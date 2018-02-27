// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Text;

namespace ejercicio
{
    class Casa:Edificio
    {
        public string dueño;
        public int telefono;
        public string direccion;
        public Cochera cochera;

        public string pDueño
        {
            get { return dueño; }
            set { dueño = value; }
        }

        public int pTelefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string pDireccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public Cochera pCochera
        {
            get { return cochera; }
            set { cochera = value; }
        }

        public Casa()
        {
            dueño = "";
            telefono = 0;
            direccion = "";
            cochera = null;
        }

        public Casa(string medidas_load,int terreno_load,string dueño_load, int telefono_load, string direccion_load, Cochera cochera_load)
        {
            medidas = medidas_load;
            ambientes = terreno_load;
            dueño = dueño_load;
            telefono = telefono_load;
            direccion = direccion_load;
            cochera = cochera_load;
        }

        public string DatosCasa()
        {
            string contenido = "";

            contenido = contenido + "-- Datos del terreno --" + "\n\n" +
                "[+] Medidas : " + medidas + "\n" +
                "[+] Ambientes : " + ambientes + "\n\n";

            contenido = contenido + "-- Datos de la casa --" + "\n\n"
            + "[+] Dueño : " + dueño + "\n"
            + "[+] Telefono : " + telefono + "\n"
            + "[+] Direccion : " + direccion + "\n";
            if (cochera != null)
            {
                contenido = contenido + "[+] Cochera : " + cochera.pDimensiones + "\n";
            }
            return contenido;
        }

        public string DatosCasaCompleto()
        {
            string contenido = "";

            contenido = contenido + "-- Datos del terreno --" + "\n\n" +
                "[+] Medidas : " + medidas + "\n" +
                "[+] Ambientes : " + ambientes + "\n\n";

            contenido = contenido + "-- Datos de la casa completo --" + "\n\n"
            + "[+] Dueño : " + dueño + "\n"
            + "[+] Telefono : " + telefono + "\n"
            + "[+] Direccion : " + direccion + "\n\n";

            if (cochera != null)
            {
                contenido = contenido + "-- Datos de la cochera -- " + "\n\n"
                + "[+] Ambientes : " + cochera.ambientes + "\n"
                + "[+] Dimensiones : " + cochera.dimensiones + "\n";

                if (cochera.pAuto != null)
                {
                    contenido = contenido + "\n-- Datos del auto --" + "\n\n"
                    + "[+] Marca : " + cochera.pAuto.marca + "\n"
                    + "[+] Numero de serie : " + cochera.pAuto.numero_serie + "\n";
                }

            }

            return contenido;
        }
    }
}
