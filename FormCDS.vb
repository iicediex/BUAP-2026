Public Class FormCDS
    Inherits System.Windows.Forms.Form

    Private lblPuntaje As Label
    Private lblClasificacion As Label
    Private txtComentarios As TextBox

    Private rbPreguntas(14) As RadioButton  ' SI

    Private Sub FormCDS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "CDS - Depresión Geriátrica Abreviada"
        Me.Size = New Size(750, 900)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.WhiteSmoke

        Dim y As Integer = 20

        Dim lblTitulo As New Label With {.Text = "ESCALA DE DEPRESIÓN GERIÁTRICA ABREVIADA (CDS)", .Location = New Point(20, y), .Font = New Font("Arial", 14, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblTitulo)
        y += 40

        Dim lblInstrucciones As New Label With {.Text = "Responda a cada una de las siguientes preguntas.", .Location = New Point(20, y), .AutoSize = True}
        Me.Controls.Add(lblInstrucciones)
        y += 40

        Dim preguntas() As String = {
            "¿Está usted satisfecho con su vida?",
            "¿Ha abandonado muchos de sus intereses y actividades previas?",
            "¿Siente que su vida está vacía?",
            "¿Se aburre a menudo?",
            "¿Está de buen humor la mayor parte del tiempo?",
            "¿Teme que le vaya a pasar algo malo?",
            "¿Se siente feliz la mayor parte del tiempo?",
            "¿Se siente a menudo desamparado?",
            "¿Prefiere quedarse en casa en vez de salir a hacer cosas nuevas?",
            "¿Cree que tiene más problemas con la memoria que la mayoría de la gente?",
            "¿Cree que es maravilloso vivir en este momento?",
            "¿Se siente bastante inútil tal como es ahora?",
            "¿Siente que su vida está llena de energía?",
            "¿Siente que su situación es desesperada?",
            "¿Cree que la mayoría de las personas están mejor que usted?"
        }

        For i As Integer = 0 To 14
            Dim lbl As New Label With {.Text = (i + 1) & ". " & preguntas(i), .Location = New Point(20, y), .AutoSize = True}
            Me.Controls.Add(lbl)
            y += 30

            rbPreguntas(i) = New RadioButton With {.Text = "SI", .Location = New Point(20, y)}
            Dim rbNo As New RadioButton With {.Text = "NO", .Location = New Point(80, y), .Checked = True}
            Me.Controls.Add(rbPreguntas(i))
            Me.Controls.Add(rbNo)
            y += 40
        Next

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

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs)
        Dim puntaje As Integer = 0

        For i As Integer = 0 To 14
            If rbPreguntas(i).Checked Then puntaje += 1
        Next

        lblPuntaje.Text = "Puntaje total: " & puntaje

        Dim clasif As String = If(puntaje <= 5, "Sin sintomatología depresiva", "Con sintomatología depresiva")
        lblClasificacion.Text = "Clasificación: " & clasif
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Guardar en SQL (por implementar).", "Info")
    End Sub
End Class