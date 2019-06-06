using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class TopCruceros
    {
        [System.ComponentModel.DisplayName("codCrucero")]
        public Int32 codCrucero { get; set; }
        [System.ComponentModel.DisplayName("Identificador")]
        public String identificador { get; set; }
        [System.ComponentModel.DisplayName("Fabricante")]
        public String fabricante { get; set; }
        [System.ComponentModel.DisplayName("Modelo")]
        public String modelo { get; set; }
        [System.ComponentModel.DisplayName("Dias Fuera de Servicio")]
        public Int32 dias_fuera_servicio { get; set; }

        public TopCruceros(Int32 codCrucero, String identificador, String fabricante, String modelo, Int32 dias_fuera_servicio)
        {
            this.codCrucero = codCrucero;
            this.identificador = identificador;
            this.fabricante = fabricante;
            this.modelo = modelo;
            this.dias_fuera_servicio = dias_fuera_servicio;
        }

    }
}
