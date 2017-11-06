using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCarcel.Models;

namespace WebApiCarcel.Controllers
{
    public class DelitoController : ApiController
    {
        private CarcelDBContext context;

        public DelitoController()
        {
            this.context = new CarcelDBContext();
        }

        public IEnumerable<Object> get()
        {
            return context.Delitos.ToList();
        }

        public IHttpActionResult get(int id)
        {
            Delito delito = context.Delitos.Find(id);

            if (delito == null)
            {
                return NotFound();
            }
            return Ok(delito);
        }

        public IHttpActionResult post(Delito delito)
        {
            context.Delitos.Add(delito);
            int filasAfectadas = context.SaveChanges();
            if (filasAfectadas == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Agregado correctamente" });
        }

        public IHttpActionResult delete(int id)
        {
            Delito delito = context.Delitos.Find(id);
            if (delito == null) return NotFound();
            context.Delitos.Remove(delito);
            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }
            return InternalServerError();
        }

        public IHttpActionResult put(Delito delito)
        {
            context.Entry(delito).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }
            return InternalServerError();
        }
    }
}
