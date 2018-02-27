// Written by Ismael Heredia in the year 2017
package Rest;

import Controlador.AccesoDatos;
import Funciones.Funciones;
import Modelo.Proveedor;
import java.util.ArrayList;
import java.util.List;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

@Path("/xml/proveedores")
public class XMLProveedoresService {

    AccesoDatos datos = new AccesoDatos();
    Funciones funcion = new Funciones();

    @GET
    @Path("/")
    @Produces(MediaType.APPLICATION_XML)
    public List<Proveedor> getProveedoresInXML() {
        List<Proveedor> listaProveedores = new ArrayList<Proveedor>();
        listaProveedores = datos.listarProveedoresEnTabla("");
        return listaProveedores;
    }

    @GET
    @Path("/{id}")
    @Produces(MediaType.APPLICATION_XML)
    public Proveedor getProveedorInXML(@PathParam("id") int id) {
        Proveedor proveedor = datos.listarProveedorEnTabla(id);
        return proveedor;

    }

}
