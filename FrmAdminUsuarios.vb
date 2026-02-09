Imports Microsoft.Data.SqlClient

Public Class FrmAdminUsuarios
    Inherits System.Windows.Forms.Form

    Private dgvUsuarios As DataGridView

    Private Sub FrmAdminUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Administrar Usuarios - BUAP"
        Me.Size = New Size(900, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.BackColor = Color.WhiteSmoke

        dgvUsuarios = New DataGridView With {.Location = New Point(20, 20), .Size = New Size(850, 400), .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, .ReadOnly = True}
        Me.Controls.Add(dgvUsuarios)

        CargarUsuarios()

        Dim btnNuevo As New Button With {.Text = "Nuevo", .Location = New Point(20, 430), .Size = New Size(150, 40)}
        AddHandler btnNuevo.Click, AddressOf btnNuevo_Click
        Me.Controls.Add(btnNuevo)

        Dim btnEditar As New Button With {.Text = "Editar", .Location = New Point(180, 430), .Size = New Size(150, 40)}
        AddHandler btnEditar.Click, AddressOf btnEditar_Click
        Me.Controls.Add(btnEditar)

        Dim btnBorrar As New Button With {.Text = "Borrar", .Location = New Point(340, 430), .Size = New Size(150, 40)}
        AddHandler btnBorrar.Click, AddressOf btnBorrar_Click
        Me.Controls.Add(btnBorrar)

        Dim btnRegresar As New Button With {.Text = "Regresar", .Location = New Point(500, 430), .Size = New Size(150, 40)}
        AddHandler btnRegresar.Click, Sub() Me.Close()
        Me.Controls.Add(btnRegresar)
    End Sub

    Private Sub CargarUsuarios()
        Try
            Using conn = Conexion.Conectar()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT id_paciente, curp, nombre, apellido, fecha_nacimiento, sexo, derechohabiencia FROM Pacientes"

                Using cmd As New SqlCommand(query, conn)
                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvUsuarios.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
        Dim frm As New FrmNuevoUsuario()
        frm.ShowDialog()
        CargarUsuarios()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs)
        If dgvUsuarios.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Globales.IdUsuarioSeleccionado = CInt(dgvUsuarios.SelectedRows(0).Cells("id_paciente").Value)

        Dim frm As New FrmNuevoUsuario()
        frm.ShowDialog()
        CargarUsuarios()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs)
        If dgvUsuarios.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim respuesta As DialogResult = MessageBox.Show("¿Desea borrar este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = DialogResult.No Then Return

        Dim id As Integer = CInt(dgvUsuarios.SelectedRows(0).Cells("id_paciente").Value)

        Try
            Using conn = Conexion.Conectar()
                If conn Is Nothing Then Return

                Dim query As String = "DELETE FROM Pacientes WHERE id_paciente = @id"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Borrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CargarUsuarios()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al borrar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class