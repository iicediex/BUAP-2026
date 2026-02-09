Imports Microsoft.Data.SqlClient

Public Class FrmObservaciones
    Inherits System.Windows.Forms.Form

    Private dgvObservaciones As DataGridView

    Private Sub FrmObservaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Observaciones - BUAP"
        Me.Size = New Size(900, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.BackColor = Color.WhiteSmoke

        dgvObservaciones = New DataGridView With {.Location = New Point(20, 20), .Size = New Size(850, 400), .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, .ReadOnly = True}
        Me.Controls.Add(dgvObservaciones)

        CargarObservaciones()

        Dim btnNueva As New Button With {.Text = "Nueva Observación", .Location = New Point(20, 430), .Size = New Size(150, 40)}
        AddHandler btnNueva.Click, AddressOf btnNueva_Click
        Me.Controls.Add(btnNueva)

        Dim btnRegresar As New Button With {.Text = "Regresar", .Location = New Point(200, 430), .Size = New Size(150, 40)}
        AddHandler btnRegresar.Click, Sub() Me.Close()
        Me.Controls.Add(btnRegresar)
    End Sub

    Private Sub CargarObservaciones()
        Try
            Using conn = Conexion.Conectar()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT id_observacion, id_paciente, fecha, observacion FROM Observaciones"

                Using cmd As New SqlCommand(query, conn)
                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvObservaciones.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNueva_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Form para nueva observación (por implementar).", "Info")
    End Sub
End Class