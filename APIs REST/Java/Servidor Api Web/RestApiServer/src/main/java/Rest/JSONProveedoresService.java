// Written by Ismael Heredia in the year 2017
package Rest;

import Controlador.AccesoDatos;
import Funciones.Funciones;
import Modelo.Proveedor;
import java.util.ArrayList;
import java.util.List;
import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.GenericEntity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

@Path("/json/proveedores")
public class JSONProveedoresService {

    AccesoDatos datos = new AccesoDatos();
    Funciones funcion = new Funciones();

    @GET
    @Path("/")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getProveedoresInJSON() {
        List<Proveedor> listaProveedores = new ArrayList<Proveedor>();
        listaProveedores = datos.listarProveedoresEnTabla("");
        GenericEntity<List<Proveedor>> list = new GenericEntity<List<Proveedor>>(listaProveedores) {
        };
        return Response.ok(list).build();
    }

    @GET
    @Path("/{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Proveedor getProveedorInJSON(@PathParam("id") int id) {
        Proveedor proveedor = datos.listarProveedorEnTabla(id);
        return proveedor;
    }

    @POST
    @Path("/")
    @Consumes(MediaType.APPLICATION_JSON)
    public Response createProveeedorInJSON(Proveedor p) {
        AccesoDatos datos = new AccesoDatos();
        String mensaje = "";
        boolean success = false;
        String sql = "insert into proveedores(nombre_empresa,direccion,telefono,fecha_registro_proveedor) values('" + p.getNombre_empresa() + "','" + p.getDireccion() + "'," + p.getTelefono() + ",'" + p.getFecha_registro() + "')";
        if (datos.comprobar_existencia_proveedor_crear(p.getNombre_empresa())) {
            success = false;
            mensaje = "El proveedor " + p.getNombre_empresa() + " ya existe";
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
    public Response putProveedorInJSON(@PathParam("id") int id, Proveedor p) {
        AccesoDatos datos = new AccesoDatos();
        String mensaje = "";
        boolean success = false;
        String sql = "update proveedores set nombre_empresa='" + p.getNombre_empresa() + "',direccion='" + p.getDireccion() + "',telefono=" + p.getTelefono() + " where id_proveedor=" + id;
        if (datos.comprobar_existencia_proveedor_editar(p.getId_proveedor(), p.getNombre_empresa())) {
            success = false;
            mensaje = "El proveedor " + p.getNombre_empresa() + " ya existe";
        } else {
            if (datos.cargarConsulta(sql)) {
                success = true;
                mensaje = "Registro actualizado";
            } else {
                success = false;
                mensaje = "Ha ocurrido un error en la base de datos";
            }
        }
        String resultado = funcion.generarRespuesta(success, mensaje);
        return Response.status(201).entity(resultado).build();
    }

    @DELETE
    @Path("/{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Response delProveedorInJSON(@PathParam("id") int id) {
        AccesoDatos datos = new AccesoDatos();
        String mensaje = "";
        boolean success = false;
        String sql = "delete from proveedores where id_proveedor=" + id;
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
