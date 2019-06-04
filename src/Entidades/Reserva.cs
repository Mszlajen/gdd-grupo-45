using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class Reserva : TipoPasaje
    {
        public DateTime fechaReserva { get; private set; }

        public Reserva(Int32 codReserva, Int32 codPasaje, DateTime fechaReserva)
        {
            this.id = codReserva;
            this.codPasaje = codPasaje;
            this.fechaReserva = fechaReserva;
            this.tipo = "Reserva";
        }
    }
}
