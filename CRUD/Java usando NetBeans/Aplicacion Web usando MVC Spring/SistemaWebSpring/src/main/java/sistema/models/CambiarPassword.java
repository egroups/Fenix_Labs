// Written by Ismael Heredia in the year 2016

package sistema.models;

public class CambiarPassword {
    
    String nombre_usuario;
    String password;
    String nuevo_password;

    public String getNombre_usuario() {
        return nombre_usuario;
    }

    public void setNombre_usuario(String nombre_usuario) {
        this.nombre_usuario = nombre_usuario;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getNuevo_password() {
        return nuevo_password;
    }

    public void setNuevo_password(String nuevo_password) {
        this.nuevo_password = nuevo_password;
    }

    public CambiarPassword() {
    }

    public CambiarPassword(String nombre_usuario, String password, String nuevo_password) {
        this.nombre_usuario = nombre_usuario;
        this.password = password;
        this.nuevo_password = nuevo_password;
    }

    @Override
    public String toString() {
        return "CambiarPassword{" + "nombre_usuario=" + nombre_usuario + ", password=" + password + ", nuevo_password=" + nuevo_password + '}';
    }
      
}
