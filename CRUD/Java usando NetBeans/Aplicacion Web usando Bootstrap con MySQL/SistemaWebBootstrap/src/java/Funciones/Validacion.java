// Written by Ismael Heredia in the year 2016

package Funciones;

import java.text.DecimalFormat;
import java.time.LocalDate;
import java.time.temporal.ChronoUnit;

public class Validacion {

    public boolean isNumeric(String number) {
        try {
            double check = Double.parseDouble(number);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }

    public boolean isDouble(String number) {
        try {
            Double.parseDouble(number);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }

    public String CleanNumber(double number) {
        String resultado = "";
        try {
            DecimalFormat format = new DecimalFormat("0.#");
            resultado = format.format(number);
        } catch (NumberFormatException e) {
            //
        }
        return resultado;
    }

    public long calcular_fechaNacimiento(String fecha) {
        String[] fecha_parte = fecha.split("/");
        int año = Integer.parseInt(fecha_parte[2]);
        int mes = Integer.parseInt(fecha_parte[1]);
        int dia = Integer.parseInt(fecha_parte[0]);
        LocalDate start = LocalDate.of(año, mes, dia);
        LocalDate end = LocalDate.now();
        long edad = ChronoUnit.YEARS.between(start, end);
        return edad;
    }

    public double calcularPorcentajeMejora(double numero1, double numero2) {
        double resta1 = numero1 - numero2;
        double division = resta1 / numero1;
        double porcentaje = division * 100;
        return porcentaje;
    }

}
