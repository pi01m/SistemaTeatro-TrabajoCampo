using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Sector_C_DNI853
    {
        public int IdCambio_DNI853 { get; set; }
        public string IdSector_DNI853 { get; set; }
        public DateTime Fecha_DNI853 { get; set; }
        public TimeSpan Hora_DNI853 { get; set; }
        public string IdSala_DNI853 { get; set; }
        public string NombreSector_DNI853 { get; set; }
        public string Ubicacion_DNI853 { get; set; }
        public int Capacidad_DNI853 { get; set; }
        public decimal Precio_DNI853 { get; set; }
        public bool Act_DNI853 { get; set; }

        public BE_Sector_C_DNI853() { }

        public override string ToString()
        {
            return $"{IdSector_DNI853} - {NombreSector_DNI853}";
        }
    }
}
