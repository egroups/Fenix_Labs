//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sistema.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class proveedores
    {
        public proveedores()
        {
            this.productos = new HashSet<productos>();
        }
    
        public int id_proveedor { get; set; }
        public string nombre_empresa { get; set; }
        public string direccion { get; set; }
        public Nullable<int> telefono { get; set; }
        public string fecha_registro_proveedor { get; set; }
    
        public virtual ICollection<productos> productos { get; set; }
    }
}
