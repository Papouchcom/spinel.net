namespace QuidoDemo
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBoxCommunicationInterface = new System.Windows.Forms.GroupBox();
            this.textBoxTcpPort = new System.Windows.Forms.TextBox();
            this.textBoxTcpHost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRefreshSerialPorts = new System.Windows.Forms.Button();
            this.comboBoxSerialPortBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSerialPortName = new System.Windows.Forms.ComboBox();
            this.radioButtonTcpClient = new System.Windows.Forms.RadioButton();
            this.radioButtonSerialPort = new System.Windows.Forms.RadioButton();
            this.buttonCiCreate = new System.Windows.Forms.Button();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.buttonCiDestroy = new System.Windows.Forms.Button();
            this.labelDeviceString = new System.Windows.Forms.Label();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.buttonCiConnect = new System.Windows.Forms.Button();
            this.textBoxDeviceString = new System.Windows.Forms.TextBox();
            this.buttonCiDisconnect = new System.Windows.Forms.Button();
            this.buttonQuidoCreate = new System.Windows.Forms.Button();
            this.groupBoxQuido = new System.Windows.Forms.GroupBox();
            this.numericOutputTimer = new System.Windows.Forms.NumericUpDown();
            this.labelOutputTimer = new System.Windows.Forms.Label();
            this.buttonGetOutputs = new System.Windows.Forms.Button();
            this.buttonGetTemp = new System.Windows.Forms.Button();
            this.buttonListenToggle = new System.Windows.Forms.Button();
            this.labelOutputIndex = new System.Windows.Forms.Label();
            this.numericOutputIndex = new System.Windows.Forms.NumericUpDown();
            this.buttonSetAutonotifyOff = new System.Windows.Forms.Button();
            this.buttonSetAutonotifyOn = new System.Windows.Forms.Button();
            this.buttonGetAutonotify = new System.Windows.Forms.Button();
            this.buttonGetCounterSettings = new System.Windows.Forms.Button();
            this.buttonSetCounterSettings = new System.Windows.Forms.Button();
            this.buttonGetCounter = new System.Windows.Forms.Button();
            this.buttonGetInputs = new System.Windows.Forms.Button();
            this.buttonGetInfoCore = new System.Windows.Forms.Button();
            this.buttonSetOutputOff = new System.Windows.Forms.Button();
            this.buttonSetOutputOn = new System.Windows.Forms.Button();
            this.buttonGetInfo = new System.Windows.Forms.Button();
            this.buttonQuidoDestroy = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonGetSn = new System.Windows.Forms.Button();
            this.groupBoxCommunicationInterface.SuspendLayout();
            this.groupBoxQuido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOutputTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOutputIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCommunicationInterface
            // 
            this.groupBoxCommunicationInterface.Controls.Add(this.textBoxTcpPort);
            this.groupBoxCommunicationInterface.Controls.Add(this.textBoxTcpHost);
            this.groupBoxCommunicationInterface.Controls.Add(this.label4);
            this.groupBoxCommunicationInterface.Controls.Add(this.label3);
            this.groupBoxCommunicationInterface.Controls.Add(this.buttonRefreshSerialPorts);
            this.groupBoxCommunicationInterface.Controls.Add(this.comboBoxSerialPortBaudRate);
            this.groupBoxCommunicationInterface.Controls.Add(this.label2);
            this.groupBoxCommunicationInterface.Controls.Add(this.label1);
            this.groupBoxCommunicationInterface.Controls.Add(this.comboBoxSerialPortName);
            this.groupBoxCommunicationInterface.Controls.Add(this.radioButtonTcpClient);
            this.groupBoxCommunicationInterface.Controls.Add(this.radioButtonSerialPort);
            this.groupBoxCommunicationInterface.Controls.Add(this.buttonCiCreate);
            this.groupBoxCommunicationInterface.Controls.Add(this.labelConnectionString);
            this.groupBoxCommunicationInterface.Controls.Add(this.buttonCiDestroy);
            this.groupBoxCommunicationInterface.Controls.Add(this.labelDeviceString);
            this.groupBoxCommunicationInterface.Controls.Add(this.textBoxConnectionString);
            this.groupBoxCommunicationInterface.Controls.Add(this.buttonCiConnect);
            this.groupBoxCommunicationInterface.Controls.Add(this.textBoxDeviceString);
            this.groupBoxCommunicationInterface.Controls.Add(this.buttonCiDisconnect);
            this.groupBoxCommunicationInterface.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCommunicationInterface.Name = "groupBoxCommunicationInterface";
            this.groupBoxCommunicationInterface.Size = new System.Drawing.Size(504, 237);
            this.groupBoxCommunicationInterface.TabIndex = 17;
            this.groupBoxCommunicationInterface.TabStop = false;
            this.groupBoxCommunicationInterface.Text = "Communication Interface - Initialization / Deinitialization ";
            // 
            // textBoxTcpPort
            // 
            this.textBoxTcpPort.Location = new System.Drawing.Point(112, 76);
            this.textBoxTcpPort.Name = "textBoxTcpPort";
            this.textBoxTcpPort.Size = new System.Drawing.Size(89, 20);
            this.textBoxTcpPort.TabIndex = 35;
            this.textBoxTcpPort.Text = "10001";
            this.textBoxTcpPort.TextChanged += new System.EventHandler(this.providerSettingsChange);
            // 
            // textBoxTcpHost
            // 
            this.textBoxTcpHost.Location = new System.Drawing.Point(112, 51);
            this.textBoxTcpHost.Name = "textBoxTcpHost";
            this.textBoxTcpHost.Size = new System.Drawing.Size(88, 20);
            this.textBoxTcpHost.TabIndex = 34;
            this.textBoxTcpHost.Text = "192.168.1.254";
            this.textBoxTcpHost.TextChanged += new System.EventHandler(this.providerSettingsChange);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "IP address:";
            // 
            // buttonRefreshSerialPorts
            // 
            this.buttonRefreshSerialPorts.Location = new System.Drawing.Point(397, 47);
            this.buttonRefreshSerialPorts.Name = "buttonRefreshSerialPorts";
            this.buttonRefreshSerialPorts.Size = new System.Drawing.Size(89, 23);
            this.buttonRefreshSerialPorts.TabIndex = 31;
            this.buttonRefreshSerialPorts.Text = "refresh ports";
            this.buttonRefreshSerialPorts.UseVisualStyleBackColor = true;
            // 
            // comboBoxSerialPortBaudRate
            // 
            this.comboBoxSerialPortBaudRate.FormattingEnabled = true;
            this.comboBoxSerialPortBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxSerialPortBaudRate.Location = new System.Drawing.Point(302, 76);
            this.comboBoxSerialPortBaudRate.Name = "comboBoxSerialPortBaudRate";
            this.comboBoxSerialPortBaudRate.Size = new System.Drawing.Size(88, 21);
            this.comboBoxSerialPortBaudRate.TabIndex = 30;
            this.comboBoxSerialPortBaudRate.Text = "9600";
            this.comboBoxSerialPortBaudRate.SelectedValueChanged += new System.EventHandler(this.providerSettingsChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Speed:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Port name:";
            // 
            // comboBoxSerialPortName
            // 
            this.comboBoxSerialPortName.FormattingEnabled = true;
            this.comboBoxSerialPortName.Location = new System.Drawing.Point(302, 49);
            this.comboBoxSerialPortName.Name = "comboBoxSerialPortName";
            this.comboBoxSerialPortName.Size = new System.Drawing.Size(88, 21);
            this.comboBoxSerialPortName.TabIndex = 27;
            this.comboBoxSerialPortName.Text = "COM1";
            this.comboBoxSerialPortName.SelectedIndexChanged += new System.EventHandler(this.providerSettingsChange);
            // 
            // radioButtonTcpClient
            // 
            this.radioButtonTcpClient.AutoSize = true;
            this.radioButtonTcpClient.Checked = true;
            this.radioButtonTcpClient.Location = new System.Drawing.Point(18, 29);
            this.radioButtonTcpClient.Name = "radioButtonTcpClient";
            this.radioButtonTcpClient.Size = new System.Drawing.Size(115, 17);
            this.radioButtonTcpClient.TabIndex = 26;
            this.radioButtonTcpClient.TabStop = true;
            this.radioButtonTcpClient.Text = "TCP socket (client)";
            this.radioButtonTcpClient.UseVisualStyleBackColor = true;
            this.radioButtonTcpClient.CheckedChanged += new System.EventHandler(this.radioButtonProviderChange);
            // 
            // radioButtonSerialPort
            // 
            this.radioButtonSerialPort.AutoSize = true;
            this.radioButtonSerialPort.Location = new System.Drawing.Point(207, 29);
            this.radioButtonSerialPort.Name = "radioButtonSerialPort";
            this.radioButtonSerialPort.Size = new System.Drawing.Size(72, 17);
            this.radioButtonSerialPort.TabIndex = 25;
            this.radioButtonSerialPort.Text = "Serial port";
            this.radioButtonSerialPort.UseVisualStyleBackColor = true;
            this.radioButtonSerialPort.CheckedChanged += new System.EventHandler(this.radioButtonProviderChange);
            // 
            // buttonCiCreate
            // 
            this.buttonCiCreate.Location = new System.Drawing.Point(112, 176);
            this.buttonCiCreate.Name = "buttonCiCreate";
            this.buttonCiCreate.Size = new System.Drawing.Size(89, 46);
            this.buttonCiCreate.TabIndex = 13;
            this.buttonCiCreate.Text = "Create";
            this.buttonCiCreate.UseVisualStyleBackColor = true;
            this.buttonCiCreate.Click += new System.EventHandler(this.buttonCiCreate_Click);
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(13, 107);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(92, 13);
            this.labelConnectionString.TabIndex = 5;
            this.labelConnectionString.Text = "Connection string:";
            // 
            // buttonCiDestroy
            // 
            this.buttonCiDestroy.Location = new System.Drawing.Point(398, 176);
            this.buttonCiDestroy.Name = "buttonCiDestroy";
            this.buttonCiDestroy.Size = new System.Drawing.Size(89, 46);
            this.buttonCiDestroy.TabIndex = 10;
            this.buttonCiDestroy.Text = "Destroy";
            this.buttonCiDestroy.UseVisualStyleBackColor = true;
            this.buttonCiDestroy.Click += new System.EventHandler(this.buttonCiDestroy_Click);
            // 
            // labelDeviceString
            // 
            this.labelDeviceString.AutoSize = true;
            this.labelDeviceString.Location = new System.Drawing.Point(13, 144);
            this.labelDeviceString.Name = "labelDeviceString";
            this.labelDeviceString.Size = new System.Drawing.Size(72, 13);
            this.labelDeviceString.TabIndex = 6;
            this.labelDeviceString.Text = "Device string:";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(112, 104);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(374, 20);
            this.textBoxConnectionString.TabIndex = 7;
            this.textBoxConnectionString.Text = "provider=SERIAL_PORT;PortName=COM11;BaudRate=115200";
            // 
            // buttonCiConnect
            // 
            this.buttonCiConnect.Location = new System.Drawing.Point(207, 176);
            this.buttonCiConnect.Name = "buttonCiConnect";
            this.buttonCiConnect.Size = new System.Drawing.Size(89, 46);
            this.buttonCiConnect.TabIndex = 12;
            this.buttonCiConnect.Text = "Connect";
            this.buttonCiConnect.UseVisualStyleBackColor = true;
            this.buttonCiConnect.Click += new System.EventHandler(this.buttonCiConnect_Click);
            // 
            // textBoxDeviceString
            // 
            this.textBoxDeviceString.Location = new System.Drawing.Point(112, 144);
            this.textBoxDeviceString.Name = "textBoxDeviceString";
            this.textBoxDeviceString.Size = new System.Drawing.Size(374, 20);
            this.textBoxDeviceString.TabIndex = 8;
            this.textBoxDeviceString.Text = "adr=254";
            // 
            // buttonCiDisconnect
            // 
            this.buttonCiDisconnect.Location = new System.Drawing.Point(302, 176);
            this.buttonCiDisconnect.Name = "buttonCiDisconnect";
            this.buttonCiDisconnect.Size = new System.Drawing.Size(89, 46);
            this.buttonCiDisconnect.TabIndex = 11;
            this.buttonCiDisconnect.Text = "Disconnect";
            this.buttonCiDisconnect.UseVisualStyleBackColor = true;
            this.buttonCiDisconnect.Click += new System.EventHandler(this.buttonCiDisconnect_Click);
            // 
            // buttonQuidoCreate
            // 
            this.buttonQuidoCreate.Location = new System.Drawing.Point(112, 19);
            this.buttonQuidoCreate.Name = "buttonQuidoCreate";
            this.buttonQuidoCreate.Size = new System.Drawing.Size(89, 46);
            this.buttonQuidoCreate.TabIndex = 18;
            this.buttonQuidoCreate.Text = "Create QUIDO";
            this.buttonQuidoCreate.UseVisualStyleBackColor = true;
            this.buttonQuidoCreate.Click += new System.EventHandler(this.buttonQuidoCreate_Click);
            // 
            // groupBoxQuido
            // 
            this.groupBoxQuido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxQuido.Controls.Add(this.buttonGetSn);
            this.groupBoxQuido.Controls.Add(this.numericOutputTimer);
            this.groupBoxQuido.Controls.Add(this.labelOutputTimer);
            this.groupBoxQuido.Controls.Add(this.buttonGetOutputs);
            this.groupBoxQuido.Controls.Add(this.buttonGetTemp);
            this.groupBoxQuido.Controls.Add(this.buttonListenToggle);
            this.groupBoxQuido.Controls.Add(this.labelOutputIndex);
            this.groupBoxQuido.Controls.Add(this.numericOutputIndex);
            this.groupBoxQuido.Controls.Add(this.buttonSetAutonotifyOff);
            this.groupBoxQuido.Controls.Add(this.buttonSetAutonotifyOn);
            this.groupBoxQuido.Controls.Add(this.buttonGetAutonotify);
            this.groupBoxQuido.Controls.Add(this.buttonGetCounterSettings);
            this.groupBoxQuido.Controls.Add(this.buttonSetCounterSettings);
            this.groupBoxQuido.Controls.Add(this.buttonGetCounter);
            this.groupBoxQuido.Controls.Add(this.buttonGetInputs);
            this.groupBoxQuido.Controls.Add(this.buttonGetInfoCore);
            this.groupBoxQuido.Controls.Add(this.buttonSetOutputOff);
            this.groupBoxQuido.Controls.Add(this.buttonSetOutputOn);
            this.groupBoxQuido.Controls.Add(this.buttonGetInfo);
            this.groupBoxQuido.Controls.Add(this.buttonQuidoDestroy);
            this.groupBoxQuido.Controls.Add(this.buttonQuidoCreate);
            this.groupBoxQuido.Location = new System.Drawing.Point(12, 255);
            this.groupBoxQuido.Name = "groupBoxQuido";
            this.groupBoxQuido.Size = new System.Drawing.Size(504, 392);
            this.groupBoxQuido.TabIndex = 19;
            this.groupBoxQuido.TabStop = false;
            this.groupBoxQuido.Text = "Quido";
            // 
            // numericOutputTimer
            // 
            this.numericOutputTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericOutputTimer.Location = new System.Drawing.Point(446, 149);
            this.numericOutputTimer.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericOutputTimer.Name = "numericOutputTimer";
            this.numericOutputTimer.Size = new System.Drawing.Size(40, 20);
            this.numericOutputTimer.TabIndex = 40;
            // 
            // labelOutputTimer
            // 
            this.labelOutputTimer.AutoSize = true;
            this.labelOutputTimer.Location = new System.Drawing.Point(398, 151);
            this.labelOutputTimer.Name = "labelOutputTimer";
            this.labelOutputTimer.Size = new System.Drawing.Size(36, 13);
            this.labelOutputTimer.TabIndex = 39;
            this.labelOutputTimer.Text = "Timer:";
            // 
            // buttonGetOutputs
            // 
            this.buttonGetOutputs.Enabled = false;
            this.buttonGetOutputs.Location = new System.Drawing.Point(112, 123);
            this.buttonGetOutputs.Name = "buttonGetOutputs";
            this.buttonGetOutputs.Size = new System.Drawing.Size(89, 46);
            this.buttonGetOutputs.TabIndex = 38;
            this.buttonGetOutputs.Tag = "1";
            this.buttonGetOutputs.Text = "Get Outputs";
            this.buttonGetOutputs.UseVisualStyleBackColor = true;
            this.buttonGetOutputs.Click += new System.EventHandler(this.buttonGetOutputs_Click);
            // 
            // buttonGetTemp
            // 
            this.buttonGetTemp.Location = new System.Drawing.Point(112, 331);
            this.buttonGetTemp.Name = "buttonGetTemp";
            this.buttonGetTemp.Size = new System.Drawing.Size(89, 46);
            this.buttonGetTemp.TabIndex = 37;
            this.buttonGetTemp.Text = "Get Temp";
            this.buttonGetTemp.UseVisualStyleBackColor = true;
            this.buttonGetTemp.Click += new System.EventHandler(this.buttonGetTemp_Click);
            // 
            // buttonListenToggle
            // 
            this.buttonListenToggle.Location = new System.Drawing.Point(207, 19);
            this.buttonListenToggle.Name = "buttonListenToggle";
            this.buttonListenToggle.Size = new System.Drawing.Size(89, 46);
            this.buttonListenToggle.TabIndex = 36;
            this.buttonListenToggle.Text = "Background Listener ON";
            this.buttonListenToggle.UseVisualStyleBackColor = true;
            this.buttonListenToggle.Click += new System.EventHandler(this.buttonListenToggle_Click);
            // 
            // labelOutputIndex
            // 
            this.labelOutputIndex.AutoSize = true;
            this.labelOutputIndex.Location = new System.Drawing.Point(398, 126);
            this.labelOutputIndex.Name = "labelOutputIndex";
            this.labelOutputIndex.Size = new System.Drawing.Size(42, 13);
            this.labelOutputIndex.TabIndex = 35;
            this.labelOutputIndex.Text = "Output:";
            // 
            // numericOutputIndex
            // 
            this.numericOutputIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericOutputIndex.Location = new System.Drawing.Point(446, 124);
            this.numericOutputIndex.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericOutputIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericOutputIndex.Name = "numericOutputIndex";
            this.numericOutputIndex.Size = new System.Drawing.Size(40, 20);
            this.numericOutputIndex.TabIndex = 34;
            this.numericOutputIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonSetAutonotifyOff
            // 
            this.buttonSetAutonotifyOff.Location = new System.Drawing.Point(302, 279);
            this.buttonSetAutonotifyOff.Name = "buttonSetAutonotifyOff";
            this.buttonSetAutonotifyOff.Size = new System.Drawing.Size(89, 46);
            this.buttonSetAutonotifyOff.TabIndex = 32;
            this.buttonSetAutonotifyOff.Text = "Set Autonotify OFF";
            this.buttonSetAutonotifyOff.UseVisualStyleBackColor = true;
            this.buttonSetAutonotifyOff.Click += new System.EventHandler(this.buttonSetAutonotifyOff_Click);
            // 
            // buttonSetAutonotifyOn
            // 
            this.buttonSetAutonotifyOn.Location = new System.Drawing.Point(207, 279);
            this.buttonSetAutonotifyOn.Name = "buttonSetAutonotifyOn";
            this.buttonSetAutonotifyOn.Size = new System.Drawing.Size(89, 46);
            this.buttonSetAutonotifyOn.TabIndex = 31;
            this.buttonSetAutonotifyOn.Text = "Set Autonotify ON";
            this.buttonSetAutonotifyOn.UseVisualStyleBackColor = true;
            this.buttonSetAutonotifyOn.Click += new System.EventHandler(this.buttonSetAutonotifyOn_Click);
            // 
            // buttonGetAutonotify
            // 
            this.buttonGetAutonotify.Location = new System.Drawing.Point(112, 279);
            this.buttonGetAutonotify.Name = "buttonGetAutonotify";
            this.buttonGetAutonotify.Size = new System.Drawing.Size(89, 46);
            this.buttonGetAutonotify.TabIndex = 30;
            this.buttonGetAutonotify.Text = "Get Autonotify";
            this.buttonGetAutonotify.UseVisualStyleBackColor = true;
            this.buttonGetAutonotify.Click += new System.EventHandler(this.buttonGetAutonotify_Click);
            // 
            // buttonGetCounterSettings
            // 
            this.buttonGetCounterSettings.Location = new System.Drawing.Point(207, 227);
            this.buttonGetCounterSettings.Name = "buttonGetCounterSettings";
            this.buttonGetCounterSettings.Size = new System.Drawing.Size(89, 46);
            this.buttonGetCounterSettings.TabIndex = 29;
            this.buttonGetCounterSettings.Text = "Get Counter Settings";
            this.buttonGetCounterSettings.UseVisualStyleBackColor = true;
            this.buttonGetCounterSettings.Click += new System.EventHandler(this.buttonGetCounterSettings_Click);
            // 
            // buttonSetCounterSettings
            // 
            this.buttonSetCounterSettings.Location = new System.Drawing.Point(302, 227);
            this.buttonSetCounterSettings.Name = "buttonSetCounterSettings";
            this.buttonSetCounterSettings.Size = new System.Drawing.Size(89, 46);
            this.buttonSetCounterSettings.TabIndex = 28;
            this.buttonSetCounterSettings.Text = "Set Counter Settings";
            this.buttonSetCounterSettings.UseVisualStyleBackColor = true;
            this.buttonSetCounterSettings.Click += new System.EventHandler(this.buttonSetCounterSettings_Click);
            // 
            // buttonGetCounter
            // 
            this.buttonGetCounter.Location = new System.Drawing.Point(112, 227);
            this.buttonGetCounter.Name = "buttonGetCounter";
            this.buttonGetCounter.Size = new System.Drawing.Size(89, 46);
            this.buttonGetCounter.TabIndex = 24;
            this.buttonGetCounter.Text = "Get Counter";
            this.buttonGetCounter.UseVisualStyleBackColor = true;
            this.buttonGetCounter.Click += new System.EventHandler(this.buttonGetCounter_Click);
            // 
            // buttonGetInputs
            // 
            this.buttonGetInputs.Location = new System.Drawing.Point(112, 175);
            this.buttonGetInputs.Name = "buttonGetInputs";
            this.buttonGetInputs.Size = new System.Drawing.Size(89, 46);
            this.buttonGetInputs.TabIndex = 23;
            this.buttonGetInputs.Text = "Get Inputs";
            this.buttonGetInputs.UseVisualStyleBackColor = true;
            this.buttonGetInputs.Click += new System.EventHandler(this.buttonGetInputs_Click);
            // 
            // buttonGetInfoCore
            // 
            this.buttonGetInfoCore.Location = new System.Drawing.Point(207, 71);
            this.buttonGetInfoCore.Name = "buttonGetInfoCore";
            this.buttonGetInfoCore.Size = new System.Drawing.Size(89, 46);
            this.buttonGetInfoCore.TabIndex = 22;
            this.buttonGetInfoCore.Text = "Get INFO 2";
            this.buttonGetInfoCore.UseVisualStyleBackColor = true;
            this.buttonGetInfoCore.Click += new System.EventHandler(this.buttonGetInfoCore_Click);
            // 
            // buttonSetOutputOff
            // 
            this.buttonSetOutputOff.Location = new System.Drawing.Point(302, 123);
            this.buttonSetOutputOff.Name = "buttonSetOutputOff";
            this.buttonSetOutputOff.Size = new System.Drawing.Size(89, 46);
            this.buttonSetOutputOff.TabIndex = 21;
            this.buttonSetOutputOff.Text = "Reset Output";
            this.buttonSetOutputOff.UseVisualStyleBackColor = true;
            this.buttonSetOutputOff.Click += new System.EventHandler(this.buttonSetRele1Off_Click);
            // 
            // buttonSetOutputOn
            // 
            this.buttonSetOutputOn.Location = new System.Drawing.Point(207, 123);
            this.buttonSetOutputOn.Name = "buttonSetOutputOn";
            this.buttonSetOutputOn.Size = new System.Drawing.Size(89, 46);
            this.buttonSetOutputOn.TabIndex = 20;
            this.buttonSetOutputOn.Text = "Set Output";
            this.buttonSetOutputOn.UseVisualStyleBackColor = true;
            this.buttonSetOutputOn.Click += new System.EventHandler(this.buttonSetRele1On_Click);
            // 
            // buttonGetInfo
            // 
            this.buttonGetInfo.Location = new System.Drawing.Point(112, 71);
            this.buttonGetInfo.Name = "buttonGetInfo";
            this.buttonGetInfo.Size = new System.Drawing.Size(89, 46);
            this.buttonGetInfo.TabIndex = 0;
            this.buttonGetInfo.Text = "Get INFO 1";
            this.buttonGetInfo.UseVisualStyleBackColor = true;
            this.buttonGetInfo.Click += new System.EventHandler(this.buttonGetInfo_Click);
            // 
            // buttonQuidoDestroy
            // 
            this.buttonQuidoDestroy.Location = new System.Drawing.Point(302, 19);
            this.buttonQuidoDestroy.Name = "buttonQuidoDestroy";
            this.buttonQuidoDestroy.Size = new System.Drawing.Size(89, 46);
            this.buttonQuidoDestroy.TabIndex = 19;
            this.buttonQuidoDestroy.Text = "Destory QUIDO";
            this.buttonQuidoDestroy.UseVisualStyleBackColor = true;
            this.buttonQuidoDestroy.Click += new System.EventHandler(this.buttonQuidoDestroy_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(528, 18);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(390, 629);
            this.richTextBox1.TabIndex = 20;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // buttonGetSn
            // 
            this.buttonGetSn.Location = new System.Drawing.Point(301, 71);
            this.buttonGetSn.Name = "buttonGetSn";
            this.buttonGetSn.Size = new System.Drawing.Size(89, 46);
            this.buttonGetSn.TabIndex = 41;
            this.buttonGetSn.Text = "Get Serial Number";
            this.buttonGetSn.UseVisualStyleBackColor = true;
            this.buttonGetSn.Click += new System.EventHandler(this.buttonGetSn_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 659);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBoxQuido);
            this.Controls.Add(this.groupBoxCommunicationInterface);
            this.Name = "FormMain";
            this.Text = "Quido demo - .NET native";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBoxCommunicationInterface.ResumeLayout(false);
            this.groupBoxCommunicationInterface.PerformLayout();
            this.groupBoxQuido.ResumeLayout(false);
            this.groupBoxQuido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOutputTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOutputIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCommunicationInterface;
        private System.Windows.Forms.Button buttonCiCreate;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.Label labelDeviceString;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.Button buttonCiConnect;
        private System.Windows.Forms.TextBox textBoxDeviceString;
        private System.Windows.Forms.Button buttonCiDisconnect;
        private System.Windows.Forms.Button buttonCiDestroy;
        private System.Windows.Forms.Button buttonQuidoCreate;
        private System.Windows.Forms.GroupBox groupBoxQuido;
        private System.Windows.Forms.Button buttonGetInfo;
        private System.Windows.Forms.Button buttonQuidoDestroy;
        private System.Windows.Forms.Button buttonSetOutputOff;
        private System.Windows.Forms.Button buttonSetOutputOn;
        private System.Windows.Forms.Button buttonGetInfoCore;
        private System.Windows.Forms.Button buttonGetInputs;
        private System.Windows.Forms.Button buttonGetCounter;
        private System.Windows.Forms.Button buttonSetCounterSettings;
        private System.Windows.Forms.Button buttonGetCounterSettings;
        private System.Windows.Forms.Button buttonSetAutonotifyOff;
        private System.Windows.Forms.Button buttonSetAutonotifyOn;
        private System.Windows.Forms.Button buttonGetAutonotify;
        private System.Windows.Forms.NumericUpDown numericOutputIndex;
        private System.Windows.Forms.Label labelOutputIndex;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonListenToggle;
        private System.Windows.Forms.Button buttonGetTemp;
        private System.Windows.Forms.Button buttonGetOutputs;
        private System.Windows.Forms.NumericUpDown numericOutputTimer;
        private System.Windows.Forms.Label labelOutputTimer;
        private System.Windows.Forms.TextBox textBoxTcpPort;
        private System.Windows.Forms.TextBox textBoxTcpHost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRefreshSerialPorts;
        private System.Windows.Forms.ComboBox comboBoxSerialPortBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSerialPortName;
        private System.Windows.Forms.RadioButton radioButtonTcpClient;
        private System.Windows.Forms.RadioButton radioButtonSerialPort;
        private System.Windows.Forms.Button buttonGetSn;
    }
}

