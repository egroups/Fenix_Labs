// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Aplicacion.Models;

namespace Aplicacion.Data
{
    class ProveedorDatos
    {
        string connection_string = ConfigurationManager.ConnectionStrings["sistema"].ToString();

        public List<Proveedor> List(string patron)
        {
            var proveedores = new List<Proveedor>();

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM proveedores WHERE nombre LIKE @patron", connection);
                query.Parameters.AddWithValue("@patron", "%" + patron + "%");

                var dr = query.ExecuteReader();

                while (dr.Read())
                {
                    proveedores.Add(
                        new Proveedor
                        {
                            id = Convert.ToInt32(dr["id"]),
                            nombre = dr["nombre"].ToString(),
                            direccion = dr["direccion"].ToString(),
                            telefono = Convert.ToInt32(dr["telefono"]),
                            fecha_registro = dr["fecha_registro"].ToString()
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

            return proveedores;
        }

        public Proveedor Get(int id)
        {
            Proveedor proveedor = null;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM proveedores WHERE id = @id", connection);
                query.Parameters.AddWithValue("@id", id);

                var dr = query.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {
                    proveedor = new Proveedor();
                    proveedor.id = Convert.ToInt32(dr["id"]);
                    proveedor.nombre = dr["nombre"].ToString();
                    proveedor.direccion = dr["direccion"].ToString();
                    proveedor.telefono = Convert.ToInt32(dr["telefono"]);
                    proveedor.fecha_registro = dr["fecha_registro"].ToString();
                }

                dr.Close();

                connection.Close();
                connection.Dispose();

            }
            catch
            {
                throw;
            }

            return proveedor;
        }

        public bool Add(Proveedor proveedor)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("INSERT INTO proveedores(nombre,direccion,telefono,fecha_registro) VALUES (@p0, @p1, @p2, @p3)", connection);

                query.Parameters.AddWithValue("@p0", proveedor.nombre);
                query.Parameters.AddWithValue("@p1", proveedor.direccion);
                query.Parameters.AddWithValue("@p2", proveedor.telefono);
                query.Parameters.AddWithValue("@p3", proveedor.fecha_registro);

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

        public bool Update(Proveedor proveedor)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("UPDATE proveedores SET nombre = @p0, direccion = @p1, telefono = @p2 WHERE id = @p3", connection);

                query.Parameters.AddWithValue("@p0", proveedor.nombre);
                query.Parameters.AddWithValue("@p1", proveedor.direccion);
                query.Parameters.AddWithValue("@p2", proveedor.telefono);
                query.Parameters.AddWithValue("@p3", proveedor.id);

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

        public bool Delete(Proveedor proveedor)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("DELETE FROM proveedores WHERE id = @p0", connection);
                query.Parameters.AddWithValue("@p0", proveedor.id);
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

        public bool check_exists_proveedor_add(string nombre)
        {
            bool respuesta = false;
            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM proveedores WHERE nombre = @nombre", connection);
                query.Parameters.AddWithValue("@nombre", nombre);

                var dr = query.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(dr);
                int length = dt.Rows.Count;

                if (length >= 1)
                {
                    respuesta = true;
                }

                connection.Close();
                connection.Dispose();

            }
            catch
            {
                throw;
            }
            return respuesta;
        }

        public bool check_exists_proveedor_edit(int id, string nombre)
        {
            bool respuesta = false;
            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM proveedores WHERE nombre = @nombre and id != @id", connection);
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@nombre", nombre);

                var dr = query.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(dr);
                int length = dt.Rows.Count;

                if (length >= 1)
                {
                    respuesta = true;
                }

                connection.Close();
                connection.Dispose();

            }
            catch
            {
                throw;
            }
            return respuesta;
        }
    }
}
