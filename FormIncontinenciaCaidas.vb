Public Class FormIncontinenciaCaidas
    Inherits System.Windows.Forms.Form

    Private lblPuntaje As Label
    Private lblClasificacion As Label
    Private txtComentarios As TextBox

    Private rbQ1_SI As RadioButton, rbQ1_NO As RadioButton
    Private rbQ2_SI As RadioButton, rbQ2_NO As RadioButton
    Private rbQ3_SI As RadioButton, rbQ3_NO As RadioButton
    Private rbQ4_SI As RadioButton, rbQ4_NO As RadioButton

    Private rbCaida_SI As RadioButton, rbCaida_NO As RadioButton

    Private Sub FormIncontinenciaCaidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Cuestionario para la Detección de Incontinencia Urinaria y Síndrome de Caídas"
        Me.Size = New Size(750, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.WhiteSmoke

        Dim y As Integer = 20

        Dim lblTitulo As New Label With {.Text = "CUESTIONARIO PARA LA DETECCIÓN DE INCONTINENCIA URINARIA Y SÍNDROME DE CAÍDAS", .Location = New Point(20, y), .Font = New Font("Arial", 14, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblTitulo)
        y += 40

        Dim lblIncont As New Label With {.Text = "INCONTINENCIA URINARIA", .Location = New Point(20, y), .Font = New Font("Arial", 12, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblIncont)
        y += 30

        AgregarPregunta(1, "¿Padece usted orina cuando no lo desea?", y, rbQ1_SI, rbQ1_NO)
        y += 60

        AgregarPregunta(2, "¿Usa usted algún protector, toalla o paño para evitar que se moje la ropa interior?", y, rbQ2_SI, rbQ2_NO)
        y += 60

        AgregarPregunta(3, "¿Tiene usted problemas con su vejiga, se moja sin querer?", y, rbQ3_SI, rbQ3_NO)
        y += 60

        AgregarPregunta(4, "¿Acude a un orinar al baño, con mayor frecuencia que la normal?", y, rbQ4_SI, rbQ4_NO)
        y += 60

        Dim lblCaida As New Label With {.Text = "SÍNDROME DE CAÍDAS", .Location = New Point(20, y), .Font = New Font("Arial", 12, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblCaida)
        y += 30

        AgregarPregunta(1, "¿Ha presentado 2 o más caídas en el último año?", y, rbCaida_SI, rbCaida_NO)
        y += 60

        lblPuntaje = New Label With {.Text = "Puntaje total: 0", .Location = New Point(20, y), .Font = New Font("Arial", 12, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblPuntaje)
        y += 40

        lblClasificacion = New Label With {.Text = "Clasificación: ", .Location = New Point(20, y), .Font = New Font("Arial", 12, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblClasificacion)
        y += 50

        Dim lblComentarios As New Label With {.Text = "Comentarios / Observaciones:", .Location = New Point(20, y), .AutoSize = True}
        Me.Controls.Add(lblComentarios)
        y += 25

        txtComentarios = New TextBox With {.Multiline = True, .ScrollBars = ScrollBars.Vertical, .Size = New Size(650, 100), .Location = New Point(20, y)}
        Me.Controls.Add(txtComentarios)
        y += 120

        Dim btnCalcular As New Button With {.Text = "Calcular", .Location = New Point(20, y), .Size = New Size(200, 50)}
        AddHandler btnCalcular.Click, AddressOf btnCalcular_Click
        Me.Controls.Add(btnCalcular)

        Dim btnGuardar As New Button With {.Text = "Guardar", .Location = New Point(230, y), .Size = New Size(200, 50)}
        AddHandler btnGuardar.Click, AddressOf btnGuardar_Click
        Me.Controls.Add(btnGuardar)

        Dim btnRegresar As New Button With {.Text = "Regresar", .Location = New Point(440, y), .Size = New Size(200, 50)}
        AddHandler btnRegresar.Click, Sub() Me.Close()
        Me.Controls.Add(btnRegresar)
    End Sub

    Private Sub AgregarPregunta(num As Integer, texto As String, y As Integer, ByRef rbSI As RadioButton, ByRef rbNO As RadioButton)
        Dim lbl As New Label With {.Text = num & ". " & texto, .Location = New Point(20, y), .AutoSize = True}
        Me.Controls.Add(lbl)

        rbSI = New RadioButton With {.Text = "SI", .Location = New Point(20, y + 25)}
        rbNO = New RadioButton With {.Text = "NO", .Location = New Point(80, y + 25), .Checked = True}
        Me.Controls.Add(rbSI)
        Me.Controls.Add(rbNO)
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs)
        Dim puntajeIncont As Integer = 0
        If rbQ1_SI.Checked Then puntajeIncont += 1
        If rbQ2_SI.Checked Then puntajeIncont += 1
        If rbQ3_SI.Checked Then puntajeIncont += 1
        If rbQ4_SI.Checked Then puntajeIncont += 1

        Dim clasifIncont As String = If(puntajeIncont >= 1, "Positivo", "Negativo")

        Dim clasifCaida As String = If(rbCaida_SI.Checked, "Positivo", "Negativo")

        lblPuntaje.Text = "Puntaje Incontinencia: " & puntajeIncont

        lblClasificacion.Text = "Clasificación Incontinencia: " & clasifIncont & vbCrLf & "Clasificación Caídas: " & clasifCaida
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Guardar en SQL (por implementar).", "Info")
    End Sub
End Class