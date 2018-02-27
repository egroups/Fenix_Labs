' Written By Ismael Heredia in the year 2017

Imports Sistema.Aplicacion.Data

Public Class FormCambiarClave

    Dim usuarioDatos As New UsuarioDatos
    Dim funcion As New Funciones
    Dim usuario As String = ""

    Public Sub New(ByVal usuario_recibido As String)
        InitializeComponent()
        usuario = usuario_recibido
    End Sub

    Private Sub btnCambiarClave_Click(sender As Object, e As EventArgs) Handles btnCambiarClave.Click
        If txtUsuarioActual.Text = "" OrElse txtClave.Text = "" OrElse txtNuevaClave.Text = "" Then
            MessageBox.Show("Faltan datos")
        Else
            Dim usuario As String = txtUsuarioActual.Text
            Dim clave As String = funcion.md5_encode(txtClave.Text)
            Dim nueva_clave As String = funcion.md5_encode(txtNuevaClave.Text)

            Dim id As Integer = usuarioDatos.get_id_by_user(usuario)

            If usuarioDatos.check_login(usuario, clave) Then
                If usuarioDatos.change_password(id, nueva_clave) Then
                    MessageBox.Show("La clave ha sido cambiada , reinicie la aplicación")
                    Application.Exit()
                Else
                    MessageBox.Show("Ha ocurrido un error en la base de datos")
                End If
            Else
                MessageBox.Show("Login inválido")
            End If
        End If
    End Sub

    Private Sub FormCambiarClave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsuarioActual.Text = usuario
    End Sub

End Class