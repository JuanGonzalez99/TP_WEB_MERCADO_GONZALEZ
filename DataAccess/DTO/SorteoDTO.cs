using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace AccesoDatos
{
    public class SorteoDTO
    {
        public int IdSorteo { get; set; }

        public Cliente Cliente { get; set; }
        public Premio Premio { get; set; }
        public Voucher Voucher { get; set; }
        public int IdPremio { get; set; }
        public int Clienteid { get; set; }
        public int IdVoucher { get; set; }

        private ModelContexto db = new ModelContexto();

        // Si se agrega el sorteo devuelve el id de ese sorteo, si no te devuelvo -1
        public int addSorteo()
        {
            Sorteo sorteo = new Sorteo();
            sorteo.IdPremio = this.IdPremio;
            sorteo.Clienteid = this.Clienteid;
            sorteo.IdVoucher = this.IdVoucher;
            using (db)
            {
                db.Sorteo.Add(sorteo);
                db.SaveChanges();
                var query = from dir in db.Sorteo
                            orderby dir.IdSorteo descending
                            where  dir.IdPremio == sorteo.IdPremio
                            && dir.Clienteid == sorteo.Clienteid
                            && dir.IdVoucher == sorteo.IdVoucher
                            select dir;
                sorteo = query.FirstOrDefault<Sorteo>();

                if ( sorteo.IdPremio == this.IdPremio
                    && sorteo.Clienteid == this.Clienteid
                    && sorteo.IdVoucher == this.IdVoucher)
                {
                    return sorteo.IdSorteo;
                }
                else
                {
                    return -1;
                }
            }
        }


    }
}
