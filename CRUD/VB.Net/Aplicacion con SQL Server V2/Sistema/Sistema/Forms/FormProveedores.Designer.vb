<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProveedores
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.msOpciones = New System.Windows.Forms.MenuStrip()
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargarListaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrabarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbProveedor = New System.Windows.Forms.GroupBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.gbProveedores = New System.Windows.Forms.GroupBox()
        Me.lvProveedores = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarProveedorToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarProveedorToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarProveedorToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargarListaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrabarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lblNombreBuscar = New System.Windows.Forms.Label()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.msOpciones.SuspendLayout()
        Me.gbProveedor.SuspendLayout()
        Me.gbProveedores.SuspendLayout()
        Me.cmsOpciones.SuspendLayout()
        Me.ssStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'msOpciones
        '
        Me.msOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpcionesToolStripMenuItem})
        Me.msOpciones.Location = New System.Drawing.Point(0, 0)
        Me.msOpciones.Name = "msOpciones"
        Me.msOpciones.Size = New System.Drawing.Size(622, 24)
        Me.msOpciones.TabIndex = 0
        Me.msOpciones.Text = "MenuStrip1"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarProveedorToolStripMenuItem, Me.EditarProveedorToolStripMenuItem, Me.BorrarProveedorToolStripMenuItem, Me.CancelarToolStripMenuItem, Me.RecargarListaToolStripMenuItem, Me.GrabarToolStripMenuItem})
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        '
        'AgregarProveedorToolStripMenuItem
        '
        Me.AgregarProveedorToolStripMenuItem.Name = "AgregarProveedorToolStripMenuItem"
        Me.AgregarProveedorToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.AgregarProveedorToolStripMenuItem.Text = "Agregar Proveedor"
        '
        'EditarProveedorToolStripMenuItem
        '
        Me.EditarProveedorToolStripMenuItem.Name = "EditarProveedorToolStripMenuItem"
        Me.EditarProveedorToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.EditarProveedorToolStripMenuItem.Text = "Editar Proveedor"
        '
        'BorrarProveedorToolStripMenuItem
        '
        Me.BorrarProveedorToolStripMenuItem.Name = "BorrarProveedorToolStripMenuItem"
        Me.BorrarProveedorToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.BorrarProveedorToolStripMenuItem.Text = "Borrar Proveedor"
        '
        'CancelarToolStripMenuItem
        '
        Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
        Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.CancelarToolStripMenuItem.Text = "Cancelar"
        '
        'RecargarListaToolStripMenuItem
        '
        Me.RecargarListaToolStripMenuItem.Name = "RecargarListaToolStripMenuItem"
        Me.RecargarListaToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.RecargarListaToolStripMenuItem.Text = "Recargar Lista"
        '
        'GrabarToolStripMenuItem
        '
        Me.GrabarToolStripMenuItem.Name = "GrabarToolStripMenuItem"
        Me.GrabarToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.GrabarToolStripMenuItem.Text = "Grabar"
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.btnGrabar)
        Me.gbProveedor.Controls.Add(Me.txtID)
        Me.gbProveedor.Controls.Add(Me.txtTelefono)
        Me.gbProveedor.Controls.Add(Me.txtDireccion)
        Me.gbProveedor.Controls.Add(Me.txtNombre)
        Me.gbProveedor.Controls.Add(Me.lblTelefono)
        Me.gbProveedor.Controls.Add(Me.lblDireccion)
        Me.gbProveedor.Controls.Add(Me.lblNombre)
        Me.gbProveedor.Location = New System.Drawing.Point(12, 48)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(234, 204)
        Me.gbProveedor.TabIndex = 1
        Me.gbProveedor.TabStop = False
        Me.gbProveedor.Text = "Datos del Proveedor"
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(54, 151)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(113, 23)
        Me.btnGrabar.TabIndex = 7
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(17, 126)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(42, 20)
        Me.txtID.TabIndex = 6
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(83, 100)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(133, 20)
        Me.txtTelefono.TabIndex = 5
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(83, 65)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(133, 20)
        Me.txtDireccion.TabIndex = 4
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(83, 29)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(133, 20)
        Me.txtNombre.TabIndex = 3
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Location = New System.Drawing.Point(24, 100)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(58, 13)
        Me.lblTelefono.TabIndex = 2
        Me.lblTelefono.Text = "Telefono : "
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.Location = New System.Drawing.Point(24, 68)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(61, 13)
        Me.lblDireccion.TabIndex = 1
        Me.lblDireccion.Text = "Direccion : "
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(24, 29)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(53, 13)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "Nombre : "
        '
        'gbProveedores
        '
        Me.gbProveedores.Controls.Add(Me.lvProveedores)
        Me.gbProveedores.Controls.Add(Me.btnBuscar)
        Me.gbProveedores.Controls.Add(Me.txtBuscar)
        Me.gbProveedores.Controls.Add(Me.lblNombreBuscar)
        Me.gbProveedores.Location = New System.Drawing.Point(264, 48)
        Me.gbProveedores.Name = "gbProveedores"
        Me.gbProveedores.Size = New System.Drawing.Size(346, 204)
        Me.gbProveedores.TabIndex = 2
        Me.gbProveedores.TabStop = False
        Me.gbProveedores.Text = "Proveedores"
        '
        'lvProveedores
        '
        Me.lvProveedores.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvProveedores.ContextMenuStrip = Me.cmsOpciones
        Me.lvProveedores.FullRowSelect = True
        Me.lvProveedores.GridLines = True
        Me.lvProveedores.Location = New System.Drawing.Point(26, 77)
        Me.lvProveedores.Name = "lvProveedores"
        Me.lvProveedores.Size = New System.Drawing.Size(301, 109)
        Me.lvProveedores.TabIndex = 3
        Me.lvProveedores.UseCompatibleStateImageBehavior = False
        Me.lvProveedores.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 123
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Direccion"
        Me.ColumnHeader2.Width = 97
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Telefono"
        Me.ColumnHeader3.Width = 77
        '
        'cmsOpciones
        '
        Me.cmsOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarProveedorToolStripMenuItem1, Me.EditarProveedorToolStripMenuItem1, Me.BorrarProveedorToolStripMenuItem1, Me.CancelarToolStripMenuItem1, Me.RecargarListaToolStripMenuItem1, Me.GrabarToolStripMenuItem1})
        Me.cmsOpciones.Name = "cmsOpciones"
        Me.cmsOpciones.Size = New System.Drawing.Size(174, 136)
        '
        'AgregarProveedorToolStripMenuItem1
        '
        Me.AgregarProveedorToolStripMenuItem1.Name = "AgregarProveedorToolStripMenuItem1"
        Me.AgregarProveedorToolStripMenuItem1.Size = New System.Drawing.Size(173, 22)
        Me.AgregarProveedorToolStripMenuItem1.Text = "Agregar Proveedor"
        '
        'EditarProveedorToolStripMenuItem1
        '
        Me.EditarProveedorToolStripMenuItem1.Name = "EditarProveedorToolStripMenuItem1"
        Me.EditarProveedorToolStripMenuItem1.Size = New System.Drawing.Size(173, 22)
        Me.EditarProveedorToolStripMenuItem1.Text = "Editar Proveedor"
        '
        'BorrarProveedorToolStripMenuItem1
        '
        Me.BorrarProveedorToolStripMenuItem1.Name = "BorrarProveedorToolStripMenuItem1"
        Me.BorrarProveedorToolStripMenuItem1.Size = New System.Drawing.Size(173, 22)
        Me.BorrarProveedorToolStripMenuItem1.Text = "Borrar Proveedor"
        '
        'CancelarToolStripMenuItem1
        '
        Me.CancelarToolStripMenuItem1.Name = "CancelarToolStripMenuItem1"
        Me.CancelarToolStripMenuItem1.Size = New System.Drawing.Size(173, 22)
        Me.CancelarToolStripMenuItem1.Text = "Cancelar"
        '
        'RecargarListaToolStripMenuItem1
        '
        Me.RecargarListaToolStripMenuItem1.Name = "RecargarListaToolStripMenuItem1"
        Me.RecargarListaToolStripMenuItem1.Size = New System.Drawing.Size(173, 22)
        Me.RecargarListaToolStripMenuItem1.Text = "Recargar Lista"
        '
        'GrabarToolStripMenuItem1
        '
        Me.GrabarToolStripMenuItem1.Name = "GrabarToolStripMenuItem1"
        Me.GrabarToolStripMenuItem1.Size = New System.Drawing.Size(173, 22)
        Me.GrabarToolStripMenuItem1.Text = "Grabar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(252, 30)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(82, 33)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(164, 20)
        Me.txtBuscar.TabIndex = 1
        '
        'lblNombreBuscar
        '
        Me.lblNombreBuscar.AutoSize = True
        Me.lblNombreBuscar.Location = New System.Drawing.Point(23, 36)
        Me.lblNombreBuscar.Name = "lblNombreBuscar"
        Me.lblNombreBuscar.Size = New System.Drawing.Size(53, 13)
        Me.lblNombreBuscar.TabIndex = 0
        Me.lblNombreBuscar.Text = "Nombre : "
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status})
        Me.ssStatus.Location = New System.Drawing.Point(0, 265)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(622, 22)
        Me.ssStatus.TabIndex = 3
        Me.ssStatus.Text = "StatusStrip1"
        '
        'status
        '
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(105, 17)
        Me.status.Text = "Programa cargado"
        '
        'frmProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 287)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.gbProveedores)
        Me.Controls.Add(Me.gbProveedor)
        Me.Controls.Add(Me.msOpciones)
        Me.MaximizeBox = False
        Me.Name = "frmProveedores"
        Me.Text = "Proveedores"
        Me.msOpciones.ResumeLayout(False)
        Me.msOpciones.PerformLayout()
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        Me.gbProveedores.ResumeLayout(False)
        Me.gbProveedores.PerformLayout()
        Me.cmsOpciones.ResumeLayout(False)
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents msOpciones As System.Windows.Forms.MenuStrip
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgregarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecargarListaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents gbProveedores As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreBuscar As System.Windows.Forms.Label
    Friend WithEvents lvProveedores As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmsOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AgregarProveedorToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarProveedorToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarProveedorToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecargarListaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
