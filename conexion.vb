Imports Microsoft.Data.SqlClient
Module Conexion
    Public Function Conectar() As SqlConnection
        Dim cadena As String = "Server=(localdb)\MSSQLLocalDB;Database=GerontologiaBUAP2025;Trusted_Connection=True;"
        Dim conn As New SqlConnection(cadena)
        Try
            conn.Open()
            Return conn
        Catch ex As Exception
            MessageBox.Show("Error de conexión: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
End Module