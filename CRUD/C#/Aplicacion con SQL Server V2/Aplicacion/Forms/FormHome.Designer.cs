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
            this.msOptions = new System.Windows.Forms.MenuStrip();
            this.tsOpcionessssssss = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemEstadisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemCambiarNombre = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemCambiarClave = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.ssEstado = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.msOptions.SuspendLayout();
            this.ssEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // msOptions
            // 
            this.msOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOpcionessssssss,
            this.ItemEstadisticas,
            this.cuentaToolStripMenuItem,
            this.ItemSalir});
            this.msOptions.Location = new System.Drawing.Point(0, 0);
            this.msOptions.Name = "msOptions";
            this.msOptions.Size = new System.Drawing.Size(527, 24);
            this.msOptions.TabIndex = 0;
            this.msOptions.Text = "menuStrip1";
            // 
            // tsOpcionessssssss
            // 
            this.tsOpcionessssssss.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemProductos,
            this.ItemProveedores,
            this.ItemUsuarios});
            this.tsOpcionessssssss.Name = "tsOpcionessssssss";
            this.tsOpcionessssssss.Size = new System.Drawing.Size(69, 20);
            this.tsOpcionessssssss.Text = "Opciones";
            // 
            // ItemProductos
            // 
            this.ItemProductos.Name = "ItemProductos";
            this.ItemProductos.Size = new System.Drawing.Size(152, 22);
            this.ItemProductos.Text = "Productos";
            this.ItemProductos.Click += new System.EventHandler(this.ItemProductos_Click);
            // 
            // ItemProveedores
            // 
            this.ItemProveedores.Name = "ItemProveedores";
            this.ItemProveedores.Size = new System.Drawing.Size(152, 22);
            this.ItemProveedores.Text = "Proveedores";
            this.ItemProveedores.Click += new System.EventHandler(this.ItemProveedores_Click);
            // 
            // ItemUsuarios
            // 
            this.ItemUsuarios.Name = "ItemUsuarios";
            this.ItemUsuarios.Size = new System.Drawing.Size(152, 22);
            this.ItemUsuarios.Text = "Usuarios";
            this.ItemUsuarios.Click += new System.EventHandler(this.ItemUsuarios_Click);
            // 
            // ItemEstadisticas
            // 
            this.ItemEstadisticas.Name = "ItemEstadisticas";
            this.ItemEstadisticas.Size = new System.Drawing.Size(79, 20);
            this.ItemEstadisticas.Text = "Estadisticas";
            this.ItemEstadisticas.Click += new System.EventHandler(this.tsEstadisticas_Click);
            // 
            // cuentaToolStripMenuItem
            // 
            this.cuentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemCambiarNombre,
            this.ItemCambiarClave});
            this.cuentaToolStripMenuItem.Name = "cuentaToolStripMenuItem";
            this.cuentaToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.cuentaToolStripMenuItem.Text = "Cuenta";
            // 
            // ItemCambiarNombre
            // 
            this.ItemCambiarNombre.Name = "ItemCambiarNombre";
            this.ItemCambiarNombre.Size = new System.Drawing.Size(222, 22);
            this.ItemCambiarNombre.Text = "Cambiar nombre de usuario";
            this.ItemCambiarNombre.Click += new System.EventHandler(this.ItemCambiarNombreDeUsuario_Click);
            // 
            // ItemCambiarClave
            // 
            this.ItemCambiarClave.Name = "ItemCambiarClave";
            this.ItemCambiarClave.Size = new System.Drawing.Size(222, 22);
            this.ItemCambiarClave.Text = "Cambiar clave";
            this.ItemCambiarClave.Click += new System.EventHandler(this.ItemCambiarClave_Click);
            // 
            // ItemSalir
            // 
            this.ItemSalir.Name = "ItemSalir";
            this.ItemSalir.Size = new System.Drawing.Size(41, 20);
            this.ItemSalir.Text = "Salir";
            this.ItemSalir.Click += new System.EventHandler(this.ItemSalir_Click);
            // 
            // ssEstado
            // 
            this.ssEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.ssEstado.Location = new System.Drawing.Point(0, 328);
            this.ssEstado.Name = "ssEstado";
            this.ssEstado.Size = new System.Drawing.Size(527, 22);
            this.ssEstado.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(105, 17);
            this.toolStripStatusLabel1.Text = "Programa cargado";
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 350);
            this.Controls.Add(this.ssEstado);
            this.Controls.Add(this.msOptions);
            this.MainMenuStrip = this.msOptions;
            this.MaximizeBox = false;
            this.Name = "FormHome";
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHome_FormClosing);
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.msOptions.ResumeLayout(false);
            this.msOptions.PerformLayout();
            this.ssEstado.ResumeLayout(false);
            this.ssEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msOptions;
        private System.Windows.Forms.ToolStripMenuItem tsOpcionessssssss;
        private System.Windows.Forms.ToolStripMenuItem ItemProductos;
        private System.Windows.Forms.ToolStripMenuItem ItemProveedores;
        private System.Windows.Forms.ToolStripMenuItem ItemEstadisticas;
        private System.Windows.Forms.ToolStripMenuItem ItemSalir;
        private System.Windows.Forms.StatusStrip ssEstado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem ItemUsuarios;
        private System.Windows.Forms.ToolStripMenuItem cuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ItemCambiarNombre;
        private System.Windows.Forms.ToolStripMenuItem ItemCambiarClave;
    }
}