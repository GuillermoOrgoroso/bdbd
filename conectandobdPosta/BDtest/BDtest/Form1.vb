Imports System.Data.Odbc


Public Class Form1
    Private stringDeConexion As String = "DRIVER=MySQL ODBC 8.0 UNICODE Driver;UID=root;PWD=Tooroot123654;PORT=3306;DATABASE=Persona;SERVER=localhost"

    Private lector As OdbcDataReader

    Private Sub obtenerDatos()
        Dim conexion As New OdbcConnection(stringDeConexion)
        conexion.Open()

        Dim comando As New OdbcCommand
        comando.CommandText = "SELECT * FROM Personita"

        comando.Connection = conexion

        Me.lector = comando.ExecuteReader()




    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Dim conexion As New OdbcConnection(stringDeConexion)
        conexion.Open()

        Dim comando = New OdbcCommand

        If txtMail.Text = "" Then


            comando.CommandText = "INSERT INTO Personita(id,nombre,apellido) VALUES(" + txtID.Text + ",'" + txtNombre.Text + "','" + txtApellido.Text + "' )"

        Else
            comando.CommandText = "INSERT INTO Personita(id,nombre,apellido,mail) VALUES(" + txtID.Text + ",'" + txtNombre.Text + "','" + txtApellido.Text + "','" + txtMail.Text + "' )"


        End If

        MsgBox(comando.CommandText)
        comando.Connection = conexion

        comando.ExecuteNonQuery()

        MsgBox("Datos ingresados correctamente wachin!")


    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim conexion As New OdbcConnection(stringDeConexion)

        conexion.Open()

        Dim comando = New OdbcCommand

        comando.CommandText = "UPDATE Personita SET nombre = '" + txtNombre.Text + "', apellido = '" + txtApellido.Text + "', mail = '" + txtMail.Text + "' WHERE id = " + txtID.Text + ""

        MsgBox(comando.CommandText)
        comando.Connection = conexion

        comando.ExecuteNonQuery()

        MsgBox("Datos modificados correctamente ATRRRRR")



    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim conexion As New OdbcConnection(stringDeConexion)

        conexion.Open()

        Dim comando = New OdbcCommand

        comando.CommandText = "DELETE FROM Personita WHERE id = " + txtID.Text + ""

        MsgBox(comando.CommandText)
        comando.Connection = conexion

        comando.ExecuteNonQuery()

        MsgBox("Persona eliminada correctamente")
        MsgBox("hola")


    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        obtenerDatos()

    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        lector.Read()
        txtID.Text = lector(0).ToString()
        txtNombre.Text = lector(1).ToString()
        txtApellido.Text = lector(2).ToString()
        txtMail.Text = lector(3).ToString()



    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click

        obtenerDatos()

        Dim tablita As New DataTable

        tablita.Load(Me.lector)

        GrillaDatos.DataSource = tablita




    End Sub


End Class
