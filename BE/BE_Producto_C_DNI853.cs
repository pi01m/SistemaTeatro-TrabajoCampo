using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Producto_C_DNI853
    {
        public int IdCambio_DNI853 { get; set; }
        public string IdProducto_DNI853 { get; set; }
        public DateTime Fecha_DNI853 { get; set; }
        public TimeSpan Hora_DNI853 { get; set; }
        public string NombreProducto_DNI853 { get; set; }
        public string Categoria_DNI853 { get; set; }
        public decimal Precio_DNI853 { get; set; }
        public int Stock_DNI853 { get; set; }
        public bool Act_DNI853 { get; set; }

        public BE_Producto_C_DNI853() { }

        public override string ToString()
        {
            return $"{IdProducto_DNI853} - {NombreProducto_DNI853}";
        }
    }
}
