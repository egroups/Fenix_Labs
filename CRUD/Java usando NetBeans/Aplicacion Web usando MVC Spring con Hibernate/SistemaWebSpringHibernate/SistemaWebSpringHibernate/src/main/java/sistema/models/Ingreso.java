// Written by Ismael Heredia in the year 2016

package sistema.models;

public class Ingreso {
 
    String username;
    String password;

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Ingreso() {
    }

    public Ingreso(String username, String password) {
        this.username = username;
        this.password = password;
    }

    @Override
    public String toString() {
        return "Ingreso{" + "username=" + username + ", password=" + password + '}';
    }

}
