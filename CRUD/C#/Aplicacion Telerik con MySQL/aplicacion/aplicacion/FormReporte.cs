// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace aplicacion
{
    public partial class FormReporte : Telerik.WinControls.UI.RadForm
    {
        public FormReporte()
        {
            InitializeComponent();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.SetDatabaseLogon("root", "", "ConexionMysql", "sistema");
            reporte.Refresh();
            crystalReportViewer1.Refresh();
            crystalReportViewer1.ReportSource = reporte;
        }
    }
}
