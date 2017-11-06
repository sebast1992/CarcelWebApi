using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCarcel.Models;

namespace WebApiCarcel.Controllers
{
    public class CondenaDelitoController : ApiController
    {
        private CarcelDBContext context;

        public CondenaDelitoController()
        {
            this.context = new CarcelDBContext();
        }

        public IEnumerable<Object> get()
        {
            return context.CondenaDelito.Include("Condena").Include("Delito").Select(c => new
            {
                Id = c.Id,
                Condena = new { condenaId = c.CondenaId },
                Delito = new { delitoId = c.DelitoId },
            });
        }

        public IHttpActionResult get(int id)
        {
            CondenaDelito condenaDelito = context.CondenaDelito.Find(id);

            if (condenaDelito == null)
            {
                return NotFound();
            }
            return Ok(condenaDelito);
        }

        public IHttpActionResult post(CondenaDelito condenaDelito)
        {
            context.CondenaDelito.Add(condenaDelito);
            int filasAfectadas = context.SaveChanges();
            if (filasAfectadas == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Agregado correctamente" });
        }

        public IHttpActionResult delete(int id)
        {
            CondenaDelito condenaDelito = context.CondenaDelito.Find(id);
            if (condenaDelito == null) return NotFound();
            context.CondenaDelito.Remove(condenaDelito);
            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }
            return InternalServerError();
        }

        public IHttpActionResult put(CondenaDelito condenaDelito)
        {
            context.Entry(condenaDelito).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }
            return InternalServerError();
        }
    }
}
