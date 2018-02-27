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
import sistema.dao.ProveedorDAO;
import sistema.functions.Funciones;
import sistema.models.Buscador;
import sistema.models.Mensaje;
import sistema.models.Proveedor;

@Controller
public class ProveedoresController {

    ApplicationContext context
            = new ClassPathXmlApplicationContext("Spring-Module.xml");

    ProveedorDAO proveedorDAO = (ProveedorDAO) context.getBean("ProveedorDAO");

    Funciones funcion = new Funciones();

    @RequestMapping("/administracion/proveedores")
    public ModelAndView ProveedoresForm(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            Buscador buscador = new Buscador();
            Proveedor proveedor = new Proveedor();
            int cantidad_proveedores_total = proveedorDAO.listProveedores("").size();
            ModelAndView model = new ModelAndView("FormAgregarProveedor");
            model.addObject("cantidad_proveedores_total", cantidad_proveedores_total);
            model.addObject("Buscador", buscador);
            model.addObject("BuscadorActivo", "0");
            model.addObject("Proveedor", proveedor);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/proveedores/buscar")
    public ModelAndView FormBuscadorProveedoresGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            return new ModelAndView("redirect:/administracion/proveedores");
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/proveedores/buscar", method = RequestMethod.POST)
    public ModelAndView FormBuscadorProveedores(@ModelAttribute("Buscador") Buscador datos, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            Buscador buscador = new Buscador();
            Proveedor proveedor = new Proveedor();
            String nombre_buscar = datos.getNombre_buscar();
            int cantidad_proveedores_total = proveedorDAO.listProveedores("").size();
            ArrayList proveedores = proveedorDAO.listProveedores(nombre_buscar);
            int cantidad_proveedores_encontrados = proveedores.size();
            ModelAndView model = new ModelAndView("FormAgregarProveedor");
            model.addObject("cantidad_proveedores_total", cantidad_proveedores_total);
            model.addObject("cantidad_proveedores_encontrados", cantidad_proveedores_encontrados);
            model.addObject("Buscador", buscador);
            model.addObject("BuscadorActivo", "1");
            model.addObject("Proveedor", proveedor);
            model.addObject("proveedores", proveedores);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/proveedores/agregar")
    public ModelAndView FormAgregarProveedorGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            return new ModelAndView("redirect:/administracion/proveedores");
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/proveedores/agregar", method = RequestMethod.POST)
    public ModelAndView FormAgregarProveedor(@ModelAttribute("Proveedor") Proveedor proveedor, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String nombre_empresa = proveedor.getNombre_empresa();
            String direccion = proveedor.getDireccion();
            int telefono = proveedor.getTelefono();
            String fecha_registro = funcion.fecha_del_dia();

            proveedor.setFecha_registro(fecha_registro);

            String msg = "";
            String tipo = "";

            if (!"".equals(nombre_empresa) && !"".equals(direccion) && funcion.valid_number(String.valueOf(telefono)) && !"".equals(fecha_registro)) {
                if (proveedorDAO.comprobar_existencia_proveedor_crear(nombre_empresa)) {
                    msg = "El proveedor " + nombre_empresa + " ya existe";
                    tipo = "warning";
                } else {
                    if (proveedorDAO.insert(proveedor)) {
                        msg = "Proveedor registrado";
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

            Mensaje mensaje = new Mensaje("Proveedores", msg, tipo, "administracion/proveedores");
            ModelAndView model = new ModelAndView("Redireccion");
            model.addObject("mensaje", mensaje);

            return model;

        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/proveedores/{id}/editar", method = RequestMethod.GET)
    public ModelAndView FormEditandoProveedor(@PathVariable int id, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String msg = "";
            String tipo = "";
            if (id > 0) {
                Proveedor proveedor = proveedorDAO.findByProveedorId(id);
                Buscador buscador = new Buscador();
                int cantidad_proveedores_total = proveedorDAO.listProveedores("").size();
                ArrayList proveedores = proveedorDAO.listProveedores("");
                ModelAndView model = new ModelAndView("FormEditarProveedor");
                model.addObject("cantidad_proveedores_total", cantidad_proveedores_total);
                model.addObject("Buscador", buscador);
                model.addObject("BuscadorActivo", "0");
                model.addObject("Proveedor", proveedor);
                return model;
            } else {
                Mensaje mensaje = new Mensaje("Proveedores", "ID Invalido", "warning", "administracion/proveedores");
                ModelAndView model = new ModelAndView("Redireccion");
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
    public ModelAndView FormEditarProveedor(@ModelAttribute("Proveedor") Proveedor proveedor, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            int id_proveedor = proveedor.getId_proveedor();
            String nombre_empresa = proveedor.getNombre_empresa();
            String direccion = proveedor.getDireccion();
            int telefono = proveedor.getTelefono();

            String msg = "";
            String tipo = "";

            if (!"".equals(nombre_empresa) && !"".equals(direccion) && funcion.valid_number(String.valueOf(telefono))) {
                if (proveedorDAO.comprobar_existencia_proveedor_crear(nombre_empresa)) {
                    msg = "El proveedor " + nombre_empresa + " ya existe";
                    tipo = "warning";
                } else {
                    if (proveedorDAO.update(proveedor)) {
                        msg = "Proveedor editado";
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

            Mensaje mensaje = new Mensaje("Proveedores", msg, tipo, "administracion/proveedores");
            ModelAndView model = new ModelAndView("Redireccion");
            model.addObject("mensaje", mensaje);

            return model;

        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/proveedores/{id}/borrar", method = RequestMethod.GET)
    public ModelAndView FormBorrarProveedor(@PathVariable int id, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String msg = "";
            String tipo = "";
            if (id > 0) {
                if (proveedorDAO.delete(proveedorDAO.findByProveedorId(id)) == true) {
                    msg = "Proveedor borrado";
                    tipo = "success";
                } else {
                    msg = "Ha ocurrido un error en la base de datos";
                    tipo = "error";
                }
            } else {
                msg = "ID Invalido";
                tipo = "warning";
            }
            Mensaje mensaje = new Mensaje("Proveedores", msg, tipo, "administracion/proveedores");
            ModelAndView model = new ModelAndView("Redireccion");
            model.addObject("mensaje", mensaje);

            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

}
