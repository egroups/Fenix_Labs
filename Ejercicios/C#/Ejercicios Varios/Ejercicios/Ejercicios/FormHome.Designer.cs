namespace Ejercicios
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
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
            this.tcOptions = new System.Windows.Forms.TabControl();
            this.tpReverseString = new System.Windows.Forms.TabPage();
            this.tpNotas = new System.Windows.Forms.TabPage();
            this.tpEnteros = new System.Windows.Forms.TabPage();
            this.tpFactorial = new System.Windows.Forms.TabPage();
            this.lblTexto = new System.Windows.Forms.Label();
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.lblSalida = new System.Windows.Forms.Label();
            this.txtSalida = new System.Windows.Forms.TextBox();
            this.btnReverseString = new System.Windows.Forms.Button();
            this.lblMatematica = new System.Windows.Forms.Label();
            this.lblFisica = new System.Windows.Forms.Label();
            this.lblQuimica = new System.Windows.Forms.Label();
            this.lblLengua = new System.Windows.Forms.Label();
            this.lblGeografia = new System.Windows.Forms.Label();
            this.txtNotaMatematica = new System.Windows.Forms.TextBox();
            this.txtNotaFisica = new System.Windows.Forms.TextBox();
            this.txtNotaQuimica = new System.Windows.Forms.TextBox();
            this.txtNotaLengua = new System.Windows.Forms.TextBox();
            this.txtNotaGeografia = new System.Windows.Forms.TextBox();
            this.btnAgregarNotaMatematica = new System.Windows.Forms.Button();
            this.btnAgregarNotaFisica = new System.Windows.Forms.Button();
            this.btnAgregarNotaQuimica = new System.Windows.Forms.Button();
            this.btnAgregarNotaLengua = new System.Windows.Forms.Button();
            this.btnAgregarNotaGeografia = new System.Windows.Forms.Button();
            this.mmOutput = new System.Windows.Forms.RichTextBox();
            this.btnPromedioMatematica = new System.Windows.Forms.Button();
            this.btnPromedioFisica = new System.Windows.Forms.Button();
            this.btnPromedioQuimica = new System.Windows.Forms.Button();
            this.btnPromedioLengua = new System.Windows.Forms.Button();
            this.btnPromedioGeografia = new System.Windows.Forms.Button();
            this.btnLimpiarMatematica = new System.Windows.Forms.Button();
            this.btnLimpiarFisica = new System.Windows.Forms.Button();
            this.btnLimpiarQuimica = new System.Windows.Forms.Button();
            this.btnLimpiarLengua = new System.Windows.Forms.Button();
            this.btnLimpiarGeografia = new System.Windows.Forms.Button();
            this.tcOptions.SuspendLayout();
            this.tpReverseString.SuspendLayout();
            this.tpNotas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcOptions
            // 
            this.tcOptions.Controls.Add(this.tpReverseString);
            this.tcOptions.Controls.Add(this.tpNotas);
            this.tcOptions.Controls.Add(this.tpEnteros);
            this.tcOptions.Controls.Add(this.tpFactorial);
            this.tcOptions.Location = new System.Drawing.Point(12, 23);
            this.tcOptions.Name = "tcOptions";
            this.tcOptions.SelectedIndex = 0;
            this.tcOptions.Size = new System.Drawing.Size(446, 365);
            this.tcOptions.TabIndex = 0;
            // 
            // tpReverseString
            // 
            this.tpReverseString.Controls.Add(this.btnReverseString);
            this.tpReverseString.Controls.Add(this.txtSalida);
            this.tpReverseString.Controls.Add(this.lblSalida);
            this.tpReverseString.Controls.Add(this.txtEntrada);
            this.tpReverseString.Controls.Add(this.lblTexto);
            this.tpReverseString.Location = new System.Drawing.Point(4, 22);
            this.tpReverseString.Name = "tpReverseString";
            this.tpReverseString.Padding = new System.Windows.Forms.Padding(3);
            this.tpReverseString.Size = new System.Drawing.Size(438, 227);
            this.tpReverseString.TabIndex = 0;
            this.tpReverseString.Text = "ReverseString";
            this.tpReverseString.UseVisualStyleBackColor = true;
            // 
            // tpNotas
            // 
            this.tpNotas.Controls.Add(this.btnLimpiarGeografia);
            this.tpNotas.Controls.Add(this.btnLimpiarLengua);
            this.tpNotas.Controls.Add(this.btnLimpiarQuimica);
            this.tpNotas.Controls.Add(this.btnLimpiarFisica);
            this.tpNotas.Controls.Add(this.btnLimpiarMatematica);
            this.tpNotas.Controls.Add(this.btnPromedioGeografia);
            this.tpNotas.Controls.Add(this.btnPromedioLengua);
            this.tpNotas.Controls.Add(this.btnPromedioQuimica);
            this.tpNotas.Controls.Add(this.btnPromedioFisica);
            this.tpNotas.Controls.Add(this.btnPromedioMatematica);
            this.tpNotas.Controls.Add(this.mmOutput);
            this.tpNotas.Controls.Add(this.btnAgregarNotaGeografia);
            this.tpNotas.Controls.Add(this.btnAgregarNotaLengua);
            this.tpNotas.Controls.Add(this.btnAgregarNotaQuimica);
            this.tpNotas.Controls.Add(this.btnAgregarNotaFisica);
            this.tpNotas.Controls.Add(this.btnAgregarNotaMatematica);
            this.tpNotas.Controls.Add(this.txtNotaGeografia);
            this.tpNotas.Controls.Add(this.txtNotaLengua);
            this.tpNotas.Controls.Add(this.txtNotaQuimica);
            this.tpNotas.Controls.Add(this.txtNotaFisica);
            this.tpNotas.Controls.Add(this.txtNotaMatematica);
            this.tpNotas.Controls.Add(this.lblGeografia);
            this.tpNotas.Controls.Add(this.lblLengua);
            this.tpNotas.Controls.Add(this.lblQuimica);
            this.tpNotas.Controls.Add(this.lblFisica);
            this.tpNotas.Controls.Add(this.lblMatematica);
            this.tpNotas.Location = new System.Drawing.Point(4, 22);
            this.tpNotas.Name = "tpNotas";
            this.tpNotas.Padding = new System.Windows.Forms.Padding(3);
            this.tpNotas.Size = new System.Drawing.Size(438, 339);
            this.tpNotas.TabIndex = 1;
            this.tpNotas.Text = "Notas";
            this.tpNotas.UseVisualStyleBackColor = true;
            // 
            // tpEnteros
            // 
            this.tpEnteros.Location = new System.Drawing.Point(4, 22);
            this.tpEnteros.Name = "tpEnteros";
            this.tpEnteros.Size = new System.Drawing.Size(438, 339);
            this.tpEnteros.TabIndex = 2;
            this.tpEnteros.Text = "Enteros";
            this.tpEnteros.UseVisualStyleBackColor = true;
            // 
            // tpFactorial
            // 
            this.tpFactorial.Location = new System.Drawing.Point(4, 22);
            this.tpFactorial.Name = "tpFactorial";
            this.tpFactorial.Size = new System.Drawing.Size(438, 227);
            this.tpFactorial.TabIndex = 3;
            this.tpFactorial.Text = "Factorial";
            this.tpFactorial.UseVisualStyleBackColor = true;
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Location = new System.Drawing.Point(16, 26);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(43, 13);
            this.lblTexto.TabIndex = 0;
            this.lblTexto.Text = "Texto : ";
            // 
            // txtEntrada
            // 
            this.txtEntrada.Location = new System.Drawing.Point(65, 26);
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(350, 20);
            this.txtEntrada.TabIndex = 1;
            // 
            // lblSalida
            // 
            this.lblSalida.AutoSize = true;
            this.lblSalida.Location = new System.Drawing.Point(16, 64);
            this.lblSalida.Name = "lblSalida";
            this.lblSalida.Size = new System.Drawing.Size(45, 13);
            this.lblSalida.TabIndex = 2;
            this.lblSalida.Text = "Salida : ";
            // 
            // txtSalida
            // 
            this.txtSalida.Location = new System.Drawing.Point(65, 64);
            this.txtSalida.Name = "txtSalida";
            this.txtSalida.Size = new System.Drawing.Size(350, 20);
            this.txtSalida.TabIndex = 3;
            // 
            // btnReverseString
            // 
            this.btnReverseString.Location = new System.Drawing.Point(112, 110);
            this.btnReverseString.Name = "btnReverseString";
            this.btnReverseString.Size = new System.Drawing.Size(205, 23);
            this.btnReverseString.TabIndex = 4;
            this.btnReverseString.Text = "ReverseString";
            this.btnReverseString.UseVisualStyleBackColor = true;
            this.btnReverseString.Click += new System.EventHandler(this.btnReverseString_Click);
            // 
            // lblMatematica
            // 
            this.lblMatematica.AutoSize = true;
            this.lblMatematica.Location = new System.Drawing.Point(20, 17);
            this.lblMatematica.Name = "lblMatematica";
            this.lblMatematica.Size = new System.Drawing.Size(71, 13);
            this.lblMatematica.TabIndex = 0;
            this.lblMatematica.Text = "Matematica : ";
            // 
            // lblFisica
            // 
            this.lblFisica.AutoSize = true;
            this.lblFisica.Location = new System.Drawing.Point(20, 48);
            this.lblFisica.Name = "lblFisica";
            this.lblFisica.Size = new System.Drawing.Size(43, 13);
            this.lblFisica.TabIndex = 1;
            this.lblFisica.Text = "Fisica : ";
            // 
            // lblQuimica
            // 
            this.lblQuimica.AutoSize = true;
            this.lblQuimica.Location = new System.Drawing.Point(20, 78);
            this.lblQuimica.Name = "lblQuimica";
            this.lblQuimica.Size = new System.Drawing.Size(54, 13);
            this.lblQuimica.TabIndex = 2;
            this.lblQuimica.Text = "Quimica : ";
            // 
            // lblLengua
            // 
            this.lblLengua.AutoSize = true;
            this.lblLengua.Location = new System.Drawing.Point(20, 109);
            this.lblLengua.Name = "lblLengua";
            this.lblLengua.Size = new System.Drawing.Size(52, 13);
            this.lblLengua.TabIndex = 3;
            this.lblLengua.Text = "Lengua : ";
            // 
            // lblGeografia
            // 
            this.lblGeografia.AutoSize = true;
            this.lblGeografia.Location = new System.Drawing.Point(20, 139);
            this.lblGeografia.Name = "lblGeografia";
            this.lblGeografia.Size = new System.Drawing.Size(62, 13);
            this.lblGeografia.TabIndex = 4;
            this.lblGeografia.Text = "Geografia : ";
            // 
            // txtNotaMatematica
            // 
            this.txtNotaMatematica.Location = new System.Drawing.Point(97, 17);
            this.txtNotaMatematica.Name = "txtNotaMatematica";
            this.txtNotaMatematica.Size = new System.Drawing.Size(100, 20);
            this.txtNotaMatematica.TabIndex = 5;
            // 
            // txtNotaFisica
            // 
            this.txtNotaFisica.Location = new System.Drawing.Point(69, 48);
            this.txtNotaFisica.Name = "txtNotaFisica";
            this.txtNotaFisica.Size = new System.Drawing.Size(100, 20);
            this.txtNotaFisica.TabIndex = 6;
            // 
            // txtNotaQuimica
            // 
            this.txtNotaQuimica.Location = new System.Drawing.Point(80, 78);
            this.txtNotaQuimica.Name = "txtNotaQuimica";
            this.txtNotaQuimica.Size = new System.Drawing.Size(100, 20);
            this.txtNotaQuimica.TabIndex = 7;
            // 
            // txtNotaLengua
            // 
            this.txtNotaLengua.Location = new System.Drawing.Point(78, 109);
            this.txtNotaLengua.Name = "txtNotaLengua";
            this.txtNotaLengua.Size = new System.Drawing.Size(100, 20);
            this.txtNotaLengua.TabIndex = 8;
            // 
            // txtNotaGeografia
            // 
            this.txtNotaGeografia.Location = new System.Drawing.Point(88, 139);
            this.txtNotaGeografia.Name = "txtNotaGeografia";
            this.txtNotaGeografia.Size = new System.Drawing.Size(100, 20);
            this.txtNotaGeografia.TabIndex = 9;
            // 
            // btnAgregarNotaMatematica
            // 
            this.btnAgregarNotaMatematica.Location = new System.Drawing.Point(203, 17);
            this.btnAgregarNotaMatematica.Name = "btnAgregarNotaMatematica";
            this.btnAgregarNotaMatematica.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarNotaMatematica.TabIndex = 10;
            this.btnAgregarNotaMatematica.Text = "Agregar";
            this.btnAgregarNotaMatematica.UseVisualStyleBackColor = true;
            this.btnAgregarNotaMatematica.Click += new System.EventHandler(this.btnAgregarNotaMatematica_Click);
            // 
            // btnAgregarNotaFisica
            // 
            this.btnAgregarNotaFisica.Location = new System.Drawing.Point(175, 48);
            this.btnAgregarNotaFisica.Name = "btnAgregarNotaFisica";
            this.btnAgregarNotaFisica.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarNotaFisica.TabIndex = 11;
            this.btnAgregarNotaFisica.Text = "Agregar";
            this.btnAgregarNotaFisica.UseVisualStyleBackColor = true;
            this.btnAgregarNotaFisica.Click += new System.EventHandler(this.btnAgregarNotaFisica_Click);
            // 
            // btnAgregarNotaQuimica
            // 
            this.btnAgregarNotaQuimica.Location = new System.Drawing.Point(186, 78);
            this.btnAgregarNotaQuimica.Name = "btnAgregarNotaQuimica";
            this.btnAgregarNotaQuimica.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarNotaQuimica.TabIndex = 12;
            this.btnAgregarNotaQuimica.Text = "Agregar";
            this.btnAgregarNotaQuimica.UseVisualStyleBackColor = true;
            this.btnAgregarNotaQuimica.Click += new System.EventHandler(this.btnAgregarNotaQuimica_Click);
            // 
            // btnAgregarNotaLengua
            // 
            this.btnAgregarNotaLengua.Location = new System.Drawing.Point(186, 107);
            this.btnAgregarNotaLengua.Name = "btnAgregarNotaLengua";
            this.btnAgregarNotaLengua.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarNotaLengua.TabIndex = 13;
            this.btnAgregarNotaLengua.Text = "Agregar";
            this.btnAgregarNotaLengua.UseVisualStyleBackColor = true;
            this.btnAgregarNotaLengua.Click += new System.EventHandler(this.btnAgregarNotaLengua_Click);
            // 
            // btnAgregarNotaGeografia
            // 
            this.btnAgregarNotaGeografia.Location = new System.Drawing.Point(194, 136);
            this.btnAgregarNotaGeografia.Name = "btnAgregarNotaGeografia";
            this.btnAgregarNotaGeografia.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarNotaGeografia.TabIndex = 14;
            this.btnAgregarNotaGeografia.Text = "Agregar";
            this.btnAgregarNotaGeografia.UseVisualStyleBackColor = true;
            this.btnAgregarNotaGeografia.Click += new System.EventHandler(this.btnAgregarNotaGeografia_Click);
            // 
            // mmOutput
            // 
            this.mmOutput.Location = new System.Drawing.Point(23, 179);
            this.mmOutput.Name = "mmOutput";
            this.mmOutput.Size = new System.Drawing.Size(389, 142);
            this.mmOutput.TabIndex = 15;
            this.mmOutput.Text = "";
            // 
            // btnPromedioMatematica
            // 
            this.btnPromedioMatematica.Location = new System.Drawing.Point(284, 17);
            this.btnPromedioMatematica.Name = "btnPromedioMatematica";
            this.btnPromedioMatematica.Size = new System.Drawing.Size(75, 23);
            this.btnPromedioMatematica.TabIndex = 16;
            this.btnPromedioMatematica.Text = "Promedio";
            this.btnPromedioMatematica.UseVisualStyleBackColor = true;
            this.btnPromedioMatematica.Click += new System.EventHandler(this.btnPromedioMatematica_Click);
            // 
            // btnPromedioFisica
            // 
            this.btnPromedioFisica.Location = new System.Drawing.Point(267, 46);
            this.btnPromedioFisica.Name = "btnPromedioFisica";
            this.btnPromedioFisica.Size = new System.Drawing.Size(75, 23);
            this.btnPromedioFisica.TabIndex = 17;
            this.btnPromedioFisica.Text = "Promedio";
            this.btnPromedioFisica.UseVisualStyleBackColor = true;
            this.btnPromedioFisica.Click += new System.EventHandler(this.btnPromedioFisica_Click);
            // 
            // btnPromedioQuimica
            // 
            this.btnPromedioQuimica.Location = new System.Drawing.Point(267, 78);
            this.btnPromedioQuimica.Name = "btnPromedioQuimica";
            this.btnPromedioQuimica.Size = new System.Drawing.Size(75, 23);
            this.btnPromedioQuimica.TabIndex = 18;
            this.btnPromedioQuimica.Text = "Promedio";
            this.btnPromedioQuimica.UseVisualStyleBackColor = true;
            this.btnPromedioQuimica.Click += new System.EventHandler(this.btnPromedioQuimica_Click);
            // 
            // btnPromedioLengua
            // 
            this.btnPromedioLengua.Location = new System.Drawing.Point(267, 107);
            this.btnPromedioLengua.Name = "btnPromedioLengua";
            this.btnPromedioLengua.Size = new System.Drawing.Size(75, 23);
            this.btnPromedioLengua.TabIndex = 19;
            this.btnPromedioLengua.Text = "Promedio";
            this.btnPromedioLengua.UseVisualStyleBackColor = true;
            this.btnPromedioLengua.Click += new System.EventHandler(this.btnPromedioLengua_Click);
            // 
            // btnPromedioGeografia
            // 
            this.btnPromedioGeografia.Location = new System.Drawing.Point(275, 136);
            this.btnPromedioGeografia.Name = "btnPromedioGeografia";
            this.btnPromedioGeografia.Size = new System.Drawing.Size(75, 23);
            this.btnPromedioGeografia.TabIndex = 20;
            this.btnPromedioGeografia.Text = "Promedio";
            this.btnPromedioGeografia.UseVisualStyleBackColor = true;
            this.btnPromedioGeografia.Click += new System.EventHandler(this.btnPromedioGeografia_Click);
            // 
            // btnLimpiarMatematica
            // 
            this.btnLimpiarMatematica.Location = new System.Drawing.Point(365, 17);
            this.btnLimpiarMatematica.Name = "btnLimpiarMatematica";
            this.btnLimpiarMatematica.Size = new System.Drawing.Size(56, 23);
            this.btnLimpiarMatematica.TabIndex = 21;
            this.btnLimpiarMatematica.Text = "Limpiar";
            this.btnLimpiarMatematica.UseVisualStyleBackColor = true;
            this.btnLimpiarMatematica.Click += new System.EventHandler(this.btnLimpiarMatematica_Click);
            // 
            // btnLimpiarFisica
            // 
            this.btnLimpiarFisica.Location = new System.Drawing.Point(348, 48);
            this.btnLimpiarFisica.Name = "btnLimpiarFisica";
            this.btnLimpiarFisica.Size = new System.Drawing.Size(56, 23);
            this.btnLimpiarFisica.TabIndex = 22;
            this.btnLimpiarFisica.Text = "Limpiar";
            this.btnLimpiarFisica.UseVisualStyleBackColor = true;
            this.btnLimpiarFisica.Click += new System.EventHandler(this.btnLimpiarFisica_Click);
            // 
            // btnLimpiarQuimica
            // 
            this.btnLimpiarQuimica.Location = new System.Drawing.Point(348, 78);
            this.btnLimpiarQuimica.Name = "btnLimpiarQuimica";
            this.btnLimpiarQuimica.Size = new System.Drawing.Size(56, 23);
            this.btnLimpiarQuimica.TabIndex = 23;
            this.btnLimpiarQuimica.Text = "Limpiar";
            this.btnLimpiarQuimica.UseVisualStyleBackColor = true;
            this.btnLimpiarQuimica.Click += new System.EventHandler(this.btnLimpiarQuimica_Click);
            // 
            // btnLimpiarLengua
            // 
            this.btnLimpiarLengua.Location = new System.Drawing.Point(348, 106);
            this.btnLimpiarLengua.Name = "btnLimpiarLengua";
            this.btnLimpiarLengua.Size = new System.Drawing.Size(56, 23);
            this.btnLimpiarLengua.TabIndex = 24;
            this.btnLimpiarLengua.Text = "Limpiar";
            this.btnLimpiarLengua.UseVisualStyleBackColor = true;
            this.btnLimpiarLengua.Click += new System.EventHandler(this.btnLimpiarLengua_Click);
            // 
            // btnLimpiarGeografia
            // 
            this.btnLimpiarGeografia.Location = new System.Drawing.Point(356, 134);
            this.btnLimpiarGeografia.Name = "btnLimpiarGeografia";
            this.btnLimpiarGeografia.Size = new System.Drawing.Size(56, 23);
            this.btnLimpiarGeografia.TabIndex = 25;
            this.btnLimpiarGeografia.Text = "Limpiar";
            this.btnLimpiarGeografia.UseVisualStyleBackColor = true;
            this.btnLimpiarGeografia.Click += new System.EventHandler(this.btnLimpiarGeografia_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 400);
            this.Controls.Add(this.tcOptions);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Ejercicios";
            this.tcOptions.ResumeLayout(false);
            this.tpReverseString.ResumeLayout(false);
            this.tpReverseString.PerformLayout();
            this.tpNotas.ResumeLayout(false);
            this.tpNotas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcOptions;
        private System.Windows.Forms.TabPage tpReverseString;
        private System.Windows.Forms.TabPage tpNotas;
        private System.Windows.Forms.TabPage tpEnteros;
        private System.Windows.Forms.TabPage tpFactorial;
        private System.Windows.Forms.Button btnReverseString;
        private System.Windows.Forms.TextBox txtSalida;
        private System.Windows.Forms.Label lblSalida;
        private System.Windows.Forms.TextBox txtEntrada;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Label lblGeografia;
        private System.Windows.Forms.Label lblLengua;
        private System.Windows.Forms.Label lblQuimica;
        private System.Windows.Forms.Label lblFisica;
        private System.Windows.Forms.Label lblMatematica;
        private System.Windows.Forms.TextBox txtNotaGeografia;
        private System.Windows.Forms.TextBox txtNotaLengua;
        private System.Windows.Forms.TextBox txtNotaQuimica;
        private System.Windows.Forms.TextBox txtNotaFisica;
        private System.Windows.Forms.TextBox txtNotaMatematica;
        private System.Windows.Forms.Button btnAgregarNotaGeografia;
        private System.Windows.Forms.Button btnAgregarNotaLengua;
        private System.Windows.Forms.Button btnAgregarNotaQuimica;
        private System.Windows.Forms.Button btnAgregarNotaFisica;
        private System.Windows.Forms.Button btnAgregarNotaMatematica;
        private System.Windows.Forms.RichTextBox mmOutput;
        private System.Windows.Forms.Button btnPromedioMatematica;
        private System.Windows.Forms.Button btnPromedioGeografia;
        private System.Windows.Forms.Button btnPromedioLengua;
        private System.Windows.Forms.Button btnPromedioQuimica;
        private System.Windows.Forms.Button btnPromedioFisica;
        private System.Windows.Forms.Button btnLimpiarGeografia;
        private System.Windows.Forms.Button btnLimpiarLengua;
        private System.Windows.Forms.Button btnLimpiarQuimica;
        private System.Windows.Forms.Button btnLimpiarFisica;
        private System.Windows.Forms.Button btnLimpiarMatematica;
    }
}

