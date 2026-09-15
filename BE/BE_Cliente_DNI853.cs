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
        public string DNI_C_DNI853 { get; set; }
        public string Nombre_C_DNI853 { get; set; }
        public string Apellido_C_DNI853 { get; set; }
        public string CorreoElectronico_C_DNI853 { get; set; }
        public string Telefono_C_DNI853 { get; set; }
        public string Direccion_C_DNI853 { get; set; }
         
        public BE_Cliente_DNI853() { }

        public string ObtenerIdentificadorFila()
        {
            return this.DNI_C_DNI853;
        }

        public string ObtenerCadenaParaHash()
        {
            return $"{DNI_C_DNI853}|{Nombre_C_DNI853}|{Apellido_C_DNI853}|{CorreoElectronico_C_DNI853}|{Telefono_C_DNI853}|{Direccion_C_DNI853}";
        }

        public override string ToString()
        {
            return $"{Nombre_C_DNI853} {Apellido_C_DNI853} - {DNI_C_DNI853}";
        }
    }
}
