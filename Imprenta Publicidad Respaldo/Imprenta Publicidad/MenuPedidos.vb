Imports System.Data.SqlClient
Imports Microsoft.Win32

Public Class MenuPedidos

    '-------------------------- SECCION DE VARIABLES GLOBALES -------------------------------

    Dim tabla As DataTable
    Dim registro As DataRow
    Dim i, j As Integer


    '-------------------------- SECCION DE CARGA DEL FORMULARIO -------------------------------

    Private ejecutado As Boolean = False

    Private Sub MenuPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Activated
        If Not ejecutado Then
            Dim conBase As New SqlClient.SqlConnection("Data Source=LAPTOP-CTMJ5NHT;Initial Catalog=Imprenta;Integrated Security=True")

            ActualizarDataGridView()

            ' Crear DataAdapters para cada tabla que deseas utilizar
            Dim daDatos As New SqlClient.SqlDataAdapter("Select * from Pedidos", conBase)
            Dim daDatosMP As New SqlClient.SqlDataAdapter("Select * from Materia_Prima", conBase)
            Dim daDatosProducto As New SqlClient.SqlDataAdapter("Select * from Producto", conBase)
            Dim daDatosCliente As New SqlClient.SqlDataAdapter("Select * from Cliente", conBase)

            ' Crear DataSets para almacenar los datos de cada tabla
            Dim dsMuestra As New DataSet
            Dim dsMuestraMP As New DataSet
            Dim dsMuestraProducto As New DataSet
            Dim dsMuestraCliente As New DataSet

            ' Llenar los DataSets con los datos de las tablas correspondientes
            daDatos.Fill(dsMuestra, "Pedidos")
            daDatosMP.Fill(dsMuestraMP, "Materia Prima")
            daDatosProducto.Fill(dsMuestraProducto, "Producto")
            daDatosCliente.Fill(dsMuestraCliente, "Cliente")

            ' Rellenar los ComboBox con los datos de los DataSets
            RellenarComboBox(ComboBox1, dsMuestraCliente, "Cliente", "nombre", "id_cliente")
            RellenarComboBox(ComboBox2, dsMuestraProducto, "Producto", "nombre", "id_producto")
            RellenarComboBox(ComboBox3, dsMuestraMP, "Materia Prima", "nombre", "id_mp")
            If dsMuestra.Tables("Pedidos").Rows.Count > 0 Then
                ActualizarCampos(0)
            End If

            ejecutado = True
        End If
    End Sub

    Private Sub ActualizarDataGridView()
        Dim conBase As New SqlClient.SqlConnection("Data Source=LAPTOP-CTMJ5NHT;Initial Catalog=Imprenta;Integrated Security=True")
        ' Generar un DataAdapter para la unión de tablas
        Dim daDatosCompleto As New SqlClient.SqlDataAdapter("Select Ped.id_Pedidos as 'Numero de Pedido', 
        Cl.Nombre as 'Cliente', Pro.nombre as 'Producto',
        Ped.Cantidad, Ped.Fecha_Pedido as 'Fecha del Pedido', 
        Ped.Fecha_Entrega as 'Fecha de Entrega', MP.Nombre as 'Materia Prima'
        From Materia_Prima MP, Pedidos Ped,
        Producto Pro, Cliente Cl
        Where MP.id_mp = Ped.id_mp
        AND Ped.id_producto = Pro.id_producto
        AND Ped.id_Cliente = Cl.id_Cliente
        ORDER BY CAST(SUBSTRING(Ped.id_Pedidos, 2, LEN(Ped.id_Pedidos)) AS INT)", conBase)

        Dim dsMuestraCompleto As New DataSet
        daDatosCompleto.Fill(dsMuestraCompleto, "Completa")
        dgPedidos.DataSource = dsMuestraCompleto.Tables("Completa")

        ' Rellenar la tabla con los datos del DataSet
        tabla = dsMuestraCompleto.Tables("Completa")
        j = tabla.Rows.Count
    End Sub


    Private Sub RellenarComboBox(ComboBox As ComboBox, dsMuestraATratar As DataSet, Tabla As String, Display As String, Value As String)
        ' Agregar la opción "Seleccione una opción" al DataSet
        Dim dt As DataTable = dsMuestraATratar.Tables(Tabla)
        Dim row As DataRow = dt.NewRow()
        row(Display) = "Seleccione una Opción:"
        dt.Rows.InsertAt(row, 0)

        ' Rellenar el ComboBox con los datos del DataSet modificado
        ComboBox.DataSource = dt
        ComboBox.DisplayMember = Display
        ComboBox.ValueMember = Value

        ' Establecer el número máximo de elementos visibles en el ComboBox
        ComboBox.DropDownHeight = ComboBox.ItemHeight * 4

        ' Configurar la propiedad IntegralHeight en False para permitir desplazamiento
        ComboBox.IntegralHeight = False

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If Not TextBox1.Text.StartsWith("P") Then
            TextBox1.Text = "P"
            TextBox1.SelectionStart = 1
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Obtenemos la posición actual del cursor en el TextBox
        Dim cursorPosition As Integer = TextBox1.SelectionStart

        If cursorPosition = 0 AndAlso e.KeyChar <> "P"c Then
            ' El cursor está al principio y se presionó una tecla que no es "P"
            e.Handled = True
        ElseIf cursorPosition > 0 AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            ' El cursor está después del primer carácter (la "P") y se presionó una tecla que no es un dígito
            e.Handled = True
        End If
    End Sub

    Private Sub ActualizarCampos(indice As Integer)
        registro = tabla.Rows(indice)
        TextBox1.Text = CStr(registro.Item(0))
        ComboBox1.Text = CStr(registro.Item(1))
        ComboBox2.Text = CStr(registro.Item(2))
        NumericUpDown2.Text = CStr(registro.Item(3))
        dtmFechaE.Value = CStr(registro.Item(4))
        dtmFechaP.Value = CStr(registro.Item(5))
        ComboBox3.Text = CStr(registro.Item(6))
    End Sub


    Private Sub LimpiarEntradas()
        TextBox1.Text = ""
        dtmFechaE.Value = DateTime.Now
        dtmFechaE.Value = DateTime.Now.AddDays(2)
        NumericUpDown2.Text = 1
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
    End Sub

    '-------------------------- SECCION DE BOTON DE CONTROLES -------------------------------

    '--LISTAR--
    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        ActualizarCampos(0)
    End Sub

    '--AGREGAR--
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ' Obtener los valores de los controles de entrada
        Dim nuevoIDPedido As String = TextBox1.Text
        Dim nuevoIDCliente As String = If(ComboBox1.SelectedItem IsNot Nothing, ComboBox1.SelectedValue.ToString(), "")
        Dim nuevoIDProducto As String = If(ComboBox2.SelectedItem IsNot Nothing, ComboBox2.SelectedValue.ToString(), "")
        Dim nuevoCantidad As Integer = Integer.Parse(NumericUpDown2.Text)
        Dim nuevoFechaPedido As DateTime = DateTime.Parse(dtmFechaE.Value)
        Dim nuevoFechaEntrega As DateTime = DateTime.Parse(dtmFechaP.Value)
        Dim nuevoIDMP As String = If(ComboBox3.SelectedItem IsNot Nothing, ComboBox3.SelectedValue.ToString(), "")

        Dim conBase As New SqlConnection("Data Source=LAPTOP-CTMJ5NHT;Initial Catalog=Imprenta;Integrated Security=True")

        conBase.Open()

        ' Validar si el ID del pedido ya existe
        Dim idPedidoExistente As Boolean = False
        Dim idPedidoValido As Boolean = True
        Dim existeQuery As String = "SELECT COUNT(*) FROM Pedidos WHERE id_Pedidos = @IDPedido"
        Using existeCommand As New SqlCommand(existeQuery, conBase)
            existeCommand.Parameters.AddWithValue("@IDPedido", nuevoIDPedido)
            idPedidoExistente = CInt(existeCommand.ExecuteScalar()) > 0

            ' Validar si no se ha ingresado un número después de "P"
            If nuevoIDPedido.Length <= 1 OrElse Not Char.IsDigit(nuevoIDPedido(1)) Then
                idPedidoValido = False
            End If
        End Using

        If idPedidoExistente Or Not idPedidoValido Then
            MessageBox.Show("El ID del pedido no es válido o ya existe. No se puede duplicar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf nuevoIDCliente = "" OrElse nuevoIDProducto = "" OrElse nuevoIDMP = "" Then
            MessageBox.Show("Por favor, seleccione una opción válida en todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else

            ' Crear el comando de inserción de SQL
            Dim insertQuery As String = "INSERT INTO Pedidos (id_Pedidos, Cantidad, Fecha_Pedido, Fecha_Entrega, id_mp, id_producto, id_Cliente) 
            VALUES(@IDPedido, @Cantidad, @FechaPedido, @FechaEntrega, @IDMP, @IDProducto, @IDCliente)"
            Using insertCommand As New SqlCommand(insertQuery, conBase)
                ' Asignar los valores de los parámetros
                insertCommand.Parameters.AddWithValue("@IDPedido", nuevoIDPedido)
                insertCommand.Parameters.AddWithValue("@Cantidad", nuevoCantidad)
                insertCommand.Parameters.AddWithValue("@FechaPedido", nuevoFechaPedido)
                insertCommand.Parameters.AddWithValue("@FechaEntrega", nuevoFechaEntrega)
                insertCommand.Parameters.AddWithValue("@IDMP", nuevoIDMP)
                insertCommand.Parameters.AddWithValue("@IDProducto", nuevoIDProducto)
                insertCommand.Parameters.AddWithValue("@IDCliente", nuevoIDCliente)

                ' Ejecutar la consulta de inserción
                insertCommand.ExecuteNonQuery()
            End Using

            MessageBox.Show("El pedido ha sido agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

        Dim idPedido As String = TextBox1.Text

        ' Validar que se haya ingresado un ID de pedido válido
        If String.IsNullOrEmpty(idPedido) Then
            MessageBox.Show("Ingrese un ID de pedido válido")
            Return
        End If

        ' Establecer la conexión a la base de datos
        Using conBase As New SqlConnection("Data Source=LAPTOP-CTMJ5NHT;Initial Catalog=Imprenta;Integrated Security=True")
            conBase.Open()

            ' Crear el comando de eliminación de SQL
            Dim query As String = "DELETE FROM Pedidos WHERE id_Pedidos = @IDPedido"
            Using command As New SqlCommand(query, conBase)
                ' Asignar el valor del parámetro
                command.Parameters.AddWithValue("@IDPedido", idPedido)

                ' Ejecutar la consulta de eliminación
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                ' Verificar si se eliminó algún registro
                If rowsAffected > 0 Then
                    MessageBox.Show("Registro eliminado correctamente")
                Else
                    MessageBox.Show("No se encontró un pedido con el ID especificado")
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
        Dim nuevoIDPedido As String = TextBox1.Text
        Dim nuevoIDCliente As String = If(ComboBox1.SelectedValue() IsNot DBNull.Value, Convert.ToString(ComboBox1.SelectedValue()), "")
        Dim nuevoIDProducto As String = If(ComboBox2.SelectedValue() IsNot DBNull.Value, Convert.ToString(ComboBox2.SelectedValue()), "")
        Dim nuevoCantidad As Integer = Integer.Parse(NumericUpDown2.Text)
        Dim nuevoFechaPedido As DateTime = DateTime.Parse(dtmFechaP.Value)
        Dim nuevoFechaEntrega As DateTime = DateTime.Parse(dtmFechaE.Value)
        Dim nuevoIDMP As String = If(ComboBox3.SelectedValue() IsNot DBNull.Value, Convert.ToString(ComboBox3.SelectedValue()), "")

        Dim conBase As New SqlConnection("Data Source=LAPTOP-CTMJ5NHT;Initial Catalog=Imprenta;Integrated Security=True")
        conBase.Open()

        ' Verificar si el ID del pedido existe en la base de datos
        Dim idPedidoExistente As Boolean = False
        Dim existeQuery As String = "SELECT COUNT(*) FROM Pedidos WHERE id_Pedidos = @IDPedido"
        Using existeCommand As New SqlCommand(existeQuery, conBase)
            existeCommand.Parameters.AddWithValue("@IDPedido", nuevoIDPedido)
            idPedidoExistente = CInt(existeCommand.ExecuteScalar()) > 0
        End Using
        If String.IsNullOrEmpty(nuevoIDPedido) Then
            MessageBox.Show("Por favor, ingrese un ID de pedido válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf Not idPedidoExistente Then
            MessageBox.Show("El ID del pedido no existe. No se puede modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf nuevoIDCliente = "" OrElse nuevoIDProducto = "" OrElse nuevoIDMP = "" Then
            MessageBox.Show("Por favor, seleccione una opción válida en todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            ' Crear el comando de actualización de SQL
            Dim updateQuery As String = "UPDATE Pedidos SET Cantidad = @Cantidad, Fecha_Pedido = @FechaPedido, Fecha_Entrega = @FechaEntrega, id_mp = @IDMP, id_producto = @IDProducto, id_Cliente = @IDCliente WHERE id_Pedidos = @IDPedido"
            Using updateCommand As New SqlCommand(updateQuery, conBase)
                ' Asignar los valores de los parámetros
                updateCommand.Parameters.AddWithValue("@IDPedido", nuevoIDPedido)
                updateCommand.Parameters.AddWithValue("@Cantidad", nuevoCantidad)
                updateCommand.Parameters.AddWithValue("@FechaPedido", nuevoFechaPedido)
                updateCommand.Parameters.AddWithValue("@FechaEntrega", nuevoFechaEntrega)
                updateCommand.Parameters.AddWithValue("@IDMP", nuevoIDMP)
                updateCommand.Parameters.AddWithValue("@IDProducto", nuevoIDProducto)
                updateCommand.Parameters.AddWithValue("@IDCliente", nuevoIDCliente)

                ' Ejecutar la consulta de actualización
                updateCommand.ExecuteNonQuery()
            End Using

            MessageBox.Show("El pedido ha sido modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

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


    ' --REGISTROS--
    Private Sub PedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosToolStripMenuItem.Click
        MessageBox.Show("Usted ya se encuentra en este menú", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        ejecutado = False
        Me.Hide()
        Menu_Clientes.Show()
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

    Private Sub MenuPedidos_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        ejecutado = False
        Me.Hide()
        MenuLogin.Show()
    End Sub



End Class