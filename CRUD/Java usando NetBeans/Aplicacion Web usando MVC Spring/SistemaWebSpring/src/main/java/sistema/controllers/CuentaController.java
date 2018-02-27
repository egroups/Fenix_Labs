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
import sistema.models.CambiarPassword;
import sistema.models.CambiarUsuario;
import sistema.models.Mensaje;
import sistema.models.Usuario;

@Controller
public class CuentaController {

    ApplicationContext context
            = new ClassPathXmlApplicationContext("Spring-Module.xml");

    UsuarioDAO usuarioDAO = (UsuarioDAO) context.getBean("UsuarioDAO");

    Funciones funcion = new Funciones();

    @RequestMapping("/administracion/cuenta/cambiar_usuario")
    public ModelAndView FormCambiandoUsuario(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            CambiarUsuario cambiar_usuario = new CambiarUsuario();
            String usuario = funcion.get_username_cookie(request);
            ModelAndView model = new ModelAndView("FormCambiarUsuario");
            model.addObject("CambiarUsuario", cambiar_usuario);
            model.addObject("usuario", usuario);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/cuenta/cambiar_usuario", method = RequestMethod.POST)
    public ModelAndView FormCambiarUsuario(@ModelAttribute("CambiarUsuario") CambiarUsuario cambiar_usuario, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario = cambiar_usuario.getNombre_usuario();
            String nuevo_usuario = cambiar_usuario.getNuevo_usuario();
            String password = funcion.md5_encode(cambiar_usuario.getPassword());
            if (!"".equals(usuario) && !"".equals(nuevo_usuario) && !"".equals(password)) {
                if (usuarioDAO.ingreso_usuario(usuario, password)) {
                    if (usuarioDAO.cambiar_usuario(usuario, nuevo_usuario)) {
                        Mensaje mensaje = new Mensaje("Cambiar Usuario", "El usuario ha sido cambiado exitosamente , reinicie la aplicacion", "success", "Login/LogOut");
                        ModelAndView model = new ModelAndView("Redireccion");
                        model.addObject("mensaje", mensaje);
                        return model;
                    } else {
                        Mensaje mensaje = new Mensaje("Cambiar Usuario", "Ha ocurrido un error en la base de datos", "warning", "/administracion/cuenta/cambiar_usuario");
                        ModelAndView model = new ModelAndView("Redireccion");
                        model.addObject("mensaje", mensaje);
                        return model;
                    }
                } else {
                    Mensaje mensaje = new Mensaje("Cambiar Usuario", "Login Incorrecto", "warning", "/administracion/cuenta/cambiar_usuario");
                    ModelAndView model = new ModelAndView("Redireccion");
                    model.addObject("mensaje", mensaje);
                    return model;
                }
            } else {
                Mensaje mensaje = new Mensaje("Cambiar Usuario", "Faltan datos", "warning", "/administracion/cuenta/cambiar_usuario");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/cuenta/cambiar_password")
    public ModelAndView FormCambiandoPassword(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            CambiarPassword cambiar_password = new CambiarPassword();
            String usuario = funcion.get_username_cookie(request);
            ModelAndView model = new ModelAndView("FormCambiarPassword");
            model.addObject("CambiarPassword", cambiar_password);
            model.addObject("usuario", usuario);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/cuenta/cambiar_password", method = RequestMethod.POST)
    public ModelAndView FormCambiarPassword(@ModelAttribute("CambiarPassword") CambiarPassword cambiar_password, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario = cambiar_password.getNombre_usuario();
            String nuevo_password = funcion.md5_encode(cambiar_password.getNuevo_password());
            String password = funcion.md5_encode(cambiar_password.getPassword());
            if (!"".equals(usuario) && !"".equals(nuevo_password) && !"".equals(password)) {
                if (usuarioDAO.ingreso_usuario(usuario, password)) {
                    if (usuarioDAO.cambiar_password(usuario, nuevo_password)) {
                        Mensaje mensaje = new Mensaje("Cambiar Password", "El password ha sido cambiado exitosamente , reinicie la aplicacion", "success", "Login/LogOut");
                        ModelAndView model = new ModelAndView("Redireccion");
                        model.addObject("mensaje", mensaje);
                        return model;
                    } else {
                        Mensaje mensaje = new Mensaje("Cambiar Password", "Ha ocurrido un error en la base de datos", "warning", "/administracion/cuenta/cambiar_password");
                        ModelAndView model = new ModelAndView("Redireccion");
                        model.addObject("mensaje", mensaje);
                        return model;
                    }
                } else {
                    Mensaje mensaje = new Mensaje("Cambiar Password", "Login Incorrecto", "warning", "/administracion/cuenta/cambiar_password");
                    ModelAndView model = new ModelAndView("Redireccion");
                    model.addObject("mensaje", mensaje);
                    return model;
                }
            } else {
                Mensaje mensaje = new Mensaje("Cambiar Password", "Faltan datos", "warning", "/administracion/cuenta/cambiar_password");
                ModelAndView model = new ModelAndView("Redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

}
