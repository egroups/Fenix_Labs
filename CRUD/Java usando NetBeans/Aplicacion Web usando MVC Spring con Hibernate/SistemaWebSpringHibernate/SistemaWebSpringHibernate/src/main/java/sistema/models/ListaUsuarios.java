// Written by Ismael Heredia in the year 2016

package sistema.models;

public class ListaUsuarios {

    int id_usuario;
    String nombre;
    String password;
    int tipo;
    String nombre_tipo;
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

    public String getNombre_tipo() {
        return nombre_tipo;
    }

    public void setNombre_tipo(String nombre_tipo) {
        this.nombre_tipo = nombre_tipo;
    }

    public String getFecha_registro() {
        return fecha_registro;
    }

    public void setFecha_registro(String fecha_registro) {
        this.fecha_registro = fecha_registro;
    }

    public ListaUsuarios() {
    }

    public ListaUsuarios(int id_usuario, String nombre, String password, int tipo, String nombre_tipo, String fecha_registro) {
        this.id_usuario = id_usuario;
        this.nombre = nombre;
        this.password = password;
        this.tipo = tipo;
        this.nombre_tipo = nombre_tipo;
        this.fecha_registro = fecha_registro;
    }

    @Override
    public String toString() {
        return "ListaUsuarios{" + "id_usuario=" + id_usuario + ", nombre=" + nombre + ", password=" + password + ", tipo=" + tipo + ", nombre_tipo=" + nombre_tipo + ", fecha_registro=" + fecha_registro + '}';
    }

}
