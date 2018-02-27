<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductos
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
        Me.AgregarProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargarListaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrabarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbProducto = New System.Windows.Forms.GroupBox()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.rtbDescripcion = New System.Windows.Forms.RichTextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.gbProductos = New System.Windows.Forms.GroupBox()
        Me.lvProductos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarProductoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarProductoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarProductoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargarListaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrabarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtNombreBuscar = New System.Windows.Forms.TextBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.msOpciones.SuspendLayout()
        Me.gbProducto.SuspendLayout()
        Me.gbProductos.SuspendLayout()
        Me.cmsOpciones.SuspendLayout()
        Me.ssStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'msOpciones
        '
        Me.msOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpcionesToolStripMenuItem})
        Me.msOpciones.Location = New System.Drawing.Point(0, 0)
        Me.msOpciones.Name = "msOpciones"
        Me.msOpciones.Size = New System.Drawing.Size(739, 24)
        Me.msOpciones.TabIndex = 0
        Me.msOpciones.Text = "MenuStrip1"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarProductoToolStripMenuItem, Me.EditarProductoToolStripMenuItem, Me.BorrarProductoToolStripMenuItem, Me.CancelarToolStripMenuItem, Me.RecargarListaToolStripMenuItem, Me.GrabarToolStripMenuItem})
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        '
        'AgregarProductoToolStripMenuItem
        '
        Me.AgregarProductoToolStripMenuItem.Name = "AgregarProductoToolStripMenuItem"
        Me.AgregarProductoToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AgregarProductoToolStripMenuItem.Text = "Agregar Producto"
        '
        'EditarProductoToolStripMenuItem
        '
        Me.EditarProductoToolStripMenuItem.Name = "EditarProductoToolStripMenuItem"
        Me.EditarProductoToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.EditarProductoToolStripMenuItem.Text = "Editar Producto"
        '
        'BorrarProductoToolStripMenuItem
        '
        Me.BorrarProductoToolStripMenuItem.Name = "BorrarProductoToolStripMenuItem"
        Me.BorrarProductoToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.BorrarProductoToolStripMenuItem.Text = "Borrar Producto"
        '
        'CancelarToolStripMenuItem
        '
        Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
        Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CancelarToolStripMenuItem.Text = "Cancelar"
        '
        'RecargarListaToolStripMenuItem
        '
        Me.RecargarListaToolStripMenuItem.Name = "RecargarListaToolStripMenuItem"
        Me.RecargarListaToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.RecargarListaToolStripMenuItem.Text = "Recargar Lista"
        '
        'GrabarToolStripMenuItem
        '
        Me.GrabarToolStripMenuItem.Name = "GrabarToolStripMenuItem"
        Me.GrabarToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.GrabarToolStripMenuItem.Text = "Grabar"
        '
        'gbProducto
        '
        Me.gbProducto.Controls.Add(Me.cmbProveedor)
        Me.gbProducto.Controls.Add(Me.btnGrabar)
        Me.gbProducto.Controls.Add(Me.txtPrecio)
        Me.gbProducto.Controls.Add(Me.lblPrecio)
        Me.gbProducto.Controls.Add(Me.lblProveedor)
        Me.gbProducto.Controls.Add(Me.rtbDescripcion)
        Me.gbProducto.Controls.Add(Me.lblDescripcion)
        Me.gbProducto.Controls.Add(Me.txtID)
        Me.gbProducto.Controls.Add(Me.txtNombre)
        Me.gbProducto.Controls.Add(Me.lblNombre)
        Me.gbProducto.Location = New System.Drawing.Point(12, 42)
        Me.gbProducto.Name = "gbProducto"
        Me.gbProducto.Size = New System.Drawing.Size(262, 336)
        Me.gbProducto.TabIndex = 1
        Me.gbProducto.TabStop = False
        Me.gbProducto.Text = "Datos del producto"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(89, 207)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(121, 21)
        Me.cmbProveedor.TabIndex = 10
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(59, 290)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(133, 23)
        Me.btnGrabar.TabIndex = 9
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(70, 247)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecio.TabIndex = 8
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Location = New System.Drawing.Point(18, 247)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(46, 13)
        Me.lblPrecio.TabIndex = 7
        Me.lblPrecio.Text = "Precio : "
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(18, 210)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(65, 13)
        Me.lblProveedor.TabIndex = 5
        Me.lblProveedor.Text = "Proveedor : "
        '
        'rtbDescripcion
        '
        Me.rtbDescripcion.Location = New System.Drawing.Point(21, 90)
        Me.rtbDescripcion.Name = "rtbDescripcion"
        Me.rtbDescripcion.Size = New System.Drawing.Size(220, 96)
        Me.rtbDescripcion.TabIndex = 4
        Me.rtbDescripcion.Text = ""
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(18, 64)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(72, 13)
        Me.lblDescripcion.TabIndex = 3
        Me.lblDescripcion.Text = "Descripcion : "
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(163, 54)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(29, 20)
        Me.txtID.TabIndex = 2
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(77, 28)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(164, 20)
        Me.txtNombre.TabIndex = 1
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(18, 31)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(53, 13)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "Nombre : "
        '
        'gbProductos
        '
        Me.gbProductos.Controls.Add(Me.lvProductos)
        Me.gbProductos.Controls.Add(Me.btnBuscar)
        Me.gbProductos.Controls.Add(Me.txtNombreBuscar)
        Me.gbProductos.Controls.Add(Me.lblBuscar)
        Me.gbProductos.Location = New System.Drawing.Point(292, 42)
        Me.gbProductos.Name = "gbProductos"
        Me.gbProductos.Size = New System.Drawing.Size(424, 336)
        Me.gbProductos.TabIndex = 2
        Me.gbProductos.TabStop = False
        Me.gbProductos.Text = "Productos"
        '
        'lvProductos
        '
        Me.lvProductos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader4})
        Me.lvProductos.ContextMenuStrip = Me.cmsOpciones
        Me.lvProductos.FullRowSelect = True
        Me.lvProductos.GridLines = True
        Me.lvProductos.Location = New System.Drawing.Point(24, 77)
        Me.lvProductos.Name = "lvProductos"
        Me.lvProductos.Size = New System.Drawing.Size(380, 236)
        Me.lvProductos.TabIndex = 3
        Me.lvProductos.UseCompatibleStateImageBehavior = False
        Me.lvProductos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width = 68
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descripcion"
        Me.ColumnHeader2.Width = 92
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Precio"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DisplayIndex = 4
        Me.ColumnHeader5.Text = "Proveedor"
        Me.ColumnHeader5.Width = 95
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DisplayIndex = 3
        Me.ColumnHeader4.Text = "Fecha"
        '
        'cmsOpciones
        '
        Me.cmsOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarProductoToolStripMenuItem1, Me.EditarProductoToolStripMenuItem1, Me.BorrarProductoToolStripMenuItem1, Me.CancelarToolStripMenuItem1, Me.RecargarListaToolStripMenuItem1, Me.GrabarToolStripMenuItem1})
        Me.cmsOpciones.Name = "cmsOpciones"
        Me.cmsOpciones.Size = New System.Drawing.Size(169, 136)
        '
        'AgregarProductoToolStripMenuItem1
        '
        Me.AgregarProductoToolStripMenuItem1.Name = "AgregarProductoToolStripMenuItem1"
        Me.AgregarProductoToolStripMenuItem1.Size = New System.Drawing.Size(168, 22)
        Me.AgregarProductoToolStripMenuItem1.Text = "Agregar Producto"
        '
        'EditarProductoToolStripMenuItem1
        '
        Me.EditarProductoToolStripMenuItem1.Name = "EditarProductoToolStripMenuItem1"
        Me.EditarProductoToolStripMenuItem1.Size = New System.Drawing.Size(168, 22)
        Me.EditarProductoToolStripMenuItem1.Text = "Editar Producto"
        '
        'BorrarProductoToolStripMenuItem1
        '
        Me.BorrarProductoToolStripMenuItem1.Name = "BorrarProductoToolStripMenuItem1"
        Me.BorrarProductoToolStripMenuItem1.Size = New System.Drawing.Size(168, 22)
        Me.BorrarProductoToolStripMenuItem1.Text = "Borrar Producto"
        '
        'CancelarToolStripMenuItem1
        '
        Me.CancelarToolStripMenuItem1.Name = "CancelarToolStripMenuItem1"
        Me.CancelarToolStripMenuItem1.Size = New System.Drawing.Size(168, 22)
        Me.CancelarToolStripMenuItem1.Text = "Cancelar"
        '
        'RecargarListaToolStripMenuItem1
        '
        Me.RecargarListaToolStripMenuItem1.Name = "RecargarListaToolStripMenuItem1"
        Me.RecargarListaToolStripMenuItem1.Size = New System.Drawing.Size(168, 22)
        Me.RecargarListaToolStripMenuItem1.Text = "Recargar Lista"
        '
        'GrabarToolStripMenuItem1
        '
        Me.GrabarToolStripMenuItem1.Name = "GrabarToolStripMenuItem1"
        Me.GrabarToolStripMenuItem1.Size = New System.Drawing.Size(168, 22)
        Me.GrabarToolStripMenuItem1.Text = "Grabar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(277, 26)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(127, 23)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtNombreBuscar
        '
        Me.txtNombreBuscar.Location = New System.Drawing.Point(80, 28)
        Me.txtNombreBuscar.Name = "txtNombreBuscar"
        Me.txtNombreBuscar.Size = New System.Drawing.Size(191, 20)
        Me.txtNombreBuscar.TabIndex = 1
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Location = New System.Drawing.Point(21, 28)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(53, 13)
        Me.lblBuscar.TabIndex = 0
        Me.lblBuscar.Text = "Nombre : "
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status})
        Me.ssStatus.Location = New System.Drawing.Point(0, 390)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(739, 22)
        Me.ssStatus.TabIndex = 4
        Me.ssStatus.Text = "StatusStrip1"
        '
        'status
        '
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(105, 17)
        Me.status.Text = "Programa cargado"
        '
        'FormProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 412)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.gbProductos)
        Me.Controls.Add(Me.gbProducto)
        Me.Controls.Add(Me.msOpciones)
        Me.MaximizeBox = False
        Me.Name = "FormProductos"
        Me.Text = "Productos"
        Me.msOpciones.ResumeLayout(False)
        Me.msOpciones.PerformLayout()
        Me.gbProducto.ResumeLayout(False)
        Me.gbProducto.PerformLayout()
        Me.gbProductos.ResumeLayout(False)
        Me.gbProductos.PerformLayout()
        Me.cmsOpciones.ResumeLayout(False)
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents msOpciones As System.Windows.Forms.MenuStrip
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgregarProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarProductoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecargarListaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbProducto As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents rtbDescripcion As System.Windows.Forms.RichTextBox
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents gbProductos As System.Windows.Forms.GroupBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtNombreBuscar As System.Windows.Forms.TextBox
    Friend WithEvents lvProductos As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmsOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AgregarProductoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarProductoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarProductoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecargarListaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmbProveedor As System.Windows.Forms.ComboBox
End Class
