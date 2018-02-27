// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Reports;

namespace aplicacion
{
    public partial class FormReporte : Form
    {
        public FormReporte()
        {
            InitializeComponent();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.SetDatabaseLogon("admin", "123456", "SINDECIDIR-PC", "sistemaV2");
            reporte.Refresh();
            crvReporte.Refresh();
            crvReporte.ReportSource = reporte;
        }
    }
}
