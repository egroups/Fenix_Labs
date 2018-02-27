<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCambiarUsuario
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
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.txtNuevoNombre = New System.Windows.Forms.TextBox()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.txtUsuarioActual = New System.Windows.Forms.TextBox()
        Me.lblNuevoNombre = New System.Windows.Forms.Label()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.lblUsuarioActual = New System.Windows.Forms.Label()
        Me.btnCambiarUsuario = New System.Windows.Forms.Button()
        Me.gbDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.txtNuevoNombre)
        Me.gbDatos.Controls.Add(Me.txtClave)
        Me.gbDatos.Controls.Add(Me.txtUsuarioActual)
        Me.gbDatos.Controls.Add(Me.lblNuevoNombre)
        Me.gbDatos.Controls.Add(Me.lblClave)
        Me.gbDatos.Controls.Add(Me.lblUsuarioActual)
        Me.gbDatos.Location = New System.Drawing.Point(12, 12)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(282, 129)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos"
        '
        'txtNuevoNombre
        '
        Me.txtNuevoNombre.Location = New System.Drawing.Point(109, 91)
        Me.txtNuevoNombre.Name = "txtNuevoNombre"
        Me.txtNuevoNombre.Size = New System.Drawing.Size(152, 20)
        Me.txtNuevoNombre.TabIndex = 5
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(109, 55)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(152, 20)
        Me.txtClave.TabIndex = 4
        '
        'txtUsuarioActual
        '
        Me.txtUsuarioActual.Location = New System.Drawing.Point(109, 25)
        Me.txtUsuarioActual.Name = "txtUsuarioActual"
        Me.txtUsuarioActual.ReadOnly = True
        Me.txtUsuarioActual.Size = New System.Drawing.Size(152, 20)
        Me.txtUsuarioActual.TabIndex = 3
        '
        'lblNuevoNombre
        '
        Me.lblNuevoNombre.AutoSize = True
        Me.lblNuevoNombre.Location = New System.Drawing.Point(18, 91)
        Me.lblNuevoNombre.Name = "lblNuevoNombre"
        Me.lblNuevoNombre.Size = New System.Drawing.Size(86, 13)
        Me.lblNuevoNombre.TabIndex = 2
        Me.lblNuevoNombre.Text = "Nuevo nombre : "
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Location = New System.Drawing.Point(18, 58)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(43, 13)
        Me.lblClave.TabIndex = 1
        Me.lblClave.Text = "Clave : "
        '
        'lblUsuarioActual
        '
        Me.lblUsuarioActual.AutoSize = True
        Me.lblUsuarioActual.Location = New System.Drawing.Point(18, 28)
        Me.lblUsuarioActual.Name = "lblUsuarioActual"
        Me.lblUsuarioActual.Size = New System.Drawing.Size(85, 13)
        Me.lblUsuarioActual.TabIndex = 0
        Me.lblUsuarioActual.Text = "Usuario Actual : "
        '
        'btnCambiarUsuario
        '
        Me.btnCambiarUsuario.Location = New System.Drawing.Point(82, 156)
        Me.btnCambiarUsuario.Name = "btnCambiarUsuario"
        Me.btnCambiarUsuario.Size = New System.Drawing.Size(138, 23)
        Me.btnCambiarUsuario.TabIndex = 1
        Me.btnCambiarUsuario.Text = "Cambiar"
        Me.btnCambiarUsuario.UseVisualStyleBackColor = True
        '
        'FormCambiarUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 194)
        Me.Controls.Add(Me.btnCambiarUsuario)
        Me.Controls.Add(Me.gbDatos)
        Me.MaximizeBox = False
        Me.Name = "FormCambiarUsuario"
        Me.Text = "Cambiar Usuario"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblNuevoNombre As System.Windows.Forms.Label
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioActual As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioActual As System.Windows.Forms.TextBox
    Friend WithEvents txtNuevoNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnCambiarUsuario As System.Windows.Forms.Button
End Class
