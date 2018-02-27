// Written by Ismael Heredia in the year 2017
package sistema.controllers;

import java.util.ArrayList;
import javax.servlet.http.HttpServletRequest;
import javax.validation.Valid;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.servlet.ModelAndView;
import sistema.bo.ProductoBO;
import sistema.bo.ProveedorBO;
import sistema.functions.Funciones;
import sistema.models.Buscador;
import sistema.models.Mensaje;
import sistema.models.Producto;

@Controller
public class ProductosController {

    ApplicationContext context
            = new ClassPathXmlApplicationContext("Spring-Module.xml");

    ProductoBO productoBO = (ProductoBO) context.getBean("ProductoBO");
    ProveedorBO proveedorBO = (ProveedorBO) context.getBean("ProveedorBO");

    Funciones funcion = new Funciones();

    @ResponseStatus(value = HttpStatus.NOT_FOUND)
    public final class ResourceNotFoundException extends RuntimeException {
    }

    @RequestMapping("/administracion/productos")
    public ModelAndView ProductosForm(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario_logeado = funcion.get_username_cookie(request);
            Buscador buscador = new Buscador();
            int cantidad = productoBO.listProductos("").size();
            ArrayList productos = productoBO.listProductos("");
            ModelAndView model = new ModelAndView("productos/listar");
            model.addObject("usuario_logeado", usuario_logeado);
            model.addObject("Buscador", buscador);
            model.addObject("productos", productos);
            model.addObject("cantidad", cantidad);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/productos/listar")
    public ModelAndView FormListarProductosGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            return new ModelAndView("redirect:/administracion/productos");
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/productos/listar", method = RequestMethod.POST)
    public ModelAndView FormListarProductos(@ModelAttribute("Buscador") Buscador datos, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario_logeado = funcion.get_username_cookie(request);
            Buscador buscador = new Buscador();
            String nombre_buscar = datos.getNombre_buscar();
            ArrayList productos = productoBO.listProductos(nombre_buscar);
            int cantidad = productos.size();
            ModelAndView model = new ModelAndView("productos/listar");
            model.addObject("usuario_logeado", usuario_logeado);
            model.addObject("Buscador", buscador);
            model.addObject("productos", productos);
            model.addObject("cantidad", cantidad);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/productos/agregar")
    public ModelAndView AgregarForm(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario_logeado = funcion.get_username_cookie(request);
            Producto producto = new Producto();
            ArrayList proveedores = proveedorBO.listProveedores("");
            ModelAndView model = new ModelAndView("productos/agregar");
            model.addObject("usuario_logeado", usuario_logeado);
            model.addObject("Producto", producto);
            model.addObject("proveedores", proveedores);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/productos/agregar", method = RequestMethod.POST)
    public ModelAndView FormAgregarProducto(@Valid Producto producto, BindingResult result, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {

            String contenido = "";
            String tipo = "";

            if (result.hasErrors()) {
                contenido = "Faltan datos";
                tipo = "warning";
            } else {
                String nombre = producto.getNombre();
                String descripcion = producto.getDescripcion();
                double precio = producto.getPrecio();
                int id_proveedor = producto.getId_proveedor();
                String fecha_registro = funcion.fecha_del_dia();

                producto.setFecha_registro(fecha_registro);

                if (productoBO.check_exists_producto_new(nombre)) {
                    contenido = "El producto " + nombre + " ya existe";
                    tipo = "warning";
                } else {
                    if (productoBO.insert(producto)) {
                        contenido = "Producto registrado";
                        tipo = "success";
                    } else {
                        contenido = "Ha ocurrido un error en la base de datos";
                        tipo = "error";
                    }
                }
            }

            Mensaje mensaje = null;

            if ("success".equals(tipo)) {
                mensaje = new Mensaje("Productos", contenido, tipo, "administracion/productos");
            } else {
                mensaje = new Mensaje("Productos", contenido, tipo, "administracion/productos/agregar");
            }

            ModelAndView model = new ModelAndView("mensajes/redireccion");
            model.addObject("mensaje", mensaje);

            return model;

        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/productos/{id}/editar", method = RequestMethod.GET)
    public ModelAndView FormEditandoProducto(@PathVariable int id, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario_logeado = funcion.get_username_cookie(request);
            String contenido = "";
            String tipo = "";
            if (id > 0) {
                Producto producto = productoBO.findByProductoId(id);
                if (producto == null) {
                    throw new ResourceNotFoundException();
                } else {
                    ArrayList proveedores = proveedorBO.listProveedores("");
                    ModelAndView model = new ModelAndView("productos/editar");
                    model.addObject("usuario_logeado", usuario_logeado);
                    model.addObject("Producto", producto);
                    model.addObject("proveedores", proveedores);
                    return model;
                }
            } else {
                Mensaje mensaje = new Mensaje("Productos", "ID Inválido", "warning", "administracion/productos");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
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
    public ModelAndView FormEditarProducto(@Valid Producto producto, BindingResult result, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {

            String contenido = "";
            String tipo = "";

            if (result.hasErrors()) {
                contenido = "Faltan datos";
                tipo = "warning";
            } else {
                int id = producto.getId();
                String nombre = producto.getNombre();
                String descripcion = producto.getDescripcion();
                double precio = producto.getPrecio();
                int id_proveedor = producto.getId_proveedor();

                if (productoBO.check_exists_producto_edit(id, nombre)) {
                    contenido = "El producto " + nombre + " ya existe";
                    tipo = "warning";
                } else {
                    if (productoBO.update(producto)) {
                        contenido = "Producto editado";
                        tipo = "success";
                    } else {
                        contenido = "Ha ocurrido un error en la base de datos";
                        tipo = "error";
                    }
                }
            }

            Mensaje mensaje = null;

            if ("success".equals(tipo)) {
                mensaje = new Mensaje("Productos", contenido, tipo, "administracion/productos");
            } else {
                mensaje = new Mensaje("Productos", contenido, tipo, "administracion/productos/" + producto.getId() + "/editar");
            }

            ModelAndView model = new ModelAndView("mensajes/redireccion");
            model.addObject("mensaje", mensaje);

            return model;

        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/productos/{id}/borrar", method = RequestMethod.GET)
    public ModelAndView FormConfirmarBorrarProducto(@PathVariable int id, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario_logeado = funcion.get_username_cookie(request);
            Producto producto = productoBO.findByProductoId(id);
            if (producto == null) {
                throw new ResourceNotFoundException();
            } else {
                ModelAndView model = new ModelAndView("productos/borrar");
                model.addObject("usuario_logeado", usuario_logeado);
                model.addObject("Producto", producto);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/productos/borrar", method = RequestMethod.POST)
    public ModelAndView FormBorrarProducto(@ModelAttribute("Producto") Producto producto, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String contenido = "";
            String tipo = "";
            int id = producto.getId();
            if (id > 0) {
                if (productoBO.delete(productoBO.findByProductoId(id)) == true) {
                    contenido = "Producto borrado";
                    tipo = "success";
                } else {
                    contenido = "Ha ocurrido un error en la base de datos";
                    tipo = "error";
                }
            } else {
                contenido = "ID Inválido";
                tipo = "warning";
            }

            Mensaje mensaje = null;

            if ("success".equals(tipo)) {
                mensaje = new Mensaje("Productos", contenido, tipo, "administracion/productos");
            } else {
                mensaje = new Mensaje("Productos", contenido, tipo, "administracion/productos/" + producto.getId() + "/borrar");
            }

            ModelAndView model = new ModelAndView("mensajes/redireccion");
            model.addObject("mensaje", mensaje);

            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/productos/borrar")
    public ModelAndView FormBorrarProductoGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            return new ModelAndView("redirect:/administracion/productos");
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

}
