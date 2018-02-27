using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistema.Clases
{
    public class Productos
    {
        int id_producto;
        string nombre_producto;
        string descripcion;
        double precio;
        string fecha_registro;
        int id_proveedor;

        public int pId_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }

        public string pNombre_producto
        {
            get { return nombre_producto; }
            set { nombre_producto = value; }
        }

        public string pDescripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public double pPrecio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string pFecha_registro
        {
            get { return fecha_registro; }
            set { fecha_registro = value; }
        }

        public int pId_proveedor
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        public Productos()
        {
            id_producto = 0;
            nombre_producto = "";
            descripcion = "";
            precio = 0;
            fecha_registro = "";
            id_proveedor = 0;
        }

        public Productos(int id_producto, string nombre_producto, string descripcion, double precio, string fecha_registro, int id_proveedor)
        {
            this.id_producto = id_producto;
            this.nombre_producto = nombre_producto;
            this.descripcion = descripcion;
            this.precio = precio;
            this.fecha_registro = fecha_registro;
            this.id_proveedor = id_proveedor;
        }

        public string ToString()
        {
            return "[+] ID Producto : " + id_producto + "\n" +
                "[+] Nombre producto : " + nombre_producto + "\n" +
                "[+] Descripcion : " + descripcion + "\n" +
                "[+] Precio : " + precio + "\n" +
                "[+] ID Proveedor : " + id_proveedor + "\n" +
                "[+] Fecha registro : " + fecha_registro;
        }

    }
}