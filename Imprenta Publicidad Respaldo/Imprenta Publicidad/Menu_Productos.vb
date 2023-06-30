Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.Logging
Imports Microsoft.Win32

Public Class Menu_Productos

    '-------------------------- SECCION DE VARIABLES GLOBALES -------------------------------

    Dim tabla As DataTable
    Dim registro As DataRow
    Dim i, j As Integer


    '-------------------------- SECCION DE CARGA DEL FORMULARIO -------------------------------
    Private ejecutado As Boolean = False

    Private Sub MenuProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not ejecutado Then

            Dim conBase As New SqlClient.SqlConnection("Data Source=LAPTOP-CTMJ5NHT;Initial Catalog=Imprenta;Integrated Security=True")

        ActualizarDataGridView()
        ActualizarCampos(0)

            ejecutado = True
        End If

    End Sub

    Private Sub ActualizarDataGridView()
        Dim conBase As New SqlClient.SqlConnection("Data Source=LAPTOP-CTMJ5NHT;Initial Catalog=Imprenta;Integrated Security=True")
        'Generar Data Adapter de toda nuestra tabla mediante una union de tablas
        Dim daDatosProductos As New SqlClient.SqlDataAdapter(
        "SELECT 
        id_producto as 'ID Del Producto',
        nombre as 'Nombre',
        descripcion as 'Descripción',
        ROUND(precio,2) as 'Precio', 
        sku as 'SKU'
        FROM Producto
        ORDER BY CAST(SUBSTRING(id_producto, 4, LEN(id_producto)) AS INT)", conBase)

        Dim dsMuestraProductos As New DataSet
        daDatosProductos.Fill(dsMuestraProductos, "Productos")
        dgProductos.DataSource = dsMuestraProductos.Tables("Productos")

        'Rellenar la tabla con nuestros datos
        tabla = dsMuestraProductos.Tables("Productos")
        j = tabla.Rows.Count
    End Sub

    Private Sub dgProductos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgProductos.CellFormatting
        If e.ColumnIndex = 3 AndAlso e.Value IsNot Nothing AndAlso Not e.Value Is DBNull.Value Then
            Dim precio As Double = CDbl(e.Value)
            Dim precioRedondeado As Double = Math.Round(precio, 2)
            e.Value = precioRedondeado.ToString("0.00")
            e.FormattingApplied = True
        End If
    End Sub


    Private Sub ActualizarCampos(indice As Integer)
        registro = tabla.Rows(indice)
        TextBox1.Text = CStr(registro.Item(0))
        TextBox2.Text = CStr(registro.Item(1))
        TextBox3.Text = CStr(registro.Item(2))

        Dim precio As Double = CDbl(registro.Item(3))
        Dim precioRedondeado As Double = Math.Round(precio, 2)
        TextBox4.Text = precioRedondeado.ToString()

        TextBox5.Text = CStr(registro.Item(4))
    End Sub

    Private Sub LimpiarEntradas()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If Not TextBox1.Text.StartsWith("PR0") Then
            TextBox1.Text = "PR0"
            TextBox1.SelectionStart = 4
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Obtenemos la posición actual del cursor en el TextBox
        Dim cursorPosition As Integer = TextBox1.SelectionStart

        If cursorPosition = 0 AndAlso e.KeyChar <> "P"c Then ''´PENDIENTE
            ' El cursor está al principio y se presionó una tecla que no es "P"
            e.Handled = True
        ElseIf cursorPosition > 0 AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            ' El cursor está después del primer carácter (la "P") y se presionó una tecla que no es un dígito
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        ' Verificar si el carácter presionado es un dígito o una tecla especial (por ejemplo, borrar, retroceso)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Ignorar el carácter ingresado si no es un dígito o una tecla especial
        End If

        ' Verificar la longitud actual del texto
        If TextBox5.Text.Length >= 6 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Ignorar el carácter ingresado si ya se alcanzó la longitud máxima
        End If
    End Sub


    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        ' Verificar la longitud del número de teléfono
        If TextBox5.Text.Length <> 6 Then
            TextBox5.ForeColor = Color.Red ' Cambiar el color del texto si no tiene 6 dígitos
        Else
            TextBox5.ForeColor = Color.Black ' Restablecer el color del texto si tiene 6 dígitos
        End If
    End Sub


    '-------------------------- SECCION DE BOTON DE CONTROLES -------------------------------

    '--LISTAR--
    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        ActualizarCampos(0)
    End Sub

    '--AGREGAR--
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ' Obtener los valores de los controles de entrada
        Dim nuevoIDProducto As String = TextBox1.Text
        Dim nuevoNombre As String = TextBox2.Text
        Dim nuevoDescripcion As String = TextBox3.Text
        Dim nuevoPrecio As String = TextBox4.Text
        Dim nuevoSKU As String = TextBox5.Text


        Dim conjuntoTextBoxes As TextBox() = {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5}

        If nuevoSKU.Length <> 6 Then
            MessageBox.Show("El SKU debe tener 6 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Validar la longitud del SKU (6 dígitos)


        Dim conBase As New SqlConnection("Data Source=LAPTOP-CTMJ5NHT;Initial Catalog=Imprenta;Integrated Security=True")

        conBase.Open()

        ' Validar si el ID del pedido ya existe
        Dim idProductoExistente As Boolean = False
        Dim idProductoValido As Boolean = True
        Dim existeQuery As String = "SELECT COUNT(*) FROM Producto WHERE id_producto = @IDProducto"
        Using existeCommand As New SqlCommand(existeQuery, conBase)
            existeCommand.Parameters.AddWithValue("@IDProducto", nuevoIDProducto)
            idProductoExistente = CInt(existeCommand.ExecuteScalar()) > 0
            If nuevoIDProducto.Length <= 3 OrElse Not Char.IsDigit(nuevoIDProducto(3)) Then
                idProductoValido = False
            End If
        End Using

        If idProductoExistente Or Not idProductoValido Then
            MessageBox.Show("El ID del producto no es válido o ya existe. No se puede duplicar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf String.IsNullOrWhiteSpace(nuevoIDProducto) OrElse
               String.IsNullOrWhiteSpace(nuevoNombre) OrElse
               String.IsNullOrWhiteSpace(nuevoDescripcion) OrElse 'PODRIAMOS DEJAR EL DE APELLIDO MATERNO ABIERTO
               String.IsNullOrWhiteSpace(nuevoPrecio) OrElse
               String.IsNullOrWhiteSpace(nuevoSKU) Then 'PODRIAMOS DEJAR EL DE RFC ABIERTO 
            MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            ' Crear el comando de inserción de SQL
            Dim insertQuery As String = "INSERT INTO Producto (id_producto, nombre, descripcion, precio, sku) 
            VALUES(@IDProducto, @Nombre, @Descripcion, @Precio, @SKU)"
            Using insertCommand As New SqlCommand(insertQuery, conBase)
                ' Asignar los valores de los parámetros
                insertCommand.Parameters.AddWithValue("@IDProducto", nuevoIDProducto)
                insertCommand.Parameters.AddWithValue("@Nombre", nuevoNombre)
                insertCommand.Parameters.AddWithValue("@Descripcion", nuevoDescripcion)
                insertCommand.Parameters.AddWithValue("@Precio", nuevoPrecio)
                insertCommand.Parameters.AddWithValue("@SKU", nuevoSKU)


                ' Ejecutar la consulta de inserción
                insertCommand.ExecuteNonQuery()
            End Using

            MessageBox.Show("El producto ha sido agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Cerrar la conexión con la base de datos
            conBase.Close()
            conBase.Dispose()


            'Actualizar la tabla de los datos
            ActualizarDataGridView()

            ' Limpiar los controles de entrada después de agregar el registro
            LimpiarEntradas()
        End If
    End Sub


    '--ELIMINAR--
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Dim idProducto As String = TextBox1.Text

        ' Validar que se haya ingresado un ID de pedido válido
        If String.IsNullOrEmpty(idProducto) Then
            MessageBox.Show("Ingrese un ID de Producto válido")
            Return
        End If

        ' Establecer la conexión a la base de datos
        Using conBase As New SqlConnection("Data Source=LAPTOP-CTMJ5NHT;Initial Catalog=Imprenta;Integrated Security=True")
            conBase.Open()

            ' Crear el comando de eliminación de SQL
            Dim query As String = "DELETE FROM Producto WHERE id_producto = @IDProducto"
            Using command As New SqlCommand(query, conBase)
                ' Asignar el valor del parámetro
                command.Parameters.AddWithValue("@IDProducto", idProducto)

                ' Ejecutar la consulta de eliminación
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                ' Verificar si se eliminó algún registro
                If rowsAffected > 0 Then
                    MessageBox.Show("Registro eliminado correctamente")
                Else
                    MessageBox.Show("No se encontró un producto con el ID especificado")
                End If
            End Using

            ' Cerrar la conexión con la base de datos
            conBase.Close()
            conBase.Dispose()
        End Using

        ' Actualizar la tabla de los datos
        ActualizarDataGridView()

        ' Limpiar los controles de entrada después de eliminar el registro
        LimpiarEntradas()
    End Sub

    '--MODIFICAR--
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        ' Obtener los valores de los controles de entrada
        Dim nuevoIDProducto As String = TextBox1.Text
        Dim nuevoNombre As String = TextBox2.Text
        Dim nuevoDescripcion As String = TextBox3.Text
        Dim nuevoPrecio As String = TextBox4.Text
        Dim nuevoSKU As String = TextBox5.Text


        Dim conjuntoTextBoxes As TextBox() = {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5}


        Dim conBase As New SqlConnection("Data Source=LAPTOP-CTMJ5NHT;Initial Catalog=Imprenta;Integrated Security=True")
        conBase.Open()

        ' Verificar si el ID del pedido existe en la base de datos
        Dim idPedidoExistente As Boolean = False
        Dim existeQuery As String = "SELECT COUNT(*) FROM Producto WHERE id_Producto = @IDProducto"
        Using existeCommand As New SqlCommand(existeQuery, conBase)
            existeCommand.Parameters.AddWithValue("@IDProducto", nuevoIDProducto)
            idPedidoExistente = CInt(existeCommand.ExecuteScalar()) > 0
        End Using
        If String.IsNullOrEmpty(nuevoIDProducto) Then
            MessageBox.Show("Por favor, ingrese un ID de producto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf Not idPedidoExistente Then
            MessageBox.Show("El ID del producto no existe. No se puede modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf String.IsNullOrWhiteSpace(nuevoIDProducto) OrElse
               String.IsNullOrWhiteSpace(nuevoNombre) OrElse
               String.IsNullOrWhiteSpace(nuevoDescripcion) OrElse 'PODRIAMOS DEJAR EL DE APELLIDO MATERNO ABIERTO
               String.IsNullOrWhiteSpace(nuevoPrecio) OrElse
               String.IsNullOrWhiteSpace(nuevoSKU) Then 'PODRIAMOS DEJAR EL DE RFC ABIERTO
            MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            ' Crear el comando de actualización de SQL
            Dim updateQuery As String = "UPDATE Producto SET nombre = @Nombre, descripcion = @Descripcion, precio = @Precio,
            sku = @SKU WHERE id_producto = @IDProducto"
            Using updateCommand As New SqlCommand(updateQuery, conBase)
                ' Asignar los valores de los parámetros
                updateCommand.Parameters.AddWithValue("@IDProducto", nuevoIDProducto)
                updateCommand.Parameters.AddWithValue("@Nombre", nuevoNombre)
                updateCommand.Parameters.AddWithValue("@Descripcion", nuevoDescripcion)
                updateCommand.Parameters.AddWithValue("@Precio", nuevoPrecio)
                updateCommand.Parameters.AddWithValue("@SKU", nuevoSKU)



                ' Ejecutar la consulta de actualización
                updateCommand.ExecuteNonQuery()
            End Using

            MessageBox.Show("El Producto ha sido modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Cerrar la conexión con la base de datos
            conBase.Close()
            conBase.Dispose()

            ' Actualizar la tabla de los datos
            ActualizarDataGridView()

            ' Limpiar los controles de entrada después de modificar el registro
            LimpiarEntradas()
        End If
    End Sub

    '-------------------------- SECCION DE BOTONES DE DESPLAZAMIENTO -------------------------------

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        ActualizarCampos(0)
    End Sub

    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        i -= 1
        If i >= 0 Then
            ActualizarCampos(i)
        Else
            i = 0
        End If
    End Sub

    Private Sub btnAdelante_Click(sender As Object, e As EventArgs) Handles btnAdelante.Click
        i += 1
        If i <= j - 1 Then
            ActualizarCampos(i)
        Else
            i = j - 1
        End If
    End Sub
    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        ActualizarCampos(j - 1)
    End Sub


    '-------------------------- SECCION DE BOTONES DE LIMPIAR E INICIO -------------------------------

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarEntradas()
    End Sub
    Private Sub pcLimpiar_Click(sender As Object, e As EventArgs) Handles pcLimpiar.Click
        LimpiarEntradas()
    End Sub

    Private Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        ejecutado = False
        MenuInicio.Show()
        Me.Hide()
    End Sub


    '-------------------------- SECCION DE MENU DE ARRIBA -------------------------------
    Private Sub InicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InicioToolStripMenuItem.Click
        btnInicio_Click(sender, e)
    End Sub


    ' --MENÚ DE ARRIBA-
    Private Sub PedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosToolStripMenuItem.Click
        ejecutado = False
        Me.Hide()
        MenuPedidos.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        ejecutado = False
        Me.Hide()
        Menu_Clientes.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        MessageBox.Show("Usted ya se encuentra en este menú", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Private Sub VerCatalogoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerCatalogoToolStripMenuItem.Click
        ejecutado = False
        Me.Hide()
        Menu_Catalogos.Show()
    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        ejecutado = False
        Me.Hide()
        MenuLogin.Show()
    End Sub



End Class