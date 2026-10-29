using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Producto_DNI853:IVerificable
    {
        public string IdProducto_DNI853 { get; set; }
        public string NombreProducto_DNI853 { get; set; }
        public string Categoria_DNI853 { get; set; }
        public decimal Precio_DNI853 { get; set; }
        public int Stock_DNI853 { get; set; }

        public BE_Producto_DNI853() { }

        public string ObtenerIdentificadorFila()
        {
            return this.IdProducto_DNI853;
        }

        public string ObtenerCadenaParaHash()
        {
            string precioFormat = Precio_DNI853.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

            return $"{IdProducto_DNI853}|{NombreProducto_DNI853}|{Categoria_DNI853}|{precioFormat}|{Stock_DNI853}";
        }

        public override string ToString()
        {
            return NombreProducto_DNI853;
        }
    }
}
