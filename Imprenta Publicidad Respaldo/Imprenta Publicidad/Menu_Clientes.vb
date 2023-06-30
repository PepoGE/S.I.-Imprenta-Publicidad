Imports System.Data.SqlClient
Imports Microsoft.Win32

Public Class Menu_Clientes

    '-------------------------- SECCION DE VARIABLES GLOBALES -------------------------------

    Dim tabla As DataTable
    Dim registro As DataRow
    Dim i, j As Integer


    '-------------------------- SECCION DE CARGA DEL FORMULARIO -------------------------------

    Private ejecutado As Boolean = False

    Private Sub MenuClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Activated
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
        Dim daDatosClientes As New SqlClient.SqlDataAdapter(
        "SELECT 
        id_Cliente as 'ID del Cliente', 
        Nombre,
        Apellido_Paterno as 'Apellido Paterno',
        Apellido_Materno as 'Apellido Materno',
        Correo as 'Correo electrónico', 
        Telefono as 'Teléfono', 
        rfc as 'RFC'
        FROM Cliente
        ORDER BY CAST(SUBSTRING(id_Cliente, 2, LEN(id_Cliente)) AS INT);", conBase)

        Dim dsMuestraClientes As New DataSet
        daDatosClientes.Fill(dsMuestraClientes, "Clientes")
        dgClientes.DataSource = dsMuestraClientes.Tables("Clientes")

        'Rellenar la tabla con nuestros datos
        tabla = dsMuestraClientes.Tables("Clientes")
        j = tabla.Rows.Count
    End Sub

    Private Sub ActualizarCampos(indice As Integer)
        registro = tabla.Rows(indice)
        TextBox1.Text = CStr(registro.Item(0))
        TextBox2.Text = CStr(registro.Item(1))
        TextBox3.Text = CStr(registro.Item(2))
        TextBox4.Text = CStr(registro.Item(3))
        TextBox5.Text = CStr(registro.Item(4))
        TextBox6.Text = CStr(registro.Item(5))
        TextBox7.Text = CStr(registro.Item(6))
    End Sub

    Private Sub LimpiarEntradas()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If Not TextBox1.Text.StartsWith("C") Then
            TextBox1.Text = "C"
            TextBox1.SelectionStart = 1
        End If
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        ' Verificar si el carácter presionado es un dígito o una tecla especial (por ejemplo, borrar, retroceso)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Ignorar el carácter ingresado si no es un dígito o una tecla especial
        End If

        ' Verificar la longitud actual del texto
        If TextBox6.Text.Length >= 10 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Ignorar el carácter ingresado si ya se alcanzó la longitud máxima
        End If
    End Sub


    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        ' Verificar la longitud del número de teléfono
        If TextBox6.Text.Length <> 10 Then
            TextBox6.ForeColor = Color.Red ' Cambiar el color del texto si no tiene 10 dígitos
        Else
            TextBox6.ForeColor = Color.Black ' Restablecer el color del texto si tiene 10 dígitos
        End If
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        ' Verificar la longitud actual del texto
        If TextBox7.Text.Length >= 10 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Ignorar el carácter ingresado si ya se alcanzó la longitud máxima
        End If
    End Sub


    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        ' Verificar la longitud del número del rfc
        If TextBox7.Text.Length <> 10 Then
            TextBox7.ForeColor = Color.Red ' Cambiar el color del texto si no tiene 10 dígitos
        Else
            TextBox7.ForeColor = Color.Black ' Restablecer el color del texto si tiene 10 dígitos
        End If
    End Sub



    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Obtenemos la posición actual del cursor en el TextBox
        Dim cursorPosition As Integer = TextBox1.SelectionStart

        If cursorPosition = 0 AndAlso e.KeyChar <> "C"c Then
            ' El cursor está al principio y se presionó una tecla que no es "P"
            e.Handled = True
        ElseIf cursorPosition > 0 AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            ' El cursor está después del primer carácter (la "P") y se presionó una tecla que no es un dígito
            e.Handled = True
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
        Dim nuevoIDCliente As String = TextBox1.Text
        Dim nuevoNombre As String = TextBox2.Text
        Dim nuevoApellidoP As String = TextBox3.Text
        Dim nuevoApellidoM As String = TextBox4.Text
        Dim nuevoCorreo As String = TextBox5.Text
        Dim nuevoTelefono As String = TextBox6.Text
        Dim nuevoRFC As String = TextBox7.Text

        Dim conjuntoTextBoxes As TextBox() = {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7}

        If nuevoTelefono.Length <> 10 Then
            MessageBox.Show("El teléfono debe tener 10 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Validar la longitud del SKU (6 dígitos)
        If nuevoRFC.Length <> 10 Then
            MessageBox.Show("El RFC debe tener 10 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim conBase As New SqlConnection("Data Source=LAPTOP-CTMJ5NHT;Initial Catalog=Imprenta;Integrated Security=True")

        conBase.Open()

        ' Validar si el ID del pedido ya existe
        Dim idClienteExistente As Boolean = False
        Dim idClienteValido As Boolean = True
        Dim existeQuery As String = "SELECT COUNT(*) FROM Cliente WHERE id_Cliente = @IDCliente"
        Using existeCommand As New SqlCommand(existeQuery, conBase)
            existeCommand.Parameters.AddWithValue("@IDCliente", nuevoIDCliente)
            idClienteExistente = CInt(existeCommand.ExecuteScalar()) > 0
            If nuevoIDCliente.Length <= 1 OrElse Not Char.IsDigit(nuevoIDCliente(1)) Then
                idClienteValido = False
            End If
        End Using

        If idClienteExistente Or Not idClienteValido Then
            MessageBox.Show("El ID del cliente no es válido o ya existe. No se puede duplicar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf String.IsNullOrWhiteSpace(nuevoIDCliente) OrElse
               String.IsNullOrWhiteSpace(nuevoNombre) OrElse
               String.IsNullOrWhiteSpace(nuevoApellidoP) OrElse 'PODRIAMOS DEJAR EL DE APELLIDO MATERNO ABIERTO
               String.IsNullOrWhiteSpace(nuevoCorreo) OrElse
               String.IsNullOrWhiteSpace(nuevoTelefono) Then 'PODRIAMOS DEJAR EL DE RFC ABIERTO 
            MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            ' Crear el comando de inserción de SQL
            Dim insertQuery As String = "INSERT INTO Cliente (id_Cliente, Nombre, Apellido_Paterno, Apellido_Materno, Correo, Telefono, rfc) 
            VALUES(@IDCliente, @Nombre, @ApelllidoP, @ApellidoM, @Correo, @Telefono, @RFC)"
            Using insertCommand As New SqlCommand(insertQuery, conBase)
                ' Asignar los valores de los parámetros
                insertCommand.Parameters.AddWithValue("@IDCliente", nuevoIDCliente)
                insertCommand.Parameters.AddWithValue("@Nombre", nuevoNombre)
                insertCommand.Parameters.AddWithValue("@ApelllidoP", nuevoApellidoP)
                insertCommand.Parameters.AddWithValue("@ApellidoM", nuevoApellidoM)
                insertCommand.Parameters.AddWithValue("@Correo", nuevoCorreo)
                insertCommand.Parameters.AddWithValue("@Telefono", nuevoTelefono)
                insertCommand.Parameters.AddWithValue("@RFC", nuevoRFC)

                ' Ejecutar la consulta de inserción
                insertCommand.ExecuteNonQuery()
            End Using

            MessageBox.Show("El Cliente ha sido agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

        Dim idCliente As String = TextBox1.Text

        ' Validar que se haya ingresado un ID de pedido válido
        If String.IsNullOrEmpty(idCliente) Then
            MessageBox.Show("Ingrese un ID de Cliente válido")
            Return
        End If

        ' Establecer la conexión a la base de datos
        Using conBase As New SqlConnection("Data Source=LAPTOP-CTMJ5NHT;Initial Catalog=Imprenta;Integrated Security=True")
            conBase.Open()

            ' Crear el comando de eliminación de SQL
            Dim query As String = "DELETE FROM Cliente WHERE id_Cliente = @IDCliente"
            Using command As New SqlCommand(query, conBase)
                ' Asignar el valor del parámetro
                command.Parameters.AddWithValue("@IDCliente", idCliente)

                ' Ejecutar la consulta de eliminación
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                ' Verificar si se eliminó algún registro
                If rowsAffected > 0 Then
                    MessageBox.Show("Registro eliminado correctamente")
                Else
                    MessageBox.Show("No se encontró un cliente con el ID especificado")
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
        Dim nuevoIDCliente As String = TextBox1.Text
        Dim nuevoNombre As String = TextBox2.Text
        Dim nuevoApellidoP As String = TextBox3.Text
        Dim nuevoApellidoM As String = TextBox4.Text
        Dim nuevoCorreo As String = TextBox5.Text
        Dim nuevoTelefono As String = TextBox6.Text
        Dim nuevoRFC As String = TextBox7.Text

        Dim conjuntoTextBoxes As TextBox() = {TextBox1, TextBox2, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7}


        Dim conBase As New SqlConnection("Data Source=LAPTOP-CTMJ5NHT;Initial Catalog=Imprenta;Integrated Security=True")
        conBase.Open()

        ' Verificar si el ID del pedido existe en la base de datos
        Dim idPedidoExistente As Boolean = False
        Dim existeQuery As String = "SELECT COUNT(*) FROM Cliente WHERE id_Cliente = @IDCliente"
        Using existeCommand As New SqlCommand(existeQuery, conBase)
            existeCommand.Parameters.AddWithValue("@IDCliente", nuevoIDCliente)
            idPedidoExistente = CInt(existeCommand.ExecuteScalar()) > 0
        End Using
        If String.IsNullOrEmpty(nuevoIDCliente) Then
            MessageBox.Show("Por favor, ingrese un ID de cliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf Not idPedidoExistente Then
            MessageBox.Show("El ID del cliente no existe. No se puede modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf String.IsNullOrWhiteSpace(nuevoIDCliente) OrElse
               String.IsNullOrWhiteSpace(nuevoNombre) OrElse
               String.IsNullOrWhiteSpace(nuevoApellidoP) OrElse 'PODRIAMOS DEJAR EL DE APELLIDO MATERNO ABIERTO
               String.IsNullOrWhiteSpace(nuevoCorreo) OrElse
               String.IsNullOrWhiteSpace(nuevoTelefono) Then 'PODRIAMOS DEJAR EL DE RFC ABIERTO
            MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            ' Crear el comando de actualización de SQL
            Dim updateQuery As String = "UPDATE Cliente SET Nombre = @Nombre, Apellido_Paterno = @ApelllidoP, Apellido_Materno = @ApellidoM,
            Correo = @Correo, Telefono = @Telefono, rfc = @RFC WHERE id_Cliente = @IDCliente"
            Using updateCommand As New SqlCommand(updateQuery, conBase)
                ' Asignar los valores de los parámetros
                updateCommand.Parameters.AddWithValue("@IDCliente", nuevoIDCliente)
                updateCommand.Parameters.AddWithValue("@Nombre", nuevoNombre)
                updateCommand.Parameters.AddWithValue("@ApelllidoP", nuevoApellidoP)
                updateCommand.Parameters.AddWithValue("@ApellidoM", nuevoApellidoM)
                updateCommand.Parameters.AddWithValue("@Correo", nuevoCorreo)
                updateCommand.Parameters.AddWithValue("@Telefono", nuevoTelefono)
                updateCommand.Parameters.AddWithValue("@RFC", nuevoRFC)


                ' Ejecutar la consulta de actualización
                updateCommand.ExecuteNonQuery()
            End Using

            MessageBox.Show("El Cliente ha sido modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
        MessageBox.Show("Usted ya se encuentra en este menú", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        ejecutado = False
        Me.Hide()
        Menu_Productos.Show()
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