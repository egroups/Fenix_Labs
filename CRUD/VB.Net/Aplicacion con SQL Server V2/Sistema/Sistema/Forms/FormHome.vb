' Written By Ismael Heredia in the year 2017

Imports Sistema.Aplicacion.Data

Public Class FormHome

    Dim usuarioDatos As New UsuarioDatos
    Dim usuario As String = ""

    Public Sub New(ByVal usuario_recibido As String)
        InitializeComponent()
        usuario = usuario_recibido
    End Sub

    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If usuarioDatos.get_user_type(usuario) = "Administrador" Then
            ItemUsuarios.Enabled = True
        Else
            ItemUsuarios.Enabled = False
        End If
    End Sub

    Private Sub ItemProductos_Click(sender As Object, e As EventArgs) Handles ItemProductos.Click
        Dim form As New FormProductos()
        form.Show()
    End Sub

    Private Sub ItemProveedores_Click(sender As Object, e As EventArgs) Handles ItemProveedores.Click
        Dim form As New FormProveedores()
        form.Show()
    End Sub

    Private Sub ItemUsuarios_Click(sender As Object, e As EventArgs) Handles ItemUsuarios.Click
        Dim formUsuarios As New FormUsuarios()
        formUsuarios.Show()
    End Sub

    Private Sub ItemCambiarUsuario_Click(sender As Object, e As EventArgs) Handles ItemCambiarUsuario.Click
        Dim formCambiarUsuario As New FormCambiarUsuario(usuario)
        formCambiarUsuario.Show()
    End Sub

    Private Sub ItemCambiarClave_Click(sender As Object, e As EventArgs) Handles ItemCambiarClave.Click
        Dim formCambiarContraseña As New FormCambiarClave(usuario)
        formCambiarContraseña.Show()
    End Sub

    Private Sub ItemSalir_Click(sender As Object, e As EventArgs) Handles ItemSalir.Click
        If MessageBox.Show("¿ Esta seguro de salir del programa ?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub ItemEstadisticas_Click(sender As Object, e As EventArgs) Handles ItemEstadisticas.Click
        Dim formReporte As New FormReporte()
        formReporte.Show()
    End Sub

    Private Sub frmHome_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

End Class