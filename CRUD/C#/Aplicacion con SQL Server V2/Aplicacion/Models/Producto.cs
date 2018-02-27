// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Models
{
    class Producto
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public double precio { get; set; }

        public int id_proveedor { get; set; }

        public string fecha_registro { get; set; }

        public Proveedor proveedor { get; set; }

        public Producto()
        {
            proveedor = new Proveedor();
        }
    }
}
