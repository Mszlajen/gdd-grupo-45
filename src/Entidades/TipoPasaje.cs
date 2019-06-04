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
        public Int32 codPasaje { get; protected set; }
        public Pasaje pasaje()
        {
            return new SQL.SqlPasaje().buscarPasaje(codPasaje);
        }
    }
}
