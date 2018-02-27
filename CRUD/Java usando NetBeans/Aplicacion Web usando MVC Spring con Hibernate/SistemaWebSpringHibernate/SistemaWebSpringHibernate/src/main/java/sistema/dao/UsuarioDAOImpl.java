// Written by Ismael Heredia in the year 2016
package sistema.dao;

import java.util.ArrayList;
import org.hibernate.HibernateException;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import sistema.models.ListaUsuarios;
import sistema.models.Usuario;

public class UsuarioDAOImpl implements UsuarioDAO {
    
    private SessionFactory sessionFactory;
    
    public void setSessionFactory(SessionFactory sessionFactory) {
        this.sessionFactory = sessionFactory;
    }
    
    @Override
    public boolean insert(Usuario usuario) {
        boolean respuesta = false;
        try {
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            session.save(usuario);
            session.getTransaction().commit();
            session.close();
            respuesta = true;
        } catch (HibernateException he) {
            respuesta = false;
        }
        return respuesta;
    }
    
    @Override
    public boolean update(Usuario usuario) {
        boolean respuesta = false;
        try {
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            session.update(usuario);
            session.getTransaction().commit();
            session.close();
            respuesta = true;
        } catch (HibernateException he) {
            respuesta = false;
        }
        return respuesta;
    }
    
    @Override
    public boolean delete(Usuario usuario) {
        boolean respuesta = false;
        try {
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            session.delete(usuario);
            session.getTransaction().commit();
            session.close();
            respuesta = true;
        } catch (HibernateException he) {
            respuesta = false;
        }
        return respuesta;
    }
    
    @Override
    public ArrayList listUsuarios(String patron) {
        Session session = this.sessionFactory.openSession();
        session.beginTransaction();
        Query q = session.createQuery("from Usuario p where p.nombre like :patron");
        q.setString("patron", "%" + patron + "%");
        ArrayList usuarios = (ArrayList) q.list();
        session.close();
        ArrayList lista = new ArrayList();
        for (int i = 0; i < usuarios.size(); i++) {
            Usuario usuario = (Usuario) usuarios.get(i);
            int id_usuario = usuario.getId_usuario();
            String nombre_usuario = usuario.getNombre();
            String clave = usuario.getPassword();
            int tipo = usuario.getTipo();
            String nombre_tipo = "";
            if (tipo == 1) {
                nombre_tipo = "Administrador";
            } else {
                nombre_tipo = "Usuario";
            }
            String fecha_registro = usuario.getFecha_registro();
            ListaUsuarios usu = new ListaUsuarios(id_usuario, nombre_usuario, clave, tipo, nombre_tipo, fecha_registro);
            lista.add(usu);
        }
        return lista;
    }
    
    @Override
    public Usuario findByUsuarioId(int id_producto_to_load) {
        Usuario usuario = new Usuario();
        try {
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            usuario = (Usuario) session.get(Usuario.class, id_producto_to_load);
            session.getTransaction().commit();
            session.close();
        } catch (HibernateException he) {
            //
        }
        return usuario;
    }
    
    @Override
    public boolean comprobar_existencia_usuario_crear(String nombre_usuario) {
        boolean respuesta = false;
        Session session = this.sessionFactory.openSession();
        session.beginTransaction();
        Query q = session.createQuery("from Usuario u where u.nombre like :patron");
        q.setString("patron", "%" + nombre_usuario + "%");
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
    public boolean comprobar_existencia_usuario_editar(String nombre_usuario) {
        boolean respuesta = false;
        Session session = this.sessionFactory.openSession();
        session.beginTransaction();
        Query q = session.createQuery("from Usuario u where u.nombre like :patron");
        q.setString("patron", "%" + nombre_usuario + "%");
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
    public int get_id_by_username(String username) {
        int id_usuario = 0;
        try {
            String query = "from Usuario where nombre='" + username + "'";
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            Query q = session.createQuery(query);
            ArrayList lista = (ArrayList) q.list();
            for (Object o : lista) {
                Usuario usuario = (Usuario) o;
                id_usuario = usuario.getId_usuario();
            }
            session.close();
        } catch (Exception e) {
            //
        }
        return id_usuario;
    }
    
    @Override
    public Integer ejecutarConsulta(String query) {
        int cantidad = 0;
        Session session = this.sessionFactory.openSession();
        session.beginTransaction();
        Query q = session.createQuery(query);
        ArrayList lista = (ArrayList) q.list();
        session.close();
        return lista.size();
    }
    
    @Override
    public boolean ingreso_usuario(String username, String password) {
        boolean respuesta = false;
        try {
            int cantidad = ejecutarConsulta("from Usuario where nombre='" + username + "' and clave='" + password + "'");
            if (cantidad >= 1) {
                respuesta = true;
            } else {
                respuesta = false;
            }
        } catch (Exception e) {
            System.out.println(e);
        }
        return respuesta;
    }
    
    @Override
    public boolean es_admin(String username) {
        boolean respuesta = false;
        try {
            String query = "from Usuario where nombre='" + username + "'";
            Session session = this.sessionFactory.openSession();
            session.beginTransaction();
            Query q = session.createQuery(query);
            ArrayList lista = (ArrayList) q.list();
            for (Object o : lista) {
                Usuario usuario = (Usuario) o;
                int tipo = usuario.getTipo();
                if (tipo == 1) {
                    respuesta = true;
                } else {
                    respuesta = false;
                }
            }
            session.close();
        } catch (Exception e) {
            //
        }
        return respuesta;
    }
    
    @Override
    public boolean cambiar_usuario(String usuario, String nuevo_usuario) {
        int id_usuario = get_id_by_username(usuario);
        Usuario usuario_save = findByUsuarioId(id_usuario);
        usuario_save.setNombre(nuevo_usuario);
        return update(usuario_save);
    }
    
    @Override
    public boolean cambiar_password(String usuario, String nuevo_password) {
        int id_usuario = get_id_by_username(usuario);
        Usuario usuario_save = findByUsuarioId(id_usuario);
        usuario_save.setPassword(nuevo_password);
        return update(usuario_save);
    }
    
}
