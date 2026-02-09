Imports Microsoft.Data.SqlClient
Imports System.IO

Public Class FrmNuevoGerontologo
    Inherits System.Windows.Forms.Form

    Private txtNombre As TextBox
    Private txtApellido As TextBox
    Private txtUsuario As TextBox
    Private txtContrasena As TextBox
    Private cmbRol As ComboBox
    Private picFoto As PictureBox
    Private btnSeleccionarFoto As Button
    Private fotoPath As String = ""

    Private Sub FrmNuevoGerontologo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Nuevo Gerontólogo - BUAP"
        Me.Size = New Size(800, 500)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.BackColor = Color.WhiteSmoke

        Dim y As Integer = 20

        Dim lblTitulo As New Label With {.Text = "NUEVO GERONTÓLOGO", .Location = New Point(20, y), .Font = New Font("Arial", 14, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblTitulo)
        y += 50

        Dim lblNombre As New Label With {.Text = "Nombre:", .Location = New Point(20, y), .AutoSize = True}
        txtNombre = New TextBox With {.Location = New Point(150, y), .Size = New Size(300, 25)}
        Me.Controls.Add(lblNombre)
        Me.Controls.Add(txtNombre)
        y += 40

        Dim lblApellido As New Label With {.Text = "Apellido:", .Location = New Point(20, y), .AutoSize = True}
        txtApellido = New TextBox With {.Location = New Point(150, y), .Size = New Size(300, 25)}
        Me.Controls.Add(lblApellido)
        Me.Controls.Add(txtApellido)
        y += 40

        Dim lblUsuario As New Label With {.Text = "Usuario:", .Location = New Point(20, y), .AutoSize = True}
        txtUsuario = New TextBox With {.Location = New Point(150, y), .Size = New Size(300, 25)}
        Me.Controls.Add(lblUsuario)
        Me.Controls.Add(txtUsuario)
        y += 40

        Dim lblContrasena As New Label With {.Text = "Contraseña:", .Location = New Point(20, y), .AutoSize = True}
        txtContrasena = New TextBox With {.Location = New Point(150, y), .Size = New Size(300, 25), .PasswordChar = "*"}
        Me.Controls.Add(lblContrasena)
        Me.Controls.Add(txtContrasena)
        y += 40

        Dim lblRol As New Label With {.Text = "Rol:", .Location = New Point(20, y), .AutoSize = True}
        cmbRol = New ComboBox With {.Location = New Point(150, y), .Size = New Size(300, 25), .DropDownStyle = ComboBoxStyle.DropDownList}
        cmbRol.Items.AddRange({"Administrador", "Gerontólogo"})
        cmbRol.SelectedIndex = 1
        Me.Controls.Add(lblRol)
        Me.Controls.Add(cmbRol)
        y += 40

        Dim lblFoto As New Label With {.Text = "Foto:", .Location = New Point(20, y), .AutoSize = True}
        picFoto = New PictureBox With {.Location = New Point(150, y), .Size = New Size(150, 150), .BorderStyle = BorderStyle.FixedSingle}
        Me.Controls.Add(lblFoto)
        Me.Controls.Add(picFoto)
        y += 160

        btnSeleccionarFoto = New Button With {.Text = "Seleccionar Foto", .Location = New Point(320, y - 140), .Size = New Size(150, 40)}
        AddHandler btnSeleccionarFoto.Click, AddressOf btnSeleccionarFoto_Click
        Me.Controls.Add(btnSeleccionarFoto)

        Dim btnGuardar As New Button With {.Text = "Guardar", .Location = New Point(20, y), .Size = New Size(150, 40)}
        AddHandler btnGuardar.Click, AddressOf btnGuardar_Click
        Me.Controls.Add(btnGuardar)

        Dim btnRegresar As New Button With {.Text = "Regresar", .Location = New Point(180, y), .Size = New Size(150, 40)}
        AddHandler btnRegresar.Click, Sub() Me.Close()
        Me.Controls.Add(btnRegresar)

        If Globales.IdGerontologo > 0 Then
            Me.Text = "Editar Gerontólogo"
            CargarDatosParaEdit()
        End If
    End Sub

    Private Sub CargarDatosParaEdit()
        Try
            Using conn = Conexion.Conectar()
                Dim query As String = "SELECT nombre, apellido, usuario, rol, foto_path FROM Gerontologos WHERE id_gerontologo = @id"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", Globales.IdGerontologo)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtNombre.Text = reader("nombre").ToString()
                            txtApellido.Text = reader("apellido").ToString()
                            txtUsuario.Text = reader("usuario").ToString()
                            cmbRol.SelectedItem = reader("rol").ToString()
                            fotoPath = If(reader("foto_path") Is DBNull.Value, "", reader("foto_path").ToString())
                            If Not String.IsNullOrEmpty(fotoPath) Then
                                picFoto.Image = Image.FromFile(fotoPath)
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSeleccionarFoto_Click(sender As Object, e As EventArgs)
        Dim openFile As New OpenFileDialog()
        openFile.Filter = "Imágenes|*.jpg;*.png;*.bmp"
        If openFile.ShowDialog() = DialogResult.OK Then
            fotoPath = openFile.FileName
            picFoto.Image = Image.FromFile(fotoPath)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtNombre.Text) Or String.IsNullOrWhiteSpace(txtApellido.Text) Or String.IsNullOrWhiteSpace(txtUsuario.Text) Or String.IsNullOrWhiteSpace(txtContrasena.Text) Then
            MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn = Conexion.Conectar()
                If conn Is Nothing Then Return

                Dim query As String
                If Globales.IdGerontologo > 0 Then
                    query = "UPDATE Gerontologos SET nombre = @nombre, apellido = @apellido, usuario = @usuario, contrasena_hash = @contrasena, rol = @rol, foto_path = @foto WHERE id_gerontologo = @id"
                Else
                    query = "INSERT INTO Gerontologos (nombre, apellido, usuario, contrasena_hash, rol, foto_path) VALUES (@nombre, @apellido, @usuario, @contrasena, @rol, @foto)"
                End If

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim())
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim())
                    cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text.Trim())
                    cmd.Parameters.AddWithValue("@rol", cmbRol.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@foto", If(String.IsNullOrWhiteSpace(fotoPath), DBNull.Value, fotoPath))
                    If Globales.IdGerontologo > 0 Then cmd.Parameters.AddWithValue("@id", Globales.IdGerontologo)

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al guardar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class