// Written by Ismael Heredia in the year 2017
package sistema.bo;

import java.util.ArrayList;
import sistema.bo.UsuarioBO;
import sistema.dao.UsuarioDAO;
import sistema.models.AsignarUsuario;
import sistema.models.Usuario;

public class UsuarioBOImpl implements UsuarioBO {

    UsuarioDAO usuarioDAO;

    public void setUsuarioDAO(UsuarioDAO usuarioDAO) {
        this.usuarioDAO = usuarioDAO;
    }

    public ArrayList listUsuarios(String patron) {
        return usuarioDAO.listUsuarios(patron);
    }

    public Usuario findByUsuarioId(int id_to_load) {
        return usuarioDAO.findByUsuarioId(id_to_load);
    }

    public boolean insert(Usuario usuario) {
        return usuarioDAO.insert(usuario);
    }

    public boolean update(AsignarUsuario usuario) {
        return usuarioDAO.update(usuario);
    }

    public boolean delete(Usuario usuario) {
        return usuarioDAO.delete(usuario);
    }

    public boolean login_check(String username, String password) {
        return usuarioDAO.login_check(username, password);
    }

    public boolean is_admin(String username) {
        return usuarioDAO.is_admin(username);
    }

    public boolean check_exists_usuario_new(String nombre) {
        return usuarioDAO.check_exists_usuario_new(nombre);
    }

    public boolean check_exists_usuario_edit(int id, String nombre) {
        return usuarioDAO.check_exists_usuario_edit(id, nombre);
    }

    public boolean change_username(String usuario, String nuevo_usuario) {
        return usuarioDAO.change_username(usuario, nuevo_usuario);
    }

    public boolean change_password(String usuario, String nueva_clave) {
        return usuarioDAO.change_password(usuario, nueva_clave);
    }

}
