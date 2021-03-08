Public Class Deactivation
    Dim TimesTried As String = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Timer1.Enabled = False Then

        End If

        If TextBox1.Text = "iamtheone" Then  'This Password Can Be Changed Into Whatever You Want\\\
            Application.Exit()
            End

        End If
        MsgBox("Access Denied")
        TimesTried += 1
        If TimesTried = 3 Then
            MessageBox.Show("Incorrect login maximum attempts achieved, please try again in 24 hours")
            Timer1.Enabled = True
        End If
        If TimesTried < 3 Then
            MessageBox.Show("Incorrect login, you have used " & TimesTried & " of 3 your login attempts.")
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TimesTried = 0
        Timer1.Enabled = False
    End Sub
End Class