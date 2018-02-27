// Written by Ismael Heredia in the year 2016

package sistema.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="productos")
public class Producto {

    @Id
    @Column(name="id_producto")
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    int id_producto;
    @Column(name = "nombre_producto")
    String nombre_producto;
    @Column(name = "descripcion")
    String descripcion;
    @Column(name = "precio")
    int precio;
    @Column(name = "id_proveedor")
    int id_proveedor;
    @Column(name = "fecha_registro")
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

    public String getFecha_registro() {
        return fecha_registro;
    }

    public void setFecha_registro(String fecha_registro) {
        this.fecha_registro = fecha_registro;
    }

    public Producto(int id_producto, String nombre_producto, String descripcion, int precio, int id_proveedor, String fecha_registro) {
        this.id_producto = id_producto;
        this.nombre_producto = nombre_producto;
        this.descripcion = descripcion;
        this.precio = precio;
        this.id_proveedor = id_proveedor;
        this.fecha_registro = fecha_registro;
    }
    
    public Producto() {
        
    }

    @Override
    public String toString() {
        return "Producto{" + "id_producto=" + id_producto + ", nombre_producto=" + nombre_producto + ", descripcion=" + descripcion + ", precio=" + precio + ", id_proveedor=" + id_proveedor + ", fecha_registro=" + fecha_registro + '}';
    }
  
}
