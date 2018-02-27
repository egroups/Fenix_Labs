// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class UsuarioModel
    {
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public int tipo { get; set; }
        public string fecha_registro { get; set; }

    }
}