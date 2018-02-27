// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace aplicacion
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            reporte reporte = new reporte();
            reporte.SetDatabaseLogon("admin", "123456", "localhost\\SQLEXPRESS", "sistema");
            reporte.Refresh();
            crystalReportViewer1.Refresh();
            crystalReportViewer1.ReportSource = reporte;
        }
    }
}
