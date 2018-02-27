// Written by Ismael Heredia in the year 2016

package sistema.controllers;

import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;
import sistema.dao.UsuarioDAO;
import sistema.functions.Funciones;
import sistema.models.Ingreso;
import sistema.models.Mensaje;

@Controller
public class LoginController {

    ApplicationContext context
            = new ClassPathXmlApplicationContext("Spring-Module.xml");

    UsuarioDAO usuarioDAO = (UsuarioDAO) context.getBean("UsuarioDAO");

    Funciones funcion = new Funciones();

    @RequestMapping("/login")
    public ModelAndView LoginForm(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            return new ModelAndView("redirect:/administracion");
        } else {
            Ingreso ingreso = new Ingreso();
            ModelAndView model = new ModelAndView("Login");
            model.addObject("Ingreso", ingreso);
            return model;
        }
    }

    @RequestMapping(value = "/IngresoUsuario", method = RequestMethod.POST)
    public ModelAndView IngresoUsuario(@ModelAttribute("Ingreso") Ingreso ingreso, HttpServletResponse response, HttpServletRequest request) {
        String usuario = ingreso.getUsername();
        String password = funcion.md5_encode(ingreso.getPassword());

        Mensaje mensaje = null;
        ModelAndView model = null;

        if (usuarioDAO.ingreso_usuario(usuario, password)) {

            String msg = "";

            if (usuarioDAO.es_admin(usuario)) {
                msg = "Bienvenido a la administración administrador " + usuario;
            } else {
                msg = "Bienvenido a la administración usuario " + usuario;
            }

            Cookie cookie = new Cookie("user_login", funcion.base64_encode(usuario + '-' + password));
            response.addCookie(cookie);

            mensaje = new Mensaje("Iniciar Sesion", msg, "success", "administracion");
            model = new ModelAndView("Redireccion");
            model.addObject("mensaje", mensaje);
        } else {
            mensaje = new Mensaje("Iniciar Sesion", "Login Incorrecto", "warning", "login");
            model = new ModelAndView("Redireccion");
            model.addObject("mensaje", mensaje);
        }

        return model;

    }

    @RequestMapping(value = "/Login/LogOut", method = RequestMethod.GET)
    public ModelAndView LogOutForm(HttpServletRequest request, HttpServletResponse response) {
        Mensaje mensaje = null;
        ModelAndView model = null;
        if (funcion.valid_cookie(request)) {
            for (Cookie cookie : request.getCookies()) {
                if ("user_login".equals(cookie.getName())) {
                    cookie.setValue(null);
                    cookie.setMaxAge(0);
                    cookie.setPath(request.getContextPath());
                    response.addCookie(cookie);
                }
            }
            mensaje = new Mensaje("Cerrar Sesion", "La sesion ha sido cerrada", "success", "login");
            model = new ModelAndView("Redireccion");
            model.addObject("mensaje", mensaje);
        } else {
            mensaje = new Mensaje("Cerrar Sesion", "No has iniciado sesion", "warning", "login");
            model = new ModelAndView("Redireccion");
            model.addObject("mensaje", mensaje);
        }
        return model;
    }
}
