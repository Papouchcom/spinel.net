using System;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using Papouch.Spinel.Spinel97;
using Papouch.Communication;

namespace Papouch.Spinel.Spinel97.Device
{
    public class Device : CsPropertyObject
    {
        public byte S97_INST_ReadInfo = 0xF3;     // Čtení informací o výrobku (typové)
        public byte S97_INST_ReadSN         = 0xFA;     // Čtení výrobních údajů

        internal ICommunicationInterface ci = null;
        private byte fADR = 0xFE;
        private byte fSIG = 0x00;

        public Device(ICommunicationInterface ci, byte spinelADR)
        {
            this.ci = ci;
            this.ADR = spinelADR;
        }

        public Boolean CmdGetInfo(out SpinelDeviceVersion version)
        {
            version = null;

            if ((ci != null) && (ci.Active))
            {
                PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_ReadInfo);
                txPacket.ADR = fADR;

                PacketSpinel97 rxPacket;

                //                if (Spinel97Utils.SendAndReceive(ref this.ci, ref txPacket, out rxPacket))
                if (this.SendAndReceive(ref txPacket, out rxPacket))
                {
                    
                    version = new SpinelDeviceVersion(Encoding.ASCII.GetString(rxPacket.SDATA));
                    return version.Valid;
                }
            }

            return false;
        }

        public Boolean CmdGetSN(out SpinelDeviceSN dev_sn)
        {
            dev_sn = null;

            if ((ci != null) && (ci.Active))
            {
                PacketSpinel97 txPacket = new PacketSpinel97(S97_INST_ReadSN);
                txPacket.ADR = fADR;

                PacketSpinel97 rxPacket;

                if (this.SendAndReceive(ref txPacket, out rxPacket))
                {
                    dev_sn = new SpinelDeviceSN(rxPacket.SDATA);
                    return dev_sn.Valid;
                }
            }

            return false;
        }


        [CsProperty("ADR", 0xFE)]
        public byte ADR
        {
            set { this.fADR = value;  }
            get { return this.fADR; }
        }

        private readonly BackgroundWorker bwListen = new BackgroundWorker();
        private ManualResetEvent bwListen_stopped = new ManualResetEvent(false);

        public bool Listen
        {
            get { return bwListen.IsBusy; }
        }

        private void bwListen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bwListen_stopped.Set();
        }

        public void StartListen()
        {
            if (!bwListen.IsBusy)
            {
                bwListen.DoWork += bwListen_DoWork;
                bwListen.RunWorkerCompleted += bwListen_RunWorkerCompleted;
                bwListen.WorkerSupportsCancellation = true;
                bwListen.RunWorkerAsync();
            }
        }

        public void StopListen()
        {
            bwListen.CancelAsync();
        }

        private byte[] rx_buffer = new byte[4096];
        private int rx_buffer_index = 0;

        public delegate void EventSpinelPacketReceive(PacketSpinel97 packet);
        public event EventSpinelPacketReceive OnPacketReceive = null;

        public virtual void PacketReceive(ref PacketSpinel97 packet)
        {
            Debug.Print("Receive packet {0}", packet.INST);
            OnPacketReceive(packet);

            if (packet.INST < 0x10)
            {
                foreach (SpinelStackRec ssr in packets_to_receive) 
                {
                    if (ssr.CheckReceivePacket(ref packet))
                    {
                        packets_to_receive.Remove(ssr);
                        return;
                    }
                }
            }
        }

        private void bwListen_DoWork(object sender, DoWorkEventArgs e)
        {
            bwListen_stopped.Reset();
            
            int i = 0;
            int del = 0;
            int len = 0;
            PacketSpinel97 rxPacket = null;
            
            int bytesToRead = 0;
            while (!bwListen.CancellationPending)
            {
                if (packets_to_send.Count > 0)
                {
                    SpinelStackRec ssr = packets_to_send.Peek();
                    packets_to_send.Dequeue();
                    //packets_to_send[0];
                    //packets_to_send.RemoveAt(0);

                    byte[] txData = ssr.tx_packet.GetBin();
                    ci.Write(txData, 0, txData.Length);

                    packets_to_receive.Add(ssr);
                    
                    ssr.Sended();
                }
                
                System.Threading.Thread.Sleep(1);
                bytesToRead = (int)ci.BytesToRead();
                if (bytesToRead > 0)
                {
                    rx_buffer_index += ci.Read(ref rx_buffer, rx_buffer_index, bytesToRead);

                    Debug.Print("{0}/{1}", bytesToRead, rx_buffer_index);

                    i = 0;
                    while ((i+8 < rx_buffer_index))
                    {
                        del = 0;
                        if ((rx_buffer[i] == 0x2A) && (rx_buffer[i+1] == 0x61))
                        {
                            len = rx_buffer[i + 2] * 0x100 + rx_buffer[i + 3];

                            del = len + 4 + i;

                            if (del > rx_buffer_index) break;

                            byte[] buffer = new byte[del];
                            Array.Copy(rx_buffer, buffer, del);
                            
                            rxPacket = null;
                            Spinel97Utils.GetSpinelPacket(ref buffer, del, out rxPacket);      
                            if (rxPacket != null)
                            {
                                Debug.Print(Papouch.Utils.PapUtils.ConvertBinToHex(buffer));
                                PacketReceive(ref rxPacket);
                            }
                        }

                        if (del > 0)
                        {
                            Array.Copy(rx_buffer, del, rx_buffer, 0, rx_buffer_index - del);
                            rx_buffer_index = rx_buffer_index - del;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
        }

        public bool SendAndReceive( ref PacketSpinel97 txPacket, out PacketSpinel97 rxPacket)
        {
            txPacket.SIG = fSIG++;

            if (!bwListen.IsBusy)
            {
                byte[] txData = txPacket.GetBin();
                ci.Write(txData, 0, txData.Length);

                return Papouch.Spinel.Spinel97.Spinel97Utils.Receive(ref ci, out rxPacket, 250);
            }
            else
            {
                SpinelStackRec ssr = new SpinelStackRec(txPacket);
                packets_to_send.Enqueue(ssr);
                bool result = ssr.WaitFor(TimeSpan.FromSeconds(1),TimeSpan.FromMilliseconds(200));

                rxPacket = ssr.rx_packet;
                return result;
            }
        }

        private Queue<SpinelStackRec> packets_to_send = new Queue<SpinelStackRec>();
        private List<SpinelStackRec> packets_to_receive = new List<SpinelStackRec>();

    }

    public class SpinelStackRec
    {
        public PacketSpinel97 tx_packet = null;
        public PacketSpinel97 rx_packet = null;

        ManualResetEvent notify_rx_packet_receive = new ManualResetEvent(false);
        ManualResetEvent notify_tx_packet_send = new ManualResetEvent(false);

        public SpinelStackRec(PacketSpinel97 tx_packet = null)
        {
            this.tx_packet = tx_packet;
        }

        public TimeSpan timeout_send;
        public TimeSpan timeout_receive;

        public bool WaitForReceive(TimeSpan timeout)
        {
            this.timeout_receive = timeout;
            return notify_rx_packet_receive.WaitOne(timeout);
        }

        public bool WaitForSend(TimeSpan timeout)
        {
            this.timeout_send = timeout;
            return notify_tx_packet_send.WaitOne(timeout);
        }

        public bool WaitFor(TimeSpan timeout_send, TimeSpan timeout_receive)
        {
            if (WaitForSend(timeout_send))
            {
                return WaitForReceive(timeout_receive);
            }
            return false;
        }

        public void Sended()
        {
            this.notify_tx_packet_send.Set();
        }

        public bool CheckReceivePacket(ref PacketSpinel97 rxPacket)
        {
            if ((rxPacket.INST < 0x10) && (rxPacket.SIG == this.tx_packet.SIG))
            {
                this.rx_packet = rxPacket;
                this.notify_rx_packet_receive.Set();
                return true;
            }
            return false;
        }
    }
}
