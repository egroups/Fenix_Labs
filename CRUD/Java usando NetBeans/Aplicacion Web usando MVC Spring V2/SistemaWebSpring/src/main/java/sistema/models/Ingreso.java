// Written by Ismael Heredia in the year 2017
package sistema.models;

import org.hibernate.validator.constraints.NotEmpty;

public class Ingreso {

    @NotEmpty
    String usuario;

    @NotEmpty
    String clave;

    public String getUsuario() {
        return usuario;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public String getClave() {
        return clave;
    }

    public void setClave(String clave) {
        this.clave = clave;
    }

    public Ingreso() {

    }

    public Ingreso(String usuario, String clave) {
        this.usuario = usuario;
        this.clave = clave;
    }

    @Override
    public String toString() {
        return "Ingreso{" + "usuario=" + usuario + ", clave=" + clave + '}';
    }

}
