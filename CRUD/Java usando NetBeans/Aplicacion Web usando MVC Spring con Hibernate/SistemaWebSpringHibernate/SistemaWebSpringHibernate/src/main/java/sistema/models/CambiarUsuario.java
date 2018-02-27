// Written by Ismael Heredia in the year 2016

package sistema.models;

public class CambiarUsuario {
    
    String nombre_usuario;
    String nuevo_usuario;
    String password;

    public String getNombre_usuario() {
        return nombre_usuario;
    }

    public void setNombre_usuario(String nombre_usuario) {
        this.nombre_usuario = nombre_usuario;
    }

    public String getNuevo_usuario() {
        return nuevo_usuario;
    }

    public void setNuevo_usuario(String nuevo_usuario) {
        this.nuevo_usuario = nuevo_usuario;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public CambiarUsuario() {
    }
    
    public CambiarUsuario(String nombre_usuario, String nuevo_usuario, String password) {
        this.nombre_usuario = nombre_usuario;
        this.nuevo_usuario = nuevo_usuario;
        this.password = password;
    }

    @Override
    public String toString() {
        return "CambiarUsuario{" + "nombre_usuario=" + nombre_usuario + ", nuevo_usuario=" + nuevo_usuario + ", password=" + password + '}';
    }
       
}
