Public Class FormDemencia
    Inherits System.Windows.Forms.Form

    Private lblPuntaje As Label
    Private lblClasificacion As Label
    Private txtComentarios As TextBox

    Private chkPreguntas(11) As CheckBox

    Private Sub FormDemencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Factores de Riesgo para el Desarrollo de Demencia"
        Me.Size = New Size(800, 800)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.WhiteSmoke

        Dim y As Integer = 20

        Dim lblTitulo As New Label With {.Text = "FACTORES DE RIESGO PARA EL DESARROLLO DE DEMENCIA", .Location = New Point(20, y), .Font = New Font("Arial", 14, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblTitulo)
        y += 50

        Dim lblInstrucciones As New Label With {.Text = "Marque con X las respuestas afirmativas.", .Location = New Point(20, y), .AutoSize = True}
        Me.Controls.Add(lblInstrucciones)
        y += 40

        Dim preguntas() As String = {
            "1. ¿Tiene usted 65 años o menos?",
            "2. ¿Cuántos años escolares tiene?",
            "3. Sexo: Hombre",
            "4. ¿Presión arterial sistólica >140 mmHg?",
            "5. ¿IMC <30 kg/m²?",
            "6. ¿>30 kg/m² total de referencia verbal?",
            "7. ¿Realiza actividad física?",
            "8. ¿Vive solo?",
            "9. ¿Fuma actualmente?",
            "10. ¿Tiene dificultades para escuchar?",
            "11. ¿Tiene problemas de memoria?",
            "12. ¿Tiene diabetes mellitus tipo 2?"
        }

        For i As Integer = 0 To 11
            Dim lbl As New Label With {.Text = preguntas(i), .Location = New Point(20, y), .AutoSize = True, .Width = 600}
            Me.Controls.Add(lbl)

            chkPreguntas(i) = New CheckBox With {.Text = "SI", .Location = New Point(650, y)}
            Me.Controls.Add(chkPreguntas(i))
            y += 35
        Next

        lblPuntaje = New Label With {.Text = "Puntaje total: 0", .Location = New Point(20, y), .Font = New Font("Arial", 12, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblPuntaje)
        y += 40

        lblClasificacion = New Label With {.Text = "Clasificación de Riesgo: ", .Location = New Point(20, y), .Font = New Font("Arial", 12, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblClasificacion)
        y += 50

        Dim lblComentarios As New Label With {.Text = "Comentarios / Observaciones:", .Location = New Point(20, y), .AutoSize = True}
        Me.Controls.Add(lblComentarios)
        y += 25

        txtComentarios = New TextBox With {.Multiline = True, .ScrollBars = ScrollBars.Vertical, .Size = New Size(700, 100), .Location = New Point(20, y)}
        Me.Controls.Add(txtComentarios)
        y += 120

        Dim btnCalcular As New Button With {.Text = "Calcular Riesgo", .Location = New Point(20, y), .Size = New Size(200, 50)}
        AddHandler btnCalcular.Click, AddressOf btnCalcular_Click
        Me.Controls.Add(btnCalcular)

        Dim btnGuardar As New Button With {.Text = "Guardar", .Location = New Point(240, y), .Size = New Size(200, 50)}
        AddHandler btnGuardar.Click, AddressOf btnGuardar_Click
        Me.Controls.Add(btnGuardar)

        Dim btnRegresar As New Button With {.Text = "Regresar", .Location = New Point(460, y), .Size = New Size(200, 50)}
        AddHandler btnRegresar.Click, Sub() Me.Close()
        Me.Controls.Add(btnRegresar)
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs)
        Dim puntaje As Integer = 0

        For i As Integer = 0 To 11
            If chkPreguntas(i).Checked Then puntaje += 1
        Next

        lblPuntaje.Text = "Puntaje total: " & puntaje

        Dim clasif As String = ""
        If puntaje <= 7 Then
            clasif = "Bajo Riesgo"
        ElseIf puntaje <= 11 Then
            clasif = "Mediano Riesgo"
        Else clasif = "Alto Riesgo"
        End If
        lblClasificacion.Text = "Clasificación: " & clasif
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Guardar en SQL (por implementar).", "Info")
    End Sub
End Class