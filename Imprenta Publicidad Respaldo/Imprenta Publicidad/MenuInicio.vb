Public Class MenuInicio
    Private Sub MenuInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 1
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Hide()
        MenuLogin.Show()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If (ComboBox1.SelectedIndex = 1) Then
            MenuPedidos.Show()
            Me.Hide()
        ElseIf (ComboBox1.SelectedIndex = 2) Then
            Menu_Productos.Show()
            Me.Hide()
        ElseIf (ComboBox1.SelectedIndex = 3) Then
            Menu_Clientes.Show()
            Me.Hide()
        ElseIf (ComboBox1.SelectedIndex = 4) Then
            Menu_Catalogos.Show()
            Me.Hide()
        Else
            MessageBox.Show("Seleccione una opcion valida")
        End If

    End Sub

    ' --MENÚ DE ARRIBA-

    Private Sub InicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InicioToolStripMenuItem.Click
        MessageBox.Show("Usted ya se encuentra en este menú", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning)

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
        Me.Hide()
        Menu_Catalogos.Show()
    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        Me.Hide()
        MenuLogin.Show()
    End Sub
End Class
