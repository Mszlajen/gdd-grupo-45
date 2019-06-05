using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class Crucero
    {
        public Int32 codCrucero { get; set; }
        [System.ComponentModel.DisplayName("Identificador")]
        public String identificador { get; set; }
        [System.ComponentModel.DisplayName("fecha de alta")]
        public Nullable<DateTime> fechaAlta { get; set; }
        public Int32 codMarca { get; private set; }
        public Int32 codModelo { get; private set; }
        public Int32 codFabricante { get; private set; }
        public Int32 codServicio { get; private set; }

        public Crucero(Int32 codCrucero, String identificador, DateTime fechaAlta)
        {
            this.codCrucero = codCrucero;
            this.identificador = identificador;
            this.fechaAlta = fechaAlta;
        }

        public Crucero(Int32 codCrucero, String identificador)
        {
            this.codCrucero = codCrucero;
            this.identificador = identificador;
        }

        public Crucero(Int32 codCrucero, String identificador, Nullable<DateTime> fechaAlta, Int32 codMarca, Int32 codModelo, Int32 codFabricante, Int32 codServicio)
        {
            this.codCrucero = codCrucero;
            this.identificador = identificador;
            this.fechaAlta = fechaAlta;
            this.codFabricante = codFabricante;
            this.codMarca = codMarca;
            this.codModelo = codModelo;
            this.codServicio = codServicio;
        }

        public Marca marca()
        {
            return new SQL.SqlInfoCrucero().getMarca(this.codMarca);
        }

        public Fabricante fabricante()
        {
            return new SQL.SqlInfoCrucero().getFabricante(this.codFabricante);
        }

        public Servicio servicio()
        {
            return new SQL.SqlInfoCrucero().getServicio(this.codServicio);
        }

        public Modelo modelo()
        {
            return new SQL.SqlInfoCrucero().getModelo(this.codModelo);
        }
    }
}
