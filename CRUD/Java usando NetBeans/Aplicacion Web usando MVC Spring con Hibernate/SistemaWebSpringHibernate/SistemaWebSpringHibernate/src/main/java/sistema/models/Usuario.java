// Written by Ismael Heredia in the year 2016

package sistema.models;

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
    String nombre;
    @Column(name = "clave")
    String password;
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

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
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

    public Usuario(int id_usuario, String nombre, String clave, int tipo, String fecha_registro) {
        this.id_usuario = id_usuario;
        this.nombre = nombre;
        this.password = password;
        this.tipo = tipo;
        this.fecha_registro = fecha_registro;
    }
    
    public Usuario() {
        
    }

    @Override
    public String toString() {
        return "Usuario{" + "id_usuario=" + id_usuario + ", nombre=" + nombre + ", password=" + password + ", tipo=" + tipo + ", fecha_registro=" + fecha_registro + '}';
    }
    
}
