// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Text;

namespace ejercicio
{
    class Edificio
    {
        public string medidas;
        public int ambientes;

        public string pMedidas
        {
            get { return medidas; }
            set { medidas = value; }
        }

        public int pAmbientes
        {
            get { return ambientes; }
            set { ambientes = value; }
        }

        public Edificio()
        {
            medidas = "";
            ambientes = 0;
        }

        public Edificio(string medidas_load, int ambientes_load)
        {
            medidas = medidas_load;
            ambientes = ambientes_load;
        }

        public string DatosTerreno()
        {
            return "-- Datos del terreno --" + "\n\n"
            + "[+] Medidas : " + medidas + "\n"
            + "[+] Ambientes : " + ambientes;
        }
    }
}
