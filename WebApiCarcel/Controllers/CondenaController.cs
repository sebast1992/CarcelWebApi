using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCarcel.Models;

namespace WebApiCarcel.Controllers
{
    public class CondenaController : ApiController
    {
        private CarcelDBContext context;

        public CondenaController()
        {
            this.context = new CarcelDBContext();
        }

        public IEnumerable<Object> get()
        {
            return context.Condenas.Include("Juez").Include("Preso").Select(c => new
            {
                Id = c.Id,
                fechaInicioCondena = c.FechaInicioCondena,
                fechaCondena = c.FechaCondena,
                Preso = new { presoId = c.PresoId },
                Juez = new { juezId = c.JuezId }
            });
        }

        public IHttpActionResult get(int id)
        {
            Condena condena = context.Condenas.Find(id);
            if (condena == null)
            {
                return NotFound();
            }
            return Ok(condena);
        }

        public IHttpActionResult post(Condena condena)
        {
            context.Condenas.Add(condena);
            int filasAfectadas = context.SaveChanges();
            if (filasAfectadas == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Agregado Correctamente" });
        }

        public IHttpActionResult delete(int id)
        {
            Condena condena = context.Condenas.Find(id);
            if (condena == null) return NotFound();
            context.Condenas.Remove(condena);
            if (context.SaveChanges() > 0)
            {
                return Ok(new { mensaje = "Eliminado Correctamente" });
            }
            return InternalServerError();
        }

        public IHttpActionResult put(Condena condena)
        {
            context.Entry(context).State = System.Data.Entity.EntityState.Modified;
            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado Correctamente" });
            }
            return InternalServerError();
        }
    }
}
