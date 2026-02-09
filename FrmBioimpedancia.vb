Imports Microsoft.Data.SqlClient

Public Class FrmBioimpedancia
    Inherits System.Windows.Forms.Form

    Private dgvBio As DataGridView

    Private Sub FrmBioimpedancia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Bioimpedancia - BUAP"
        Me.Size = New Size(900, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.BackColor = Color.WhiteSmoke

        dgvBio = New DataGridView With {.Location = New Point(20, 20), .Size = New Size(850, 400), .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, .ReadOnly = True}
        Me.Controls.Add(dgvBio)

        CargarBioimpedancia()

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

    Private Sub CargarBioimpedancia()
        Try
            Using conn = Conexion.Conectar()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT id_bioimpedancia, id_paciente, fecha_medicion, peso_kg, talla_m, imc FROM Bioimpedancia"

                Using cmd As New SqlCommand(query, conn)
                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvBio.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Form para nueva bioimpedancia (por implementar).", "Info")
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Modo edición (por implementar).", "Info")
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Borrar bioimpedancia (por implementar).", "Info")
    End Sub
End Class