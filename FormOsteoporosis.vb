Public Class FormOsteoporosis
    Inherits System.Windows.Forms.Form

    Private lblPuntaje As Label
    Private lblClasificacion As Label
    Private txtComentarios As TextBox

    Private chkPreguntas(8) As CheckBox
    Private dgvRiesgo As DataGridView

    Private Sub FormOsteoporosis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Cuestionario para la Detección de Riesgo de Fracturas por Osteoporosis"
        Me.Size = New Size(1000, 900)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.WhiteSmoke

        Dim y As Integer = 20

        Dim lblTitulo As New Label With {
            .Text = "CUESTIONARIO PARA LA DETECCIÓN DE FRACTURAS POR OSTEOPOROSIS",
            .Location = New Point(20, y),
            .Font = New Font("Arial", 14, FontStyle.Bold),
            .AutoSize = True
        }
        Me.Controls.Add(lblTitulo)
        y += 50

        Dim lblInstrucciones As New Label With {
            .Text = "Marque con X las respuestas afirmativas (SI).",
            .Location = New Point(20, y),
            .AutoSize = True
        }
        Me.Controls.Add(lblInstrucciones)
        y += 40

        Dim preguntas() As String = {
            "1. ¿Ha tenido una fractura previa en los últimos dos años? (fractura de vértebras, de fémur o cadera sin trauma severo)",
            "2. Antecedente: ¿Alguno de sus padres ha tenido fractura de cadera?",
            "3. ¿Fuma actualmente?",
            "4. ¿Utiliza glucocorticoides o los ha tomado por más de 3 meses? (Dosis mayor a 7.5 mg/día)",
            "5. ¿Le han diagnosticado artritis reumatoide? (excepto osteoartritis)",
            "6. ¿Le han diagnosticado Diabetes Mellitus tipo 2?",
            "7. ¿Ha tenido dos o más caídas en los últimos 12 meses?",
            "8. ¿Presenta osteoporosis imperfecta secundaria, hipotiroidismo no tratado, padeciente de largos tiempos?",
            "9. ¿Toma 3 o más copas de alcohol de 40 ml de bebidas alcohólicas diarias?"
        }

        For i As Integer = 0 To 8
            Dim lbl As New Label With {
                .Text = preguntas(i),
                .Location = New Point(20, y),
                .AutoSize = True,
                .Width = 700
            }
            Me.Controls.Add(lbl)

            chkPreguntas(i) = New CheckBox With {
                .Text = "SI",
                .Location = New Point(750, y)
            }
            Me.Controls.Add(chkPreguntas(i))
            y += 40
        Next

        lblPuntaje = New Label With {
            .Text = "Puntaje total: 0",
            .Location = New Point(20, y),
            .Font = New Font("Arial", 12, FontStyle.Bold),
            .AutoSize = True
        }
        Me.Controls.Add(lblPuntaje)
        y += 40

        lblClasificacion = New Label With {
            .Text = "Clasificación de Riesgo: ",
            .Location = New Point(20, y),
            .Font = New Font("Arial", 12, FontStyle.Bold),
            .AutoSize = True
        }
        Me.Controls.Add(lblClasificacion)
        y += 50

        Dim lblTabla As New Label With {
            .Text = "Tabla de Riesgo según Edad e IMC (ejemplo visual):",
            .Location = New Point(20, y),
            .AutoSize = True
        }
        Me.Controls.Add(lblTabla)
        y += 30

        dgvRiesgo = New DataGridView With {
            .Location = New Point(20, y),
            .Size = New Size(950, 300),
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            .ReadOnly = True
        }
        Me.Controls.Add(dgvRiesgo)

        CargarTablaRiesgo()
        y += 320

        Dim lblComentarios As New Label With {
            .Text = "Comentarios / Observaciones:",
            .Location = New Point(20, y),
            .AutoSize = True
        }
        Me.Controls.Add(lblComentarios)
        y += 25

        txtComentarios = New TextBox With {
            .Multiline = True,
            .ScrollBars = ScrollBars.Vertical,
            .Size = New Size(900, 100),
            .Location = New Point(20, y)
        }
        Me.Controls.Add(txtComentarios)
        y += 120

        Dim btnCalcular As New Button With {
            .Text = "Calcular Riesgo",
            .Location = New Point(20, y),
            .Size = New Size(200, 50)
        }
        AddHandler btnCalcular.Click, AddressOf btnCalcular_Click
        Me.Controls.Add(btnCalcular)

        Dim btnGuardar As New Button With {
            .Text = "Guardar",
            .Location = New Point(240, y),
            .Size = New Size(200, 50)
        }
        AddHandler btnGuardar.Click, AddressOf btnGuardar_Click
        Me.Controls.Add(btnGuardar)

        Dim btnRegresar As New Button With {
            .Text = "Regresar",
            .Location = New Point(460, y),
            .Size = New Size(200, 50)
        }
        AddHandler btnRegresar.Click, Sub() Me.Close()
        Me.Controls.Add(btnRegresar)
    End Sub

    Private Sub CargarTablaRiesgo()
        dgvRiesgo.Columns.Add("Edad", "Edad")
        dgvRiesgo.Columns.Add("IMC15-19", "IMC 15-19")
        dgvRiesgo.Columns.Add("IMC20-24", "IMC 20-24")
        dgvRiesgo.Columns.Add("IMC25-29", "IMC 25-29")
        dgvRiesgo.Columns.Add("IMC30-34", "IMC 30-34")
        dgvRiesgo.Columns.Add("IMC35-39", "IMC 35-39")
        dgvRiesgo.Columns.Add("IMC40-44", "IMC 40-44")
        dgvRiesgo.Columns.Add("IMC45+", "IMC 45+")

        dgvRiesgo.Rows.Add("50-54", "B.R.", "M", "H", "M.R.", "A.R.", "M", "H", "M")
        dgvRiesgo.Rows.Add("55-59", "B.R.", "M", "H", "M.R.", "A.R.", "M", "H", "M")
        dgvRiesgo.Rows.Add("60-64", "B.R.", "M", "H", "M.R.", "A.R.", "M", "H", "M")
        dgvRiesgo.Rows.Add("65-69", "B.R.", "M", "H", "M.R.", "A.R.", "M", "H", "M")
        dgvRiesgo.Rows.Add("70-74", "B.R.", "M", "H", "M.R.", "A.R.", "M", "H", "M")
        dgvRiesgo.Rows.Add("75-79", "B.R.", "M", "H", "M.R.", "A.R.", "M", "H", "M")
        dgvRiesgo.Rows.Add("80-84", "B.R.", "M", "H", "M.R.", "A.R.", "M", "H", "M")
        dgvRiesgo.Rows.Add("85-89", "B.R.", "M", "H", "M.R.", "A.R.", "M", "H", "M")
        dgvRiesgo.Rows.Add("90+", "B.R.", "M", "H", "M.R.", "A.R.", "M", "H", "M")
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs)
        Dim puntaje As Integer = 0

        For i As Integer = 0 To 8
            If chkPreguntas(i).Checked Then puntaje += 1
        Next

        lblPuntaje.Text = "Puntaje total: " & puntaje

        Dim clasif As String = ""
        If puntaje <= 2 Then
            clasif = "Bajo Riesgo (B.R.)"
        ElseIf puntaje <= 6 Then
            clasif = "Mediano Riesgo (M.R.)"
        Else clasif = "Alto Riesgo (A.R.)"
        End If
        lblClasificacion.Text = "Clasificación de Riesgo: " & clasif
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Guardar en SQL (por implementar).", "Info")
    End Sub
End Class