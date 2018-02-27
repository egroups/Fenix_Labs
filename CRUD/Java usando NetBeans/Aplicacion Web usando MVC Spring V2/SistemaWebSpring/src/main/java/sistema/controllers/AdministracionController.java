// Written by Ismael Heredia in the year 2017
package sistema.controllers;

import javax.servlet.http.HttpServletRequest;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;
import sistema.bo.UsuarioBO;
import sistema.functions.Funciones;

@Controller
public class AdministracionController {

    ApplicationContext context
            = new ClassPathXmlApplicationContext("Spring-Module.xml");

    UsuarioBO usuarioBO = (UsuarioBO) context.getBean("UsuarioBO");

    Funciones funcion = new Funciones();

    @RequestMapping("/administracion")
    public ModelAndView AdministracionForm(HttpServletRequest request) {

        if (funcion.valid_cookie(request)) {

            String usuario_logeado = funcion.get_username_cookie(request);
            String tipo_usuario = "";
            if (usuarioBO.is_admin(usuario_logeado)) {
                tipo_usuario = "Administrador";
            } else {
                tipo_usuario = "Usuario";
            }

            ModelAndView model = new ModelAndView("administracion/index");
            model.addObject("usuario_logeado", usuario_logeado);
            model.addObject("tipo", tipo_usuario);
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

}
