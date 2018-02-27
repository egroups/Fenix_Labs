// Written by Ismael Heredia in the year 2017
package sistema.controllers;

import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.validation.Valid;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;
import sistema.bo.UsuarioBO;
import sistema.functions.Funciones;
import sistema.models.Ingreso;
import sistema.models.Mensaje;

@Controller
public class LoginController {

    ApplicationContext context
            = new ClassPathXmlApplicationContext("Spring-Module.xml");

    UsuarioBO usuarioBO = (UsuarioBO) context.getBean("UsuarioBO");

    Funciones funcion = new Funciones();

    @RequestMapping("/login")
    public ModelAndView LoginForm(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            return new ModelAndView("redirect:/administracion");
        } else {
            Ingreso ingreso = new Ingreso();
            ModelAndView model = new ModelAndView("login/index");
            model.addObject("Ingreso", ingreso);
            return model;
        }
    }

    @RequestMapping(value = "/IngresoUsuario", method = RequestMethod.POST)
    public ModelAndView IngresoUsuario(@Valid Ingreso ingreso, BindingResult result, HttpServletResponse response, HttpServletRequest request) {

        if (result.hasErrors()) {
            Mensaje mensaje = new Mensaje("Iniciar Sesión", "Faltan datos", "warning", "login");
            ModelAndView model = new ModelAndView("mensajes/redireccion");
            model.addObject("mensaje", mensaje);
            return model;
        } else {
            String usuario = ingreso.getUsuario();
            String clave = funcion.md5_encode(ingreso.getClave());
            if (usuarioBO.login_check(usuario, clave)) {

                String contenido = "";

                if (usuarioBO.is_admin(usuario)) {
                    contenido = "Bienvenido a la administración administrador " + usuario;
                } else {
                    contenido = "Bienvenido a la administración usuario " + usuario;
                }

                Cookie cookie = new Cookie("user_login", funcion.base64_encode(usuario + '-' + clave));
                response.addCookie(cookie);

                Mensaje mensaje = new Mensaje("Iniciar Sesión", contenido, "success", "administracion");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            } else {
                Mensaje mensaje = new Mensaje("Iniciar Sesión", "Login Incorrecto", "warning", "login");
                ModelAndView model = new ModelAndView("mensajes/redireccion");
                model.addObject("mensaje", mensaje);
                return model;
            }
        }
    }

    @RequestMapping("/IngresoUsuario")
    public ModelAndView IngresoUsuarioGET(HttpServletRequest request) {
        return new ModelAndView("redirect:/login");
    }

    @RequestMapping(value = "/Login/LogOut", method = RequestMethod.GET)
    public ModelAndView LogOutForm(HttpServletRequest request, HttpServletResponse response) {
        if (funcion.valid_cookie(request)) {
            for (Cookie cookie : request.getCookies()) {
                if ("user_login".equals(cookie.getName())) {
                    cookie.setValue(null);
                    cookie.setMaxAge(0);
                    cookie.setPath(request.getContextPath());
                    response.addCookie(cookie);
                }
            }
            Mensaje mensaje = new Mensaje("Cerrar Sesión", "La sesión ha sido cerrada", "success", "login");
            ModelAndView model = new ModelAndView("mensajes/redireccion");
            model.addObject("mensaje", mensaje);
            return model;
        } else {
            Mensaje mensaje = new Mensaje("Cerrar Sesión", "No has iniciado sesión", "warning", "login");
            ModelAndView model = new ModelAndView("mensajes/redireccion");
            model.addObject("mensaje", mensaje);
            return model;
        }
    }
}
