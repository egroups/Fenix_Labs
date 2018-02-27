// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.Models
{
    public class Proveedor
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string direccion { get; set; }

        public int telefono { get; set; }

        public string fecha_registro { get; set; }
    }
}