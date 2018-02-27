// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Aplicacion.Models;

namespace Aplicacion.Data
{
    class UsuarioDatos
    {
        string connection_string = ConfigurationManager.ConnectionStrings["sistema"].ToString();

        public List<Usuario> List(string patron)
        {
            var usuarios = new List<Usuario>();

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM usuarios WHERE nombre LIKE @patron", connection);
                query.Parameters.AddWithValue("@patron", "%" + patron + "%");

                var dr = query.ExecuteReader();

                while (dr.Read())
                {
                    usuarios.Add(
                        new Usuario
                        {
                            id = Convert.ToInt32(dr["id"]),
                            nombre = dr["nombre"].ToString(),
                            clave = dr["clave"].ToString(),
                            id_tipo = Convert.ToInt32(dr["id_tipo"]),
                            fecha_registro = dr["fecha_registro"].ToString()
                        }
                    );
                }

                dr.Close();

                foreach (var u in usuarios)
                {
                    query = new SqlCommand("SELECT * FROM tipos_usuarios WHERE id = @id", connection);
                    query.Parameters.AddWithValue("@id", u.id_tipo);

                    dr = query.ExecuteReader();

                    dr.Read();

                    if (dr.HasRows)
                    {
                        u.tipo.id = Convert.ToInt32(dr["id"]);
                        u.tipo.nombre = dr["nombre"].ToString();
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

            return usuarios;
        }

        public Usuario Get(int id)
        {
            Usuario usuario = new Usuario();

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM usuarios WHERE id = @id", connection);
                query.Parameters.AddWithValue("@id", id);

                var dr = query.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {
                    usuario = new Usuario();
                    usuario.id = Convert.ToInt32(dr["id"]);
                    usuario.nombre = dr["nombre"].ToString();
                    usuario.clave = dr["clave"].ToString();
                    usuario.id_tipo = Convert.ToInt32(dr["id_tipo"].ToString());
                    usuario.fecha_registro = dr["fecha_registro"].ToString();
                }
                else
                {
                    return null;
                }

                dr.Close();

                query = new SqlCommand("SELECT * FROM tipos_usuarios WHERE id = @id", connection);
                query.Parameters.AddWithValue("@id", usuario.id_tipo);

                dr = query.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {
                    usuario.tipo.id = Convert.ToInt32(dr["id"]);
                    usuario.tipo.nombre = dr["nombre"].ToString();
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

            return usuario;
        }

        public bool Add(Usuario usuario)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("INSERT INTO usuarios(nombre,clave,id_tipo,fecha_registro) VALUES (@p0, @p1, @p2, @p3)", connection);

                query.Parameters.AddWithValue("@p0", usuario.nombre);
                query.Parameters.AddWithValue("@p1", usuario.clave);
                query.Parameters.AddWithValue("@p2", usuario.id_tipo);
                query.Parameters.AddWithValue("@p3", usuario.fecha_registro);

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

        public bool Update(Usuario usuario)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("UPDATE usuarios SET id_tipo = @p0 WHERE id = @p1", connection);

                query.Parameters.AddWithValue("@p0", usuario.id_tipo);
                query.Parameters.AddWithValue("@p1", usuario.id);

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

        public bool Delete(Usuario usuario)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("DELETE FROM usuarios WHERE id = @p0", connection);
                query.Parameters.AddWithValue("@p0", usuario.id);
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

        public bool check_exists_usuario_add(string nombre)
        {
            bool respuesta = false;
            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM usuarios WHERE nombre = @nombre", connection);
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

        public bool check_exists_usuario_edit(int id, string nombre)
        {
            bool respuesta = false;
            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM usuarios WHERE nombre = @nombre and id != @id", connection);
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

        public bool check_login(string usuario, string clave)
        {
            bool respuesta = false;
            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT * FROM usuarios WHERE nombre = @nombre and clave = @clave", connection);
                query.Parameters.AddWithValue("@nombre", usuario);
                query.Parameters.AddWithValue("@clave", clave);

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

        public string get_user_type(string nombre)
        {
            string user_type = "";
            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT t.nombre FROM usuarios u,tipos_usuarios t WHERE u.nombre = @nombre AND u.id_tipo = t.id", connection);
                query.Parameters.AddWithValue("@nombre", nombre);

                var dr = query.ExecuteReader();

                if (dr.Read())
                {
                    user_type = dr["nombre"].ToString();
                }

                connection.Close();
                connection.Dispose();

            }
            catch
            {
                throw;
            }
            return user_type;
        }

        public int get_id_by_user(string usuario)
        {
            int id = 0;
            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("SELECT id FROM usuarios WHERE nombre = @nombre", connection);
                query.Parameters.AddWithValue("@nombre", usuario);

                var dr = query.ExecuteReader();

                if (dr.Read())
                {
                    id = Convert.ToInt32(dr["id"]);
                }

                connection.Close();
                connection.Dispose();

            }
            catch
            {
                throw;
            }
            return id;
        }

        public bool change_username(int id, string nuevo_usuario)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("UPDATE usuarios SET nombre = @p0 WHERE id = @p1", connection);

                query.Parameters.AddWithValue("@p0", nuevo_usuario);
                query.Parameters.AddWithValue("@p1", id);

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

        public bool change_password(int id, string nueva_clave)
        {
            bool respuesta = false;

            try
            {
                var connection = new SqlConnection(connection_string);
                connection.Open();

                var query = new SqlCommand("UPDATE usuarios SET clave = @p0 WHERE id = @p1", connection);

                query.Parameters.AddWithValue("@p0", nueva_clave);
                query.Parameters.AddWithValue("@p1", id);

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
