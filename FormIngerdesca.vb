Public Class FormIngerdesca
    Inherits System.Windows.Forms.Form

    Private chkPreguntas(19) As CheckBox  ' 0 = SI (negativo = requiere intervención), 1 = NO (positivo)
    Private lblResultado As Label
    Private txtComentarios As TextBox

    Private Sub FormIngerdesca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "INGERDESCA - Investigación Gerontológica del Riesgo para Caídas"
        Me.Size = New Size(900, 900)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.WhiteSmoke

        Dim y As Integer = 20

        Dim lblTitulo As New Label With {.Text = "INVESTIGACIÓN GERONTOLÓGICA DEL RIESGO PARA EL DESARROLLO DEL SÍNDROME DE CAÍDAS (INGERDESCA)", .Location = New Point(20, y), .Font = New Font("Arial", 14, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblTitulo)
        y += 50

        Dim lblInstrucciones As New Label With {.Text = "Marque con X la respuesta. Cada respuesta NO requiere intervención.", .Location = New Point(20, y), .AutoSize = True}
        Me.Controls.Add(lblInstrucciones)
        y += 40

        Dim preguntas() As String = {
            "Los pisos y tapetes están en buenas condiciones, sin roturas o tropiezos",
            "Están fijos los bordes de las alfombras por donde transita la persona adulta mayor",
            "Hay desorden en los bordes de las alfombras",
            "La luz es adecuada",
            "Las luces de noche están colocadas estratégicamente en lugares peligrosos",
            "Las camas, sillas y sofás tienen la altura suficiente para permitir que la persona adulta mayor se siente y levante",
            "Los cables están localizados de tal forma que no tengan que apresurarse en pasos",
            "Para limpiar el baño se usa un adhesivo antideslizante",
            "Los tapetes tienen una superficie antiderrapante para evitar resbalar",
            "Los derrames se limpian pronto para evitar resbalar con ellos",
            "Los utensilios usados son seguros",
            "Las sillas y mesas están firmes y seguras",
            "Hay desorden en los pasillos",
            "Los cables del teléfono y de otros aparatos están apartados del camino",
            "Se mantienen apartados los cables del pasillo",
            "¿Cuántos escalones tiene la escalera?",
            "¿Tiene tapetes antideslizantes en la escalera?",
            "¿Tiene barandal en la escalera?",
            "¿El calzado es adecuado y no resbala?"
        }

        For i As Integer = 0 To preguntas.Length - 1
            Dim lbl As New Label With {.Text = (i + 1) & ". " & preguntas(i), .Location = New Point(20, y), .AutoSize = True, .Width = 600}
            Me.Controls.Add(lbl)

            chkPreguntas(i) = New CheckBox With {.Text = "SI", .Location = New Point(650, y), .Checked = True}
            Me.Controls.Add(chkPreguntas(i))
            y += 35
        Next

        lblResultado = New Label With {.Text = "Resultado: Todas las respuestas SI = Bajo riesgo", .Location = New Point(20, y), .Font = New Font("Arial", 12, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblResultado)
        y += 50

        Dim lblComentarios As New Label With {.Text = "Comentarios / Intervenciones necesarias:", .Location = New Point(20, y), .AutoSize = True}
        Me.Controls.Add(lblComentarios)
        y += 25

        txtComentarios = New TextBox With {.Multiline = True, .ScrollBars = ScrollBars.Vertical, .Size = New Size(800, 120), .Location = New Point(20, y)}
        Me.Controls.Add(txtComentarios)
        y += 140

        Dim btnCalcular As New Button With {.Text = "Evaluar Riesgo", .Location = New Point(20, y), .Size = New Size(200, 50)}
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
        Dim negativas As Integer = 0

        For i As Integer = 0 To chkPreguntas.Length - 1
            If Not chkPreguntas(i).Checked Then  ' NO marcado = respuesta NO = requiere intervención
                negativas += 1
            End If
        Next

        Dim resultado As String = ""
        If negativas = 0 Then
            resultado = "Bajo riesgo - Todas las respuestas SI"
        Else
            resultado = "Riesgo detectado: " & negativas & " respuestas NO (requieren intervención)"
        End If

        lblResultado.Text = "Resultado: " & resultado

        ' Puedes mostrar en txtComentarios las preguntas negativas
        Dim comentario As String = "Intervenciones necesarias:" & vbCrLf
        For i As Integer = 0 To chkPreguntas.Length - 1
            If Not chkPreguntas(i).Checked Then
                comentario &= "- Pregunta " & (i + 1) & ": Revisar y corregir" & vbCrLf
            End If
        Next
        txtComentarios.Text = comentario
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Guardar en SQL (por implementar).", "Info")
    End Sub
End Class