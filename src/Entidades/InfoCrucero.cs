using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public abstract class InfoCrucero
    {
        public Int32 cod { get; private set; }
        public String nombre { get; private set; }
        public InfoCrucero(Int32 cod, String nombre)
        {
            this.cod = cod;
            this.nombre = nombre;
        }
        override public String ToString()
        {
            return this.nombre;
        }
    }
}
