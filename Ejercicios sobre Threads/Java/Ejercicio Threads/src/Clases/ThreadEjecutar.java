package Clases;

import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JTextArea;

public class ThreadEjecutar extends Thread {

    public String variable = "";
    public JTextArea logs;

    public ThreadEjecutar(String variable_cargada, JTextArea console) {
        variable = variable_cargada;
        logs = console;
    }

    public void run() {
        try {
            Thread.sleep(5000);
            //System.out.println("Thread Iniciado : "+variable);
            logs.append("Thread Iniciado : " + variable + "\n");
        } catch (InterruptedException ex) {
            Logger.getLogger(ThreadEjecutar.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
