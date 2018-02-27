// Written by Ismael Heredia in the year 2017
package sistema.models;

import javax.validation.constraints.NotNull;
import org.hibernate.validator.constraints.NotEmpty;

public class AsignarUsuario {

    int id;

    @NotEmpty
    String nombre;

    String clave;

    @NotNull
    int id_tipo;

    String fecha_registro;

    public TipoUsuario tipo;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getClave() {
        return clave;
    }

    public void setClave(String clave) {
        this.clave = clave;
    }

    public int getId_tipo() {
        return id_tipo;
    }

    public void setId_tipo(int id_tipo) {
        this.id_tipo = id_tipo;
    }

    public String getFecha_registro() {
        return fecha_registro;
    }

    public void setFecha_registro(String fecha_registro) {
        this.fecha_registro = fecha_registro;
    }

    public TipoUsuario getTipo() {
        return tipo;
    }

    public void setTipo(TipoUsuario tipo) {
        this.tipo = tipo;
    }

    public AsignarUsuario() {

    }

    public AsignarUsuario(int id, String nombre, String clave, int id_tipo, String fecha_registro) {
        this.id = id;
        this.nombre = nombre;
        this.clave = clave;
        this.id_tipo = id_tipo;
        this.fecha_registro = fecha_registro;
    }

    @Override
    public String toString() {
        return "TipoUsuario{" + "id=" + id + ", nombre=" + nombre + ", clave=" + clave + ", id_tipo=" + id_tipo + ", fecha_registro=" + fecha_registro + ", tipo=" + tipo + '}';
    }

}
