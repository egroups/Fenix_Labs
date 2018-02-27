// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace aplicacion
{
    class Conexion
    {
        public SQLiteConnection conexion;
        public SQLiteCommand comando;
        public SQLiteDataReader dr;
        public DataTable dt;

        public Conexion()
        {
            conexion = new SQLiteConnection();
            comando = new SQLiteCommand();
            dt = new DataTable();
            dr = null;
        }

        public void abrir()
        {
            conexion.ConnectionString = "Data Source=sistema.s3db;Version=3";
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            conexion.Open();
            comando.Connection = conexion;
            //comando.CommandType = CommandType.Text;
        }
        public void cerrar()
        {
            conexion.Close();
            //conexion.Dispose();
        }
    }
}
