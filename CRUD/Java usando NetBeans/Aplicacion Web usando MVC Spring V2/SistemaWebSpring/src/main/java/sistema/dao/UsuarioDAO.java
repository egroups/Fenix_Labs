// Written by Ismael Heredia in the year 2017
package sistema.dao;

import java.util.ArrayList;
import sistema.models.AsignarUsuario;
import sistema.models.Usuario;

public interface UsuarioDAO {

    public ArrayList listUsuarios(String patron);

    public Usuario findByUsuarioId(int id_to_load);

    public boolean insert(Usuario usuario);

    public boolean update(AsignarUsuario usuario);

    public boolean delete(Usuario usuario);

    public boolean login_check(String username, String password);

    public boolean is_admin(String username);

    public boolean check_exists_usuario_new(String nombre);

    public boolean check_exists_usuario_edit(int id,String nombre);

    public boolean change_username(String usuario, String nuevo_usuario);

    public boolean change_password(String usuario, String nueva_clave);

}
