// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personal.Models
{
    public class Empleado
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public string sexo { get; set; }
        public int id_profesion { get; set; }
        public Profesion profesion { get; set; }

        public Empleado()
        {
            profesion = new Profesion();
        }
    }
}