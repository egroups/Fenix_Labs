/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Modelo;

public class Auto {

    String marca;
    String numero_serie;

    public String getMarca() {
        return marca;
    }

    public void setMarca(String marca) {
        this.marca = marca;
    }

    public String getNumero_serie() {
        return numero_serie;
    }

    public void setNumero_serie(String numero_serie) {
        this.numero_serie = numero_serie;
    }

    public Auto() {

    }

    public Auto(String marca, String numero_serie) {
        this.marca = marca;
        this.numero_serie = numero_serie;
    }

    @Override
    public String toString() {
        return "-- Datos del auto --" + "\n\n"
                + "[+] Marca : " + marca + "\n"
                + "[+] Numero de serie : " + numero_serie;
    }

}
