// Written by Ismael Heredia in the year 2016

package sistema.controllers;

import java.util.ArrayList;
import javax.servlet.http.HttpServletRequest;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;
import sistema.dao.ProductoDAO;
import sistema.dao.ProveedorDAO;
import sistema.functions.Funciones;
import sistema.models.Buscador;
import sistema.models.Mensaje;
import sistema.models.Producto;

@Controller
public class ProductosController {

    ApplicationContext context
            = new ClassPathXmlApplicationContext("Spring-Module.xml");

    ProductoDAO productoDAO = (ProductoDAO) context.getBean("ProductoDAO");
    ProveedorDAO proveedorDAO = (ProveedorDAO) context.getBean("ProveedorDAO");

    Funciones funcion = new Funciones();

    @RequestMapping("/administracion/productos")
    public ModelAndView ProductosForm(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            Buscador buscador = new Buscador();
            Producto producto = new Producto();
            int cantidad_productos_total = productoDAO.listProductos("").size();
            ArrayList proveedores = proveedorDAO.listProveedores("");
            ModelAndView model = new ModelAndView("FormAgregarProducto");
            model.addObject("cantidad_productos_total", cantidad_productos_total);
            model.addObject("Buscador", buscador);
            model.addObject("BuscadorActivo", "0");
            model.addObject("Producto", producto);
            model.addObject("proveedores", proveedores);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/productos/buscar")
    public ModelAndView FormBuscadorProductosGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            return new ModelAndView("redirect:/administracion/productos");
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/productos/buscar", method = RequestMethod.POST)
    public ModelAndView FormBuscadorProductos(@ModelAttribute("Buscador") Buscador datos, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            Buscador buscador = new Buscador();
            Producto producto = new Producto();
            String nombre_buscar = datos.getNombre_buscar();
            int cantidad_productos_total = productoDAO.listProductos("").size();
            ArrayList productos = productoDAO.listProductos(nombre_buscar);
            int cantidad_productos_encontrados = productos.size();
            ArrayList proveedores = proveedorDAO.listProveedores("");
            ModelAndView model = new ModelAndView("FormAgregarProducto");
            model.addObject("cantidad_productos_total", cantidad_productos_total);
            model.addObject("cantidad_productos_encontrados", cantidad_productos_encontrados);
            model.addObject("Buscador", buscador);
            model.addObject("BuscadorActivo", "1");
            model.addObject("Producto", producto);
            model.addObject("productos", productos);
            model.addObject("proveedores", proveedores);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/productos/agregar")
    public ModelAndView FormAgregarProductoGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            return new ModelAndView("redirect:/administracion/productos");
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/productos/agregar", method = RequestMethod.POST)
    public ModelAndView FormAgregarProducto(@ModelAttribute("Producto") Producto producto, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String nombre_producto = producto.getNombre_producto();
            String descripcion = producto.getDescripcion();
            int precio = producto.getPrecio();
            int id_proveedor = producto.getId_proveedor();
            String fecha_registro = funcion.fecha_del_dia();

            producto.setFecha_registro(fecha_registro);

            String msg = "";
            String tipo = "";

            if (!"".equals(nombre_producto) && !"".equals(descripcion) && funcion.valid_number(String.valueOf(precio)) && funcion.valid_number(String.valueOf(id_proveedor)) && !"".equals(fecha_registro)) {
                if (productoDAO.comprobar_existencia_producto_crear(nombre_producto)) {
                    msg = "El producto " + nombre_producto + " ya existe";
                    tipo = "warning";
                } else {
                    if (productoDAO.insert(producto)) {
                        msg = "Producto registrado";
                        tipo = "success";
                    } else {
                        msg = "Ha ocurrido un error en la base de datos";
                        tipo = "error";
                    }
                }
            } else {
                msg = "Faltan datos";
                tipo = "warning";
            }

            Mensaje mensaje = new Mensaje("Productos", msg, tipo, "administracion/productos");
            ModelAndView model = new ModelAndView("Redireccion");
            model.addObject("mensaje", mensaje);

            return model;

        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/productos/{id}/editar", method = RequestMethod.GET)
    public ModelAndView FormEditandoProducto(@PathVariable int id, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String msg = "";
            String tipo = "";
            if (id > 0) {
                Producto producto = productoDAO.findByProductoId(id);
                Buscador buscador = new Buscador();
                int cantidad_productos_total = productoDAO.listProductos("").size();
                ArrayList proveedores = proveedorDAO.listProveedores("");
                ModelAndView model = new ModelAndView("FormEditarProducto");
                model.addObject("cantidad_productos_total", cantidad_productos_total);
                model.addObject("Buscador", buscador);
                model.addObject("BuscadorActivo", "0");
                model.addObject("Producto", producto);
                model.addObject("proveedores", proveedores);
                return model;
            } else {
                Mensaje mensaje = new Mensaje("Productos", "ID Invalido", "warning", "administracion/productos");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/productos/editar")
    public ModelAndView FormEditarProductoGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            return new ModelAndView("redirect:/administracion/productos");
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/productos/editar", method = RequestMethod.POST)
    public ModelAndView FormEditarProducto(@ModelAttribute("Producto") Producto producto, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            int id_producto = producto.getId_producto();
            String nombre_producto = producto.getNombre_producto();
            String descripcion = producto.getDescripcion();
            int precio = producto.getPrecio();
            int id_proveedor = producto.getId_proveedor();

            String msg = "";
            String tipo = "";

            if (funcion.valid_number(String.valueOf(id_producto)) && !"".equals(nombre_producto) && !"".equals(descripcion) && funcion.valid_number(String.valueOf(precio)) && funcion.valid_number(String.valueOf(id_proveedor))) {
                if (productoDAO.comprobar_existencia_producto_crear(nombre_producto)) {
                    msg = "El producto " + nombre_producto + " ya existe";
                    tipo = "warning";
                } else {
                    if (productoDAO.update(producto)) {
                        msg = "Producto editado";
                        tipo = "success";
                    } else {
                        msg = "Ha ocurrido un error en la base de datos";
                        tipo = "error";
                    }
                }
            } else {
                msg = "Faltan datos";
                tipo = "warning";
            }

            Mensaje mensaje = new Mensaje("Productos", msg, tipo, "administracion/productos");
            ModelAndView model = new ModelAndView("Redireccion");
            model.addObject("mensaje", mensaje);

            return model;

        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/productos/{id}/borrar", method = RequestMethod.GET)
    public ModelAndView FormBorrarProducto(@PathVariable int id, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String msg = "";
            String tipo = "";
            if (id > 0) {
                if (productoDAO.delete(productoDAO.findByProductoId(id)) == true) {
                    msg = "Producto borrado";
                    tipo = "success";
                } else {
                    msg = "Ha ocurrido un error en la base de datos";
                    tipo = "error";
                }
            } else {
                msg = "ID Invalido";
                tipo = "warning";
            }
            Mensaje mensaje = new Mensaje("Productos", msg, tipo, "administracion/productos");
            ModelAndView model = new ModelAndView("Redireccion");
            model.addObject("mensaje", mensaje);

            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

}
