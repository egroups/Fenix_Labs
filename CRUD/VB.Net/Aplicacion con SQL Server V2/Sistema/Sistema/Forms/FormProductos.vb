' Written By Ismael Heredia in the year 2017

Imports Sistema.Aplicacion.Data
Imports System.Collections.Generic

Public Class FormProductos

    Dim productoDatos As New ProductoDatos
    Dim proveedorDatos As New ProveedorDatos
    Dim funcion As New Funciones()
    Dim nuevo As Boolean = True

    Private Sub cargarListaProductos()
        lvProductos.Items.Clear()
        Dim nombre_buscar As String = txtNombreBuscar.Text
        Dim listaProductos As List(Of Producto) = productoDatos.List(nombre_buscar)
        For Each producto As Producto In listaProductos
            Dim item As New ListViewItem()
            item.Text = Convert.ToString(producto.nombre)
            item.SubItems.Add(Convert.ToString(producto.descripcion))
            item.SubItems.Add(Convert.ToString(producto.precio))
            item.SubItems.Add(Convert.ToString(producto.proveedor.nombre))
            item.SubItems.Add(Convert.ToString(producto.fecha_registro))
            item.Tag = Convert.ToString(producto.id)
            lvProductos.Items.Add(item)
        Next
    End Sub

    Private Function validar() As Boolean

        If txtNombre.Text = "" Then
            MessageBox.Show("Ingrese nombre")
            txtNombre.Focus()
            Return False
        End If
        If rtbDescripcion.Text = "" Then
            MessageBox.Show("Ingrese descripcion")
            rtbDescripcion.Focus()
            Return False
        End If
        If cmbProveedor.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione proveedor")
            cmbProveedor.Focus()
            Return False
        End If
        If txtPrecio.Text = "" Then
            MessageBox.Show("Ingrese precio")
            txtPrecio.Focus()
            Return False
        End If

        Return True

    End Function

    Private Sub cargarComboProveedores()
        Dim listaProveedores As List(Of Proveedor) = proveedorDatos.List("")
        Dim lista As New Dictionary(Of String, String)()
        For Each proveedor As Proveedor In listaProveedores
            lista.Add(proveedor.id, proveedor.nombre)
        Next
        cmbProveedor.DataSource = New BindingSource(lista, Nothing)
        cmbProveedor.DisplayMember = "Value"
        cmbProveedor.ValueMember = "Key"
    End Sub

    Private Sub limpiar()
        nuevo = True
        txtID.Text = ""
        txtNombre.Text = ""
        rtbDescripcion.Text = ""
        txtPrecio.Text = ""
        cmbProveedor.SelectedIndex = -1
    End Sub

    Private Sub CargarCamposProducto(id As Integer)
        Dim producto As Producto = productoDatos.Obtain(id)
        txtID.Text = producto.id.ToString()
        txtNombre.Text = producto.nombre
        rtbDescripcion.Text = producto.descripcion

        cmbProveedor.SelectedValue = producto.proveedor.id.ToString()

        txtPrecio.Text = producto.precio.ToString()
    End Sub

    Private Sub grabar()
        If validar() Then

            Dim producto As New Producto()
            If txtID.Text <> "" Then
                producto.id = Convert.ToInt32(txtID.Text)
            End If
            producto.nombre = txtNombre.Text
            producto.descripcion = rtbDescripcion.Text
            producto.precio = Convert.ToDouble(txtPrecio.Text)
            producto.id_proveedor = Convert.ToInt32(cmbProveedor.SelectedValue)
            producto.fecha_registro = funcion.fecha_del_dia()

            Dim grabar_ready As Boolean = False
            If nuevo Then
                If productoDatos.check_exists_producto_add(producto.nombre) Then
                    grabar_ready = False
                Else
                    grabar_ready = True
                End If
            Else
                If productoDatos.check_exists_producto_edit(producto.id, producto.nombre) Then
                    grabar_ready = False
                Else
                    grabar_ready = True
                End If
            End If

            If grabar_ready Then
                If nuevo Then
                    If (productoDatos.Add(producto)) Then
                        MessageBox.Show("Registro agregado")
                        status.Text = "[+] Registro agregado"
                        Me.Refresh()
                    Else
                        MessageBox.Show("Ha ocurrido un error en la base de datos")
                        status.Text = "[-] Ha ocurrido un error en la base de datos"
                        Me.Refresh()
                    End If
                Else
                    If (productoDatos.Update(producto)) Then
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
                MessageBox.Show("El producto " & producto.nombre & " ya existe")
                status.Text = "[-] El producto " & producto.nombre & " ya existe"
                Me.Refresh()
            End If

                cargarListaProductos()
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
        If lvProductos.SelectedIndices.Count > 0 AndAlso lvProductos.SelectedIndices(0) <> -1 Then
            id = Convert.ToInt32((lvProductos.SelectedItems(0).Tag))
        End If
        Dim producto As Producto = productoDatos.Obtain(id)
        If MessageBox.Show("Seguro de borrar a " & producto.nombre, "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            lvProductos.Items.Clear()
            Dim sql As String = "delete from productos where id_producto=" & producto.id
            If productoDatos.Delete(producto) Then
                MessageBox.Show("Registro borrado")
                status.Text = "[+] Registro borrado"
                Me.Refresh()
            Else
                MessageBox.Show("Ha ocurrido un error en la base de datos")
                status.Text = "[-] Ha ocurrido un error en la base de datos"
                Me.Refresh()
            End If

            cargarListaProductos()
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
        cargarListaProductos()
    End Sub


    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        grabar()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        recargarLista()
    End Sub

    Private Sub ItemAgregarProducto_Click(sender As Object, e As EventArgs) Handles AgregarProductoToolStripMenuItem.Click
        agregar()
    End Sub

    Private Sub ItemEditarProducto_Click(sender As Object, e As EventArgs) Handles EditarProductoToolStripMenuItem.Click
        editar()
    End Sub
    Private Sub ItemBorrarProducto_Click(sender As Object, e As EventArgs) Handles BorrarProductoToolStripMenuItem.Click
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

    Private Sub AgregarProductoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AgregarProductoToolStripMenuItem1.Click
        agregar()
    End Sub

    Private Sub EditarProductoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditarProductoToolStripMenuItem1.Click
        editar()
    End Sub

    Private Sub BorrarProductoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BorrarProductoToolStripMenuItem1.Click
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

    Private Sub FormProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarComboProveedores()
        recargarLista()
    End Sub

    Private Sub lvProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvProductos.SelectedIndexChanged
        If lvProductos.SelectedIndices.Count > 0 AndAlso lvProductos.SelectedIndices(0) <> -1 Then
            CargarCamposProducto(Convert.ToInt32((lvProductos.SelectedItems(0).Tag)))
        End If
    End Sub

End Class