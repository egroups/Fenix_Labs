// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductosController : ApiController
    {
        private sistemaEntities db = new sistemaEntities();

        // GET api/Productos
        public IEnumerable<ProductoModel> Getproductos()
        {
            List<ProductoModel> listaProductos = new List<ProductoModel>();
            foreach (var producto in db.productos)
            {
                ProductoModel productoModel = new ProductoModel();
                productoModel.id_producto = producto.id_producto;
                productoModel.nombre_producto = producto.nombre_producto;
                productoModel.descripcion = producto.descripcion;
                productoModel.precio = Convert.ToInt32(producto.precio);
                productoModel.id_proveedor = Convert.ToInt32(producto.id_proveedor);
                productoModel.fecha_registro = producto.fecha_registro;
                listaProductos.Add(productoModel);
            }
            IEnumerable<ProductoModel> productos = listaProductos;
            return productos;
            //return db.productos;
        }

        // GET api/Productos/5
        [ResponseType(typeof(productos))]
        public IHttpActionResult Getproductos(int id)
        {
            ProductoModel productoModel = new ProductoModel();

            productos productos = db.productos.Find(id);

            productoModel.id_producto = productos.id_producto;
            productoModel.nombre_producto = productos.nombre_producto;
            productoModel.descripcion = productos.descripcion;
            productoModel.precio = Convert.ToInt32(productos.precio);
            productoModel.id_proveedor = Convert.ToInt32(productos.id_proveedor);
            productoModel.fecha_registro = productos.fecha_registro;

            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productoModel);
        }

        // PUT api/Productos/5
        public IHttpActionResult Putproductos(int id, productos productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productos.id_producto)
            {
                return BadRequest();
            }

            db.Entry(productos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Productos
        [ResponseType(typeof(productos))]
        public IHttpActionResult Postproductos(productos productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.productos.Add(productos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productos.id_producto }, productos);
        }

        // DELETE api/Productos/5
        [ResponseType(typeof(productos))]
        public IHttpActionResult Deleteproductos(int id)
        {
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return NotFound();
            }

            db.productos.Remove(productos);
            db.SaveChanges();

            return Ok(productos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool productosExists(int id)
        {
            return db.productos.Count(e => e.id_producto == id) > 0;
        }
    }
}