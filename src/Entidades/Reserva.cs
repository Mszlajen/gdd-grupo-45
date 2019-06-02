using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    class Reserva : TipoPasaje
    {
        public Int32 codPasaje { get; private set; }
        public DateTime fechaReserva { get; private set; }

        public Reserva(Int32 codReserva, Int32 codPasaje, DateTime fechaReserva)
        {
            this.id = codReserva;
            this.codPasaje = codPasaje;
            this.fechaReserva = fechaReserva;
            this.tipo = "Reserva";
        }

        override public Pasaje pasaje()
        {
            return new SQL.SqlPasaje().buscarPasaje(codPasaje);
        }
    }
}
