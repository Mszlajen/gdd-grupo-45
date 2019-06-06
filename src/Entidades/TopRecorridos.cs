using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class TopRecorridos
    {
        [System.ComponentModel.DisplayName("codRecorrido")]
        public Int32 idRecorrido { get; set; }
        [System.ComponentModel.DisplayName("Estado")]
        public Boolean estado { get; set; }
        [System.ComponentModel.DisplayName("PasajesVendidos")]
        public Int32 pasajesVendidos { get; set; }

        public TopRecorridos(Int32 idRecorrido, Boolean estado, Int32 pasajesVendidos)
        {
            this.idRecorrido = idRecorrido;
            this.estado = estado;
            this.pasajesVendidos = pasajesVendidos;
        }

    }
}
