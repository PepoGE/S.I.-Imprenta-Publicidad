Imports System.Collections.Generic

Public Class MenuLogin
    ' Diccionario de usuarios y contraseñas
    Private usuarios As Dictionary(Of String, String) = New Dictionary(Of String, String)()

    Public Sub New()
        ' Agregar usuarios de ejemplo al diccionario
        usuarios.Add("jessica", "kiara")
        usuarios.Add("pepo", "jess")
        usuarios.Add("jose", "jess")
        usuarios.Add("diana", "karen")
        usuarios.Add("concepcion", "conchita")
        usuarios.Add("1", "123")
        usuarios.Add("admin", "admin")
        InitializeComponent()

        ' Asignar los marcadores de posición a los TextBoxes
        txtUsuario.Tag = "Usuario"
        txtContraseña.Tag = "Contraseña"
        SetPlaceholder(txtUsuario, "Usuario")
        SetPlaceholder(txtContraseña, "Contraseña")

        ' Asignar eventos GotFocus y LostFocus a los TextBoxes
        AddHandler txtUsuario.GotFocus, AddressOf txtUsuario_GotFocus
        AddHandler txtUsuario.LostFocus, AddressOf txtUsuario_LostFocus
        AddHandler txtContraseña.GotFocus, AddressOf txtContraseña_GotFocus
        AddHandler txtContraseña.LostFocus, AddressOf txtContraseña_LostFocus
        txtUsuario.TabStop = False
        txtContraseña.TabStop = False

        ' Asignar evento KeyPress a los TextBoxes
        AddHandler txtUsuario.KeyPress, AddressOf txtUsuario_KeyPress
        AddHandler txtContraseña.KeyPress, AddressOf txtContraseña_KeyPress
    End Sub

    ' Restablece el formulario a su estado inicial
    Private Sub ResetForm()
        txtUsuario.Text = ""
        txtContraseña.Text = ""
        RestorePlaceholder(txtUsuario)
        RestorePlaceholder(txtContraseña)
    End Sub

    ' Establece un marcador de posición en el TextBox especificado
    Private Sub SetPlaceholder(textBox As TextBox, placeholder As String)
        textBox.Text = placeholder
        textBox.ForeColor = Color.Gray
    End Sub

    ' Elimina el marcador de posición del TextBox especificado
    Private Sub RemovePlaceholder(textBox As TextBox)
        If textBox.ForeColor = Color.Gray AndAlso textBox.Text = textBox.Tag.ToString() Then
            textBox.Text = ""
            textBox.ForeColor = Color.Black
        End If
    End Sub

    ' Restaura el marcador de posición en el TextBox especificado si está vacío
    Private Sub RestorePlaceholder(textBox As TextBox)
        If textBox.Text.Trim() = "" Then
            textBox.Text = textBox.Tag.ToString()
            textBox.ForeColor = Color.Gray
        End If
    End Sub

    ' Evento que se activa cuando el TextBox de usuario recibe el foco
    Private Sub txtUsuario_GotFocus(sender As Object, e As EventArgs)
        RemovePlaceholder(txtUsuario)
    End Sub

    ' Evento que se activa cuando el TextBox de usuario pierde el foco
    Private Sub txtUsuario_LostFocus(sender As Object, e As EventArgs)
        RestorePlaceholder(txtUsuario)
    End Sub

    ' Evento que se activa cuando el TextBox de contraseña recibe el foco
    Private Sub txtContraseña_GotFocus(sender As Object, e As EventArgs)
        RemovePlaceholder(txtContraseña)
        txtContraseña.PasswordChar = "*"c ' Opcional: ocultar los caracteres de la contraseña
    End Sub

    ' Evento que se activa cuando el TextBox de contraseña pierde el foco
    Private Sub txtContraseña_LostFocus(sender As Object, e As EventArgs)
        RestorePlaceholder(txtContraseña)
    End Sub

    ' Evento que se activa cuando se presiona una tecla en el TextBox de usuario
    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            RealizarInicioSesion()
        End If
    End Sub

    ' Evento que se activa cuando se presiona una tecla en el TextBox de contraseña
    Private Sub txtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            RealizarInicioSesion()
        End If
    End Sub

    ' Evento que se activa cuando se hace clic en el botón de inicio de sesión
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        RealizarInicioSesion()
    End Sub

    ' Realiza el proceso de inicio de sesión
    Private Sub RealizarInicioSesion()
        Dim usuario As String = txtUsuario.Text
        Dim contraseña As String = txtContraseña.Text

        ' Verificar si las credenciales son válidas
        If usuarios.ContainsKey(usuario) AndAlso usuarios(usuario) = contraseña Then
            ' Mostrar el formulario principal y ocultar el formulario de inicio de sesión
            Me.Hide()
            MenuInicio.Show()
            ResetForm()
        Else
            MessageBox.Show("Usuario o contraseña incorrectos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


End Class
