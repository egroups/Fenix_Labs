' Written By Ismael Heredia in the year 2017

Imports Sistema.Aplicacion.Data

Public Class FormProveedores


    Dim proveedorDatos As New ProveedorDatos
    Dim funcion As New Funciones()
    Dim nuevo As Boolean = True

    ' Funciones

    Private Function validar() As Boolean

        If txtNombre.Text = "" Then
            MessageBox.Show("Ingrese el nombre")
            txtNombre.Focus()
            Return False
        End If

        If txtDireccion.Text = "" Then
            MessageBox.Show("Ingrese la direccion")
            txtDireccion.Focus()
            Return False
        End If

        If txtTelefono.Text = "" OrElse Not funcion.valid_number(txtTelefono.Text) Then
            MessageBox.Show("Ingrese el telefono")
            txtTelefono.Focus()
            Return False
        End If

        Return True

    End Function

    Private Sub cargarListaProveedores()
        lvProveedores.Items.Clear()
        Dim nombre_buscar As String = txtBuscar.Text
        Dim listaProveedores As List(Of Proveedor) = proveedorDatos.List(nombre_buscar)
        For Each proveedor As Proveedor In listaProveedores
            Dim item As New ListViewItem()
            item.Text = Convert.ToString(proveedor.nombre)
            item.SubItems.Add(Convert.ToString(proveedor.direccion))
            item.SubItems.Add(Convert.ToString(proveedor.telefono))
            item.SubItems.Add(Convert.ToString(proveedor.fecha_registro))
            item.Tag = Convert.ToString(proveedor.id)
            lvProveedores.Items.Add(item)
        Next
    End Sub

    Private Sub CargarCamposProveedor(id As Integer)
        Dim proveedor As Proveedor = proveedorDatos.Obtain(id)
        txtID.Text = Convert.ToString(proveedor.id)
        txtNombre.Text = proveedor.nombre
        txtDireccion.Text = proveedor.direccion
        txtTelefono.Text = proveedor.telefono.ToString()
    End Sub

    Private Sub limpiar()
        nuevo = True
        txtID.Text = ""
        txtNombre.Text = ""
        txtDireccion.Text = ""
        txtTelefono.Text = ""
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        recargarLista()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        grabar()
    End Sub

    Private Sub FormProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        recargarLista()
    End Sub

    Private Sub lvProveedores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvProveedores.SelectedIndexChanged
        If lvProveedores.SelectedIndices.Count > 0 AndAlso lvProveedores.SelectedIndices(0) <> -1 Then
            CargarCamposProveedor(Convert.ToInt32((lvProveedores.SelectedItems(0).Tag)))
        End If
    End Sub


    Private Sub grabar()
        If validar() Then

            Dim proveedor As New Proveedor()
            If txtID.Text <> "" Then
                proveedor.id = Convert.ToInt32(txtID.Text)
            End If
            proveedor.nombre = txtNombre.Text
            proveedor.direccion = txtDireccion.Text
            proveedor.telefono = Convert.ToInt32(txtTelefono.Text)
            proveedor.fecha_registro = funcion.fecha_del_dia()

            Dim grabar_ready As Boolean = False
            If nuevo Then
                If proveedorDatos.check_exists_proveedor_add(proveedor.nombre) Then
                    grabar_ready = False
                Else
                    grabar_ready = True
                End If
            Else
                If proveedorDatos.check_exists_proveedor_edit(proveedor.id,proveedor.nombre) Then
                    grabar_ready = False
                Else
                    grabar_ready = True
                End If
            End If

            If grabar_ready Then
                If nuevo Then
                    If (proveedorDatos.Add(proveedor)) Then
                        MessageBox.Show("Registro agregado")
                        status.Text = "[+] Registro agregado"
                        Me.Refresh()
                    Else
                        MessageBox.Show("Ha ocurrido un error en la base de datos")
                        status.Text = "[-] Ha ocurrido un error en la base de datos"
                        Me.Refresh()
                    End If
                Else
                    If (proveedorDatos.Update(proveedor)) Then
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
                MessageBox.Show("El proveedor " & proveedor.nombre & " ya existe")
                status.Text = "[-] El proveedor " & proveedor.nombre & " ya existe"
                Me.Refresh()
            End If

            cargarListaProveedores()
            limpiar()

        End If

    End Sub

    Private Sub agregar()
        status.Text = "[+] Programa en modo nuevo"
        Me.Refresh()
        nuevo = True
        limpiar()
        MessageBox.Show("Programa cargado en modo nuevo")
    End Sub


    Private Sub editar()
        status.Text = "[+] Programa en modo editar"
        Me.Refresh()
        nuevo = False
        MessageBox.Show("Programa cargado en modo editar")
    End Sub


    Private Sub borrar()

        Dim id As Integer = 0
        If lvProveedores.SelectedIndices.Count > 0 AndAlso lvProveedores.SelectedIndices(0) <> -1 Then
            id = Convert.ToInt32((lvProveedores.SelectedItems(0).Tag))
        End If

        Dim proveedor As Proveedor = proveedorDatos.Obtain(id)
        If MessageBox.Show("Seguro de borrar a " & proveedor.nombre, "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            lvProveedores.Items.Clear()
            Dim sql As String = "delete from proveedores where id_proveedor=" & proveedor.id
            If proveedorDatos.Delete(proveedor) Then
                MessageBox.Show("Registro borrado")
                status.Text = "[+] Registro borrado"
                Me.Refresh()
            Else
                MessageBox.Show("Ha ocurrido un error en la base de datos")
                status.Text = "[-] Ha ocurrido un error en la base de datos"
                Me.Refresh()

            End If

            cargarListaProveedores()
            limpiar()

        End If

    End Sub


    Private Sub cancelar()
        status.Text = "[+] Programa cargado"
        Me.Refresh()
        nuevo = False
        limpiar()
        MessageBox.Show("Opcion cancelada")
    End Sub


    Private Sub recargarLista()
        cargarListaProveedores()
    End Sub


    Private Sub ItemAgregarProveedor_Click(sender As Object, e As EventArgs) Handles AgregarProveedorToolStripMenuItem.Click
        agregar()
    End Sub

    Private Sub ItemEditarProveedor_Click(sender As Object, e As EventArgs) Handles EditarProveedorToolStripMenuItem.Click
        editar()
    End Sub
    Private Sub ItemBorrarProveedor_Click(sender As Object, e As EventArgs) Handles BorrarProveedorToolStripMenuItem.Click
        borrar()
    End Sub

    Private Sub ItemCancelar_Click(sender As Object, e As EventArgs) Handles CancelarToolStripMenuItem.Click
        cancelar()
    End Sub

    Private Sub ItemRecargarLista_Click(sender As Object, e As EventArgs) Handles RecargarListaToolStripMenuItem.Click
        recargarLista()
    End Sub

    Private Sub ItemGrabar_Click(sender As Object, e As EventArgs) Handles GrabarToolStripMenuItem.Click
        grabar()
    End Sub


    Private Sub AgregarProveedorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AgregarProveedorToolStripMenuItem1.Click
        agregar()
    End Sub

    Private Sub EditarProveedorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditarProveedorToolStripMenuItem1.Click
        editar()
    End Sub

    Private Sub BorrarProveedorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BorrarProveedorToolStripMenuItem1.Click
        borrar()
    End Sub

    Private Sub CancelarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CancelarToolStripMenuItem1.Click
        cancelar()
    End Sub

    Private Sub RecargarListaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RecargarListaToolStripMenuItem1.Click
        recargarLista()
    End Sub

    Private Sub GrabarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GrabarToolStripMenuItem1.Click
        grabar()
    End Sub

End Class