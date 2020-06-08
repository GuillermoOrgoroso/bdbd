Imports System.Data.Odbc


Public Class Form1
    Private stringDeConexion As String = "DRIVER=MySQL ODBC 8.0 UNICODE Driver;UID=root;PWD=Tooroot123654;PORT=3307;DATABASE=Persona;SERVER=localhost"


    Private Sub obtenerDatos()
        Dim conexion As New OdbcConnection(stringDeConexion)
        conexion.Open()


    End Sub


End Class
