namespace Cliente
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
            this.tcOpciones = new System.Windows.Forms.TabControl();
            this.tpAPI = new System.Windows.Forms.TabPage();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.rbXML = new System.Windows.Forms.RadioButton();
            this.rbJSON = new System.Windows.Forms.RadioButton();
            this.gbIngreseURL = new System.Windows.Forms.GroupBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.tpProductos = new System.Windows.Forms.TabPage();
            this.gbProductos = new System.Windows.Forms.GroupBox();
            this.btnBuscarProductos = new System.Windows.Forms.Button();
            this.txtNombreBuscar = new System.Windows.Forms.TextBox();
            this.lblNombreBuscar = new System.Windows.Forms.Label();
            this.lvProductos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbProducto = new System.Windows.Forms.GroupBox();
            this.btnCLEAR_Productos = new System.Windows.Forms.Button();
            this.btnDEL_Producto = new System.Windows.Forms.Button();
            this.btnGET_Producto = new System.Windows.Forms.Button();
            this.btnPUT_Producto = new System.Windows.Forms.Button();
            this.txtID_Producto = new System.Windows.Forms.TextBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.btnPOST_Producto = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.rtbDescripcion = new System.Windows.Forms.RichTextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tpProveedores = new System.Windows.Forms.TabPage();
            this.gbProveedores = new System.Windows.Forms.GroupBox();
            this.btnBuscarProveedores = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lvProveedores = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbProveedor = new System.Windows.Forms.GroupBox();
            this.btnCLEAR_Proveedores = new System.Windows.Forms.Button();
            this.btnDEL_Proveedor = new System.Windows.Forms.Button();
            this.btnPUT_Proveedor = new System.Windows.Forms.Button();
            this.btnPOST_Proveedor = new System.Windows.Forms.Button();
            this.btnGET_Proveedor = new System.Windows.Forms.Button();
            this.txtID_Proveedor = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtNombreEmpresa = new System.Windows.Forms.TextBox();
            this.lblNombreEmpresa = new System.Windows.Forms.Label();
            this.tpUsuarios = new System.Windows.Forms.TabPage();
            this.gbUsuarios = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lvUsuarios = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbUsuario = new System.Windows.Forms.GroupBox();
            this.btnCLEAR_Usuarios = new System.Windows.Forms.Button();
            this.btnDEL_Usuario = new System.Windows.Forms.Button();
            this.btnPUT_Usuario = new System.Windows.Forms.Button();
            this.btnPOST_Usuario = new System.Windows.Forms.Button();
            this.btnGET_Usuario = new System.Windows.Forms.Button();
            this.txtID_Usuario = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.tcOpciones.SuspendLayout();
            this.tpAPI.SuspendLayout();
            this.gbType.SuspendLayout();
            this.gbIngreseURL.SuspendLayout();
            this.tpProductos.SuspendLayout();
            this.gbProductos.SuspendLayout();
            this.gbProducto.SuspendLayout();
            this.tpProveedores.SuspendLayout();
            this.gbProveedores.SuspendLayout();
            this.gbProveedor.SuspendLayout();
            this.tpUsuarios.SuspendLayout();
            this.gbUsuarios.SuspendLayout();
            this.gbUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcOpciones
            // 
            this.tcOpciones.Controls.Add(this.tpAPI);
            this.tcOpciones.Controls.Add(this.tpProductos);
            this.tcOpciones.Controls.Add(this.tpProveedores);
            this.tcOpciones.Controls.Add(this.tpUsuarios);
            this.tcOpciones.Location = new System.Drawing.Point(3, 12);
            this.tcOpciones.Name = "tcOpciones";
            this.tcOpciones.SelectedIndex = 0;
            this.tcOpciones.Size = new System.Drawing.Size(748, 417);
            this.tcOpciones.TabIndex = 0;
            // 
            // tpAPI
            // 
            this.tpAPI.Controls.Add(this.gbType);
            this.tpAPI.Controls.Add(this.gbIngreseURL);
            this.tpAPI.Location = new System.Drawing.Point(4, 22);
            this.tpAPI.Name = "tpAPI";
            this.tpAPI.Padding = new System.Windows.Forms.Padding(3);
            this.tpAPI.Size = new System.Drawing.Size(740, 391);
            this.tpAPI.TabIndex = 3;
            this.tpAPI.Text = "API";
            this.tpAPI.UseVisualStyleBackColor = true;
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.rbXML);
            this.gbType.Controls.Add(this.rbJSON);
            this.gbType.Location = new System.Drawing.Point(65, 125);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(189, 91);
            this.gbType.TabIndex = 1;
            this.gbType.TabStop = false;
            this.gbType.Text = "Tipo";
            // 
            // rbXML
            // 
            this.rbXML.AutoSize = true;
            this.rbXML.Location = new System.Drawing.Point(120, 36);
            this.rbXML.Name = "rbXML";
            this.rbXML.Size = new System.Drawing.Size(47, 17);
            this.rbXML.TabIndex = 1;
            this.rbXML.Text = "XML";
            this.rbXML.UseVisualStyleBackColor = true;
            // 
            // rbJSON
            // 
            this.rbJSON.AutoSize = true;
            this.rbJSON.Checked = true;
            this.rbJSON.Location = new System.Drawing.Point(18, 36);
            this.rbJSON.Name = "rbJSON";
            this.rbJSON.Size = new System.Drawing.Size(53, 17);
            this.rbJSON.TabIndex = 0;
            this.rbJSON.TabStop = true;
            this.rbJSON.Text = "JSON";
            this.rbJSON.UseVisualStyleBackColor = true;
            // 
            // gbIngreseURL
            // 
            this.gbIngreseURL.Controls.Add(this.txtURL);
            this.gbIngreseURL.Location = new System.Drawing.Point(65, 45);
            this.gbIngreseURL.Name = "gbIngreseURL";
            this.gbIngreseURL.Size = new System.Drawing.Size(583, 74);
            this.gbIngreseURL.TabIndex = 0;
            this.gbIngreseURL.TabStop = false;
            this.gbIngreseURL.Text = "Ingrese URL";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(19, 31);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(541, 20);
            this.txtURL.TabIndex = 0;
            this.txtURL.Text = "http://localhost:4959/";
            // 
            // tpProductos
            // 
            this.tpProductos.Controls.Add(this.gbProductos);
            this.tpProductos.Controls.Add(this.gbProducto);
            this.tpProductos.Location = new System.Drawing.Point(4, 22);
            this.tpProductos.Name = "tpProductos";
            this.tpProductos.Padding = new System.Windows.Forms.Padding(3);
            this.tpProductos.Size = new System.Drawing.Size(740, 391);
            this.tpProductos.TabIndex = 0;
            this.tpProductos.Text = "Productos";
            this.tpProductos.UseVisualStyleBackColor = true;
            // 
            // gbProductos
            // 
            this.gbProductos.Controls.Add(this.btnBuscarProductos);
            this.gbProductos.Controls.Add(this.txtNombreBuscar);
            this.gbProductos.Controls.Add(this.lblNombreBuscar);
            this.gbProductos.Controls.Add(this.lvProductos);
            this.gbProductos.Location = new System.Drawing.Point(221, 17);
            this.gbProductos.Name = "gbProductos";
            this.gbProductos.Size = new System.Drawing.Size(506, 354);
            this.gbProductos.TabIndex = 2;
            this.gbProductos.TabStop = false;
            this.gbProductos.Text = "Productos";
            // 
            // btnBuscarProductos
            // 
            this.btnBuscarProductos.Location = new System.Drawing.Point(279, 34);
            this.btnBuscarProductos.Name = "btnBuscarProductos";
            this.btnBuscarProductos.Size = new System.Drawing.Size(208, 23);
            this.btnBuscarProductos.TabIndex = 3;
            this.btnBuscarProductos.Text = "Buscar Productos";
            this.btnBuscarProductos.UseVisualStyleBackColor = true;
            this.btnBuscarProductos.Click += new System.EventHandler(this.btnBuscarProductos_Click);
            // 
            // txtNombreBuscar
            // 
            this.txtNombreBuscar.Location = new System.Drawing.Point(84, 36);
            this.txtNombreBuscar.Name = "txtNombreBuscar";
            this.txtNombreBuscar.Size = new System.Drawing.Size(189, 20);
            this.txtNombreBuscar.TabIndex = 2;
            // 
            // lblNombreBuscar
            // 
            this.lblNombreBuscar.AutoSize = true;
            this.lblNombreBuscar.Location = new System.Drawing.Point(25, 36);
            this.lblNombreBuscar.Name = "lblNombreBuscar";
            this.lblNombreBuscar.Size = new System.Drawing.Size(53, 13);
            this.lblNombreBuscar.TabIndex = 1;
            this.lblNombreBuscar.Text = "Nombre : ";
            // 
            // lvProductos
            // 
            this.lvProductos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvProductos.FullRowSelect = true;
            this.lvProductos.Location = new System.Drawing.Point(19, 90);
            this.lvProductos.Name = "lvProductos";
            this.lvProductos.Size = new System.Drawing.Size(468, 245);
            this.lvProductos.TabIndex = 0;
            this.lvProductos.UseCompatibleStateImageBehavior = false;
            this.lvProductos.View = System.Windows.Forms.View.Details;
            this.lvProductos.SelectedIndexChanged += new System.EventHandler(this.lvProductos_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nombre";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descripcion";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Precio";
            this.columnHeader3.Width = 49;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Fecha";
            this.columnHeader4.Width = 91;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Proveedor";
            this.columnHeader5.Width = 122;
            // 
            // gbProducto
            // 
            this.gbProducto.Controls.Add(this.btnCLEAR_Productos);
            this.gbProducto.Controls.Add(this.btnDEL_Producto);
            this.gbProducto.Controls.Add(this.btnGET_Producto);
            this.gbProducto.Controls.Add(this.btnPUT_Producto);
            this.gbProducto.Controls.Add(this.txtID_Producto);
            this.gbProducto.Controls.Add(this.cmbProveedor);
            this.gbProducto.Controls.Add(this.lblProveedor);
            this.gbProducto.Controls.Add(this.btnPOST_Producto);
            this.gbProducto.Controls.Add(this.txtPrecio);
            this.gbProducto.Controls.Add(this.lblPrecio);
            this.gbProducto.Controls.Add(this.rtbDescripcion);
            this.gbProducto.Controls.Add(this.lblDescripcion);
            this.gbProducto.Controls.Add(this.txtNombre);
            this.gbProducto.Controls.Add(this.lblNombre);
            this.gbProducto.Location = new System.Drawing.Point(15, 17);
            this.gbProducto.Name = "gbProducto";
            this.gbProducto.Size = new System.Drawing.Size(200, 354);
            this.gbProducto.TabIndex = 1;
            this.gbProducto.TabStop = false;
            this.gbProducto.Text = "Datos del producto";
            // 
            // btnCLEAR_Productos
            // 
            this.btnCLEAR_Productos.Location = new System.Drawing.Point(6, 283);
            this.btnCLEAR_Productos.Name = "btnCLEAR_Productos";
            this.btnCLEAR_Productos.Size = new System.Drawing.Size(56, 23);
            this.btnCLEAR_Productos.TabIndex = 13;
            this.btnCLEAR_Productos.Text = "CLEAR";
            this.btnCLEAR_Productos.UseVisualStyleBackColor = true;
            this.btnCLEAR_Productos.Click += new System.EventHandler(this.btnCLEAR_Productos_Click);
            // 
            // btnDEL_Producto
            // 
            this.btnDEL_Producto.Location = new System.Drawing.Point(152, 312);
            this.btnDEL_Producto.Name = "btnDEL_Producto";
            this.btnDEL_Producto.Size = new System.Drawing.Size(42, 23);
            this.btnDEL_Producto.TabIndex = 12;
            this.btnDEL_Producto.Text = "DEL";
            this.btnDEL_Producto.UseVisualStyleBackColor = true;
            this.btnDEL_Producto.Click += new System.EventHandler(this.btnDEL_Producto_Click);
            // 
            // btnGET_Producto
            // 
            this.btnGET_Producto.Location = new System.Drawing.Point(8, 312);
            this.btnGET_Producto.Name = "btnGET_Producto";
            this.btnGET_Producto.Size = new System.Drawing.Size(38, 23);
            this.btnGET_Producto.TabIndex = 11;
            this.btnGET_Producto.Text = "GET";
            this.btnGET_Producto.UseVisualStyleBackColor = true;
            this.btnGET_Producto.Click += new System.EventHandler(this.btnGET_Producto_Click);
            // 
            // btnPUT_Producto
            // 
            this.btnPUT_Producto.Location = new System.Drawing.Point(106, 312);
            this.btnPUT_Producto.Name = "btnPUT_Producto";
            this.btnPUT_Producto.Size = new System.Drawing.Size(40, 23);
            this.btnPUT_Producto.TabIndex = 10;
            this.btnPUT_Producto.Text = "PUT";
            this.btnPUT_Producto.UseVisualStyleBackColor = true;
            this.btnPUT_Producto.Click += new System.EventHandler(this.btnPUT_Producto_Click);
            // 
            // txtID_Producto
            // 
            this.txtID_Producto.Location = new System.Drawing.Point(101, 65);
            this.txtID_Producto.Name = "txtID_Producto";
            this.txtID_Producto.ReadOnly = true;
            this.txtID_Producto.Size = new System.Drawing.Size(48, 20);
            this.txtID_Producto.TabIndex = 9;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(79, 216);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(98, 21);
            this.cmbProveedor.TabIndex = 8;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(18, 219);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(65, 13);
            this.lblProveedor.TabIndex = 7;
            this.lblProveedor.Text = "Proveedor : ";
            // 
            // btnPOST_Producto
            // 
            this.btnPOST_Producto.Location = new System.Drawing.Point(52, 312);
            this.btnPOST_Producto.Name = "btnPOST_Producto";
            this.btnPOST_Producto.Size = new System.Drawing.Size(48, 23);
            this.btnPOST_Producto.TabIndex = 6;
            this.btnPOST_Producto.Text = "POST";
            this.btnPOST_Producto.UseVisualStyleBackColor = true;
            this.btnPOST_Producto.Click += new System.EventHandler(this.btnPOST_Producto_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(68, 254);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 5;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(16, 254);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(46, 13);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "Precio : ";
            // 
            // rtbDescripcion
            // 
            this.rtbDescripcion.Location = new System.Drawing.Point(21, 102);
            this.rtbDescripcion.Name = "rtbDescripcion";
            this.rtbDescripcion.Size = new System.Drawing.Size(156, 96);
            this.rtbDescripcion.TabIndex = 3;
            this.rtbDescripcion.Text = "";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(16, 72);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(72, 13);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripcion : ";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(77, 33);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(18, 33);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(53, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre : ";
            // 
            // tpProveedores
            // 
            this.tpProveedores.Controls.Add(this.gbProveedores);
            this.tpProveedores.Controls.Add(this.gbProveedor);
            this.tpProveedores.Location = new System.Drawing.Point(4, 22);
            this.tpProveedores.Name = "tpProveedores";
            this.tpProveedores.Padding = new System.Windows.Forms.Padding(3);
            this.tpProveedores.Size = new System.Drawing.Size(740, 391);
            this.tpProveedores.TabIndex = 1;
            this.tpProveedores.Text = "Proveedores";
            this.tpProveedores.UseVisualStyleBackColor = true;
            // 
            // gbProveedores
            // 
            this.gbProveedores.Controls.Add(this.btnBuscarProveedores);
            this.gbProveedores.Controls.Add(this.txtBuscar);
            this.gbProveedores.Controls.Add(this.label2);
            this.gbProveedores.Controls.Add(this.lvProveedores);
            this.gbProveedores.Location = new System.Drawing.Point(223, 17);
            this.gbProveedores.Name = "gbProveedores";
            this.gbProveedores.Size = new System.Drawing.Size(497, 249);
            this.gbProveedores.TabIndex = 2;
            this.gbProveedores.TabStop = false;
            this.gbProveedores.Text = "Proveedores";
            // 
            // btnBuscarProveedores
            // 
            this.btnBuscarProveedores.Location = new System.Drawing.Point(344, 35);
            this.btnBuscarProveedores.Name = "btnBuscarProveedores";
            this.btnBuscarProveedores.Size = new System.Drawing.Size(135, 23);
            this.btnBuscarProveedores.TabIndex = 3;
            this.btnBuscarProveedores.Text = "Buscar Proveedores";
            this.btnBuscarProveedores.UseVisualStyleBackColor = true;
            this.btnBuscarProveedores.Click += new System.EventHandler(this.btnBuscarProveedores_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(74, 35);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(264, 20);
            this.txtBuscar.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre : ";
            // 
            // lvProveedores
            // 
            this.lvProveedores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvProveedores.FullRowSelect = true;
            this.lvProveedores.Location = new System.Drawing.Point(18, 91);
            this.lvProveedores.Name = "lvProveedores";
            this.lvProveedores.Size = new System.Drawing.Size(461, 141);
            this.lvProveedores.TabIndex = 0;
            this.lvProveedores.UseCompatibleStateImageBehavior = false;
            this.lvProveedores.View = System.Windows.Forms.View.Details;
            this.lvProveedores.SelectedIndexChanged += new System.EventHandler(this.lvProveedores_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Nombre";
            this.columnHeader6.Width = 179;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Direccion";
            this.columnHeader7.Width = 180;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Telefono";
            this.columnHeader8.Width = 96;
            // 
            // gbProveedor
            // 
            this.gbProveedor.Controls.Add(this.btnCLEAR_Proveedores);
            this.gbProveedor.Controls.Add(this.btnDEL_Proveedor);
            this.gbProveedor.Controls.Add(this.btnPUT_Proveedor);
            this.gbProveedor.Controls.Add(this.btnPOST_Proveedor);
            this.gbProveedor.Controls.Add(this.btnGET_Proveedor);
            this.gbProveedor.Controls.Add(this.txtID_Proveedor);
            this.gbProveedor.Controls.Add(this.txtTelefono);
            this.gbProveedor.Controls.Add(this.lblTelefono);
            this.gbProveedor.Controls.Add(this.txtDireccion);
            this.gbProveedor.Controls.Add(this.lblDireccion);
            this.gbProveedor.Controls.Add(this.txtNombreEmpresa);
            this.gbProveedor.Controls.Add(this.lblNombreEmpresa);
            this.gbProveedor.Location = new System.Drawing.Point(17, 17);
            this.gbProveedor.Name = "gbProveedor";
            this.gbProveedor.Size = new System.Drawing.Size(200, 249);
            this.gbProveedor.TabIndex = 1;
            this.gbProveedor.TabStop = false;
            this.gbProveedor.Text = "Datos del proveedor";
            // 
            // btnCLEAR_Proveedores
            // 
            this.btnCLEAR_Proveedores.Location = new System.Drawing.Point(52, 145);
            this.btnCLEAR_Proveedores.Name = "btnCLEAR_Proveedores";
            this.btnCLEAR_Proveedores.Size = new System.Drawing.Size(56, 23);
            this.btnCLEAR_Proveedores.TabIndex = 16;
            this.btnCLEAR_Proveedores.Text = "CLEAR";
            this.btnCLEAR_Proveedores.UseVisualStyleBackColor = true;
            this.btnCLEAR_Proveedores.Click += new System.EventHandler(this.btnCLEAR_Proveedores_Click);
            // 
            // btnDEL_Proveedor
            // 
            this.btnDEL_Proveedor.Location = new System.Drawing.Point(152, 183);
            this.btnDEL_Proveedor.Name = "btnDEL_Proveedor";
            this.btnDEL_Proveedor.Size = new System.Drawing.Size(42, 23);
            this.btnDEL_Proveedor.TabIndex = 15;
            this.btnDEL_Proveedor.Text = "DEL";
            this.btnDEL_Proveedor.UseVisualStyleBackColor = true;
            this.btnDEL_Proveedor.Click += new System.EventHandler(this.btnDEL_Proveedor_Click);
            // 
            // btnPUT_Proveedor
            // 
            this.btnPUT_Proveedor.Location = new System.Drawing.Point(106, 183);
            this.btnPUT_Proveedor.Name = "btnPUT_Proveedor";
            this.btnPUT_Proveedor.Size = new System.Drawing.Size(40, 23);
            this.btnPUT_Proveedor.TabIndex = 14;
            this.btnPUT_Proveedor.Text = "PUT";
            this.btnPUT_Proveedor.UseVisualStyleBackColor = true;
            this.btnPUT_Proveedor.Click += new System.EventHandler(this.btnPUT_Proveedor_Click);
            // 
            // btnPOST_Proveedor
            // 
            this.btnPOST_Proveedor.Location = new System.Drawing.Point(52, 183);
            this.btnPOST_Proveedor.Name = "btnPOST_Proveedor";
            this.btnPOST_Proveedor.Size = new System.Drawing.Size(48, 23);
            this.btnPOST_Proveedor.TabIndex = 13;
            this.btnPOST_Proveedor.Text = "POST";
            this.btnPOST_Proveedor.UseVisualStyleBackColor = true;
            this.btnPOST_Proveedor.Click += new System.EventHandler(this.btnPOST_Proveedor_Click);
            // 
            // btnGET_Proveedor
            // 
            this.btnGET_Proveedor.Location = new System.Drawing.Point(8, 183);
            this.btnGET_Proveedor.Name = "btnGET_Proveedor";
            this.btnGET_Proveedor.Size = new System.Drawing.Size(38, 23);
            this.btnGET_Proveedor.TabIndex = 12;
            this.btnGET_Proveedor.Text = "GET";
            this.btnGET_Proveedor.UseVisualStyleBackColor = true;
            // 
            // txtID_Proveedor
            // 
            this.txtID_Proveedor.Location = new System.Drawing.Point(6, 147);
            this.txtID_Proveedor.Name = "txtID_Proveedor";
            this.txtID_Proveedor.ReadOnly = true;
            this.txtID_Proveedor.Size = new System.Drawing.Size(40, 20);
            this.txtID_Proveedor.TabIndex = 7;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(76, 108);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(109, 20);
            this.txtTelefono.TabIndex = 5;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(17, 111);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(58, 13);
            this.lblTelefono.TabIndex = 4;
            this.lblTelefono.Text = "Telefono : ";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(76, 73);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(109, 20);
            this.txtDireccion.TabIndex = 3;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(17, 73);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(61, 13);
            this.lblDireccion.TabIndex = 2;
            this.lblDireccion.Text = "Direccion : ";
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.Location = new System.Drawing.Point(76, 35);
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.Size = new System.Drawing.Size(109, 20);
            this.txtNombreEmpresa.TabIndex = 1;
            // 
            // lblNombreEmpresa
            // 
            this.lblNombreEmpresa.AutoSize = true;
            this.lblNombreEmpresa.Location = new System.Drawing.Point(17, 35);
            this.lblNombreEmpresa.Name = "lblNombreEmpresa";
            this.lblNombreEmpresa.Size = new System.Drawing.Size(53, 13);
            this.lblNombreEmpresa.TabIndex = 0;
            this.lblNombreEmpresa.Text = "Nombre : ";
            // 
            // tpUsuarios
            // 
            this.tpUsuarios.Controls.Add(this.gbUsuarios);
            this.tpUsuarios.Controls.Add(this.gbUsuario);
            this.tpUsuarios.Location = new System.Drawing.Point(4, 22);
            this.tpUsuarios.Name = "tpUsuarios";
            this.tpUsuarios.Padding = new System.Windows.Forms.Padding(3);
            this.tpUsuarios.Size = new System.Drawing.Size(740, 391);
            this.tpUsuarios.TabIndex = 2;
            this.tpUsuarios.Text = "Usuarios";
            this.tpUsuarios.UseVisualStyleBackColor = true;
            // 
            // gbUsuarios
            // 
            this.gbUsuarios.Controls.Add(this.button3);
            this.gbUsuarios.Controls.Add(this.textBox4);
            this.gbUsuarios.Controls.Add(this.lblNombreUsuario);
            this.gbUsuarios.Controls.Add(this.lvUsuarios);
            this.gbUsuarios.Location = new System.Drawing.Point(231, 17);
            this.gbUsuarios.Name = "gbUsuarios";
            this.gbUsuarios.Size = new System.Drawing.Size(489, 212);
            this.gbUsuarios.TabIndex = 4;
            this.gbUsuarios.TabStop = false;
            this.gbUsuarios.Text = "Usuarios";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(383, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Buscar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnBuscarUsuarios_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(86, 33);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(291, 20);
            this.textBox4.TabIndex = 2;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(27, 33);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(53, 13);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "Nombre : ";
            // 
            // lvUsuarios
            // 
            this.lvUsuarios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lvUsuarios.FullRowSelect = true;
            this.lvUsuarios.Location = new System.Drawing.Point(15, 75);
            this.lvUsuarios.Name = "lvUsuarios";
            this.lvUsuarios.Size = new System.Drawing.Size(455, 118);
            this.lvUsuarios.TabIndex = 0;
            this.lvUsuarios.UseCompatibleStateImageBehavior = false;
            this.lvUsuarios.View = System.Windows.Forms.View.Details;
            this.lvUsuarios.SelectedIndexChanged += new System.EventHandler(this.lvUsuarios_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Tipo";
            this.columnHeader9.Width = 119;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Nombre";
            this.columnHeader10.Width = 171;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Fecha registro";
            this.columnHeader11.Width = 159;
            // 
            // gbUsuario
            // 
            this.gbUsuario.Controls.Add(this.btnCLEAR_Usuarios);
            this.gbUsuario.Controls.Add(this.btnDEL_Usuario);
            this.gbUsuario.Controls.Add(this.btnPUT_Usuario);
            this.gbUsuario.Controls.Add(this.btnPOST_Usuario);
            this.gbUsuario.Controls.Add(this.btnGET_Usuario);
            this.gbUsuario.Controls.Add(this.txtID_Usuario);
            this.gbUsuario.Controls.Add(this.cmbTipo);
            this.gbUsuario.Controls.Add(this.txtPassword);
            this.gbUsuario.Controls.Add(this.txtUsuario);
            this.gbUsuario.Controls.Add(this.lblTipo);
            this.gbUsuario.Controls.Add(this.lblPassword);
            this.gbUsuario.Controls.Add(this.lblUsuario);
            this.gbUsuario.Location = new System.Drawing.Point(15, 17);
            this.gbUsuario.Name = "gbUsuario";
            this.gbUsuario.Size = new System.Drawing.Size(210, 212);
            this.gbUsuario.TabIndex = 2;
            this.gbUsuario.TabStop = false;
            this.gbUsuario.Text = "Datos del usuario";
            // 
            // btnCLEAR_Usuarios
            // 
            this.btnCLEAR_Usuarios.Location = new System.Drawing.Point(58, 131);
            this.btnCLEAR_Usuarios.Name = "btnCLEAR_Usuarios";
            this.btnCLEAR_Usuarios.Size = new System.Drawing.Size(56, 23);
            this.btnCLEAR_Usuarios.TabIndex = 17;
            this.btnCLEAR_Usuarios.Text = "CLEAR";
            this.btnCLEAR_Usuarios.UseVisualStyleBackColor = true;
            this.btnCLEAR_Usuarios.Click += new System.EventHandler(this.btnCLEAR_Usuarios_Click);
            // 
            // btnDEL_Usuario
            // 
            this.btnDEL_Usuario.Location = new System.Drawing.Point(158, 170);
            this.btnDEL_Usuario.Name = "btnDEL_Usuario";
            this.btnDEL_Usuario.Size = new System.Drawing.Size(42, 23);
            this.btnDEL_Usuario.TabIndex = 16;
            this.btnDEL_Usuario.Text = "DEL";
            this.btnDEL_Usuario.UseVisualStyleBackColor = true;
            this.btnDEL_Usuario.Click += new System.EventHandler(this.btnDEL_Usuario_Click);
            // 
            // btnPUT_Usuario
            // 
            this.btnPUT_Usuario.Location = new System.Drawing.Point(112, 170);
            this.btnPUT_Usuario.Name = "btnPUT_Usuario";
            this.btnPUT_Usuario.Size = new System.Drawing.Size(40, 23);
            this.btnPUT_Usuario.TabIndex = 15;
            this.btnPUT_Usuario.Text = "PUT";
            this.btnPUT_Usuario.UseVisualStyleBackColor = true;
            this.btnPUT_Usuario.Click += new System.EventHandler(this.btnPUT_Usuario_Click);
            // 
            // btnPOST_Usuario
            // 
            this.btnPOST_Usuario.Location = new System.Drawing.Point(58, 170);
            this.btnPOST_Usuario.Name = "btnPOST_Usuario";
            this.btnPOST_Usuario.Size = new System.Drawing.Size(48, 23);
            this.btnPOST_Usuario.TabIndex = 14;
            this.btnPOST_Usuario.Text = "POST";
            this.btnPOST_Usuario.UseVisualStyleBackColor = true;
            this.btnPOST_Usuario.Click += new System.EventHandler(this.btnPOST_Usuario_Click);
            // 
            // btnGET_Usuario
            // 
            this.btnGET_Usuario.Location = new System.Drawing.Point(14, 170);
            this.btnGET_Usuario.Name = "btnGET_Usuario";
            this.btnGET_Usuario.Size = new System.Drawing.Size(38, 23);
            this.btnGET_Usuario.TabIndex = 13;
            this.btnGET_Usuario.Text = "GET";
            this.btnGET_Usuario.UseVisualStyleBackColor = true;
            this.btnGET_Usuario.Click += new System.EventHandler(this.btnGET_Usuario_Click);
            // 
            // txtID_Usuario
            // 
            this.txtID_Usuario.Location = new System.Drawing.Point(12, 134);
            this.txtID_Usuario.Name = "txtID_Usuario";
            this.txtID_Usuario.ReadOnly = true;
            this.txtID_Usuario.Size = new System.Drawing.Size(40, 20);
            this.txtID_Usuario.TabIndex = 7;
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Usuario",
            "Administrador"});
            this.cmbTipo.Location = new System.Drawing.Point(58, 91);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(136, 21);
            this.cmbTipo.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(83, 62);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(111, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(73, 33);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(121, 20);
            this.txtUsuario.TabIndex = 3;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(15, 94);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(37, 13);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo : ";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(15, 62);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(62, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password : ";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(15, 33);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(52, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario : ";
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 441);
            this.Controls.Add(this.tcOpciones);
            this.MaximizeBox = false;
            this.Name = "FormHome";
            this.Text = "Cliente REST API";
            this.tcOpciones.ResumeLayout(false);
            this.tpAPI.ResumeLayout(false);
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.gbIngreseURL.ResumeLayout(false);
            this.gbIngreseURL.PerformLayout();
            this.tpProductos.ResumeLayout(false);
            this.gbProductos.ResumeLayout(false);
            this.gbProductos.PerformLayout();
            this.gbProducto.ResumeLayout(false);
            this.gbProducto.PerformLayout();
            this.tpProveedores.ResumeLayout(false);
            this.gbProveedores.ResumeLayout(false);
            this.gbProveedores.PerformLayout();
            this.gbProveedor.ResumeLayout(false);
            this.gbProveedor.PerformLayout();
            this.tpUsuarios.ResumeLayout(false);
            this.gbUsuarios.ResumeLayout(false);
            this.gbUsuarios.PerformLayout();
            this.gbUsuario.ResumeLayout(false);
            this.gbUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcOpciones;
        private System.Windows.Forms.TabPage tpProductos;
        private System.Windows.Forms.TabPage tpProveedores;
        private System.Windows.Forms.TabPage tpUsuarios;
        private System.Windows.Forms.GroupBox gbProductos;
        private System.Windows.Forms.TextBox txtNombreBuscar;
        private System.Windows.Forms.Label lblNombreBuscar;
        private System.Windows.Forms.ListView lvProductos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox gbProducto;
        private System.Windows.Forms.TextBox txtID_Producto;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Button btnPOST_Producto;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.RichTextBox rtbDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox gbProveedores;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvProveedores;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.GroupBox gbProveedor;
        private System.Windows.Forms.TextBox txtID_Proveedor;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtNombreEmpresa;
        private System.Windows.Forms.Label lblNombreEmpresa;
        private System.Windows.Forms.GroupBox gbUsuarios;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.ListView lvUsuarios;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.GroupBox gbUsuario;
        private System.Windows.Forms.TextBox txtID_Usuario;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnPUT_Producto;
        private System.Windows.Forms.Button btnGET_Producto;
        private System.Windows.Forms.Button btnDEL_Producto;
        private System.Windows.Forms.Button btnDEL_Proveedor;
        private System.Windows.Forms.Button btnPUT_Proveedor;
        private System.Windows.Forms.Button btnPOST_Proveedor;
        private System.Windows.Forms.Button btnGET_Proveedor;
        private System.Windows.Forms.Button btnDEL_Usuario;
        private System.Windows.Forms.Button btnPUT_Usuario;
        private System.Windows.Forms.Button btnPOST_Usuario;
        private System.Windows.Forms.Button btnGET_Usuario;
        private System.Windows.Forms.TabPage tpAPI;
        private System.Windows.Forms.GroupBox gbIngreseURL;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.RadioButton rbXML;
        private System.Windows.Forms.RadioButton rbJSON;
        private System.Windows.Forms.Button btnCLEAR_Productos;
        private System.Windows.Forms.Button btnCLEAR_Proveedores;
        private System.Windows.Forms.Button btnBuscarProductos;
        private System.Windows.Forms.Button btnBuscarProveedores;
        private System.Windows.Forms.Button btnCLEAR_Usuarios;
    }
}

