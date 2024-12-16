Imports Microsoft.VisualBasic.Devices

Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        My.Computer.Audio.Stop()
        Me.Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Computer.Audio.Play(My.Resources.cs_hihat_loop_02_132bpm_258887, AudioPlayMode.BackgroundLoop)
    End Sub
End Class