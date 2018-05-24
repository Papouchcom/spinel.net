using System;
using System.Text;
using System.Collections.Generic;

using Papouch.Spinel.Spinel97;
using Papouch.Communication;

namespace Papouch.Spinel
{
    //enum SpinelDeviceStatus = ( NotInitialized, Initialized );

    class SpinelDevice
    {
       
        private Papouch.Spinel.SpinelStack fSpinelStack = null;
        public Papouch.Spinel.SpinelStack SpinelStack
        {
            set
            {
                if (fSpinelStack != value)
                {
                    if (fSpinelStack != null)
                    {
                        fSpinelStack.UnregisterDevice(this);
                    }
                    fSpinelStack = value;
                    if (fSpinelStack != null)
                    {
                        fSpinelStack.RegisterDevice(this);
                    }
                }
            }
            get
            {
                return fSpinelStack;
            }
        }

        private bool SendAndReceive(Spinel97.PacketSpinel97 packetTx, Spinel97.PacketSpinel97 packetRx, int timeout)
        {
            if (fSpinelStack != null)
            {
                return fSpinelStack.SendAndReceive(packetTx, out packetRx, timeout);
            }
            return false;
        }

        private void PacketReceive(PacketSpinel97 packetRx)
        {

        }

    }
    
    class SpinelStack
    {
        private System.IO.Stream rxBuffer = new System.IO.MemoryStream(1024);

        private Papouch.Communication.ComunicationInterface fCommunicationDevice = null;
        public Papouch.Communication.ComunicationInterface CommunicationIterface        
        {
            set
            {
                fCommunicationDevice = value;
            }
            get
            {
                return fCommunicationDevice;
            }
        }

        private List<Papouch.Spinel.SpinelDevice> fDevices = new List<Papouch.Spinel.SpinelDevice>();
        public bool RegisterDevice(Spinel.SpinelDevice device)
        {
            if (!fDevices.Contains(device))
            {
                fDevices.Add(device);
                device.SpinelStack = this;
                return true;
            }
            return false;
        }
        
        public bool UnregisterDevice(Spinel.SpinelDevice device)
        {
            if (fDevices.Contains(device) && (device.SpinelStack == this))
            {
                device.SpinelStack = null;
                return fDevices.Remove(device);
            }
            return false;
        }

        public bool SendAndReceive(Spinel97.PacketSpinel97 packetTx, out Spinel97.PacketSpinel97 packetRx, int timeout)
        {
           
            packetRx = null;

            PacketSend(packetTx);

            int rxtimeout = System.Environment.TickCount + timeout;

            while (rxtimeout > System.Environment.TickCount)
            {
                System.Threading.Thread.Sleep(10);
            }

            return false;
        }

        private void PacketSend(PacketSpinel97 packetTx)
        {

        }

    }
}
