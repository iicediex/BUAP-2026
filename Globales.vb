Module Globales
    Public GerontologoNombre As String = ""
    Public IdGerontologo As Integer = 0
    Public Rol As String = ""  ' "Administrador" o "Gerontólogo"
    Public IdUsuarioSeleccionado As Integer = 0
    Public UsuarioNombre As String = ""
    Public SesionActiva As Boolean = False

    Public Sub LimpiarSesion()
        GerontologoNombre = ""
        IdGerontologo = 0
        Rol = ""
        IdUsuarioSeleccionado = 0
        UsuarioNombre = ""
        SesionActiva = False
    End Sub
End Module