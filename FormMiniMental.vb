Public Class FormMiniMental
    Inherits System.Windows.Forms.Form

    Private lblPuntaje As Label
    Private lblClasificacion As Label
    Private txtComentarios As TextBox

    Private picPentagonos As PictureBox

    Private Sub FormMiniMental_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Mini-Examen del Estado Mental (MMSE)"
        Me.Size = New Size(750, 1000)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.WhiteSmoke

        Dim y As Integer = 20

        Dim lblTitulo As New Label With {.Text = "MINI-EXAMEN DEL ESTADO MENTAL", .Location = New Point(20, y), .Font = New Font("Arial", 14, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblTitulo)
        y += 40

        ' Orientación (simplificado, puedes agregar más campos)
        Dim lblOrientacion As New Label With {.Text = "Orientación (10 puntos)", .Location = New Point(20, y), .Font = New Font("Arial", 12, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblOrientacion)
        y += 30

        ' ... Agrega TextBox para preguntas de tiempo y lugar si quieres

        ' Dibujo pentágonos
        Dim lblDibujo As New Label With {.Text = "Copie este dibujo de dos pentágonos intersectados:", .Location = New Point(20, y), .AutoSize = True}
        Me.Controls.Add(lblDibujo)
        y += 30

        picPentagonos = New PictureBox With {.Location = New Point(20, y), .Size = New Size(300, 300), .BorderStyle = BorderStyle.FixedSingle}
        Me.Controls.Add(picPentagonos)

        DibujarPentagonos()

        y += 320

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

        Dim btnRegresar As New Button With {.Text = "Regresar", .Location = New Point(230, y), .Size = New Size(200, 50)}
        AddHandler btnRegresar.Click, Sub() Me.Close()
        Me.Controls.Add(btnRegresar)
    End Sub

    Private Sub DibujarPentagonos()
        picPentagonos.Image = New Bitmap(picPentagonos.Width, picPentagonos.Height)
        Using g As Graphics = Graphics.FromImage(picPentagonos.Image)
            g.Clear(Color.White)
            Dim pen As New Pen(Color.Black, 3)

            ' Pentágono 1
            Dim points1() As Point = {
                New Point(50, 50),
                New Point(150, 10),
                New Point(250, 50),
                New Point(200, 150),
                New Point(100, 150)
            }
            g.DrawPolygon(pen, points1)

            ' Pentágono 2 intersectado
            Dim points2() As Point = {
                New Point(150, 100),
                New Point(250, 60),
                New Point(350, 100),
                New Point(300, 200),
                New Point(200, 200)
            }
            g.DrawPolygon(pen, points2)
        End Using
        picPentagonos.Refresh()
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs)


        lblPuntaje.Text = "Puntaje total: " & puntaje

        Dim clasif As String = ""
        If puntaje >= 24 Then
            clasif = "Sin deterioro cognitivo"
        ElseIf puntaje >= 19 Then
            clasif = "Deterioro leve"
        ElseIf puntaje >= 10 Then
            clasif = "Deterioro moderado"
        Else
            clasif = "Deterioro grave"
        End If

        lblClasificacion.Text = "Clasificación: " & clasif
    End Sub

    Private Function puntaje() As String
        Throw New NotImplementedException()
    End Function
End Class