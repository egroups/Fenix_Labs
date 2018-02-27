// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ejercicio
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            Auto auto = new Auto("Bora 2009", "EJS748");
            Cochera cochera = new Cochera(1, "2.60 x 3.35", auto);
            //Cochera cochera = new Cochera(2, "40x40",null);
            Casa casa = new Casa("40x40",3,"Felipe Olmos", 4876972, "Test 2047", cochera);
            //Casa cas = new Casa();
            //rtbSalida.AppendText(casa.DatosCasa());
            rtbSalida.AppendText(casa.DatosCasaCompleto());
            //rtbSalida.AppendText(casa.pCochera.DatosCochera());
            //rtbSalida.AppendText(casa.pCochera.DatosCocheraCompleto());
            //rtbSalida.AppendText(casa.pCochera.pAuto.DatosAuto());
            //rtbSalida.AppendText(casa.pCochera.pCamioneta.DatosCamioneta());
        }
    }
}
