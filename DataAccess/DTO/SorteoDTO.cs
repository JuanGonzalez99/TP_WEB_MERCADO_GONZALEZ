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
        public PremioDTO Premio { get; set; }
        public ClientesDTO Cliente { get; set; }
        public VoucherDTO Voucher { get; set; }

        private ModelContexto db = new ModelContexto();

        // Si se agrega el sorteo devuelve el id de ese sorteo, si no te devuelvo -1
        public int addSorteo()
        {
            Sorteo sorteo = new Sorteo();
            sorteo.Premio.IdPremio = this.Premio.IdPremio;
            sorteo.Cliente.Clienteid = this.Cliente.Clienteid;
            sorteo.Voucher.IdVoucher = this.Voucher.IdVoucher;
            using (db)
            {
                db.Sorteo.Add(sorteo);
                db.SaveChanges();
                var query = from dir in db.Sorteo
                            orderby dir.IdSorteo descending
                            where  dir.Premio.IdPremio == sorteo.Premio.IdPremio
                            && dir.Cliente.Clienteid == sorteo.Cliente.Clienteid
                            && dir.Voucher.IdVoucher == sorteo.Voucher.IdVoucher
                            select dir;
                sorteo = query.FirstOrDefault<Sorteo>();

                if ( sorteo.Premio.IdPremio == this.Premio.IdPremio
                    && sorteo.Cliente.Clienteid == this.Cliente.Clienteid
                    && sorteo.Voucher.IdVoucher == this.Voucher.IdVoucher)
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
