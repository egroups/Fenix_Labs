// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Text;

namespace ejercicio
{
    class Cochera
    {
        public int ambientes;
        public string dimensiones;
        public Auto auto;

        public Auto pAuto
        {
            get { return auto; }
            set { auto = value; }
        }

        public int pAmbientes
        {
            get { return ambientes; }
            set { ambientes = value; }
        }

        public string pDimensiones
        {
            get { return dimensiones; }
            set { dimensiones = value; }
        }

        public Cochera()
        {
            ambientes = 0;
            dimensiones = "";
            auto = null;
        }

        public Cochera(int ambientes_load, string dimensiones_load, Auto auto_load)
        {
            ambientes = ambientes_load;
            dimensiones = dimensiones_load;
            auto = auto_load;
        }

        public string DatosCochera()
        {
            return "-- Datos de la cochera -- " + "\n\n"
                + "[+] Ambientes : " + ambientes + "\n"
                + "[+] Dimensiones : " + dimensiones + "\n";
        }

        public string DatosCocheraCompleto()
        {
            string contenido = "";

            contenido = "-- Datos de la cochera -- " + "\n\n"
                + "[+] Ambientes : " + ambientes + "\n"
                + "[+] Dimensiones : " + dimensiones + "\n";

            if (auto != null)
            {
                contenido = contenido + "\n-- Datos del auto --" + "\n\n"
                + "[+] Marca : " + auto.marca + "\n"
                + "[+] Numero de serie : " + auto.numero_serie + "\n";
            }

            return contenido;
        }
    }
}
