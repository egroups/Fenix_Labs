// Written by Ismael Heredia in the year 2016

package sistema.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "proveedores")
public class Proveedor {

    @Id
    @Column(name = "id_proveedor")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    int id_proveedor;
    @Column(name = "nombre_empresa")
    String nombre_empresa;
    @Column(name = "direccion")
    String direccion;
    @Column(name = "telefono")
    int telefono;
    @Column(name = "fecha_registro_proveedor")
    String fecha_registro_proveedor;

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

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public int getTelefono() {
        return telefono;
    }

    public void setTelefono(int telefono) {
        this.telefono = telefono;
    }

    public String getFecha_registro_proveedor() {
        return fecha_registro_proveedor;
    }

    public void setFecha_registro_proveedor(String fecha_registro_proveedor) {
        this.fecha_registro_proveedor = fecha_registro_proveedor;
    }

    public Proveedor(int id_proveedor, String nombre_empresa, String direccion, int telefono, String fecha_registro_proveedor) {
        this.id_proveedor = id_proveedor;
        this.nombre_empresa = nombre_empresa;
        this.direccion = direccion;
        this.telefono = telefono;
        this.fecha_registro_proveedor = fecha_registro_proveedor;
    }
    
    public Proveedor() {
        
    }

    @Override
    public String toString() {
        return "Proveedor{" + "id_proveedor=" + id_proveedor + ", nombre_empresa=" + nombre_empresa + ", direccion=" + direccion + ", telefono=" + telefono + ", fecha_registro_proveedor=" + fecha_registro_proveedor + '}';
    }

}
