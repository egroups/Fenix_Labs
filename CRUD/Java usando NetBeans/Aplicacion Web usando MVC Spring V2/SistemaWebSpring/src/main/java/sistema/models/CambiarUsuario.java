// Written by Ismael Heredia in the year 2017

package sistema.models;

import org.hibernate.validator.constraints.NotEmpty;

public class CambiarUsuario {
    
    @NotEmpty
    String nombre;
    
    @NotEmpty
    String nuevo_nombre;
    
    @NotEmpty
    String clave;

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getNuevo_nombre() {
        return nuevo_nombre;
    }

    public void setNuevo_nombre(String nuevo_nombre) {
        this.nuevo_nombre = nuevo_nombre;
    }

    public String getClave() {
        return clave;
    }

    public void setClave(String clave) {
        this.clave = clave;
    }

    public CambiarUsuario() {
        
    }
    
    public CambiarUsuario(String nombre, String nuevo_nombre, String clave) {
        this.nombre = nombre;
        this.nuevo_nombre = nuevo_nombre;
        this.clave = clave;
    }

    @Override
    public String toString() {
        return "CambiarUsuario{" + "nombre=" + nombre + ", nuevo_nombre=" + nuevo_nombre + ", clave=" + clave + '}';
    }
     
}
