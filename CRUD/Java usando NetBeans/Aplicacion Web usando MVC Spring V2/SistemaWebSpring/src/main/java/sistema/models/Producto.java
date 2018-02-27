// Written by Ismael Heredia in the year 2017
package sistema.models;

import javax.validation.constraints.NotNull;
import org.hibernate.validator.constraints.NotEmpty;

public class Producto {

    int id;

    @NotEmpty
    String nombre;

    @NotEmpty
    String descripcion;

    @NotNull
    double precio;

    @NotNull
    int id_proveedor;

    String fecha_registro;

    public Proveedor proveedor;

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

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public double getPrecio() {
        return precio;
    }

    public void setPrecio(double precio) {
        this.precio = precio;
    }

    public int getId_proveedor() {
        return id_proveedor;
    }

    public void setId_proveedor(int id_proveedor) {
        this.id_proveedor = id_proveedor;
    }

    public String getFecha_registro() {
        return fecha_registro;
    }

    public void setFecha_registro(String fecha_registro) {
        this.fecha_registro = fecha_registro;
    }

    public Proveedor getProveedor() {
        return proveedor;
    }

    public void setProveedor(Proveedor proveedor) {
        this.proveedor = proveedor;
    }

    public Producto() {

    }

    public Producto(int id, String nombre, String descripcion, double precio, int id_proveedor, String fecha_registro) {
        this.id = id;
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.precio = precio;
        this.id_proveedor = id_proveedor;
        this.fecha_registro = fecha_registro;
    }

    @Override
    public String toString() {
        return "Producto{" + "id=" + id + ", nombre=" + nombre + ", descripcion=" + descripcion + ", precio=" + precio + ", id_proveedor=" + id_proveedor + ", fecha_registro=" + fecha_registro + ", proveedor=" + proveedor + '}';
    }

}
