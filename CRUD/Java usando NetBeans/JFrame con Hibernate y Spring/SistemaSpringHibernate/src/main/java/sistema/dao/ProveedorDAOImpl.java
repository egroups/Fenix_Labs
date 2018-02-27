// Written by Ismael Heredia in the year 2016

package sistema.dao;

import java.util.ArrayList;
import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import sistema.model.Proveedor;

public class ProveedorDAOImpl implements ProveedorDAO {

    private SessionFactory sessionFactory;

    public void setSessionFactory(SessionFactory sessionFactory) {
        this.sessionFactory = sessionFactory;
    }

    @Override
    public boolean insert(Proveedor proveedor) {
        boolean respuesta = false;
        try {
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            session.save(proveedor);
            session.getTransaction().commit();
            session.close();
            respuesta = true;
        } catch (HibernateException he) {
            respuesta = false;
        }
        return respuesta;
    }

    @Override
    public boolean update(Proveedor proveedor) {
        boolean respuesta = false;
        try {
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            session.update(proveedor);
            session.getTransaction().commit();
            session.close();
            respuesta = true;
        } catch (HibernateException he) {
            respuesta = false;
        }
        return respuesta;
    }

    @Override
    public boolean delete(Proveedor proveedor) {
        boolean respuesta = false;
        try {
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            session.delete(proveedor);
            session.getTransaction().commit();
            session.close();
            respuesta = true;
        } catch (HibernateException he) {
            respuesta = false;
        }
        return respuesta;
    }

    @Override
    public Proveedor findByProveedorId(int id_proveedor_to_load) {
        Proveedor proveedor = new Proveedor();
        try {
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            proveedor = (Proveedor) session.get(Proveedor.class, id_proveedor_to_load);
            session.getTransaction().commit();
            session.close();
        } catch (HibernateException he) {
            //
        }
        return proveedor;
    }

    @Override
    public ArrayList listProveedores(String patron) {
        Session session = this.sessionFactory.openSession();
        session.beginTransaction();
        Query q = session.createQuery("from Proveedor p where p.nombre_empresa like :patron");
        q.setString("patron", "%" + patron + "%");
        ArrayList lista = (ArrayList) q.list();
        session.close();
        return lista;
    }

    @Override
    public boolean comprobar_existencia_proveedor_crear(String nombre_empresa) {
        boolean respuesta = false;
        Session session = this.sessionFactory.openSession();
        session.beginTransaction();
        Query q = session.createQuery("from Proveedor p where p.nombre_empresa like :patron");
        q.setString("patron", "%" + nombre_empresa + "%");
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
    public boolean comprobar_existencia_proveedor_editar(int id_proveedor, String nombre_empresa) {
        boolean respuesta = false;
        Session session = this.sessionFactory.openSession();
        session.beginTransaction();
        Query q = session.createQuery("from Proveedor p where p.nombre_empresa like :patron and p.id_proveedor!=" + id_proveedor);
        q.setString("patron", "%" + nombre_empresa + "%");
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
