using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class CrucerosDisponibles
    {
        [System.ComponentModel.DisplayName("codCrucero")]
        public Int32 codCrucero { get; set; }
        [System.ComponentModel.DisplayName("Identificador")]
        public String identificador { get; set; }
        [System.ComponentModel.DisplayName("fechaAlta")]
        public DateTime fechaAlta { get; set; }

        public CrucerosDisponibles(Int32 codCrucero, String identificador, DateTime fechaAlta)
        {
            this.codCrucero = codCrucero;
            this.identificador = identificador;
            this.fechaAlta = fechaAlta;
        }

        public CrucerosDisponibles(Int32 codCrucero, String identificador)
        {
            this.codCrucero = codCrucero;
            this.identificador = identificador;
        }
    }
}
