// Written by Ismael Heredia in the year 2016

package sistema.controllers;

import javax.servlet.http.HttpServletRequest;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;
import sistema.dao.UsuarioDAO;
import sistema.functions.Funciones;
import sistema.models.Ingreso;

@Controller
public class HomeController {

    ApplicationContext context
            = new ClassPathXmlApplicationContext("Spring-Module.xml");

    UsuarioDAO usuarioDAO = (UsuarioDAO) context.getBean("UsuarioDAO");

    Funciones funciones = new Funciones();

    @RequestMapping("/")
    public ModelAndView HomeForm(HttpServletRequest request) {
        if (funciones.valid_cookie(request)) {
            return new ModelAndView("redirect:/administracion");
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

}
