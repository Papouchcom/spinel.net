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
            this.groupBoxCommunicationInterface.SuspendLayout();
            this.groupBoxQuido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOutputIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCommunicationInterface
            // 
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
            this.groupBoxCommunicationInterface.Size = new System.Drawing.Size(504, 142);
            this.groupBoxCommunicationInterface.TabIndex = 17;
            this.groupBoxCommunicationInterface.TabStop = false;
            this.groupBoxCommunicationInterface.Text = "Communication Interface - Initialization / Deinitialization ";
            // 
            // buttonCiCreate
            // 
            this.buttonCiCreate.Location = new System.Drawing.Point(112, 83);
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
            this.labelConnectionString.Location = new System.Drawing.Point(14, 25);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(92, 13);
            this.labelConnectionString.TabIndex = 5;
            this.labelConnectionString.Text = "Connection string:";
            // 
            // buttonCiDestroy
            // 
            this.buttonCiDestroy.Location = new System.Drawing.Point(397, 83);
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
            this.labelDeviceString.Location = new System.Drawing.Point(14, 51);
            this.labelDeviceString.Name = "labelDeviceString";
            this.labelDeviceString.Size = new System.Drawing.Size(72, 13);
            this.labelDeviceString.TabIndex = 6;
            this.labelDeviceString.Text = "Device string:";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(112, 22);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(374, 20);
            this.textBoxConnectionString.TabIndex = 7;
            this.textBoxConnectionString.Text = "provider=SERIAL_PORT;PortName=COM11;BaudRate=115200";
            // 
            // buttonCiConnect
            // 
            this.buttonCiConnect.Location = new System.Drawing.Point(207, 83);
            this.buttonCiConnect.Name = "buttonCiConnect";
            this.buttonCiConnect.Size = new System.Drawing.Size(89, 46);
            this.buttonCiConnect.TabIndex = 12;
            this.buttonCiConnect.Text = "Connect";
            this.buttonCiConnect.UseVisualStyleBackColor = true;
            this.buttonCiConnect.Click += new System.EventHandler(this.buttonCiConnect_Click);
            // 
            // textBoxDeviceString
            // 
            this.textBoxDeviceString.Location = new System.Drawing.Point(112, 51);
            this.textBoxDeviceString.Name = "textBoxDeviceString";
            this.textBoxDeviceString.Size = new System.Drawing.Size(374, 20);
            this.textBoxDeviceString.TabIndex = 8;
            this.textBoxDeviceString.Text = "adr=254";
            // 
            // buttonCiDisconnect
            // 
            this.buttonCiDisconnect.Location = new System.Drawing.Point(302, 83);
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
            this.groupBoxQuido.Location = new System.Drawing.Point(12, 160);
            this.groupBoxQuido.Name = "groupBoxQuido";
            this.groupBoxQuido.Size = new System.Drawing.Size(504, 387);
            this.groupBoxQuido.TabIndex = 19;
            this.groupBoxQuido.TabStop = false;
            this.groupBoxQuido.Text = "Quido";
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
            this.labelOutputIndex.Location = new System.Drawing.Point(303, 131);
            this.labelOutputIndex.Name = "labelOutputIndex";
            this.labelOutputIndex.Size = new System.Drawing.Size(42, 13);
            this.labelOutputIndex.TabIndex = 35;
            this.labelOutputIndex.Text = "Output:";
            // 
            // numericOutputIndex
            // 
            this.numericOutputIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numericOutputIndex.Location = new System.Drawing.Point(302, 149);
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
            this.numericOutputIndex.Size = new System.Drawing.Size(89, 20);
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
            this.buttonSetOutputOff.Location = new System.Drawing.Point(207, 123);
            this.buttonSetOutputOff.Name = "buttonSetOutputOff";
            this.buttonSetOutputOff.Size = new System.Drawing.Size(89, 46);
            this.buttonSetOutputOff.TabIndex = 21;
            this.buttonSetOutputOff.Text = "Reset Output";
            this.buttonSetOutputOff.UseVisualStyleBackColor = true;
            this.buttonSetOutputOff.Click += new System.EventHandler(this.buttonSetRele1Off_Click);
            // 
            // buttonSetOutputOn
            // 
            this.buttonSetOutputOn.Location = new System.Drawing.Point(112, 123);
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
            this.richTextBox1.Size = new System.Drawing.Size(390, 529);
            this.richTextBox1.TabIndex = 20;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 559);
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
    }
}

