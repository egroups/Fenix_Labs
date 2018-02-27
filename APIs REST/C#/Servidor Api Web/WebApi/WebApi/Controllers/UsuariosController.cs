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
    public class UsuariosController : ApiController
    {
        private sistemaEntities db = new sistemaEntities();

        // GET api/Usuarios
        public IEnumerable<UsuarioModel> Getusuarios()
        {
            List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();
            foreach (var usuario in db.usuarios)
            {
                UsuarioModel usuarioModel = new UsuarioModel();
                usuarioModel.id_usuario = usuario.id_usuario;
                usuarioModel.usuario = usuario.usuario;
                usuarioModel.clave = usuario.clave;
                usuarioModel.tipo = Convert.ToInt32(usuario.tipo);
                usuarioModel.fecha_registro = usuario.fecha_registro;
                listaUsuarios.Add(usuarioModel);
            }
            IEnumerable<UsuarioModel> usuarios = listaUsuarios;
            return usuarios;
        }

        // GET api/Usuarios/5
        [ResponseType(typeof(usuarios))]
        public IHttpActionResult Getusuarios(int id)
        {
            UsuarioModel usuarioModel = new UsuarioModel();
            usuarios usuarios = db.usuarios.Find(id);
            usuarioModel.id_usuario = usuarios.id_usuario;
            usuarioModel.usuario = usuarios.usuario;
            usuarioModel.clave = usuarios.clave;
            usuarioModel.tipo = Convert.ToInt32(usuarios.tipo);
            usuarioModel.fecha_registro = usuarios.fecha_registro;
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarioModel);
        }

        // PUT api/Usuarios/5
        public IHttpActionResult Putusuarios(int id, usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.id_usuario)
            {
                return BadRequest();
            }

            db.Entry(usuarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuariosExists(id))
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

        // POST api/Usuarios
        [ResponseType(typeof(usuarios))]
        public IHttpActionResult Postusuarios(usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.usuarios.Add(usuarios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuarios.id_usuario }, usuarios);
        }

        // DELETE api/Usuarios/5
        [ResponseType(typeof(usuarios))]
        public IHttpActionResult Deleteusuarios(int id)
        {
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            db.usuarios.Remove(usuarios);
            db.SaveChanges();

            return Ok(usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool usuariosExists(int id)
        {
            return db.usuarios.Count(e => e.id_usuario == id) > 0;
        }
    }
}