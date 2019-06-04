using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class Pago : TipoPasaje
    {
        public String hashCard { get; private set; }
        public String lastDigits { get; private set; }
        public String securityCode { get; private set; }
        public DateTime fecha { get; private set; }
        public Int32 codMedio { get; private set; }

        public Pago(Int32 id, String hash_card, String last_digits, String security_code, DateTime fecha, Int32 cod_pasaje, Int32 cod_medio)
        {
            this.id = id;
            this.hashCard = hash_card;
            this.lastDigits = last_digits;
            this.securityCode = security_code;
            this.fecha = fecha;
            this.codPasaje = cod_pasaje;
            this.codMedio = cod_medio;
            this.tipo = "Compra";
        }
    }
}
