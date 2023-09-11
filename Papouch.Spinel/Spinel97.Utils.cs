using System;
using System.Text;
using System.Diagnostics;

using Papouch.Communication;
using Papouch.Utils;

namespace Papouch.Spinel.Spinel97
{
    public class Spinel97Utils
    {
        public static int GetSpinelPacket(ref byte[] data, int dataLength, out PacketSpinel97 packet)
        {
            packet = null;
            int i = 0;
            while (((i + 8) <= dataLength) && (data[i] == 0x2A) && (data[i] == 0x61)) i++;
            if ((i + 8) < dataLength)
            {
                int len = data[i + 2] * 0x100 + data[i + 3] - 5;
                if ((i + len + 8 <= dataLength) && (data[i + 8 + len] == 0x0D))
                {
                    packet = new PacketSpinel97();
                    packet.PRE = data[i];
                    packet.FRM = data[i + 1];
                    packet.ADR = data[i + 4];
                    packet.SIG = data[i + 5];
                    packet.INST = data[i + 6];

                    if (len > 0)
                    {
                        byte[] tmp = new byte[len];
                        Array.Copy(data, i + 7, tmp, 0, len);
                        packet.SDATA = tmp;
                    }

                    packet.SUM = data[i + 7 + len];
                    packet.CR = data[i + 8 + len];
                    return i + len + 8;

                }
            }
            return 0;
        }

        public static Boolean Receive(ref ICommunicationInterface ci, out PacketSpinel97 rxPacket, int timeout = 500) 
        {
            rxPacket = null;

            byte[] buffer = new byte[1024];                                      // přijímací buffer
            int index = 0;
            int i;

            int bytesToRead;
            DateTime dt = DateTime.Now.AddMilliseconds(timeout);                 // maximální timeout pro příjem zprávy
            while (DateTime.Now < dt)
            {
                System.Threading.Thread.Sleep(1);
                bytesToRead = (int)ci.BytesToRead();
                // if (bytesToRead > 0) Debug.Print("Rx: " + bytesToRead.ToString());
                if ((bytesToRead > 0) && (index + bytesToRead < 1024))
                {
                    index += ci.Read(ref buffer, index, bytesToRead);
                    //Debug.Print(PapUtils.ConvertBinToHex(buffer));
                    i = GetSpinelPacket(ref buffer, index, out rxPacket);        // testujme zda je již přijat kompletní paket
                    if ((rxPacket != null) && (i > 0))
                    {
                        // Debug.Print("OK: " + PapUtils.ConvertBinToHex(rxPacket.GetBin()));
                        return true;
                    }
                }
            }
            Debug.Print("Not parsed data: " + PapUtils.ConvertBinToHex(buffer));
            return false;
        }

        public static Boolean SendAndReceive(ref ICommunicationInterface ci, ref PacketSpinel97 txPacket, out PacketSpinel97 rxPacket, int timeout = 500)
        {
            rxPacket = null;
            byte[] txData = txPacket.GetBin();
            ci.Write(txData, 0, txData.Length);

            return Receive(ref ci, out txPacket, timeout);

        }
    }
}
