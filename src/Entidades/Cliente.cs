using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Entidades
{
    public class Cliente
    {
        [System.ComponentModel.DisplayName("idCliente")]
        public Int32 idCliente { get; set; }
        [System.ComponentModel.DisplayName("nombre")]
        public String nombre { get; set; }
        [System.ComponentModel.DisplayName("apellido")]
        public String apellido { get; set; }
        [System.ComponentModel.DisplayName("dni")]
        public Decimal dni { get; set; }
        [System.ComponentModel.DisplayName("direccion")]
        public String direccion { get; set; }
        [System.ComponentModel.DisplayName("telefono")]
        public Int32 telefono { get; set; }
        [System.ComponentModel.DisplayName("mail")]
        public String mail { get; set; }
        [System.ComponentModel.DisplayName("nacimiento")]
        public DateTime nacimiento { get; set; }

        public Boolean tieneNacimiento { get; set; }

        public Cliente(Int32 idCliente, String nombre, String apellido, Decimal dni, String direccion, Int32 telefono, String mail, DateTime fechaNacimiento,  Boolean tieneNacimiento) 
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.direccion = direccion;
            this.telefono = telefono;
            this.mail = mail;
            this.nacimiento = nacimiento;
            this.tieneNacimiento = tieneNacimiento;
        }

    }
}
