Imports Microsoft.Data.SqlClient
Public Class FormLogin
    Inherits System.Windows.Forms.Form

    Private txtUsuario As TextBox
    Private txtContrasena As TextBox
    Private lblMensaje As Label

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Login - Gerontología BUAP 2025"
        Me.Size = New Size(500, 400)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.FromArgb(240, 248, 255)

        Dim y As Integer = 60

        Dim lblTitulo As New Label With {.Text = "Sistema Gerontológico BUAP", .Location = New Point(40, y), .Font = New Font("Arial", 16, FontStyle.Bold), .ForeColor = Color.DarkBlue, .AutoSize = True}
        Me.Controls.Add(lblTitulo)
        y += 60

        Dim lblUsuario As New Label With {.Text = "Usuario:", .Location = New Point(40, y), .AutoSize = True}
        txtUsuario = New TextBox With {.Location = New Point(150, y - 5), .Size = New Size(250, 30)}
        Me.Controls.Add(lblUsuario)
        Me.Controls.Add(txtUsuario)
        y += 50

        Dim lblPass As New Label With {.Text = "Contraseña:", .Location = New Point(40, y), .AutoSize = True}
        txtContrasena = New TextBox With {.Location = New Point(150, y - 5), .Size = New Size(250, 30), .PasswordChar = "*"}
        Me.Controls.Add(lblPass)
        Me.Controls.Add(txtContrasena)
        y += 60

        lblMensaje = New Label With {.Text = "", .Location = New Point(40, y), .Size = New Size(400, 40), .ForeColor = Color.Red}
        Me.Controls.Add(lblMensaje)
        y += 60

        Dim btnIngresar As New Button With {.Text = "Ingresar", .Location = New Point(150, y), .Size = New Size(150, 50), .BackColor = Color.Green, .ForeColor = Color.White}
        AddHandler btnIngresar.Click, AddressOf btnIngresar_Click
        Me.Controls.Add(btnIngresar)
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs)
        lblMensaje.Text = ""
        lblMensaje.ForeColor = Color.Red

        Dim usuario As String = txtUsuario.Text.Trim()
        Dim contrasena As String = txtContrasena.Text

        If String.IsNullOrWhiteSpace(usuario) Or String.IsNullOrWhiteSpace(contrasena) Then
            lblMensaje.Text = "Ingrese usuario y contraseña"
            Return
        End If

        Try
            Using conn = Conexion.Conectar()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT id_gerontologo, nombre, apellido, rol FROM Gerontologos WHERE usuario = @user AND contrasena_hash = @pass AND activo = 1"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@user", usuario)
                    cmd.Parameters.AddWithValue("@pass", contrasena)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Globales.IdGerontologo = Convert.ToInt32(reader("id_gerontologo"))
                            Globales.GerontologoNombre = reader("nombre").ToString() & " " & reader("apellido").ToString()
                            Globales.Rol = reader("rol").ToString()
                            Globales.SesionActiva = True

                            lblMensaje.ForeColor = Color.Green
                            lblMensaje.Text = "¡Bienvenido!"

                            Me.Hide()
                            Dim frm As New FrmMenuPrincipal()
                            frm.ShowDialog()
                            Me.Close()
                        Else
                            lblMensaje.Text = "Usuario o contraseña incorrectos"
                            txtContrasena.Clear()
                            txtContrasena.Focus()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            lblMensaje.Text = "Error: " & ex.Message
        End Try
    End Sub
End Class