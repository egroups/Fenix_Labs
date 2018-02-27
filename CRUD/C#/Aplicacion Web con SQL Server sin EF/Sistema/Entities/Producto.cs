// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Producto
    {

        public int id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Ingrese un precio válido")]
        [Display(Name = "Precio")]
        public double precio { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione proveedor")]
        [Display(Name = "Proveedor")]
        public int id_proveedor { get; set; }

        public string fecha_registro { get; set; }

        public Proveedor proveedor { get; set; }

        public Producto()
        {
            proveedor = new Proveedor();
        }

    }

}
