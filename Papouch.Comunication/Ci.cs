using System;
using System.IO;
using System.Reflection;
using System.Net.Sockets;

namespace Papouch.Communication
{

    #region Interfaces
    public interface ICommunicationInterface : ICsPropertyInterface
    {
        bool Open();
        bool Open(string cs);
        bool Open(bool wait);
        bool Open(string cs, bool wait);

        bool Close();
        bool Close(bool wait);

        bool Active { get; set; }

        void Write(byte[] buffer, int offset, int count);
        void Write(string text);

        int Read(out byte[] buffer);
        int Read(ref byte[] buffer, int offset, int count);
        bool Read(out string rxData);
        string Read();

        long BytesToRead();

        void PurgeRx();
        void PurgeTx();

        Stream getBaseStream();
    }

    public interface ICommunicationInterfaceCore
    {
        bool OpenInternal(bool wait);
        bool CloseInternal(bool wait);
    }
    #endregion

    public class ComunicationInterface : CsPropertyObject, ICommunicationInterface, ICommunicationInterfaceCore
    {
        protected Stream BaseStream = null;

        public virtual Stream getBaseStream()
        {
            return BaseStream;
        }

        public ComunicationInterface()
        {
        }

        public ComunicationInterface(string ConfigString)
        {
            this.ConfigString = ConfigString;
        }

        public virtual void PurgeRx() { }

        public virtual void PurgeTx() { }

        #region Open methods
        public virtual bool OpenInternal(bool wait)
        {
            return false;
        }

        public bool Open()
        {
            return OpenInternal(false);
        }

        public bool Open(string cs)
        {
            ParseCs(cs);
            return OpenInternal(false);
        }

        public bool Open(bool wait)
        {
            return OpenInternal(wait);
        }

        public bool Open(string cs, bool wait)
        {
            ParseCs(cs);
            return OpenInternal(wait);
        }
        #endregion

        #region Close methods
        public virtual bool CloseInternal(bool wait)
        {
            return false;
        }

        public bool Close()
        {
            return CloseInternal(false);
        }

        public bool Close(bool wait)
        {
            return CloseInternal(wait);
        }
        #endregion

        public virtual bool IsConnected()
        {
            return false;
        }

        public virtual bool Active
        {
            get { return IsConnected(); }
            set
            {
                if (value)
                {
                    OpenInternal(true);
                }
                else
                {
                    CloseInternal(true);
                }
            }
        }

        #region Write methods
        /// <summary>
        /// Writes a specified number of bytes to an output buffer at the specified offset.
        /// </summary>
        /// <param name="buffer">The byte array to write the output to.</param>
        /// <param name="offset">The offset in the buffer array to begin writing.</param>
        /// <param name="count">The number of bytes to write.</param>
        public virtual void Write(byte[] buffer, int offset, int count)
        {
            if (BaseStream != null)
            {
                BaseStream.Write(buffer, offset, count);
            }
            else
            {
                throw new Exception("No active connection");
            }
        }

        /// <summary>
        /// Writes an output buffer at the specified offset.
        /// </summary>
        /// <param name="buffer">The byte array to write the output to.</param>
        public virtual void Write(byte[] buffer)
        {
            if (BaseStream != null)
            {
                BaseStream.Write(buffer, 0, buffer.Length);
            }
            else
            {
                throw new Exception("No active connection");
            }
        }

        /// <summary>
        /// Writes the specified string to the output buffer. 
        /// </summary>
        /// <param name="text">The string to write to the output buffer.</param>
        public void Write(string text)
        {
            if (BaseStream != null)
            {
                BaseStream.Write(System.Text.Encoding.UTF8.GetBytes(text), 0, text.Length);
            }
            else
            {
                throw new Exception("No active connection");
            }
        }
        #endregion

        #region Read methods

        public virtual long BytesToRead()
        {
            if (BaseStream != null)
            {
                return BaseStream.Length;
            }
            else
            {
                throw new Exception("No active connection");
            }
        }

        private System.Text.Encoding asciiEncoding = new System.Text.ASCIIEncoding();

        /// <summary>
        /// Read string from the output buffer. 
        /// </summary>
        public string Read()
        {
            if (BaseStream != null)
            {
                byte[] dataRx = new byte[BytesToRead()];
                BaseStream.Read(dataRx, 0, dataRx.Length);
                return asciiEncoding.GetString(dataRx);
            } 
            else
            {
                throw new Exception("No active connection");
            }
        }

        public bool Read(out string rxData)
        {
            rxData = null;
            if (BaseStream != null)
            {
                byte[] dataRx = new byte[BytesToRead()];
                BaseStream.Read(dataRx, 0, dataRx.Length);
                rxData = asciiEncoding.GetString(dataRx);
                return (rxData != null);
            }
            else
            {
                throw new Exception("No active connection");
            }
        }

        /// <summary>
        /// Reads a sequence of bytes from the input stream
        /// </summary>
        public int Read(ref byte[] buffer, int offset, int count)
        {
            int result = 0;
            if (BaseStream != null)
            {
                result = BaseStream.Read(buffer, offset, count);
                return result;
            }
            else
            {
                throw new Exception("No active connection");
            }
        }

        public int Read(out byte[] buffer)
        {
            buffer = null;
            if (BaseStream != null)
            {
                int len = (int)BytesToRead();
                buffer = new byte[len];
                if (len > 0)
                {
                    BaseStream.Read(buffer, 0, buffer.Length);
                }
                return buffer.Length;
            }
            else
            {
                throw new Exception("No active connection");
            }
        }
        #endregion

    }
}
