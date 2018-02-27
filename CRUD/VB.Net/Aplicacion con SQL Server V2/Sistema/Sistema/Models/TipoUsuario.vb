' Written By Ismael Heredia in the year 2017

Public Class TipoUsuario

    Public id As Integer
    Public nombre As String

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

    Public Sub New()

    End Sub

End Class
