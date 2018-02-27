' Written By Ismael Heredia in the year 2017

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Configuration

Namespace Aplicacion.Data
    Class ProductoDatos

        Dim connection_string As String = ConfigurationManager.ConnectionStrings("sistema").ToString()

        Public Function List(patron As String) As List(Of Producto)
            Dim productos = New List(Of Producto)()
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("SELECT * FROM productos WHERE nombre LIKE @patron", connection)
                query.Parameters.AddWithValue("@patron", "%" & patron & "%")
                Dim dr = query.ExecuteReader()
                While dr.Read()
                    Dim producto As New Producto
                    With producto
                        .id = Convert.ToInt32(dr("id"))
                        .nombre = dr("nombre").ToString()
                        .descripcion = dr("descripcion").ToString()
                        .precio = Convert.ToDouble(dr("precio").ToString())
                        .id_proveedor = Convert.ToInt32(dr("id_proveedor"))
                        .fecha_registro = dr("fecha_registro").ToString()
                    End With
                    productos.Add(producto)
                End While

                dr.Close()
                For Each p In productos
                    query = New SqlCommand("SELECT * FROM proveedores WHERE id = @id", connection)
                    query.Parameters.AddWithValue("@id", p.id_proveedor)
                    dr = query.ExecuteReader()
                    dr.Read()
                    If dr.HasRows Then
                        p.proveedor.id = Convert.ToInt32(dr("id"))
                        p.proveedor.nombre = dr("nombre").ToString()
                    End If

                    dr.Close()

                Next

                connection.Close()
                connection.Dispose()

            Catch
                Throw

            End Try

            Return productos

        End Function

        Public Function Obtain(id As Integer) As Producto
            Dim producto As New Producto()
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("SELECT * FROM productos WHERE id = @id", connection)
                query.Parameters.AddWithValue("@id", id)
                Dim dr = query.ExecuteReader()
                dr.Read()
                If dr.HasRows Then
                    producto.id = Convert.ToInt32(dr("id"))
                    producto.nombre = dr("nombre").ToString()
                    producto.descripcion = dr("descripcion").ToString()
                    producto.precio = Convert.ToDouble(dr("precio").ToString())
                    producto.id_proveedor = Convert.ToInt32(dr("id_proveedor"))

                Else
                    Return Nothing

                End If

                dr.Close()
                query = New SqlCommand("SELECT * FROM proveedores WHERE id = @id", connection)
                query.Parameters.AddWithValue("@id", producto.id_proveedor)
                dr = query.ExecuteReader()
                dr.Read()
                If dr.HasRows Then
                    producto.proveedor.id = Convert.ToInt32(dr("id"))
                    producto.proveedor.nombre = dr("nombre").ToString()

                Else
                    Return Nothing

                End If

                dr.Close()
                connection.Close()
                connection.Dispose()

            Catch
                Throw

            End Try

            Return producto

        End Function

        Public Function Add(producto As Producto) As Boolean
            Dim respuesta As Boolean = False
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("INSERT INTO productos(nombre,descripcion,precio,id_proveedor,fecha_registro) VALUES (@p0, @p1, @p2, @p3, @p4)", connection)
                query.Parameters.AddWithValue("@p0", producto.nombre)
                query.Parameters.AddWithValue("@p1", producto.descripcion)
                query.Parameters.AddWithValue("@p2", producto.precio)
                query.Parameters.AddWithValue("@p3", producto.id_proveedor)
                query.Parameters.AddWithValue("@p4", producto.fecha_registro)
                query.ExecuteNonQuery()
                connection.Close()
                connection.Dispose()
                respuesta = True

            Catch
                Throw

            End Try

            Return respuesta

        End Function

        Public Function Update(producto As Producto) As Boolean
            Dim respuesta As Boolean = False
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("UPDATE productos SET nombre = @p0, descripcion = @p1, precio = @p2, id_proveedor = @p3 WHERE id = @p4", connection)
                query.Parameters.AddWithValue("@p0", producto.nombre)
                query.Parameters.AddWithValue("@p1", producto.descripcion)
                query.Parameters.AddWithValue("@p2", producto.precio)
                query.Parameters.AddWithValue("@p3", producto.id_proveedor)
                query.Parameters.AddWithValue("@p4", producto.id)
                query.ExecuteNonQuery()
                connection.Close()
                connection.Dispose()
                respuesta = True

            Catch
                Throw

            End Try

            Return respuesta

        End Function

        Public Function Delete(producto As Producto) As Boolean
            Dim respuesta As Boolean = False
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("DELETE FROM productos WHERE id = @p0", connection)
                query.Parameters.AddWithValue("@p0", producto.id)
                query.ExecuteNonQuery()
                connection.Close()
                connection.Dispose()
                respuesta = True

            Catch
                Throw

            End Try

            Return respuesta

        End Function

        Public Function check_exists_producto_add(nombre As String) As Boolean
            Dim respuesta As Boolean = False
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("SELECT * FROM productos WHERE nombre = @nombre", connection)
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

        Public Function check_exists_producto_edit(id As Integer, nombre As String) As Boolean
            Dim respuesta As Boolean = False
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("SELECT * FROM productos WHERE nombre = @nombre and id != @id", connection)
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



