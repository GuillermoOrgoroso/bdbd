﻿Imports System.Data.Odbc


Public Class Form1
    Private stringDeConexion As String = "DRIVER=MySQL ODBC 8.0 UNICODE Driver;UID=root;PWD=Tooroot123654;PORT=3306;DATABASE=Persona;SERVER=localhost"

    Private lector As OdbcDataReader

    Private Sub obtenerDatos()
        Dim conexion As New OdbcConnection(stringDeConexion)
        conexion.Open()

        Dim comando As New OdbcCommand
        comando.CommandText = "SELECT * FROM Persona"

        comando.Connection = conexion

        Me.lector = comando.ExecuteReader




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
End Class
