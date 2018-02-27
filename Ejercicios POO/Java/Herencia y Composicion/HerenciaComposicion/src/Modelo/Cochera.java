/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Modelo;

public class Cochera {

    int ambientes;
    String dimensiones;
    Auto auto;

    public int getAmbientes() {
        return ambientes;
    }

    public void setAmbientes(int ambientes) {
        this.ambientes = ambientes;
    }

    public String getDimensiones() {
        return dimensiones;
    }

    public void setDimensiones(String dimensiones) {
        this.dimensiones = dimensiones;
    }

    public Auto getAuto() {
        return auto;
    }

    public void setAuto(Auto auto) {
        this.auto = auto;
    }

    public Cochera() {

    }

    public Cochera(int ambientes, String dimensiones, Auto auto) {
        this.ambientes = ambientes;
        this.dimensiones = dimensiones;
        this.auto = auto;
    }

    public String DatosCochera() {
        return "-- Datos de la cochera -- " + "\n\n"
                + "[+] Ambientes : " + ambientes + "\n"
                + "[+] Dimensiones : " + dimensiones + "\n";
    }

    public String DatosCocheraCompleto() {
        String contenido = "";
        contenido = contenido + "-- Datos de la cochera -- " + "\n\n"
                + "[+] Ambientes : " + ambientes + "\n"
                + "[+] Dimensiones : " + dimensiones + "\n";
        if (auto != null) {
            contenido = contenido + "\n-- Datos del auto --" + "\n\n"
                    + "[+] Marca : " + auto.marca + "\n"
                    + "[+] Numero de serie : " + auto.numero_serie + "\n";
        }
        return contenido;
    }

}
