' Written By Ismael Heredia in the year 2017

Imports Sistema.Aplicacion.Data

Public Class FormLogin

    Dim usuarioDatos As New UsuarioDatos
    Dim funciones As New Funciones

    Private Sub btnIngresar_Click(sender As System.Object, e As System.EventArgs) Handles btnIngresar.Click
        If txtUsuario.Text = "" OrElse txtClave.Text = "" Then
            MessageBox.Show("Faltan datos")
        Else
            Dim usuario As String = txtUsuario.Text
            Dim clave As String = funciones.md5_encode(txtClave.Text)
            If usuarioDatos.check_login(usuario, clave) Then
                If usuarioDatos.get_user_type(usuario) = "Administrador" Then
                    MessageBox.Show("Bienvenido administrador " & usuario & " al sistema")
                Else
                    MessageBox.Show("Bienvenido usuario " & usuario & " al sistema")
                End If
                FormLogin.ActiveForm.Hide()
                Dim formHome As New FormHome(usuario)
                formHome.Show()
            Else
                MessageBox.Show("Login inválidos")
            End If
        End If
    End Sub

    Private Sub frmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

End Class