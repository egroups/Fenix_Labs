// Written by Ismael Heredia in the year 2017
//SELECT prod.id,prod.nombre.prod.precio,prov.nombre AS proveedor,prod.fecha_registro FROM productos prod,proveedores prov WHERE prod.id_proveedor=prov.id
//SELECT prod.nombre,SUM(precio) AS precio FROM productos prod,proveedores prov where prod.id_proveedor=prov.id GROUP BY prod.nombre
//SELECT prov.nombre,count(prod.id_proveedor) AS cantidad FROM productos prod,proveedores prov WHERE prod.id_proveedor=prov.id GROUP BY prov.nombre
package sistema.controllers;

import javax.servlet.http.HttpServletRequest;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;
import sistema.functions.Funciones;

@Controller
public class EstadisticasController {

    Funciones funcion = new Funciones();

    @RequestMapping("/administracion/estadisticas")
    public ModelAndView FormEstadisticasListado(HttpServletRequest request) {
        if (funcion.valid_cookie(request)) {
            ModelAndView model = new ModelAndView("estadisticas/reporte");
            return model;
        } else {
            return new ModelAndView("redirect:/login");
        }
    }

}
