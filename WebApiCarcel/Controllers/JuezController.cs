﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCarcel.Models;

namespace WebApiCarcel.Controllers
{
    public class JuezController : ApiController
    {
        private CarcelDBContext context;

        public JuezController()
        {
            this.context = new CarcelDBContext();
        }

        public IEnumerable<Object> get()
        {
            return context.Jueces.ToList();
        }

        public IHttpActionResult get(int id)
        {
            Juez juez = context.Jueces.Find(id);

            if (juez == null)
            {
                return NotFound();
            }
            return Ok(juez);
        }

        public IHttpActionResult post(Juez juez)
        {
            context.Jueces.Add(juez);
            int filasAfectadas = context.SaveChanges();
            if (filasAfectadas == 0)
            {
                return InternalServerError();
            }
            return Ok(new { mensaje = "Agregado correctamente" });
        }

        public IHttpActionResult delete(int id)
        {
            Juez juez = context.Jueces.Find(id);
            if (juez == null) return NotFound();
            context.Jueces.Remove(juez);
            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }
            return InternalServerError();
        }

        public IHttpActionResult put(Juez juez)
        {
            context.Entry(juez).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();
        }
    }
}
