Public Class Menu_Catalogos

    Private PictureBoxesPequenos As PictureBox()
    Private pictureBoxGrande As PictureBox
    Private indiceImagenActual As Integer = 0
    Private imagenPersonalizadaSeleccionada As Boolean


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inicializar los Picture Boxes pequeños
        PictureBoxesPequenos = New PictureBox() {pcbHoodieP, pcbGorraP,
            pcbLonaP, pcbTazaP, pcbCuadernoP, pcbTermo}

        ' Asignar imágenes a los Picture Boxes pequeños
        PictureBoxesPequenos(0).Image = pcbHoodieP.Image
        PictureBoxesPequenos(1).Image = pcbGorraP.Image
        PictureBoxesPequenos(2).Image = pcbLonaP.Image
        PictureBoxesPequenos(3).Image = pcbTazaP.Image
        PictureBoxesPequenos(4).Image = pcbCuadernoP.Image
        PictureBoxesPequenos(5).Image = pcbTermo.Image

        'Asignar los tags / descripciones al arreglo de  picture boxes pequeños
        PictureBoxesPequenos(0).Tag = pcbHoodieP.Tag
        PictureBoxesPequenos(1).Tag = pcbGorraP.Tag
        PictureBoxesPequenos(2).Tag = pcbLonaP.Tag
        PictureBoxesPequenos(3).Tag = pcbTazaP.Tag
        PictureBoxesPequenos(4).Tag = pcbCuadernoP.Tag
        PictureBoxesPequenos(5).Tag = pcbTermo.Tag


        ' Inicializar el Picture Box grande vacío
        pictureBoxGrande = pcbGrande


    End Sub


    Private Sub pcAnterior_Click(sender As Object, e As EventArgs) Handles pcAnterior.Click
        indiceImagenActual -= 1
        If indiceImagenActual < 0 Then
            indiceImagenActual = PictureBoxesPequenos.Length - 1
        End If
        pcbGrande.Image = PictureBoxesPequenos(indiceImagenActual).Image
        pcbGrande.Tag = PictureBoxesPequenos(indiceImagenActual).Tag
        imagenPersonalizadaSeleccionada = True

    End Sub


    Private Sub pcInformacion_Click(sender As Object, e As EventArgs) Handles pcInformacion.Click
        If imagenPersonalizadaSeleccionada Then
            Dim descripcion As String = pictureBoxGrande.Tag.ToString()
            MessageBox.Show(descripcion, "DESCRIPCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("Por favor, selecciona una imagen antes de ver la información.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub pcSiguiente_Click(sender As Object, e As EventArgs) Handles pcSiguiente.Click
        indiceImagenActual += 1
        If indiceImagenActual >= PictureBoxesPequenos.Length Then
            indiceImagenActual = 0
        End If
        pcbGrande.Image = PictureBoxesPequenos(indiceImagenActual).Image
        pcbGrande.Tag = PictureBoxesPequenos(indiceImagenActual).Tag
        imagenPersonalizadaSeleccionada = True

    End Sub


    '---CODIGO PARA HACER CLICK EN IMAGENES PEQUEÑAS---
    Private Sub btnbHoodieP_Click(sender As Object, e As EventArgs) Handles btnHoodieP.Click
        pcbGrande.Image = pcbHoodieP.Image
        pcbGrande.Tag = pcbHoodieP.Tag
        imagenPersonalizadaSeleccionada = True

    End Sub

    Private Sub btnGorrasP_Click(sender As Object, e As EventArgs) Handles btnGorras.Click
        pcbGrande.Image = pcbGorraP.Image
        pcbGrande.Tag = pcbGorraP.Tag
        imagenPersonalizadaSeleccionada = True

    End Sub

    Private Sub btnLona_Click(sender As Object, e As EventArgs) Handles btnLona.Click
        pcbGrande.Image = pcbLonaP.Image
        pcbGrande.Tag = pcbLonaP.Tag
        imagenPersonalizadaSeleccionada = True

    End Sub

    Private Sub btnTaza_Click(sender As Object, e As EventArgs) Handles btnTazaP.Click
        pcbGrande.Image = pcbTazaP.Image
        pcbGrande.Tag = pcbTazaP.Tag
        imagenPersonalizadaSeleccionada = True

    End Sub

    Private Sub btnCuaderno_Click(sender As Object, e As EventArgs) Handles btnCuadernoP.Click
        pcbGrande.Image = pcbCuadernoP.Image
        pcbGrande.Tag = pcbCuadernoP.Tag
        imagenPersonalizadaSeleccionada = True

    End Sub

    Private Sub btnTermo_Click(sender As Object, e As EventArgs) Handles btnTermo.Click
        pcbGrande.Image = pcbTermo.Image
        pcbGrande.Tag = pcbTermo.Tag
        imagenPersonalizadaSeleccionada = True

    End Sub

    Private Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        Me.Hide()
        MenuInicio.Show()
    End Sub


    ' --MENÚ DE ARRIBA-

    Private Sub InicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InicioToolStripMenuItem.Click
        Me.Hide()
        MenuInicio.Show()
    End Sub

    Private Sub PedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosToolStripMenuItem.Click
        Me.Hide()
        MenuPedidos.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Me.Hide()
        Menu_Clientes.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Me.Hide()
        Menu_Productos.Show()
    End Sub

    Private Sub VerCatalogoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerCatalogoToolStripMenuItem.Click
        MessageBox.Show("Usted ya se encuentra en este menú", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        Me.Hide()
        MenuLogin.Show()
    End Sub

End Class