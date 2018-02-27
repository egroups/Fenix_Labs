' Written By Ismael Heredia in the year 2017

Public Class Proveedor

    Public id As Integer
    Public nombre As String
    Public direccion As String
    Public telefono As Integer
    Public fecha_registro As String

    Public Property pId() As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property

    Public Property pNombre() As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set

    End Property

    Public Property pDireccion() As String
        Get
            Return direccion
        End Get
        Set(value As String)
            direccion = value
        End Set

    End Property

    Public Property pTelefono() As Integer
        Get
            Return telefono
        End Get
        Set(value As Integer)
            telefono = value
        End Set

    End Property

    Public Property pFecha_registro() As String
        Get
            Return fecha_registro
        End Get
        Set(value As String)
            fecha_registro = value
        End Set

    End Property

    Public Sub New()
        id = 0
        nombre = ""
        direccion = ""
        telefono = 0
        fecha_registro = ""

    End Sub

    Public Sub New(id As Integer, nombre As String, direccion As String, telefono As Integer, fecha_registro As String)
        Me.id = id
        Me.nombre = nombre
        Me.direccion = direccion
        Me.telefono = telefono
        Me.fecha_registro = fecha_registro

    End Sub

    Public Function ToString() As String
        Return "[+] ID Proveedor : " & id & vbLf +
                   "[+] Nombre empresa : " & nombre & vbLf +
                   "[+] Telefono : " & telefono & vbLf +
                   "[+] Fecha registro : " & fecha_registro
    End Function

End Class
