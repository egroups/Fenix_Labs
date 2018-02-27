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
    public class ProveedoresController : ApiController
    {
        private sistemaEntities db = new sistemaEntities();

        // GET api/Proveedores
        public IEnumerable<ProveedorModel> Getproveedores()
        {
            List<ProveedorModel> listaProveedores = new List<ProveedorModel>();
            foreach (var proveedor in db.proveedores)
            {
                ProveedorModel proveedorModel = new ProveedorModel();
                proveedorModel.id_proveedor = proveedor.id_proveedor;
                proveedorModel.nombre_empresa = proveedor.nombre_empresa;
                proveedorModel.telefono = Convert.ToInt32(proveedor.telefono);
                proveedorModel.direccion = proveedor.direccion;
                proveedorModel.fecha_registro_proveedor = proveedor.fecha_registro_proveedor;
                listaProveedores.Add(proveedorModel);
            }
            IEnumerable<ProveedorModel> proveedores = listaProveedores;
            return proveedores;
        }

        // GET api/Proveedores/5
        [ResponseType(typeof(proveedores))]
        public IHttpActionResult Getproveedores(int id)
        {
            ProveedorModel proveedorModel = new ProveedorModel();
            proveedores proveedores = db.proveedores.Find(id);
            proveedorModel.id_proveedor = proveedores.id_proveedor;
            proveedorModel.nombre_empresa = proveedores.nombre_empresa;
            proveedorModel.telefono = Convert.ToInt32(proveedores.telefono);
            proveedorModel.direccion = proveedores.direccion;
            proveedorModel.fecha_registro_proveedor = proveedores.fecha_registro_proveedor;
            if (proveedores == null)
            {
                return NotFound();
            }

            return Ok(proveedorModel);
        }

        // PUT api/Proveedores/5
        public IHttpActionResult Putproveedores(int id, proveedores proveedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proveedores.id_proveedor)
            {
                return BadRequest();
            }

            db.Entry(proveedores).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!proveedoresExists(id))
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

        // POST api/Proveedores
        [ResponseType(typeof(proveedores))]
        public IHttpActionResult Postproveedores(proveedores proveedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.proveedores.Add(proveedores);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proveedores.id_proveedor }, proveedores);
        }

        // DELETE api/Proveedores/5
        [ResponseType(typeof(proveedores))]
        public IHttpActionResult Deleteproveedores(int id)
        {
            proveedores proveedores = db.proveedores.Find(id);
            if (proveedores == null)
            {
                return NotFound();
            }

            db.proveedores.Remove(proveedores);
            db.SaveChanges();

            return Ok(proveedores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool proveedoresExists(int id)
        {
            return db.proveedores.Count(e => e.id_proveedor == id) > 0;
        }
    }
}