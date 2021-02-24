Imports SpeechLib
Imports System.Threading
Public Class Form1
    Dim speech As SpVoice = New SpVoice()
    Dim speechRate As Integer = 0 ' Rango desde -10 hasta 10 
    Dim volume As Integer = 100 ' Rango desde 0 hasta 100.
    'Dim procesos As Process()
    Private Sub CodigoElse(texto As String, Traduce As Boolean)
        If Traduce = False Then
            speech.Voice = speech.GetVoices.Item(0)
            Select Case texto
'Interaccion con el bot
                Case "Hola"
                    Respuesta.Text = texto
                Case "Como estas?"
                    Respuesta.Text = "Bien y usted señor"
                Case "Me siento triste"
                    Respuesta.Text = "Espero que te sientas mejor. Pondre algo de musica"
                    Process.Start("https://www.youtube.com/playlist?list=LLsnM9cuc8SNfT9N3lrscWRw")
                Case "Me siento feliz"
                    Respuesta.Text = "Me alegro por usted señor"
                Case "Quiero programar"
                    Respuesta.Text = "En que lenguaje desea programar señor?"

'Abrir programas
                Case "Python"
                    Respuesta.Text = "Python abierto señor"
                    Process.Start("python.exe")
                Case "CMD"
                    Respuesta.Text = "CMD abierto señor"
                    Process.Start("cmd.exe")
                Case "Inventario"
                    Respuesta.Text = "Programa de inventario abierto señor"
                    Process.Start("C:\Users\PC0\Desktop\VisualProjects\Inventario\Inventario.exe")

'Abrir webs
                Case "Youtube"
                    Respuesta.Text = "youtube abierto señor"
                    Process.Start("www.youtube.com")
                Case "Quiero escuchar musica"
                    Respuesta.Text = "¿Que tipo de musica te gustaria escuchar?"
                Case "Quiero escuchar rock"
                    Respuesta.Text = "Buscando musica rock señor"
                    Process.Start("https://www.youtube.com/results?search_query=musica+rock")
                Case "Facebook"
                    Respuesta.Text = "Facebook abierto señor"
                    Process.Start("www.facebook.com")

'Tutorial
                Case "Que puedo traducir"
                    Respuesta.Text = "Se presentara a continuacion la lista de palabras que puede traducir, por favor pongalas tal y como estan para evitar errores"
                    Process.Start("C:\Users\PC0\Desktop\Kara\Translate\Translate.exe")

'Cerrar programa
                Case "Cerrar programa"
                    MsgBox("Hasta luego")
                    End
                Case Else
                    Respuesta.Text = "NO LE ENTENDI SEÑOR"
            End Select
            speech.Rate = 0
            speech.Volume = 80
            speech.Speak(Respuesta.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)
            'speech.WaitUntilDone(Timeout.Infinite)
        Else
            speech.Voice = speech.GetVoices.Item(1)
            'Traducir
            Select Case texto
'Saludos y despedidas
                Case "Saludo"
                    Traducido.Text = "Greeting"
                Case "Despedida"
                    Traducido.Text = "Farewell"
                Case "Hola"
                    Traducido.Text = "Hello"
                Case "Como estas?"
                    Traducido.Text = "How are you"
                Case "Adios"
                    Traducido.Text = "Goodbye"
                Case "Te veo despues"
                    Traducido.Text = "See you later"
                Case "Te veo pronto"
                    Traducido.Text = "See you soon"
'Objetos
                Case "Libro"
                    Traducido.Text = "Book"
                Case "Lapicero"
                    Traducido.Text = "Pen"
                Case "Lapiz"
                    Traducido.Text = "Pencil"
                Case Else
                    speech.Voice = speech.GetVoices.Item(0)
                    Traducido.Text = "NO LE ENTENDI SEÑOR"
            End Select
            speech.Rate = 0
            speech.Volume = 80
            speech.Speak(Traducido.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)
            'speech.WaitUntilDone(Timeout.Infinite)
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CodigoElse(TextBox1.Text, False)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each Token As ISpeechObjectToken In speech.GetVoices(String.Empty, String.Empty)
            ComboBox1.Items.Add(Token.GetDescription(49))
            ComboBox1.SelectedIndex = 0
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CodigoElse(TextBox4.Text, True)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("Hasta luego", 0, "Espero vuelva pronto")
        End
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        speech.Rate = speechRate
        speech.Volume = volume
        speech.Speak(TextBox2.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBarVolumen.Scroll
        volume = TrackBarVolumen.Value
    End Sub

    Private Sub TrackBarVelocidad_Scroll(sender As Object, e As EventArgs) Handles TrackBarVelocidad.Scroll
        speechRate = TrackBarVelocidad.Value
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(ComboBox1.SelectedIndex)
    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Respuesta_TextChanged(sender As Object, e As EventArgs) Handles Respuesta.TextChanged
    End Sub

    Private Sub Traducido_TextChanged(sender As Object, e As EventArgs) Handles Traducido.TextChanged

    End Sub
End Class