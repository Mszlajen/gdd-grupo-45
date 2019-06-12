using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    class TopRecorridosLibres
    {
        [System.ComponentModel.DisplayName("codRecorrido")]
        public Int32 idRecorrido { get; set; }
        [System.ComponentModel.DisplayName("Estado")]
        public Boolean estado { get; set; }
        [System.ComponentModel.DisplayName("MaxCabinasLibres")]
        public Int32 cabinasLibres { get; set; }

        public TopRecorridosLibres(Int32 idRecorrido, Boolean estado, Int32 cabinasLibres)
        {
            this.idRecorrido = idRecorrido;
            this.estado = estado;
            this.cabinasLibres = cabinasLibres;
        }

    }
}
