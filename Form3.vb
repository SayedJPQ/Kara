Imports SpeechLib
Public Class Form3
    Dim speech As SpVoice = New SpVoice()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "sayed" Then
            Me.Hide()
            Form2.Show()
            speech.Rate = 0
            speech.Volume = 80
            speech.Speak("Ahora debes poner tu contraseña", SpeechVoiceSpeakFlags.SVSFlagsAsync)
        Else
            speech.Rate = 0
            speech.Volume = 80
            speech.Speak("No estas autorizado", SpeechVoiceSpeakFlags.SVSFlagsAsync)
            MsgBox("Accesso denegado", 48, "Accesso restringido")
            End
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class