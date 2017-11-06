using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCarcel.Models
{
    public class CondenaDelito
    {
        public int Id { get; set; }
        public Condena Condenas { get; set; }
        public int CondenaId { get; set; }
        public Delito Delitos { get; set; }
        public int DelitoId { get; set; }

        public CondenaDelito()
        {

        }

    }
}