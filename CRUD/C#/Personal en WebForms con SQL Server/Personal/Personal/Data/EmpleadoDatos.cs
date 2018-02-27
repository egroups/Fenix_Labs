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
    public class EmpleadoDatos
    {

        string connection_string = ConfigurationManager.ConnectionStrings["personal"].ToString();

        public List<Empleado> List(string patron)
        {
            var empleados = new List<Empleado>();

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM empleados WHERE nombre LIKE @patron", connection);
                query.Parameters.AddWithValue("@patron", "%" + patron + "%");

                var dr = query.ExecuteReader();

                while (dr.Read())
                {
                    var empleado = new Empleado
                    {
                        id = Convert.ToInt32(dr["id"]),
                        nombre = dr["nombre"].ToString(),
                        telefono = Convert.ToInt32(dr["telefono"]),
                        direccion = dr["direccion"].ToString(),
                        sexo = dr["sexo"].ToString(),
                        id_profesion = Convert.ToInt32(dr["id_profesion"])
                    };

                    empleados.Add(empleado);
                }

                dr.Close();

                foreach (var e in empleados)
                {
                    query = new SqlCommand("SELECT * FROM profesiones WHERE id = @id", connection);
                    query.Parameters.AddWithValue("@id", e.id_profesion);

                    dr = query.ExecuteReader();

                    dr.Read();

                    if (dr.HasRows)
                    {
                        e.profesion.id = Convert.ToInt32(dr["id"]);
                        e.profesion.nombre = dr["nombre"].ToString();
                    }

                    dr.Close();
                }

                connection.Close();
                connection.Dispose();

            }

            catch
            {
                throw;
            }

            return empleados;
        }

        public Empleado Get(int id)
        {
            Empleado empleado = new Empleado();

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM empleados WHERE id = @id", connection);
                query.Parameters.AddWithValue("@id", id);

                var dr = query.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {
                    empleado.id = Convert.ToInt32(dr["id"]);
                    empleado.nombre = dr["nombre"].ToString();
                    empleado.telefono = Convert.ToInt32(dr["telefono"]);
                    empleado.direccion = dr["direccion"].ToString();
                    empleado.sexo = dr["sexo"].ToString();
                    empleado.id_profesion = Convert.ToInt32(dr["id_profesion"]);
                }
                else
                {
                    return null;
                }

                dr.Close();

                query = new SqlCommand("SELECT * FROM profesiones WHERE id = @id", connection);
                query.Parameters.AddWithValue("@id", empleado.id_profesion);

                dr = query.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {
                    empleado.profesion.id = Convert.ToInt32(dr["id"]);
                    empleado.profesion.nombre = dr["nombre"].ToString();
                }
                else
                {
                    return null;
                }

                dr.Close();

                connection.Close();
                connection.Dispose();

            }
            catch
            {
                throw;
            }

            return empleado;
        }

        public bool Add(Empleado empleado)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("INSERT INTO empleados(nombre,direccion,telefono,sexo,id_profesion) VALUES (@p0, @p1, @p2, @p3, @p4)", connection);

                query.Parameters.AddWithValue("@p0", empleado.nombre);
                query.Parameters.AddWithValue("@p1", empleado.direccion);
                query.Parameters.AddWithValue("@p2", empleado.telefono);
                query.Parameters.AddWithValue("@p3", empleado.sexo);
                query.Parameters.AddWithValue("@p4", empleado.id_profesion);

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

        public bool Update(Empleado empleado)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("UPDATE empleados SET nombre = @p0, direccion = @p1, telefono = @p2, sexo = @p3, id_profesion = @p4 WHERE id = @p5", connection);

                query.Parameters.AddWithValue("@p0", empleado.nombre);
                query.Parameters.AddWithValue("@p1", empleado.direccion);
                query.Parameters.AddWithValue("@p2", empleado.telefono);
                query.Parameters.AddWithValue("@p3", empleado.sexo);
                query.Parameters.AddWithValue("@p4", empleado.id_profesion);
                query.Parameters.AddWithValue("@p5", empleado.id);

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

        public bool Delete(Empleado empleado)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("DELETE FROM empleados WHERE id = @p0", connection);
                query.Parameters.AddWithValue("@p0", empleado.id);
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