using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio;

namespace BE
{
    public class BE_Sala_DNI853: IVerificable
    {
        public string IdSala_DNI853 { get; set; } 
        public string NombreSala_DNI853 { get; set; }
        public string Ubicacion_DNI853 { get; set; }
        public int Capacidad_DNI853 { get; set; }

        public BE_Sala_DNI853() { }

        public string ObtenerIdentificadorFila()
        {
            return this.IdSala_DNI853;
        }

        public string ObtenerCadenaParaHash()
        {
            return $"{IdSala_DNI853}|{NombreSala_DNI853}|{Ubicacion_DNI853}|{Capacidad_DNI853}";
        }

        public override string ToString()
        {
            return NombreSala_DNI853;
        }
    }
}
