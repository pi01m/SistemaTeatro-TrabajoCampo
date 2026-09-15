using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Obra_DNI853 : IVerificable
    {
        public string IdObra_DNI853 { get; set; }
        public string NombreObra_DNI853 { get; set; }
        public string DescripcionObra_DNI853 { get; set; }
        public string Estado_DNI853 { get; set; } // Nuevo campo de estado

        public BE_Obra_DNI853() { }

        public string ObtenerIdentificadorFila()
        {
            return this.IdObra_DNI853;
        }

        public string ObtenerCadenaParaHash()
        {
            // Se incluye el estado en la cadena para que la integridad vertical/horizontal lo contemple
            return $"{IdObra_DNI853}|{NombreObra_DNI853}|{DescripcionObra_DNI853}|{Estado_DNI853}";
        }

        public override string ToString()
        {
            return NombreObra_DNI853;
        }
    }
}
