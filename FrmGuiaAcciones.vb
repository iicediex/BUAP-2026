Public Class FrmGuiaAcciones
    Inherits System.Windows.Forms.Form

    Private dgvGuia As DataGridView

    Private Sub FrmGuiaAcciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Guía de Acciones / Tamizajes - BUAP 2025"
        Me.Size = New Size(1100, 700)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.BackColor = Color.WhiteSmoke

        dgvGuia = New DataGridView With {
            .Location = New Point(20, 20),
            .Size = New Size(1050, 550),
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            .ReadOnly = True,
            .AllowUserToAddRows = False
        }
        Me.Controls.Add(dgvGuia)

        CargarGuia()

        Dim btnRegresar As New Button With {
            .Text = "Regresar",
            .Location = New Point(20, 600),
            .Size = New Size(150, 40)
        }
        AddHandler btnRegresar.Click, Sub() Me.Close()
        Me.Controls.Add(btnRegresar)
    End Sub

    Private Sub CargarGuia()
        Dim dt As New DataTable()
        dt.Columns.Add("Tamizaje", GetType(String))
        dt.Columns.Add("Pregunta", GetType(String))
        dt.Columns.Add("SI", GetType(String))
        dt.Columns.Add("NO", GetType(String))
        dt.Columns.Add("Acción", GetType(String))

        ' Datos de tu tabla pegada (2025)
        dt.Rows.Add("DEPRESIÓN / SINTOMATOLOGÍA DEPRESIVA", "¿Se siente triste frecuentemente o deprimido?", "SI", "NO", "Si SI → Detección / Positivo → Escala GDS-5")
        dt.Rows.Add("ALTERACIONES DE MEMORIA", "En los últimos seis meses, ¿se le olvidan cosas?", "SI", "NO", "Si SI → Mini-Mental")
        dt.Rows.Add("INCONTINENCIA URINARIA", "¿Ha tenido fuga de orina cuando no lo desea?", "SI", "NO", "Si SI → Detección Positiva → Guía Incontinencia")
        dt.Rows.Add("FACTORES DE RIESGO CAÍDAS", "¿Ha presentado 2 o más caídas en el último año?", "SI", "NO", "Si SI → Investigación Ingerdesca")
        dt.Rows.Add("ACTIVIDADES BÁSICAS", "Requiere ayuda para bañarse o vestirse?", "SI", "NO", "Calificar Katz → 0 Independiente → 6 Severo")
        dt.Rows.Add("ACTIVIDADES INSTRUMENTALES", "¿Utiliza el teléfono sin ayuda?", "SI", "NO", "Calificar Lawton → 8 Independiente → 0 Dependiente")
        dt.Rows.Add("OSTEOPOROSIS", "¿Ha tenido fractura previa?", "SI", "NO", "Calcular riesgo con tabla IMC/edad")
        dt.Rows.Add("DEMENCIA", "¿Tiene problemas de memoria?", "SI", "NO", "Calcular factores de riesgo → Bajo/Medio/Alto")

        dgvGuia.DataSource = dt
    End Sub
End Class