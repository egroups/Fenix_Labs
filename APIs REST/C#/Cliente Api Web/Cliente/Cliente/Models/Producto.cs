// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Text;

namespace Cliente.Models
{
    class Producto
    {
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int id_proveedor { get; set; }
        public string fecha_registro { get; set; }
    }
}
