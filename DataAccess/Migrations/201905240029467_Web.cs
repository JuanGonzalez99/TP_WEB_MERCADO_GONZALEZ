namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Web : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Clienteid = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                        Apellido = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Documento = c.String(nullable: false, maxLength: 100),
                        Direccionid = c.Int(nullable: false),
                        TelefonoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Clienteid)
                .ForeignKey("dbo.Direccion", t => t.Direccionid, cascadeDelete: true)
                .ForeignKey("dbo.Telefono", t => t.TelefonoId, cascadeDelete: true)
                .Index(t => t.Direccionid)
                .Index(t => t.TelefonoId);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        Direccionid = c.Int(nullable: false, identity: true),
                        Provinciaid = c.Int(nullable: false),
                        Localidadid = c.Int(nullable: false),
                        Calle = c.String(nullable: false, maxLength: 50),
                        Altura = c.Int(nullable: false),
                        Piso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Direccionid)
                .ForeignKey("dbo.Localidad", t => t.Localidadid, cascadeDelete: true)
                .ForeignKey("dbo.Provincia", t => t.Provinciaid, cascadeDelete: true)
                .Index(t => t.Provinciaid)
                .Index(t => t.Localidadid);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        Localidadid = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        ProvinciaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Localidadid);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        Provinciaid = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Provinciaid);
            
            CreateTable(
                "dbo.Telefono",
                c => new
                    {
                        Telefonoid = c.Int(nullable: false, identity: true),
                        numeroCasa = c.String(nullable: false, maxLength: 50),
                        numeroCelular = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Telefonoid);
            
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        IdCompra = c.Int(nullable: false, identity: true),
                        CodigoPromocional = c.String(nullable: false, maxLength: 100),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdCompra);
            
            CreateTable(
                "dbo.Premios",
                c => new
                    {
                        IdPremio = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IdPremio);
            
            CreateTable(
                "dbo.Sorteo",
                c => new
                    {
                        IdSorteo = c.Int(nullable: false, identity: true),
                        IdPremios = c.Int(nullable: false),
                        IdClientes = c.Int(nullable: false),
                        IdCompra = c.Int(nullable: false),
                        clientes_Clienteid = c.Int(),
                        premios_IdPremio = c.Int(),
                    })
                .PrimaryKey(t => t.IdSorteo)
                .ForeignKey("dbo.Clientes", t => t.clientes_Clienteid)
                .ForeignKey("dbo.Compra", t => t.IdCompra, cascadeDelete: true)
                .ForeignKey("dbo.Premios", t => t.premios_IdPremio)
                .Index(t => t.IdCompra)
                .Index(t => t.clientes_Clienteid)
                .Index(t => t.premios_IdPremio);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sorteo", "premios_IdPremio", "dbo.Premios");
            DropForeignKey("dbo.Sorteo", "IdCompra", "dbo.Compra");
            DropForeignKey("dbo.Sorteo", "clientes_Clienteid", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "TelefonoId", "dbo.Telefono");
            DropForeignKey("dbo.Clientes", "Direccionid", "dbo.Direccion");
            DropForeignKey("dbo.Direccion", "Provinciaid", "dbo.Provincia");
            DropForeignKey("dbo.Direccion", "Localidadid", "dbo.Localidad");
            DropIndex("dbo.Sorteo", new[] { "premios_IdPremio" });
            DropIndex("dbo.Sorteo", new[] { "clientes_Clienteid" });
            DropIndex("dbo.Sorteo", new[] { "IdCompra" });
            DropIndex("dbo.Direccion", new[] { "Localidadid" });
            DropIndex("dbo.Direccion", new[] { "Provinciaid" });
            DropIndex("dbo.Clientes", new[] { "TelefonoId" });
            DropIndex("dbo.Clientes", new[] { "Direccionid" });
            DropTable("dbo.Sorteo");
            DropTable("dbo.Premios");
            DropTable("dbo.Compra");
            DropTable("dbo.Telefono");
            DropTable("dbo.Provincia");
            DropTable("dbo.Localidad");
            DropTable("dbo.Direccion");
            DropTable("dbo.Clientes");
        }
    }
}
