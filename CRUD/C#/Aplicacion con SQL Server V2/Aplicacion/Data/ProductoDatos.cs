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
    class ProductoDatos
    {
        string connection_string = ConfigurationManager.ConnectionStrings["sistema"].ToString();

        public List<Producto> List(string patron)
        {
            var productos = new List<Producto>();

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM productos WHERE nombre LIKE @patron", connection);
                query.Parameters.AddWithValue("@patron", "%" + patron + "%");

                var dr = query.ExecuteReader();

                while (dr.Read())
                {
                    var producto = new Producto
                    {
                        id = Convert.ToInt32(dr["id"]),
                        nombre = dr["nombre"].ToString(),
                        descripcion = dr["descripcion"].ToString(),
                        precio = Convert.ToDouble(dr["precio"].ToString()),
                        id_proveedor = Convert.ToInt32(dr["id_proveedor"]),
                        fecha_registro = dr["fecha_registro"].ToString()
                    };

                    productos.Add(producto);
                }

                dr.Close();

                foreach (var p in productos)
                {
                    query = new SqlCommand("SELECT * FROM proveedores WHERE id = @id", connection);
                    query.Parameters.AddWithValue("@id", p.id_proveedor);

                    dr = query.ExecuteReader();

                    dr.Read();

                    if (dr.HasRows)
                    {
                        p.proveedor.id = Convert.ToInt32(dr["id"]);
                        p.proveedor.nombre = dr["nombre"].ToString();
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

            return productos;
        }

        public Producto Get(int id)
        {
            Producto producto = new Producto();

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM productos WHERE id = @id", connection);
                query.Parameters.AddWithValue("@id", id);

                var dr = query.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {
                    producto.id = Convert.ToInt32(dr["id"]);
                    producto.nombre = dr["nombre"].ToString();
                    producto.descripcion = dr["descripcion"].ToString();
                    producto.precio = Convert.ToDouble(dr["precio"].ToString());
                    producto.id_proveedor = Convert.ToInt32(dr["id_proveedor"]);
                }
                else
                {
                    return null;
                }

                dr.Close();

                query = new SqlCommand("SELECT * FROM proveedores WHERE id = @id", connection);
                query.Parameters.AddWithValue("@id", producto.id_proveedor);

                dr = query.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {
                    producto.proveedor.id = Convert.ToInt32(dr["id"]);
                    producto.proveedor.nombre = dr["nombre"].ToString();
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

            return producto;
        }

        public bool Add(Producto producto)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("INSERT INTO productos(nombre,descripcion,precio,id_proveedor,fecha_registro) VALUES (@p0, @p1, @p2, @p3, @p4)", connection);

                query.Parameters.AddWithValue("@p0", producto.nombre);
                query.Parameters.AddWithValue("@p1", producto.descripcion);
                query.Parameters.AddWithValue("@p2", producto.precio);
                query.Parameters.AddWithValue("@p3", producto.id_proveedor);
                query.Parameters.AddWithValue("@p4", producto.fecha_registro);

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

        public bool Update(Producto producto)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("UPDATE productos SET nombre = @p0, descripcion = @p1, precio = @p2, id_proveedor = @p3 WHERE id = @p4", connection);

                query.Parameters.AddWithValue("@p0", producto.nombre);
                query.Parameters.AddWithValue("@p1", producto.descripcion);
                query.Parameters.AddWithValue("@p2", producto.precio);
                query.Parameters.AddWithValue("@p3", producto.id_proveedor);
                query.Parameters.AddWithValue("@p4", producto.id);

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

        public bool Delete(Producto producto)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("DELETE FROM productos WHERE id = @p0", connection);
                query.Parameters.AddWithValue("@p0", producto.id);
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

        public bool check_exists_producto_add(string nombre)
        {
            bool respuesta = false;
            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM productos WHERE nombre = @nombre", connection);
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

        public bool check_exists_producto_edit(int id, string nombre)
        {
            bool respuesta = false;
            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM productos WHERE nombre = @nombre and id != @id", connection);
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
