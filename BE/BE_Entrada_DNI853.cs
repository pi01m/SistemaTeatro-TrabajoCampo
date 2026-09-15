using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{ 
    public class BE_Entrada_DNI853: IVerificable
    {
        public string Id_Entrada_DNI853 { get; set; }
        public string Id_Factura_DNI853 { get; set; }
        public string IdFuncion_DNI853 { get; set; }
        public string IdSector_DNI853 { get; set; }
        public string Detalle_DNI853 { get; set; }
        public int Cantidad_DNI853 { get; set; } 
        public decimal PrecioUnitario_DNI853 { get; set; }

        public decimal Subtotal_DNI853
        {
            get { return Cantidad_DNI853 * PrecioUnitario_DNI853; }
        }

        public BE_Entrada_DNI853() { }

        public string ObtenerIdentificadorFila()
        {
            return this.Id_Entrada_DNI853.ToString();
        }

        public string ObtenerCadenaParaHash()
        {
            return $"{Id_Entrada_DNI853}|{Id_Factura_DNI853}|{IdFuncion_DNI853}|{IdSector_DNI853}|{Detalle_DNI853}|{Cantidad_DNI853}|{PrecioUnitario_DNI853}";
        }
    }
}
