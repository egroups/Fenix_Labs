// Written by Ismael Heredia in the year 2017
package Rest;

import Controlador.AccesoDatos;
import Funciones.Funciones;
import Modelo.Producto;
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

@Path("/json/productos")
public class JSONProductosService {

    AccesoDatos datos = new AccesoDatos();
    Funciones funcion = new Funciones();

    @GET
    @Path("/")
    @Produces(MediaType.APPLICATION_JSON)
    public Response getProductosInJSON() {
        List<Producto> listaProductos = new ArrayList<Producto>();
        listaProductos = datos.listarProductosEnTabla("");
        GenericEntity<List<Producto>> list = new GenericEntity<List<Producto>>(listaProductos) {
        };
        return Response.ok(list).build();
    }

    @GET
    @Path("/{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Producto getProductoInJSON(@PathParam("id") int id) {
        Producto producto = datos.listarProductoEnTabla(id);
        return producto;
    }

    @POST
    @Path("/")
    @Consumes(MediaType.APPLICATION_JSON)
    public Response createProductoInJSON(Producto p) {
        AccesoDatos datos = new AccesoDatos();
        String mensaje = "";
        boolean success = false;
        String sql = "insert into productos(nombre_producto,descripcion,precio,id_proveedor,fecha_registro) values('" + p.getNombre_producto() + "','" + p.getDescripcion() + "'," + p.getPrecio() + "," + p.getId_proveedor() + ",'" + p.getFecha_registro() + "')";
        if (datos.comprobar_existencia_producto_crear(p.getNombre_producto())) {
            success = false;
            mensaje = "El producto " + p.getNombre_producto() + " ya existe";
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
    public Response putProductoInJSON(@PathParam("id") int id, Producto p) {
        AccesoDatos datos = new AccesoDatos();
        String mensaje = "";
        boolean success = false;
        String sql = "update productos set nombre_producto='" + p.getNombre_producto() + "',descripcion='" + p.getDescripcion() + "',precio=" + p.getPrecio() + ",id_proveedor=" + p.getId_proveedor() + " where id_producto=" + id;
        if (datos.comprobar_existencia_producto_editar(p.getId_producto(), p.getNombre_producto())) {
            success = false;
            mensaje = "El producto " + p.getNombre_producto() + " ya existe";
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
    public Response delProductoInJSON(@PathParam("id") int id) {
        AccesoDatos datos = new AccesoDatos();
        String mensaje = "";
        boolean success = false;
        String sql = "delete from productos where id_producto=" + id;
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
