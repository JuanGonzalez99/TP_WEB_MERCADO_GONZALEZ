using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace AccesoDatos
{
    public class DireccionDTO
    {

        public int Direccionid { get; set; }
        public int Provinciaid { get; set; }
        public int Localidadid { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int Piso { get; set; }


        //Devuelve todas las direcciones
        public List<DireccionDTO> GetDirecciones()
        {

            using (var db = new ModelContexto())
            {
                return (
                    from dir in db.Direccion
                    select new DireccionDTO
                    {
                        Direccionid = dir.Direccionid,
                        Provinciaid = dir.Provinciaid,
                        Localidadid = dir.Localidadid,
                        Calle = dir.Calle,
                        Altura = dir.Altura,
                        Piso = dir.Piso
                    }).ToList();
            }
        }

        // Devuelve 1 direccion dependiendo del ID que se pase
        public DireccionDTO GetDireccion(int direccionid)
        {
            DireccionDTO DireccionRetorno = new DireccionDTO();
            using (var db = new ModelContexto())
            {

                var query = from dir in db.Direccion
                            select new DireccionDTO
                            {
                                Direccionid = dir.Direccionid,
                                Provinciaid = dir.Provinciaid,
                                Localidadid = dir.Localidadid,
                                Calle = dir.Calle,
                                Altura = dir.Altura,
                                Piso = dir.Piso
                            };
                List<DireccionDTO> direccion = query.ToList<DireccionDTO>();
                foreach (var foo in direccion)
                {
                    if (foo.Direccionid == direccionid)
                    {
                        DireccionRetorno = (DireccionDTO)foo;
                    }
                }
                return DireccionRetorno;
            }
        }
        // Doy de alta direccion 
        public int addDireccion()
        {
            Direccion direccion = new Direccion
            {
                Altura = this.Altura,
                Calle = this.Calle,
                Piso = this.Piso,
                Localidadid = this.Localidadid,
                Provinciaid = this.Provinciaid
            };
            using (var db = new ModelContexto())
            {
                db.Direccion.Add(direccion);
                db.SaveChanges();
                var query = from dir in db.Direccion
                            orderby dir.Direccionid descending
                            select dir;
                direccion = query.FirstOrDefault<Direccion>();
                return direccion.Direccionid;

            }
        }

        //borro una direccion por ID return true si lo borre, false si aun existe
        public bool deleteDirreccion()
        {
            Direccion direccion = new Direccion();
            direccion.Direccionid = this.Direccionid;
            direccion.Altura = this.Altura;
            direccion.Calle = this.Calle;
            direccion.Piso = this.Piso;
            direccion.Localidadid = this.Localidadid;
            direccion.Provinciaid = this.Provinciaid;
            using (var db = new ModelContexto())
            {
                db.Direccion.Attach(direccion);
                db.Direccion.Remove(direccion);
                db.SaveChanges();
                var query = from dir in db.Direccion
                            orderby dir.Direccionid descending
                            where dir.Direccionid == direccion.Direccionid
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

        //modifico el direccion devuelve true si se logro cambiar
        public bool ModifyDireccion()
        {
            Direccion direccion = new Direccion();
            direccion.Direccionid = this.Direccionid;
            direccion.Altura = this.Altura;
            direccion.Calle = this.Calle;
            direccion.Piso = this.Piso;
            direccion.Localidadid = this.Localidadid;
            direccion.Provinciaid = this.Provinciaid;
            using (var db = new ModelContexto())
            {
                db.Direccion.Attach(direccion);
                db.Entry(direccion).Property("Altura").IsModified = true;
                db.Entry(direccion).Property("Calle").IsModified = true;
                db.Entry(direccion).Property("Piso").IsModified = true;
                db.Entry(direccion).Property("Localidadid").IsModified = true;
                db.Entry(direccion).Property("Provinciaid").IsModified = true;
                db.SaveChanges();
                var query = from dir in db.Direccion
                            orderby dir.Direccionid descending
                            where dir.Direccionid == direccion.Direccionid
                            select dir;
                direccion = query.FirstOrDefault<Direccion>();
                if (direccion.Altura == this.Altura && direccion.Calle == this.Calle &&
                    direccion.Piso == this.Piso && direccion.Provinciaid == this.Provinciaid &&
                    direccion.Direccionid == this.Direccionid && direccion.Localidadid == this.Localidadid
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
