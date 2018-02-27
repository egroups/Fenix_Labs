// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Proveedor
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Ingrese un teléfono válido")]
        [Display(Name = "Teléfono")]
        public int telefono { get; set; }

        public string fecha_registro { get; set; }
    }
}
