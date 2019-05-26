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
        public Int32 idRol { get; set; }
        [System.ComponentModel.DisplayName("Estado")]
        public Boolean estado { get; set; }
        public List<Tramos> tramos { get; set; }

        public Recorridos(Int32 idRol, Boolean estado, List<Tramos> tramos)
        {
            this.idRol = idRol;
            this.estado = estado;
            this.tramos = tramos;
        }

    }
}
