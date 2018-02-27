namespace Listas
{
    partial class FormHome
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbArrayList = new System.Windows.Forms.GroupBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.lbLineas = new System.Windows.Forms.ListBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.lblText1 = new System.Windows.Forms.Label();
            this.gbGeneric = new System.Windows.Forms.GroupBox();
            this.btnListar2 = new System.Windows.Forms.Button();
            this.lbLineas2 = new System.Windows.Forms.ListBox();
            this.btnAgregar2 = new System.Windows.Forms.Button();
            this.txtTexto2 = new System.Windows.Forms.TextBox();
            this.lblText2 = new System.Windows.Forms.Label();
            this.gbArrayList.SuspendLayout();
            this.gbGeneric.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbArrayList
            // 
            this.gbArrayList.Controls.Add(this.btnListar);
            this.gbArrayList.Controls.Add(this.lbLineas);
            this.gbArrayList.Controls.Add(this.btnAgregar);
            this.gbArrayList.Controls.Add(this.txtTexto);
            this.gbArrayList.Controls.Add(this.lblText1);
            this.gbArrayList.Location = new System.Drawing.Point(12, 12);
            this.gbArrayList.Name = "gbArrayList";
            this.gbArrayList.Size = new System.Drawing.Size(260, 228);
            this.gbArrayList.TabIndex = 0;
            this.gbArrayList.TabStop = false;
            this.gbArrayList.Text = "ArrayList";
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(97, 186);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 23);
            this.btnListar.TabIndex = 4;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // lbLineas
            // 
            this.lbLineas.FormattingEnabled = true;
            this.lbLineas.Location = new System.Drawing.Point(22, 74);
            this.lbLineas.Name = "lbLineas";
            this.lbLineas.Size = new System.Drawing.Size(217, 95);
            this.lbLineas.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(164, 30);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtTexto
            // 
            this.txtTexto.Location = new System.Drawing.Point(68, 30);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(90, 20);
            this.txtTexto.TabIndex = 1;
            // 
            // lblText1
            // 
            this.lblText1.AutoSize = true;
            this.lblText1.Location = new System.Drawing.Point(19, 33);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(43, 13);
            this.lblText1.TabIndex = 0;
            this.lblText1.Text = "Texto : ";
            // 
            // gbGeneric
            // 
            this.gbGeneric.Controls.Add(this.btnListar2);
            this.gbGeneric.Controls.Add(this.lbLineas2);
            this.gbGeneric.Controls.Add(this.btnAgregar2);
            this.gbGeneric.Controls.Add(this.txtTexto2);
            this.gbGeneric.Controls.Add(this.lblText2);
            this.gbGeneric.Location = new System.Drawing.Point(278, 12);
            this.gbGeneric.Name = "gbGeneric";
            this.gbGeneric.Size = new System.Drawing.Size(260, 228);
            this.gbGeneric.TabIndex = 1;
            this.gbGeneric.TabStop = false;
            this.gbGeneric.Text = "Generic";
            // 
            // btnListar2
            // 
            this.btnListar2.Location = new System.Drawing.Point(97, 186);
            this.btnListar2.Name = "btnListar2";
            this.btnListar2.Size = new System.Drawing.Size(75, 23);
            this.btnListar2.TabIndex = 4;
            this.btnListar2.Text = "Listar";
            this.btnListar2.UseVisualStyleBackColor = true;
            this.btnListar2.Click += new System.EventHandler(this.btnListar2_Click);
            // 
            // lbLineas2
            // 
            this.lbLineas2.FormattingEnabled = true;
            this.lbLineas2.Location = new System.Drawing.Point(22, 74);
            this.lbLineas2.Name = "lbLineas2";
            this.lbLineas2.Size = new System.Drawing.Size(217, 95);
            this.lbLineas2.TabIndex = 3;
            // 
            // btnAgregar2
            // 
            this.btnAgregar2.Location = new System.Drawing.Point(164, 30);
            this.btnAgregar2.Name = "btnAgregar2";
            this.btnAgregar2.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar2.TabIndex = 2;
            this.btnAgregar2.Text = "Agregar";
            this.btnAgregar2.UseVisualStyleBackColor = true;
            this.btnAgregar2.Click += new System.EventHandler(this.btnAgregar2_Click);
            // 
            // txtTexto2
            // 
            this.txtTexto2.Location = new System.Drawing.Point(68, 30);
            this.txtTexto2.Name = "txtTexto2";
            this.txtTexto2.Size = new System.Drawing.Size(90, 20);
            this.txtTexto2.TabIndex = 1;
            // 
            // lblText2
            // 
            this.lblText2.AutoSize = true;
            this.lblText2.Location = new System.Drawing.Point(19, 33);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(43, 13);
            this.lblText2.TabIndex = 0;
            this.lblText2.Text = "Texto : ";
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 256);
            this.Controls.Add(this.gbGeneric);
            this.Controls.Add(this.gbArrayList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormHome";
            this.Text = "Ejercicio de Listas";
            this.gbArrayList.ResumeLayout(false);
            this.gbArrayList.PerformLayout();
            this.gbGeneric.ResumeLayout(false);
            this.gbGeneric.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbArrayList;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.ListBox lbLineas;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.GroupBox gbGeneric;
        private System.Windows.Forms.Button btnListar2;
        private System.Windows.Forms.ListBox lbLineas2;
        private System.Windows.Forms.Button btnAgregar2;
        private System.Windows.Forms.TextBox txtTexto2;
        private System.Windows.Forms.Label lblText2;
    }
}

