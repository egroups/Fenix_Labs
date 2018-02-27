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
import sistema.dao.UsuarioDAO;
import sistema.functions.Funciones;
import sistema.models.Buscador;
import sistema.models.Mensaje;
import sistema.models.Usuario;

@Controller
public class UsuariosController {

    ApplicationContext context
            = new ClassPathXmlApplicationContext("Spring-Module.xml");

    UsuarioDAO usuarioDAO = (UsuarioDAO) context.getBean("UsuarioDAO");

    Funciones funcion = new Funciones();

    @RequestMapping("/administracion/usuarios")
    public ModelAndView UsuariosForm(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                Buscador buscador = new Buscador();
                Usuario usuario = new Usuario();
                int cantidad_usuarios_total = usuarioDAO.listUsuarios("").size();
                ArrayList usuarios = usuarioDAO.listUsuarios("");
                ModelAndView model = new ModelAndView("FormAgregarUsuario");
                model.addObject("cantidad_usuarios_total", cantidad_usuarios_total);
                model.addObject("Buscador", buscador);
                model.addObject("BuscadorActivo", "0");
                model.addObject("Usuario", usuario);
                return model;
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/usuarios/buscar")
    public ModelAndView FormBuscadorUsuariosGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                return new ModelAndView("redirect:/administracion/usuarios");
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/usuarios/buscar", method = RequestMethod.POST)
    public ModelAndView FormBuscadorUsuarios(@ModelAttribute("Buscador") Buscador datos, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                Buscador buscador = new Buscador();
                Usuario usuario = new Usuario();
                String nombre_buscar = datos.getNombre_buscar();
                int cantidad_usuarios_total = usuarioDAO.listUsuarios("").size();
                ArrayList usuarios = usuarioDAO.listUsuarios(nombre_buscar);
                int cantidad_usuarios_encontrados = usuarios.size();
                ModelAndView model = new ModelAndView("FormAgregarUsuario");
                model.addObject("cantidad_usuarios_total", cantidad_usuarios_total);
                model.addObject("cantidad_usuarios_encontrados", cantidad_usuarios_encontrados);
                model.addObject("Buscador", buscador);
                model.addObject("BuscadorActivo", "1");
                model.addObject("Usuario", usuario);
                model.addObject("usuarios", usuarios);
                return model;
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/usuarios/agregar")
    public ModelAndView FormAgregarUsuarioGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                return new ModelAndView("redirect:/administracion/usuarios");
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/usuarios/agregar", method = RequestMethod.POST)
    public ModelAndView FormAgregarUsuario(@ModelAttribute("Usuario") Usuario usuario, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                String nombre = usuario.getNombre();
                String password = funcion.md5_encode(usuario.getPassword());
                int tipo_usuario = usuario.getTipo();
                String fecha_registro = funcion.fecha_del_dia();
                usuario.setPassword(funcion.md5_encode(usuario.getPassword()));
                usuario.setFecha_registro(fecha_registro);

                String msg = "";
                String tipo = "";

                if (!"".equals(nombre) && !"".equals(password) && funcion.valid_number(String.valueOf(tipo_usuario)) && !"".equals(fecha_registro)) {
                    if (usuarioDAO.comprobar_existencia_usuario_crear(nombre)) {
                        msg = "El usuario " + nombre + " ya existe";
                        tipo = "warning";
                    } else {
                        if (usuarioDAO.insert(usuario)) {
                            msg = "Usuario registrado";
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

                Mensaje mensaje = new Mensaje("Usuarios", msg, tipo, "administracion/usuarios");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);

                return model;
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }

        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/usuarios/{id}/editar", method = RequestMethod.GET)
    public ModelAndView FormEditandoUsuario(@PathVariable int id, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                String msg = "";
                String tipo = "";
                if (id > 0) {
                    Usuario usuario = usuarioDAO.findByUsuarioId(id);
                    Buscador buscador = new Buscador();
                    int cantidad_usuarios_total = usuarioDAO.listUsuarios("").size();
                    ModelAndView model = new ModelAndView("FormEditarUsuario");
                    model.addObject("cantidad_usuarios_total", cantidad_usuarios_total);
                    model.addObject("Buscador", buscador);
                    model.addObject("BuscadorActivo", "0");
                    model.addObject("Usuario", usuario);
                    return model;
                } else {
                    Mensaje mensaje = new Mensaje("Usuarios", "ID Invalido", "warning", "administracion/usuarios");
                    ModelAndView model = new ModelAndView("Redireccion");
                    model.addObject("mensaje", mensaje);
                    return model;
                }
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/usuarios/editar")
    public ModelAndView FormEditarUsuarioGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                return new ModelAndView("redirect:/administracion/usuarios");
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/usuarios/editar", method = RequestMethod.POST)
    public ModelAndView FormEditarUsuario(@ModelAttribute("Usuario") Usuario usuario, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                int id_usuario = usuario.getId_usuario();
                String nombre = usuario.getNombre();
                String password = usuario.getPassword();
                int tipo_usuario = usuario.getTipo();

                String msg = "";
                String tipo = "";

                if (funcion.valid_number(String.valueOf(id_usuario)) && !"".equals(nombre) && funcion.valid_number(String.valueOf(tipo_usuario))) {
                    if (usuarioDAO.update(usuario)) {
                        msg = "Usuario editado";
                        tipo = "success";
                    } else {
                        msg = "Ha ocurrido un error en la base de datos";
                        tipo = "error";
                    }
                } else {
                    msg = "Faltan datos";
                    tipo = "warning";
                }

                Mensaje mensaje = new Mensaje("Usuarios", msg, tipo, "administracion/usuarios");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);

                return model;
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }

        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/usuarios/{id}/borrar", method = RequestMethod.GET)
    public ModelAndView FormBorrarUsuario(@PathVariable int id, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                String msg = "";
                String tipo = "";
                if (id > 0) {
                    if (usuarioDAO.delete(usuarioDAO.findByUsuarioId(id)) == true) {
                        msg = "Usuario borrado";
                        tipo = "success";
                    } else {
                        msg = "Ha ocurrido un error en la base de datos";
                        tipo = "error";
                    }
                } else {
                    msg = "ID Invalido";
                    tipo = "warning";
                }
                Mensaje mensaje = new Mensaje("Usuarios", msg, tipo, "administracion/usuarios");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);

                return model;
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

}
