using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Entidades;

namespace FrbaCrucero.AbmRecorrido
{
    public interface FormTramos
    {
        void actualizarGrilla();
        List<Tramos> getTramos();
    }
}
