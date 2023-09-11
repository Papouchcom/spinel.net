using System;
using System.Text;
using System.Windows.Forms;

using Papouch.Communication;
using Papouch.Spinel;
using Papouch.Spinel.Spinel97;
using Papouch.Utils;

using System.IO.Ports;

using System.Threading;
using System.Linq;

namespace QuidoDemo
{
    public partial class FormMain : Form
    {
        #region MainForm

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            checkFormControls();
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Papouch\\QuidoDemoNet");
            if (key != null)
            {
                object val;

                val = key.GetValue("ConnectionString");
                if (val != null) textBoxConnectionString.Text = val.ToString();

                val = key.GetValue("DeviceString");
                if (val != null) textBoxDeviceString.Text = val.ToString();
                key.Close();
            }
            reloadSerialPortNames(sender, e);
            radioButtonProviderChange(sender, e);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Papouch\\QuidoDemoNet");
            if (key != null)
            {
                key.SetValue("ConnectionString", textBoxConnectionString.Text);
                key.SetValue("DeviceString", textBoxDeviceString.Text);
                key.Close();
            }
        }

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
                //textBox_ClientLog.Text += text + "\r\n";
            }
        }

        #endregion

        private void checkFormControls()
        {
            bool bc = (ci != null);
            bool ba = (bc) && (ci.Active);
            bool bq = (ba) && (quido != null);

            buttonCiCreate.Enabled = !bc;
            buttonCiDestroy.Enabled = bc;

            buttonCiConnect.Enabled = !ba && bc;
            buttonCiDisconnect.Enabled = ba;

            buttonQuidoCreate.Enabled = !bq && ba;
            buttonQuidoDestroy.Enabled = bq;

            buttonListenToggle.Enabled = bq;
            buttonListenToggle.Text = ((quido != null) && (quido.Listen) ? "SET Async Listener OFF" : "SET Async Listener ON");

            buttonGetInfo.Enabled = bq;
            buttonGetInfoCore.Enabled = bq;
            buttonGetSn.Enabled = bq;

            buttonGetOutputs.Enabled = bq;
            buttonSetOutputOn.Enabled = bq;
            buttonSetOutputOff.Enabled = bq;
            numericOutputIndex.Enabled = bq;
            labelOutputIndex.Enabled = bq;
            numericOutputTimer.Enabled = bq;
            labelOutputTimer.Enabled = bq;

            buttonGetInputs.Enabled = bq;
            buttonGetIOCount.Enabled = bq;

            buttonGetCounter.Enabled = bq;
            buttonGetCounterSettings.Enabled = bq;
            buttonSetCounterSettings.Enabled = bq;

            buttonSetAutonotifyOn.Enabled = bq;
            buttonGetAutonotify.Enabled = bq;
            buttonSetAutonotifyOff.Enabled = bq;

            buttonGetTemp.Enabled = bq;
        }

        #endregion

        #region Communication Interface

        private ICommunicationInterface ci = null;

        private void buttonCiCreate_Click(object sender, EventArgs e)
        {
            if (textBoxConnectionString.Text.IndexOf("TCP_CLIENT") > 0)
            {
                ci = new CiTcpClient();
                ci.ConfigString = textBoxConnectionString.Text;
            }
            else
            {
                try
                {
                    ci = new CiSerialPort();
                    ci.ConfigString = textBoxConnectionString.Text;
                }
                catch (Exception ex)
                {
                    LogMsg("Exception: {0}", ex.Message);
                }
            }
           
            LogMsg("CREATE CI");
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
                quido = null;
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

        #region Quido

        public Papouch.Spinel.Spinel97.Device.Quido.Quido quido = null;


        // vytvo�en� objektu "quido"
        private void buttonQuidoCreate_Click(object sender, EventArgs e)
        {
            if (ci != null)
            {
                quido = new Papouch.Spinel.Spinel97.Device.Quido.Quido(ci, 0xFE);
                quido.ConfigString = textBoxDeviceString.Text;
                
                quido.OnPacketReceive += new Papouch.Spinel.Spinel97.Device.Device.EventSpinelPacketReceive(PacketReceive);
                quido.OnInputsChange += new Papouch.Spinel.Spinel97.Device.Quido.Quido.EventQuidoInputsChange(InputsChange);
                quido.OnInputChange += new Papouch.Spinel.Spinel97.Device.Quido.Quido.EventQuidoInputChange(InputChange);

                LogMsg("Quido object created.");
                checkFormControls();
            }
            else
            {
                LogMsg("Initialize Communicatioin Interface first!");
            }
        }

        // zru�en� objektu quido
        private void buttonQuidoDestroy_Click(object sender, EventArgs e)
        {
            quido = null;
            checkFormControls();
        }

        #endregion

        #region Commands: Get INFO - basic instructions

        private void buttonGetInfo_Click(object sender, EventArgs e)
        {
            SpinelDeviceVersion ver;

            if (quido.CmdGetInfo(out ver))
            {
                LogMsg("command GetINFO:\t" + ver.Description + " v." + ver.ProductId + " " + ver.HardwareId + " " + ver.SoftwareId);
            }
            else
            {
                LogMsg("Get INFO - failure");
            }
        }

        private void buttonGetInfoCore_Click(object sender, EventArgs e)
        {
            // uk�zka mo�nosti vlastn� komunikace po komunika�n�m rozhran�

            if (ci != null)
            {
                LogMsg("Send INST 'INFO'");

                DateTime dt = DateTime.Now;

                PacketSpinel97 txPacket = new PacketSpinel97(0xF3);
                PacketSpinel97 rxPacket;

                if (quido.SendAndReceive(ref txPacket, out rxPacket))
                {
                    int i = (DateTime.Now.Millisecond - dt.Millisecond);
                    string s = Encoding.ASCII.GetString(rxPacket.SDATA) + " " + i;
                    LogMsg(s);
                }
            }
        }

        private void buttonGetSn_Click(object sender, EventArgs e)
        {
            if (ci!=null)
            {
                SpinelDeviceSN sn;

                if (quido.CmdGetSN(out sn) && sn.Valid)
                {
                    LogMsg("Get SN - sn: " + sn.SerialNumber.ToString() + ", type: " + sn.DeviceType.ToString() + ", factory_data: " + sn.FactoryData.ToString());
                }
                else
                {
                    LogMsg("Get SN - failure");
                }
            }

        }

        #endregion

        #region Commands: Outputs

        private void buttonGetOutputs_Click(object sender, EventArgs e)
        {
            if (quido != null)
            {
                LogMsg("*** GetOutputs ***");

                bool[] outputs = null;
                if (quido.CmdGetOutputs(out outputs))
                {
                    for (int index = 0; index < outputs.Length; index++)
                    {
                        LogMsg("Output " + index.ToString() + " is " + ((outputs[index]) ? "ON" : "OFF"));
                    }
                }
            }
        }

        private void buttonSetRele1On_Click(object sender, EventArgs e)
        {
            if (quido != null)
            {
                byte index = (byte)numericOutputIndex.Value;
                byte timer = (byte)numericOutputTimer.Value;

                if (quido.CmdSetOutput(index, true, timer))
                {
                    LogMsg("Quido Rele {0} = on", index);
                }
                else
                {
                    LogMsg("Quido Rele {0} set off - failure", index);
                }
            }
        }

        private void buttonSetRele1Off_Click(object sender, EventArgs e)
        {
            if (quido != null)
            {
                byte index = (byte)numericOutputIndex.Value;
                byte timer = (byte)numericOutputTimer.Value;

                if (quido.CmdSetOutput(index, false, timer))
                {
                    LogMsg("Quido Rele {0} = off", index);
                }
                else
                {
                    LogMsg("Quido Rele {0} set on - failure", index);
                }
            }
        }

        #endregion

        #region Commands: Inputs

        private void buttonGetIOCount_Click(object sender, EventArgs e)
        {
            if (quido != null)
            {
                if (quido.CmdGetIOCounts(out int inputsCount, out int outputsCount, out int thermsCount))
                {
                    LogMsg($"Quido has {inputsCount} inputs, {outputsCount} outputs and {thermsCount} thermometer");
                }
                else
                {
                    LogMsg("Failed");
                }
            }
        }

        private void buttonGetInputs_Click(object sender, EventArgs e)
        {
            if (quido != null)
            {
                bool[] inputs = null;
                if (quido.CmdGetInputs(out inputs))
                {
                    string bits = string.Join("", inputs.Select(b => b ? "1" : "0"));
                    StringBuilder result = new StringBuilder();
                    for (int i = 0; i < bits.Length; i++)                    {
                        result.Append(bits[i]);
                        if ((i + 1) % 4 == 0 && i != bits.Length - 1) result.Append(' ');
                    }
                    LogMsg("GetInputs: " + result.ToString());
                }
                else
                {
                    LogMsg("Failed");
                }
            }
        }

        #endregion

        #region Commands: Counters

        private void buttonGetCounter_Click(object sender, EventArgs e)
        {
            byte i = 1;

            if (quido != null)
            {
                int counter;
                if (quido.CmdGetCounter(i, out counter))
                {
                    LogMsg("Counter #" + i.ToString() + " = " + counter.ToString());
                }
            }
        }

        private void buttonGetCounterSettings_Click(object sender, EventArgs e)
        {
            byte i = 1;

            if (quido != null)
            {
                bool rising;
                bool falling;
                if (quido.CmdGetCounterSettings(i, out rising, out falling))
                {
                    LogMsg("Counter #" + i.ToString() + " get settings - rising = " + ((rising) ? "on" : "off") + ", falling = " + ((falling) ? "on" : "off"));
                }
            }
        }

        private void buttonSetCounterSettings_Click(object sender, EventArgs e)
        {
            byte i = 1;

            if (quido != null)
            {
                if (quido.CmdSetCounterSettings(i, true, true))
                {
                    LogMsg("Counter #" + i.ToString() + " set settings - rising = on, falling = on ");
                }
            }
        }

        #endregion

        #region Commands: Temperature

        private void buttonGetTemp_Click(object sender, EventArgs e)
        {
            if (quido != null)
            {
                if (quido.CmdGetTemperature(out float temp))
                    LogMsg($"Current temperature is {temp} �C");
                else
                    LogMsg("Temperature is not available.");
            }
        }

        #endregion

        #region Commands: Autonotify

        private void buttonGetAutonotify_Click(object sender, EventArgs e)
        {
            if (quido != null)
            {
                byte format;
                bool[] mask;
                if (quido.CmdGetAutoNotify(out format, out mask))
                {
                    LogMsg("Autonotify is set to: " + format.ToString());
                    for (int i = 0; i < mask.Length; i++)
                    {
                        LogMsg("Input " + i.ToString() + " is " + ((mask[i]) ? "ON" : "OFF"));
                    }

                }
                else
                {
                    LogMsg("Get Autonotify - failure !");
                }
            }
        }

        private void buttonSetAutonotifyOn_Click(object sender, EventArgs e)
        {
            if (quido != null)
            {
                if (quido.CmdSetAutoNotify(true))
                {
                    LogMsg("Autonotify is now set to : ON");
                }
            }
        }

        private void buttonSetAutonotifyOff_Click(object sender, EventArgs e)
        {
            if (quido != null)
            {
                if (quido.CmdSetAutoNotify(false))
                {
                    LogMsg("Autonotify is now set to : OFF");
                }
            }
        }
        #endregion

        #region Async Event Mode
        //provider=TCP_CLIENT;Host=192.168.2.93;Port=10001
        // Po inicializaci objektu Quido je aktivn� synchron� re�im. 
        // V synchron�m re�imu jsou data odes�l�na i p�ij�m�na v kontextu vol�n� dan� funkce - Nejsou thread-safe !
        // Asynchronn� re�im je mo�n� aktivovat vol�n�m funkce "quido.StartListen()", deaktivace asyncronn�ho re�imu se prov�d� funkc� "quido.StopListen()"
        // V asyncronn�m re�imu je aktivov�n backgroundworker, kter� vy�izuje po�adavky na odes�l�n� paket� a tak� p�ij�m�, parseuje a p�ruje p�ijat� pakety. 
        // Synchronizace mezi vol�n�m p��kazu a odpov�d� je prov�d�na pomoc� event�.
        // Funkce v Asynchronn�m re�imu jsou thread-safe. Ud�losti Quida nejsou thread-safe.

        // P�ep�n�n� komunika�n�ho re�imu
        private void buttonListenToggle_Click(object sender, EventArgs e)
        {
            if (quido != null)
            {
                if (!quido.Listen)
                {
                    quido.StartListen();

                    checkFormControls();
                }
                else
                {
                    quido.StopListen();
                    buttonListenToggle.Text = "SET Async Listener ON";
                }
            }
        }

        // p��jem paket� 
        private void PacketReceive(PacketSpinel97 packet)
        {
            LogMsg("Receive Packet > " + PapUtils.ConvertBinToHex(packet.GetBin()));
        }

        // Pozor! Modul Quido odes�l� informace o stavu vstup�/v�stup� jako bitovou masku. Podle po�tu dan�ch IO je v�dy pou�it odpov�daj�c� po�et Byte pro p�enos informac�.
        // Proto se na n�kter�ch modulech p�en�� v�ce vstup�/v�stup� ne� je jejich skete�n� fyzick� po�et ! Skte�n� po�et IO lze zjistit pomoc� funkce INFO.

        // funkce je vol�na v�dy kdy� p�ijde od Quida samovoln� vyslan� zpr�va
        private void InputsChange(Papouch.Spinel.Spinel97.Device.Quido.Quido quido, Boolean[] inputs)
        {
            for (int index = 0; index < inputs.Length; index++)
            {
                LogMsg("AUTONOTIFY - Input " + index.ToString() + " is " + ((inputs[index]) ? "ON" : "OFF"));
            }
        }

        // funkce je vol�na pro ka�d� vstup p�i detekci jeho zm�ny - po inicializaci (p�i prvn�m vol�n�) nen� zn�m p�edchoz� stav, 
        // proto se na poprv� zavol� funkce pro v�echny vstupy. P�i prvn�m vol�n�m je hodnota io_old_stat a io_new_stat stejn�, p�i zm�n� jsou rozd�ln�.
        private void InputChange(Papouch.Spinel.Spinel97.Device.Quido.Quido quido, int io_index, bool io_old_stat, bool io_new_stat)
        {
            LogMsg("AUTONOTIFY - Input change: " + io_index + " is " + ((io_new_stat) ? "ON" : "OFF"));
        }

        #endregion

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

    }
}