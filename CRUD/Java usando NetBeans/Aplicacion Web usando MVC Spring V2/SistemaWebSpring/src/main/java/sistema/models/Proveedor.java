// Written by Ismael Heredia in the year 2017
package sistema.models;

import javax.validation.constraints.NotNull;
import org.hibernate.validator.constraints.NotEmpty;

public class Proveedor {

    int id;

    @NotEmpty
    String nombre;

    @NotEmpty
    String direccion;

    @NotNull
    int telefono;

    String fecha_registro;

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

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public int getTelefono() {
        return telefono;
    }

    public void setTelefono(int telefono) {
        this.telefono = telefono;
    }

    public String getFecha_registro() {
        return fecha_registro;
    }

    public void setFecha_registro(String fecha_registro) {
        this.fecha_registro = fecha_registro;
    }

    public Proveedor() {

    }

    public Proveedor(int id, String nombre, String direccion, int telefono, String fecha_registro) {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.fecha_registro = fecha_registro;
    }

    @Override
    public String toString() {
        return "Proveedor{" + "id=" + id + ", nombre=" + nombre + ", direccion=" + direccion + ", telefono=" + telefono + ", fecha_registro=" + fecha_registro + '}';
    }

}
