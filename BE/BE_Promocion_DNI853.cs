using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Promocion_DNI853 : IVerificable
    {
        public string IdPromo_DNI853 { get; set; }
        public string NombrePromo_DNI853 { get; set; }
        public string TipoPromo_DNI853 { get; set; }
        public decimal ValorDescuento_DNI853 { get; set; }
        public DateTime FechaInicio_DNI853 { get; set; }
        public DateTime FechaFin_DNI853 { get; set; }
        public string EstadoPromo_DNI853 { get; set; }

        public BE_Promocion_DNI853() { }

        public string ObtenerIdentificadorFila()
        {
            return this.IdPromo_DNI853;
        }

        public string ObtenerCadenaParaHash()
        {
            string fechaInicioStr_DNI853 = FechaInicio_DNI853.ToString("yyyy-MM-dd");
            string fechaFinStr_DNI853 = FechaFin_DNI853.ToString("yyyy-MM-dd");

            return $"{IdPromo_DNI853}|{NombrePromo_DNI853}|{TipoPromo_DNI853}|{ValorDescuento_DNI853}|{fechaInicioStr_DNI853}|{fechaFinStr_DNI853}|{EstadoPromo_DNI853}";
        }

        public override string ToString()
        {
            return NombrePromo_DNI853;
        }
    }
}
