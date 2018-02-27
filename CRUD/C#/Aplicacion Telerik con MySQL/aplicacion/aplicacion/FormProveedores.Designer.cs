namespace aplicacion
{
    partial class FormProveedores
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
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Nombre");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Direccion");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn3 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Telefono");
            this.Theme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.ItemOpciones = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemAgregarProducto = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemEditarProveedor = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemBorrarProducto = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemCancelar = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemRecargarLista = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemGrabar = new Telerik.WinControls.UI.RadMenuItem();
            this.gbDatos = new Telerik.WinControls.UI.RadGroupBox();
            this.txtID = new Telerik.WinControls.UI.RadTextBox();
            this.btnGrabar = new Telerik.WinControls.UI.RadButton();
            this.txtDireccion = new Telerik.WinControls.UI.RadTextBox();
            this.txtTelefono = new Telerik.WinControls.UI.RadTextBox();
            this.txtNombre = new Telerik.WinControls.UI.RadTextBox();
            this.lblTelefono = new Telerik.WinControls.UI.RadLabel();
            this.lblDireccion = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox2 = new Telerik.WinControls.UI.RadTextBox();
            this.lblNombre = new Telerik.WinControls.UI.RadLabel();
            this.gbProveedores = new Telerik.WinControls.UI.RadGroupBox();
            this.btnBuscar = new Telerik.WinControls.UI.RadButton();
            this.txtBuscar = new Telerik.WinControls.UI.RadTextBox();
            this.lblNombreBuscar = new Telerik.WinControls.UI.RadLabel();
            this.lvProveedores = new Telerik.WinControls.UI.RadListView();
            this.ssStatus = new Telerik.WinControls.UI.RadStatusStrip();
            this.status = new Telerik.WinControls.UI.RadLabelElement();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDatos)).BeginInit();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrabar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDireccion)).BeginInit();
            this.lblDireccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbProveedores)).BeginInit();
            this.gbProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombreBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.ItemOpciones});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(909, 19);
            this.radMenu1.TabIndex = 1;
            this.radMenu1.Text = "radMenu1";
            this.radMenu1.ThemeName = "Office2013Light";
            // 
            // ItemOpciones
            // 
            this.ItemOpciones.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.ItemAgregarProducto,
            this.ItemEditarProveedor,
            this.ItemBorrarProducto,
            this.ItemCancelar,
            this.ItemRecargarLista,
            this.ItemGrabar});
            this.ItemOpciones.Name = "ItemOpciones";
            this.ItemOpciones.Text = "Opciones";
            // 
            // ItemAgregarProducto
            // 
            this.ItemAgregarProducto.Name = "ItemAgregarProducto";
            this.ItemAgregarProducto.Text = "Agregar Proveedor";
            this.ItemAgregarProducto.Click += new System.EventHandler(this.ItemAgregarProducto_Click);
            // 
            // ItemEditarProveedor
            // 
            this.ItemEditarProveedor.Name = "ItemEditarProveedor";
            this.ItemEditarProveedor.Text = "Editar Proveedor";
            this.ItemEditarProveedor.Click += new System.EventHandler(this.ItemEditarProveedor_Click);
            // 
            // ItemBorrarProducto
            // 
            this.ItemBorrarProducto.Name = "ItemBorrarProducto";
            this.ItemBorrarProducto.Text = "Borrar Producto";
            this.ItemBorrarProducto.Click += new System.EventHandler(this.ItemBorrarProducto_Click);
            // 
            // ItemCancelar
            // 
            this.ItemCancelar.Name = "ItemCancelar";
            this.ItemCancelar.Text = "Cancelar";
            this.ItemCancelar.Click += new System.EventHandler(this.ItemCancelar_Click);
            // 
            // ItemRecargarLista
            // 
            this.ItemRecargarLista.Name = "ItemRecargarLista";
            this.ItemRecargarLista.Text = "Recargar Lista";
            this.ItemRecargarLista.Click += new System.EventHandler(this.ItemRecargarLista_Click);
            // 
            // ItemGrabar
            // 
            this.ItemGrabar.Name = "ItemGrabar";
            this.ItemGrabar.Text = "Grabar";
            this.ItemGrabar.Click += new System.EventHandler(this.ItemGrabar_Click);
            // 
            // gbDatos
            // 
            this.gbDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbDatos.Controls.Add(this.txtID);
            this.gbDatos.Controls.Add(this.btnGrabar);
            this.gbDatos.Controls.Add(this.txtDireccion);
            this.gbDatos.Controls.Add(this.txtTelefono);
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.lblTelefono);
            this.gbDatos.Controls.Add(this.lblDireccion);
            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.HeaderText = "Datos de Proveedor";
            this.gbDatos.Location = new System.Drawing.Point(12, 34);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(236, 266);
            this.gbDatos.TabIndex = 2;
            this.gbDatos.Text = "Datos de Proveedor";
            this.gbDatos.ThemeName = "Office2013Light";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(29, 163);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(35, 21);
            this.txtID.TabIndex = 9;
            this.txtID.ThemeName = "Office2013Light";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(70, 161);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(110, 24);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.ThemeName = "Office2013Light";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(100, 79);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(120, 21);
            this.txtDireccion.TabIndex = 6;
            this.txtDireccion.ThemeName = "Office2013Light";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(84, 116);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(136, 21);
            this.txtTelefono.TabIndex = 5;
            this.txtTelefono.ThemeName = "Office2013Light";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(81, 35);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(139, 21);
            this.txtNombre.TabIndex = 4;
            this.txtNombre.ThemeName = "Office2013Light";
            // 
            // lblTelefono
            // 
            this.lblTelefono.Location = new System.Drawing.Point(14, 116);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(64, 19);
            this.lblTelefono.TabIndex = 3;
            this.lblTelefono.Text = "Telefono : ";
            this.lblTelefono.ThemeName = "Office2013Light";
            // 
            // lblDireccion
            // 
            this.lblDireccion.Controls.Add(this.radTextBox2);
            this.lblDireccion.Location = new System.Drawing.Point(14, 76);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(67, 19);
            this.lblDireccion.TabIndex = 1;
            this.lblDireccion.Text = "Direccion : ";
            this.lblDireccion.ThemeName = "Office2013Light";
            // 
            // radTextBox2
            // 
            this.radTextBox2.Location = new System.Drawing.Point(86, 3);
            this.radTextBox2.Name = "radTextBox2";
            this.radTextBox2.Size = new System.Drawing.Size(100, 20);
            this.radTextBox2.TabIndex = 5;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(14, 35);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(61, 19);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre : ";
            this.lblNombre.ThemeName = "Office2013Light";
            // 
            // gbProveedores
            // 
            this.gbProveedores.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbProveedores.Controls.Add(this.btnBuscar);
            this.gbProveedores.Controls.Add(this.txtBuscar);
            this.gbProveedores.Controls.Add(this.lblNombreBuscar);
            this.gbProveedores.Controls.Add(this.lvProveedores);
            this.gbProveedores.HeaderText = "Proveedores";
            this.gbProveedores.Location = new System.Drawing.Point(265, 34);
            this.gbProveedores.Name = "gbProveedores";
            this.gbProveedores.Size = new System.Drawing.Size(549, 266);
            this.gbProveedores.TabIndex = 4;
            this.gbProveedores.Text = "Proveedores";
            this.gbProveedores.ThemeName = "Office2013Light";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(420, 37);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 24);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.ThemeName = "Office2013Light";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(99, 37);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(305, 21);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.ThemeName = "Office2013Light";
            // 
            // lblNombreBuscar
            // 
            this.lblNombreBuscar.Location = new System.Drawing.Point(32, 40);
            this.lblNombreBuscar.Name = "lblNombreBuscar";
            this.lblNombreBuscar.Size = new System.Drawing.Size(61, 19);
            this.lblNombreBuscar.TabIndex = 1;
            this.lblNombreBuscar.Text = "Nombre : ";
            this.lblNombreBuscar.ThemeName = "Office2013Light";
            // 
            // lvProveedores
            // 
            this.lvProveedores.AllowEdit = false;
            listViewDetailColumn1.HeaderText = "Nombre";
            listViewDetailColumn2.HeaderText = "Direccion";
            listViewDetailColumn3.HeaderText = "Telefono";
            this.lvProveedores.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2,
            listViewDetailColumn3});
            this.lvProveedores.ItemSpacing = -1;
            this.lvProveedores.Location = new System.Drawing.Point(25, 79);
            this.lvProveedores.Name = "lvProveedores";
            this.lvProveedores.Size = new System.Drawing.Size(505, 172);
            this.lvProveedores.TabIndex = 0;
            this.lvProveedores.ThemeName = "Office2013Light";
            this.lvProveedores.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.lvProveedores.SelectedItemChanged += new System.EventHandler(this.lvProveedores_SelectedItemChanged);
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.status});
            this.ssStatus.Location = new System.Drawing.Point(0, 324);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(909, 27);
            this.ssStatus.TabIndex = 5;
            this.ssStatus.Text = "radStatusStrip1";
            this.ssStatus.ThemeName = "Office2013Light";
            // 
            // status
            // 
            this.status.Name = "status";
            this.ssStatus.SetSpring(this.status, false);
            this.status.Text = "Programa cargado";
            this.status.TextWrap = true;
            // 
            // FormProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 351);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.gbProveedores);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.radMenu1);
            this.MaximizeBox = false;
            this.Name = "FormProveedores";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Proveedores";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.FormProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDatos)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrabar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDireccion)).EndInit();
            this.lblDireccion.ResumeLayout(false);
            this.lblDireccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbProveedores)).EndInit();
            this.gbProveedores.ResumeLayout(false);
            this.gbProveedores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombreBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme Theme;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem ItemOpciones;
        private Telerik.WinControls.UI.RadGroupBox gbDatos;
        private Telerik.WinControls.UI.RadButton btnGrabar;
        private Telerik.WinControls.UI.RadTextBox txtDireccion;
        private Telerik.WinControls.UI.RadTextBox txtTelefono;
        private Telerik.WinControls.UI.RadTextBox txtNombre;
        private Telerik.WinControls.UI.RadLabel lblTelefono;
        private Telerik.WinControls.UI.RadLabel lblDireccion;
        private Telerik.WinControls.UI.RadTextBox radTextBox2;
        private Telerik.WinControls.UI.RadLabel lblNombre;
        private Telerik.WinControls.UI.RadGroupBox gbProveedores;
        private Telerik.WinControls.UI.RadListView lvProveedores;
        private Telerik.WinControls.UI.RadStatusStrip ssStatus;
        private Telerik.WinControls.UI.RadLabelElement status;
        private Telerik.WinControls.UI.RadMenuItem ItemAgregarProducto;
        private Telerik.WinControls.UI.RadMenuItem ItemEditarProveedor;
        private Telerik.WinControls.UI.RadMenuItem ItemBorrarProducto;
        private Telerik.WinControls.UI.RadMenuItem ItemCancelar;
        private Telerik.WinControls.UI.RadMenuItem ItemRecargarLista;
        private Telerik.WinControls.UI.RadMenuItem ItemGrabar;
        private Telerik.WinControls.UI.RadTextBox txtID;
        private Telerik.WinControls.UI.RadTextBox txtBuscar;
        private Telerik.WinControls.UI.RadButton btnBuscar;
        private Telerik.WinControls.UI.RadLabel lblNombreBuscar;
    }
}
