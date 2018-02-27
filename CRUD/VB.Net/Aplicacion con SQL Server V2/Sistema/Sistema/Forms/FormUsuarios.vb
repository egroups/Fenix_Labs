' Written By Ismael Heredia in the year 2017

Imports Sistema.Aplicacion.Data

Public Class FormUsuarios

    Dim usuarioDatos As New UsuarioDatos
    Dim tipoUsuarioDatos As New TipoUsuarioDatos
    Dim funcion As New Funciones()
    Dim nuevo As Boolean = True

    Private Sub cargarListaUsuarios()
        lvUsuarios.Items.Clear()
        Dim nombre_buscar As String = txtBuscar.Text
        Dim listaUsuarios As List(Of Usuario) = usuarioDatos.List(nombre_buscar)
        For Each usuario As Usuario In listaUsuarios
            Dim item As New ListViewItem()
            item.Text = Convert.ToString(usuario.tipo.nombre)
            item.SubItems.Add(Convert.ToString(usuario.nombre))
            item.SubItems.Add(Convert.ToString(usuario.fecha_registro))
            item.Tag = Convert.ToString(usuario.id)
            lvUsuarios.Items.Add(item)
        Next
    End Sub

    Private Sub limpiar()
        txtUsuario.Text = ""
        txtClave.Text = ""
        cmbTipo.SelectedIndex = -1
    End Sub

    Private Sub recargarLista()
        cargarListaUsuarios()
    End Sub

    Private Function validar() As Boolean

        If txtUsuario.Text = "" Then
            MessageBox.Show("Ingrese nombre de usuario")
            txtUsuario.Focus()
            Return False
        End If
        If nuevo Then
            If txtClave.Text = "" Then
                MessageBox.Show("Ingrese clave")
                txtClave.Focus()
                Return False
            End If
        End If
        If cmbTipo.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione tipo")
            cmbTipo.Focus()
            Return False
        End If

        Return True

    End Function

    Private Sub cargarComboTipoUsuario()
        Dim listaTipos As List(Of TipoUsuario) = tipoUsuarioDatos.List("")
        Dim lista As New Dictionary(Of String, String)()
        For Each tipo As TipoUsuario In listaTipos
            lista.Add(tipo.id, tipo.nombre)
        Next
        cmbTipo.DataSource = New BindingSource(lista, Nothing)
        cmbTipo.DisplayMember = "Value"
        cmbTipo.ValueMember = "Key"
        cmbTipo.SelectedIndex = 0
    End Sub

    Private Sub CargarCamposUsuario(id As Integer)
        Dim usuario As Usuario = usuarioDatos.Obtain(id)
        txtID.Text = Convert.ToString(usuario.id)
        txtUsuario.Text = usuario.nombre
        cmbTipo.SelectedValue = usuario.tipo.id.ToString()
    End Sub

    Private Sub grabar()
        If validar() Then

            Dim usuario As New Usuario()
            Dim clave As String = funcion.md5_encode(txtClave.Text)

            If txtID.Text <> "" Then
                usuario.id = Convert.ToInt32(txtID.Text)
            End If
            usuario.nombre = txtUsuario.Text
            usuario.clave = clave
            usuario.id_tipo = Convert.ToInt32(cmbTipo.SelectedValue)
            usuario.fecha_registro = funcion.fecha_del_dia()

            Dim grabar_ready As Boolean = False

            If (nuevo = True) Then
                If usuarioDatos.check_exists_usuario_add(usuario.nombre) Then
                    grabar_ready = False
                Else
                    grabar_ready = True
                End If
            Else
                grabar_ready = True
            End If

            If grabar_ready Then
                If nuevo Then
                    If (usuarioDatos.Add(usuario)) Then
                        MessageBox.Show("Registro agregado")
                        status.Text = "[+] Registro agregado"
                        Me.Refresh()
                    Else
                        MessageBox.Show("Ha ocurrido un error en la base de datos")
                        status.Text = "[-] Ha ocurrido un error en la base de datos"
                        Me.Refresh()
                    End If
                Else
                    If (usuarioDatos.Update(usuario)) Then
                        MessageBox.Show("Registro actualizado")
                        status.Text = "[+] Registro actualizado"
                        Me.Refresh()
                    Else
                        MessageBox.Show("Ha ocurrido un error en la base de datos")
                        status.Text = "[-] Ha ocurrido un error en la base de datos"
                        Me.Refresh()
                    End If
                End If
            Else
                MessageBox.Show("El usuario " & usuario.nombre & " ya existe")
                status.Text = "[-] El usuario " & usuario.nombre & " ya existe"
                Me.Refresh()
            End If

            cargarListaUsuarios()
            limpiar()
        End If

    End Sub


    Private Sub agregar()

        nuevo = True
        txtID.Text = ""
        txtUsuario.Text = ""
        txtClave.Text = ""
        txtID.Enabled = True
        txtUsuario.Enabled = True
        txtClave.Enabled = True
        cmbTipo.SelectedIndex = 0
        status.Text = "[+] Programa en modo nuevo"
        Me.Refresh()
        limpiar()
        MessageBox.Show("Programa cargado en modo nuevo")
    End Sub

    Private Sub editar()
        nuevo = False
        txtID.Enabled = False
        txtUsuario.Enabled = False
        txtClave.Enabled = False
        status.Text = "[+] Programa en modo editar"
        Me.Refresh()
        nuevo = False
        MessageBox.Show("Programa cargado en modo editar")
    End Sub

    Private Sub borrar()
        Dim id As Integer = 0
        If lvUsuarios.SelectedIndices.Count > 0 AndAlso lvUsuarios.SelectedIndices(0) <> -1 Then
            id = Convert.ToInt32((lvUsuarios.SelectedItems(0).Tag))
        End If

        Dim usuario As Usuario = usuarioDatos.Obtain(id)
        If MessageBox.Show("Seguro de borrar a " & usuario.nombre, "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            lvUsuarios.Items.Clear()

            If (usuarioDatos.Delete(usuario)) Then
                MessageBox.Show("Registro borrado")
                status.Text = "[+] Registro borrado"
                Me.Refresh()
            Else
                MessageBox.Show("Ha ocurrido un error en la base de datos")
                status.Text = "[-] Ha ocurrido un error en la base de datos"
                Me.Refresh()
            End If

            cargarListaUsuarios()
            limpiar()

        End If

    End Sub


    Private Sub asignar(tipo_usuario As String)
        Dim id As Integer = 0
        If lvUsuarios.SelectedIndices.Count > 0 AndAlso lvUsuarios.SelectedIndices(0) <> -1 Then
            id = Convert.ToInt32((lvUsuarios.SelectedItems(0).Tag))
        End If

        Dim usuario As Usuario = usuarioDatos.Obtain(id)
        Dim nombre_usuario As String = usuario.pNombre
        Dim id_tipo As Integer = 0
        Dim rango As String = ""

        If tipo_usuario = "admin" Then
            id_tipo = 1
            rango = "Administrador"
        ElseIf tipo_usuario = "user" Then
            id_tipo = 2
            rango = "Usuario"
        Else
            id_tipo = 2
            rango = "Usuario"
        End If

        usuario.id_tipo = id_tipo

        If MessageBox.Show("Seguro de asignar como " & rango & " a " & nombre_usuario, "Asignar", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            lvUsuarios.Items.Clear()
            If (usuarioDatos.Update(usuario)) Then
                status.Text = "[+] Asignacion realizada"
                Me.Refresh()
                limpiar()
                MessageBox.Show("Asignacion realizada")
            Else
                MessageBox.Show("Ha ocurrido un error en la base de datos")
                status.Text = "[-] Ha ocurrido un error en la base de datos"
                Me.Refresh()
            End If

            cargarListaUsuarios()

        End If

    End Sub


    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        grabar()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        recargarLista()
    End Sub

    Private Sub FormUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarComboTipoUsuario()
        recargarLista()
    End Sub

    Private Sub lvUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvUsuarios.SelectedIndexChanged
        If lvUsuarios.SelectedIndices.Count > 0 AndAlso lvUsuarios.SelectedIndices(0) <> -1 Then
            CargarCamposUsuario(Convert.ToInt32((lvUsuarios.SelectedItems(0).Tag)))
        End If
    End Sub

    Private Sub ItemAgregarUsuario_Click(sender As Object, e As EventArgs) Handles AgregarUsuarioToolStripMenuItem.Click
        agregar()
    End Sub

    Private Sub ItemEditarUsuario_Click(sender As Object, e As EventArgs) Handles EditarUsuarioToolStripMenuItem.Click
        editar()
    End Sub

    Private Sub ItemAsignarUsuario_Click(sender As Object, e As EventArgs) Handles UsuarioToolStripMenuItem.Click
        asignar("user")
    End Sub

    Private Sub AsignarAdministrador_Click(sender As Object, e As EventArgs) Handles AdministradorToolStripMenuItem.Click
        asignar("admin")
    End Sub

    Private Sub ItemBorrarUsuario_Click(sender As Object, e As EventArgs) Handles BorrarUsuarioToolStripMenuItem.Click
        borrar()
    End Sub


    Private Sub ItemRecargarLista_Click(sender As Object, e As EventArgs) Handles RecargarListaToolStripMenuItem.Click
        recargarLista()
    End Sub

    Private Sub ItemGrabar_Click(sender As Object, e As EventArgs) Handles GrabarToolStripMenuItem.Click
        grabar()
    End Sub

    Private Sub AgregarUsuarioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AgregarUsuarioToolStripMenuItem1.Click
        agregar()
    End Sub

    Private Sub EditarUsuarioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditarUsuarioToolStripMenuItem1.Click
        editar()
    End Sub

    Private Sub UsuarioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UsuarioToolStripMenuItem1.Click
        asignar("user")
    End Sub

    Private Sub AdministradorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AdministradorToolStripMenuItem1.Click
        asignar("admin")
    End Sub

    Private Sub BorrarUsuarioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BorrarUsuarioToolStripMenuItem1.Click
        borrar()
    End Sub

    Private Sub RecargarListaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RecargarListaToolStripMenuItem1.Click
        recargarLista()
    End Sub

    Private Sub GrabarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GrabarToolStripMenuItem1.Click
        grabar()
    End Sub

End Class