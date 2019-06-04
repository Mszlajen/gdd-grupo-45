using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class MedioDePago
    {
        public Int32 id { get; private set; }
        public String nombre { get; private set; }
        public MedioDePago(Int32 id, String nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
