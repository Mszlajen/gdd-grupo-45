using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class Recorridos
    {
        [System.ComponentModel.DisplayName("codRecorrido")]
        public Int32 idRecorrido { get; set; }
        [System.ComponentModel.DisplayName("Estado")]
        public Boolean estado { get; set; }
        public List<Tramos> tramos { get; set; }

        public Recorridos(Int32 idRecorrido, Boolean estado, List<Tramos> tramos)
        {
            this.idRecorrido = idRecorrido;
            this.estado = estado;
            this.tramos = tramos;
        }

    }
}
