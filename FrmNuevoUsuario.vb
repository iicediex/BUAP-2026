Imports Microsoft.Data.SqlClient

Public Class FrmNuevoUsuario
    Inherits System.Windows.Forms.Form

    Private txtCURP As TextBox
    Private txtNombre As TextBox
    Private txtApellido As TextBox
    Private txtFechaNac As TextBox
    Private cmbSexo As ComboBox
    Private cmbDerechohabiencia As ComboBox
    Private cmbEntidad As ComboBox
    Private txtEscolaridad As TextBox
    Private chkSabeLeer As CheckBox
    Private chkSabeEscribir As CheckBox

    Private Sub FrmNuevoUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Nuevo Usuario - BUAP"
        Me.Size = New Size(800, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.BackColor = Color.WhiteSmoke

        Dim y As Integer = 20

        Dim lblTitulo As New Label With {.Text = "REGISTRO DE NUEVO USUARIO", .Location = New Point(20, y), .Font = New Font("Arial", 14, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblTitulo)
        y += 50

        Dim lblCURP As New Label With {.Text = "CURP (18 caracteres):", .Location = New Point(20, y), .AutoSize = True}
        txtCURP = New TextBox With {.Location = New Point(200, y), .Size = New Size(400, 25), .MaxLength = 18}
        Me.Controls.Add(lblCURP)
        Me.Controls.Add(txtCURP)
        y += 40

        Dim lblNombre As New Label With {.Text = "Nombre:", .Location = New Point(20, y), .AutoSize = True}
        txtNombre = New TextBox With {.Location = New Point(200, y), .Size = New Size(400, 25)}
        Me.Controls.Add(lblNombre)
        Me.Controls.Add(txtNombre)
        y += 40

        Dim lblApellido As New Label With {.Text = "Apellido:", .Location = New Point(20, y), .AutoSize = True}
        txtApellido = New TextBox With {.Location = New Point(200, y), .Size = New Size(400, 25)}
        Me.Controls.Add(lblApellido)
        Me.Controls.Add(txtApellido)
        y += 40

        Dim lblFechaNac As New Label With {.Text = "Fecha Nacimiento (DD-MM-YYYY):", .Location = New Point(20, y), .AutoSize = True}
        txtFechaNac = New TextBox With {.Location = New Point(200, y), .Size = New Size(400, 25)}
        Me.Controls.Add(lblFechaNac)
        Me.Controls.Add(txtFechaNac)
        y += 40

        Dim lblSexo As New Label With {.Text = "Sexo:", .Location = New Point(20, y), .AutoSize = True}
        cmbSexo = New ComboBox With {.Location = New Point(200, y), .Size = New Size(400, 25), .DropDownStyle = ComboBoxStyle.DropDownList}
        cmbSexo.Items.AddRange({"M", "F", "O"})
        cmbSexo.SelectedIndex = 0
        Me.Controls.Add(lblSexo)
        Me.Controls.Add(cmbSexo)
        y += 40

        Dim lblDerecho As New Label With {.Text = "Derechohabiencia:", .Location = New Point(20, y), .AutoSize = True}
        cmbDerechohabiencia = New ComboBox With {.Location = New Point(200, y), .Size = New Size(400, 25), .DropDownStyle = ComboBoxStyle.DropDownList}
        cmbDerechohabiencia.Items.AddRange({"Ninguna", "IMSS", "ISSSTE", "PEMEX", "SEDENA", "SEMAR"})
        cmbDerechohabiencia.SelectedIndex = 0
        Me.Controls.Add(lblDerecho)
        Me.Controls.Add(cmbDerechohabiencia)
        y += 40

        Dim lblEntidad As New Label With {.Text = "Entidad Nacimiento:", .Location = New Point(20, y), .AutoSize = True}
        cmbEntidad = New ComboBox With {.Location = New Point(200, y), .Size = New Size(400, 25), .DropDownStyle = ComboBoxStyle.DropDownList}
        cmbEntidad.Items.AddRange({"Puebla", "México", "Ciudad de México", "Veracruz", "Oaxaca", "Otro"})
        cmbEntidad.SelectedIndex = 0
        Me.Controls.Add(lblEntidad)
        Me.Controls.Add(cmbEntidad)
        y += 40

        Dim lblEscolaridad As New Label With {.Text = "Escolaridad (años):", .Location = New Point(20, y), .AutoSize = True}
        txtEscolaridad = New TextBox With {.Location = New Point(200, y), .Size = New Size(400, 25)}
        Me.Controls.Add(lblEscolaridad)
        Me.Controls.Add(txtEscolaridad)
        y += 40

        Dim lblSabeLeer As New Label With {.Text = "Sabe Leer:", .Location = New Point(20, y), .AutoSize = True}
        chkSabeLeer = New CheckBox With {.Location = New Point(200, y), .Checked = False}
        Me.Controls.Add(lblSabeLeer)
        Me.Controls.Add(chkSabeLeer)
        y += 40

        Dim lblSabeEscribir As New Label With {.Text = "Sabe Escribir:", .Location = New Point(20, y), .AutoSize = True}
        chkSabeEscribir = New CheckBox With {.Location = New Point(200, y), .Checked = False}
        Me.Controls.Add(lblSabeEscribir)
        Me.Controls.Add(chkSabeEscribir)
        y += 50

        Dim btnGuardar As New Button With {.Text = "Guardar", .Location = New Point(20, y), .Size = New Size(150, 40)}
        AddHandler btnGuardar.Click, AddressOf btnGuardar_Click
        Me.Controls.Add(btnGuardar)

        Dim btnRegresar As New Button With {.Text = "Regresar", .Location = New Point(200, y), .Size = New Size(150, 40)}
        AddHandler btnRegresar.Click, Sub() Me.Close()
        Me.Controls.Add(btnRegresar)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)
        If txtCURP.Text.Trim().Length <> 18 Then
            MessageBox.Show("CURP debe tener 18 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtNombre.Text) Or String.IsNullOrWhiteSpace(txtApellido.Text) Then
            MessageBox.Show("Nombre y Apellido son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim fechaNac As Date
        If Not Date.TryParse(txtFechaNac.Text, fechaNac) Then
            MessageBox.Show("Fecha de Nacimiento inválida (DD-MM-YYYY).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn = Conexion.Conectar()
                If conn Is Nothing Then Return

                Dim query As String = "INSERT INTO Pacientes (curp, nombre, apellido, fecha_nacimiento, sexo, derechohabiencia, entidad_nacimiento, escolaridad_anios, sabe_leer, sabe_escribir) " &
                                      "VALUES (@curp, @nombre, @apellido, @fechaNac, @sexo, @derecho, @entidad, @escolaridad, @sabeLeer, @sabeEscribir)"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@curp", txtCURP.Text.Trim())
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                    cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim())
                    cmd.Parameters.AddWithValue("@fechaNac", fechaNac)
                    cmd.Parameters.AddWithValue("@sexo", cmbSexo.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@derecho", cmbDerechohabiencia.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@entidad", cmbEntidad.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@escolaridad", If(String.IsNullOrWhiteSpace(txtEscolaridad.Text), 0, CInt(txtEscolaridad.Text)))
                    cmd.Parameters.AddWithValue("@sabeLeer", If(chkSabeLeer.Checked, 1, 0))
                    cmd.Parameters.AddWithValue("@sabeEscribir", If(chkSabeEscribir.Checked, 1, 0))

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Usuario registrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al guardar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class