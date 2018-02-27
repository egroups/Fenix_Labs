// Written by Ismael Heredia in the year 2016

package sistema.dao;

import java.util.ArrayList;
import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import sistema.models.ListaProductos;
import sistema.models.Producto;
import sistema.models.Proveedor;

public class ProductoDAOImpl implements ProductoDAO {

    private SessionFactory sessionFactory;

    public void setSessionFactory(SessionFactory sessionFactory) {
        this.sessionFactory = sessionFactory;
    }

    @Override
    public boolean insert(Producto producto) {
        boolean respuesta = false;
        try {
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            session.save(producto);
            session.getTransaction().commit();
            session.close();
            respuesta = true;
        } catch (HibernateException he) {
            respuesta = false;
        }
        return respuesta;
    }

    @Override
    public boolean update(Producto producto) {
        boolean respuesta = false;
        try {
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            session.update(producto);
            session.getTransaction().commit();
            session.close();
            respuesta = true;
        } catch (HibernateException he) {
            respuesta = false;
        }
        return respuesta;
    }

    @Override
    public boolean delete(Producto producto) {
        boolean respuesta = false;
        try {
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            session.delete(producto);
            session.getTransaction().commit();
            session.close();
            respuesta = true;
        } catch (HibernateException he) {
            respuesta = false;
        }
        return respuesta;
    }

    @Override
    public ArrayList listProductos(String patron) {
        Session session = this.sessionFactory.openSession();
        session.beginTransaction();
        Query q = session.createQuery("from Producto p where p.nombre_producto like :patron");
        q.setString("patron", "%" + patron + "%");
        ArrayList productos = (ArrayList) q.list();
        session.close();
        ArrayList lista = new ArrayList();
        for (int i = 0; i < productos.size(); i++) {
            Producto producto = (Producto) productos.get(i);
            int id_producto = producto.getId_producto();
            String nombre_producto = producto.getNombre_producto();
            String descripcion = producto.getDescripcion();
            int precio = producto.getPrecio();
            int id_proveedor = producto.getId_proveedor();
            String nombre_empresa = cargarNombreProveedor(producto.getId_proveedor());
            String fecha_registro = producto.getFecha_registro();
            ListaProductos prod = new ListaProductos(id_producto,nombre_producto,descripcion,precio,id_proveedor,nombre_empresa,fecha_registro);
            lista.add(prod);
        }
        return lista;
    }

    @Override
    public Producto findByProductoId(int id_producto_to_load) {
        Producto producto = new Producto();
        try {
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            producto = (Producto) session.get(Producto.class, id_producto_to_load);
            session.getTransaction().commit();
            session.close();
        } catch (HibernateException he) {
            //
        }
        return producto;
    }

    @Override
    public String cargarNombreProveedor(int id_proveedor_to_load) {
        String nombre_empresa = "";
        try {
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            Proveedor proveedor = (Proveedor) session.get(Proveedor.class, id_proveedor_to_load);
            nombre_empresa = proveedor.getNombre_empresa();
            session.getTransaction().commit();
            session.close();
        } catch (HibernateException he) {
            //
        }
        return nombre_empresa;
    }

    @Override
    public boolean comprobar_existencia_producto_crear(String nombre_producto) {
        boolean respuesta = false;
        Session session = this.sessionFactory.openSession();
        session.beginTransaction();
        Query q = session.createQuery("from Producto p where p.nombre_producto like :patron");
        q.setString("patron", "%" + nombre_producto + "%");
        ArrayList lista = (ArrayList) q.list();
        session.close();
        if (lista.size() >= 1) {
            respuesta = true;
        } else {
            respuesta = false;
        }
        return respuesta;
    }

    @Override
    public boolean comprobar_existencia_producto_editar(int id_producto, String nombre_producto) {
        boolean respuesta = false;
        Session session = this.sessionFactory.openSession();
        session.beginTransaction();
        Query q = session.createQuery("from Producto p where p.nombre_producto like :patron and p.id_producto!=" + id_producto);
        q.setString("patron", "%" + nombre_producto + "%");
        ArrayList lista = (ArrayList) q.list();
        session.close();
        if (lista.size() >= 1) {
            respuesta = true;
        } else {
            respuesta = false;
        }
        return respuesta;
    }

}
