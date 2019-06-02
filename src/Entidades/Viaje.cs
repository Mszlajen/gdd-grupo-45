using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class Viaje
    {
        [System.ComponentModel.DisplayName("idViaje")]
        public Int32 idViaje { get; set; }
        [System.ComponentModel.DisplayName("fechaInicio")]
        public DateTime fechaInicio { get; set; }
        [System.ComponentModel.DisplayName("fechaLlegada")]
        public DateTime fechaLlegada { get; set; }
        [System.ComponentModel.DisplayName("codRecorrido")]
        public Int32 codRecorrido { get; set; }
        [System.ComponentModel.DisplayName("codCrucero")]
        public Int32 codCrucero { get; set; }
        [System.ComponentModel.DisplayName("retorna")]
        public bool retorna { get; set; }
        [System.ComponentModel.DisplayName("razonCancelacion")]
        public String razonCancelacion { get; set; }

        public Viaje(Int32 idViaje, DateTime fechaInicio, DateTime fechaLlegada, Int32 codRecorrido, Int32 codCrucero, bool retorna, String razonCancelacion)
        {
            this.idViaje = idViaje;
            this.fechaInicio = fechaInicio;
            this.fechaLlegada = fechaLlegada;
            this.codRecorrido = codRecorrido;
            this.codCrucero = codCrucero;
            this.retorna = retorna;
            this.razonCancelacion = razonCancelacion;
        }

        public Viaje(Int32 idViaje, DateTime fechaInicio, DateTime fechaLlegada, Int32 codRecorrido, Int32 codCrucero, bool retorna)
        {
            this.idViaje = idViaje;
            this.fechaInicio = fechaInicio;
            this.fechaLlegada = fechaLlegada;
            this.codRecorrido = codRecorrido;
            this.codCrucero = codCrucero;
            this.retorna = retorna;
        }

        public CrucerosDisponibles crucero()
        {
            return (new SQL.SqlCruceros()).getCrucero(this.codCrucero);
        }

        public Recorridos recorrido()
        {
            return (new SQL.SqlRecorridos()).getRecorrido(this.codRecorrido);
        }
    }
}
