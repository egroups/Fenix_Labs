// Written by Ismael Heredia in the year 2017
package sistema.controllers;

import javax.servlet.http.HttpServletRequest;
import javax.validation.Valid;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;
import sistema.bo.UsuarioBO;
import sistema.functions.Funciones;
import sistema.models.CambiarUsuario;
import sistema.models.CambiarClave;
import sistema.models.Mensaje;

@Controller
public class CuentaController {

    ApplicationContext context
            = new ClassPathXmlApplicationContext("Spring-Module.xml");

    UsuarioBO usuarioBO = (UsuarioBO) context.getBean("UsuarioBO");

    Funciones funcion = new Funciones();

    @RequestMapping("/administracion/cuenta/cambiar_usuario")
    public ModelAndView FormCambiandoUsuario(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario_logeado = funcion.get_username_cookie(request);
            CambiarUsuario cambiar_usuario = new CambiarUsuario();
            String usuario = funcion.get_username_cookie(request);
            ModelAndView model = new ModelAndView("cuenta/cambiar_usuario");
            model.addObject("usuario_logeado", usuario_logeado);
            model.addObject("CambiarUsuario", cambiar_usuario);
            model.addObject("usuario", usuario);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/cuenta/cambiar_usuario", method = RequestMethod.POST)
    public ModelAndView FormCambiarUsuario(@Valid CambiarUsuario cambiar_usuario, BindingResult result, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (result.hasErrors()) {
                Mensaje mensaje = new Mensaje("Cambiar Usuario", "Faltan datos", "warning", "/administracion/cuenta/cambiar_usuario");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            } else {
                String nombre = cambiar_usuario.getNombre();
                String nuevo_nombre = cambiar_usuario.getNuevo_nombre();
                String clave = funcion.md5_encode(cambiar_usuario.getClave());
                if (usuarioBO.login_check(nombre, clave)) {
                    if (usuarioBO.change_username(nombre, nuevo_nombre)) {
                        Mensaje mensaje = new Mensaje("Cambiar Usuario", "El usuario ha sido cambiado exitosamente , reinicie la aplicación", "success", "Login/LogOut");
                        ModelAndView model = new ModelAndView("mensajes/redireccion");
                        model.addObject("mensaje", mensaje);
                        return model;
                    } else {
                        Mensaje mensaje = new Mensaje("Cambiar Usuario", "Ha ocurrido un error en la base de datos", "warning", "/administracion/cuenta/cambiar_usuario");
                        ModelAndView model = new ModelAndView("mensajes/redireccion");
                        model.addObject("mensaje", mensaje);
                        return model;
                    }
                } else {
                    Mensaje mensaje = new Mensaje("Cambiar Usuario", "Login Incorrecto", "warning", "/administracion/cuenta/cambiar_usuario");
                    ModelAndView model = new ModelAndView("mensajes/redireccion");
                    model.addObject("mensaje", mensaje);
                    return model;
                }
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/cuenta/cambiar_clave")
    public ModelAndView FormCambiandoClave(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario_logeado = funcion.get_username_cookie(request);
            CambiarClave cambiar_clave = new CambiarClave();
            String usuario = funcion.get_username_cookie(request);
            ModelAndView model = new ModelAndView("cuenta/cambiar_clave");
            model.addObject("usuario_logeado", usuario_logeado);
            model.addObject("CambiarClave", cambiar_clave);
            model.addObject("usuario", usuario);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping(value = "/administracion/cuenta/cambiar_clave", method = RequestMethod.POST)
    public ModelAndView FormCambiarClave(@Valid CambiarClave cambiar_clave, BindingResult result, HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            if (result.hasErrors()) {
                Mensaje mensaje = new Mensaje("Cambiar Clave", "Faltan datos", "warning", "/administracion/cuenta/cambiar_clave");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            } else {
                String usuario = cambiar_clave.getNombre();
                String nuevo_clave = funcion.md5_encode(cambiar_clave.getNueva_clave());
                String clave = funcion.md5_encode(cambiar_clave.getClave());
                if (usuarioBO.login_check(usuario, clave)) {
                    if (usuarioBO.change_password(usuario, nuevo_clave)) {
                        Mensaje mensaje = new Mensaje("Cambiar Clave", "La clave ha sido cambiada exitosamente , reinicie la aplicación", "success", "Login/LogOut");
                        ModelAndView model = new ModelAndView("mensajes/redireccion");
                        model.addObject("mensaje", mensaje);
                        return model;
                    } else {
                        Mensaje mensaje = new Mensaje("Cambiar Clave", "Ha ocurrido un error en la base de datos", "warning", "/administracion/cuenta/cambiar_clave");
                        ModelAndView model = new ModelAndView("mensajes/redireccion");
                        model.addObject("mensaje", mensaje);
                        return model;
                    }
                } else {
                    Mensaje mensaje = new Mensaje("Cambiar Clave", "Login Incorrecto", "warning", "/administracion/cuenta/cambiar_clave");
                    ModelAndView model = new ModelAndView("mensajes/redireccion");
                    model.addObject("mensaje", mensaje);
                    return model;
                }
            }
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

}
