﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class Puertos
    {
        [System.ComponentModel.DisplayName("codPuerto")]
        public Int32 codPuerto { get; set; }
        [System.ComponentModel.DisplayName("NombrePuerto")]
        public String nombrePuerto { get; set; }
        [System.ComponentModel.DisplayName("EstadoPuerto")]
        public Boolean estado { get; set; }

        public Puertos(Int32 codPuerto, String nombrePuerto, Boolean estado)
        {
            this.codPuerto = codPuerto;
            this.nombrePuerto = nombrePuerto;
            this.estado = estado;
        }

        public override string ToString()
        {
            return nombrePuerto;
        }
    }
}
