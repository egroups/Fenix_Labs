// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace aplicacion
{
    class Conexion
    {
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader dr;
        public DataTable dt;

        public Conexion()
        {
            conexion = new SqlConnection();
            comando = new SqlCommand();
            dt = new DataTable();
            dr = null;
        }

        public void abrir()
        {
            conexion.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456";
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }
        public void cerrar()
        {
            conexion.Close();
            conexion.Dispose();
        }
    }
}
