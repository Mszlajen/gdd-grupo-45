using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class Rol
    {
        [System.ComponentModel.DisplayName("idRol")]
        public Int32 idRol { get; set; }
        [System.ComponentModel.DisplayName("Descripcion")]
        public String desc { get; set; }
        public List<Funcionalidad> funcionalidades { get; set; }
        [System.ComponentModel.DisplayName("Estado")]
        public Boolean estado { get; set; }
        [System.ComponentModel.DisplayName("Registrable")]
        public Boolean registrable { get; set; }

        public Rol(Int32 idRol, Boolean estado, Boolean registrable, String desc, List<Funcionalidad> func)
        {
            this.idRol = idRol;
            this.desc = desc;
            this.estado = estado;
            this.registrable = registrable;
            this.funcionalidades = func;
        }

        public Rol(Boolean estado, Boolean registrable, String desc, List<Funcionalidad> func)
        {
            this.desc = desc;
            this.estado = estado;
            this.registrable = registrable;
            this.funcionalidades = func;
        }
    }
}
