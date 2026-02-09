Public Class FormIQCODE
    Inherits System.Windows.Forms.Form

    Private lblMedia As Label
    Private lblClasificacion As Label
    Private txtComentarios As TextBox

    Private rbPreguntas(15)() As RadioButton   ' Corrección: solo esta declaración

    Private Sub FormIQCODE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Cuestionario del Informante sobre Deterioro Cognoscitivo en el Anciano (IQCODE)"
        Me.Size = New Size(900, 900)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.WhiteSmoke

        Dim y As Integer = 20

        Dim lblTitulo As New Label With {
            .Text = "CUESTIONARIO DEL INFORMANTE SOBRE DETERIORO COGNOSCITIVO EN EL ANCIANO (IQCODE)",
            .Location = New Point(20, y),
            .Font = New Font("Arial", 14, FontStyle.Bold),
            .AutoSize = True
        }
        Me.Controls.Add(lblTitulo)
        y += 50

        Dim lblInstrucciones As New Label With {
            .Text = "Compare el rendimiento actual con hace 10 años. Marque la opción correspondiente.",
            .Location = New Point(20, y),
            .AutoSize = True
        }
        Me.Controls.Add(lblInstrucciones)
        y += 40

        Dim opciones() As String = {"Mucho mejor", "Un poco mejor", "Sin cambio", "Un poco peor", "Mucho peor"}

        For i As Integer = 0 To 15
            Dim lbl As New Label With {
                .Text = (i + 1) & ". Recuerda cosas relacionadas con...",
                .Location = New Point(20, y),
                .AutoSize = True,
                .Width = 600
            }
            Me.Controls.Add(lbl)
            y += 30

            rbPreguntas(i) = New RadioButton(5) {}
            For j As Integer = 0 To 4
                rbPreguntas(i)(j) = New RadioButton With {
                    .Text = opciones(j),
                    .Location = New Point(20 + j * 150, y),
                    .Checked = (j = 2)  ' Por defecto "Sin cambio"
                }
                Me.Controls.Add(rbPreguntas(i)(j))
            Next
            y += 40
        Next

        lblMedia = New Label With {
            .Text = "Media total: 3.0",
            .Location = New Point(20, y),
            .Font = New Font("Arial", 12, FontStyle.Bold),
            .AutoSize = True
        }
        Me.Controls.Add(lblMedia)
        y += 40

        lblClasificacion = New Label With {
            .Text = "Clasificación: ",
            .Location = New Point(20, y),
            .Font = New Font("Arial", 12, FontStyle.Bold),
            .AutoSize = True
        }
        Me.Controls.Add(lblClasificacion)
        y += 50

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
            .Size = New Size(800, 100),
            .Location = New Point(20, y)
        }
        Me.Controls.Add(txtComentarios)
        y += 120

        Dim btnCalcular As New Button With {
            .Text = "Calcular",
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

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs)
        Dim suma As Double = 0
        Dim conteo As Integer = 0

        For i As Integer = 0 To 15
            For j As Integer = 0 To 4
                If rbPreguntas(i)(j).Checked Then
                    suma += (j + 1)  ' 1 = Mucho mejor, 5 = Mucho peor
                    conteo += 1
                End If
            Next
        Next

        Dim media As Double = If(conteo > 0, suma / conteo, 3.0)

        lblMedia.Text = "Media total: " & media.ToString("F2")

        Dim clasif As String = If(media >= 3.5, "Probable deterioro cognitivo", "Sin deterioro significativo")
        lblClasificacion.Text = "Clasificación: " & clasif
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Guardar en SQL (por implementar).", "Info")
    End Sub
End Class