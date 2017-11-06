namespace WebApiCarcel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeraMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CondenaDelitoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CondenaId = c.Int(nullable: false),
                        DelitoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Condenas", t => t.CondenaId, cascadeDelete: true)
                .ForeignKey("dbo.Delitoes", t => t.DelitoId, cascadeDelete: true)
                .Index(t => t.CondenaId)
                .Index(t => t.DelitoId);
            
            CreateTable(
                "dbo.Condenas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicioCondena = c.DateTime(nullable: false),
                        FechaCondena = c.DateTime(nullable: false),
                        PresoId = c.Int(nullable: false),
                        JuezId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Juezs", t => t.JuezId, cascadeDelete: true)
                .ForeignKey("dbo.Presoes", t => t.PresoId, cascadeDelete: true)
                .Index(t => t.PresoId)
                .Index(t => t.JuezId);
            
            CreateTable(
                "dbo.Juezs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Rut = c.String(),
                        Domicilio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Presoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rut = c.String(),
                        Apellido = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Domicilio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Delitoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        CondenaMinima = c.Int(nullable: false),
                        CondenaMaxima = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CondenaDelitoes", "DelitoId", "dbo.Delitoes");
            DropForeignKey("dbo.CondenaDelitoes", "CondenaId", "dbo.Condenas");
            DropForeignKey("dbo.Condenas", "PresoId", "dbo.Presoes");
            DropForeignKey("dbo.Condenas", "JuezId", "dbo.Juezs");
            DropIndex("dbo.Condenas", new[] { "JuezId" });
            DropIndex("dbo.Condenas", new[] { "PresoId" });
            DropIndex("dbo.CondenaDelitoes", new[] { "DelitoId" });
            DropIndex("dbo.CondenaDelitoes", new[] { "CondenaId" });
            DropTable("dbo.Delitoes");
            DropTable("dbo.Presoes");
            DropTable("dbo.Juezs");
            DropTable("dbo.Condenas");
            DropTable("dbo.CondenaDelitoes");
        }
    }
}
