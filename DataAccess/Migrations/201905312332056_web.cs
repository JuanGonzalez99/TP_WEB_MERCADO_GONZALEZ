namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class web : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Clienteid = c.Int(nullable: false, identity: true),
                        Documento = c.String(nullable: false, maxLength: 20),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Apellido = c.String(nullable: false, maxLength: 100),
                        Localidad = c.String(maxLength: 50),
                        Provincia = c.String(maxLength: 50),
                        Direccion = c.String(maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Clienteid);
            
            CreateTable(
                "dbo.Premios",
                c => new
                    {
                        IdPremio = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        URL = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.IdPremio);
            
            CreateTable(
                "dbo.Sorteo",
                c => new
                    {
                        IdSorteo = c.Int(nullable: false, identity: true),
                        IdPremio = c.Int(nullable: false),
                        Clienteid = c.Int(nullable: false),
                        IdVoucher = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSorteo)
                .ForeignKey("dbo.Clientes", t => t.Clienteid, cascadeDelete: true)
                .ForeignKey("dbo.Premios", t => t.IdPremio, cascadeDelete: true)
                .ForeignKey("dbo.Voucher", t => t.IdVoucher, cascadeDelete: true)
                .Index(t => t.IdPremio)
                .Index(t => t.Clienteid)
                .Index(t => t.IdVoucher);
            
            CreateTable(
                "dbo.Voucher",
                c => new
                    {
                        IdVoucher = c.Int(nullable: false, identity: true),
                        CodigoPromocional = c.String(nullable: false, maxLength: 100),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdVoucher);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sorteo", "IdVoucher", "dbo.Voucher");
            DropForeignKey("dbo.Sorteo", "IdPremio", "dbo.Premios");
            DropForeignKey("dbo.Sorteo", "Clienteid", "dbo.Clientes");
            DropIndex("dbo.Sorteo", new[] { "IdVoucher" });
            DropIndex("dbo.Sorteo", new[] { "Clienteid" });
            DropIndex("dbo.Sorteo", new[] { "IdPremio" });
            DropTable("dbo.Voucher");
            DropTable("dbo.Sorteo");
            DropTable("dbo.Premios");
            DropTable("dbo.Clientes");
        }
    }
}
