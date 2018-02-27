namespace aplicacion
{
    partial class FormCambiarClave
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
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.txtNuevaClave = new System.Windows.Forms.TextBox();
            this.lblNuevaClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtUsuarioActual = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.lblActual = new System.Windows.Forms.Label();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.txtNuevaClave);
            this.gbDatos.Controls.Add(this.lblNuevaClave);
            this.gbDatos.Controls.Add(this.txtClave);
            this.gbDatos.Controls.Add(this.txtUsuarioActual);
            this.gbDatos.Controls.Add(this.lblClave);
            this.gbDatos.Controls.Add(this.lblActual);
            this.gbDatos.Location = new System.Drawing.Point(12, 12);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(260, 120);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos";
            // 
            // txtNuevaClave
            // 
            this.txtNuevaClave.Location = new System.Drawing.Point(125, 84);
            this.txtNuevaClave.Name = "txtNuevaClave";
            this.txtNuevaClave.PasswordChar = '*';
            this.txtNuevaClave.Size = new System.Drawing.Size(118, 20);
            this.txtNuevaClave.TabIndex = 5;
            // 
            // lblNuevaClave
            // 
            this.lblNuevaClave.AutoSize = true;
            this.lblNuevaClave.Location = new System.Drawing.Point(15, 84);
            this.lblNuevaClave.Name = "lblNuevaClave";
            this.lblNuevaClave.Size = new System.Drawing.Size(78, 13);
            this.lblNuevaClave.TabIndex = 4;
            this.lblNuevaClave.Text = "Nueva Clave : ";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(91, 50);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(152, 20);
            this.txtClave.TabIndex = 3;
            // 
            // txtUsuarioActual
            // 
            this.txtUsuarioActual.Location = new System.Drawing.Point(105, 23);
            this.txtUsuarioActual.Name = "txtUsuarioActual";
            this.txtUsuarioActual.ReadOnly = true;
            this.txtUsuarioActual.Size = new System.Drawing.Size(138, 20);
            this.txtUsuarioActual.TabIndex = 2;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(15, 50);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(43, 13);
            this.lblClave.TabIndex = 1;
            this.lblClave.Text = "Clave : ";
            // 
            // lblActual
            // 
            this.lblActual.AutoSize = true;
            this.lblActual.Location = new System.Drawing.Point(15, 26);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(84, 13);
            this.lblActual.TabIndex = 0;
            this.lblActual.Text = "Usuario actual : ";
            // 
            // btnCambiar
            // 
            this.btnCambiar.Location = new System.Drawing.Point(49, 147);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(173, 23);
            this.btnCambiar.TabIndex = 2;
            this.btnCambiar.Text = "Cambiar";
            this.btnCambiar.UseVisualStyleBackColor = true;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // FormCambiarClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 187);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.gbDatos);
            this.MaximizeBox = false;
            this.Name = "FormCambiarClave";
            this.Text = "Cambiar clave";
            this.Load += new System.EventHandler(this.FormCambiarContraseña_Load);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.TextBox txtNuevaClave;
        private System.Windows.Forms.Label lblNuevaClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtUsuarioActual;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblActual;
        private System.Windows.Forms.Button btnCambiar;

    }
}