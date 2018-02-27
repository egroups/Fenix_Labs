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
import sistema.bo.TipoUsuarioBO;
import sistema.bo.UsuarioBO;
import sistema.functions.Funciones;
import sistema.models.Buscador;
import sistema.models.Mensaje;
import sistema.models.AsignarUsuario;
import sistema.models.Usuario;

@Controller
public class UsuariosController {

    ApplicationContext context
            = new ClassPathXmlApplicationContext("Spring-Module.xml");

    UsuarioBO usuarioBO = (UsuarioBO) context.getBean("UsuarioBO");
    TipoUsuarioBO tipoUsuarioBO = (TipoUsuarioBO) context.getBean("TipoUsuarioBO");

    Funciones funcion = new Funciones();

    @ResponseStatus(value = HttpStatus.NOT_FOUND)
    public final class ResourceNotFoundException extends RuntimeException {
    }

    @RequestMapping("/administracion/usuarios")
    public ModelAndView UsuariosForm(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                String usuario_logeado = funcion.get_username_cookie(request);
                Buscador buscador = new Buscador();
                int cantidad = usuarioBO.listUsuarios("").size();
                ArrayList usuarios = usuarioBO.listUsuarios("");
                ModelAndView model = new ModelAndView("usuarios/listar");
                model.addObject("usuario_logeado", usuario_logeado);
                model.addObject("Buscador", buscador);
                model.addObject("usuarios", usuarios);
                model.addObject("cantidad", cantidad);
                return model;
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/usuarios/listar")
    public ModelAndView FormListarProductosGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                return new ModelAndView("redirect:/administracion/usuarios");
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/usuarios/listar", method = RequestMethod.POST)
    public ModelAndView FormListarUsuarios(@ModelAttribute("Buscador") Buscador datos, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                String usuario_logeado = funcion.get_username_cookie(request);
                Buscador buscador = new Buscador();
                String nombre_buscar = datos.getNombre_buscar();
                ArrayList usuarios = usuarioBO.listUsuarios(nombre_buscar);
                int cantidad = usuarios.size();
                ModelAndView model = new ModelAndView("usuarios/listar");
                model.addObject("usuario_logeado", usuario_logeado);
                model.addObject("Buscador", buscador);
                model.addObject("usuarios", usuarios);
                model.addObject("cantidad", cantidad);
                return model;
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/usuarios/agregar")
    public ModelAndView AgregarForm(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                String usuario_logeado = funcion.get_username_cookie(request);
                AsignarUsuario usuario = new AsignarUsuario();
                ArrayList tipos = tipoUsuarioBO.listTipoUsuario("");
                ModelAndView model = new ModelAndView("usuarios/agregar");
                model.addObject("usuario_logeado", usuario_logeado);
                model.addObject("Usuario", usuario);
                model.addObject("tipos", tipos);
                return model;
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/usuarios/agregar", method = RequestMethod.POST)
    public ModelAndView FormAgregarUsuario(@Valid Usuario usuario, BindingResult result, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {

                String contenido = "";
                String tipo = "";

                if (result.hasErrors()) {
                    contenido = "Faltan datos";
                    tipo = "warning";
                } else {

                    String nombre = usuario.getNombre();
                    String clave = funcion.md5_encode(usuario.getClave());
                    int id_tipo = usuario.getId_tipo();
                    String fecha_registro = funcion.fecha_del_dia();
                    usuario.setClave(funcion.md5_encode(usuario.getClave()));
                    usuario.setFecha_registro(fecha_registro);

                    if (usuarioBO.check_exists_usuario_new(nombre)) {
                        contenido = "El usuario " + nombre + " ya existe";
                        tipo = "warning";
                    } else {
                        if (usuarioBO.insert(usuario)) {
                            contenido = "Usuario registrado";
                            tipo = "success";
                        } else {
                            contenido = "Ha ocurrido un error en la base de datos";
                            tipo = "error";
                        }
                    }
                }

                Mensaje mensaje = null;

                if ("success".equals(tipo)) {
                    mensaje = new Mensaje("Usuarios", contenido, tipo, "administracion/usuarios");
                } else {
                    mensaje = new Mensaje("Usuarios", contenido, tipo, "administracion/usuarios/agregar");
                }

                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);

                return model;
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
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
                String usuario_logeado = funcion.get_username_cookie(request);
                String contenido = "";
                String tipo = "";
                if (id > 0) {
                    Usuario usuario = usuarioBO.findByUsuarioId(id);
                    if (usuario == null) {
                        throw new ResourceNotFoundException();
                    } else {
                        ArrayList tipos = tipoUsuarioBO.listTipoUsuario("");
                        ModelAndView model = new ModelAndView("usuarios/editar");
                        model.addObject("usuario_logeado", usuario_logeado);
                        model.addObject("AsignarUsuario", usuario);
                        model.addObject("tipos", tipos);
                        return model;
                    }
                } else {
                    Mensaje mensaje = new Mensaje("Usuarios", "ID Inválido", "warning", "administracion/usuarios");
                    ModelAndView model = new ModelAndView("mensajes/redireccion");
                    model.addObject("mensaje", mensaje);
                    return model;
                }
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
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
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/usuarios/editar", method = RequestMethod.POST)
    public ModelAndView FormEditarUsuario(@Valid AsignarUsuario usuario, BindingResult result, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {

                String contenido = "";
                String tipo = "";

                if (result.hasErrors()) {
                    contenido = "Faltan datos";
                    tipo = "warning";
                } else {

                    int id_usuario = usuario.getId();
                    String nombre = usuario.getNombre();
                    int id_tipo = usuario.getId_tipo();

                    if (usuarioBO.update(usuario)) {
                        contenido = "Usuario editado";
                        tipo = "success";
                    } else {
                        contenido = "Ha ocurrido un error en la base de datos";
                        tipo = "error";
                    }
                }

                Mensaje mensaje = null;

                if ("success".equals(tipo)) {
                    mensaje = new Mensaje("Usuarios", contenido, tipo, "administracion/usuarios");
                } else {
                    mensaje = new Mensaje("Usuarios", contenido, tipo, "administracion/usuarios/" + usuario.getId() + "/editar");
                }

                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);

                return model;
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }

        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/usuarios/{id}/borrar", method = RequestMethod.GET)
    public ModelAndView FormConfirmarBorrarUsuario(@PathVariable int id, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                String usuario_logeado = funcion.get_username_cookie(request);
                Usuario usuario = usuarioBO.findByUsuarioId(id);
                if (usuario == null) {
                    throw new ResourceNotFoundException();
                } else {
                    ModelAndView model = new ModelAndView("usuarios/borrar");
                    model.addObject("usuario_logeado", usuario_logeado);
                    model.addObject("Usuario", usuario);
                    return model;
                }
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/usuarios/borrar", method = RequestMethod.POST)
    public ModelAndView FormBorrarUsuario(@ModelAttribute("Usuario") Usuario usuario, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                String contenido = "";
                String tipo = "";
                int id = usuario.getId();
                if (id > 0) {
                    if (usuarioBO.delete(usuarioBO.findByUsuarioId(id)) == true) {
                        contenido = "Usuario borrado";
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
                    mensaje = new Mensaje("Usuarios", contenido, tipo, "administracion/usuarios");
                } else {
                    mensaje = new Mensaje("Usuarios", contenido, tipo, "administracion/usuarios/" + usuario.getId() + "/borrar");
                }

                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);

                return model;
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/usuarios/borrar")
    public ModelAndView FormBorrarUsuarioGET(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (funcion.validar_cookie_admin(request)) {
                return new ModelAndView("redirect:/administracion/usuarios");
            } else {
                Mensaje mensaje = new Mensaje("Usuarios", "Acceso Denegado", "error", "administracion");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

}
