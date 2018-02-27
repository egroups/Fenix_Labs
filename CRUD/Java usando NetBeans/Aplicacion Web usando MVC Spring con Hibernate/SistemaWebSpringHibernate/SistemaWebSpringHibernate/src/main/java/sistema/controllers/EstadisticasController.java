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
public class EstadisticasController {

    Funciones funcion = new Funciones();

    @RequestMapping("/administracion/estadisticas/listado_productos")
    public ModelAndView FormEstadisticasListado(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            ModelAndView model = new ModelAndView("FormEstadisticasListado");
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/estadisticas/grafico_productos")
    public ModelAndView FormEstadisticasGraficoProductos(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            ModelAndView model = new ModelAndView("FormEstadisticasGraficoProductos");
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

    @RequestMapping("/administracion/estadisticas/grafico_proveedores")
    public ModelAndView FormEstadisticasGraficoProveedores(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            ModelAndView model = new ModelAndView("FormEstadisticasGraficoProveedores");
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

}
