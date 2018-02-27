// Written by Ismael Heredia in the year 2017
package sistema.models;

public class TipoUsuario {
  
    int id;
    String nombre;

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
    
    public TipoUsuario() {
        
    }

    public TipoUsuario(int id, String nombre) {
        this.id = id;
        this.nombre = nombre;
    }

    @Override
    public String toString() {
        return "TipoUsuario{" + "id=" + id + ", nombre=" + nombre + '}';
    }
  
}
