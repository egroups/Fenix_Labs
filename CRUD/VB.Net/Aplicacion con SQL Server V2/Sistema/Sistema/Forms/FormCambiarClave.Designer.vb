<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCambiarClave
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
        Me.txtNuevaClave = New System.Windows.Forms.TextBox()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.txtUsuarioActual = New System.Windows.Forms.TextBox()
        Me.lblNuevaClave = New System.Windows.Forms.Label()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCambiarClave = New System.Windows.Forms.Button()
        Me.gbDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.txtNuevaClave)
        Me.gbDatos.Controls.Add(Me.txtClave)
        Me.gbDatos.Controls.Add(Me.txtUsuarioActual)
        Me.gbDatos.Controls.Add(Me.lblNuevaClave)
        Me.gbDatos.Controls.Add(Me.lblClave)
        Me.gbDatos.Controls.Add(Me.Label1)
        Me.gbDatos.Location = New System.Drawing.Point(12, 23)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(300, 141)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos"
        '
        'txtNuevaClave
        '
        Me.txtNuevaClave.Location = New System.Drawing.Point(134, 98)
        Me.txtNuevaClave.Name = "txtNuevaClave"
        Me.txtNuevaClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNuevaClave.Size = New System.Drawing.Size(145, 20)
        Me.txtNuevaClave.TabIndex = 5
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(115, 63)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(164, 20)
        Me.txtClave.TabIndex = 4
        '
        'txtUsuarioActual
        '
        Me.txtUsuarioActual.Location = New System.Drawing.Point(115, 26)
        Me.txtUsuarioActual.Name = "txtUsuarioActual"
        Me.txtUsuarioActual.ReadOnly = True
        Me.txtUsuarioActual.Size = New System.Drawing.Size(164, 20)
        Me.txtUsuarioActual.TabIndex = 3
        '
        'lblNuevaClave
        '
        Me.lblNuevaClave.AutoSize = True
        Me.lblNuevaClave.Location = New System.Drawing.Point(24, 98)
        Me.lblNuevaClave.Name = "lblNuevaClave"
        Me.lblNuevaClave.Size = New System.Drawing.Size(77, 13)
        Me.lblNuevaClave.TabIndex = 2
        Me.lblNuevaClave.Text = "Nueva clave : "
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Location = New System.Drawing.Point(24, 63)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(43, 13)
        Me.lblClave.TabIndex = 1
        Me.lblClave.Text = "Clave : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario Actual : "
        '
        'btnCambiarClave
        '
        Me.btnCambiarClave.Location = New System.Drawing.Point(81, 182)
        Me.btnCambiarClave.Name = "btnCambiarClave"
        Me.btnCambiarClave.Size = New System.Drawing.Size(153, 23)
        Me.btnCambiarClave.TabIndex = 1
        Me.btnCambiarClave.Text = "Cambiar"
        Me.btnCambiarClave.UseVisualStyleBackColor = True
        '
        'FormCambiarClave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 221)
        Me.Controls.Add(Me.btnCambiarClave)
        Me.Controls.Add(Me.gbDatos)
        Me.MaximizeBox = False
        Me.Name = "FormCambiarClave"
        Me.Text = "Cambiar clave"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblNuevaClave As System.Windows.Forms.Label
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNuevaClave As System.Windows.Forms.TextBox
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioActual As System.Windows.Forms.TextBox
    Friend WithEvents btnCambiarClave As System.Windows.Forms.Button
End Class
