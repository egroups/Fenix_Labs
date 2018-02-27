// Written by Ismael Heredia in the year 2017
package Rest;

import Controlador.AccesoDatos;
import Funciones.Funciones;
import Modelo.Usuario;
import java.util.ArrayList;
import java.util.List;
import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.PUT;
import javax.ws.rs.POST;
import javax.ws.rs.DELETE;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.GenericEntity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

@Path("/json/usuarios")
public class JSONUsuariosService {

    AccesoDatos datos = new AccesoDatos();
    Funciones funcion = new Funciones();

    @GET
    @Path("/")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getUsuariosInJSON() {
        List<Usuario> listaUsuarios = new ArrayList<Usuario>();
        listaUsuarios = datos.listarUsuariosEnTabla("");
        GenericEntity<List<Usuario>> list = new GenericEntity<List<Usuario>>(listaUsuarios) {
        };
        return Response.ok(list).build();
    }

    @GET
    @Path("/{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Usuario getUsuarioInJSON(@PathParam("id") int id) {
        Usuario usuario = datos.listarUsuarioEnTabla(id);
        return usuario;
    }

    @POST
    @Path("/")
    @Consumes(MediaType.APPLICATION_JSON)
    public Response createUsuarioInJSON(Usuario u) {
        AccesoDatos datos = new AccesoDatos();
        String mensaje = "";
        boolean success = false;
        String sql = "insert into usuarios(usuario,clave,tipo,fecha_registro) values('" + u.getNombre() + "','" + u.getPassword() + "'," + u.getTipo() + ",'" + u.getFecha_registro() + "')";
        if (datos.comprobar_existencia_usuario_crear(u.getNombre())) {
            success = false;
            mensaje = "El usuario " + u.getNombre() + " ya existe";
        } else {
            if (datos.cargarConsulta(sql)) {
                success = true;
                mensaje = "Registro agregado";
            } else {
                success = false;
                mensaje = "Ha ocurrido un error en la base de datos";
            }
        }
        String resultado = funcion.generarRespuesta(success, mensaje);
        return Response.status(201).entity(resultado).build();
    }

    @PUT
    @Path("/{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Response putUsuarioInJSON(@PathParam("id") int id, Usuario u) {
        AccesoDatos datos = new AccesoDatos();
        String mensaje = "";
        boolean success = false;
        String sql = "update usuarios set tipo=" + u.getTipo() + " where usuario='" + u.getNombre() + "'";
        if (datos.cargarConsulta(sql)) {
            success = true;
            mensaje = "Registro actualizado";
        } else {
            success = false;
            mensaje = "Ha ocurrido un error en la base de datos";
        }
        String resultado = funcion.generarRespuesta(success, mensaje);
        return Response.status(201).entity(resultado).build();
    }

    @DELETE
    @Path("/{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Response delUsuarioInJSON(@PathParam("id") int id) {
        AccesoDatos datos = new AccesoDatos();
        String mensaje = "";
        boolean success = false;
        String sql = "delete from usuarios where id_usuario=" + id;
        if (datos.cargarConsulta(sql)) {
            success = true;
            mensaje = "Registro borrado";
        } else {
            success = false;
            mensaje = "Ha ocurrido un error en la base de datos";
        }
        String resultado = funcion.generarRespuesta(success, mensaje);
        return Response.status(201).entity(resultado).build();
    }

}
