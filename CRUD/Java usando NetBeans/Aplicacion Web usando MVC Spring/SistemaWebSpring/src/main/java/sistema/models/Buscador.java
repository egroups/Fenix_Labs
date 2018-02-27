// Written by Ismael Heredia in the year 2016

package sistema.models;

public class Buscador {
    
    String nombre_buscar;

    public String getNombre_buscar() {
        return nombre_buscar;
    }

    public void setNombre_buscar(String nombre_buscar) {
        this.nombre_buscar = nombre_buscar;
    }

    public Buscador() {
    }

    public Buscador(String nombre_buscar) {
        this.nombre_buscar = nombre_buscar;
    }

    @Override
    public String toString() {
        return "Buscador{" + "nombre_buscar=" + nombre_buscar + '}';
    }
   
}
