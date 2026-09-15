using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Funcion_DNI853 : IVerificable
    {
        public string IdFuncion_DNI853 { get; set; }
        public string IdObra_DNI853 { get; set; }
        public string IdSala_DNI853 { get; set; }
        public DateTime Fecha_DNI853 { get; set; }
        public string HoraInicio_DNI853 { get; set; }
        public string HoraFinalizacion_DNI853 { get; set; }
        public string Estado_DNI853 { get; set; }

        public BE_Funcion_DNI853() { }

        public string ObtenerIdentificadorFila()
        {
            return this.IdFuncion_DNI853;
        }

        public string ObtenerCadenaParaHash()
        {
            // Formateamos la fecha de manera consistente para el cálculo del hash (ej: yyyy-MM-dd)
            string fechaFormateada_DNI853 = Fecha_DNI853.ToString("yyyy-MM-dd");
            return $"{IdFuncion_DNI853}|{IdObra_DNI853}|{IdSala_DNI853}|{fechaFormateada_DNI853}|{HoraInicio_DNI853}|{HoraFinalizacion_DNI853}|{Estado_DNI853}";
        }

        public override string ToString()
        {
            return $"{IdFuncion_DNI853} - {Fecha_DNI853.ToShortDateString()} {HoraInicio_DNI853}";
        }


    }
}
