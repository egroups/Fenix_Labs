' Written By Ismael Heredia in the year 2017

Imports System
Imports System.Collections.Generic
Imports System.Text

Class Funciones
    Public Function md5_encode(input As String) As String

        Using md5 As System.Security.Cryptography.MD5 = System.Security.Cryptography.MD5.Create()
            Dim inputBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(input)
            Dim hashBytes() As Byte = md5.ComputeHash(inputBytes)
            Dim sb As New StringBuilder()
            For i As Integer = 0 To hashBytes.Length - 1
                sb.Append(hashBytes(i).ToString("X2"))

            Next
            Return sb.ToString().ToLower()

        End Using

    End Function

    Public Function valid_number(numberString As String) As Boolean
        Dim number As Integer
        Return Integer.TryParse(numberString, number)
    End Function

    Public Function fecha_del_dia() As String
        Dim Hoy As DateTime = DateTime.Today
        Dim fecha_actual As String = Hoy.ToString("yyyy-MM-dd")
        Return fecha_actual

    End Function


End Class

