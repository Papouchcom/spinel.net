using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;

using Papouch.Communication;
using Papouch.Utils;

namespace WindowsFormsApplication1
{
    public partial class FormCommIntDemo : Form
    {
        #region Logging support

        public delegate void LogCallBack(string text, params object[] args);

        public void LogMsg(string text, params object[] args)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new LogCallBack(LogMsg), text, args);
            }
            else
            {
                richTextBox1.AppendText(String.Format(text, args) + "\r\n");
            }
        }

        #endregion

        #region Form UI support

        public FormCommIntDemo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkFormControls();
            reloadSerialPortNames(sender, e);
            radioButtonProviderChange(sender, e);
        }

        private void reloadSerialPortNames(object sender, EventArgs e)
        {
            comboBoxSerialPortName.BeginUpdate();
            try
            {
                comboBoxSerialPortName.Items.Clear();

                string[] ports = SerialPort.GetPortNames();
                foreach (string port in ports)
                {
                    comboBoxSerialPortName.Items.Add(port);
                }
            }
            finally
            {
                comboBoxSerialPortName.EndUpdate();
            }
        }

        private void radioButtonProviderChange(object sender, EventArgs e)
        {
            textBoxTcpPort.Enabled = radioButtonTcpClient.Checked;
            textBoxTcpHost.Enabled = radioButtonTcpClient.Checked;

            comboBoxSerialPortName.Enabled = radioButtonSerialPort.Checked;
            comboBoxSerialPortBaudRate.Enabled = radioButtonSerialPort.Checked;

            providerSettingsChange(sender, e);
        }

        private void providerSettingsChange(object sender, EventArgs e)
        {
            string s = "";
            if (radioButtonSerialPort.Checked)
            {
                s += "provider=SERIAL_PORT;";
                s += "PortName=" + comboBoxSerialPortName.SelectedItem + ";";
                s += "BaudRate=" + comboBoxSerialPortBaudRate.SelectedItem + ";";
            }
            else
            if (radioButtonTcpClient.Checked)
            {
                s += "provider=TCP_CLIENT;";
                s += "Host=" + textBoxTcpHost.Text + ";";
                s += "Port=" + textBoxTcpPort.Text + ";";
            }
            textBoxConnectionString.Text = s;
        }

        private void checkFormControls()
        {
            bool bc = (ci != null);
            bool ba = (bc) && (ci.Active);

            buttonCiCreate.Enabled = !bc;
            buttonCiDestroy.Enabled = bc;

            buttonCiConnect.Enabled = !ba && bc;
            buttonCiDisconnect.Enabled = ba;

            buttonReadBin.Enabled = ba;
            buttonReadText.Enabled = ba;
            buttonSendText.Enabled = ba;
            buttonSendBin.Enabled = ba;
        }
        #endregion

        #region CI (Communication Interface) Create, Connect, Disconnect, Destroy

        private ICommunicationInterface ci = null;

        private void buttonCiCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxConnectionString.Text.IndexOf("TCP_CLIENT") > 0)
                {
                    ci = new CiTcpClient();
                    ci.ConfigString = textBoxConnectionString.Text;
                }
                else
                {
                    ci = new CiSerialPort();
                    ci.ConfigString = textBoxConnectionString.Text;
                }

                LogMsg("CREATE CI");
            }
            catch (Exception ex)
            {
                LogMsg("Exception: " + ex.Message);
            }
            checkFormControls();
        }

        private void buttonCiConnect_Click(object sender, EventArgs e)
        {
            if (ci.Open(true))
            {
                LogMsg(string.Format("CONNECT - ok ({0})", ci.GetConfigString(false)));
            }
            else
            {
                LogMsg("CONNECT - err: [ci.Open() = false]");
            }
            checkFormControls();
        }

        private void buttonCiDisconnect_Click(object sender, EventArgs e)
        {
            if (ci.Active)
            {
                if (ci.Close(true))
                {
                    LogMsg("DISCONNECT - ok");
                }
                else
                {
                    LogMsg("DISCONNECT - err: [ci.Close = false]");
                }
            }
            checkFormControls();
        }

        private void buttonCiDestroy_Click(object sender, EventArgs e)
        {
            if (ci != null)
            {
                ci.Close();
                ci = null;
                LogMsg("DESTROY - ok");
            }
            else
            {
                LogMsg("DESTROY - err: ci is NULL");
            }
            checkFormControls();
        }

        #endregion

        #region CI (Communication Interface) Send/Transmit

        private void buttonSendBin_Click(object sender, EventArgs e)
        {
            if ((ci != null) && (ci.Active))
            {
                byte[] data = { 0x00, 0x01, 0xFF };
                ci.Write(data, 0, 3);
            }
        }

        private void buttonSendText_Click(object sender, EventArgs e)
        {
            try
            {
                ci.Write("Hello!\r");
            }
            catch (Exception ex)
            {
                LogMsg("Exception: " + ex.Message);
            }
        }

        #endregion

        #region CI (Communication Interface) Read/Recive
        private void buttonReadBin_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data;
                int len = ci.Read(out data);
                LogMsg("RX len: {0}, data (hex): {1}", len, PapUtils.ConvertBinToHex(data));
            }
            catch (Exception ex)
            {
                LogMsg("Exception: " + ex.Message);
            }
        }

        private void buttonReadText_Click(object sender, EventArgs e)
        {
            try
            {
                string s = ci.Read();
                LogMsg("Rx: " + s);

            }
            catch (Exception ex)
            {
                LogMsg("Exception: " + ex.Message);
            }
        }

        #endregion

    }
}
