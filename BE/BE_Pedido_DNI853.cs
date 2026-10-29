using Servicio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Pedido_DNI853:IVerificable
    {
        public string IdPedido_DNI853 { get; set; }
        public string DNI_C_DNI853 { get; set; }
        public string IdVendedor_DNI853 { get; set; }
        public DateTime FechaVenta_DNI853 { get; set; }
        public string HoraVenta_DNI853 { get; set; }
        public decimal ImporteTotal_DNI853 { get; set; }
        public string Estado_Venta_DNI853 { get; set; }
        public List<BE_ItemCarrito_DNI853> Items_DNI853 { get; set; } = new List<BE_ItemCarrito_DNI853>();

        public BE_Pedido_DNI853() { }

        public string ObtenerIdentificadorFila()
        {
            return this.IdPedido_DNI853;
        }

        public string ObtenerCadenaParaHash()
        {
            string totalFormat = ImporteTotal_DNI853.ToString("0.00", CultureInfo.InvariantCulture);
            return $"{IdPedido_DNI853}|{DNI_C_DNI853}|{IdVendedor_DNI853}|{FechaVenta_DNI853:yyyy-MM-dd}|{HoraVenta_DNI853}|{totalFormat}|{Estado_Venta_DNI853}";
        }
    }
}
