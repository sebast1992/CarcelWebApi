using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCarcel.Models;

namespace WebApiCarcel.Controllers
{
    public class PresoController : ApiController
    {
        private CarcelDBContext context;

        public PresoController()
        {
            this.context = new CarcelDBContext();
        }

        public IEnumerable<Object> get()
        {
            return context.Presos.ToList();
        }

        public IHttpActionResult get(int id)
        {
            Preso preso = context.Presos.Find(id);

            if (preso == null)
            {
                return NotFound();
            }
            return Ok(preso);
        }

        public IHttpActionResult post(Preso preso)
        {
            context.Presos.Add(preso);
            int filasAfectadas = context.SaveChanges();
            if (filasAfectadas == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Agregado correctamente" });
        }

        public IHttpActionResult delete(int id)
        {
            Preso preso = context.Presos.Find(id);
            if (preso == null) return NotFound();
            context.Presos.Remove(preso);
            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }
            return InternalServerError();
        }

        public IHttpActionResult put(Preso preso)
        {
            context.Entry(preso).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();
        }
    }
}
