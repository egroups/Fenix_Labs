// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Models
{
    class Usuario
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string clave { get; set; }

        public int id_tipo { get; set; }
        public string fecha_registro { get; set; }

        public TipoUsuario tipo { get; set; }

        public Usuario()
        {
            tipo = new TipoUsuario();
        }
    }
}
