Public Class FormGDS5
    Inherits System.Windows.Forms.Form

    Private lblPuntaje As Label
    Private lblClasificacion As Label
    Private txtComentarios As TextBox

    Private rbQ1_SI As RadioButton, rbQ1_NO As RadioButton
    Private rbQ2_SI As RadioButton, rbQ2_NO As RadioButton
    Private rbQ3_SI As RadioButton, rbQ3_NO As RadioButton
    Private rbQ4_SI As RadioButton, rbQ4_NO As RadioButton
    Private rbQ5_SI As RadioButton, rbQ5_NO As RadioButton

    Private Sub FormGDS5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "GDS-5 - Depresión Geriátrica Simplificada (2025)"
        Me.Size = New Size(750, 750)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.WhiteSmoke

        Dim y As Integer = 20

        Dim lblTitulo As New Label With {.Text = "GDS-5 (5 Preguntas)", .Location = New Point(20, y), .Font = New Font("Arial", 14, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblTitulo)
        y += 40

        Dim lblInstrucciones As New Label With {.Text = "Responda según cómo se ha sentido en el último mes.", .Location = New Point(20, y), .AutoSize = True}
        Me.Controls.Add(lblInstrucciones)
        y += 40

        AgregarPregunta(1, "¿Está usted, básicamente satisfecho con su vida?", y, rbQ1_SI, rbQ1_NO)
        y += 60

        AgregarPregunta(2, "¿Siente su vida vacía?", y, rbQ2_SI, rbQ2_NO)
        y += 60

        AgregarPregunta(3, "¿Se siente aburrido frecuentemente?", y, rbQ3_SI, rbQ3_NO)
        y += 60

        AgregarPregunta(4, "¿Está usted preocupado o teme que algo malo le va a pasar?", y, rbQ4_SI, rbQ4_NO)
        y += 60

        AgregarPregunta(5, "¿Cree usted que las otras personas están mejor que usted en general?", y, rbQ5_SI, rbQ5_NO)
        y += 80

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

        Dim btnRegresar As New Button With {.Text = "Regresar", .Location = New Point(250, y), .Size = New Size(200, 50)}
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
        Dim puntaje As Integer = 0

        If rbQ1_NO.Checked Then puntaje += 1
        If rbQ2_SI.Checked Then puntaje += 1
        If rbQ3_SI.Checked Then puntaje += 1
        If rbQ4_SI.Checked Then puntaje += 1
        If rbQ5_SI.Checked Then puntaje += 1

        lblPuntaje.Text = "Puntaje total: " & puntaje

        Dim clasif As String = ""
        Select Case puntaje
            Case 0 : clasif = "0 - Sin depresión"
            Case 1 To 2 : clasif = "1-2 - Depresión leve"
            Case 3 To 4 : clasif = "3-4 - Depresión moderada"
            Case 5 : clasif = "5 - Depresión severa"
        End Select

        lblClasificacion.Text = "Clasificación: " & clasif & " (Línea de corte: 5)"
    End Sub
End Class