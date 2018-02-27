' Written By Ismael Heredia in the year 2017

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.Sql
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace Aplicacion.Data
    Class UsuarioDatos

        Dim connection_string As String = ConfigurationManager.ConnectionStrings("sistema").ToString()

        Public Function List(patron As String) As List(Of Usuario)
            Dim usuarios = New List(Of Usuario)()
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("SELECT * FROM usuarios WHERE nombre LIKE @patron", connection)
                query.Parameters.AddWithValue("@patron", "%" & patron & "%")
                Dim dr = query.ExecuteReader()
                While dr.Read()
                    Dim usuario As New Usuario
                    With usuario
                        .id = Convert.ToInt32(dr("id"))
                        .nombre = dr("nombre").ToString()
                        .clave = dr("clave").ToString()
                        .id_tipo = Convert.ToInt32(dr("id_tipo"))
                        .fecha_registro = dr("fecha_registro").ToString()
                    End With
                    usuarios.Add(usuario)
                End While

                dr.Close()
                For Each u In usuarios
                    query = New SqlCommand("SELECT * FROM tipos_usuarios WHERE id = @id", connection)
                    query.Parameters.AddWithValue("@id", u.id_tipo)
                    dr = query.ExecuteReader()
                    dr.Read()
                    If dr.HasRows Then
                        u.tipo.id = Convert.ToInt32(dr("id"))
                        u.tipo.nombre = dr("nombre").ToString()

                    End If

                    dr.Close()

                Next

                connection.Close()
                connection.Dispose()

            Catch
                Throw

            End Try

            Return usuarios

        End Function

        Public Function Obtain(id As Integer) As Usuario
            Dim usuario As New Usuario()
            Try
                Dim connection = New SqlConnection(connection_String)
                connection.Open()
                Dim query = New SqlCommand("SELECT * FROM usuarios WHERE id = @id", connection)
                query.Parameters.AddWithValue("@id", id)
                Dim dr = query.ExecuteReader()
                dr.Read()
                If dr.HasRows Then
                    usuario = New Usuario()
                    usuario.id = Convert.ToInt32(dr("id"))
                    usuario.nombre = dr("nombre").ToString()
                    usuario.clave = dr("clave").ToString()
                    usuario.id_tipo = Convert.ToInt32(dr("id_tipo").ToString())
                    usuario.fecha_registro = dr("fecha_registro").ToString()

                Else
                    Return Nothing

                End If

                dr.Close()
                query = New SqlCommand("SELECT * FROM tipos_usuarios WHERE id = @id", connection)
                query.Parameters.AddWithValue("@id", usuario.id_tipo)
                dr = query.ExecuteReader()
                dr.Read()
                If dr.HasRows Then
                    usuario.tipo.id = Convert.ToInt32(dr("id"))
                    usuario.tipo.nombre = dr("nombre").ToString()

                Else
                    Return Nothing

                End If

                dr.Close()
                connection.Close()
                connection.Dispose()

            Catch
                Throw

            End Try

            Return usuario

        End Function

    Public Function Add(usuario As Usuario) As Boolean
        Dim respuesta As Boolean = False
        Try
            Dim connection = New SqlConnection(connection_String)
            connection.Open()
            Dim query = New SqlCommand("INSERT INTO usuarios(nombre,clave,id_tipo,fecha_registro) VALUES (@p0, @p1, @p2, @p3)", connection)
            query.Parameters.AddWithValue("@p0", usuario.nombre)
            query.Parameters.AddWithValue("@p1", usuario.clave)
            query.Parameters.AddWithValue("@p2", usuario.id_tipo)
            query.Parameters.AddWithValue("@p3", usuario.fecha_registro)
            query.ExecuteNonQuery()
            connection.Close()
            connection.Dispose()
            respuesta = True

        Catch
            Throw

        End Try

        Return respuesta

    End Function

    Public Function Update(usuario As Usuario) As Boolean
        Dim respuesta As Boolean = False
        Try
            Dim connection = New SqlConnection(connection_String)
            connection.Open()
            Dim query = New SqlCommand("UPDATE usuarios SET id_tipo = @p0 WHERE id = @p1", connection)
            query.Parameters.AddWithValue("@p0", usuario.id_tipo)
            query.Parameters.AddWithValue("@p1", usuario.id)
            query.ExecuteNonQuery()
            connection.Close()
            connection.Dispose()
            respuesta = True

        Catch
            Throw

        End Try

        Return respuesta

    End Function

    Public Function Delete(usuario As Usuario) As Boolean
        Dim respuesta As Boolean = False
        Try
            Dim connection = New SqlConnection(connection_String)
            connection.Open()
            Dim query = New SqlCommand("DELETE FROM usuarios WHERE id = @p0", connection)
            query.Parameters.AddWithValue("@p0", usuario.id)
            query.ExecuteNonQuery()
            connection.Close()
            connection.Dispose()
            respuesta = True

        Catch
            Throw

        End Try

        Return respuesta

    End Function

    Public Function check_exists_usuario_add(nombre As String) As Boolean
        Dim respuesta As Boolean = False
        Try
            Dim connection = New SqlConnection(connection_String)
            connection.Open()
            Dim query = New SqlCommand("SELECT * FROM usuarios WHERE nombre = @nombre", connection)
            query.Parameters.AddWithValue("@nombre", nombre)
            Dim dr = query.ExecuteReader()
            Dim dt As New DataTable()
            dt.Load(dr)
            Dim length As Integer = dt.Rows.Count
            If length >= 1 Then
                respuesta = True

            End If

            connection.Close()
            connection.Dispose()

        Catch
            Throw

        End Try
        Return respuesta

    End Function

    Public Function check_exists_usuario_edit(id As Integer, nombre As String) As Boolean
        Dim respuesta As Boolean = False
        Try
            Dim connection = New SqlConnection(connection_String)
            connection.Open()
            Dim query = New SqlCommand("SELECT * FROM usuarios WHERE nombre = @nombre and id != @id", connection)
            query.Parameters.AddWithValue("@id", id)
            query.Parameters.AddWithValue("@nombre", nombre)
            Dim dr = query.ExecuteReader()
            Dim dt As New DataTable()
            dt.Load(dr)
            Dim length As Integer = dt.Rows.Count
            If length >= 1 Then
                respuesta = True

            End If

            connection.Close()
            connection.Dispose()

        Catch
            Throw

        End Try
        Return respuesta

    End Function

    Public Function check_login(usuario As String, clave As String) As Boolean
        Dim respuesta As Boolean = False
        Try
            Dim connection = New SqlConnection(connection_String)
            connection.Open()
            Dim query = New SqlCommand("SELECT * FROM usuarios WHERE nombre = @nombre and clave = @clave", connection)
            query.Parameters.AddWithValue("@nombre", usuario)
            query.Parameters.AddWithValue("@clave", clave)
            Dim dr = query.ExecuteReader()
            Dim dt As New DataTable()
            dt.Load(dr)
            Dim length As Integer = dt.Rows.Count
            If length >= 1 Then
                respuesta = True

            End If

            connection.Close()
            connection.Dispose()

        Catch
            Throw

        End Try
        Return respuesta

    End Function

    Public Function get_user_type(nombre As String) As String
        Dim user_type As String = ""
        Try
            Dim connection = New SqlConnection(connection_String)
            connection.Open()
            Dim query = New SqlCommand("SELECT t.nombre FROM usuarios u,tipos_usuarios t WHERE u.nombre = @nombre AND u.id_tipo = t.id", connection)
            query.Parameters.AddWithValue("@nombre", nombre)
            Dim dr = query.ExecuteReader()
            If dr.Read() Then
                user_type = dr("nombre").ToString()

            End If

            connection.Close()
            connection.Dispose()

        Catch
            Throw

        End Try
        Return user_type

    End Function

    Public Function get_id_by_user(usuario As String) As Integer
        Dim id As Integer = 0
        Try
            Dim connection = New SqlConnection(connection_String)
            connection.Open()
            Dim query = New SqlCommand("SELECT id FROM usuarios WHERE nombre = @nombre", connection)
            query.Parameters.AddWithValue("@nombre", usuario)
            Dim dr = query.ExecuteReader()
            If dr.Read() Then
                id = Convert.ToInt32(dr("id"))

            End If

            connection.Close()
            connection.Dispose()

        Catch
            Throw

        End Try
        Return id

    End Function

    Public Function change_username(id As Integer, nuevo_usuario As String) As Boolean
        Dim respuesta As Boolean = False
        Try
            Dim connection = New SqlConnection(connection_String)
            connection.Open()
            Dim query = New SqlCommand("UPDATE usuarios SET nombre = @p0 WHERE id = @p1", connection)
            query.Parameters.AddWithValue("@p0", nuevo_usuario)
            query.Parameters.AddWithValue("@p1", id)
            query.ExecuteNonQuery()
            connection.Close()
            connection.Dispose()
            respuesta = True

        Catch
            Throw

        End Try

        Return respuesta

    End Function

    Public Function change_password(id As Integer, nueva_clave As String) As Boolean
        Dim respuesta As Boolean = False
        Try
            Dim connection = New SqlConnection(connection_String)
            connection.Open()
            Dim query = New SqlCommand("UPDATE usuarios SET clave = @p0 WHERE id = @p1", connection)
            query.Parameters.AddWithValue("@p0", nueva_clave)
            query.Parameters.AddWithValue("@p1", id)
            query.ExecuteNonQuery()
            connection.Close()
            connection.Dispose()
            respuesta = True

        Catch
            Throw

        End Try

        Return respuesta

    End Function

    End Class
End Namespace
