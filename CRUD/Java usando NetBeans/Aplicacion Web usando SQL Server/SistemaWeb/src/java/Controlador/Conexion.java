// Written by Ismael Heredia in the year 2016

package Controlador;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;

import Modelo.Producto;
import Modelo.Proveedor;
import Modelo.Usuario;
import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Conexion {

    private Connection con;

    public void abrirConexion() {
        try {
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            con = DriverManager.getConnection("jdbc:sqlserver://localhost;databaseName=sistema", "admin", "123456");
            //con = DriverManager.getConnection("jdbc:sqlserver://localhost;integratedSecurity=true;databaseName=Producciones", "", "");
        } catch (Exception e) {
            System.out.println(e);
        }
    }

    public void cerrarConexion() {
        if (con != null) {
            try {
                con.close();
            } catch (Exception e) {
                //
            }
        }
    }
    
    public Connection retornarConexion() {
        return con;
    }

    public Integer ejecutarConsulta(String sql) {
        int cantidad = 0;
        try {
            abrirConexion();
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {
                cantidad++;
            }
            cerrarConexion();
        } catch (Exception e) {
            System.out.println(e);
        }
        return cantidad;
    }

    public boolean comprobar_existencia_producto_crear(String nombre_producto) {
        boolean respuesta = false;
        String sql = "select * from productos where nombre_producto like '" + nombre_producto + "'";
        if (ejecutarConsulta(sql) >= 1) {
            respuesta = true;
        } else {
            respuesta = false;
        }
        return respuesta;
    }

    public boolean comprobar_existencia_producto_editar(int id_producto, String nombre_producto) {
        boolean respuesta = false;
        String sql = "select * from productos where nombre_producto like '" + nombre_producto + "' and id_producto!=" + id_producto;
        if (ejecutarConsulta(sql) >= 1) {
            respuesta = true;
        } else {
            respuesta = false;
        }
        return respuesta;
    }

    public boolean comprobar_existencia_proveedor_crear(String nombre_empresa) {
        boolean respuesta = false;
        String sql = "select * from proveedores where nombre_empresa like '" + nombre_empresa + "'";
        if (ejecutarConsulta(sql) >= 1) {
            respuesta = true;
        } else {
            respuesta = false;
        }
        return respuesta;
    }

    public boolean comprobar_existencia_proveedor_editar(int id_proveedor, String nombre_empresa) {
        boolean respuesta = false;
        String sql = "select * from proveedores where nombre_empresa like '" + nombre_empresa + "' and id_proveedor!=" + id_proveedor;
        if (ejecutarConsulta(sql) >= 1) {
            respuesta = true;
        } else {
            respuesta = false;
        }
        return respuesta;
    }

    public boolean comprobar_existencia_usuario_crear(String nombre_usuario) {
        boolean respuesta = false;
        String sql = "select * from usuarios where usuario like '" + nombre_usuario + "'";
        if (ejecutarConsulta(sql) >= 1) {
            respuesta = true;
        } else {
            respuesta = false;
        }
        return respuesta;
    }

    public boolean comprobar_existencia_usuario_editar(String nombre_usuario) {
        boolean respuesta = false;
        String sql = "select * from usuarios where usuario like '" + nombre_usuario + "'";
        if (ejecutarConsulta(sql) >= 1) {
            respuesta = true;
        } else {
            respuesta = false;
        }
        return respuesta;
    }

    public boolean ingreso_usuario(String username, String password) {
        boolean respuesta = false;
        try {
            int cantidad = ejecutarConsulta("select id_usuario from usuarios where usuario='" + username + "' and clave='" + password + "'");
            if (cantidad >= 1) {
                respuesta = true;
            } else {
                respuesta = false;
            }
        } catch (Exception e) {
            System.out.println(e);
        }
        return respuesta;
    }

    public boolean es_admin(String username) {
        boolean respuesta = false;
        try {
            abrirConexion();
            Statement st = con.createStatement();
            String sql = "select tipo from usuarios where usuario='" + username + "'";
            ResultSet rs = st.executeQuery(sql);
            if (rs.next()) {
                int id = rs.getInt(1);
                if (id == 1) {
                    respuesta = true;
                } else {
                    respuesta = false;
                }
            }
            cerrarConexion();
        } catch (Exception e) {
            //
        }
        return respuesta;
    }

    public int cargar_id_nuevo_para_proveedor() {
        int id = 0;
        try {
            abrirConexion();
            Statement st = con.createStatement();
            String sql = "select max(id_proveedor) from proveedores";
            ResultSet rs = st.executeQuery(sql);
            if (rs.next()) {
                id = rs.getInt(1) + 1;
            }
            cerrarConexion();
        } catch (Exception e) {
            //
        }
        return id;
    }

    public int cargar_id_nuevo_para_producto() {
        int id = 0;
        try {
            abrirConexion();
            Statement st = con.createStatement();
            String sql = "select max(id_producto) from productos";
            ResultSet rs = st.executeQuery(sql);
            if (rs.next()) {
                id = rs.getInt(1) + 1;
            }
            cerrarConexion();
        } catch (Exception e) {
            //
        }
        return id;
    }

    public ArrayList listarProductosEnTabla(String patron) {
        ArrayList productos = new ArrayList();
        try {
            abrirConexion();
            Statement st = con.createStatement();
            String sql = "select id_producto,nombre_producto,descripcion,precio,id_proveedor,fecha_registro from productos";

            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {
                int id_producto = rs.getInt(1);
                String nombre_producto = rs.getString(2);
                String descripcion = rs.getString(3);
                double precio = rs.getDouble(4);
                int id_proveedor = rs.getInt(5);
                String fecha_registro = rs.getString(6);
                Pattern regex1 = null;
                Matcher regex2 = null;
                regex1 = Pattern.compile(patron);
                regex2 = regex1.matcher(nombre_producto);
                if (regex2.find()) {
                    Producto p = new Producto(id_producto, nombre_producto, descripcion, precio, fecha_registro, id_proveedor);
                    productos.add(p);
                }
            }
            cerrarConexion();
        } catch (Exception e) {
            //
        }
        return productos;
    }

    public Producto listarProductoEnTabla(int id_producto_load) {
        Producto producto = new Producto();
        try {
            abrirConexion();
            Statement st = con.createStatement();
            String sql = "select id_producto,nombre_producto,descripcion,precio,id_proveedor,fecha_registro from productos where id_producto=" + id_producto_load;

            ResultSet rs = st.executeQuery(sql);
            if (rs.next()) {
                int id_producto = rs.getInt(1);
                String nombre_producto = rs.getString(2);
                String descripcion = rs.getString(3);
                double precio = rs.getDouble(4);
                int id_proveedor = rs.getInt(5);
                String fecha_registro = rs.getString(6);
                producto.setId_producto(id_producto);
                producto.setNombre_producto(nombre_producto);
                producto.setDescripcion(descripcion);
                producto.setPrecio(precio);
                producto.setId_proveedor(id_proveedor);
                producto.setFecha_registro(fecha_registro);
            }
            cerrarConexion();
        } catch (Exception e) {
            //
        }
        return producto;
    }

    public ArrayList listarProveedoresEnTabla(String patron) {
        ArrayList proveedores = new ArrayList();
        try {
            abrirConexion();
            Statement st = con.createStatement();
            String sql = "select id_proveedor,nombre_empresa,direccion,telefono,fecha_registro_proveedor from proveedores";

            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {
                int id_proveedor = rs.getInt(1);
                String nombre_empresa = rs.getString(2);
                String direccion = rs.getString(3);
                int telefono = rs.getInt(4);
                String fecha_registro = rs.getString(5);
                Pattern regex1 = null;
                Matcher regex2 = null;
                regex1 = Pattern.compile(patron);
                regex2 = regex1.matcher(nombre_empresa);
                if (regex2.find()) {
                    Proveedor p = new Proveedor(id_proveedor, nombre_empresa, direccion, telefono, fecha_registro);
                    proveedores.add(p);
                }
            }
            cerrarConexion();
        } catch (Exception e) {
            System.out.println(e);
        }
        return proveedores;
    }

    public Proveedor listarProveedorEnTabla(int id_proveedor_to_load) {
        Proveedor proveedor = new Proveedor();
        try {
            abrirConexion();
            Statement st = con.createStatement();
            String sql = "select id_proveedor,nombre_empresa,direccion,telefono,fecha_registro_proveedor from proveedores where id_proveedor=" + id_proveedor_to_load;

            ResultSet rs = st.executeQuery(sql);
            if (rs.next()) {
                int id_proveedor = rs.getInt(1);
                String nombre_empresa = rs.getString(2);
                String direccion = rs.getString(3);
                int telefono = rs.getInt(4);
                String fecha_registro = rs.getString(5);

                proveedor.setId_proveedor(id_proveedor);
                proveedor.setNombre_empresa(nombre_empresa);
                proveedor.setDireccion(direccion);
                proveedor.setTelefono(telefono);
                proveedor.setFecha_registro(fecha_registro);
            }
            cerrarConexion();
        } catch (Exception e) {
            System.out.println(e);
        }
        return proveedor;
    }

    public ArrayList listarUsuariosEnTabla(String patron) {
        ArrayList usuarios = new ArrayList();
        try {
            abrirConexion();
            Statement st = con.createStatement();
            String sql = "select id_usuario,usuario,clave,tipo,fecha_registro from usuarios";

            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {
                int id_usuario = rs.getInt(1);
                String nombre = rs.getString(2);
                String password = rs.getString(3);
                int tipo = rs.getInt(4);
                String fecha_registro = rs.getString(5);
                Pattern regex1 = null;
                Matcher regex2 = null;
                regex1 = Pattern.compile(patron);
                regex2 = regex1.matcher(nombre);
                if (regex2.find()) {
                    Usuario u = new Usuario(id_usuario, nombre, password, tipo, fecha_registro);
                    usuarios.add(u);
                }
            }
            cerrarConexion();
        } catch (Exception e) {
            System.out.println(e);
        }
        return usuarios;
    }

    public boolean cargarConsulta(String consulta) {
        boolean respuesta = false;
        try {
            abrirConexion();
            Statement st = con.createStatement();
            int cantidad = st.executeUpdate(consulta);
            if (cantidad > 0) {
                respuesta = true;
            } else {
                respuesta = false;
            }
            cerrarConexion();
        } catch (Exception e) {
            //System.out.println(consulta);
            //System.out.println(e);
            respuesta = false;
        }
        return respuesta;
    }

    public Usuario listarUsuarioEnTabla(int id_usuario) {
        Usuario usuario = new Usuario();
        try {
            abrirConexion();
            Statement st = con.createStatement();
            String sql = "select id_usuario,usuario,clave,tipo,fecha_registro from usuarios where id_usuario=" + id_usuario;

            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {
                int id_usuario_load = rs.getInt(1);
                String nombre = rs.getString(2);
                String password = rs.getString(3);
                int tipo = rs.getInt(4);
                String fecha_registro = rs.getString(5);
                usuario.setId_usuario(id_usuario_load);
                usuario.setNombre(nombre);
                usuario.setPassword(password);
                usuario.setTipo(tipo);
                usuario.setFecha_registro(fecha_registro);
            }
            cerrarConexion();
        } catch (Exception e) {
            System.out.println(e);
        }
        return usuario;
    }

    public String cargarNombreProveedor(int id_proveedor) {
        String nombre_proveedor = "";
        try {
            abrirConexion();
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("select nombre_empresa from proveedores where id_proveedor='" + id_proveedor + "'");
            rs.next();
            nombre_proveedor = rs.getString(1);
            rs.close();
            cerrarConexion();
        } catch (Exception e) {
            //
        }
        return nombre_proveedor;
    }

    public int get_id_by_username(String nombre_usuario) {
        int id_usuario = 0;
        try {
            abrirConexion();
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("select id_usuario from usuarios where usuario like '" + nombre_usuario + "'");
            rs.next();
            id_usuario = rs.getInt(1);
            rs.close();
            cerrarConexion();
        } catch (Exception e) {
            //
        }
        return id_usuario;
    }
   
}