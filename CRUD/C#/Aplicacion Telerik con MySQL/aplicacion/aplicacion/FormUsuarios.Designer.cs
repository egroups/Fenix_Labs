namespace aplicacion
{
    partial class FormUsuarios
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Tipo");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Nombre");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn3 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Fecha Registro");
            this.Theme = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.ItemOpciones = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemAgregarUsuario = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemEditarUsuario = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemBorrarUsuario = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemCancelar = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemRecargarLista = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemGrabar = new Telerik.WinControls.UI.RadMenuItem();
            this.gbDatos = new Telerik.WinControls.UI.RadGroupBox();
            this.txtID = new Telerik.WinControls.UI.RadTextBox();
            this.btnGrabar = new Telerik.WinControls.UI.RadButton();
            this.cmbTipo = new Telerik.WinControls.UI.RadDropDownList();
            this.txtPassword = new Telerik.WinControls.UI.RadTextBox();
            this.txtUsuario = new Telerik.WinControls.UI.RadTextBox();
            this.lblTipo = new Telerik.WinControls.UI.RadLabel();
            this.lblPassword = new Telerik.WinControls.UI.RadLabel();
            this.radTextBox2 = new Telerik.WinControls.UI.RadTextBox();
            this.lblNombre = new Telerik.WinControls.UI.RadLabel();
            this.gbUsuarios = new Telerik.WinControls.UI.RadGroupBox();
            this.btnBuscar = new Telerik.WinControls.UI.RadButton();
            this.txtBuscar = new Telerik.WinControls.UI.RadTextBox();
            this.lblNombreBuscar = new Telerik.WinControls.UI.RadLabel();
            this.lvUsuarios = new Telerik.WinControls.UI.RadListView();
            this.ssStatus = new Telerik.WinControls.UI.RadStatusStrip();
            this.status = new Telerik.WinControls.UI.RadLabelElement();
            this.ItemCambiarTipoUsuario = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemUsuario = new Telerik.WinControls.UI.RadMenuItem();
            this.ItemAdministrador = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDatos)).BeginInit();
            this.gbDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrabar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassword)).BeginInit();
            this.lblPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbUsuarios)).BeginInit();
            this.gbUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombreBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvUsuarios)).BeginInit();
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
            this.radMenu1.Size = new System.Drawing.Size(859, 19);
            this.radMenu1.TabIndex = 1;
            this.radMenu1.Text = "radMenu1";
            this.radMenu1.ThemeName = "Office2013Light";
            // 
            // ItemOpciones
            // 
            this.ItemOpciones.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.ItemAgregarUsuario,
            this.ItemEditarUsuario,
            this.ItemBorrarUsuario,
            this.ItemCancelar,
            this.ItemRecargarLista,
            this.ItemGrabar,
            this.ItemCambiarTipoUsuario});
            this.ItemOpciones.Name = "ItemOpciones";
            this.ItemOpciones.Text = "Opciones";
            // 
            // ItemAgregarUsuario
            // 
            this.ItemAgregarUsuario.Name = "ItemAgregarUsuario";
            this.ItemAgregarUsuario.Text = "Agregar Usuario";
            this.ItemAgregarUsuario.Click += new System.EventHandler(this.ItemAgregarUsuario_Click);
            // 
            // ItemEditarUsuario
            // 
            this.ItemEditarUsuario.Name = "ItemEditarUsuario";
            this.ItemEditarUsuario.Text = "Editar Usuario";
            this.ItemEditarUsuario.Click += new System.EventHandler(this.ItemEditarUsuario_Click);
            // 
            // ItemBorrarUsuario
            // 
            this.ItemBorrarUsuario.Name = "ItemBorrarUsuario";
            this.ItemBorrarUsuario.Text = "Borrar Usuario";
            this.ItemBorrarUsuario.Click += new System.EventHandler(this.ItemBorrarUsuario_Click);
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
            this.gbDatos.Controls.Add(this.cmbTipo);
            this.gbDatos.Controls.Add(this.txtPassword);
            this.gbDatos.Controls.Add(this.txtUsuario);
            this.gbDatos.Controls.Add(this.lblTipo);
            this.gbDatos.Controls.Add(this.lblPassword);
            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.HeaderText = "Datos de Usuario";
            this.gbDatos.Location = new System.Drawing.Point(12, 35);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(236, 266);
            this.gbDatos.TabIndex = 2;
            this.gbDatos.Text = "Datos de Usuario";
            this.gbDatos.ThemeName = "Office2013Light";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(33, 160);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(28, 21);
            this.txtID.TabIndex = 9;
            this.txtID.ThemeName = "Office2013Light";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(67, 170);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(110, 24);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.ThemeName = "Office2013Light";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem1.Tag = "2";
            radListDataItem1.Text = "Usuario";
            radListDataItem2.Tag = "1";
            radListDataItem2.Text = "Administrador";
            this.cmbTipo.Items.Add(radListDataItem1);
            this.cmbTipo.Items.Add(radListDataItem2);
            this.cmbTipo.Location = new System.Drawing.Point(60, 121);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(157, 21);
            this.cmbTipo.TabIndex = 7;
            this.cmbTipo.ThemeName = "Office2013Light";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(81, 79);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(139, 21);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.ThemeName = "Office2013Light";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(81, 35);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(139, 21);
            this.txtUsuario.TabIndex = 4;
            this.txtUsuario.ThemeName = "Office2013Light";
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(14, 120);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(40, 19);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo : ";
            this.lblTipo.ThemeName = "Office2013Light";
            // 
            // lblPassword
            // 
            this.lblPassword.Controls.Add(this.radTextBox2);
            this.lblPassword.Location = new System.Drawing.Point(14, 76);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(67, 19);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password : ";
            this.lblPassword.ThemeName = "Office2013Light";
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
            // gbUsuarios
            // 
            this.gbUsuarios.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbUsuarios.Controls.Add(this.btnBuscar);
            this.gbUsuarios.Controls.Add(this.txtBuscar);
            this.gbUsuarios.Controls.Add(this.lblNombreBuscar);
            this.gbUsuarios.Controls.Add(this.lvUsuarios);
            this.gbUsuarios.HeaderText = "Usuarios";
            this.gbUsuarios.Location = new System.Drawing.Point(267, 35);
            this.gbUsuarios.Name = "gbUsuarios";
            this.gbUsuarios.Size = new System.Drawing.Size(559, 266);
            this.gbUsuarios.TabIndex = 4;
            this.gbUsuarios.Text = "Usuarios";
            this.gbUsuarios.ThemeName = "Office2013Light";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(434, 32);
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
            this.txtBuscar.Size = new System.Drawing.Size(325, 21);
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
            // lvUsuarios
            // 
            this.lvUsuarios.AllowEdit = false;
            listViewDetailColumn1.HeaderText = "Tipo";
            listViewDetailColumn2.HeaderText = "Nombre";
            listViewDetailColumn3.HeaderText = "Fecha Registro";
            this.lvUsuarios.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2,
            listViewDetailColumn3});
            this.lvUsuarios.ItemSpacing = -1;
            this.lvUsuarios.Location = new System.Drawing.Point(25, 76);
            this.lvUsuarios.Name = "lvUsuarios";
            this.lvUsuarios.Size = new System.Drawing.Size(534, 175);
            this.lvUsuarios.TabIndex = 0;
            this.lvUsuarios.ThemeName = "Office2013Light";
            this.lvUsuarios.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.lvUsuarios.SelectedItemChanged += new System.EventHandler(this.lvUsuarios_SelectedItemChanged);
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.status});
            this.ssStatus.Location = new System.Drawing.Point(0, 318);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(859, 27);
            this.ssStatus.TabIndex = 6;
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
            // ItemCambiarTipoUsuario
            // 
            this.ItemCambiarTipoUsuario.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.ItemUsuario,
            this.ItemAdministrador});
            this.ItemCambiarTipoUsuario.Name = "ItemCambiarTipoUsuario";
            this.ItemCambiarTipoUsuario.Text = "Cambiar Tipo de Usuario";
            this.ItemCambiarTipoUsuario.Click += new System.EventHandler(this.ItemCambiarTipoUsuario_Click);
            // 
            // ItemUsuario
            // 
            this.ItemUsuario.Name = "ItemUsuario";
            this.ItemUsuario.Text = "Usuario";
            this.ItemUsuario.Click += new System.EventHandler(this.ItemUsuario_Click);
            // 
            // ItemAdministrador
            // 
            this.ItemAdministrador.Name = "ItemAdministrador";
            this.ItemAdministrador.Text = "Administrador";
            this.ItemAdministrador.Click += new System.EventHandler(this.ItemAdministrador_Click);
            // 
            // FormUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 345);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.gbUsuarios);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.radMenu1);
            this.MaximizeBox = false;
            this.Name = "FormUsuarios";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Usuarios";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDatos)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGrabar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPassword)).EndInit();
            this.lblPassword.ResumeLayout(false);
            this.lblPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbUsuarios)).EndInit();
            this.gbUsuarios.ResumeLayout(false);
            this.gbUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombreBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvUsuarios)).EndInit();
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
        private Telerik.WinControls.UI.RadTextBox txtID;
        private Telerik.WinControls.UI.RadButton btnGrabar;
        private Telerik.WinControls.UI.RadDropDownList cmbTipo;
        private Telerik.WinControls.UI.RadTextBox txtPassword;
        private Telerik.WinControls.UI.RadTextBox txtUsuario;
        private Telerik.WinControls.UI.RadLabel lblTipo;
        private Telerik.WinControls.UI.RadLabel lblPassword;
        private Telerik.WinControls.UI.RadTextBox radTextBox2;
        private Telerik.WinControls.UI.RadLabel lblNombre;
        private Telerik.WinControls.UI.RadGroupBox gbUsuarios;
        private Telerik.WinControls.UI.RadButton btnBuscar;
        private Telerik.WinControls.UI.RadTextBox txtBuscar;
        private Telerik.WinControls.UI.RadLabel lblNombreBuscar;
        private Telerik.WinControls.UI.RadListView lvUsuarios;
        private Telerik.WinControls.UI.RadStatusStrip ssStatus;
        private Telerik.WinControls.UI.RadLabelElement status;
        private Telerik.WinControls.UI.RadMenuItem ItemAgregarUsuario;
        private Telerik.WinControls.UI.RadMenuItem ItemEditarUsuario;
        private Telerik.WinControls.UI.RadMenuItem ItemBorrarUsuario;
        private Telerik.WinControls.UI.RadMenuItem ItemCancelar;
        private Telerik.WinControls.UI.RadMenuItem ItemRecargarLista;
        private Telerik.WinControls.UI.RadMenuItem ItemGrabar;
        private Telerik.WinControls.UI.RadMenuItem ItemCambiarTipoUsuario;
        private Telerik.WinControls.UI.RadMenuItem ItemUsuario;
        private Telerik.WinControls.UI.RadMenuItem ItemAdministrador;

    }
}
