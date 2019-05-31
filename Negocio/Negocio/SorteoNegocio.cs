using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Negocio
{
    public class SorteoNegocio
    {
        public int IdSorteo { get; set; }
        private PremioDTO Premio { get; set; }
        private ClientesDTO Cliente { get; set; }
        private VoucherDTO Voucher { get; set; }

        public int clienteid { get; set; }
        public int premioid { get; set; }
        public int voucherid { get; set; }

        public int AgregaSorteo()
        {
            try
            {
                Premio.IdPremio = this.premioid;
                Cliente.Clienteid = this.clienteid;
                Voucher.IdVoucher = this.voucherid;
                
                
                if ((Premio.GetPremioByID()) && (Cliente.GetClientByID()) && (Voucher.GetVoucherByCode()==0))
                {
                    SorteoDTO sorteo = new SorteoDTO();
                    sorteo.Cliente = this.Cliente;
                    sorteo.Premio = this.Premio;
                    sorteo.Voucher = this.Voucher;
                    this.IdSorteo = sorteo.addSorteo();
                    if (this.IdSorteo != -1)
                    {
                        return IdSorteo;
                    }
                }
            }
            catch (Exception ex)
            {

                return -1;
            }


            return -1;
        }
    }
}
