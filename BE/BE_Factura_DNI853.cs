using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Factura_DNI853: IVerificable
    {
        public string Id_Factura_DNI853 { get; set; }
        public string DNI_C_DNI853 { get; set; }
        public decimal ImporteTotal_DNI853 { get; set; }
        public string TipoPago_DNI853 { get; set; }
        public string Banco_DNI853 { get; set; }
        public string NumeroTarjeta_DNI853 { get; set; }
        public string FechaVencimiento_DNI853 { get; set; }
        public DateTime Fecha_DNI853 { get; set; }
        public string Vendedor_DNI853 { get; set; }
        public string IdPromocion_DNI853 { get; set; } 

        public BE_Factura_DNI853() { }

        public string ObtenerIdentificadorFila()
        {
            return this.Id_Factura_DNI853.ToString();
        }

        public string ObtenerCadenaParaHash()
        {
            return $"{Id_Factura_DNI853}|{DNI_C_DNI853}|{ImporteTotal_DNI853}|{TipoPago_DNI853}|{Banco_DNI853}|{NumeroTarjeta_DNI853}|{FechaVencimiento_DNI853}|{Fecha_DNI853:yyyy-MM-dd}|{Vendedor_DNI853}|{IdPromocion_DNI853}";
        }
    }
}
