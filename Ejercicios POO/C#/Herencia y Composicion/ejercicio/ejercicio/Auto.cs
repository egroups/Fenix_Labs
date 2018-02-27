// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Text;

namespace ejercicio
{
    class Auto
    {
        public string marca;
        public string numero_serie;

        public string pMarca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string pNumero_serie
        {
            get { return numero_serie; }
            set { numero_serie = value; }
        }

        public Auto()
        {
            marca = "";
            numero_serie = "";
        }

        public Auto(string marca_load, string numero_serie_load)
        {
            marca = marca_load;
            numero_serie = numero_serie_load;
        }

        public string DatosAuto()
        {
            return "-- Datos del auto --" + "\n\n"
            + "[+] Marca : " + marca + "\n"
            + "[+] Numero de serie : " + numero_serie;
        }
    }
}
