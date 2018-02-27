// Written by Ismael Heredia in the year 2017
package Modelo;

public class Mensaje {

    boolean success = false;
    String message = "";

    public boolean isSuccess() {
        return success;
    }

    public void setSuccess(boolean success) {
        this.success = success;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public Mensaje() {
    }

    public Mensaje(boolean success, String message) {
        this.success = success;
        this.message = message;
    }

}
