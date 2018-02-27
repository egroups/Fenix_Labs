// Written by Ismael Heredia in the year 2016

package sistema.funciones;

import java.security.MessageDigest;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Funciones {

    public String md5_encode(String text) {
        // Credits : Based on http://www.avajava.com/tutorials/lessons/how-do-i-generate-an-md5-digest-for-a-string.html
        StringBuffer string_now = null;
        try {
            MessageDigest generate = MessageDigest.getInstance("MD5");
            generate.update(text.getBytes());
            byte[] result = generate.digest();
            string_now = new StringBuffer();
            for (byte line : result) {
                string_now.append(String.format("%02x", line & 0xff));
            }
        } catch (Exception e) {
            //
        }
        return string_now.toString();
    }

    public static boolean valid_number(String str) {
        try {
            double d = Double.parseDouble(str);
        } catch (NumberFormatException nfe) {
            return false;
        }
        return true;
    }

    public String convertir_fecha_para_db(String fecha) {
        String date_formatted = "";
        try {
            SimpleDateFormat format_date = new SimpleDateFormat("dd/MM/yyyy");
            SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd");
            Date date = format_date.parse(fecha);
            date_formatted = formatter.format(date);
        } catch (ParseException ex) {
            //
        }
        return date_formatted;
    }

    public String convertir_fecha_para_usuario(String fecha) {
        String date_formatted = "";
        try {
            SimpleDateFormat format_date = new SimpleDateFormat("yyyy-MM-dd");
            SimpleDateFormat formatter = new SimpleDateFormat("dd/MM/yyyy");
            Date date = format_date.parse(fecha);
            date_formatted = formatter.format(date);
        } catch (ParseException ex) {
            //
        }
        return date_formatted;
    }

    public String fecha_del_dia() {
        String fecha = new SimpleDateFormat("yyyy-MM-dd").format(Calendar.getInstance().getTime());
        return fecha;
    }

}
