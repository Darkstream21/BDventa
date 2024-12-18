Public Class Form3
    Private Sub ProductosBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles ProductosBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductosBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.TiendaDataSet)

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'TiendaDataSet.Productos' Puede moverla o quitarla según sea necesario.
        Me.ProductosTableAdapter.Fill(Me.TiendaDataSet.Productos)

    End Sub

    Private Sub ImagenPictureBox_Click(sender As Object, e As EventArgs) Handles ImagenPictureBox.Click
        OpenFileDialog1.Title = "Abrir Imagen"
        OpenFileDialog1.FileName = ".jpg"
        OpenFileDialog1.Filter = "All files |*.*"
        OpenFileDialog1.ShowDialog()
        ImagenPictureBox.Image = System.Drawing.Image.FromFile(OpenFileDialog1.FileName)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Validate()
        Me.ProductosBindingSource.AddNew()
        CodigoTextBox.Focus()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If ImagenPictureBox.Image Is Nothing Or CodigoTextBox.Text = "" Or ProductoTextBox.Text = "" Or DescripcionTextBox.Text = "" Or DescripcionTextBox.Text = "" Or ExistenciaTextBox.Text = "" Then
            MsgBox("Error! Todos los campos deben estar completos y ademas tener una imagen en el registro", MsgBoxStyle.Critical, "Error de captura")
        Else
            If ProductosBindingSource.Find("codigo", CodigoTextBox.Text) = -1 Then
                Me.Validate()
                Me.ProductosBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.TiendaDataSet)
                Me.ProductosTableAdapter.Fill(Me.TiendaDataSet.Productos)
                MsgBox("Producto guardado satisfactoriamente", MsgBoxStyle.Information, "Captura ok")
            Else
                CodigoTextBox.Text = ""
                CodigoTextBox.Focus()
                MsgBox("Error el producto ya existe", MsgBoxStyle.Critical, "Error de captura")
            End If

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If CodigoTextBox.Text = "" Then
            MsgBox("Error, no existe producto para eliminar", MsgBoxStyle.Critical, "Error al eliminar")
        Else
            Dim eliminar As String = MsgBox("Desea eliminar el producto seleccionado", vbYesNo, "¿Eliminar?")
            If eliminar = vbYes Then
                Me.Validate()
                Me.ProductosBindingSource.RemoveCurrent()
                Me.TableAdapterManager.UpdateAll(Me.TiendaDataSet)
                Me.ProductosTableAdapter.Fill(Me.TiendaDataSet.Productos)
                MsgBox("Se ha eliminado el producto satisfactoriamente", MsgBoxStyle.Information, "Registro eliminado")
            Else
                MsgBox("Se ha cancelado la eliminacion del producto", MsgBoxStyle.Information, "Accion cancelada")
            End If
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Validate()
        Me.ProductosTableAdapter.Fill(Me.TiendaDataSet.Productos)
        MsgBox("La accion ha sido cancelada, ningun registro ha sido guardado", MsgBoxStyle.Information, "Accion Cancelada")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Validate()
        Me.ProductosBindingSource.RemoveCurrent()
        Me.TableAdapterManager.UpdateAll(Me.TiendaDataSet)
        Me.ProductosTableAdapter.Fill(Me.TiendaDataSet.Productos)
        MsgBox("El producto ha sido editado satisfactoriamente", MsgBoxStyle.Information, "Producto editado")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.ProductosBindingSource.MoveFirst()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.ProductosBindingSource.MovePrevious()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.ProductosBindingSource.MoveNext()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.ProductosBindingSource.MoveLast()
    End Sub


End Class