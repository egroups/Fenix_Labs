<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHome
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
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.msOpciones = New System.Windows.Forms.MenuStrip()
        Me.OpcionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemProductos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemProveedores = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemUsuarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemEstadisticas = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemCambiarUsuario = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemCambiarClave = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ssStatus.SuspendLayout()
        Me.msOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status})
        Me.ssStatus.Location = New System.Drawing.Point(0, 328)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(617, 22)
        Me.ssStatus.TabIndex = 0
        '
        'status
        '
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(105, 17)
        Me.status.Text = "Programa cargado"
        '
        'msOpciones
        '
        Me.msOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpcionesToolStripMenuItem, Me.ItemEstadisticas, Me.CuentaToolStripMenuItem, Me.ItemSalir})
        Me.msOpciones.Location = New System.Drawing.Point(0, 0)
        Me.msOpciones.Name = "msOpciones"
        Me.msOpciones.Size = New System.Drawing.Size(617, 24)
        Me.msOpciones.TabIndex = 1
        Me.msOpciones.Text = "MenuStrip1"
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemProductos, Me.ItemProveedores, Me.ItemUsuarios})
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        '
        'ItemProductos
        '
        Me.ItemProductos.Name = "ItemProductos"
        Me.ItemProductos.Size = New System.Drawing.Size(152, 22)
        Me.ItemProductos.Text = "Productos"
        '
        'ItemProveedores
        '
        Me.ItemProveedores.Name = "ItemProveedores"
        Me.ItemProveedores.Size = New System.Drawing.Size(152, 22)
        Me.ItemProveedores.Text = "Proveedores"
        '
        'ItemUsuarios
        '
        Me.ItemUsuarios.Name = "ItemUsuarios"
        Me.ItemUsuarios.Size = New System.Drawing.Size(152, 22)
        Me.ItemUsuarios.Text = "Usuarios"
        '
        'ItemEstadisticas
        '
        Me.ItemEstadisticas.Name = "ItemEstadisticas"
        Me.ItemEstadisticas.Size = New System.Drawing.Size(79, 20)
        Me.ItemEstadisticas.Text = "Estadisticas"
        '
        'CuentaToolStripMenuItem
        '
        Me.CuentaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemCambiarUsuario, Me.ItemCambiarClave})
        Me.CuentaToolStripMenuItem.Name = "CuentaToolStripMenuItem"
        Me.CuentaToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.CuentaToolStripMenuItem.Text = "Cuenta"
        '
        'ItemCambiarUsuario
        '
        Me.ItemCambiarUsuario.Name = "ItemCambiarUsuario"
        Me.ItemCambiarUsuario.Size = New System.Drawing.Size(222, 22)
        Me.ItemCambiarUsuario.Text = "Cambiar nombre de usuario"
        '
        'ItemCambiarClave
        '
        Me.ItemCambiarClave.Name = "ItemCambiarClave"
        Me.ItemCambiarClave.Size = New System.Drawing.Size(222, 22)
        Me.ItemCambiarClave.Text = "Cambiar clave"
        '
        'ItemSalir
        '
        Me.ItemSalir.Name = "ItemSalir"
        Me.ItemSalir.Size = New System.Drawing.Size(41, 20)
        Me.ItemSalir.Text = "Salir"
        '
        'FormHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 350)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.msOpciones)
        Me.MainMenuStrip = Me.msOpciones
        Me.MaximizeBox = False
        Me.Name = "FormHome"
        Me.Text = "Home"
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.msOpciones.ResumeLayout(False)
        Me.msOpciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents msOpciones As System.Windows.Forms.MenuStrip
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemProductos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemProveedores As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemUsuarios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemEstadisticas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CuentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemCambiarUsuario As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemCambiarClave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemSalir As System.Windows.Forms.ToolStripMenuItem
End Class
