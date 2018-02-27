<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUsuarios
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
        Me.AgregarUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarTipoDeUsuarioAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministradorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargarListaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrabarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbUsuario = New System.Windows.Forms.GroupBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.ssStatus = New System.Windows.Forms.StatusStrip()
        Me.status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbUsuarios = New System.Windows.Forms.GroupBox()
        Me.lvUsuarios = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsOpciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarUsuarioToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarUsuarioToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiarTipoDeUsuarioAToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuarioToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministradorToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarUsuarioToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargarListaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrabarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.msOpciones.SuspendLayout()
        Me.gbUsuario.SuspendLayout()
        Me.ssStatus.SuspendLayout()
        Me.gbUsuarios.SuspendLayout()
        Me.cmsOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'msOpciones
        '
        Me.msOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpcionesToolStripMenuItem})
        Me.msOpciones.Location = New System.Drawing.Point(0, 0)
        Me.msOpciones.Name = "msOpciones"
        Me.msOpciones.Size = New System.Drawing.Size(720, 24)
        Me.msOpciones.TabIndex = 0
        '
        'OpcionesToolStripMenuItem
        '
        Me.OpcionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarUsuarioToolStripMenuItem, Me.EditarUsuarioToolStripMenuItem, Me.CambiarTipoDeUsuarioAToolStripMenuItem, Me.BorrarUsuarioToolStripMenuItem, Me.CancelarToolStripMenuItem, Me.RecargarListaToolStripMenuItem, Me.GrabarToolStripMenuItem})
        Me.OpcionesToolStripMenuItem.Name = "OpcionesToolStripMenuItem"
        Me.OpcionesToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.OpcionesToolStripMenuItem.Text = "Opciones"
        '
        'AgregarUsuarioToolStripMenuItem
        '
        Me.AgregarUsuarioToolStripMenuItem.Name = "AgregarUsuarioToolStripMenuItem"
        Me.AgregarUsuarioToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.AgregarUsuarioToolStripMenuItem.Text = "Agregar Usuario"
        '
        'EditarUsuarioToolStripMenuItem
        '
        Me.EditarUsuarioToolStripMenuItem.Name = "EditarUsuarioToolStripMenuItem"
        Me.EditarUsuarioToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.EditarUsuarioToolStripMenuItem.Text = "Editar Usuario"
        '
        'CambiarTipoDeUsuarioAToolStripMenuItem
        '
        Me.CambiarTipoDeUsuarioAToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuarioToolStripMenuItem, Me.AdministradorToolStripMenuItem})
        Me.CambiarTipoDeUsuarioAToolStripMenuItem.Name = "CambiarTipoDeUsuarioAToolStripMenuItem"
        Me.CambiarTipoDeUsuarioAToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.CambiarTipoDeUsuarioAToolStripMenuItem.Text = "Cambiar tipo de usuario a"
        '
        'UsuarioToolStripMenuItem
        '
        Me.UsuarioToolStripMenuItem.Name = "UsuarioToolStripMenuItem"
        Me.UsuarioToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.UsuarioToolStripMenuItem.Text = "Usuario"
        '
        'AdministradorToolStripMenuItem
        '
        Me.AdministradorToolStripMenuItem.Name = "AdministradorToolStripMenuItem"
        Me.AdministradorToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.AdministradorToolStripMenuItem.Text = "Administrador"
        '
        'BorrarUsuarioToolStripMenuItem
        '
        Me.BorrarUsuarioToolStripMenuItem.Name = "BorrarUsuarioToolStripMenuItem"
        Me.BorrarUsuarioToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.BorrarUsuarioToolStripMenuItem.Text = "Borrar Usuario"
        '
        'CancelarToolStripMenuItem
        '
        Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
        Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.CancelarToolStripMenuItem.Text = "Cancelar"
        '
        'RecargarListaToolStripMenuItem
        '
        Me.RecargarListaToolStripMenuItem.Name = "RecargarListaToolStripMenuItem"
        Me.RecargarListaToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.RecargarListaToolStripMenuItem.Text = "Recargar Lista"
        '
        'GrabarToolStripMenuItem
        '
        Me.GrabarToolStripMenuItem.Name = "GrabarToolStripMenuItem"
        Me.GrabarToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.GrabarToolStripMenuItem.Text = "Grabar"
        '
        'gbUsuario
        '
        Me.gbUsuario.Controls.Add(Me.btnGrabar)
        Me.gbUsuario.Controls.Add(Me.txtID)
        Me.gbUsuario.Controls.Add(Me.cmbTipo)
        Me.gbUsuario.Controls.Add(Me.lblTipo)
        Me.gbUsuario.Controls.Add(Me.txtClave)
        Me.gbUsuario.Controls.Add(Me.lblClave)
        Me.gbUsuario.Controls.Add(Me.txtUsuario)
        Me.gbUsuario.Controls.Add(Me.lblUsuario)
        Me.gbUsuario.Location = New System.Drawing.Point(12, 44)
        Me.gbUsuario.Name = "gbUsuario"
        Me.gbUsuario.Size = New System.Drawing.Size(269, 189)
        Me.gbUsuario.TabIndex = 1
        Me.gbUsuario.TabStop = False
        Me.gbUsuario.Text = "Datos de usuario"
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(88, 145)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(109, 23)
        Me.btnGrabar.TabIndex = 7
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(23, 147)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(50, 20)
        Me.txtID.TabIndex = 6
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(63, 107)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipo.TabIndex = 5
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Location = New System.Drawing.Point(20, 107)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(37, 13)
        Me.lblTipo.TabIndex = 4
        Me.lblTipo.Text = "Tipo : "
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(79, 69)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(171, 20)
        Me.txtClave.TabIndex = 3
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Location = New System.Drawing.Point(20, 72)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(43, 13)
        Me.lblClave.TabIndex = 2
        Me.lblClave.Text = "Clave : "
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(79, 31)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(171, 20)
        Me.txtUsuario.TabIndex = 1
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(20, 31)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(53, 13)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.Text = "Nombre : "
        '
        'ssStatus
        '
        Me.ssStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status})
        Me.ssStatus.Location = New System.Drawing.Point(0, 246)
        Me.ssStatus.Name = "ssStatus"
        Me.ssStatus.Size = New System.Drawing.Size(720, 22)
        Me.ssStatus.TabIndex = 2
        Me.ssStatus.Text = "StatusStrip1"
        '
        'status
        '
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(105, 17)
        Me.status.Text = "Programa cargado"
        '
        'gbUsuarios
        '
        Me.gbUsuarios.Controls.Add(Me.lvUsuarios)
        Me.gbUsuarios.Controls.Add(Me.btnBuscar)
        Me.gbUsuarios.Controls.Add(Me.txtBuscar)
        Me.gbUsuarios.Controls.Add(Me.lblNombre)
        Me.gbUsuarios.Location = New System.Drawing.Point(287, 44)
        Me.gbUsuarios.Name = "gbUsuarios"
        Me.gbUsuarios.Size = New System.Drawing.Size(421, 189)
        Me.gbUsuarios.TabIndex = 3
        Me.gbUsuarios.TabStop = False
        Me.gbUsuarios.Text = "Usuarios"
        '
        'lvUsuarios
        '
        Me.lvUsuarios.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvUsuarios.ContextMenuStrip = Me.cmsOpciones
        Me.lvUsuarios.FullRowSelect = True
        Me.lvUsuarios.GridLines = True
        Me.lvUsuarios.Location = New System.Drawing.Point(19, 70)
        Me.lvUsuarios.Name = "lvUsuarios"
        Me.lvUsuarios.Size = New System.Drawing.Size(383, 97)
        Me.lvUsuarios.TabIndex = 3
        Me.lvUsuarios.UseCompatibleStateImageBehavior = False
        Me.lvUsuarios.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Tipo"
        Me.ColumnHeader1.Width = 121
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width = 102
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Fecha registro"
        Me.ColumnHeader3.Width = 155
        '
        'cmsOpciones
        '
        Me.cmsOpciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarUsuarioToolStripMenuItem1, Me.EditarUsuarioToolStripMenuItem1, Me.CambiarTipoDeUsuarioAToolStripMenuItem1, Me.BorrarUsuarioToolStripMenuItem1, Me.RecargarListaToolStripMenuItem1, Me.GrabarToolStripMenuItem1})
        Me.cmsOpciones.Name = "cmsOpciones"
        Me.cmsOpciones.Size = New System.Drawing.Size(211, 136)
        '
        'AgregarUsuarioToolStripMenuItem1
        '
        Me.AgregarUsuarioToolStripMenuItem1.Name = "AgregarUsuarioToolStripMenuItem1"
        Me.AgregarUsuarioToolStripMenuItem1.Size = New System.Drawing.Size(210, 22)
        Me.AgregarUsuarioToolStripMenuItem1.Text = "Agregar Usuario"
        '
        'EditarUsuarioToolStripMenuItem1
        '
        Me.EditarUsuarioToolStripMenuItem1.Name = "EditarUsuarioToolStripMenuItem1"
        Me.EditarUsuarioToolStripMenuItem1.Size = New System.Drawing.Size(210, 22)
        Me.EditarUsuarioToolStripMenuItem1.Text = "Editar Usuario"
        '
        'CambiarTipoDeUsuarioAToolStripMenuItem1
        '
        Me.CambiarTipoDeUsuarioAToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuarioToolStripMenuItem1, Me.AdministradorToolStripMenuItem1})
        Me.CambiarTipoDeUsuarioAToolStripMenuItem1.Name = "CambiarTipoDeUsuarioAToolStripMenuItem1"
        Me.CambiarTipoDeUsuarioAToolStripMenuItem1.Size = New System.Drawing.Size(210, 22)
        Me.CambiarTipoDeUsuarioAToolStripMenuItem1.Text = "Cambiar tipo de usuario a"
        '
        'UsuarioToolStripMenuItem1
        '
        Me.UsuarioToolStripMenuItem1.Name = "UsuarioToolStripMenuItem1"
        Me.UsuarioToolStripMenuItem1.Size = New System.Drawing.Size(150, 22)
        Me.UsuarioToolStripMenuItem1.Text = "Usuario"
        '
        'AdministradorToolStripMenuItem1
        '
        Me.AdministradorToolStripMenuItem1.Name = "AdministradorToolStripMenuItem1"
        Me.AdministradorToolStripMenuItem1.Size = New System.Drawing.Size(150, 22)
        Me.AdministradorToolStripMenuItem1.Text = "Administrador"
        '
        'BorrarUsuarioToolStripMenuItem1
        '
        Me.BorrarUsuarioToolStripMenuItem1.Name = "BorrarUsuarioToolStripMenuItem1"
        Me.BorrarUsuarioToolStripMenuItem1.Size = New System.Drawing.Size(210, 22)
        Me.BorrarUsuarioToolStripMenuItem1.Text = "Borrar Usuario"
        '
        'RecargarListaToolStripMenuItem1
        '
        Me.RecargarListaToolStripMenuItem1.Name = "RecargarListaToolStripMenuItem1"
        Me.RecargarListaToolStripMenuItem1.Size = New System.Drawing.Size(210, 22)
        Me.RecargarListaToolStripMenuItem1.Text = "Recargar Lista"
        '
        'GrabarToolStripMenuItem1
        '
        Me.GrabarToolStripMenuItem1.Name = "GrabarToolStripMenuItem1"
        Me.GrabarToolStripMenuItem1.Size = New System.Drawing.Size(210, 22)
        Me.GrabarToolStripMenuItem1.Text = "Grabar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(301, 25)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(101, 23)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(75, 28)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(220, 20)
        Me.txtBuscar.TabIndex = 1
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(16, 31)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(53, 13)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "Nombre : "
        '
        'FormUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 268)
        Me.Controls.Add(Me.gbUsuarios)
        Me.Controls.Add(Me.ssStatus)
        Me.Controls.Add(Me.gbUsuario)
        Me.Controls.Add(Me.msOpciones)
        Me.MainMenuStrip = Me.msOpciones
        Me.MaximizeBox = False
        Me.Name = "FormUsuarios"
        Me.Text = "Usuarios"
        Me.msOpciones.ResumeLayout(False)
        Me.msOpciones.PerformLayout()
        Me.gbUsuario.ResumeLayout(False)
        Me.gbUsuario.PerformLayout()
        Me.ssStatus.ResumeLayout(False)
        Me.ssStatus.PerformLayout()
        Me.gbUsuarios.ResumeLayout(False)
        Me.gbUsuarios.PerformLayout()
        Me.cmsOpciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents msOpciones As System.Windows.Forms.MenuStrip
    Friend WithEvents OpcionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgregarUsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarUsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarUsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecargarListaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CambiarTipoDeUsuarioAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdministradorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents ssStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gbUsuarios As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lvUsuarios As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmsOpciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AgregarUsuarioToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarUsuarioToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BorrarUsuarioToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecargarListaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrabarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CambiarTipoDeUsuarioAToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuarioToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdministradorToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
