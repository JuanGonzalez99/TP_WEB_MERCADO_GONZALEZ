using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Negocio
{
    public class VoucherNegocio
    {
        public int IdVoucher { get; set; }
        public string CodigoPromocional { get; set; } // Se genera Fecha+horaMinutosSegundos+IdVoucher
        public bool Estado { get; set; } // 1 = usado

        //retorna 0 si el codigo promocional existe disponible y lo carga en el objeto
        //retorna 1 si el codigo promocional ya ha sido utilizado y lo carga en el objeto
        //retorna 2 si el codigo promocional no existe carga objeto en 0
        // retorna -1 error base o de logica
        public int ValidoCodigo()
        {

            if (this.CodigoPromocional != "")
            {
                try
                {
                    VoucherDTO voucher = new VoucherDTO();
                    voucher.CodigoPromocional = this.CodigoPromocional;
                    int aux = voucher.GetVoucherByCode();
                    if (aux == 0)
                    {
                        this.IdVoucher = voucher.IdVoucher;
                        this.CodigoPromocional = voucher.CodigoPromocional;
                        this.Estado = voucher.Estado;
                        return aux;
                    }
                    else if (aux == 1)
                    {
                        this.IdVoucher = voucher.IdVoucher;
                        this.CodigoPromocional = voucher.CodigoPromocional;
                        this.Estado = voucher.Estado;
                        return aux;
                    }
                    else
                    {
                        // No existe codigo
                        return aux;
                    }
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }


            return -1;
        }

    }
}
