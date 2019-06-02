using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class Pasaje
    {
        public Int32 cod_pasaje { get; private set; }
        public Int32 cod_cliente { get; private set; }
        public Int32 cod_viaje { get; private set; }
        public Nullable<Int32> cod_pago { get; private set; }
        public Decimal costo { get; private set; }

        public Pasaje(Int32 cod_pasaje, Int32 cod_cliente, Int32 cod_viaje, Nullable<Int32> cod_pago, Decimal costo)
        {
            this.costo = costo;
            this.cod_cliente = cod_cliente;
            this.cod_pago = cod_pago;
            this.cod_pasaje = cod_pasaje;
            this.cod_viaje = cod_viaje;
        }

    }
}
