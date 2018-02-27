' Written By Ismael Heredia in the year 2017
Public Class Producto

    Public id As Integer
    Public nombre As String
    Public descripcion As String
    Public precio As Double
    Public fecha_registro As String
    Public id_proveedor As Integer
    Public proveedor As Proveedor

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

    Public Property pDescripcion() As String
        Get
            Return descripcion
        End Get
        Set(value As String)
            descripcion = value
        End Set

    End Property

    Public Property pPrecio() As Double
        Get
            Return precio
        End Get
        Set(value As Double)
            precio = value
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

    Public Property pId_proveedor() As Integer
        Get
            Return id_proveedor
        End Get
        Set(value As Integer)
            id_proveedor = value
        End Set

    End Property

    Public Property pProveedor() As Proveedor
        Get
            Return proveedor
        End Get
        Set(value As Proveedor)
            proveedor = value
        End Set

    End Property

    Public Sub New()
        proveedor = New Proveedor()
    End Sub

    Public Sub New(id As Integer, nombre As String, descripcion As String, precio As Double, fecha_registro As String, id_proveedor As Integer)
        Me.id = id
        Me.nombre = nombre
        Me.descripcion = descripcion
        Me.precio = precio
        Me.fecha_registro = fecha_registro
        Me.id_proveedor = id_proveedor

    End Sub

    Public Function ToString() As String
        Return "[+] ID Producto : " & id & vbLf +
               "[+] Nombre producto : " & nombre & vbLf +
               "[+] Descripcion : " & descripcion & vbLf +
               "[+] Precio : " & precio & vbLf +
               "[+] ID Proveedor : " & id_proveedor & vbLf +
               "[+] Fecha registro : " & fecha_registro
    End Function

End Class
