// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Models
{
    class Proveedor
    {
        public int id_proveedor { get; set; }
        public string nombre_empresa { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string fecha_registro_proveedor { get; set; }
    }
}
