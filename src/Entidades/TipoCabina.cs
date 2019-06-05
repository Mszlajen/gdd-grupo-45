using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class TipoCabina
    {
        public Int32 codTipo { get; set; }
        public Decimal valor { get; set; }
        public String nombre { get; set; }

        public TipoCabina(Int32 codTipo, Decimal valor, String nombre)
        {
            this.codTipo = codTipo;
            this.valor = valor;
            this.nombre = nombre;
        }

        public override string ToString()
        {
            return this.nombre + "(" + (this.valor * 100 - 100).ToString() + "%)";
        }
    }
}
