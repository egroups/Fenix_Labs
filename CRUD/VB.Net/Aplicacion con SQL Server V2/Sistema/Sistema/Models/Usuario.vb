' Written By Ismael Heredia in the year 2017
Public Class Usuario

    Public id As Integer
    Public nombre As String
    Public clave As String
    Public id_tipo As Integer
    Public tipo As TipoUsuario
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

    Public Property pClave() As String
        Get
            Return clave
        End Get
        Set(value As String)
            clave = value
        End Set
    End Property

    Public Property pIdTipo() As Integer
        Get
            Return id_tipo
        End Get
        Set(value As Integer)
            id_tipo = value
        End Set
    End Property

    Public Property pFecha_registro As String
        Get
            Return fecha_registro
        End Get
        Set(value As String)
            fecha_registro = value
        End Set
    End Property

    Public Sub New()
        tipo = New TipoUsuario()
    End Sub

    Public Sub New(id As Integer, nombre As String, clave As String, id_tipo As Integer, fecha_registro As String)
        Me.id = id
        Me.nombre = nombre
        Me.clave = clave
        Me.id_tipo = id_tipo
        Me.fecha_registro = fecha_registro
    End Sub

    Public Function ToString() As String
        Return "[+] ID Usuario : " & id & vbLf +
               "[+] Nombre : " & nombre & vbLf +
               "[+] Clave : " & clave & vbLf +
               "[+] Id Tipo : " & id_tipo & vbLf +
               "[+] Fecha registro : " & fecha_registro
    End Function

End Class
