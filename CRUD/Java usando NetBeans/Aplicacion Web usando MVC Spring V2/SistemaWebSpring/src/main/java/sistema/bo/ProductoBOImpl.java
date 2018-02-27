// Written by Ismael Heredia in the year 2017
package sistema.bo;

import java.util.ArrayList;
import sistema.bo.ProductoBO;
import sistema.dao.ProductoDAO;
import sistema.models.Producto;

public class ProductoBOImpl implements ProductoBO {

    ProductoDAO productoDAO;

    public void setProductoDAO(ProductoDAO productoDAO) {
        this.productoDAO = productoDAO;
    }

    public ArrayList listProductos(String patron) {
        return productoDAO.listProductos(patron);
    }

    public Producto findByProductoId(int id_to_load) {
        return productoDAO.findByProductoId(id_to_load);
    }

    public boolean insert(Producto producto) {
        return productoDAO.insert(producto);
    }

    public boolean update(Producto producto) {
        return productoDAO.update(producto);
    }

    public boolean delete(Producto producto) {
        return productoDAO.delete(producto);
    }

    public boolean check_exists_producto_new(String nombre) {
        return productoDAO.check_exists_producto_new(nombre);
    }

    public boolean check_exists_producto_edit(int id, String nombre) {
        return productoDAO.check_exists_producto_edit(id, nombre);
    }

}
