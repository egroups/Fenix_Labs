// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Listas
{
    public partial class FormHome : Form
    {

        ArrayList array1 = new ArrayList();
        List<int> list1 = new List<int>();

        public FormHome()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtTexto.Text != "")
            {
                array1.Add(txtTexto.Text);
                lbLineas.Items.Add(txtTexto.Text);
                txtTexto.Text = "";
                MessageBox.Show("Agregado");
            }
            else
            {
                MessageBox.Show("Ingrese texto");
            }
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            if (txtTexto2.Text != "")
            {
                list1.Add(Convert.ToInt32(txtTexto2.Text));
                lbLineas2.Items.Add(txtTexto2.Text);
                txtTexto2.Text = "";
                MessageBox.Show("Agregado");
            }
            else
            {
                MessageBox.Show("Ingrese numero");
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            foreach (string text in array1)
            {
                MessageBox.Show("Texto : " + text);
            }
            MessageBox.Show("Listado terminado");
        }

        private void btnListar2_Click(object sender, EventArgs e)
        {
            foreach (int text in list1)
            {
                MessageBox.Show("Numero : " + Convert.ToString(text));
            }
            MessageBox.Show("Listado terminado");
        }

    }
}
