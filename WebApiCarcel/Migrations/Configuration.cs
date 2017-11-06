namespace WebApiCarcel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApiCarcel.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApiCarcel.Models.CarcelDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApiCarcel.Models.CarcelDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Delitos.AddOrUpdate(d => d.Nombre,
                new Delito { Nombre = "Homicidio", CondenaMinima = 5, CondenaMaxima = 20 },
                new Delito { Nombre = "Femicidio", CondenaMinima = 5, CondenaMaxima = 20 },
                new Delito { Nombre = "Robo con intimidación", CondenaMinima = 1, CondenaMaxima = 12 },
                new Delito { Nombre = "Robo en lugar no habitado", CondenaMinima = 1, CondenaMaxima = 5 },
                new Delito { Nombre = "Cohecho", CondenaMinima = 5, CondenaMaxima = 8 }
                );
        }
    }
}
