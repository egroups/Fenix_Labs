/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Modelo;

public class Edificio {

    String medidas;
    int ambientes;

    public String getMedidas() {
        return medidas;
    }

    public void setMedidas(String medidas) {
        this.medidas = medidas;
    }

    public int getAmbientes() {
        return ambientes;
    }

    public void setAmbientes(int ambientes) {
        this.ambientes = ambientes;
    }

    public Edificio() {

    }

    public Edificio(String medidas, int ambientes) {
        this.medidas = medidas;
        this.ambientes = ambientes;
    }

    public String datosTerreno() {
        return "-- Datos del terreno --" + "\n\n"
                + "[+] Medidas : " + medidas + "\n"
                + "[+] Ambientes : " + ambientes;
    }

}
