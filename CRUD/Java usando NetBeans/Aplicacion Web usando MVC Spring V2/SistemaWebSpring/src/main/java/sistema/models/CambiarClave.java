// Written by Ismael Heredia in the year 2017
package sistema.models;

import org.hibernate.validator.constraints.NotEmpty;

public class CambiarClave {

    @NotEmpty
    String nombre;

    @NotEmpty
    String clave;

    @NotEmpty
    String nueva_clave;

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

    public String getNueva_clave() {
        return nueva_clave;
    }

    public void setNueva_clave(String nueva_clave) {
        this.nueva_clave = nueva_clave;
    }

    public CambiarClave() {

    }

    public CambiarClave(String nombre, String clave, String nueva_clave) {
        this.nombre = nombre;
        this.clave = clave;
        this.nueva_clave = nueva_clave;
    }

    @Override
    public String toString() {
        return "CambiarClave{" + "nombre=" + nombre + ", clave=" + clave + ", nueva_clave=" + nueva_clave + '}';
    }

}
