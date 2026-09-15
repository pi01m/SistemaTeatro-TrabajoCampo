using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Sector_DNI853 : IVerificable
    {
        public string IdSector_DNI853 { get; set; }
        public string IdSala_DNI853 { get; set; }
        public string NombreSector_DNI853 { get; set; }
        public string Ubicacion_DNI853 { get; set; }
        public int Capacidad_DNI853 { get; set; }
        public decimal Precio_DNI853 { get; set; } // <--- NUEVA PROPIEDAD DE PRECIO

        public BE_Sector_DNI853() { }

        public string ObtenerIdentificadorFila()
        {
            return this.IdSector_DNI853;
        }

        public string ObtenerCadenaParaHash()
        {
            // Incluimos el precio en el cálculo del dígito verificador
            return $"{IdSector_DNI853}|{IdSala_DNI853}|{NombreSector_DNI853}|{Ubicacion_DNI853}|{Capacidad_DNI853}|{Precio_DNI853}";
        }

        public override string ToString()
        {
            return NombreSector_DNI853;
        }
    }
}
