using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class Servicio_DigitoVerificadorVertical //este en el diagrama de clases llamalo Servicio_DigitoVerificador asi tambien yo lo llame en el diagrama de secuencia
    {
        public string Nombre { get; set; }
        public string DVV { get; set; }
        public string DVH { get; set; }

        // Constructor vacío por defecto
        public Servicio_DigitoVerificadorVertical() { }

        // Constructor que marca el diagrama de secuencia: Crear(DVV, Nombre)
        public Servicio_DigitoVerificadorVertical(string dvv, string nombre)
        {
            this.DVV = dvv;
            this.Nombre = nombre;
            this.DVH = null; // Para el registro maestro, el DVH no se usa
        }

        
    }
}
