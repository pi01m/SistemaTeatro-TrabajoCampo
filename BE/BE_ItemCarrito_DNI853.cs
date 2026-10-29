using Servicio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_ItemCarrito_DNI853:IVerificable
    {
        public string IdItem_DNI853 { get; set; }
        public string IdPedido_DNI853 { get; set; }
        public string IdProducto_DNI853 { get; set; }
        public string NombreProducto_DNI853 { get; set; }
        public int CantidadSolicitada_DNI853 { get; set; }
        public decimal PrecioUnitario_DNI853 { get; set; }
        public decimal Subtotal_DNI853 => CantidadSolicitada_DNI853 * PrecioUnitario_DNI853;

        public BE_ItemCarrito_DNI853() { }

        public string ObtenerIdentificadorFila()
        {
            return this.IdItem_DNI853;
        }

        public string ObtenerCadenaParaHash()
        {
            string precioFormat = PrecioUnitario_DNI853.ToString("0.00", CultureInfo.InvariantCulture);
            string subtotalFormat = Subtotal_DNI853.ToString("0.00", CultureInfo.InvariantCulture);

            return $"{IdItem_DNI853}|{IdPedido_DNI853}|{IdProducto_DNI853}|{NombreProducto_DNI853}|{CantidadSolicitada_DNI853}|{precioFormat}|{subtotalFormat}";
        }
    }
}
