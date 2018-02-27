// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Sistema.Models;

namespace Sistema
{
    public class TipoUsuarioDatos
    {

        string connection_string = ConfigurationManager.ConnectionStrings["sistema"].ToString();

        public List<TipoUsuario> List(string patron)
        {
            var tipos = new List<TipoUsuario>();

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM tipos_usuarios WHERE nombre LIKE @patron", connection);
                query.Parameters.AddWithValue("@patron", "%" + patron + "%");

                var dr = query.ExecuteReader();

                while (dr.Read())
                {
                    tipos.Add(
                        new TipoUsuario
                        {
                            id = Convert.ToInt32(dr["id"]),
                            nombre = dr["nombre"].ToString(),
                        }
                    );
                }

                connection.Close();
                connection.Dispose();

            }
            catch
            {
                throw;
            }

            return tipos;
        }
    }
}
