using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sistema.Models
{

    public class BuscadorModel
    {
        [Display(Name = "nombre_buscar")]
        public string nombre_buscar { get; set; }
    }

    public class CambiarUsuarioModel
    {

        [Required]
        [Display(Name = "Nombre de usuario")]
        public string nombre_usuario { get; set; }

        [Required]
        [Display(Name = "Password actual")]
        public string password { get; set; }

        [Required]
        [Display(Name = "Nuevo nombre de usuario")]
        public string nuevo_usuario { get; set; }

    }

    public class CambiarPasswordModel
    {

        [Required]
        [Display(Name = "Nombre de usuario")]
        public string nombre_usuario { get; set; }

        [Required]
        [Display(Name = "Password actual")]
        public string password { get; set; }

        [Required]
        [Display(Name = "Nuevo password")]
        public string nuevo_password { get; set; }

    }

    public class ProveedorModel
    {

        public int id_proveedor { get; set; }

        [Required] 
        [Display(Name = "Nombre de empresa")] 
        public string nombre_empresa { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string direccion { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public int telefono { get; set; } 

    }

    public class ProductoModel
    {

        public int id_producto { get; set; }

        [Required]
        [Display(Name = "Nombre producto")]
        public string nombre_producto { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public int precio { get; set; }

        [Required]
        [Display(Name = "Proveedor")]
        public int id_proveedor { get; set; }

    }

    public class UsuarioModel
    {

        public int id_usuario { get; set; }

        [Required]
        [Display(Name = "Nombre de usuario")]
        public string nombre_usuario { get; set; }

        [Required]
        [Display(Name = "Password actual")]
        public string password { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public int tipo { get; set; }

    }

    public class AsignarUsuarioModel
    {

        public int id_usuario { get; set; }

        [Required]
        [Display(Name = "Nombre de usuario")]
        public string nombre_usuario { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public int tipo { get; set; }

    }

}