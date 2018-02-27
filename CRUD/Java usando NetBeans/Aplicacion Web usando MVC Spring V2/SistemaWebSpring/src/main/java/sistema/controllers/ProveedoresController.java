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
import sistema.bo.ProveedorBO;
import sistema.functions.Funciones;
import sistema.models.Buscador;
import sistema.models.Mensaje;
import sistema.models.Proveedor;

@Controller
public class ProveedoresController {

    ApplicationContext context
            = new ClassPathXmlApplicationContext("Spring-Module.xml");

    ProveedorBO proveedorBO = (ProveedorBO) context.getBean("ProveedorBO");

    Funciones funcion = new Funciones();

    @ResponseStatus(value = HttpStatus.NOT_FOUND)
    public final class ResourceNotFoundException extends RuntimeException {
    }

    @RequestMapping("/administracion/proveedores")
    public ModelAndView ProveedoresForm(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario_logeado = funcion.get_username_cookie(request);
            Buscador buscador = new Buscador();
            int cantidad = proveedorBO.listProveedores("").size();
            ArrayList proveedores = proveedorBO.listProveedores("");
            ModelAndView model = new ModelAndView("proveedores/listar");
            model.addObject("usuario_logeado", usuario_logeado);
            model.addObject("Buscador", buscador);
            model.addObject("proveedores", proveedores);
            model.addObject("cantidad", cantidad);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/proveedores/listar")
    public ModelAndView FormListarProveedoresGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            return new ModelAndView("redirect:/administracion/proveedores");
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/proveedores/listar", method = RequestMethod.POST)
    public ModelAndView FormListarProveedores(@ModelAttribute("Buscador") Buscador datos, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario_logeado = funcion.get_username_cookie(request);
            Buscador buscador = new Buscador();
            String nombre_buscar = datos.getNombre_buscar();
            ArrayList proveedores = proveedorBO.listProveedores(nombre_buscar);
            int cantidad = proveedores.size();
            ModelAndView model = new ModelAndView("proveedores/listar");
            model.addObject("usuario_logeado", usuario_logeado);
            model.addObject("Buscador", buscador);
            model.addObject("proveedores", proveedores);
            model.addObject("cantidad", cantidad);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/proveedores/agregar")
    public ModelAndView AgregarForm(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario_logeado = funcion.get_username_cookie(request);
            Proveedor proveedor = new Proveedor();
            ModelAndView model = new ModelAndView("proveedores/agregar");
            model.addObject("usuario_logeado", usuario_logeado);
            model.addObject("Proveedor", proveedor);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/proveedores/agregar", method = RequestMethod.POST)
    public ModelAndView FormAgregarProveedor(@Valid Proveedor proveedor, BindingResult result, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {

            String contenido = "";
            String tipo = "";

            if (result.hasErrors()) {
                contenido = "Faltan datos";
                tipo = "warning";
            } else {

                String nombre = proveedor.getNombre();
                String direccion = proveedor.getDireccion();
                int telefono = proveedor.getTelefono();
                String fecha_registro = funcion.fecha_del_dia();

                proveedor.setFecha_registro(fecha_registro);

                if (proveedorBO.check_exists_proveedor_new(nombre)) {
                    contenido = "El proveedor " + nombre + " ya existe";
                    tipo = "warning";
                } else {
                    if (proveedorBO.insert(proveedor)) {
                        contenido = "Proveedor registrado";
                        tipo = "success";
                    } else {
                        contenido = "Ha ocurrido un error en la base de datos";
                        tipo = "error";
                    }
                }
            }

            Mensaje mensaje = null;

            if ("success".equals(tipo)) {
                mensaje = new Mensaje("Proveedores", contenido, tipo, "administracion/proveedores");
            } else {
                mensaje = new Mensaje("Proveedores", contenido, tipo, "administracion/proveedores/agregar");
            }

            ModelAndView model = new ModelAndView("mensajes/redireccion");
            model.addObject("mensaje", mensaje);

            return model;

        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/proveedores/{id}/editar", method = RequestMethod.GET)
    public ModelAndView FormEditandoProveedor(@PathVariable int id, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario_logeado = funcion.get_username_cookie(request);
            String contenido = "";
            String tipo = "";
            if (id > 0) {
                Proveedor proveedor = proveedorBO.findByProveedorId(id);
                if (proveedor == null) {
                    throw new ResourceNotFoundException();
                } else {
                    ModelAndView model = new ModelAndView("proveedores/editar");
                    model.addObject("usuario_logeado", usuario_logeado);
                    model.addObject("Proveedor", proveedor);
                    return model;
                }
            } else {
                Mensaje mensaje = new Mensaje("Proveedores", "ID Inválido", "warning", "administracion/proveedores");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/proveedores/editar")
    public ModelAndView FormEditarProveedorGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            return new ModelAndView("redirect:/administracion/proveedores");
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/proveedores/editar", method = RequestMethod.POST)
    public ModelAndView FormEditarProveedor(@Valid Proveedor proveedor, BindingResult result, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {

            String contenido = "";
            String tipo = "";

            if (result.hasErrors()) {
                contenido = "Faltan datos";
                tipo = "warning";
            } else {
                int id = proveedor.getId();
                String nombre = proveedor.getNombre();
                String direccion = proveedor.getDireccion();
                int telefono = proveedor.getTelefono();

                if (proveedorBO.check_exists_proveedor_edit(id, nombre)) {
                    contenido = "El proveedor " + nombre + " ya existe";
                    tipo = "warning";
                } else {
                    if (proveedorBO.update(proveedor)) {
                        contenido = "Proveedor editado";
                        tipo = "success";
                    } else {
                        contenido = "Ha ocurrido un error en la base de datos";
                        tipo = "error";
                    }
                }
            }

            Mensaje mensaje = null;

            if ("success".equals(tipo)) {
                mensaje = new Mensaje("Proveedores", contenido, tipo, "administracion/proveedores");
            } else {
                mensaje = new Mensaje("Proveedores", contenido, tipo, "administracion/proveedores/" + proveedor.getId() + "/editar");
            }

            ModelAndView model = new ModelAndView("mensajes/redireccion");
            model.addObject("mensaje", mensaje);

            return model;

        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/proveedores/{id}/borrar", method = RequestMethod.GET)
    public ModelAndView FormConfirmarBorrarProveedor(@PathVariable int id, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario_logeado = funcion.get_username_cookie(request);
            Proveedor proveedor = proveedorBO.findByProveedorId(id);
            if (proveedor == null) {
                throw new ResourceNotFoundException();
            } else {
                ModelAndView model = new ModelAndView("proveedores/borrar");
                model.addObject("usuario_logeado", usuario_logeado);
                model.addObject("Proveedor", proveedor);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/proveedores/borrar", method = RequestMethod.POST)
    public ModelAndView FormBorrarProveedor(@ModelAttribute("Proveedor") Proveedor proveedor, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String contenido = "";
            String tipo = "";
            int id = proveedor.getId();
            if (id > 0) {
                if (proveedorBO.delete(proveedorBO.findByProveedorId(id)) == true) {
                    contenido = "Proveedor borrado";
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
                mensaje = new Mensaje("Proveedores", contenido, tipo, "administracion/proveedores");
            } else {
                mensaje = new Mensaje("Proveedores", contenido, tipo, "administracion/proveedores/" + proveedor.getId() + "/borrar");
            }

            ModelAndView model = new ModelAndView("mensajes/redireccion");
            model.addObject("mensaje", mensaje);

            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/proveedores/borrar")
    public ModelAndView FormBorrarProveedorGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            return new ModelAndView("redirect:/administracion/proveedores");
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

}
