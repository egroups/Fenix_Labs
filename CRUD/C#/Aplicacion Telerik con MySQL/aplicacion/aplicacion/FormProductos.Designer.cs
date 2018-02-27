namespace aplicacion
{
    partial class FormProductos
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
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn6 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Nombre");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn7 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Descripcion");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn8 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Precio");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn9 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 3", "Fecha");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn10 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 4", "Proveedor");
            this.Theme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.ItemOpciones = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemAgregarProducto = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemEditarProducto = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemBorrarProducto = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemCancelar = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemRecargarLista = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemGrabar = new Telerik.WinControls.UI.RadMenuItem();
            this.gbDatos = new Telerik.WinControls.UI.RadGroupBox();
            this.txtID = new Telerik.WinControls.UI.RadTextBox();
            this.btnGrabar = new Telerik.WinControls.UI.RadButton();
            this.cmbProveedor = new Telerik.WinControls.UI.RadDropDownList();
            this.txtDescripcion = new Telerik.WinControls.UI.RadTextBox();
            this.txtPrecio = new Telerik.WinControls.UI.RadTextBox();
            this.txtNombre = new Telerik.WinControls.UI.RadTextBox();
            this.lblPrecio = new Telerik.WinControls.UI.RadLabel();
            this.lblProveedor = new Telerik.WinControls.UI.RadLabel();
            this.lblDescripcion = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox2 = new Telerik.WinControls.UI.RadTextBox();
            this.lblNombre = new Telerik.WinControls.UI.RadLabel();
            this.ssStatus = new Telerik.WinControls.UI.RadStatusStrip();
            this.status = new Telerik.WinControls.UI.RadLabelElement();
            this.gbProductos = new Telerik.WinControls.UI.RadGroupBox();
            this.btnBuscar = new Telerik.WinControls.UI.RadButton();
            this.txtBuscar = new Telerik.WinControls.UI.RadTextBox();
            this.lblNombreBuscar = new Telerik.WinControls.UI.RadLabel();
            this.lvProductos = new Telerik.WinControls.UI.RadListView();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDatos)).BeginInit();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrabar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescripcion)).BeginInit();
            this.lblDescripcion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbProductos)).BeginInit();
            this.gbProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombreBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.ItemOpciones});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(892, 19);
            this.radMenu1.TabIndex = 0;
            this.radMenu1.Text = "radMenu1";
            this.radMenu1.ThemeName = "Office2013Light";
            // 
            // ItemOpciones
            // 
            this.ItemOpciones.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.ItemAgregarProducto,
            this.ItemEditarProducto,
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
            this.ItemAgregarProducto.Text = "Agregar Producto";
            this.ItemAgregarProducto.Click += new System.EventHandler(this.ItemAgregarProducto_Click);
            // 
            // ItemEditarProducto
            // 
            this.ItemEditarProducto.Name = "ItemEditarProducto";
            this.ItemEditarProducto.Text = "Editar Producto";
            this.ItemEditarProducto.Click += new System.EventHandler(this.ItemEditarProducto_Click);
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
            this.gbDatos.Controls.Add(this.cmbProveedor);
            this.gbDatos.Controls.Add(this.txtDescripcion);
            this.gbDatos.Controls.Add(this.txtPrecio);
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.lblPrecio);
            this.gbDatos.Controls.Add(this.lblProveedor);
            this.gbDatos.Controls.Add(this.lblDescripcion);
            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.HeaderText = "Datos de Producto";
            this.gbDatos.Location = new System.Drawing.Point(12, 42);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(236, 266);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.Text = "Datos de Producto";
            this.gbDatos.ThemeName = "Office2013Light";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(29, 203);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(28, 21);
            this.txtID.TabIndex = 9;
            this.txtID.ThemeName = "Office2013Light";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(63, 213);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(110, 24);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.ThemeName = "Office2013Light";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cmbProveedor.Location = new System.Drawing.Point(92, 121);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(125, 21);
            this.cmbProveedor.TabIndex = 7;
            this.cmbProveedor.ThemeName = "Office2013Light";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(100, 79);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(120, 21);
            this.txtDescripcion.TabIndex = 6;
            this.txtDescripcion.ThemeName = "Office2013Light";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(70, 159);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(150, 21);
            this.txtPrecio.TabIndex = 5;
            this.txtPrecio.ThemeName = "Office2013Light";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(81, 35);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(139, 21);
            this.txtNombre.TabIndex = 4;
            this.txtNombre.ThemeName = "Office2013Light";
            // 
            // lblPrecio
            // 
            this.lblPrecio.Location = new System.Drawing.Point(14, 159);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(50, 19);
            this.lblPrecio.TabIndex = 3;
            this.lblPrecio.Text = "Precio : ";
            this.lblPrecio.ThemeName = "Office2013Light";
            // 
            // lblProveedor
            // 
            this.lblProveedor.Location = new System.Drawing.Point(14, 120);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(72, 19);
            this.lblProveedor.TabIndex = 2;
            this.lblProveedor.Text = "Proveedor : ";
            this.lblProveedor.ThemeName = "Office2013Light";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Controls.Add(this.radTextBox2);
            this.lblDescripcion.Location = new System.Drawing.Point(14, 76);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(80, 19);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion : ";
            this.lblDescripcion.ThemeName = "Office2013Light";
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
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.status});
            this.ssStatus.Location = new System.Drawing.Point(0, 320);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(892, 27);
            this.ssStatus.TabIndex = 2;
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
            // gbProductos
            // 
            this.gbProductos.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbProductos.Controls.Add(this.btnBuscar);
            this.gbProductos.Controls.Add(this.txtBuscar);
            this.gbProductos.Controls.Add(this.lblNombreBuscar);
            this.gbProductos.Controls.Add(this.lvProductos);
            this.gbProductos.HeaderText = "Productos";
            this.gbProductos.Location = new System.Drawing.Point(269, 42);
            this.gbProductos.Name = "gbProductos";
            this.gbProductos.Size = new System.Drawing.Size(592, 266);
            this.gbProductos.TabIndex = 3;
            this.gbProductos.Text = "Productos";
            this.gbProductos.ThemeName = "Office2013Light";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(468, 32);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 24);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.ThemeName = "Office2013Light";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(92, 32);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(356, 21);
            this.txtBuscar.TabIndex = 5;
            this.txtBuscar.ThemeName = "Office2013Light";
            // 
            // lblNombreBuscar
            // 
            this.lblNombreBuscar.Location = new System.Drawing.Point(25, 35);
            this.lblNombreBuscar.Name = "lblNombreBuscar";
            this.lblNombreBuscar.Size = new System.Drawing.Size(61, 19);
            this.lblNombreBuscar.TabIndex = 4;
            this.lblNombreBuscar.Text = "Nombre : ";
            this.lblNombreBuscar.ThemeName = "Office2013Light";
            // 
            // lvProductos
            // 
            this.lvProductos.AllowEdit = false;
            listViewDetailColumn6.HeaderText = "Nombre";
            listViewDetailColumn7.HeaderText = "Descripcion";
            listViewDetailColumn8.HeaderText = "Precio";
            listViewDetailColumn9.HeaderText = "Fecha";
            listViewDetailColumn10.HeaderText = "Proveedor";
            this.lvProductos.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn6,
            listViewDetailColumn7,
            listViewDetailColumn8,
            listViewDetailColumn9,
            listViewDetailColumn10});
            this.lvProductos.ItemSpacing = -1;
            this.lvProductos.Location = new System.Drawing.Point(25, 76);
            this.lvProductos.Name = "lvProductos";
            this.lvProductos.Size = new System.Drawing.Size(562, 175);
            this.lvProductos.TabIndex = 0;
            this.lvProductos.ThemeName = "Office2013Light";
            this.lvProductos.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.lvProductos.SelectedItemChanged += new System.EventHandler(this.lvProductos_SelectedItemChanged);
            // 
            // FormProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 347);
            this.Controls.Add(this.gbProductos);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.radMenu1);
            this.MaximizeBox = false;
            this.Name = "FormProductos";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Productos";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.FormProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDatos)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrabar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescripcion)).EndInit();
            this.lblDescripcion.ResumeLayout(false);
            this.lblDescripcion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbProductos)).EndInit();
            this.gbProductos.ResumeLayout(false);
            this.gbProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombreBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme Theme;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem ItemOpciones;
        private Telerik.WinControls.UI.RadMenuItem ItemAgregarProducto;
        private Telerik.WinControls.UI.RadMenuItem ItemEditarProducto;
        private Telerik.WinControls.UI.RadMenuItem ItemBorrarProducto;
        private Telerik.WinControls.UI.RadMenuItem ItemCancelar;
        private Telerik.WinControls.UI.RadMenuItem ItemRecargarLista;
        private Telerik.WinControls.UI.RadMenuItem ItemGrabar;
        private Telerik.WinControls.UI.RadGroupBox gbDatos;
        private Telerik.WinControls.UI.RadLabel lblPrecio;
        private Telerik.WinControls.UI.RadLabel lblProveedor;
        private Telerik.WinControls.UI.RadLabel lblDescripcion;
        private Telerik.WinControls.UI.RadLabel lblNombre;
        private Telerik.WinControls.UI.RadTextBox txtNombre;
        private Telerik.WinControls.UI.RadTextBox txtPrecio;
        private Telerik.WinControls.UI.RadTextBox radTextBox2;
        private Telerik.WinControls.UI.RadTextBox txtDescripcion;
        private Telerik.WinControls.UI.RadDropDownList cmbProveedor;
        private Telerik.WinControls.UI.RadButton btnGrabar;
        private Telerik.WinControls.UI.RadStatusStrip ssStatus;
        private Telerik.WinControls.UI.RadLabelElement status;
        private Telerik.WinControls.UI.RadGroupBox gbProductos;
        private Telerik.WinControls.UI.RadListView lvProductos;
        private Telerik.WinControls.UI.RadTextBox txtID;
        private Telerik.WinControls.UI.RadButton btnBuscar;
        private Telerik.WinControls.UI.RadTextBox txtBuscar;
        private Telerik.WinControls.UI.RadLabel lblNombreBuscar;
    }
}
