namespace WindowsFormsApplication1
{
    partial class FormCommIntDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCommIntDemo));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
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
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.buttonCiConnect = new System.Windows.Forms.Button();
            this.buttonCiDisconnect = new System.Windows.Forms.Button();
            this.buttonSendBin = new System.Windows.Forms.Button();
            this.buttonSendText = new System.Windows.Forms.Button();
            this.buttonReadText = new System.Windows.Forms.Button();
            this.buttonReadBin = new System.Windows.Forms.Button();
            this.groupBoxCommunicationInterface.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(522, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(382, 529);
            this.richTextBox1.TabIndex = 22;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
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
            this.groupBoxCommunicationInterface.Controls.Add(this.textBoxConnectionString);
            this.groupBoxCommunicationInterface.Controls.Add(this.buttonCiConnect);
            this.groupBoxCommunicationInterface.Controls.Add(this.buttonCiDisconnect);
            this.groupBoxCommunicationInterface.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCommunicationInterface.Name = "groupBoxCommunicationInterface";
            this.groupBoxCommunicationInterface.Size = new System.Drawing.Size(504, 208);
            this.groupBoxCommunicationInterface.TabIndex = 21;
            this.groupBoxCommunicationInterface.TabStop = false;
            this.groupBoxCommunicationInterface.Text = "Communication Interface - Initialization / Deinitialization ";
            // 
            // textBoxTcpPort
            // 
            this.textBoxTcpPort.Location = new System.Drawing.Point(111, 83);
            this.textBoxTcpPort.Name = "textBoxTcpPort";
            this.textBoxTcpPort.Size = new System.Drawing.Size(89, 20);
            this.textBoxTcpPort.TabIndex = 24;
            this.textBoxTcpPort.Text = "10001";
            this.textBoxTcpPort.TextChanged += new System.EventHandler(this.providerSettingsChange);
            // 
            // textBoxTcpHost
            // 
            this.textBoxTcpHost.Location = new System.Drawing.Point(112, 57);
            this.textBoxTcpHost.Name = "textBoxTcpHost";
            this.textBoxTcpHost.Size = new System.Drawing.Size(88, 20);
            this.textBoxTcpHost.TabIndex = 23;
            this.textBoxTcpHost.Text = "192.168.1.254";
            this.textBoxTcpHost.TextChanged += new System.EventHandler(this.providerSettingsChange);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "IP address:";
            // 
            // buttonRefreshSerialPorts
            // 
            this.buttonRefreshSerialPorts.Location = new System.Drawing.Point(396, 54);
            this.buttonRefreshSerialPorts.Name = "buttonRefreshSerialPorts";
            this.buttonRefreshSerialPorts.Size = new System.Drawing.Size(89, 23);
            this.buttonRefreshSerialPorts.TabIndex = 20;
            this.buttonRefreshSerialPorts.Text = "refresh ports";
            this.buttonRefreshSerialPorts.UseVisualStyleBackColor = true;
            this.buttonRefreshSerialPorts.Click += new System.EventHandler(this.reloadSerialPortNames);
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
            this.comboBoxSerialPortBaudRate.Location = new System.Drawing.Point(302, 81);
            this.comboBoxSerialPortBaudRate.Name = "comboBoxSerialPortBaudRate";
            this.comboBoxSerialPortBaudRate.Size = new System.Drawing.Size(88, 21);
            this.comboBoxSerialPortBaudRate.TabIndex = 19;
            this.comboBoxSerialPortBaudRate.Text = "9600";
            this.comboBoxSerialPortBaudRate.SelectedIndexChanged += new System.EventHandler(this.providerSettingsChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Speed:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Port name:";
            // 
            // comboBoxSerialPortName
            // 
            this.comboBoxSerialPortName.FormattingEnabled = true;
            this.comboBoxSerialPortName.Location = new System.Drawing.Point(302, 54);
            this.comboBoxSerialPortName.Name = "comboBoxSerialPortName";
            this.comboBoxSerialPortName.Size = new System.Drawing.Size(88, 21);
            this.comboBoxSerialPortName.TabIndex = 16;
            this.comboBoxSerialPortName.Text = "COM1";
            this.comboBoxSerialPortName.SelectedValueChanged += new System.EventHandler(this.providerSettingsChange);
            // 
            // radioButtonTcpClient
            // 
            this.radioButtonTcpClient.AutoSize = true;
            this.radioButtonTcpClient.Checked = true;
            this.radioButtonTcpClient.Location = new System.Drawing.Point(18, 34);
            this.radioButtonTcpClient.Name = "radioButtonTcpClient";
            this.radioButtonTcpClient.Size = new System.Drawing.Size(115, 17);
            this.radioButtonTcpClient.TabIndex = 15;
            this.radioButtonTcpClient.TabStop = true;
            this.radioButtonTcpClient.Text = "TCP socket (client)";
            this.radioButtonTcpClient.UseVisualStyleBackColor = true;
            this.radioButtonTcpClient.CheckedChanged += new System.EventHandler(this.radioButtonProviderChange);
            // 
            // radioButtonSerialPort
            // 
            this.radioButtonSerialPort.AutoSize = true;
            this.radioButtonSerialPort.Location = new System.Drawing.Point(207, 34);
            this.radioButtonSerialPort.Name = "radioButtonSerialPort";
            this.radioButtonSerialPort.Size = new System.Drawing.Size(72, 17);
            this.radioButtonSerialPort.TabIndex = 14;
            this.radioButtonSerialPort.Text = "Serial port";
            this.radioButtonSerialPort.UseVisualStyleBackColor = true;
            this.radioButtonSerialPort.CheckedChanged += new System.EventHandler(this.radioButtonProviderChange);
            // 
            // buttonCiCreate
            // 
            this.buttonCiCreate.Location = new System.Drawing.Point(111, 147);
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
            this.labelConnectionString.Location = new System.Drawing.Point(13, 124);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(92, 13);
            this.labelConnectionString.TabIndex = 5;
            this.labelConnectionString.Text = "Connection string:";
            // 
            // buttonCiDestroy
            // 
            this.buttonCiDestroy.Location = new System.Drawing.Point(396, 147);
            this.buttonCiDestroy.Name = "buttonCiDestroy";
            this.buttonCiDestroy.Size = new System.Drawing.Size(89, 46);
            this.buttonCiDestroy.TabIndex = 10;
            this.buttonCiDestroy.Text = "Destroy";
            this.buttonCiDestroy.UseVisualStyleBackColor = true;
            this.buttonCiDestroy.Click += new System.EventHandler(this.buttonCiDestroy_Click);
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(111, 121);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(374, 20);
            this.textBoxConnectionString.TabIndex = 7;
            this.textBoxConnectionString.Text = "provider=SERIAL_PORT;PortName=COM7;BaudRate=9600";
            // 
            // buttonCiConnect
            // 
            this.buttonCiConnect.Location = new System.Drawing.Point(206, 147);
            this.buttonCiConnect.Name = "buttonCiConnect";
            this.buttonCiConnect.Size = new System.Drawing.Size(89, 46);
            this.buttonCiConnect.TabIndex = 12;
            this.buttonCiConnect.Text = "Connect";
            this.buttonCiConnect.UseVisualStyleBackColor = true;
            this.buttonCiConnect.Click += new System.EventHandler(this.buttonCiConnect_Click);
            // 
            // buttonCiDisconnect
            // 
            this.buttonCiDisconnect.Location = new System.Drawing.Point(301, 147);
            this.buttonCiDisconnect.Name = "buttonCiDisconnect";
            this.buttonCiDisconnect.Size = new System.Drawing.Size(89, 46);
            this.buttonCiDisconnect.TabIndex = 11;
            this.buttonCiDisconnect.Text = "Disconnect";
            this.buttonCiDisconnect.UseVisualStyleBackColor = true;
            this.buttonCiDisconnect.Click += new System.EventHandler(this.buttonCiDisconnect_Click);
            // 
            // buttonSendBin
            // 
            this.buttonSendBin.Location = new System.Drawing.Point(124, 236);
            this.buttonSendBin.Name = "buttonSendBin";
            this.buttonSendBin.Size = new System.Drawing.Size(184, 46);
            this.buttonSendBin.TabIndex = 23;
            this.buttonSendBin.Text = "Send binnary data";
            this.buttonSendBin.UseVisualStyleBackColor = true;
            this.buttonSendBin.Click += new System.EventHandler(this.buttonSendBin_Click);
            // 
            // buttonSendText
            // 
            this.buttonSendText.Location = new System.Drawing.Point(124, 288);
            this.buttonSendText.Name = "buttonSendText";
            this.buttonSendText.Size = new System.Drawing.Size(184, 45);
            this.buttonSendText.TabIndex = 24;
            this.buttonSendText.Text = "Send text data";
            this.buttonSendText.UseVisualStyleBackColor = true;
            this.buttonSendText.Click += new System.EventHandler(this.buttonSendText_Click);
            // 
            // buttonReadText
            // 
            this.buttonReadText.Location = new System.Drawing.Point(314, 288);
            this.buttonReadText.Name = "buttonReadText";
            this.buttonReadText.Size = new System.Drawing.Size(184, 45);
            this.buttonReadText.TabIndex = 25;
            this.buttonReadText.Text = "Read text data";
            this.buttonReadText.UseVisualStyleBackColor = true;
            this.buttonReadText.Click += new System.EventHandler(this.buttonReadText_Click);
            // 
            // buttonReadBin
            // 
            this.buttonReadBin.Location = new System.Drawing.Point(314, 237);
            this.buttonReadBin.Name = "buttonReadBin";
            this.buttonReadBin.Size = new System.Drawing.Size(184, 45);
            this.buttonReadBin.TabIndex = 26;
            this.buttonReadBin.Text = "Read binnary data";
            this.buttonReadBin.UseVisualStyleBackColor = true;
            this.buttonReadBin.Click += new System.EventHandler(this.buttonReadBin_Click);
            // 
            // FormCommIntDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 549);
            this.Controls.Add(this.buttonReadBin);
            this.Controls.Add(this.buttonReadText);
            this.Controls.Add(this.buttonSendText);
            this.Controls.Add(this.buttonSendBin);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBoxCommunicationInterface);
            this.Name = "FormCommIntDemo";
            this.Text = "Papouch.CI .NET (Communication Interface) - Demo Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxCommunicationInterface.ResumeLayout(false);
            this.groupBoxCommunicationInterface.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBoxCommunicationInterface;
        private System.Windows.Forms.Button buttonCiCreate;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.Button buttonCiDestroy;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.Button buttonCiConnect;
        private System.Windows.Forms.Button buttonCiDisconnect;
        private System.Windows.Forms.Button buttonSendBin;
        private System.Windows.Forms.Button buttonSendText;
        private System.Windows.Forms.Button buttonReadText;
        private System.Windows.Forms.Button buttonReadBin;
        private System.Windows.Forms.Button buttonRefreshSerialPorts;
        private System.Windows.Forms.ComboBox comboBoxSerialPortBaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSerialPortName;
        private System.Windows.Forms.RadioButton radioButtonTcpClient;
        private System.Windows.Forms.RadioButton radioButtonSerialPort;
        private System.Windows.Forms.TextBox textBoxTcpPort;
        private System.Windows.Forms.TextBox textBoxTcpHost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

