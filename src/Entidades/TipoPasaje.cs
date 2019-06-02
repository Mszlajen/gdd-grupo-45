using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public abstract class TipoPasaje
    {
        public Int32 id { get; set; }
        public String tipo { get; protected set; }
        abstract public Pasaje pasaje();
    }
}
