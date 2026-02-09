Public Class FormLawton
    Inherits System.Windows.Forms.Form

    Private lblPuntaje As Label
    Private lblClasificacion As Label
    Private txtComentarios As TextBox

    Private rbCapacidades(7)() As RadioButton  ' 8 actividades, cada una con 2 opciones (0 = dependiente, 1 = independiente)

    Private Sub FormLawton_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Índice de Actividades Instrumentales de la Vida Diaria (Lawton & Brody)"
        Me.Size = New Size(800, 900)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.WhiteSmoke

        Dim y As Integer = 20

        Dim lblTitulo As New Label With {
            .Text = "ÍNDICE DE ACTIVIDADES INSTRUMENTALES DE LA VIDA DIARIA (LAWTON & BRODY)",
            .Location = New Point(20, y),
            .Font = New Font("Arial", 14, FontStyle.Bold),
            .AutoSize = True
        }
        Me.Controls.Add(lblTitulo)
        y += 50

        Dim lblInstrucciones As New Label With {
            .Text = "Califique cada actividad según el nivel de independencia de la persona adulta mayor.",
            .Location = New Point(20, y),
            .AutoSize = True
        }
        Me.Controls.Add(lblInstrucciones)
        y += 40

        Dim actividades() As String = {
            "1. Usar el teléfono",
            "2. Hacer compras",
            "3. Preparación de la comida",
            "4. Cuidado de la casa",
            "5. Lavado de ropa",
            "6. Uso de medios de transporte",
            "7. Responsabilidad respecto a sus medicamentos",
            "8. Manejo de asuntos económicos"
        }

        For i As Integer = 0 To 7
            Dim lbl As New Label With {
                .Text = actividades(i),
                .Location = New Point(20, y),
                .AutoSize = True,
                .Width = 600
            }
            Me.Controls.Add(lbl)

            rbCapacidades(i) = New RadioButton(2) {}
            rbCapacidades(i)(0) = New RadioButton With {.Text = "Independiente", .Location = New Point(20, y + 25), .Checked = True}
            rbCapacidades(i)(1) = New RadioButton With {.Text = "Dependiente", .Location = New Point(200, y + 25)}
            Me.Controls.Add(rbCapacidades(i)(0))
            Me.Controls.Add(rbCapacidades(i)(1))

            y += 60
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
            .Size = New Size(700, 100),
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
        Dim puntaje As Integer = 0

        For i As Integer = 0 To 7
            If rbCapacidades(i)(0).Checked Then puntaje += 1  ' Independiente = 1 punto
        Next

        lblPuntaje.Text = "Puntaje total: " & puntaje

        Dim clasif As String = ""
        Select Case puntaje
            Case 8
                clasif = "Independiente"
            Case 6 To 7
                clasif = "Semidependiente"
            Case 0 To 5
                clasif = "Dependiente"
        End Select

        lblClasificacion.Text = "Clasificación: " & clasif
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Guardar en SQL (por implementar).", "Info")
    End Sub
End Class