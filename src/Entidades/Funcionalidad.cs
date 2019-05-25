using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class Funcionalidad
    {
        public Int32 idFuncion { get; set; }
        public String descFuncion { get; set; }

        public Funcionalidad(Int32 id, String desc)
        {
            this.idFuncion = id;
            this.descFuncion = desc;
        }
    }
}
