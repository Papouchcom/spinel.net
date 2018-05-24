<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Formulář přepisuje metodu Dispose, aby vyčistil seznam součástí.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Vyžadováno Návrhářem Windows Form
    Private components As System.ComponentModel.IContainer

    'POZNÁMKA: Následující procedura je vyžadována Návrhářem Windows Form
    'Může být upraveno pomocí Návrháře Windows Form.  
    'Neupravovat pomocí editoru kódu
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.numericOutputTimer = New System.Windows.Forms.NumericUpDown()
        Me.labelOutputTimer = New System.Windows.Forms.Label()
        Me.buttonGetOutputs = New System.Windows.Forms.Button()
        Me.buttonGetTemp = New System.Windows.Forms.Button()
        Me.buttonListenToggle = New System.Windows.Forms.Button()
        Me.labelOutputIndex = New System.Windows.Forms.Label()
        Me.numericOutputIndex = New System.Windows.Forms.NumericUpDown()
        Me.buttonSetAutonotifyOff = New System.Windows.Forms.Button()
        Me.buttonSetAutonotifyOn = New System.Windows.Forms.Button()
        Me.buttonGetAutonotify = New System.Windows.Forms.Button()
        Me.buttonGetCounterSettings = New System.Windows.Forms.Button()
        Me.buttonSetCounterSettings = New System.Windows.Forms.Button()
        Me.buttonGetCounter = New System.Windows.Forms.Button()
        Me.buttonGetInputs = New System.Windows.Forms.Button()
        Me.buttonGetInfoCore = New System.Windows.Forms.Button()
        Me.buttonSetOutputOff = New System.Windows.Forms.Button()
        Me.buttonSetOutputOn = New System.Windows.Forms.Button()
        Me.buttonGetInfo = New System.Windows.Forms.Button()
        Me.buttonQuidoDestroy = New System.Windows.Forms.Button()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.groupBoxQuido = New System.Windows.Forms.GroupBox()
        Me.buttonQuidoCreate = New System.Windows.Forms.Button()
        Me.groupBoxCommunicationInterface = New System.Windows.Forms.GroupBox()
        Me.textBoxTcpPort = New System.Windows.Forms.TextBox()
        Me.textBoxTcpHost = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.buttonRefreshSerialPorts = New System.Windows.Forms.Button()
        Me.comboBoxSerialPortBaudRate = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.comboBoxSerialPortName = New System.Windows.Forms.ComboBox()
        Me.radioButtonTcpClient = New System.Windows.Forms.RadioButton()
        Me.radioButtonSerialPort = New System.Windows.Forms.RadioButton()
        Me.buttonCiCreate = New System.Windows.Forms.Button()
        Me.labelConnectionString = New System.Windows.Forms.Label()
        Me.buttonCiDestroy = New System.Windows.Forms.Button()
        Me.labelDeviceString = New System.Windows.Forms.Label()
        Me.textBoxConnectionString = New System.Windows.Forms.TextBox()
        Me.buttonCiConnect = New System.Windows.Forms.Button()
        Me.textBoxDeviceString = New System.Windows.Forms.TextBox()
        Me.buttonCiDisconnect = New System.Windows.Forms.Button()
        CType(Me.numericOutputTimer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericOutputIndex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBoxQuido.SuspendLayout()
        Me.groupBoxCommunicationInterface.SuspendLayout()
        Me.SuspendLayout()
        '
        'numericOutputTimer
        '
        Me.numericOutputTimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.numericOutputTimer.Location = New System.Drawing.Point(446, 149)
        Me.numericOutputTimer.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numericOutputTimer.Name = "numericOutputTimer"
        Me.numericOutputTimer.Size = New System.Drawing.Size(40, 20)
        Me.numericOutputTimer.TabIndex = 40
        '
        'labelOutputTimer
        '
        Me.labelOutputTimer.AutoSize = True
        Me.labelOutputTimer.Location = New System.Drawing.Point(398, 151)
        Me.labelOutputTimer.Name = "labelOutputTimer"
        Me.labelOutputTimer.Size = New System.Drawing.Size(36, 13)
        Me.labelOutputTimer.TabIndex = 39
        Me.labelOutputTimer.Text = "Timer:"
        '
        'buttonGetOutputs
        '
        Me.buttonGetOutputs.Enabled = False
        Me.buttonGetOutputs.Location = New System.Drawing.Point(112, 123)
        Me.buttonGetOutputs.Name = "buttonGetOutputs"
        Me.buttonGetOutputs.Size = New System.Drawing.Size(89, 46)
        Me.buttonGetOutputs.TabIndex = 38
        Me.buttonGetOutputs.Tag = "1"
        Me.buttonGetOutputs.Text = "Get Outputs"
        Me.buttonGetOutputs.UseVisualStyleBackColor = True
        '
        'buttonGetTemp
        '
        Me.buttonGetTemp.Location = New System.Drawing.Point(112, 331)
        Me.buttonGetTemp.Name = "buttonGetTemp"
        Me.buttonGetTemp.Size = New System.Drawing.Size(89, 46)
        Me.buttonGetTemp.TabIndex = 37
        Me.buttonGetTemp.Text = "Get Temp"
        Me.buttonGetTemp.UseVisualStyleBackColor = True
        '
        'buttonListenToggle
        '
        Me.buttonListenToggle.Location = New System.Drawing.Point(207, 19)
        Me.buttonListenToggle.Name = "buttonListenToggle"
        Me.buttonListenToggle.Size = New System.Drawing.Size(89, 46)
        Me.buttonListenToggle.TabIndex = 36
        Me.buttonListenToggle.Text = "Background Listener ON"
        Me.buttonListenToggle.UseVisualStyleBackColor = True
        '
        'labelOutputIndex
        '
        Me.labelOutputIndex.AutoSize = True
        Me.labelOutputIndex.Location = New System.Drawing.Point(398, 126)
        Me.labelOutputIndex.Name = "labelOutputIndex"
        Me.labelOutputIndex.Size = New System.Drawing.Size(42, 13)
        Me.labelOutputIndex.TabIndex = 35
        Me.labelOutputIndex.Text = "Output:"
        '
        'numericOutputIndex
        '
        Me.numericOutputIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.numericOutputIndex.Location = New System.Drawing.Point(446, 124)
        Me.numericOutputIndex.Maximum = New Decimal(New Integer() {128, 0, 0, 0})
        Me.numericOutputIndex.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numericOutputIndex.Name = "numericOutputIndex"
        Me.numericOutputIndex.Size = New System.Drawing.Size(40, 20)
        Me.numericOutputIndex.TabIndex = 34
        Me.numericOutputIndex.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'buttonSetAutonotifyOff
        '
        Me.buttonSetAutonotifyOff.Location = New System.Drawing.Point(302, 279)
        Me.buttonSetAutonotifyOff.Name = "buttonSetAutonotifyOff"
        Me.buttonSetAutonotifyOff.Size = New System.Drawing.Size(89, 46)
        Me.buttonSetAutonotifyOff.TabIndex = 32
        Me.buttonSetAutonotifyOff.Text = "Set Autonotify OFF"
        Me.buttonSetAutonotifyOff.UseVisualStyleBackColor = True
        '
        'buttonSetAutonotifyOn
        '
        Me.buttonSetAutonotifyOn.Location = New System.Drawing.Point(207, 279)
        Me.buttonSetAutonotifyOn.Name = "buttonSetAutonotifyOn"
        Me.buttonSetAutonotifyOn.Size = New System.Drawing.Size(89, 46)
        Me.buttonSetAutonotifyOn.TabIndex = 31
        Me.buttonSetAutonotifyOn.Text = "Set Autonotify ON"
        Me.buttonSetAutonotifyOn.UseVisualStyleBackColor = True
        '
        'buttonGetAutonotify
        '
        Me.buttonGetAutonotify.Location = New System.Drawing.Point(112, 279)
        Me.buttonGetAutonotify.Name = "buttonGetAutonotify"
        Me.buttonGetAutonotify.Size = New System.Drawing.Size(89, 46)
        Me.buttonGetAutonotify.TabIndex = 30
        Me.buttonGetAutonotify.Text = "Get Autonotify"
        Me.buttonGetAutonotify.UseVisualStyleBackColor = True
        '
        'buttonGetCounterSettings
        '
        Me.buttonGetCounterSettings.Location = New System.Drawing.Point(207, 227)
        Me.buttonGetCounterSettings.Name = "buttonGetCounterSettings"
        Me.buttonGetCounterSettings.Size = New System.Drawing.Size(89, 46)
        Me.buttonGetCounterSettings.TabIndex = 29
        Me.buttonGetCounterSettings.Text = "Get Counter Settings"
        Me.buttonGetCounterSettings.UseVisualStyleBackColor = True
        '
        'buttonSetCounterSettings
        '
        Me.buttonSetCounterSettings.Location = New System.Drawing.Point(302, 227)
        Me.buttonSetCounterSettings.Name = "buttonSetCounterSettings"
        Me.buttonSetCounterSettings.Size = New System.Drawing.Size(89, 46)
        Me.buttonSetCounterSettings.TabIndex = 28
        Me.buttonSetCounterSettings.Text = "Set Counter Settings"
        Me.buttonSetCounterSettings.UseVisualStyleBackColor = True
        '
        'buttonGetCounter
        '
        Me.buttonGetCounter.Location = New System.Drawing.Point(112, 227)
        Me.buttonGetCounter.Name = "buttonGetCounter"
        Me.buttonGetCounter.Size = New System.Drawing.Size(89, 46)
        Me.buttonGetCounter.TabIndex = 24
        Me.buttonGetCounter.Text = "Get Counter"
        Me.buttonGetCounter.UseVisualStyleBackColor = True
        '
        'buttonGetInputs
        '
        Me.buttonGetInputs.Location = New System.Drawing.Point(112, 175)
        Me.buttonGetInputs.Name = "buttonGetInputs"
        Me.buttonGetInputs.Size = New System.Drawing.Size(89, 46)
        Me.buttonGetInputs.TabIndex = 23
        Me.buttonGetInputs.Text = "Get Inputs"
        Me.buttonGetInputs.UseVisualStyleBackColor = True
        '
        'buttonGetInfoCore
        '
        Me.buttonGetInfoCore.Location = New System.Drawing.Point(207, 71)
        Me.buttonGetInfoCore.Name = "buttonGetInfoCore"
        Me.buttonGetInfoCore.Size = New System.Drawing.Size(89, 46)
        Me.buttonGetInfoCore.TabIndex = 22
        Me.buttonGetInfoCore.Text = "Get INFO 2"
        Me.buttonGetInfoCore.UseVisualStyleBackColor = True
        '
        'buttonSetOutputOff
        '
        Me.buttonSetOutputOff.Location = New System.Drawing.Point(302, 123)
        Me.buttonSetOutputOff.Name = "buttonSetOutputOff"
        Me.buttonSetOutputOff.Size = New System.Drawing.Size(89, 46)
        Me.buttonSetOutputOff.TabIndex = 21
        Me.buttonSetOutputOff.Text = "Reset Output"
        Me.buttonSetOutputOff.UseVisualStyleBackColor = True
        '
        'buttonSetOutputOn
        '
        Me.buttonSetOutputOn.Location = New System.Drawing.Point(207, 123)
        Me.buttonSetOutputOn.Name = "buttonSetOutputOn"
        Me.buttonSetOutputOn.Size = New System.Drawing.Size(89, 46)
        Me.buttonSetOutputOn.TabIndex = 20
        Me.buttonSetOutputOn.Text = "Set Output"
        Me.buttonSetOutputOn.UseVisualStyleBackColor = True
        '
        'buttonGetInfo
        '
        Me.buttonGetInfo.Location = New System.Drawing.Point(112, 71)
        Me.buttonGetInfo.Name = "buttonGetInfo"
        Me.buttonGetInfo.Size = New System.Drawing.Size(89, 46)
        Me.buttonGetInfo.TabIndex = 0
        Me.buttonGetInfo.Text = "Get INFO 1"
        Me.buttonGetInfo.UseVisualStyleBackColor = True
        '
        'buttonQuidoDestroy
        '
        Me.buttonQuidoDestroy.Location = New System.Drawing.Point(302, 19)
        Me.buttonQuidoDestroy.Name = "buttonQuidoDestroy"
        Me.buttonQuidoDestroy.Size = New System.Drawing.Size(89, 46)
        Me.buttonQuidoDestroy.TabIndex = 19
        Me.buttonQuidoDestroy.Text = "Destory QUIDO"
        Me.buttonQuidoDestroy.UseVisualStyleBackColor = True
        '
        'richTextBox1
        '
        Me.richTextBox1.Location = New System.Drawing.Point(528, 18)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(390, 629)
        Me.richTextBox1.TabIndex = 23
        Me.richTextBox1.Text = resources.GetString("richTextBox1.Text")
        '
        'groupBoxQuido
        '
        Me.groupBoxQuido.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.groupBoxQuido.Controls.Add(Me.numericOutputTimer)
        Me.groupBoxQuido.Controls.Add(Me.labelOutputTimer)
        Me.groupBoxQuido.Controls.Add(Me.buttonGetOutputs)
        Me.groupBoxQuido.Controls.Add(Me.buttonGetTemp)
        Me.groupBoxQuido.Controls.Add(Me.buttonListenToggle)
        Me.groupBoxQuido.Controls.Add(Me.labelOutputIndex)
        Me.groupBoxQuido.Controls.Add(Me.numericOutputIndex)
        Me.groupBoxQuido.Controls.Add(Me.buttonSetAutonotifyOff)
        Me.groupBoxQuido.Controls.Add(Me.buttonSetAutonotifyOn)
        Me.groupBoxQuido.Controls.Add(Me.buttonGetAutonotify)
        Me.groupBoxQuido.Controls.Add(Me.buttonGetCounterSettings)
        Me.groupBoxQuido.Controls.Add(Me.buttonSetCounterSettings)
        Me.groupBoxQuido.Controls.Add(Me.buttonGetCounter)
        Me.groupBoxQuido.Controls.Add(Me.buttonGetInputs)
        Me.groupBoxQuido.Controls.Add(Me.buttonGetInfoCore)
        Me.groupBoxQuido.Controls.Add(Me.buttonSetOutputOff)
        Me.groupBoxQuido.Controls.Add(Me.buttonSetOutputOn)
        Me.groupBoxQuido.Controls.Add(Me.buttonGetInfo)
        Me.groupBoxQuido.Controls.Add(Me.buttonQuidoDestroy)
        Me.groupBoxQuido.Controls.Add(Me.buttonQuidoCreate)
        Me.groupBoxQuido.Location = New System.Drawing.Point(12, 255)
        Me.groupBoxQuido.Name = "groupBoxQuido"
        Me.groupBoxQuido.Size = New System.Drawing.Size(504, 391)
        Me.groupBoxQuido.TabIndex = 22
        Me.groupBoxQuido.TabStop = False
        Me.groupBoxQuido.Text = "Quido"
        '
        'buttonQuidoCreate
        '
        Me.buttonQuidoCreate.Location = New System.Drawing.Point(112, 19)
        Me.buttonQuidoCreate.Name = "buttonQuidoCreate"
        Me.buttonQuidoCreate.Size = New System.Drawing.Size(89, 46)
        Me.buttonQuidoCreate.TabIndex = 18
        Me.buttonQuidoCreate.Text = "Create QUIDO"
        Me.buttonQuidoCreate.UseVisualStyleBackColor = True
        '
        'groupBoxCommunicationInterface
        '
        Me.groupBoxCommunicationInterface.Controls.Add(Me.textBoxTcpPort)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.textBoxTcpHost)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.label4)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.label3)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.buttonRefreshSerialPorts)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.comboBoxSerialPortBaudRate)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.label2)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.label1)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.comboBoxSerialPortName)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.radioButtonTcpClient)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.radioButtonSerialPort)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.buttonCiCreate)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.labelConnectionString)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.buttonCiDestroy)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.labelDeviceString)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.textBoxConnectionString)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.buttonCiConnect)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.textBoxDeviceString)
        Me.groupBoxCommunicationInterface.Controls.Add(Me.buttonCiDisconnect)
        Me.groupBoxCommunicationInterface.Location = New System.Drawing.Point(12, 12)
        Me.groupBoxCommunicationInterface.Name = "groupBoxCommunicationInterface"
        Me.groupBoxCommunicationInterface.Size = New System.Drawing.Size(504, 237)
        Me.groupBoxCommunicationInterface.TabIndex = 21
        Me.groupBoxCommunicationInterface.TabStop = False
        Me.groupBoxCommunicationInterface.Text = "Communication Interface - Initialization / Deinitialization "
        '
        'textBoxTcpPort
        '
        Me.textBoxTcpPort.Location = New System.Drawing.Point(112, 76)
        Me.textBoxTcpPort.Name = "textBoxTcpPort"
        Me.textBoxTcpPort.Size = New System.Drawing.Size(89, 20)
        Me.textBoxTcpPort.TabIndex = 35
        Me.textBoxTcpPort.Text = "10001"
        '
        'textBoxTcpHost
        '
        Me.textBoxTcpHost.Location = New System.Drawing.Point(112, 51)
        Me.textBoxTcpHost.Name = "textBoxTcpHost"
        Me.textBoxTcpHost.Size = New System.Drawing.Size(88, 20)
        Me.textBoxTcpHost.TabIndex = 34
        Me.textBoxTcpHost.Text = "192.168.1.254"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(54, 81)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(29, 13)
        Me.label4.TabIndex = 33
        Me.label4.Text = "Port:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(54, 55)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(60, 13)
        Me.label3.TabIndex = 32
        Me.label3.Text = "IP address:"
        '
        'buttonRefreshSerialPorts
        '
        Me.buttonRefreshSerialPorts.Location = New System.Drawing.Point(397, 47)
        Me.buttonRefreshSerialPorts.Name = "buttonRefreshSerialPorts"
        Me.buttonRefreshSerialPorts.Size = New System.Drawing.Size(89, 23)
        Me.buttonRefreshSerialPorts.TabIndex = 31
        Me.buttonRefreshSerialPorts.Text = "refresh ports"
        Me.buttonRefreshSerialPorts.UseVisualStyleBackColor = True
        '
        'comboBoxSerialPortBaudRate
        '
        Me.comboBoxSerialPortBaudRate.FormattingEnabled = True
        Me.comboBoxSerialPortBaudRate.Items.AddRange(New Object() {"1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200"})
        Me.comboBoxSerialPortBaudRate.Location = New System.Drawing.Point(302, 76)
        Me.comboBoxSerialPortBaudRate.Name = "comboBoxSerialPortBaudRate"
        Me.comboBoxSerialPortBaudRate.Size = New System.Drawing.Size(88, 21)
        Me.comboBoxSerialPortBaudRate.TabIndex = 30
        Me.comboBoxSerialPortBaudRate.Text = "9600"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(238, 79)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(41, 13)
        Me.label2.TabIndex = 29
        Me.label2.Text = "Speed:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(238, 52)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(58, 13)
        Me.label1.TabIndex = 28
        Me.label1.Text = "Port name:"
        '
        'comboBoxSerialPortName
        '
        Me.comboBoxSerialPortName.FormattingEnabled = True
        Me.comboBoxSerialPortName.Location = New System.Drawing.Point(302, 49)
        Me.comboBoxSerialPortName.Name = "comboBoxSerialPortName"
        Me.comboBoxSerialPortName.Size = New System.Drawing.Size(88, 21)
        Me.comboBoxSerialPortName.TabIndex = 27
        Me.comboBoxSerialPortName.Text = "COM1"
        '
        'radioButtonTcpClient
        '
        Me.radioButtonTcpClient.AutoSize = True
        Me.radioButtonTcpClient.Checked = True
        Me.radioButtonTcpClient.Location = New System.Drawing.Point(18, 29)
        Me.radioButtonTcpClient.Name = "radioButtonTcpClient"
        Me.radioButtonTcpClient.Size = New System.Drawing.Size(115, 17)
        Me.radioButtonTcpClient.TabIndex = 26
        Me.radioButtonTcpClient.TabStop = True
        Me.radioButtonTcpClient.Text = "TCP socket (client)"
        Me.radioButtonTcpClient.UseVisualStyleBackColor = True
        '
        'radioButtonSerialPort
        '
        Me.radioButtonSerialPort.AutoSize = True
        Me.radioButtonSerialPort.Location = New System.Drawing.Point(207, 29)
        Me.radioButtonSerialPort.Name = "radioButtonSerialPort"
        Me.radioButtonSerialPort.Size = New System.Drawing.Size(72, 17)
        Me.radioButtonSerialPort.TabIndex = 25
        Me.radioButtonSerialPort.Text = "Serial port"
        Me.radioButtonSerialPort.UseVisualStyleBackColor = True
        '
        'buttonCiCreate
        '
        Me.buttonCiCreate.Location = New System.Drawing.Point(112, 176)
        Me.buttonCiCreate.Name = "buttonCiCreate"
        Me.buttonCiCreate.Size = New System.Drawing.Size(89, 46)
        Me.buttonCiCreate.TabIndex = 13
        Me.buttonCiCreate.Text = "Create"
        Me.buttonCiCreate.UseVisualStyleBackColor = True
        '
        'labelConnectionString
        '
        Me.labelConnectionString.AutoSize = True
        Me.labelConnectionString.Location = New System.Drawing.Point(13, 107)
        Me.labelConnectionString.Name = "labelConnectionString"
        Me.labelConnectionString.Size = New System.Drawing.Size(92, 13)
        Me.labelConnectionString.TabIndex = 5
        Me.labelConnectionString.Text = "Connection string:"
        '
        'buttonCiDestroy
        '
        Me.buttonCiDestroy.Location = New System.Drawing.Point(398, 176)
        Me.buttonCiDestroy.Name = "buttonCiDestroy"
        Me.buttonCiDestroy.Size = New System.Drawing.Size(89, 46)
        Me.buttonCiDestroy.TabIndex = 10
        Me.buttonCiDestroy.Text = "Destroy"
        Me.buttonCiDestroy.UseVisualStyleBackColor = True
        '
        'labelDeviceString
        '
        Me.labelDeviceString.AutoSize = True
        Me.labelDeviceString.Location = New System.Drawing.Point(13, 144)
        Me.labelDeviceString.Name = "labelDeviceString"
        Me.labelDeviceString.Size = New System.Drawing.Size(72, 13)
        Me.labelDeviceString.TabIndex = 6
        Me.labelDeviceString.Text = "Device string:"
        '
        'textBoxConnectionString
        '
        Me.textBoxConnectionString.Location = New System.Drawing.Point(112, 104)
        Me.textBoxConnectionString.Name = "textBoxConnectionString"
        Me.textBoxConnectionString.Size = New System.Drawing.Size(374, 20)
        Me.textBoxConnectionString.TabIndex = 7
        Me.textBoxConnectionString.Text = "provider=SERIAL_PORT;PortName=COM11;BaudRate=115200"
        '
        'buttonCiConnect
        '
        Me.buttonCiConnect.Location = New System.Drawing.Point(207, 176)
        Me.buttonCiConnect.Name = "buttonCiConnect"
        Me.buttonCiConnect.Size = New System.Drawing.Size(89, 46)
        Me.buttonCiConnect.TabIndex = 12
        Me.buttonCiConnect.Text = "Connect"
        Me.buttonCiConnect.UseVisualStyleBackColor = True
        '
        'textBoxDeviceString
        '
        Me.textBoxDeviceString.Location = New System.Drawing.Point(112, 144)
        Me.textBoxDeviceString.Name = "textBoxDeviceString"
        Me.textBoxDeviceString.Size = New System.Drawing.Size(374, 20)
        Me.textBoxDeviceString.TabIndex = 8
        Me.textBoxDeviceString.Text = "adr=254"
        '
        'buttonCiDisconnect
        '
        Me.buttonCiDisconnect.Location = New System.Drawing.Point(302, 176)
        Me.buttonCiDisconnect.Name = "buttonCiDisconnect"
        Me.buttonCiDisconnect.Size = New System.Drawing.Size(89, 46)
        Me.buttonCiDisconnect.TabIndex = 11
        Me.buttonCiDisconnect.Text = "Disconnect"
        Me.buttonCiDisconnect.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(929, 658)
        Me.Controls.Add(Me.richTextBox1)
        Me.Controls.Add(Me.groupBoxQuido)
        Me.Controls.Add(Me.groupBoxCommunicationInterface)
        Me.Name = "FormMain"
        Me.Text = "Quido demo - .NET native (VB)"
        CType(Me.numericOutputTimer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericOutputIndex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBoxQuido.ResumeLayout(False)
        Me.groupBoxQuido.PerformLayout()
        Me.groupBoxCommunicationInterface.ResumeLayout(False)
        Me.groupBoxCommunicationInterface.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents numericOutputTimer As NumericUpDown
    Private WithEvents labelOutputTimer As Label
    Private WithEvents buttonGetOutputs As Button
    Private WithEvents buttonGetTemp As Button
    Private WithEvents buttonListenToggle As Button
    Private WithEvents labelOutputIndex As Label
    Private WithEvents numericOutputIndex As NumericUpDown
    Private WithEvents buttonSetAutonotifyOff As Button
    Private WithEvents buttonSetAutonotifyOn As Button
    Private WithEvents buttonGetAutonotify As Button
    Private WithEvents buttonGetCounterSettings As Button
    Private WithEvents buttonSetCounterSettings As Button
    Private WithEvents buttonGetCounter As Button
    Private WithEvents buttonGetInputs As Button
    Private WithEvents buttonGetInfoCore As Button
    Private WithEvents buttonSetOutputOff As Button
    Private WithEvents buttonSetOutputOn As Button
    Private WithEvents buttonGetInfo As Button
    Private WithEvents buttonQuidoDestroy As Button
    Private WithEvents richTextBox1 As RichTextBox
    Private WithEvents groupBoxQuido As GroupBox
    Private WithEvents buttonQuidoCreate As Button
    Private WithEvents groupBoxCommunicationInterface As GroupBox
    Private WithEvents textBoxTcpPort As TextBox
    Private WithEvents textBoxTcpHost As TextBox
    Private WithEvents label4 As Label
    Private WithEvents label3 As Label
    Private WithEvents buttonRefreshSerialPorts As Button
    Private WithEvents comboBoxSerialPortBaudRate As ComboBox
    Private WithEvents label2 As Label
    Private WithEvents label1 As Label
    Private WithEvents comboBoxSerialPortName As ComboBox
    Private WithEvents radioButtonTcpClient As RadioButton
    Private WithEvents radioButtonSerialPort As RadioButton
    Private WithEvents buttonCiCreate As Button
    Private WithEvents labelConnectionString As Label
    Private WithEvents buttonCiDestroy As Button
    Private WithEvents labelDeviceString As Label
    Private WithEvents textBoxConnectionString As TextBox
    Private WithEvents buttonCiConnect As Button
    Private WithEvents textBoxDeviceString As TextBox
    Private WithEvents buttonCiDisconnect As Button
End Class
