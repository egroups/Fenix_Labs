// Written by Ismael Heredia in the year 2017

package sistema.bo;

import java.util.ArrayList;
import sistema.bo.ProveedorBO;
import sistema.dao.ProveedorDAO;
import sistema.models.Proveedor;

public class ProveedorBOImpl implements ProveedorBO {

    ProveedorDAO proveedorDAO;
    
    public void setProveedorDAO(ProveedorDAO proveedorDAO) {
        this.proveedorDAO = proveedorDAO;
    }
    
    public ArrayList listProveedores(String patron) {
        return proveedorDAO.listProveedores(patron);
    }
    
    public Proveedor findByProveedorId(int id_to_load) {
        return proveedorDAO.findByProveedorId(id_to_load);
    }
    
    public boolean insert(Proveedor proveedor) {
        return proveedorDAO.insert(proveedor);
    }

    public boolean update(Proveedor proveedor) {
        return proveedorDAO.update(proveedor);
    }

    public boolean delete(Proveedor proveedor) {
        return proveedorDAO.delete(proveedor);
    }
    
    public boolean check_exists_proveedor_new(String nombre) {
        return proveedorDAO.check_exists_proveedor_new(nombre);
    }

    public boolean check_exists_proveedor_edit(int id, String nombre) {
        return proveedorDAO.check_exists_proveedor_edit(id,nombre);
    }

}
