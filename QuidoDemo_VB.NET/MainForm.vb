Imports System.Text
Imports System.Windows.Forms

Imports Papouch.Communication
Imports Papouch.Spinel
Imports Papouch.Spinel.Spinel97
Imports Papouch.Utils

Imports System.IO.Ports

Imports System.Threading

Public Class FormMain
    Private Sub buttonSetCounterSettings_DoubleClick(sender As Object, e As EventArgs) Handles buttonSetCounterSettings.DoubleClick

    End Sub

#Region "MainForm"

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        checkFormControls()
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Papouch\QuidoDemoNet")
        If key IsNot Nothing Then
            Dim val As Object

            val = key.GetValue("ConnectionString")
            If val IsNot Nothing Then
                textBoxConnectionString.Text = val.ToString()
            End If

            val = key.GetValue("DeviceString")
            If val IsNot Nothing Then
                textBoxDeviceString.Text = val.ToString()
            End If
            key.Close()
        End If
        reloadSerialPortNames(sender, e)
        radioButtonProviderChange(sender, e)
    End Sub

    Private Sub FormMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Papouch\QuidoDemoNet")
        If key IsNot Nothing Then
            key.SetValue("ConnectionString", textBoxConnectionString.Text)
            key.SetValue("DeviceString", textBoxDeviceString.Text)
            key.Close()
        End If
    End Sub

#Region "Logging support"

    Public Delegate Sub LogCallBack(text As String)

    Public Sub LogMsg(text As String)
        If Me.InvokeRequired Then
            Me.BeginInvoke(New LogCallBack(AddressOf LogMsg), text)
        Else
            'textBox_ClientLog.Text += text + "\r\n";
            richTextBox1.AppendText([String].Format(text) + vbCr & vbLf)
        End If
    End Sub

#End Region

    Private Sub checkFormControls()
        Dim bc As Boolean = (ci IsNot Nothing)
        Dim ba As Boolean = (bc) AndAlso (ci.Active)
        Dim bq As Boolean = (ba) AndAlso (quido IsNot Nothing)

        buttonCiCreate.Enabled = Not bc
        buttonCiDestroy.Enabled = bc

        buttonCiConnect.Enabled = Not ba AndAlso bc
        buttonCiDisconnect.Enabled = ba

        buttonQuidoCreate.Enabled = Not bq AndAlso ba
        buttonQuidoDestroy.Enabled = bq

        buttonListenToggle.Enabled = bq
        buttonListenToggle.Text = (If((quido IsNot Nothing) AndAlso (quido.Listen), "SET Async Listener OFF", "SET Async Listener ON"))

        buttonGetInfo.Enabled = bq
        buttonGetInfoCore.Enabled = bq

        buttonGetOutputs.Enabled = bq
        buttonSetOutputOn.Enabled = bq
        buttonSetOutputOff.Enabled = bq
        numericOutputIndex.Enabled = bq
        labelOutputIndex.Enabled = bq
        numericOutputTimer.Enabled = bq
        labelOutputTimer.Enabled = bq


        buttonGetInputs.Enabled = bq

        buttonGetCounter.Enabled = bq
        buttonGetCounterSettings.Enabled = bq
        buttonSetCounterSettings.Enabled = bq

        buttonSetAutonotifyOn.Enabled = bq
        buttonGetAutonotify.Enabled = bq
        buttonSetAutonotifyOff.Enabled = bq

        buttonGetTemp.Enabled = bq
    End Sub

#End Region

#Region "Communication Interface"

    Private ci As ICommunicationInterface = Nothing

    Private Sub buttonCiCreate_Click(sender As Object, e As EventArgs) Handles buttonCiCreate.Click

        If textBoxConnectionString.Text.IndexOf("TCP_CLIENT") > 0 Then
            ci = New CiTcpClient()
            ci.ConfigString = textBoxConnectionString.Text
        Else
            Try
                ci = New CiSerialPort()
                ci.ConfigString = textBoxConnectionString.Text
            Catch ex As Exception
                LogMsg(String.Format("Exception: {0}", ex.Message))
            End Try
        End If

        LogMsg("CREATE CI")
        checkFormControls()
    End Sub

    Private Sub buttonCiConnect_Click(sender As Object, e As EventArgs) Handles buttonCiConnect.Click
        If ci.Open(True) Then
            LogMsg(String.Format("CONNECT - ok ({0})", ci.GetConfigString(False)))
        Else
            LogMsg("CONNECT - err: [ci.Open() = false]")
        End If
        checkFormControls()
    End Sub

    Private Sub buttonCiDisconnect_Click(sender As Object, e As EventArgs) Handles buttonCiDisconnect.Click
        If ci.Active Then
            If ci.Close(True) Then
                LogMsg("DISCONNECT - ok")
            Else
                LogMsg("DISCONNECT - err: [ci.Close = false]")
            End If
        End If
        checkFormControls()
    End Sub

    Private Sub buttonCiDestroy_Click(sender As Object, e As EventArgs) Handles buttonCiDestroy.Click
        If ci IsNot Nothing Then
            quido = Nothing
            ci.Close()
            ci = Nothing
            LogMsg("DESTROY - ok")
        Else
            LogMsg("DESTROY - err: ci is NULL")
        End If
        checkFormControls()
    End Sub

#End Region

#Region "Quido"

    Public quido As Papouch.Spinel.Spinel97.Device.Quido.Quido = Nothing

    ' vytvoření objektu "quido"
    Private Sub buttonQuidoCreate_Click(sender As Object, e As EventArgs) Handles buttonQuidoCreate.Click
        If ci IsNot Nothing Then
            quido = New Papouch.Spinel.Spinel97.Device.Quido.Quido(ci, &HFE)
            quido.ConfigString = textBoxDeviceString.Text

            quido.ConfigString = textBoxDeviceString.Text

            AddHandler quido.OnPacketReceive, AddressOf PacketReceive
            AddHandler quido.OnInputChange, AddressOf InputChange
            AddHandler quido.OnInputsChange, AddressOf InputsChange

            ' like C# :
            ' quido.OnPacketReceive += New Papouch.Spinel.Spinel97.Device.Device.EventSpinelPacketReceive(AddressOf PacketReceive)
            ' quido.OnInputsChange += New Papouch.Spinel.Spinel97.Device.Quido.Quido.EventQuidoInputsChange(AddressOf InputsChange)
            ' quido.OnInputChange += New Papouch.Spinel.Spinel97.Device.Quido.Quido.EventQuidoInputChange(AddressOf InputChange)

            LogMsg("Quido object created.")
            checkFormControls()
        Else
            LogMsg("Initialize Communicatioin Interface first!")
        End If
    End Sub

    ' zrušení objektu quido
    Private Sub buttonQuidoDestroy_Click(sender As Object, e As EventArgs) Handles buttonQuidoDestroy.Click
        quido = Nothing
        checkFormControls()
    End Sub

#End Region

#Region "Commands: Get INFO - basic instructions"

    Private Sub buttonGetInfo_Click(sender As Object, e As EventArgs) Handles buttonGetInfo.Click
        Dim ver As SpinelDeviceVersion

        If quido.CmdGetInfo(ver) Then
            LogMsg("command GetINFO:" + ver.Description + " v." + ver.ProductId.ToString() + " " + ver.HardwareId.ToString() + " " + ver.SoftwareId.ToString())
        Else
            LogMsg("Get INFO - failure")
        End If
    End Sub

    Private Sub buttonGetInfoCore_Click(sender As Object, e As EventArgs) Handles buttonGetInfoCore.Click
        ' ukázka možnosti vlastní komunikace po komunikačním rozhraní

        If ci IsNot Nothing Then
            LogMsg("Send INST 'INFO'")

            Dim dt As DateTime = DateTime.Now

            Dim txPacket As New PacketSpinel97(&HF3)
            Dim rxPacket As PacketSpinel97

            If quido.SendAndReceive(txPacket, rxPacket) Then
                Dim i As Integer = (DateTime.Now.Millisecond - dt.Millisecond)
                Dim s As String = Encoding.ASCII.GetString(rxPacket.SDATA)
                LogMsg(s)
            End If
        End If
    End Sub

#End Region

#Region "Commands: Outputs"

    Private Sub buttonGetOutputs_Click(sender As Object, e As EventArgs) Handles buttonGetOutputs.Click
        If quido IsNot Nothing Then
            LogMsg("*** GetOutputs ***")

            Dim outputs As Boolean() = Nothing
            If quido.CmdGetOutputs(outputs) Then
                For index As Integer = 0 To outputs.Length - 1
                    LogMsg("Output " + index.ToString() + " is " + (If((outputs(index)), "ON", "OFF")))
                Next
            End If
        End If
    End Sub

    Private Sub buttonSetOutputOn_Click(sender As Object, e As EventArgs) Handles buttonSetOutputOn.Click
        If quido IsNot Nothing Then
            Dim index As Byte = CByte(numericOutputIndex.Value)
            Dim timer As Byte = CByte(numericOutputTimer.Value)

            If quido.CmdSetOutput(index, True, timer) Then
                LogMsg(String.Format("Quido Rele {0} = on", index))
            Else
                LogMsg(String.Format("Quido Rele {0} set off - failure", index))
            End If
        End If
    End Sub

    Private Sub buttonSetOutputOff_Click(sender As Object, e As EventArgs) Handles buttonSetOutputOff.Click
        If quido IsNot Nothing Then
            Dim index As Byte = CByte(numericOutputIndex.Value)
            Dim timer As Byte = CByte(numericOutputTimer.Value)

            If quido.CmdSetOutput(index, False, timer) Then
                LogMsg(String.Format("Quido Rele {0} = off", index))
            Else
                LogMsg(String.Format("Quido Rele {0} set on - failure", index))
            End If
        End If
    End Sub

#End Region

#Region "Commands: Inputs"

    Private Sub buttonGetInputs_Click(sender As Object, e As EventArgs) Handles buttonGetInputs.Click
        If quido IsNot Nothing Then
            LogMsg("*** GetInputs ***")

            Dim inputs As Boolean() = Nothing
            If quido.CmdGetInputs(inputs) Then
                For index As Integer = 0 To inputs.Length - 1
                    LogMsg("Input " + index.ToString() + " is " + (If((inputs(index)), "ON", "OFF")))
                Next
            End If
        End If
    End Sub

#End Region

#Region "Commands: Counters"

    Private Sub buttonGetCounter_Click(sender As Object, e As EventArgs) Handles buttonGetCounter.Click
        Dim i As Byte = 1

        If quido IsNot Nothing Then
            Dim counter As Integer
            If quido.CmdGetCounter(i, counter) Then
                LogMsg("Counter #" + i.ToString() + " = " + counter.ToString())
            End If
        End If
    End Sub

    Private Sub buttonGetCounterSettings_Click(sender As Object, e As EventArgs) Handles buttonGetCounterSettings.Click
        Dim i As Byte = 1

        If quido IsNot Nothing Then
            Dim rising As Boolean
            Dim falling As Boolean
            If quido.CmdGetCounterSettings(i, rising, falling) Then
                LogMsg("Counter #" + i.ToString() + " get settings - rising = " + (If((rising), "on", "off")) + ", falling = " + (If((falling), "on", "off")))
            End If
        End If
    End Sub

    Private Sub buttonSetCounterSettings_Click(sender As Object, e As EventArgs) Handles buttonSetCounterSettings.Click
        Dim i As Byte = 1

        If quido IsNot Nothing Then
            If quido.CmdSetCounterSettings(i, True, True) Then
                LogMsg("Counter #" + i.ToString() + " set settings - rising = on, falling = on ")
            End If
        End If
    End Sub

#End Region

#Region "Commands: Temperature"

    Private Sub buttonGetTemp_Click(sender As Object, e As EventArgs) Handles buttonGetTemp.Click
        If quido IsNot Nothing Then
            Dim temp As Single
            If quido.CmdGetTemperature(temp) Then
                LogMsg("Temperature is " + temp.ToString() + " °C")
            End If
        End If
    End Sub

#End Region

#Region "Commands: Autonotify"

    Private Sub buttonGetAutonotify_Click(sender As Object, e As EventArgs) Handles buttonGetAutonotify.Click
        If quido IsNot Nothing Then
            Dim format As Byte
            Dim mask As Boolean()
            If quido.CmdGetAutoNotify(format, mask) Then
                LogMsg("Autonotify is set to: " + format.ToString())
                For i As Integer = 0 To mask.Length - 1
                    LogMsg("Input " + i.ToString() + " is " + (If((mask(i)), "ON", "OFF")))

                Next
            Else
                LogMsg("Get Autonotify - failure !")
            End If
        End If
    End Sub

    Private Sub buttonSetAutonotifyOn_Click(sender As Object, e As EventArgs) Handles buttonSetAutonotifyOn.Click
        If quido IsNot Nothing Then
            If quido.CmdSetAutoNotify(True) Then
                LogMsg("Autonotify is now set to : ON")
            End If
        End If
    End Sub

    Private Sub buttonSetAutonotifyOff_Click(sender As Object, e As EventArgs) Handles buttonSetAutonotifyOff.Click
        If quido IsNot Nothing Then
            If quido.CmdSetAutoNotify(False) Then
                LogMsg("Autonotify is now set to : OFF")
            End If
        End If
    End Sub

#End Region

#Region "Async Event Mode"

    'provider=TCP_CLIENT;Host=192.168.2.93;Port=10001
    ' Po inicializaci objektu Quido je aktivní synchroní režim. 
    ' V synchroním režimu jsou data odesílána i přijímána v kontextu volání dané funkce - Nejsou thread-safe !
    ' Asynchronní režim je možné aktivovat voláním funkce "quido.StartListen()", deaktivace asyncronního režimu se provádí funkcí "quido.StopListen()"
    ' V asyncronním režimu je aktivován backgroundworker, který vyřizuje požadavky na odesílání paketů a také přijímá, parseuje a páruje přijaté pakety. 
    ' Synchronizace mezi voláním příkazu a odpovědí je prováděna pomocí eventů.
    ' Funkce v Asynchronním režimu jsou thread-safe. Události Quida nejsou thread-safe.

    ' Přepínání komunikačního režimu
    Private Sub buttonListenToggle_Click(sender As Object, e As EventArgs) Handles buttonListenToggle.Click
        If quido IsNot Nothing Then
            If Not quido.Listen Then
                quido.StartListen()

                checkFormControls()
            Else
                quido.StopListen()
                buttonListenToggle.Text = "SET Async Listener ON"
            End If
        End If
    End Sub

    ' příjem paketů 
    Private Sub PacketReceive(packet As PacketSpinel97)
        LogMsg("Receive Packet > " + PapUtils.ConvertBinToHex(packet.GetBin()))
    End Sub

    ' Pozor! Modul Quido odesílá informace o stavu vstupů/výstupů jako bitovou masku. Podle počtu daných IO je vždy použit odpovídající počet Byte pro přenos informací.
    ' Proto se na některých modulech přenáší více vstupů/výstupů než je jejich sketečný fyzický počet ! Sktečný počet IO lze zjistit pomocí funkce INFO.

    ' funkce je volána vždy když přijde od Quida samovolně vyslaná zpráva
    Private Sub InputsChange(quido As Papouch.Spinel.Spinel97.Device.Quido.Quido, inputs As [Boolean]())
        For index As Integer = 0 To inputs.Length - 1
            LogMsg("AUTONOTIFY - Input " + index.ToString() + " is " + (If((inputs(index)), "ON", "OFF")))
        Next
    End Sub

    ' funkce je volána pro každý vstup při detekci jeho změny - po inicializaci (při prvním volání) není znám předchozí stav, 
    ' proto se na poprvé zavolá funkce pro všechny vstupy. Při prvním voláním je hodnota io_old_stat a io_new_stat stejná, při změně jsou rozdílné.
    Private Sub InputChange(quido As Papouch.Spinel.Spinel97.Device.Quido.Quido, io_index As Integer, io_old_stat As Boolean, io_new_stat As Boolean)
        LogMsg("AUTONOTIFY - Input change: " + io_index + " is " + (If((io_new_stat), "ON", "OFF")))
    End Sub

#End Region

    Private Sub radioButtonProviderChange(sender As Object, e As EventArgs) Handles radioButtonTcpClient.Click, radioButtonSerialPort.Click
        textBoxTcpPort.Enabled = radioButtonTcpClient.Checked
        textBoxTcpHost.Enabled = radioButtonTcpClient.Checked

        comboBoxSerialPortName.Enabled = radioButtonSerialPort.Checked
        comboBoxSerialPortBaudRate.Enabled = radioButtonSerialPort.Checked

        providerSettingsChange(sender, e)
    End Sub

    Private Sub providerSettingsChange(sender As Object, e As EventArgs)
        Dim s As String = ""
        If radioButtonSerialPort.Checked Then
            s += "provider=SERIAL_PORT;"
            s += "PortName=" + comboBoxSerialPortName.SelectedItem + ";"
            s += "BaudRate=" + comboBoxSerialPortBaudRate.SelectedItem + ";"
        ElseIf radioButtonTcpClient.Checked Then
            s += "provider=TCP_CLIENT;"
            s += "Host=" + textBoxTcpHost.Text + ";"
            s += "Port=" + textBoxTcpPort.Text + ";"
        End If
        textBoxConnectionString.Text = s
    End Sub

    Private Sub reloadSerialPortNames(sender As Object, e As EventArgs) Handles buttonRefreshSerialPorts.Click
        comboBoxSerialPortName.BeginUpdate()
        Try
            comboBoxSerialPortName.Items.Clear()

            Dim ports As String() = SerialPort.GetPortNames()
            For Each port As String In ports
                comboBoxSerialPortName.Items.Add(port)
            Next
        Finally
            comboBoxSerialPortName.EndUpdate()
        End Try
    End Sub

End Class
