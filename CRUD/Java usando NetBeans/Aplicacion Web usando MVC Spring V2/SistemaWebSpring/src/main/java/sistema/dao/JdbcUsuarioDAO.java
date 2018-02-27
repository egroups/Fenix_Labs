// Written by Ismael Heredia in the year 2017
package sistema.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import javax.sql.DataSource;
import sistema.models.TipoUsuario;
import sistema.models.AsignarUsuario;
import sistema.models.Usuario;

public class JdbcUsuarioDAO implements UsuarioDAO {

    private DataSource dataSource;

    public void setDataSource(DataSource dataSource) {
        this.dataSource = dataSource;
    }

    public boolean login_check(String username, String password) {
        boolean respuesta = false;
        String sql = "SELECT id FROM usuarios WHERE nombre = ? AND clave = ?";
        int cantidad = 0;
        try {
            Connection conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, username);
            ps.setString(2, password);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                cantidad++;
            }
            if (cantidad >= 1) {
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

    public boolean is_admin(String username) {
        boolean respuesta = false;
        try {
            Connection conn = dataSource.getConnection();
            String sql = "SELECT id_tipo FROM usuarios WHERE nombre = ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, username);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                int id_tipo = rs.getInt(1);
                if (id_tipo == 1) {
                    respuesta = true;
                } else {
                    respuesta = false;
                }
            }
            conn.close();
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        return respuesta;
    }

    public ArrayList listUsuarios(String patron) {
        ArrayList listaUsuarios = new ArrayList();
        try {
            Connection conn = dataSource.getConnection();
            String sql = "SELECT * FROM usuarios WHERE nombre LIKE ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, "%" + patron + "%");
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                int id = rs.getInt(1);
                String nombre = rs.getString(2);
                String clave = rs.getString(3);
                int id_tipo = rs.getInt(4);
                String fecha_registro = rs.getString(5);
                Pattern regex1 = null;
                Matcher regex2 = null;
                regex1 = Pattern.compile(patron);
                regex2 = regex1.matcher(nombre);
                if (regex2.find()) {
                    AsignarUsuario u = new AsignarUsuario(id, nombre, clave, id_tipo, fecha_registro);
                    listaUsuarios.add(u);
                }
            }
            rs.close();
            ps.close();

            for (int i = 0; i < listaUsuarios.size(); i++) {
                AsignarUsuario usuario = (AsignarUsuario) listaUsuarios.get(i);
                sql = "SELECT * FROM tipos_usuarios WHERE id = ?";
                ps = conn.prepareStatement(sql);
                ps.setInt(1, usuario.getId_tipo());
                rs = ps.executeQuery();
                while (rs.next()) {
                    int id = rs.getInt(1);
                    String nombre = rs.getString(2);
                    TipoUsuario tipo = new TipoUsuario(id, nombre);
                    usuario.setTipo(tipo);
                }
            }

            conn.close();
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        return listaUsuarios;
    }

    public Usuario findByUsuarioId(int id_to_load) {
        Usuario usuario = null;
        try {
            Connection conn = dataSource.getConnection();
            Statement st = conn.createStatement();
            String sql = "SELECT * FROM usuarios WHERE id = ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setInt(1, id_to_load);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                int id = rs.getInt(1);
                String nombre = rs.getString(2);
                String clave = rs.getString(3);
                int id_tipo = rs.getInt(4);
                String fecha_registro = rs.getString(5);
                usuario = new Usuario(id, nombre, clave, id_tipo, fecha_registro);
            }
            rs.close();
            ps.close();

            sql = "SELECT * FROM tipos_usuarios WHERE id = ?";
            ps = conn.prepareStatement(sql);
            ps.setInt(1, usuario.getId_tipo());
            rs = ps.executeQuery();
            if (rs.next()) {
                int id = rs.getInt(1);
                String nombre = rs.getString(2);
                TipoUsuario tipo = new TipoUsuario(id, nombre);
                usuario.setTipo(tipo);
            }

            conn.close();
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        return usuario;
    }

    public boolean insert(Usuario usuario) {
        boolean respuesta = false;
        String sql = "INSERT INTO usuarios(nombre,clave,id_tipo,fecha_registro) VALUES(?,?,?,?)";
        try {
            Connection conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, usuario.getNombre());
            ps.setString(2, usuario.getClave());
            ps.setInt(3, usuario.getId_tipo());
            ps.setString(4, usuario.getFecha_registro());
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

    public boolean update(AsignarUsuario usuario) {
        boolean respuesta = false;
        String sql = "UPDATE usuarios SET id_tipo = ? WHERE id = ?";
        try {
            Connection conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setInt(1, usuario.getId_tipo());
            ps.setInt(2, usuario.getId());
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

    public boolean delete(Usuario usuario) {
        boolean respuesta = false;
        String sql = "delete from usuarios where id = ?";
        try {
            Connection conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setInt(1, usuario.getId());
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

    public boolean change_username(String usuario, String nuevo_usuario) {
        boolean respuesta = false;
        String sql = "UPDATE usuarios SET nombre = ? WHERE nombre = ?";
        try {
            Connection conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, nuevo_usuario);
            ps.setString(2, usuario);
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

    public boolean change_password(String usuario, String nueva_clave) {
        boolean respuesta = false;
        String sql = "UPDATE usuarios SET clave = ? WHERE nombre = ?";
        Connection conn = null;
        try {
            conn = dataSource.getConnection();
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, nueva_clave);
            ps.setString(2, usuario);
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

    public boolean check_exists_usuario_new(String nombre) {
        boolean respuesta = false;
        try {
            String sql = "SELECT * FROM usuarios WHERE nombre LIKE ?";
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

    public boolean check_exists_usuario_edit(int id, String nombre) {
        boolean respuesta = false;
        try {
            String sql = "SELECT * FROM usuarios WHERE nombre LIKE ? AND id != ?";
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
