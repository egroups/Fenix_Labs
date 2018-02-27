package sistema.entity;
// Generated 31-ene-2017 10:47:40 by Hibernate Tools 4.3.1


import java.util.HashSet;
import java.util.Set;

/**
 * Proveedores generated by hbm2java
 */
public class Proveedores  implements java.io.Serializable {


     private Integer idProveedor;
     private String nombreEmpresa;
     private String direccion;
     private Integer telefono;
     private String fechaRegistroProveedor;
     private Set productoses = new HashSet(0);

    public Proveedores() {
    }

    public Proveedores(String nombreEmpresa, String direccion, Integer telefono, String fechaRegistroProveedor, Set productoses) {
       this.nombreEmpresa = nombreEmpresa;
       this.direccion = direccion;
       this.telefono = telefono;
       this.fechaRegistroProveedor = fechaRegistroProveedor;
       this.productoses = productoses;
    }
   
    public Integer getIdProveedor() {
        return this.idProveedor;
    }
    
    public void setIdProveedor(Integer idProveedor) {
        this.idProveedor = idProveedor;
    }
    public String getNombreEmpresa() {
        return this.nombreEmpresa;
    }
    
    public void setNombreEmpresa(String nombreEmpresa) {
        this.nombreEmpresa = nombreEmpresa;
    }
    public String getDireccion() {
        return this.direccion;
    }
    
    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }
    public Integer getTelefono() {
        return this.telefono;
    }
    
    public void setTelefono(Integer telefono) {
        this.telefono = telefono;
    }
    public String getFechaRegistroProveedor() {
        return this.fechaRegistroProveedor;
    }
    
    public void setFechaRegistroProveedor(String fechaRegistroProveedor) {
        this.fechaRegistroProveedor = fechaRegistroProveedor;
    }
    public Set getProductoses() {
        return this.productoses;
    }
    
    public void setProductoses(Set productoses) {
        this.productoses = productoses;
    }




}


