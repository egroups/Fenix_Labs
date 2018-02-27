// Written by Ismael Heredia in the year 2016
package sistema.models;

public class Producto {

    int id_producto;
    String nombre_producto;
    String descripcion;
    int precio;
    int id_proveedor;
    String nombre_empresa;
    String fecha_registro;

    public int getId_producto() {
        return id_producto;
    }

    public void setId_producto(int id_producto) {
        this.id_producto = id_producto;
    }

    public String getNombre_producto() {
        return nombre_producto;
    }

    public void setNombre_producto(String nombre_producto) {
        this.nombre_producto = nombre_producto;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public int getPrecio() {
        return precio;
    }

    public void setPrecio(int precio) {
        this.precio = precio;
    }

    public int getId_proveedor() {
        return id_proveedor;
    }

    public void setId_proveedor(int id_proveedor) {
        this.id_proveedor = id_proveedor;
    }

    public String getNombre_empresa() {
        return nombre_empresa;
    }

    public void setNombre_empresa(String nombre_empresa) {
        this.nombre_empresa = nombre_empresa;
    }

    public String getFecha_registro() {
        return fecha_registro;
    }

    public void setFecha_registro(String fecha_registro) {
        this.fecha_registro = fecha_registro;
    }

    public Producto() {
    }

    public Producto(int id_producto, String nombre_producto, String descripcion, int precio, int id_proveedor, String nombre_empresa, String fecha_registro) {
        this.id_producto = id_producto;
        this.nombre_producto = nombre_producto;
        this.descripcion = descripcion;
        this.precio = precio;
        this.id_proveedor = id_proveedor;
        this.nombre_empresa = nombre_empresa;
        this.fecha_registro = fecha_registro;
    }

    @Override
    public String toString() {
        return "Producto{" + "id_producto=" + id_producto + ", nombre_producto=" + nombre_producto + ", descripcion=" + descripcion + ", precio=" + precio + ", id_proveedor=" + id_proveedor + ", nombre_empresa=" + nombre_empresa + ", fecha_registro=" + fecha_registro + '}';
    }
 
}
