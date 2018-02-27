namespace aplicacion
{
    partial class FormCambiarUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Theme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.gbDatos = new Telerik.WinControls.UI.RadGroupBox();
            this.txtNuevoNombre = new Telerik.WinControls.UI.RadTextBox();
            this.lblNuevoNombre = new Telerik.WinControls.UI.RadLabel();
            this.txtContraseña = new Telerik.WinControls.UI.RadTextBox();
            this.txtUsuarioActual = new Telerik.WinControls.UI.RadTextBox();
            this.lblContraseña = new Telerik.WinControls.UI.RadLabel();
            this.lblUsuarioActual = new Telerik.WinControls.UI.RadLabel();
            this.btnCambiarUsuario = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbDatos)).BeginInit();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevoNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNuevoNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContraseña)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuarioActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContraseña)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUsuarioActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCambiarUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbDatos.Controls.Add(this.txtNuevoNombre);
            this.gbDatos.Controls.Add(this.lblNuevoNombre);
            this.gbDatos.Controls.Add(this.txtContraseña);
            this.gbDatos.Controls.Add(this.txtUsuarioActual);
            this.gbDatos.Controls.Add(this.lblContraseña);
            this.gbDatos.Controls.Add(this.lblUsuarioActual);
            this.gbDatos.HeaderText = "Datos";
            this.gbDatos.Location = new System.Drawing.Point(12, 12);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(268, 132);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.Text = "Datos";
            this.gbDatos.ThemeName = "Office2013Light";
            // 
            // txtNuevoNombre
            // 
            this.txtNuevoNombre.Location = new System.Drawing.Point(121, 95);
            this.txtNuevoNombre.Name = "txtNuevoNombre";
            this.txtNuevoNombre.Size = new System.Drawing.Size(130, 21);
            this.txtNuevoNombre.TabIndex = 5;
            this.txtNuevoNombre.ThemeName = "Office2013Light";
            // 
            // lblNuevoNombre
            // 
            this.lblNuevoNombre.Location = new System.Drawing.Point(20, 97);
            this.lblNuevoNombre.Name = "lblNuevoNombre";
            this.lblNuevoNombre.Size = new System.Drawing.Size(98, 19);
            this.lblNuevoNombre.TabIndex = 4;
            this.lblNuevoNombre.Text = "Nuevo nombre : ";
            this.lblNuevoNombre.ThemeName = "Office2013Light";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(93, 68);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(158, 21);
            this.txtContraseña.TabIndex = 3;
            this.txtContraseña.ThemeName = "Office2013Light";
            // 
            // txtUsuarioActual
            // 
            this.txtUsuarioActual.Location = new System.Drawing.Point(121, 33);
            this.txtUsuarioActual.Name = "txtUsuarioActual";
            this.txtUsuarioActual.ReadOnly = true;
            this.txtUsuarioActual.Size = new System.Drawing.Size(130, 21);
            this.txtUsuarioActual.TabIndex = 2;
            this.txtUsuarioActual.ThemeName = "Office2013Light";
            // 
            // lblContraseña
            // 
            this.lblContraseña.Location = new System.Drawing.Point(20, 68);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(78, 19);
            this.lblContraseña.TabIndex = 1;
            this.lblContraseña.Text = "Contraseña : ";
            this.lblContraseña.ThemeName = "Office2013Light";
            // 
            // lblUsuarioActual
            // 
            this.lblUsuarioActual.Location = new System.Drawing.Point(20, 33);
            this.lblUsuarioActual.Name = "lblUsuarioActual";
            this.lblUsuarioActual.Size = new System.Drawing.Size(95, 19);
            this.lblUsuarioActual.TabIndex = 0;
            this.lblUsuarioActual.Text = "Usuario Actual : ";
            this.lblUsuarioActual.ThemeName = "Office2013Light";
            // 
            // btnCambiarUsuario
            // 
            this.btnCambiarUsuario.Location = new System.Drawing.Point(57, 161);
            this.btnCambiarUsuario.Name = "btnCambiarUsuario";
            this.btnCambiarUsuario.Size = new System.Drawing.Size(170, 24);
            this.btnCambiarUsuario.TabIndex = 2;
            this.btnCambiarUsuario.Text = "Cambiar";
            this.btnCambiarUsuario.ThemeName = "Office2013Light";
            this.btnCambiarUsuario.Click += new System.EventHandler(this.btnCambiarUsuario_Click);
            // 
            // FormCambiarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 212);
            this.Controls.Add(this.btnCambiarUsuario);
            this.Controls.Add(this.gbDatos);
            this.MaximizeBox = false;
            this.Name = "FormCambiarUsuario";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Cambiar Usuario";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.FormCambiarUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbDatos)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevoNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNuevoNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContraseña)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuarioActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblContraseña)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUsuarioActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCambiarUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme Theme;
        private Telerik.WinControls.UI.RadGroupBox gbDatos;
        private Telerik.WinControls.UI.RadTextBox txtContraseña;
        private Telerik.WinControls.UI.RadTextBox txtUsuarioActual;
        private Telerik.WinControls.UI.RadLabel lblContraseña;
        private Telerik.WinControls.UI.RadLabel lblUsuarioActual;
        private Telerik.WinControls.UI.RadButton btnCambiarUsuario;
        private Telerik.WinControls.UI.RadTextBox txtNuevoNombre;
        private Telerik.WinControls.UI.RadLabel lblNuevoNombre;
    }
}
