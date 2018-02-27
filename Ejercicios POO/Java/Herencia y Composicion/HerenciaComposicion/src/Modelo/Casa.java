/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Modelo;

public class Casa extends Edificio {

    String dueño;
    int telefono;
    String direccion;
    Cochera cochera;

    public String getDueño() {
        return dueño;
    }

    public void setDueño(String dueño) {
        this.dueño = dueño;
    }

    public int getTelefono() {
        return telefono;
    }

    public void setTelefono(int telefono) {
        this.telefono = telefono;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public Cochera getCochera() {
        return cochera;
    }

    public void setCochera(Cochera cochera) {
        this.cochera = cochera;
    }

    public Casa() {

    }

    public Casa(String medidas, int ambientes, String dueño, int telefono, String direccion, Cochera cochera) {
        this.medidas = medidas;
        this.ambientes = ambientes;
        this.dueño = dueño;
        this.telefono = telefono;
        this.direccion = direccion;
        this.cochera = cochera;
    }

    public String DatosCasa() {
        String contenido = "";
        contenido = contenido + "-- Datos del terreno --" + "\n\n"
                + "[+] Medidas : " + medidas + "\n"
                + "[+] Ambientes : " + ambientes + "\n\n";

        contenido = contenido + "-- Datos de la casa --" + "\n\n"
                + "[+] Dueño : " + dueño + "\n"
                + "[+] Telefono : " + telefono + "\n"
                + "[+] Direccion : " + direccion + "\n";

        if (cochera != null) {
            contenido = contenido + "[+] Cochera : " + cochera.dimensiones + "\n";
        }

        return contenido;
    }

    public String DatosCasaCompleto() {
        String contenido = "";
        contenido = contenido + "-- Datos del terreno --" + "\n\n"
                + "[+] Medidas : " + medidas + "\n"
                + "[+] Ambientes : " + ambientes + "\n\n";

        contenido = contenido + "-- Datos de la casa --" + "\n\n"
                + "[+] Dueño : " + dueño + "\n"
                + "[+] Telefono : " + telefono + "\n"
                + "[+] Direccion : " + direccion + "\n";

        if (cochera != null) {
            contenido = contenido + "\n-- Datos de la cochera --" + "\n\n"
                    + "[+] Ambientes : " + cochera.ambientes + "\n"
                    + "[+] Dimensiones : " + cochera.dimensiones + "\n";

            if (cochera.auto != null) {
                contenido = contenido + "\n-- Datos del auto --" + "\n\n"
                        + "[+] Marca : " + cochera.auto.marca + "\n"
                        + "[+] Numero de serie : " + cochera.auto.numero_serie + "\n";
            }

        }

        return contenido;
    }

}
