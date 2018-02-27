// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Usuario
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Clave")]
        public string clave { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione tipo de usuario")]
        [Display(Name = "Tipo de usuario")]
        public int id_tipo { get; set; }
        public string fecha_registro { get; set; }

        public TipoUsuario tipo { get; set; }

        public Usuario()
        {
            tipo = new TipoUsuario();
        }

    }
}
