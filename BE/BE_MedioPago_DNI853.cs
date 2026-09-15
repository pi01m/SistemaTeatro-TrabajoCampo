using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_MedioPago_DNI853:IVerificable
    {
        public string IdMedioPago_DNI853 { get; set; }
        public string Nombre_MedioPago_DNI853 { get; set; }

        public BE_MedioPago_DNI853() { }

        public string ObtenerIdentificadorFila()
        {
            return this.IdMedioPago_DNI853;
        }

        public string ObtenerCadenaParaHash()
        {
            return $"{IdMedioPago_DNI853}|{Nombre_MedioPago_DNI853}";
        }

        public override string ToString()
        {
            return Nombre_MedioPago_DNI853; // Esto hace que el ComboBox muestre el nombre automáticamente
        }
    }
}
