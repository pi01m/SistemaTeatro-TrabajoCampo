using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Cliente_DNI853 : IVerificable
    {
        public string DNI_C { get; set; }
        public string Nombre_C { get; set; }
        public string Apellido_C { get; set; }
        public string CorreoElectronico_C { get; set; }
        public string Telefono_C { get; set; }
        public string Direccion_C { get; set; }

        public BE_Cliente_DNI853() { }

        public string ObtenerIdentificadorFila()
        {
            return this.DNI_C;
        }

        public string ObtenerCadenaParaHash()
        {
            return $"{DNI_C}|{Nombre_C}|{Apellido_C}|{CorreoElectronico_C}|{Telefono_C}|{Direccion_C}";
        }

        public override string ToString()
        {
            return $"{Nombre_C} {Apellido_C} - {DNI_C}";
        }
    }
}
