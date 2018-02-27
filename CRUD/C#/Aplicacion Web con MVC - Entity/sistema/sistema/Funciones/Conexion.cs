// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sistema.Models;

namespace sistema.Conexiones
{
    public class Conexion
    {

        Funciones.Funciones funcion = new Funciones.Funciones();

        // Conexiones

        public bool ingreso_usuario(string userName, string password)
        {
            SistemaEntidades context = new SistemaEntidades();
            var query = from p in context.usuarios
                        where p.usuario == userName
                        && p.clave == password
                        select p;

            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool es_admin(string username)
        {
            SistemaEntidades context = new SistemaEntidades();
            var query = (from p in context.usuarios
                         where p.usuario == username
                         select p).ToList();
            string tipo = query[0].tipo.ToString();
            if (tipo == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int get_id_by_username(string username)
        {
            SistemaEntidades context = new SistemaEntidades();
            var query = (from p in context.usuarios
                         where p.usuario == username
                         select p).ToList();
            int id_usuario = query[0].id_usuario;
            return id_usuario;
        }

        // Validaciones de cookies

        public bool valid_cookie(string cookie_content)
        {

            string[] datos = cookie_content.Split('-');
            string username_cookie = datos[0];
            string password_cookie = datos[1];
            if (username_cookie != "" && password_cookie != "")
            {
                if (ingreso_usuario(username_cookie, password_cookie))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public bool valid_cookie_admin(string cookie_content)
        {

            string[] datos = cookie_content.Split('-');
            string username_cookie = datos[0];
            string password_cookie = datos[1];
            if (username_cookie != "" && password_cookie != "")
            {
                if (ingreso_usuario(username_cookie, password_cookie))
                {
                    if (es_admin(username_cookie))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public string get_username_in_cookie(string cookie_content)
        {
            string[] datos = cookie_content.Split('-');
            string username_cookie = datos[0];
            string password_cookie = datos[1];
            return username_cookie;
        }


        // Cambiar usuario

        public bool cambiar_usuario(string nombre_usuario, string new_username)
        {
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                usuarios usuario_load = context.usuarios.Single(usuario => usuario.usuario == nombre_usuario);
                usuario_load.usuario = new_username;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Cambiar password

        public bool cambiar_password(string nombre_usuario, string new_password)
        {
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                usuarios usuario_load = context.usuarios.Single(usuario => usuario.usuario == nombre_usuario);
                usuario_load.clave = new_password;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Proveedores

        public List<proveedores> listarProveedores(string patron)
        {
            List<proveedores> lista = new List<proveedores>();
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                lista = (from p in context.proveedores
                         select p).Where(p => p.nombre_empresa.Contains(patron)).ToList();
            }
            catch
            {
                //
            }
            return lista;
        }

        public bool comprobar_existencia_proveedor_crear(String nombre_empresa)
        {
            Boolean respuesta = false;
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                var query = (from p in context.proveedores
                         select p).Where(p => p.nombre_empresa==nombre_empresa).ToList();
                if (query.Count() >= 1)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch
            {
                //
            }
            return respuesta;
        }

        public bool comprobar_existencia_proveedor_editar(int id_proveedor, String nombre_empresa)
        {
            Boolean respuesta = false;
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                var query = (from p in context.proveedores
                             select p).Where(p => p.nombre_empresa == nombre_empresa && p.id_proveedor!=id_proveedor).ToList();
                if (query.Count() >= 1)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch
            {
                //
            }
            return respuesta;
        }

        public bool comprobar_existencia_producto_crear(String nombre_producto)
        {
            Boolean respuesta = false;
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                var query = (from p in context.productos
                             select p).Where(p => p.nombre_producto == nombre_producto).ToList();
                if (query.Count() >= 1)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch
            {
                //
            }
            return respuesta;
        }

        public bool comprobar_existencia_producto_editar(int id_producto, String nombre_producto)
        {
            Boolean respuesta = false;
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                var query = (from p in context.productos
                             select p).Where(p => p.nombre_producto == nombre_producto && p.id_producto != id_producto).ToList();
                if (query.Count() >= 1)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch
            {
                //
            }
            return respuesta;
        }

        public bool comprobar_existencia_usuario_crear(String nombre_usuario)
        {
            Boolean respuesta = false;
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                var query = (from p in context.usuarios
                             select p).Where(p => p.usuario == nombre_usuario).ToList();
                if (query.Count() >= 1)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch
            {
                //
            }
            return respuesta;
        }

        public bool comprobar_existencia_usuario_editar(String nombre_usuario)
        {
            Boolean respuesta = false;
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                var query = (from p in context.usuarios
                             select p).Where(p => p.usuario == nombre_usuario).ToList();
                if (query.Count() >= 1)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }
            catch
            {
                //
            }
            return respuesta;
        }

        public proveedores cargarProveedor(int id_proveedor)
        {
            proveedores proveedor_load = new proveedores();
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                proveedor_load = (from p in context.proveedores
                         select p).Where(p => p.id_proveedor == id_proveedor).Single();
            }
            catch
            {
                //
            }
            return proveedor_load;
        }

        public bool agregarProveedor(string nombre_empresa, string direccion, int telefono)
        {
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                proveedores proveedor = new proveedores();
                proveedor.nombre_empresa = nombre_empresa;
                proveedor.direccion = direccion;
                proveedor.telefono = telefono;
                proveedor.fecha_registro_proveedor = funcion.fecha_del_dia();
                context.proveedores.Add(proveedor);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editarProveedor(int id_proveedor, string nombre_empresa, string direccion, int telefono)
        {
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                proveedores proveedor_load = context.proveedores.Single(proveedor => proveedor.id_proveedor == id_proveedor);
                proveedor_load.nombre_empresa = nombre_empresa;
                proveedor_load.direccion = direccion;
                proveedor_load.telefono = telefono;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool borrarProveedor(int id_proveedor)
        {
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                proveedores proveedor_load = context.proveedores.Single(proveedor => proveedor.id_proveedor == id_proveedor);
                context.proveedores.Remove(proveedor_load);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string cargarNombreProveedor(int id_proveedor)
        {
            string nombre_empresa = "";

            try
            {
                SistemaEntidades context = new SistemaEntidades();
                var query = (from p in context.proveedores
                             where p.id_proveedor == id_proveedor
                             select p).Single();

                nombre_empresa = query.nombre_empresa.ToString();
            }
            catch
            {
                nombre_empresa = "";
            }

            return nombre_empresa;

        }

        // Productos

        public List<productos> listarProductos(string patron)
        {
            List<productos> lista = new List<productos>();
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                lista = (from p in context.productos
                         select p).Where(p => p.nombre_producto.Contains(patron)).ToList();
            }
            catch
            {
                //
            }
            return lista;
        }

        public productos cargarProducto(int id_producto)
        {
            productos producto_load = new productos();
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                producto_load = (from p in context.productos
                                  select p).Where(p => p.id_producto == id_producto).Single(); 
            }
            catch
            {
                //
            }
            return producto_load;
        }

        public bool agregarProducto(string nombre_producto, string descripcion, int precio, int id_proveedor)
        {
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                productos producto = new productos();
                producto.nombre_producto = nombre_producto;
                producto.descripcion = descripcion;
                producto.precio = precio;
                producto.id_proveedor = id_proveedor;
                producto.fecha_registro = funcion.fecha_del_dia();
                context.productos.Add(producto);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editarProducto(int id_producto, string nombre_producto, string descripcion, int precio, int id_proveedor)
        {
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                productos producto_load = context.productos.Single(producto => producto.id_producto == id_producto);
                producto_load.nombre_producto = nombre_producto;
                producto_load.descripcion = descripcion;
                producto_load.precio = precio;
                producto_load.id_proveedor = id_proveedor;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool borrarProducto(int id_producto)
        {
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                productos producto_load = context.productos.Single(producto => producto.id_producto == id_producto);
                context.productos.Remove(producto_load);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Usuarios

        public List<usuarios> listarUsuarios(string patron)
        {
            List<usuarios> lista = new List<usuarios>();
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                lista = (from p in context.usuarios
                         select p).Where(p => p.usuario.Contains(patron)).ToList();
            }
            catch
            {
                //
            }
            return lista;
        }

        public usuarios cargarUsuario(int id_usuario)
        {
            usuarios usuario_load = new usuarios();
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                usuario_load = (from p in context.usuarios
                                 select p).Where(p => p.id_usuario == id_usuario).Single();
            }
            catch
            {
                //
            }
            return usuario_load;
        }


        public bool agregarUsuario(string nombre_usuario, string clave, int tipo)
        {
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                usuarios new_usuario = new usuarios();
                new_usuario.usuario = nombre_usuario;
                new_usuario.clave = clave;
                new_usuario.tipo = tipo;
                new_usuario.fecha_registro = funcion.fecha_del_dia();
                context.usuarios.Add(new_usuario);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool asignar_usuario(int id_usuario, int new_tipo)
        {
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                usuarios usuario_load = context.usuarios.Single(usuario => usuario.id_usuario == id_usuario);
                usuario_load.tipo = new_tipo;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool borrarUsuario(int id_usuario)
        {
            try
            {
                SistemaEntidades context = new SistemaEntidades();
                usuarios usuario_load = context.usuarios.Single(usuario => usuario.id_usuario == id_usuario);
                context.usuarios.Remove(usuario_load);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}