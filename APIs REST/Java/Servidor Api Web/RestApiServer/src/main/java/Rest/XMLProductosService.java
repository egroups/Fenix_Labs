// Written by Ismael Heredia in the year 2017
package Rest;

import Controlador.AccesoDatos;
import Funciones.Funciones;
import Modelo.Producto;
import java.util.ArrayList;
import java.util.List;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

@Path("/xml/productos")
public class XMLProductosService {

    AccesoDatos datos = new AccesoDatos();
    Funciones funcion = new Funciones();

    @GET
    @Path("/")
    @Produces(MediaType.APPLICATION_XML)
    public List<Producto> getProductosInXML() {
        List<Producto> listaProductos = new ArrayList<Producto>();
        listaProductos = datos.listarProductosEnTabla("");
        return listaProductos;
    }

    @GET
    @Path("/{id}")
    @Produces(MediaType.APPLICATION_XML)
    public Producto getProductoInXML(@PathParam("id") int id) {
        Producto producto = datos.listarProductoEnTabla(id);
        return producto;

    }

}
