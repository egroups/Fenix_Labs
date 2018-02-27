// Written By Ismael Heredia in the year 2016

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ejercicios
{
    public partial class FormHome : Form
    {

        ArrayList notasMatematica = new ArrayList();
        ArrayList notasFisica = new ArrayList();
        ArrayList notasQuimica = new ArrayList();
        ArrayList notasLengua = new ArrayList();
        ArrayList notasGeografia = new ArrayList();

        public FormHome()
        {
            InitializeComponent();
        }

        private void btnReverseString_Click(object sender, EventArgs e)
        {
            if (txtEntrada.Text == "")
            {
                MessageBox.Show("Ingrese texto");
            }
            else
            {
                string entrada = txtEntrada.Text;
                char[] charArray = entrada.ToCharArray();
                Array.Reverse(charArray);
                string salida = new string(charArray);
                txtSalida.Text = salida;
            }
        }

        private int calcularPromedioNotas(string tipo)
        {
            int promedio = 0;

            try
            {
                ArrayList notas = new ArrayList();

                if (tipo == "matematica")
                {
                    notas.AddRange(notasMatematica);
                }
                if (tipo == "fisica")
                {
                    notas.AddRange(notasFisica);
                }
                if (tipo == "quimica")
                {
                    notas.AddRange(notasQuimica);
                }
                if (tipo == "lengua")
                {
                    notas.AddRange(notasLengua);
                }
                if (tipo == "geografia")
                {
                    notas.AddRange(notasGeografia);
                }

                int total = 0;

                foreach (int nota in notas)
                {
                    total = total + nota;
                }

                promedio = total / notas.Count;
            }
            catch
            {
                //
            }

            return promedio;
        }

        private void btnAgregarNotaMatematica_Click(object sender, EventArgs e)
        {
            if (txtNotaMatematica.Text == "")
            {
                MessageBox.Show("Ingrese nota de Matematica");
            }
            else
            {
                notasMatematica.Add(Convert.ToInt32(txtNotaMatematica.Text));
                mmOutput.AppendText("Nota : " + txtNotaMatematica.Text + " agregada en Matematica\n");
            }
        }

        private void btnAgregarNotaFisica_Click(object sender, EventArgs e)
        {
            if (txtNotaFisica.Text == "")
            {
                MessageBox.Show("Ingrese nota de Fisica");
            }
            else
            {
                notasFisica.Add(Convert.ToInt32(txtNotaFisica.Text));
                mmOutput.AppendText("Nota : " + txtNotaFisica.Text + " agregada en Fisica\n");
            }
        }

        private void btnAgregarNotaQuimica_Click(object sender, EventArgs e)
        {
            if (txtNotaQuimica.Text == "")
            {
                MessageBox.Show("Ingrese nota de Quimica");
            }
            else
            {
                notasQuimica.Add(Convert.ToInt32(txtNotaQuimica.Text));
                mmOutput.AppendText("Nota : " + txtNotaQuimica.Text + " agregada en Quimica\n");
            }
        }

        private void btnAgregarNotaLengua_Click(object sender, EventArgs e)
        {
            if (txtNotaLengua.Text == "")
            {
                MessageBox.Show("Ingrese nota de Lengua");
            }
            else
            {
                notasLengua.Add(Convert.ToInt32(txtNotaLengua.Text));
                mmOutput.AppendText("Nota : " + txtNotaLengua.Text + " agregada en Lengua\n");
            }
        }

        private void btnAgregarNotaGeografia_Click(object sender, EventArgs e)
        {
            if (txtNotaGeografia.Text == "")
            {
                MessageBox.Show("Ingrese nota de Geografia");
            }
            else
            {
                notasGeografia.Add(Convert.ToInt32(txtNotaGeografia.Text));
                mmOutput.AppendText("Nota : " + txtNotaGeografia.Text + " agregada en Geografia\n");
            }
        }

        private void btnLimpiarMatematica_Click(object sender, EventArgs e)
        {
            mmOutput.AppendText("Notas de Matematica borradas\n");
            notasMatematica.Clear();
        }

        private void btnLimpiarFisica_Click(object sender, EventArgs e)
        {
            mmOutput.AppendText("Notas de Fisica borradas\n");
            notasFisica.Clear();
        }

        private void btnLimpiarQuimica_Click(object sender, EventArgs e)
        {
            mmOutput.AppendText("Notas de Quimica borradas\n");
            notasQuimica.Clear();
        }

        private void btnLimpiarLengua_Click(object sender, EventArgs e)
        {
            mmOutput.AppendText("Notas de Lengua borradas\n");
            notasLengua.Clear();
        }

        private void btnLimpiarGeografia_Click(object sender, EventArgs e)
        {
            mmOutput.AppendText("Notas de Geografia borradas\n");
            notasGeografia.Clear();
        }

        private void btnPromedioMatematica_Click(object sender, EventArgs e)
        {
            mmOutput.AppendText("Promedio de Matematica : "+calcularPromedioNotas("matematica").ToString()+"\n");
        }

        private void btnPromedioFisica_Click(object sender, EventArgs e)
        {
            mmOutput.AppendText("Promedio de Fisica : " + calcularPromedioNotas("fisica").ToString()+"\n");
        }

        private void btnPromedioQuimica_Click(object sender, EventArgs e)
        {
            mmOutput.AppendText("Promedio de Quimica : " + calcularPromedioNotas("quimica").ToString()+"\n");
        }

        private void btnPromedioLengua_Click(object sender, EventArgs e)
        {
            mmOutput.AppendText("Promedio de Lengua : " + calcularPromedioNotas("lengua").ToString()+"\n");
        }

        private void btnPromedioGeografia_Click(object sender, EventArgs e)
        {
            mmOutput.AppendText("Promedio de Geografia : " + calcularPromedioNotas("geografia").ToString()+"\n");
        }
    }
}
