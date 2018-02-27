' Written By Ismael Heredia in the year 2017

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Configuration

Namespace Aplicacion.Data
    Class TipoUsuarioDatos

        Dim connection_string As String = ConfigurationManager.ConnectionStrings("sistema").ToString()

        Public Function List(patron As String) As List(Of TipoUsuario)
            Dim tipos = New List(Of TipoUsuario)()
            Try
                Dim connection = New SqlConnection(connection_string)
                connection.Open()
                Dim query = New SqlCommand("SELECT * FROM tipos_usuarios WHERE nombre LIKE @patron", connection)
                query.Parameters.AddWithValue("@patron", "%" & patron & "%")
                Dim dr = query.ExecuteReader()
                While dr.Read()
                    Dim tipo As New TipoUsuario
                    With tipo
                        .id = Convert.ToInt32(dr("id"))
                        .nombre = dr("nombre").ToString()
                    End With
                    tipos.Add(tipo)
                End While

                connection.Close()
                connection.Dispose()

            Catch
                Throw

            End Try

            Return tipos

        End Function

    End Class

End Namespace



