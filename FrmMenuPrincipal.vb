Public Class FrmMenuPrincipal
    Inherits System.Windows.Forms.Form

    Private Sub FrmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Menú Principal - Gerontología BUAP"
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.WhiteSmoke

        Dim lblBienvenida As New Label With {.Text = "Bienvenido, " & Globales.GerontologoNombre & " (" & Globales.Rol & ")", .Location = New Point(20, 20), .Font = New Font("Arial", 14, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblBienvenida)

        Dim y As Integer = 80

        If Globales.Rol = "Administrador" Then
            Dim lblAdmin As New Label With {.Text = "Administración (solo Admin):", .Location = New Point(20, y), .Font = New Font("Arial", 12, FontStyle.Bold), .AutoSize = True}
            Me.Controls.Add(lblAdmin)
            y += 40

            Dim btnAdminGerontologos As New Button With {
                .Text = "Administrar Gerontólogos",
                .Location = New Point(20, y),
                .Size = New Size(350, 45),
                .Font = New Font("Arial", 10, FontStyle.Bold),
                .BackColor = Color.LightCyan
            }
            AddHandler btnAdminGerontologos.Click, AddressOf AbrirAdminGerontologos
            Me.Controls.Add(btnAdminGerontologos)
            y += 55

            Dim btnAdminUsuarios As New Button With {
                .Text = "Administrar Usuarios",
                .Location = New Point(20, y),
                .Size = New Size(350, 45),
                .Font = New Font("Arial", 10, FontStyle.Bold),
                .BackColor = Color.LightYellow
            }
            AddHandler btnAdminUsuarios.Click, AddressOf AbrirAdminUsuarios
            Me.Controls.Add(btnAdminUsuarios)
            y += 55

            Dim btnNuevaEscala As New Button With {
                .Text = "Crear Nueva Escala",
                .Location = New Point(20, y),
                .Size = New Size(350, 45),
                .Font = New Font("Arial", 10, FontStyle.Bold),
                .BackColor = Color.LightGreen
            }
            AddHandler btnNuevaEscala.Click, AddressOf AbrirNuevaEscala
            Me.Controls.Add(btnNuevaEscala)
            y += 55
        End If

        ' Opciones comunes para ambos roles
        Dim lblComun As New Label With {.Text = "Opciones Comunes:", .Location = New Point(450, 100), .Font = New Font("Arial", 12, FontStyle.Bold), .AutoSize = True}
        Me.Controls.Add(lblComun)

        Dim yComun As Integer = 140

        Dim btnSeleccionEscala As New Button With {
            .Text = "Seleccionar Escala",
            .Location = New Point(450, yComun),
            .Size = New Size(350, 45),
            .Font = New Font("Arial", 10, FontStyle.Bold),
            .BackColor = Color.LightBlue
        }
        AddHandler btnSeleccionEscala.Click, AddressOf AbrirSeleccionEscala
        Me.Controls.Add(btnSeleccionEscala)
        yComun += 55

        Dim btnBio As New Button With {
            .Text = "Bioimpedancia",
            .Location = New Point(450, yComun),
            .Size = New Size(350, 45),
            .Font = New Font("Arial", 10, FontStyle.Bold),
            .BackColor = Color.LightBlue
        }
        AddHandler btnBio.Click, AddressOf AbrirBioimpedancia
        Me.Controls.Add(btnBio)
        yComun += 55

        Dim btnObs As New Button With {
            .Text = "Observaciones",
            .Location = New Point(450, yComun),
            .Size = New Size(350, 45),
            .Font = New Font("Arial", 10, FontStyle.Bold),
            .BackColor = Color.LightBlue
        }
        AddHandler btnObs.Click, AddressOf AbrirObservaciones
        Me.Controls.Add(btnObs)
        yComun += 55

        Dim btnCerrar As New Button With {
            .Text = "Cerrar Sesión",
            .Location = New Point(450, yComun),
            .Size = New Size(350, 45),
            .Font = New Font("Arial", 10, FontStyle.Bold),
            .BackColor = Color.LightCoral
        }
        AddHandler btnCerrar.Click, AddressOf btnCerrar_Click
        Me.Controls.Add(btnCerrar)
    End Sub

    Private Sub AbrirAdminGerontologos(sender As Object, e As EventArgs)
        Dim frm As New FrmAdminGerontologos()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirAdminUsuarios(sender As Object, e As EventArgs)
        Dim frm As New FrmAdminUsuarios()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirNuevaEscala(sender As Object, e As EventArgs)
        MessageBox.Show("Función para crear nueva escala (por implementar).", "Info")
    End Sub

    Private Sub AbrirSeleccionEscala(sender As Object, e As EventArgs)
        Dim frm As New FrmSeleccionEscala()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirBioimpedancia(sender As Object, e As EventArgs)
        Dim frm As New FrmBioimpedancia()
        frm.ShowDialog()
    End Sub

    Private Sub AbrirObservaciones(sender As Object, e As EventArgs)
        Dim frm As New FrmObservaciones()
        frm.ShowDialog()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Globales.LimpiarSesion()
        Me.Close()
        Dim frm As New FormLogin()
        frm.Show()
    End Sub
End Class