Imports Microsoft.Win32

Public Class SleepCenter
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Shell("shutdown -s")
        Dim regKey As RegistryKey
        regKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR", True)
        regKey.SetValue("Start", 4)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Deactivation.Show()
        Me.Hide()
    End Sub
End Class