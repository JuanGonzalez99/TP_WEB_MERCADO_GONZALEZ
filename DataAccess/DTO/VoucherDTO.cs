using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace AccesoDatos
{
    public class VoucherDTO
    {
        public int IdVoucher { get; set; }
        public string CodigoPromocional { get; set; } // Se genera Fecha+horaMinutosSegundos+IdVoucher
        public bool Estado { get; set; } // 0 no valido 1 usado

        private ModelContexto db = new ModelContexto();

        //retorna 0 si el codigo promocional existe disponible y lo carga en el objeto
        //retorna 1 si el codigo promocional ya ha sido utilizado y lo carga en el objeto
        //retorna 2 si el codigo promocional no existe carga objeto en 0
        public int GetVoucherByCode()
        {
            using (db)
            {
                var query = from Voucher in db.Voucher select Voucher;
                List<Voucher> voucher = query.ToList<Voucher>();
                foreach (var foo in voucher)
                {
                    if (foo.CodigoPromocional == this.CodigoPromocional)
                    {
                        this.IdVoucher = foo.IdVoucher;
                        this.CodigoPromocional = foo.CodigoPromocional;
                        this.Estado = foo.Estado;
                        if(this.Estado == false)
                        {
                            return 0;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }            
            }
            IdVoucher = 0;
            CodigoPromocional = "0";
            Estado = false;
            return 2;
        }

        public int GetVoucherById()
        {
            using (db)
            {
                var query = from Voucher in db.Voucher select Voucher;
                List<Voucher> voucher = query.ToList<Voucher>();
                foreach (var foo in voucher)
                {
                    if (foo.IdVoucher == this.IdVoucher)
                    {
                        this.IdVoucher = foo.IdVoucher;
                        this.CodigoPromocional = foo.CodigoPromocional;
                        this.Estado = foo.Estado;
                        if (this.Estado == false)
                        {
                            return 0;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
            }
            IdVoucher = 0;
            CodigoPromocional = "0";
            Estado = false;
            return 2;
        }

        //Cambia a Usado el Voucher retorna true si el cambio fue correto
        //retorna false si hubo error en el cambio
        public bool ChangeStatus() {
            Voucher voucher = new Voucher();
            voucher.IdVoucher = this.IdVoucher;
            voucher.CodigoPromocional = this.CodigoPromocional;
            voucher.Estado = true;
            using (db)
            {
                db.Voucher.Attach(voucher);
                db.Entry(voucher).Property("Estado").IsModified = true;
                db.SaveChanges();
                var query = from dir in db.Voucher
                            orderby dir.IdVoucher descending
                            where dir.IdVoucher == voucher.IdVoucher
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

    }
}
