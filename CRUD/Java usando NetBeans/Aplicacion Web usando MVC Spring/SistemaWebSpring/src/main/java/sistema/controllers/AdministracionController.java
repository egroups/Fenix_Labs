// Written by Ismael Heredia in the year 2016

package sistema.controllers;

import java.util.ArrayList;
import java.util.List;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;
import sistema.dao.ProductoDAO;
import sistema.dao.ProveedorDAO;
import sistema.dao.UsuarioDAO;
import sistema.functions.Funciones;
import sistema.models.Buscador;
import sistema.models.Ingreso;
import sistema.models.Mensaje;
import sistema.models.Producto;

@Controller
public class AdministracionController {

    ApplicationContext context
            = new ClassPathXmlApplicationContext("Spring-Module.xml");

    UsuarioDAO usuarioDAO = (UsuarioDAO) context.getBean("UsuarioDAO");

    Funciones funcion = new Funciones();

    @RequestMapping("/administracion")
    public ModelAndView AdminForm(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            String usuario = funcion.get_username_cookie(request);
            String msg = "";

            if (usuarioDAO.es_admin(usuario)) {
                msg = "Bienvenido a la administración administrador " + usuario;
            } else {
                msg = "Bienvenido a la administración usuario " + usuario;
            }

            ModelAndView model = new ModelAndView("Administracion");
            model.addObject("bienvenida", msg);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

}
