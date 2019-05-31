using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    class Cabina
    {
        [System.ComponentModel.DisplayName("codCabina")]
        public Int32 codCabina { get; set; }
        [System.ComponentModel.DisplayName("codCrucero")]
        public Int32 codCrucero { get; set; }
        [System.ComponentModel.DisplayName("numero")]
        public Decimal numero { get; set; }
        [System.ComponentModel.DisplayName("codTipo")]
        public Int32 codTipo { get; set; }
        [System.ComponentModel.DisplayName("piso")]
        public Decimal piso { get; set; }

        public Cabina(Int32 codCabina, Int32 codCrucero, Decimal numero, Int32 codTipo, Decimal piso)
        {
            this.codCabina = codCabina;
            this.codCrucero = codCrucero;
            this.numero = numero;
            this.codTipo = codTipo;
            this.piso = piso;
        }

        public TipoCabina tipoCabina()
        {
            return (new SQL.SqlCabinas()).getTipoCabina(this.codTipo);
        }
    }
}
