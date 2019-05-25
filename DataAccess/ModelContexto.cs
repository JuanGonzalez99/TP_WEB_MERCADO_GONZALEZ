namespace AccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Dominio;

    public class ModelContexto : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'ModelContexto' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'ClassLibrary1.ModelContexto' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'ModelContexto'  en el archivo de configuración de la aplicación.
        public ModelContexto()
            : base("name=WebContext")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Voucher> Voucher { get; set; }
        public DbSet<Sorteo> Sorteo { get; set; }
        public DbSet<Premio> Premios { get; set; }



        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}