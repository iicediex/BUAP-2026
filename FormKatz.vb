Public Class FormKatz
    Inherits System.Windows.Forms.Form

    Private lblPuntaje As Label
    Private lblClasificacion As Label
    Private txtComentarios As TextBox

    Private rbBanarse(1) As RadioButton
    Private rbVestirse(1) As RadioButton
    Private rbHigiene(1) As RadioButton
    Private rbTransferencia(1) As RadioButton
    Private rbContinencia(1) As RadioButton
    Private rbAlimentacion(1) As RadioButton

    Private Sub FormKatz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "ÍNDICE DE INDEPENDENCIA EN ACTIVIDADES BÁSICAS DE LA VIDA DIARIA (KATZ)"
        Me.Size = New Size(750, 700)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.WhiteSmoke

        Dim y As Integer = 20

        Dim lblTitulo As New Label With {.Text = "ÍNDICE DE KATZ", .Location = New Point(20, y), .Font = New Font("Arial", 14, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblTitulo)
        y += 40

        Dim lblInstrucciones As New Label With {.Text = "Califique cada actividad (0 = Independiente, 1 = Dependiente)", .Location = New Point(20, y), .AutoSize = True}
        Me.Controls.Add(lblInstrucciones)
        y += 40

        AgregarActividad("1. Bañarse", y, rbBanarse)
        y += 60

        AgregarActividad("2. Vestirse", y, rbVestirse)
        y += 60

        AgregarActividad("3. Higiene personal", y, rbHigiene)
        y += 60

        AgregarActividad("4. Transferencia (cama-silla)", y, rbTransferencia)
        y += 60

        AgregarActividad("5. Continencia", y, rbContinencia)
        y += 60

        AgregarActividad("6. Alimentación", y, rbAlimentacion)
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

        Dim btnGuardar As New Button With {.Text = "Guardar", .Location = New Point(230, y), .Size = New Size(200, 50)}
        AddHandler btnGuardar.Click, AddressOf btnGuardar_Click
        Me.Controls.Add(btnGuardar)

        Dim btnRegresar As New Button With {.Text = "Regresar", .Location = New Point(440, y), .Size = New Size(200, 50)}
        AddHandler btnRegresar.Click, Sub() Me.Close()
        Me.Controls.Add(btnRegresar)
    End Sub

    Private Sub AgregarActividad(texto As String, y As Integer, ByRef rb As RadioButton())
        Dim lbl As New Label With {.Text = texto, .Location = New Point(20, y), .AutoSize = True}
        Me.Controls.Add(lbl)

        rb(0) = New RadioButton With {.Text = "Independiente", .Location = New Point(20, y + 25), .Checked = True}
        rb(1) = New RadioButton With {.Text = "Dependiente", .Location = New Point(200, y + 25)}
        Me.Controls.Add(rb(0))
        Me.Controls.Add(rb(1))
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs)
        Dim puntaje As Integer = 0

        If rbBanarse(1).Checked Then puntaje += 1
        If rbVestirse(1).Checked Then puntaje += 1
        If rbHigiene(1).Checked Then puntaje += 1
        If rbTransferencia(1).Checked Then puntaje += 1
        If rbContinencia(1).Checked Then puntaje += 1
        If rbAlimentacion(1).Checked Then puntaje += 1

        lblPuntaje.Text = "Puntaje total: " & puntaje

        Dim clasif As String = ""
        Select Case puntaje
            Case 0 : clasif = "Independiente"
            Case 1 To 2 : clasif = "Deterioro leve"
            Case 3 To 4 : clasif = "Deterioro moderado"
            Case 5 To 6 : clasif = "Deterioro severo"
        End Select

        lblClasificacion.Text = "Clasificación: " & clasif
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Guardar en SQL (por implementar).", "Info")
    End Sub
End Class