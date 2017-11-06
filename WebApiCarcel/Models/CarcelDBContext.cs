using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApiCarcel.Models
{
    public class CarcelDBContext : DbContext
    {
        public DbSet<Juez> Jueces { get; set; }
        public DbSet<Preso> Presos { get; set; }
        public DbSet<Condena> Condenas { get; set; }
        public DbSet<CondenaDelito> CondenaDelito { get; set; }
        public DbSet<Delito> Delitos { get; set; }

    }
}