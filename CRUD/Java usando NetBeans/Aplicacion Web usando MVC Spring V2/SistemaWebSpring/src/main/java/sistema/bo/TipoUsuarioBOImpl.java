// Written by Ismael Heredia in the year 2017
package sistema.bo;

import java.util.ArrayList;
import sistema.dao.TipoUsuarioDAO;

public class TipoUsuarioBOImpl implements TipoUsuarioBO {

    TipoUsuarioDAO tipoUsuarioDAO;

    public void setTipoUsuarioDAO(TipoUsuarioDAO tipoUsuarioDAO) {
        this.tipoUsuarioDAO = tipoUsuarioDAO;
    }
    
    public ArrayList listTipoUsuario(String patron) {
        return tipoUsuarioDAO.listTipoUsuario(patron);
    }
}
