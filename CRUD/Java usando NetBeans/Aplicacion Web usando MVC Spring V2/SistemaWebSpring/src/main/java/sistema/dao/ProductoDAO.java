// Written by Ismael Heredia in the year 2017
package sistema.dao;

import java.util.ArrayList;
import sistema.models.Producto;

public interface ProductoDAO {

    public ArrayList listProductos(String patron);

    public Producto findByProductoId(int id_to_load);

    public boolean insert(Producto producto);

    public boolean update(Producto producto);

    public boolean delete(Producto producto);

    public boolean check_exists_producto_new(String nombre);

    public boolean check_exists_producto_edit(int id, String nombre);

}
