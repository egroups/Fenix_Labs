// Written by Ismael Heredia in the year 2017
package sistema.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import javax.sql.DataSource;
import sistema.models.Proveedor;

public class JdbcProveedorDAO implements ProveedorDAO {

    private DataSource dataSource;

    public void setDataSource(DataSource dataSource) {
        this.dataSource = dataSource;
    }

    public ArrayList listProveedores(String patron) {
        ArrayList listaProveedores = new ArrayList();
        try {
            Connection conn = dataSource.getConnection();
            String sql = "SELECT * FROM proveedores WHERE nombre LIKE ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, "%" + patron + "%");
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                int id = rs.getInt(1);
                String nombre = rs.getString(2);
                String direccion = rs.getString(3);
                int telefono = rs.getInt(4);
                String fecha_registro = rs.getString(5);
                Pattern regex1 = null;
                Matcher regex2 = null;
                regex1 = Pattern.compile(patron);
                regex2 = regex1.matcher(nombre);
                if (regex2.find()) {
                    Proveedor p = new Proveedor(id, nombre, direccion, telefono, fecha_registro);
                    listaProveedores.add(p);
                }
            }
            conn.close();
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        return listaProveedores;
    }

    public Proveedor findByProveedorId(int id_to_load) {
        Proveedor proveedor = null;
        try {
            Connection conn = dataSource.getConnection();
            String sql = "SELECT * FROM proveedores WHERE id = ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setInt(1, id_to_load);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                int id = rs.getInt(1);
                String nombre = rs.getString(2);
                String direccion = rs.getString(3);
                int telefono = rs.getInt(4);
                String fecha_registro = rs.getString(5);
                proveedor = new Proveedor(id, nombre, direccion, telefono, fecha_registro);
            }
            conn.close();
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        return proveedor;
    }

    public boolean insert(Proveedor proveedor) {
        boolean respuesta = false;
        String sql = "INSERT INTO proveedores(nombre,direccion,telefono,fecha_registro) VALUES(?,?,?,?)";
        try {
            Connection conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, proveedor.getNombre());
            ps.setString(2, proveedor.getDireccion());
            ps.setInt(3, proveedor.getTelefono());
            ps.setString(4, proveedor.getFecha_registro());
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

    public boolean update(Proveedor proveedor) {
        boolean respuesta = false;
        String sql = "UPDATE proveedores SET nombre = ?, direccion = ?, telefono = ? WHERE id = ?";
        try {
            Connection conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, proveedor.getNombre());
            ps.setString(2, proveedor.getDireccion());
            ps.setInt(3, proveedor.getTelefono());
            ps.setInt(4, proveedor.getId());
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

    public boolean delete(Proveedor proveedor) {
        boolean respuesta = false;
        String sql = "delete from proveedores where id = ?";
        try {
            Connection conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setInt(1, proveedor.getId());
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

    public boolean check_exists_proveedor_new(String nombre) {
        boolean respuesta = false;
        try {
            String sql = "SELECT * FROM proveedores WHERE nombre LIKE ?";
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

    public boolean check_exists_proveedor_edit(int id, String nombre) {
        boolean respuesta = false;
        try {
            String sql = "SELECT * FROM proveedores WHERE nombre LIKE ? AND id != ?";
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
