Public Class FrmSeleccionEscala
    Inherits System.Windows.Forms.Form

    Private Sub FrmSeleccionEscala_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Selección de Escalas - BUAP"
        Me.Size = New Size(600, 800)  ' Corrección: Size sin problema
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.BackColor = Color.WhiteSmoke

        Dim y As Integer = 20

        Dim lblTitulo As New Label With {
            .Text = "SELECCIONE UNA ESCALA",
            .Location = New Point(20, y),
            .Font = New Font("Arial", 14, FontStyle.Bold),  ' Corrección: FontStyle.Bold dentro de New Font
            .AutoSize = True
        }
        Me.Controls.Add(lblTitulo)
        y += 50

        AgregarBoton("Guía de Acciones / Tamizajes", y, AddressOf AbrirGuiaAcciones)
        y += 60

        AgregarBoton("GDS-5 (Depresión Simplificada)", y, AddressOf AbrirGDS5)
        y += 60

        AgregarBoton("CDS (Depresión Abreviada)", y, AddressOf AbrirCDS)
        y += 60

        AgregarBoton("Mini-Mental (MMSE)", y, AddressOf AbrirMiniMental)
        y += 60

        AgregarBoton("Incontinencia Urinaria y Caídas", y, AddressOf AbrirIncontinencia)
        y += 60

        AgregarBoton("Ingerdesca (Caídas Ambientales)", y, AddressOf AbrirIngerdesca)
        y += 60

        AgregarBoton("Katz (Actividades Básicas)", y, AddressOf AbrirKatz)
        y += 60

        AgregarBoton("Lawton & Brody (Actividades Instrumentales)", y, AddressOf AbrirLawton)
        y += 60

        AgregarBoton("Osteoporosis (Factores Riesgo)", y, AddressOf AbrirOsteoporosis)
        y += 60

        AgregarBoton("Demencia (Factores Riesgo)", y, AddressOf AbrirDemencia)
        y += 60

        AgregarBoton("IQCODE (Deterioro Cognoscitivo)", y, AddressOf AbrirIQCODE)
        y += 60

        Dim btnRegresar As New Button With {
            .Text = "Regresar",
            .Location = New Point(20, y),
            .Size = New Size(150, 40)
        }
        AddHandler btnRegresar.Click, Sub() Me.Close()
        Me.Controls.Add(btnRegresar)
    End Sub

    Private Sub AgregarBoton(texto As String, y As Integer, accion As EventHandler)
        Dim btn As New Button With {
            .Text = texto,
            .Location = New Point(20, y),
            .Size = New Size(500, 40),
            .Font = New Font("Arial", 12)
        }
        AddHandler btn.Click, accion
        Me.Controls.Add(btn)
    End Sub

    Private Sub AbrirGuiaAcciones(sender As Object, e As EventArgs)
        Dim frm As New FrmGuiaAcciones()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirGDS5(sender As Object, e As EventArgs)
        Dim frm As New FormGDS5()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirCDS(sender As Object, e As EventArgs)
        Dim frm As New FormCDS()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirMiniMental(sender As Object, e As EventArgs)
        Dim frm As New FormMiniMental()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirIncontinencia(sender As Object, e As EventArgs)
        Dim frm As New FormIncontinenciaCaidas()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirIngerdesca(sender As Object, e As EventArgs)
        Dim frm As New FormIngerdesca()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirKatz(sender As Object, e As EventArgs)
        Dim frm As New FormKatz()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirLawton(sender As Object, e As EventArgs)
        Dim frm As New FormLawton()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirOsteoporosis(sender As Object, e As EventArgs)
        Dim frm As New FormOsteoporosis()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirDemencia(sender As Object, e As EventArgs)
        Dim frm As New FormDemencia()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirIQCODE(sender As Object, e As EventArgs)
        Dim frm As New FormIQCODE()
        frm.ShowDialog()
    End Sub
End Class
