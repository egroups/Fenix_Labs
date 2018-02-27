// Written by Ismael Heredia in the year 2016

package sistema.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "usuarios")
public class Usuario {

    @Id
    @Column(name = "id_usuario")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    int id_usuario;
    @Column(name = "usuario")
    String usuario;
    @Column(name = "clave")
    String clave;
    @Column(name = "tipo")
    int tipo;
    @Column(name = "fecha_registro")
    String fecha_registro;

    public int getId_usuario() {
        return id_usuario;
    }

    public void setId_usuario(int id_usuario) {
        this.id_usuario = id_usuario;
    }

    public String getUsuario() {
        return usuario;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public String getClave() {
        return clave;
    }

    public void setClave(String clave) {
        this.clave = clave;
    }

    public int getTipo() {
        return tipo;
    }

    public void setTipo(int tipo) {
        this.tipo = tipo;
    }

    public String getFecha_registro() {
        return fecha_registro;
    }

    public void setFecha_registro(String fecha_registro) {
        this.fecha_registro = fecha_registro;
    }

    public Usuario(int id_usuario, String usuario, String clave, int tipo, String fecha_registro) {
        this.id_usuario = id_usuario;
        this.usuario = usuario;
        this.clave = clave;
        this.tipo = tipo;
        this.fecha_registro = fecha_registro;
    }
    
    public Usuario() {
        
    }

    @Override
    public String toString() {
        return "Usuario{" + "id_usuario=" + id_usuario + ", usuario=" + usuario + ", clave=" + clave + ", tipo=" + tipo + ", fecha_registro=" + fecha_registro + '}';
    }
    
}
