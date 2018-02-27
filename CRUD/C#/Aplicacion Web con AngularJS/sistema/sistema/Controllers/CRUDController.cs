using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sistema.Models;
using System.IO;

namespace sistema.Controllers
{

    public class Producto
    {
        public int id { get; set; }
        public string nombre_producto { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int id_proveedor { get; set; }
        public string nombre_empresa { get; set; }
        public string fecha_registro { get; set; }
    }

    public class Proveedor
    {
        public int id { get; set; }
        public string nombre_empresa { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string fecha_registro_proveedor { get; set; }
    }

    public class Usuario
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public int tipo { get; set; }
        public string nombre_tipo { get; set; }
        public string fecha_registro { get; set; }

    }

    public class CRUDController : Controller
    {

        Conexiones.Conexion conexion_now = new Conexiones.Conexion();
        Funciones.Funciones funcion = new Funciones.Funciones();

        //
        // GET: /CRUD/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarProductos()
        {
            List<Producto> lista = new List<Producto>(); 
            List<productos> productos = conexion_now.listarProductos("");
            foreach (var producto in productos)
            {
                int id = producto.id_producto;
                string nombre_producto = producto.nombre_producto;
                string descripcion = producto.descripcion;
                int precio = Convert.ToInt32(producto.precio);
                int id_proveedor = Convert.ToInt32(producto.id_proveedor);
                string fecha_registro = producto.fecha_registro;
                Producto prod = new Producto();
                prod.id = id;
                prod.nombre_producto = nombre_producto;
                prod.descripcion = descripcion;
                prod.precio = precio;
                prod.id_proveedor = id_proveedor;
                prod.nombre_empresa = conexion_now.cargarNombreProveedor(id_proveedor);
                prod.fecha_registro = fecha_registro;
                lista.Add(prod);
            }
            return Json(new { success = true, data = lista });
        }

        public ActionResult ListarProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>(); 
            List<proveedores> proveedores = conexion_now.listarProveedores("");
            foreach (var proveedor in proveedores)
            {
                int id = proveedor.id_proveedor;
                string nombre_empresa = proveedor.nombre_empresa;
                string direccion = proveedor.direccion;
                int telefono = Convert.ToInt32(proveedor.telefono);
                string fecha_registro_proveedor = proveedor.fecha_registro_proveedor;
                Proveedor prov = new Proveedor();
                prov.id = id;
                prov.nombre_empresa = nombre_empresa;
                prov.direccion = direccion;
                prov.telefono = telefono;
                prov.fecha_registro_proveedor = fecha_registro_proveedor;
                lista.Add(prov);
            }
            return Json(new { success = true, data = lista });
        }

        public ActionResult ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>(); 
            List<usuarios> usuarios = conexion_now.listarUsuarios("");
            foreach (var usuario in usuarios)
            {
                int id = usuario.id_usuario;
                string nombre_usuario = usuario.usuario;
                string password = usuario.clave;
                int tipo = Convert.ToInt32(usuario.tipo);
                string fecha_registro = usuario.fecha_registro;

                string nombre_tipo = "";

                if (tipo == 1)
                {
                    nombre_tipo = "Administrador";
                }
                else
                {
                    nombre_tipo = "Usuario";
                }

                Usuario user = new Usuario();
                user.id = id;
                user.usuario = nombre_usuario;
                user.password = password;
                user.nombre_tipo = nombre_tipo;
                user.fecha_registro = fecha_registro;

                lista.Add(user);

            }
            return Json(new { success = true, data = lista });
        }

        public ActionResult AgregarProducto()
        {
            string respuesta = "";
            bool done = false;

            string nombre_producto = Request["nombre_producto"];
            string descripcion = Request["descripcion"];
            int precio = Convert.ToInt32(Request["precio"]);
            int id_proveedor = Convert.ToInt32(Request["id_proveedor"]);

            if (nombre_producto != "" && descripcion != "" && funcion.valid_number(precio.ToString()) && funcion.valid_number(id_proveedor.ToString()))
            {
                if (conexion_now.comprobar_existencia_producto_crear(nombre_producto))
                {
                    respuesta = "El producto " + nombre_producto + " ya existe";
                    done = false;
                }
                else
                {
                    if (conexion_now.agregarProducto(nombre_producto, descripcion, precio, id_proveedor))
                    {
                        respuesta = "El producto ha sido registrado exitosamente";
                        done = true;
                    }
                    else
                    {
                        respuesta = "Ha ocurrido un error en la base de datos";
                        done = false;
                    }
                }
            }
            else
            {
                respuesta = "Los datos ingresados en el formulario son invalidos";
                done = false;
            }

            return Json(new { success = done , message = respuesta });

        }

        public ActionResult EditarProducto()
        {
            string respuesta = "";
            bool done = false;

            int id_producto = Convert.ToInt32(Request["id_producto"]);
            string nombre_producto = Request["nombre_producto"];
            string descripcion = Request["descripcion"];
            int precio = Convert.ToInt32(Request["precio"]);
            int id_proveedor = Convert.ToInt32(Request["id_proveedor"]);

            if (funcion.valid_number(id_producto.ToString()) && nombre_producto != "" && descripcion != "" && funcion.valid_number(precio.ToString()) && funcion.valid_number(id_proveedor.ToString()))
            {
                if (conexion_now.comprobar_existencia_producto_editar(id_producto, nombre_producto))
                {
                    respuesta = "El producto " + nombre_producto + " ya existe";
                    done = false;
                }
                else
                {
                    if (conexion_now.editarProducto(id_producto, nombre_producto, descripcion, precio, id_proveedor))
                    {
                        respuesta = "El producto ha sido editado exitosamente";
                        done = true;
                    }
                    else
                    {
                        respuesta = "Ha ocurrido un error en la base de datos";
                        done = false;
                    }
                }
            }
            else
            {
                respuesta = "Los datos ingresados en el formulario son invalidos";
                done = false;
            }

            return Json(new { success = done, message = respuesta });

        }

        public ActionResult BorrarProducto()
        {
            bool done = false;
            string respuesta = "";

            int id = Convert.ToInt32(Request["id_producto"]);

            if (funcion.valid_number(id.ToString()))
            {
                if (conexion_now.borrarProducto(id))
                {
                    respuesta = "El producto ha sido borrado exitosamente";
                    done = true;
                }
                else
                {
                    respuesta = "Ha ocurrido un error en la base de datos";
                    done = false;
                }
            }
            else
            {
                respuesta = "ID invalido";
                done = false;
            }

            return Json(new { success = done, message = respuesta });

        }

        public ActionResult AgregarProveedor()
        {

            string respuesta = "";

            bool done = false;

            string nombre_empresa = Request["nombre_empresa"];
            string direccion = Request["direccion"];
            int telefono = Convert.ToInt32(Request["telefono"]);

            if (nombre_empresa != "" && direccion != "" && funcion.valid_number(telefono.ToString()))
            {
                if (conexion_now.comprobar_existencia_proveedor_crear(nombre_empresa))
                {
                    respuesta = "El proveedor " + nombre_empresa + " ya existe";
                    done = false;
                }
                else
                {
                    if (conexion_now.agregarProveedor(nombre_empresa, direccion, telefono))
                    {
                        respuesta = "El proveedor ha sido registrado exitosamente";
                        done = true;
                    }
                    else
                    {
                        respuesta = "Ha ocurrido un error en la base de datos";
                        done = false;
                    }
                }
            }
            else
            {
                respuesta = "Los datos ingresados en el formulario son invalidos";
                done = false;
            }

            return Json(new { success = done, message = respuesta });
        }

        public ActionResult EditarProveedor()
        {
            string respuesta = "";
            bool done = false;

            int id_proveedor = Convert.ToInt32(Request["id_proveedor"]);
            string nombre_empresa = Request["nombre_empresa"];
            string direccion = Request["direccion"]; 
            int telefono = Convert.ToInt32(Request["telefono"]); 

            if (funcion.valid_number(id_proveedor.ToString()) && nombre_empresa != "" && direccion != "" && funcion.valid_number(telefono.ToString()))
            {
                if (conexion_now.comprobar_existencia_proveedor_editar(id_proveedor, nombre_empresa))
                {
                    respuesta = "El proveedor " + nombre_empresa + " ya existe";
                    done = false;
                }
                else
                {
                    if (conexion_now.editarProveedor(id_proveedor, nombre_empresa, direccion, telefono))
                    {
                        respuesta = "El proveedor ha sido editado exitosamente";
                        done = true;
                    }
                    else
                    {
                        respuesta = "Ha ocurrido un error en la base de datos";
                        done = false;
                    }
                }
            }
            else
            {
                respuesta = "Los datos ingresados en el formulario son invalidos";
                done = false;
            }

            return Json(new { success = done, message = respuesta });

        }

        public ActionResult BorrarProveedor()
        {
            bool done = false;
            string respuesta = "";

            int id = Convert.ToInt32(Request["id_proveedor"]);

            if (funcion.valid_number(id.ToString()))
            {
                if (conexion_now.borrarProveedor(id))
                {
                    respuesta = "El proveedor ha sido borrado exitosamente";
                    done = true;
                }
                else
                {
                    respuesta = "Ha ocurrido un error en la base de datos";
                    done = false;
                }
            }
            else
            {
                respuesta = "ID invalido";
                done = false;
            }

            return Json(new { success = done, message = respuesta });

        }

        public ActionResult AgregarUsuario()
        {
            string respuesta = "";
            bool done = false;

            string nombre_usuario = Request["nombre_usuario"];
            string clave = Request["password"];
            int tipo = Convert.ToInt32(Request["tipo"]);

            if (nombre_usuario != "" && clave != "" && funcion.valid_number(tipo.ToString()))
            {
                if (conexion_now.comprobar_existencia_usuario_crear(nombre_usuario))
                {
                    respuesta = "El usuario " + nombre_usuario + " ya existe";
                    done = false;
                }
                else
                {
                    string password_encoded = funcion.md5_encode(clave);
                    if (conexion_now.agregarUsuario(nombre_usuario, password_encoded, tipo))
                    {
                        respuesta = "El usuario ha sido registrado exitosamente";
                        done = true;
                    }
                    else
                    {
                        respuesta = "Ha ocurrido un error en la base de datos";
                        done = false;
                    }
                }
            }
            else
            {
                respuesta = "Los datos ingresados en el formulario son invalidos";
                done = false;
            }

            return Json(new { success = done, message = respuesta });

        }

        public ActionResult EditarUsuario()
        {

            string respuesta = "";
            bool done = false;

            int id_usuario = Convert.ToInt32(Request["id_usuario"]);
            int tipo = Convert.ToInt32(Request["tipo"]);

            if (funcion.valid_number(id_usuario.ToString()) && funcion.valid_number(tipo.ToString()))
            {
                if (conexion_now.asignar_usuario(id_usuario, tipo))
                {
                    respuesta = "El usuario ha sido asignado exitosamente";
                    done = true;
                }
                else
                {
                    respuesta = "Ha ocurrido un error en la base de datos";
                    done = false;
                }
            }
            else
            {
                respuesta = "Los datos ingresados en el formulario son invalidos";
                done = false;
            }

            return Json(new { success = done, message = respuesta });

        }

        public ActionResult BorrarUsuario()
        {

            bool done = false;
            string respuesta = "";

            int id = Convert.ToInt32(Request["id_usuario"]);

            if (funcion.valid_number(id.ToString()))
            {
                if (conexion_now.borrarUsuario(id))
                {
                    respuesta = "El usuario ha sido borrado exitosamente";
                    done = true;
                }
                else
                {
                    respuesta = "Ha ocurrido un error en la base de datos";
                    done = false;
                }
            }
            else
            {
                respuesta = "ID invalido";
                done = false;
            }

            return Json(new { success = done, message = respuesta });

        }

        public ActionResult CambiarUsuario()
        {

            bool done = false;
            string respuesta = "";

            string nombre_usuario = Request["username"];
            string password = funcion.md5_encode(Request["password"]);
            string nuevo_usuario = Request["new_username"];

            if (nombre_usuario != "" && password != "" && nuevo_usuario != "")
            {
                if (conexion_now.ingreso_usuario(nombre_usuario, password))
                {
                    if (conexion_now.cambiar_usuario(nombre_usuario, nuevo_usuario))
                    {
                        respuesta = "El usuario ha sido cambiado exitosamente, reinicie la aplicacion";
                        done = true;
                    }
                    else
                    {
                        respuesta = "Ha ocurrido un error en la base de datos";
                        done = false;
                    }
                }
                else
                {
                    respuesta = "Login Incorrecto";
                    done = false;
                }
            }
            else
            {
                respuesta = "Los datos ingresados en el formulario son invalidos";
                done = false;
            }

            return Json(new { success = done, message = respuesta });

        }

        public ActionResult CambiarPassword()
        {

            bool done = false;
            string respuesta = "";

            string nombre_usuario = Request["username"];
            string password = funcion.md5_encode(Request["anterior_password"]);
            string nuevo_password = funcion.md5_encode(Request["new_password"]);

            if (nombre_usuario != "" && password != "" && nuevo_password != "")
            {
                if (conexion_now.ingreso_usuario(nombre_usuario, password))
                {
                    if (conexion_now.cambiar_password(nombre_usuario,nuevo_password))
                    {
                        respuesta = "El password ha sido cambiado exitosamente, reinicie la aplicacion";
                        done = true;
                    }
                    else
                    {
                        respuesta = "Ha ocurrido un error en la base de datos";
                        done = false;
                    }
                }
                else
                {
                    respuesta = "Login Incorrecto";
                    done = false;
                }
            }
            else
            {
                respuesta = "Los datos ingresados en el formulario son invalidos";
                done = false;
            }

            return Json(new { success = done, message = respuesta });
        }

        // Reportes
        public ActionResult DescargarReporte()
        {

            CrystalDecisions.CrystalReports.Engine.ReportDocument reporte = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            reporte.Load(Server.MapPath("~/Reportes/Reporte.rpt"));
            reporte.SetDatabaseLogon("admin", "123456", "localhost\\SQLEXPRESS", "sistema");
            reporte.Refresh();

            try
            {
                Stream stream = reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Sistema_Reporte.pdf");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //

	}
}