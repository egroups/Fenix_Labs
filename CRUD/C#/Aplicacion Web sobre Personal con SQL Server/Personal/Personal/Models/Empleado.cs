// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Personal.Models
{
    public class Empleado
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Ingrese un teléfono válido")]
        [Display(Name = "Teléfono")]
        public int telefono { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public string sexo { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione profesión")]
        [Display(Name = "Profesión")]
        public int id_profesion { get; set; }

        public Profesion profesion { get; set; }

        public Empleado()
        {
            profesion = new Profesion();
        }
    }
}