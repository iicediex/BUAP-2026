Imports Microsoft.Data.SqlClient

Public Class FrmAdminGerontologos
    Inherits System.Windows.Forms.Form

    Private dgvGerontologos As DataGridView

    Private Sub FrmAdminGerontologos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Administrar Gerontólogos - BUAP"
        Me.Size = New Size(900, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.BackColor = Color.WhiteSmoke

        dgvGerontologos = New DataGridView With {.Location = New Point(20, 20), .Size = New Size(850, 400), .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, .ReadOnly = True}
        Me.Controls.Add(dgvGerontologos)

        CargarGerontologos()

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

    Private Sub CargarGerontologos()
        Try
            Using conn = Conexion.Conectar()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT id_gerontologo, nombre, apellido, usuario, rol FROM Gerontologos"

                Using cmd As New SqlCommand(query, conn)
                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvGerontologos.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
        Globales.IdGerontologo = 0
        Dim frm As New FrmNuevoGerontologo()
        frm.ShowDialog()
        CargarGerontologos()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs)
        If dgvGerontologos.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un gerontólogo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Globales.IdGerontologo = CInt(dgvGerontologos.SelectedRows(0).Cells("id_gerontologo").Value)

        Dim frm As New FrmNuevoGerontologo()
        frm.ShowDialog()
        CargarGerontologos()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs)
        If dgvGerontologos.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un gerontólogo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim respuesta As DialogResult = MessageBox.Show("¿Desea borrar este gerontólogo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = DialogResult.No Then Return

        Dim id As Integer = CInt(dgvGerontologos.SelectedRows(0).Cells("id_gerontologo").Value)

        Try
            Using conn = Conexion.Conectar()
                If conn Is Nothing Then Return

                Dim query As String = "DELETE FROM Gerontologos WHERE id_gerontologo = @id"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Borrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CargarGerontologos()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al borrar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class