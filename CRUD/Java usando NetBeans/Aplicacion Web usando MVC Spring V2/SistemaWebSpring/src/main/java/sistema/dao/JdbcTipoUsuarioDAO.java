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
import sistema.models.TipoUsuario;

public class JdbcTipoUsuarioDAO implements TipoUsuarioDAO {

    private DataSource dataSource;

    public void setDataSource(DataSource dataSource) {
        this.dataSource = dataSource;
    }
    
    public ArrayList listTipoUsuario(String patron) {
        ArrayList listaTipoUsuario = new ArrayList();
        try {
            Connection conn = dataSource.getConnection();
            String sql = "SELECT * FROM tipos_usuarios WHERE nombre LIKE ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, "%" + patron + "%");
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                int id = rs.getInt(1);
                String nombre = rs.getString(2);
                Pattern regex1 = null;
                Matcher regex2 = null;
                regex1 = Pattern.compile(patron);
                regex2 = regex1.matcher(nombre);
                if (regex2.find()) {
                    TipoUsuario tipoUsuario = new TipoUsuario(id,nombre);
                    listaTipoUsuario.add(tipoUsuario);
                }
            }
            conn.close();
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }

        return listaTipoUsuario;
    }
    
}