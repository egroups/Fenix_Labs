// Written by Ismael Heredia in the year 2017
package Rest;

import Controlador.AccesoDatos;
import Funciones.Funciones;
import Modelo.Usuario;
import java.util.ArrayList;
import java.util.List;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

@Path("/xml/usuarios")
public class XMLUsuariosService {

    AccesoDatos datos = new AccesoDatos();
    Funciones funcion = new Funciones();

    @GET
    @Path("/")
    @Produces(MediaType.APPLICATION_XML)
    public List<Usuario> getUsuariosInXML() {
        List<Usuario> listaUsuarios = new ArrayList<Usuario>();
        listaUsuarios = datos.listarUsuariosEnTabla("");
        return listaUsuarios;
    }

    @GET
    @Path("/{id}")
    @Produces(MediaType.APPLICATION_XML)
    public Usuario getUsuarioInXML(@PathParam("id") int id) {
        Usuario usuario = datos.listarUsuarioEnTabla(id);
        return usuario;
    }

}
