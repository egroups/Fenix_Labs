namespace aplicacion
{
    partial class FormLogin
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
            this.gbLogin = new Telerik.WinControls.UI.RadGroupBox();
            this.txtPassword = new Telerik.WinControls.UI.RadTextBox();
            this.txtUsuario = new Telerik.WinControls.UI.RadTextBox();
            this.lblPassword = new Telerik.WinControls.UI.RadLabel();
            this.lblUsuario = new Telerik.WinControls.UI.RadLabel();
            this.btnIngresar = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbLogin)).BeginInit();
            this.gbLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIngresar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbLogin.Controls.Add(this.txtPassword);
            this.gbLogin.Controls.Add(this.txtUsuario);
            this.gbLogin.Controls.Add(this.lblPassword);
            this.gbLogin.Controls.Add(this.lblUsuario);
            this.gbLogin.HeaderText = "Login";
            this.gbLogin.Location = new System.Drawing.Point(12, 12);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(268, 108);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.Text = "Login";
            this.gbLogin.ThemeName = "Office2013Light";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(93, 68);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(158, 21);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.ThemeName = "Office2013Light";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(83, 33);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(168, 21);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.ThemeName = "Office2013Light";
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(20, 68);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(67, 19);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password : ";
            this.lblPassword.ThemeName = "Office2013Light";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Location = new System.Drawing.Point(20, 33);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(57, 19);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario : ";
            this.lblUsuario.ThemeName = "Office2013Light";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(61, 137);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(170, 24);
            this.btnIngresar.TabIndex = 1;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.ThemeName = "Office2013Light";
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 183);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.gbLogin);
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Aplicacion basica";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbLogin)).EndInit();
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIngresar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme Theme;
        private Telerik.WinControls.UI.RadGroupBox gbLogin;
        private Telerik.WinControls.UI.RadLabel lblPassword;
        private Telerik.WinControls.UI.RadLabel lblUsuario;
        private Telerik.WinControls.UI.RadTextBox txtPassword;
        private Telerik.WinControls.UI.RadTextBox txtUsuario;
        private Telerik.WinControls.UI.RadButton btnIngresar;


    }
}