using System;
using System.IO.Ports;

using Papouch.Communication;


namespace Papouch.Communication
{
    public interface ICiSerialPort
    {
        string PortName { get; set; }
        int BaudRate { get; set; }
        int DataBits { get; set; }

        bool DTR { get; set; }  // Data Terinal Ready
        bool RTS { get; set; }  // Request To Send
        bool DSR { get; }       // Data Set Ready
        bool CTS { get; }       // Clear To Send
        bool CD { get; }        // Carier Detect
    }

    public class CiSerialPort : ComunicationInterface, ICiSerialPort
    {
        private SerialPort serialPort;

        public CiSerialPort() 
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = 115200;
        }

        public CiSerialPort(string ConnectionString)
        {
            base.ConfigString = ConfigString;
        }

        #region Serial port properties
        [CsPropertyAttribute("ComPort")]
        public string ComPort
        {
            get { return serialPort.PortName; }
            set { serialPort.PortName = value; }
        }

        [CsPropertyAttribute("PortName")]
        public string PortName
        {
            get { return serialPort.PortName; }
            set { serialPort.PortName = value; }
        }

        [CsPropertyAttribute("BaudRate", 9600)]
        public int BaudRate
        {
            get { return serialPort.BaudRate; }
            set { serialPort.BaudRate = value; }
        }

        [CsPropertyAttribute("DataBits", 8)]
        public int DataBits
        {
            get { return serialPort.DataBits; }
            set { serialPort.DataBits = value; }
        }

        // Summary: Gets or sets the parity-checking protocol.
        [CsPropertyAttribute("Parity", Parity.None)]
        public Parity Parity
        {
            get { return serialPort.Parity; }
            set { serialPort.Parity = value; }
        }

        //
        // Summary:
        //     Gets or sets the standard number of stopbits per byte.
        //
        // Returns:
        //     One of the System.IO.Ports.StopBits values.
        //        [CiPropertyAttribute("StopBits", StopBits.One)]
        //
        [CsPropertyAttribute("StopBits", StopBits.One)]
        public StopBits StopBits
        {
            get { return serialPort.StopBits; }
            set { serialPort.StopBits = value; }
        }
        #endregion

        #region Status signals - DTR, RTS, DSR, CTS, CD
        [CsPropertyAttribute("DTR", false)]
        public bool DTR // Data Terinal Ready
        {
            get { return serialPort.DtrEnable; }
            set { serialPort.DtrEnable = value; }
        }

        [CsPropertyAttribute("RTS", true)]
        public bool RTS // Request To Send
        {
            get { return serialPort.RtsEnable; }
            set { serialPort.RtsEnable = value; }
        }

        public bool DSR // Data Set Ready
        {
            get { return serialPort.DsrHolding; }
        }

        public bool CTS // Clear To Send
        {
            get { return serialPort.CtsHolding; }
        }

        public bool CD // Carier Detect
        {
            get { return serialPort.CDHolding; }
        }
        #endregion

        public override long BytesToRead()
        {
            return serialPort.BytesToRead;
        }

        public override bool IsConnected()
        {
            return serialPort.IsOpen;
        }

        public override bool Active
        {
            get { return IsConnected(); }
            set { if (value) Open(); else Close(); }
        }

        public override bool OpenInternal(bool wait)
        {
            bool b = false;
            lock (serialPort)
            {
                try
                {
                    serialPort.Open();
                    //serialPort.BaudRate = 115200;
                    b = serialPort.IsOpen;
                    if (b)
                    {
                        BaseStream = serialPort.BaseStream;
                    }
                } catch
                {  }
            }
            return b;
        }

        public override bool CloseInternal(bool wait)
        {
            bool b = false;
            lock (serialPort)
            {
                serialPort.Close();
                b = !serialPort.IsOpen;
            }
            return b;
        }

        public override void PurgeRx()
        {
            serialPort.DiscardInBuffer();
        }

        public override void PurgeTx()
        {
            serialPort.DiscardOutBuffer();
        }

    }
}
