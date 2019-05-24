using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace AccesoDatos
{
    public class TelefonoDTO
    {

        public int Telefonoid { get; set; }
        public string numeroCasa { get; set; }
        public string numeroCelular { get; set; }

        //Alta de telefono devuelve id si es correcto
        public int addTelefono()
        {
            Telefono telefono = new Telefono();
            telefono.numeroCasa = this.numeroCasa;
            telefono.numeroCelular = this.numeroCelular;
            using (var db = new ModelContexto())
            {
                db.Telefono.Add(telefono);
                db.SaveChanges();
                var query = from dir in db.Telefono
                            orderby dir.Telefonoid descending
                            where dir.numeroCelular == this.numeroCelular && dir.numeroCasa == this.numeroCasa
                            select dir;
                telefono = query.FirstOrDefault<Telefono>();
                return telefono.Telefonoid;
            }
        }

        //borro un telefono por ID return true si lo borre, false si aun existe
        public bool deleteTelefono()
        {
            Telefono telefono = new Telefono();
            telefono.Telefonoid = this.Telefonoid;
            telefono.numeroCasa = this.numeroCasa;
            telefono.numeroCelular = this.numeroCelular;
            using (var db = new ModelContexto())
            {
                db.Telefono.Attach(telefono);
                db.Telefono.Remove(telefono);
                db.SaveChanges();
                var query = from dir in db.Telefono
                            orderby dir.Telefonoid descending
                            where dir.Telefonoid == telefono.Telefonoid
                            select dir;
                if (!query.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //modifico el telefono
        public bool ModifyTelefono()
        {
            Telefono telefono = new Telefono();
            telefono.Telefonoid = this.Telefonoid;
            telefono.numeroCasa = this.numeroCasa;
            telefono.numeroCelular = this.numeroCelular;
            using (var db = new ModelContexto())
            {
                db.Telefono.Attach(telefono);
                db.Entry(telefono).Property("numeroCasa").IsModified = true;
                db.Entry(telefono).Property("numeroCelular").IsModified = true;
                db.SaveChanges();
                var query = from dir in db.Telefono
                            orderby dir.Telefonoid descending
                            where dir.Telefonoid == telefono.Telefonoid
                            select dir;
                telefono = query.FirstOrDefault<Telefono>();
                if (telefono.numeroCasa == this.numeroCasa && telefono.numeroCelular == this.numeroCelular)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public List<TelefonoDTO> GetTelefonos()
        {

            using (var db = new ModelContexto())
            {
                return (
                    from dir in db.Telefono
                    select new TelefonoDTO
                    {
                        Telefonoid = dir.Telefonoid,
                        numeroCasa = dir.numeroCasa,
                        numeroCelular = dir.numeroCelular
                    }).ToList();
            }
        }

        // Devuelve 1 telefono dependiendo del ID que se pase
        public TelefonoDTO GetTelefono(int telefonoid)
        {
            TelefonoDTO telefonoRetorno = new TelefonoDTO();
            using (var db = new ModelContexto())
            {

                var query = from dir in db.Telefono
                            select new TelefonoDTO
                            {
                                Telefonoid = dir.Telefonoid,
                                numeroCasa = dir.numeroCasa,
                                numeroCelular = dir.numeroCelular
                            };
                List<TelefonoDTO> direccion = query.ToList<TelefonoDTO>();
                foreach (var foo in direccion)
                {
                    if (foo.Telefonoid == telefonoid)
                    {
                        telefonoRetorno = (TelefonoDTO)foo;
                    }
                }
                return telefonoRetorno;
            }
        }
    }
}
