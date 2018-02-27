// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Personal.Models;

namespace Personal.Functions
{
    public class ProfesionDatos
    {

        string connection_string = ConfigurationManager.ConnectionStrings["personal"].ToString();

        public List<Profesion> List(string patron)
        {
            var profesiones = new List<Profesion>();

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM profesiones WHERE nombre LIKE @patron", connection);
                query.Parameters.AddWithValue("@patron", "%" + patron + "%");

                var dr = query.ExecuteReader();

                while (dr.Read())
                {
                    profesiones.Add(
                        new Profesion
                        {
                            id = Convert.ToInt32(dr["id"]),
                            nombre = dr["nombre"].ToString(),
                        }
                    );
                }

                dr.Close();

                connection.Close();
                connection.Dispose();

            }
            catch
            {
                throw;
            }

            return profesiones;
        }

        public Profesion Get(int id)
        {
            Profesion profesion = null;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM profesiones WHERE id = @id", connection);
                query.Parameters.AddWithValue("@id", id);

                var dr = query.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {
                    profesion = new Profesion();
                    profesion.id = Convert.ToInt32(dr["id"]);
                    profesion.nombre = dr["nombre"].ToString();
                }

                dr.Close();

                connection.Close();
                connection.Dispose();

            }
            catch
            {
                throw;
            }

            return profesion;
        }

        public bool Add(Profesion profesion)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("INSERT INTO profesiones(nombre) VALUES (@p0)", connection);

                query.Parameters.AddWithValue("@p0", profesion.nombre);

                query.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();

                respuesta = true;
            }
            catch
            {
                throw;
            }

            return respuesta;
        }

        public bool Update(Profesion profesion)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("UPDATE profesiones SET nombre = @p0 WHERE id = @p1", connection);

                query.Parameters.AddWithValue("@p0", profesion.nombre);
                query.Parameters.AddWithValue("@p1", profesion.id);

                query.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();

                respuesta = true;
            }
            catch
            {
                throw;
            }

            return respuesta;
        }

        public bool Delete(Profesion profesion)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("DELETE FROM profesiones WHERE id = @p0", connection);
                query.Parameters.AddWithValue("@p0", profesion.id);
                query.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();

                respuesta = true;
            }
            catch
            {
                throw;
            }

            return respuesta;
        }
    }
}