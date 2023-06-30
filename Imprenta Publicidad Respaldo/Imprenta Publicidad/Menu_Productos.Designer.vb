<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Menu_Productos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu_Productos))
        Me.btnInicio = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgProductos = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pcLimpiar = New System.Windows.Forms.PictureBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnUltimo = New System.Windows.Forms.Button()
        Me.btnPrimero = New System.Windows.Forms.Button()
        Me.btnAdelante = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pcModificar = New System.Windows.Forms.PictureBox()
        Me.pcEliminar = New System.Windows.Forms.PictureBox()
        Me.pcAgregar = New System.Windows.Forms.PictureBox()
        Me.pcListar = New System.Windows.Forms.PictureBox()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnListar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAtras = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pcInicio = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.InicioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TablasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PedidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerCatalogoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSesionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pcLimpiar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pcModificar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcEliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcAgregar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcListar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pcInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnInicio
        '
        Me.btnInicio.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.btnInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInicio.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInicio.ForeColor = System.Drawing.Color.Black
        Me.btnInicio.Location = New System.Drawing.Point(989, 781)
        Me.btnInicio.Name = "btnInicio"
        Me.btnInicio.Size = New System.Drawing.Size(42, 42)
        Me.btnInicio.TabIndex = 16
        Me.btnInicio.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.dgProductos)
        Me.GroupBox4.Font = New System.Drawing.Font("Perpetua", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox4.Location = New System.Drawing.Point(130, 577)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(828, 245)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detalles"
        '
        'dgProductos
        '
        Me.dgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProductos.Location = New System.Drawing.Point(24, 22)
        Me.dgProductos.Name = "dgProductos"
        Me.dgProductos.RowHeadersWidth = 51
        Me.dgProductos.RowTemplate.Height = 24
        Me.dgProductos.Size = New System.Drawing.Size(778, 205)
        Me.dgProductos.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.pcLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnUltimo)
        Me.GroupBox1.Controls.Add(Me.btnPrimero)
        Me.GroupBox1.Controls.Add(Me.btnAdelante)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnAtras)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Perpetua", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox1.Location = New System.Drawing.Point(130, 174)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(828, 378)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos"
        '
        'pcLimpiar
        '
        Me.pcLimpiar.BackColor = System.Drawing.Color.White
        Me.pcLimpiar.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.pcLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pcLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pcLimpiar.Enabled = False
        Me.pcLimpiar.Image = Global.Imprenta_Publicidad.My.Resources.Resources.escoba
        Me.pcLimpiar.Location = New System.Drawing.Point(409, 325)
        Me.pcLimpiar.Name = "pcLimpiar"
        Me.pcLimpiar.Size = New System.Drawing.Size(25, 25)
        Me.pcLimpiar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcLimpiar.TabIndex = 8
        Me.pcLimpiar.TabStop = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ForeColor = System.Drawing.Color.Black
        Me.btnLimpiar.Location = New System.Drawing.Point(400, 317)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(42, 42)
        Me.btnLimpiar.TabIndex = 7
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnUltimo
        '
        Me.btnUltimo.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.btnUltimo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUltimo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUltimo.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUltimo.ForeColor = System.Drawing.Color.Black
        Me.btnUltimo.Location = New System.Drawing.Point(562, 317)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(86, 41)
        Me.btnUltimo.TabIndex = 6
        Me.btnUltimo.Text = ">>"
        Me.btnUltimo.UseVisualStyleBackColor = True
        '
        'btnPrimero
        '
        Me.btnPrimero.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.btnPrimero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrimero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrimero.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrimero.ForeColor = System.Drawing.Color.Black
        Me.btnPrimero.Location = New System.Drawing.Point(193, 317)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(86, 41)
        Me.btnPrimero.TabIndex = 5
        Me.btnPrimero.Text = "<<"
        Me.btnPrimero.UseVisualStyleBackColor = True
        '
        'btnAdelante
        '
        Me.btnAdelante.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.btnAdelante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAdelante.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdelante.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdelante.ForeColor = System.Drawing.Color.Black
        Me.btnAdelante.Location = New System.Drawing.Point(460, 317)
        Me.btnAdelante.Name = "btnAdelante"
        Me.btnAdelante.Size = New System.Drawing.Size(86, 41)
        Me.btnAdelante.TabIndex = 4
        Me.btnAdelante.Text = ">"
        Me.btnAdelante.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.pcModificar)
        Me.GroupBox3.Controls.Add(Me.pcEliminar)
        Me.GroupBox3.Controls.Add(Me.pcAgregar)
        Me.GroupBox3.Controls.Add(Me.pcListar)
        Me.GroupBox3.Controls.Add(Me.btnModificar)
        Me.GroupBox3.Controls.Add(Me.btnEliminar)
        Me.GroupBox3.Controls.Add(Me.btnListar)
        Me.GroupBox3.Controls.Add(Me.btnAgregar)
        Me.GroupBox3.Font = New System.Drawing.Font("Perpetua", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox3.Location = New System.Drawing.Point(500, 21)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(302, 280)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Operaciones"
        '
        'pcModificar
        '
        Me.pcModificar.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.pcModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pcModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pcModificar.Enabled = False
        Me.pcModificar.Image = Global.Imprenta_Publicidad.My.Resources.Resources.archivo_de_edicion
        Me.pcModificar.Location = New System.Drawing.Point(68, 222)
        Me.pcModificar.Name = "pcModificar"
        Me.pcModificar.Size = New System.Drawing.Size(32, 28)
        Me.pcModificar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcModificar.TabIndex = 10
        Me.pcModificar.TabStop = False
        '
        'pcEliminar
        '
        Me.pcEliminar.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.pcEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pcEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pcEliminar.Enabled = False
        Me.pcEliminar.Image = Global.Imprenta_Publicidad.My.Resources.Resources.rectangulo_xmark
        Me.pcEliminar.Location = New System.Drawing.Point(66, 160)
        Me.pcEliminar.Name = "pcEliminar"
        Me.pcEliminar.Size = New System.Drawing.Size(32, 28)
        Me.pcEliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcEliminar.TabIndex = 10
        Me.pcEliminar.TabStop = False
        '
        'pcAgregar
        '
        Me.pcAgregar.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.pcAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pcAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pcAgregar.Enabled = False
        Me.pcAgregar.Image = Global.Imprenta_Publicidad.My.Resources.Resources.agregar_documento
        Me.pcAgregar.Location = New System.Drawing.Point(66, 96)
        Me.pcAgregar.Name = "pcAgregar"
        Me.pcAgregar.Size = New System.Drawing.Size(32, 28)
        Me.pcAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcAgregar.TabIndex = 10
        Me.pcAgregar.TabStop = False
        '
        'pcListar
        '
        Me.pcListar.BackColor = System.Drawing.Color.Transparent
        Me.pcListar.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.pcListar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pcListar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pcListar.Enabled = False
        Me.pcListar.Image = Global.Imprenta_Publicidad.My.Resources.Resources.lista_de_rectangulos
        Me.pcListar.Location = New System.Drawing.Point(66, 37)
        Me.pcListar.Name = "pcListar"
        Me.pcListar.Size = New System.Drawing.Size(32, 28)
        Me.pcListar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcListar.TabIndex = 10
        Me.pcListar.TabStop = False
        '
        'btnModificar
        '
        Me.btnModificar.BackColor = System.Drawing.SystemColors.Control
        Me.btnModificar.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.btnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnModificar.Font = New System.Drawing.Font("Perpetua Titling MT", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.ForeColor = System.Drawing.Color.Black
        Me.btnModificar.Location = New System.Drawing.Point(44, 214)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(220, 45)
        Me.btnModificar.TabIndex = 6
        Me.btnModificar.Text = "     MODIFICAR"
        Me.btnModificar.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminar.Font = New System.Drawing.Font("Perpetua Titling MT", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar.Location = New System.Drawing.Point(44, 152)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(220, 45)
        Me.btnEliminar.TabIndex = 5
        Me.btnEliminar.Text = "   ELIMINAR"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnListar
        '
        Me.btnListar.BackColor = System.Drawing.SystemColors.Control
        Me.btnListar.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.btnListar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnListar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnListar.Font = New System.Drawing.Font("Perpetua Titling MT", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListar.ForeColor = System.Drawing.Color.Black
        Me.btnListar.Location = New System.Drawing.Point(44, 28)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(220, 45)
        Me.btnListar.TabIndex = 4
        Me.btnListar.Text = "LISTAR"
        Me.btnListar.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Font = New System.Drawing.Font("Perpetua Titling MT", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.Color.Black
        Me.btnAgregar.Location = New System.Drawing.Point(44, 90)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(220, 45)
        Me.btnAgregar.TabIndex = 0
        Me.btnAgregar.Text = "   AGREGAR"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.TextBox5)
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox2.Location = New System.Drawing.Point(24, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(458, 280)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ingresar Datos"
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Perpetua", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(200, 213)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(221, 27)
        Me.TextBox5.TabIndex = 9
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Perpetua", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(200, 169)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(221, 27)
        Me.TextBox4.TabIndex = 8
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Perpetua", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(200, 124)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(221, 27)
        Me.TextBox3.TabIndex = 7
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Perpetua", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(200, 80)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(221, 27)
        Me.TextBox2.TabIndex = 6
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Perpetua", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(200, 41)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(221, 27)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.Text = "PR0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Perpetua", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(29, 213)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 27)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "SKU:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Perpetua", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(28, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 27)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Precio:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Perpetua", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(29, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 27)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Descripción:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Perpetua", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(28, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 27)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Nombre:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Perpetua", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(28, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 27)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "ID Producto:"
        '
        'btnAtras
        '
        Me.btnAtras.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.btnAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAtras.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtras.ForeColor = System.Drawing.Color.Black
        Me.btnAtras.Location = New System.Drawing.Point(295, 317)
        Me.btnAtras.Name = "btnAtras"
        Me.btnAtras.Size = New System.Drawing.Size(86, 41)
        Me.btnAtras.TabIndex = 3
        Me.btnAtras.Text = "<"
        Me.btnAtras.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(38, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 15)
        Me.Label3.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Perpetua Titling MT", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(349, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(411, 28)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Ingrese Datos Del Producto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Perpetua Titling MT", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(417, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(265, 44)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "PRODUCTOS"
        '
        'pcInicio
        '
        Me.pcInicio.BackColor = System.Drawing.Color.White
        Me.pcInicio.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Portrait
        Me.pcInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pcInicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pcInicio.Enabled = False
        Me.pcInicio.Image = Global.Imprenta_Publicidad.My.Resources.Resources.hogar
        Me.pcInicio.Location = New System.Drawing.Point(997, 791)
        Me.pcInicio.Name = "pcInicio"
        Me.pcInicio.Size = New System.Drawing.Size(26, 26)
        Me.pcInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcInicio.TabIndex = 17
        Me.pcInicio.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.Imprenta_Publicidad.My.Resources.Resources.TICS_LOGO
        Me.PictureBox2.Location = New System.Drawing.Point(867, 87)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(91, 67)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Imprenta_Publicidad.My.Resources.Resources.Logo_imprenta2
        Me.PictureBox1.Location = New System.Drawing.Point(130, 87)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(114, 67)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InicioToolStripMenuItem, Me.TablasToolStripMenuItem, Me.CerrarSesionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1082, 28)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'InicioToolStripMenuItem
        '
        Me.InicioToolStripMenuItem.Name = "InicioToolStripMenuItem"
        Me.InicioToolStripMenuItem.Size = New System.Drawing.Size(59, 24)
        Me.InicioToolStripMenuItem.Text = "Inicio"
        '
        'TablasToolStripMenuItem
        '
        Me.TablasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PedidosToolStripMenuItem, Me.ClientesToolStripMenuItem, Me.ProductosToolStripMenuItem})
        Me.TablasToolStripMenuItem.Name = "TablasToolStripMenuItem"
        Me.TablasToolStripMenuItem.Size = New System.Drawing.Size(84, 24)
        Me.TablasToolStripMenuItem.Text = "Registros"
        '
        'PedidosToolStripMenuItem
        '
        Me.PedidosToolStripMenuItem.Name = "PedidosToolStripMenuItem"
        Me.PedidosToolStripMenuItem.Size = New System.Drawing.Size(158, 26)
        Me.PedidosToolStripMenuItem.Text = "Pedidos"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(158, 26)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerCatalogoToolStripMenuItem})
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(158, 26)
        Me.ProductosToolStripMenuItem.Text = "Productos"
        '
        'VerCatalogoToolStripMenuItem
        '
        Me.VerCatalogoToolStripMenuItem.Name = "VerCatalogoToolStripMenuItem"
        Me.VerCatalogoToolStripMenuItem.Size = New System.Drawing.Size(178, 26)
        Me.VerCatalogoToolStripMenuItem.Text = "Ver Catalogo"
        '
        'CerrarSesionToolStripMenuItem
        '
        Me.CerrarSesionToolStripMenuItem.Name = "CerrarSesionToolStripMenuItem"
        Me.CerrarSesionToolStripMenuItem.Size = New System.Drawing.Size(110, 24)
        Me.CerrarSesionToolStripMenuItem.Text = "Cerrar Sesion"
        '
        'Menu_Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Imprenta_Publicidad.My.Resources.Resources.Friday
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1082, 846)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.pcInicio)
        Me.Controls.Add(Me.btnInicio)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Menu_Productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú Productos"
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pcLimpiar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.pcModificar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcEliminar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcAgregar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcListar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pcInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pcInicio As PictureBox
    Friend WithEvents btnInicio As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dgProductos As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pcLimpiar As PictureBox
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnUltimo As Button
    Friend WithEvents btnPrimero As Button
    Friend WithEvents btnAdelante As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents pcModificar As PictureBox
    Friend WithEvents pcEliminar As PictureBox
    Friend WithEvents pcAgregar As PictureBox
    Friend WithEvents pcListar As PictureBox
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnListar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnAtras As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents InicioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TablasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PedidosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerCatalogoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CerrarSesionToolStripMenuItem As ToolStripMenuItem
End Class
