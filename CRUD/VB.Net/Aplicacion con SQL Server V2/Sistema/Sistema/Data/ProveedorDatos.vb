' Written By Ismael Heredia in the year 2017

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Configuration

Namespace Aplicacion.Data

    Class ProveedorDatos

        Dim connection_string As String = ConfigurationManager.ConnectionStrings("sistema").ToString()

        Public Function List(patron As String) As List(Of Proveedor)
            Dim proveedores = New List(Of Proveedor)()
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("SELECT * FROM proveedores WHERE nombre LIKE @patron", connection)
                query.Parameters.AddWithValue("@patron", "%" & patron & "%")
                Dim dr = query.ExecuteReader()
                While dr.Read()
                    Dim proveedor As New Proveedor
                    With proveedor
                        .id = Convert.ToInt32(dr("id"))
                        .nombre = dr("nombre").ToString()
                        .direccion = dr("direccion").ToString()
                        .telefono = Convert.ToInt32(dr("telefono").ToString())
                        .fecha_registro = dr("fecha_registro").ToString()
                    End With
                    proveedores.Add(proveedor)
                End While

                connection.Close()
                connection.Dispose()

            Catch
                Throw
            End Try

            Return proveedores

        End Function

        Public Function Obtain(id As Integer) As Proveedor
            Dim proveedor As Proveedor = Nothing
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("SELECT * FROM proveedores WHERE id = @id", connection)
                query.Parameters.AddWithValue("@id", id)
                Dim dr = query.ExecuteReader()
                dr.Read()
                If dr.HasRows Then
                    proveedor = New Proveedor()
                    proveedor.id = Convert.ToInt32(dr("id"))
                    proveedor.nombre = dr("nombre").ToString()
                    proveedor.direccion = dr("direccion").ToString()
                    proveedor.telefono = Convert.ToInt32(dr("telefono"))
                    proveedor.fecha_registro = dr("fecha_registro").ToString()

                End If

                dr.Close()
                connection.Close()
                connection.Dispose()

            Catch
                Throw

            End Try

            Return proveedor

        End Function

        Public Function Add(proveedor As Proveedor) As Boolean
            Dim respuesta As Boolean = False
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("INSERT INTO proveedores(nombre,direccion,telefono,fecha_registro) VALUES (@p0, @p1, @p2, @p3)", connection)
                query.Parameters.AddWithValue("@p0", proveedor.nombre)
                query.Parameters.AddWithValue("@p1", proveedor.direccion)
                query.Parameters.AddWithValue("@p2", proveedor.telefono)
                query.Parameters.AddWithValue("@p3", proveedor.fecha_registro)
                query.ExecuteNonQuery()
                connection.Close()
                connection.Dispose()
                respuesta = True

            Catch
                Throw

            End Try

            Return respuesta

        End Function

        Public Function Update(proveedor As Proveedor) As Boolean
            Dim respuesta As Boolean = False
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("UPDATE proveedores SET nombre = @p0, direccion = @p1, telefono = @p2 WHERE id = @p3", connection)
                query.Parameters.AddWithValue("@p0", proveedor.nombre)
                query.Parameters.AddWithValue("@p1", proveedor.direccion)
                query.Parameters.AddWithValue("@p2", proveedor.telefono)
                query.Parameters.AddWithValue("@p3", proveedor.id)
                query.ExecuteNonQuery()
                connection.Close()
                connection.Dispose()
                respuesta = True

            Catch
                Throw

            End Try

            Return respuesta

        End Function

        Public Function Delete(proveedor As Proveedor) As Boolean
            Dim respuesta As Boolean = False
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("DELETE FROM proveedores WHERE id = @p0", connection)
                query.Parameters.AddWithValue("@p0", proveedor.id)
                query.ExecuteNonQuery()
                connection.Close()
                connection.Dispose()
                respuesta = True

            Catch
                Throw

            End Try

            Return respuesta

        End Function

        Public Function check_exists_proveedor_add(nombre As String) As Boolean
            Dim respuesta As Boolean = False
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("SELECT * FROM proveedores WHERE nombre = @nombre", connection)
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

        Public Function check_exists_proveedor_edit(id As Integer, nombre As String) As Boolean
            Dim respuesta As Boolean = False
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("SELECT * FROM proveedores WHERE nombre = @nombre and id != @id", connection)
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

    End Class

End Namespace


