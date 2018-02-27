// Written by Ismael Heredia in the year 2017
package sistema.dao;

import java.util.ArrayList;
import sistema.models.Proveedor;

public interface ProveedorDAO {

    public ArrayList listProveedores(String patron);

    public Proveedor findByProveedorId(int id_to_load);

    public boolean insert(Proveedor proveedor);

    public boolean update(Proveedor proveedor);

    public boolean delete(Proveedor proveedor);

    public boolean check_exists_proveedor_new(String nombre);

    public boolean check_exists_proveedor_edit(int id, String nombre);

}
