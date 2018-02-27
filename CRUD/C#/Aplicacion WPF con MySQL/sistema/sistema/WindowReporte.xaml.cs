// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace sistema
{
    /// <summary>
    /// Interaction logic for WindowReporte.xaml
    /// </summary>
    public partial class WindowReporte : Window
    {
        public WindowReporte()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.SetDatabaseLogon("root", "", "ConexionMysql", "sistema");
            reporte.Refresh();
            crystalReportViewer1.ViewerCore.ReportSource = reporte;
            crystalReportViewer1.ViewerCore.Visibility = Visibility.Visible;
        }
    }
}
