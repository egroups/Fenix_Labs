// Written by Ismael Heredia in the year 2017
package sistema.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import javax.sql.DataSource;
import sistema.models.Producto;
import sistema.models.Proveedor;

public class JdbcProductoDAO implements ProductoDAO {

    private DataSource dataSource;

    public void setDataSource(DataSource dataSource) {
        this.dataSource = dataSource;
    }

    public ArrayList listProductos(String patron) {
        ArrayList listaProductos = new ArrayList();
        try {
            Connection conn = dataSource.getConnection();
            String sql = "SELECT * FROM productos WHERE nombre LIKE ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, "%" + patron + "%");
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                int id = rs.getInt(1);
                String nombre = rs.getString(2);
                String descripcion = rs.getString(3);
                double precio = rs.getInt(4);
                int id_proveedor = rs.getInt(5);
                String fecha_registro = rs.getString(6);
                Pattern regex1 = null;
                Matcher regex2 = null;
                regex1 = Pattern.compile(patron);
                regex2 = regex1.matcher(nombre);
                if (regex2.find()) {
                    Producto p = new Producto(id, nombre, descripcion, precio, id_proveedor, fecha_registro);
                    listaProductos.add(p);
                }
            }

            rs.close();
            ps.close();

            for (int i = 0; i < listaProductos.size(); i++) {
                Producto producto = (Producto) listaProductos.get(i);
                sql = "SELECT * FROM proveedores WHERE id = ?";
                ps = conn.prepareStatement(sql);
                ps.setInt(1, producto.getId_proveedor());
                rs = ps.executeQuery();
                while (rs.next()) {
                    int id = rs.getInt(1);
                    String nombre = rs.getString(2);
                    String direccion = rs.getString(3);
                    int telefono = rs.getInt(4);
                    String fecha_registro = rs.getString(5);
                    Proveedor proveedor = new Proveedor(id, nombre, direccion, telefono, fecha_registro);
                    producto.setProveedor(proveedor);
                }
            }

            conn.close();
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        return listaProductos;
    }

    public Producto findByProductoId(int id_to_load) {
        Producto producto = null;
        try {
            Connection conn = dataSource.getConnection();
            String sql = "SELECT * FROM productos WHERE id = ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setInt(1, id_to_load);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                int id = rs.getInt(1);
                String nombre = rs.getString(2);
                String descripcion = rs.getString(3);
                double precio = rs.getInt(4);
                int id_proveedor = rs.getInt(5);
                String fecha_registro = rs.getString(6);
                producto = new Producto(id, nombre, descripcion, precio, id_proveedor, fecha_registro);
            }

            rs.close();
            ps.close();

            sql = "SELECT * FROM proveedores WHERE id = ?";
            ps = conn.prepareStatement(sql);
            ps.setInt(1, producto.getId_proveedor());
            rs = ps.executeQuery();
            if (rs.next()) {
                int id = rs.getInt(1);
                String nombre = rs.getString(2);
                String direccion = rs.getString(3);
                int telefono = rs.getInt(4);
                String fecha_registro = rs.getString(5);
                Proveedor proveedor = new Proveedor(id, nombre, direccion, telefono, fecha_registro);
                producto.setProveedor(proveedor);
            }

            conn.close();

        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        return producto;
    }

    public boolean insert(Producto producto) {
        boolean respuesta = false;
        String sql = "INSERT INTO productos(nombre,descripcion,precio,id_proveedor,fecha_registro) VALUES(?,?,?,?,?)";
        try {
            Connection conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, producto.getNombre());
            ps.setString(2, producto.getDescripcion());
            ps.setDouble(3, producto.getPrecio());
            ps.setInt(4, producto.getId_proveedor());
            ps.setString(5, producto.getFecha_registro());
            int cantidad = ps.executeUpdate();
            if (cantidad > 0) {
                respuesta = true;
            } else {
                respuesta = false;
            }
            ps.close();
            conn.close();

        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        return respuesta;
    }

    public boolean update(Producto producto) {
        boolean respuesta = false;
        String sql = "UPDATE productos SET nombre = ?, descripcion = ?, precio = ?, id_proveedor = ? WHERE id = ?";
        try {
            Connection conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, producto.getNombre());
            ps.setString(2, producto.getDescripcion());
            ps.setDouble(3, producto.getPrecio());
            ps.setInt(4, producto.getId_proveedor());
            ps.setInt(5, producto.getId());
            int cantidad = ps.executeUpdate();
            if (cantidad > 0) {
                respuesta = true;
            } else {
                respuesta = false;
            }
            ps.close();
            conn.close();

        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        return respuesta;
    }

    public boolean delete(Producto producto) {
        boolean respuesta = false;
        String sql = "DELETE FROM productos WHERE id = ?";
        try {
            Connection conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setInt(1, producto.getId());
            int cantidad = ps.executeUpdate();
            if (cantidad > 0) {
                respuesta = true;
            } else {
                respuesta = false;
            }
            conn.close();
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        return respuesta;
    }

    public boolean check_exists_producto_new(String nombre) {
        boolean respuesta = false;
        try {
            String sql = "SELECT * FROM productos WHERE nombre LIKE ?";
            int cantidad = 0;
            Connection conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, nombre);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                cantidad++;
            }
            if (cantidad >= 1) {
                respuesta = true;
            } else {
                respuesta = false;
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        return respuesta;
    }

    public boolean check_exists_producto_edit(int id, String nombre) {
        boolean respuesta = false;
        try {
            String sql = "SELECT * FROM productos WHERE nombre LIKE ? AND id != ?";
            int cantidad = 0;
            Connection conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, nombre);
            ps.setInt(2, id);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                cantidad++;
            }
            if (cantidad >= 1) {
                respuesta = true;
            } else {
                respuesta = false;
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
        return respuesta;
    }

}
