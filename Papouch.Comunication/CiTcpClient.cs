using System;
using System.Text;

using System.Net.Sockets;
using Papouch.Communication;

namespace Papouch.Communication
{

    interface ICiTcpClient
    {
        string Host { get; set; }
        int Port { get; set; }
    }

    // příklad nastavení ConnectionString:
    // provider=TCP_CLIENT;host=192.168.1.84;port=10001

    public class CiTcpClient : ComunicationInterface, ICiTcpClient
    {
        private string aHost = "127.0.0.1";
        private int aPort = 10001;
        TcpClient tcpClient = null;

        public CiTcpClient()
        {
           return;
        }

        public override long BytesToRead()
        {
            if (tcpClient != null)
                return tcpClient.Available;
            else
                return 0;
        }

        #region TcpClient port properties
        
        [CsPropertyAttribute("Host")]
        public string Host
        {
            get { return this.aHost; }
            set { this.aHost = value; }
        }

        [CsPropertyAttribute("Port")]
        public int Port
        {
            get { return this.aPort; }
            set { this.aPort = value; }
        }
        #endregion


        public override bool IsConnected()
        {
            return ((tcpClient != null) && (tcpClient.Connected));
        }

        public override bool Active
        {
            get { return IsConnected(); }
            set { if (value) Open(); else Close(); }
        }

        public override bool OpenInternal(bool wait)
        {
            lock (this)
            {
                try
                {
                    tcpClient = new System.Net.Sockets.TcpClient(aHost, aPort);
                    BaseStream = tcpClient.GetStream();
                    return tcpClient.Connected;
                }
                catch
                {
                    return false;
                }
            }
        }

        public override bool CloseInternal(bool wait)
        {
            if ((tcpClient != null) && (tcpClient.Connected))
            {
                tcpClient.Close();
            }
            return true;
        }

    }
}
