using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class Tramos
    {
        [System.ComponentModel.DisplayName("codRecorrido")]
        public Int32 codRecorrido { get; set; }
        [System.ComponentModel.DisplayName("nroTramo")]
        public Byte nroTramo { get; set; }
        [System.ComponentModel.DisplayName("puertoSalida")]
        public Int32 puertoSalida { get; set; }
        [System.ComponentModel.DisplayName("puertoLlegada")]
        public Int32 puertoLlegada { get; set; }
        [System.ComponentModel.DisplayName("costoTramo")]
        public Decimal costoTramo { get; set; }

        public Tramos(Int32 codRecorrido, Byte nroTramo, Int32 puertoSalida, Int32 puertoLlegada, Decimal costoTramo)
        {
            this.codRecorrido = codRecorrido;
            this.nroTramo = nroTramo;
            this.puertoSalida = puertoSalida;
            this.puertoLlegada = puertoLlegada;
            this.costoTramo = costoTramo;
        }

        public Tramos(Byte nroTramo, Int32 puertoSalida, Int32 puertoLlegada, Decimal costoTramo)
        {
            this.nroTramo = nroTramo;
            this.puertoSalida = puertoSalida;
            this.puertoLlegada = puertoLlegada;
            this.costoTramo = costoTramo;
        }



    }
}
