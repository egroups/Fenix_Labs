namespace aplicacion
{
    partial class FormHome
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
            this.rmOptions = new Telerik.WinControls.UI.RadMenu();
            this.ItemOpciones = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemProductos = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemProveedores = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemUsuarios = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemEstadisticas = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemCuenta = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemCambiarUsuario = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemCambiarPassword = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemSalir = new Telerik.WinControls.UI.RadMenuItem();
            this.ssStatus = new Telerik.WinControls.UI.RadStatusStrip();
            this.status = new Telerik.WinControls.UI.RadLabelElement();
            ((System.ComponentModel.ISupportInitialize)(this.rmOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rmOptions
            // 
            this.rmOptions.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.ItemOpciones,
            this.ItemEstadisticas,
            this.ItemCuenta,
            this.ItemSalir});
            this.rmOptions.Location = new System.Drawing.Point(0, 0);
            this.rmOptions.Name = "rmOptions";
            this.rmOptions.Size = new System.Drawing.Size(464, 19);
            this.rmOptions.TabIndex = 0;
            this.rmOptions.Text = "Menu";
            this.rmOptions.ThemeName = "Office2013Light";
            // 
            // ItemOpciones
            // 
            this.ItemOpciones.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.ItemProductos,
            this.ItemProveedores,
            this.ItemUsuarios});
            this.ItemOpciones.Name = "ItemOpciones";
            this.ItemOpciones.Text = "Opciones";
            // 
            // ItemProductos
            // 
            this.ItemProductos.Name = "ItemProductos";
            this.ItemProductos.Text = "Productos";
            this.ItemProductos.Click += new System.EventHandler(this.ItemProductos_Click);
            // 
            // ItemProveedores
            // 
            this.ItemProveedores.Name = "ItemProveedores";
            this.ItemProveedores.Text = "Proveedores";
            this.ItemProveedores.Click += new System.EventHandler(this.ItemProveedores_Click);
            // 
            // ItemUsuarios
            // 
            this.ItemUsuarios.Name = "ItemUsuarios";
            this.ItemUsuarios.Text = "Usuarios";
            this.ItemUsuarios.Click += new System.EventHandler(this.ItemUsuarios_Click);
            // 
            // ItemEstadisticas
            // 
            this.ItemEstadisticas.Name = "ItemEstadisticas";
            this.ItemEstadisticas.Text = "Estadisticas";
            this.ItemEstadisticas.Click += new System.EventHandler(this.ItemEstadisticas_Click);
            // 
            // ItemCuenta
            // 
            this.ItemCuenta.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.ItemCambiarUsuario,
            this.ItemCambiarPassword});
            this.ItemCuenta.Name = "ItemCuenta";
            this.ItemCuenta.Text = "Cuenta";
            // 
            // ItemCambiarUsuario
            // 
            this.ItemCambiarUsuario.Name = "ItemCambiarUsuario";
            this.ItemCambiarUsuario.Text = "Cambiar nombre de usuario";
            this.ItemCambiarUsuario.Click += new System.EventHandler(this.ItemCambiarUsuario_Click);
            // 
            // ItemCambiarPassword
            // 
            this.ItemCambiarPassword.Name = "ItemCambiarPassword";
            this.ItemCambiarPassword.Text = "Cambiar contraseña";
            this.ItemCambiarPassword.Click += new System.EventHandler(this.ItemCambiarPassword_Click);
            // 
            // ItemSalir
            // 
            this.ItemSalir.Name = "ItemSalir";
            this.ItemSalir.Text = "Salir";
            this.ItemSalir.Click += new System.EventHandler(this.ItemSalir_Click);
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.status});
            this.ssStatus.Location = new System.Drawing.Point(0, 304);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(464, 27);
            this.ssStatus.TabIndex = 1;
            this.ssStatus.ThemeName = "Office2013Light";
            // 
            // status
            // 
            this.status.Name = "status";
            this.ssStatus.SetSpring(this.status, false);
            this.status.Text = "Programa cargado";
            this.status.TextWrap = true;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 331);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.rmOptions);
            this.MaximizeBox = false;
            this.Name = "FormHome";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Home";
            this.ThemeName = "Office2013Light";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHome_FormClosing);
            this.Load += new System.EventHandler(this.FormHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rmOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme Theme;
        private Telerik.WinControls.UI.RadMenu rmOptions;
        private Telerik.WinControls.UI.RadMenuItem ItemOpciones;
        private Telerik.WinControls.UI.RadMenuItem ItemProductos;
        private Telerik.WinControls.UI.RadMenuItem ItemProveedores;
        private Telerik.WinControls.UI.RadMenuItem ItemUsuarios;
        private Telerik.WinControls.UI.RadMenuItem ItemEstadisticas;
        private Telerik.WinControls.UI.RadMenuItem ItemCuenta;
        private Telerik.WinControls.UI.RadMenuItem ItemSalir;
        private Telerik.WinControls.UI.RadMenuItem ItemCambiarUsuario;
        private Telerik.WinControls.UI.RadMenuItem ItemCambiarPassword;
        private Telerik.WinControls.UI.RadStatusStrip ssStatus;
        private Telerik.WinControls.UI.RadLabelElement status;
    }
}
