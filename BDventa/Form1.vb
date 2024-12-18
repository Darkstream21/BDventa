Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim salir As String = MsgBox("¿Desea salir?", vbYesNo, "Salida")
        If salir = vbYes Then
            Me.Close()
        End If
    End Sub

    Private Sub UsuariosBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles UsuariosBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.UsuariosBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.TiendaDataSet)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'TiendaDataSet.Usuarios' Puede moverla o quitarla según sea necesario.
        Me.UsuariosTableAdapter.Fill(Me.TiendaDataSet.Usuarios)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Validate()
        UsuariosBindingSource.Filter = "usuario='" & TextBox1.Text & " 'and contraseña='" & TextBox2.Text & "'"
        If UsuariosBindingSource.Count = 1 Then
            MsgBox("Bienvenidos " & TextBox1.Text & " ! ! !", MsgBoxStyle.Information, " Login OK")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.Focus()
            Me.Hide()
            Form3.Show()
        Else
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.Focus()
            MsgBox("ERROR No se pudo iniciar sesión ", MsgBoxStyle.Critical, "Error de login")
            Me.Hide()
            Form2.Show()
        End If
    End Sub
End Class
