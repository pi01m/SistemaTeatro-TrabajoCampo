using BE;
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL_Negocio
{
    public class BLL_Producto_C_DNI853
    {
        private DAL_Producto_C_DNI853 objDalBitacora_DNI853;
        private BLL_Producto_DNI853 objBllProducto_DNI853;

        public BLL_Producto_C_DNI853()
        {
            objDalBitacora_DNI853 = new DAL_Producto_C_DNI853();
            objBllProducto_DNI853 = new BLL_Producto_DNI853();
        }

        public List<BE_Producto_C_DNI853> ListarBitacora_DNI853(string codProd_DNI853, string nombre_DNI853, DateTime fechaIni_DNI853, DateTime fechaFin_DNI853)
        {
            return objDalBitacora_DNI853.ListarBitacora_DNI853(codProd_DNI853, nombre_DNI853, fechaIni_DNI853, fechaFin_DNI853);
        }

        public bool ActivarRegistroHistorico_DNI853(BE_Producto_C_DNI853 registroSeleccionado_DNI853)
        {
            if (registroSeleccionado_DNI853 == null)
                throw new Exception("err_SeleccioneRegistroBitacora");

            // Verificar si el producto aún existe en el maestro de productos
            var productosActuales_DNI853 = objBllProducto_DNI853.ListarProductos_DNI853();
            bool existeEnMaestro_DNI853 = productosActuales_DNI853.Any(p => p.IdProducto_DNI853 == registroSeleccionado_DNI853.IdProducto_DNI853);

            BE_Producto_DNI853 productoAActivar_DNI853 = new BE_Producto_DNI853
            {
                IdProducto_DNI853 = registroSeleccionado_DNI853.IdProducto_DNI853,
                NombreProducto_DNI853 = registroSeleccionado_DNI853.NombreProducto_DNI853,
                Categoria_DNI853 = registroSeleccionado_DNI853.Categoria_DNI853,
                Precio_DNI853 = registroSeleccionado_DNI853.Precio_DNI853,
                Stock_DNI853 = registroSeleccionado_DNI853.Stock_DNI853
            };

            if (existeEnMaestro_DNI853)
            {
                // Modifica el producto maestro. Al actualizarlo, SQL Server ejecuta el Trigger,
                // recalcula los Dígitos Verificadores (DVH/DVV) y registra en la Bitácora de Eventos.
                return objBllProducto_DNI853.ModificarProducto_DNI853(productoAActivar_DNI853);
            }
            else
            {
                // Si el producto había sido eliminado físicamente, se reinserta en el maestro.
                return objBllProducto_DNI853.CrearProducto_DNI853(
                    productoAActivar_DNI853.IdProducto_DNI853,
                    productoAActivar_DNI853.NombreProducto_DNI853,
                    productoAActivar_DNI853.Categoria_DNI853,
                    productoAActivar_DNI853.Precio_DNI853.ToString(System.Globalization.CultureInfo.InvariantCulture),
                    productoAActivar_DNI853.Stock_DNI853.ToString()
                );
            }
        }
    }
}
