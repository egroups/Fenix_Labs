' Written By Ismael Heredia in the year 2017

Imports Sistema.Aplicacion.Data

Public Class FormCambiarUsuario

    Dim usuarioDatos As New UsuarioDatos
    Dim funciones As New Funciones
    Dim usuario As String = ""

    Public Sub New(ByVal usuario_recibido As String)
        InitializeComponent()
        usuario = usuario_recibido
    End Sub

    Private Sub btnCambiarUsuario_Click(sender As Object, e As EventArgs) Handles btnCambiarUsuario.Click
        If txtUsuarioActual.Text = "" OrElse txtClave.Text = "" OrElse txtNuevoNombre.Text = "" Then
            MessageBox.Show("Faltan datos")
        Else
            Dim usuario As String = txtUsuarioActual.Text
            Dim clave As String = funciones.md5_encode(txtClave.Text)
            Dim nuevo_usuario As String = txtNuevoNombre.Text

            Dim id As Integer = usuarioDatos.get_id_by_user(usuario)

            If usuarioDatos.check_login(usuario, clave) Then

                Dim grabar_ready As Boolean = False

                If usuarioDatos.check_exists_usuario_add(nuevo_usuario) Then
                    grabar_ready = False
                Else
                    grabar_ready = True
                End If

                If grabar_ready Then
                    If usuarioDatos.change_username(id, nuevo_usuario) Then
                        MessageBox.Show("El nombre de usuario ha sido cambiado , reinicie la aplicación")
                        Application.Exit()
                    Else
                        MessageBox.Show("Ha ocurrido un error en la base de datos")
                    End If
                Else
                    MessageBox.Show("El usuario " & nuevo_usuario & " ya existe")
                End If
            Else
                MessageBox.Show("Login inválido")
            End If
        End If
    End Sub


    Private Sub FormCambiarUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsuarioActual.Text = usuario
    End Sub

End Class