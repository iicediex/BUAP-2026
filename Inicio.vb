Imports System
Imports System.Windows.Forms

Module Inicio
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Try
            ' Fuerza que inicie directamente con FormLogin
            Application.Run(New FormLogin())
        Catch ex As Exception
            MessageBox.Show("Error al iniciar la aplicación:" & vbCrLf & vbCrLf &
                            ex.Message & vbCrLf & vbCrLf &
                            "Detalles:" & vbCrLf & ex.StackTrace,
                            "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub
End Module