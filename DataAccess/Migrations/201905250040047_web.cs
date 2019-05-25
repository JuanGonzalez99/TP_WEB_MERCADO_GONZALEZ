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
                        Cliente_Clienteid = c.Int(),
                        Premio_IdPremio = c.Int(),
                        Voucher_IdVoucher = c.Int(),
                    })
                .PrimaryKey(t => t.IdSorteo)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Clienteid)
                .ForeignKey("dbo.Premios", t => t.Premio_IdPremio)
                .ForeignKey("dbo.Voucher", t => t.Voucher_IdVoucher)
                .Index(t => t.Cliente_Clienteid)
                .Index(t => t.Premio_IdPremio)
                .Index(t => t.Voucher_IdVoucher);
            
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
            DropForeignKey("dbo.Sorteo", "Voucher_IdVoucher", "dbo.Voucher");
            DropForeignKey("dbo.Sorteo", "Premio_IdPremio", "dbo.Premios");
            DropForeignKey("dbo.Sorteo", "Cliente_Clienteid", "dbo.Clientes");
            DropIndex("dbo.Sorteo", new[] { "Voucher_IdVoucher" });
            DropIndex("dbo.Sorteo", new[] { "Premio_IdPremio" });
            DropIndex("dbo.Sorteo", new[] { "Cliente_Clienteid" });
            DropTable("dbo.Voucher");
            DropTable("dbo.Sorteo");
            DropTable("dbo.Premios");
            DropTable("dbo.Clientes");
        }
    }
}
