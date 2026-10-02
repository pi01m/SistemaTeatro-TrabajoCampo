using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Carrito_DNI853
    {
        private BindingList<BE_Entrada_DNI853> listaCarrito_DNI853;

        public BLL_Carrito_DNI853()
        {
            listaCarrito_DNI853 = new BindingList<BE_Entrada_DNI853>();
        }

        public BindingList<BE_Entrada_DNI853> ObtenerCarrito_DNI853()
        {
            return listaCarrito_DNI853;
        }

        public void AgregarItem_DNI853(BE_Entrada_DNI853 item_DNI853)
        {
            listaCarrito_DNI853.Add(item_DNI853);
        }

        public void QuitarItem_DNI853(BE_Entrada_DNI853 item_DNI853)
        {
            listaCarrito_DNI853.Remove(item_DNI853);
        }

        public void LimpiarCarrito_DNI853()
        {
            listaCarrito_DNI853.Clear();
        }

        public int ObtenerCantidadItems_DNI853()
        {
            return listaCarrito_DNI853.Count;
        }

        public decimal CalcularTotalSinDescuento_DNI853()
        {
            return listaCarrito_DNI853.Sum(item_DNI853 => item_DNI853.Subtotal_DNI853);
        }

        public void AgregarItem_DNI853(string idFuncion, string idSector, string nombreObra, DateTime fechaFunc, string horaInicio, string nombreSector, string cantidadStr, decimal precioSector, int disponibilidadActual)
        {
            // 1. Validaciones básicas de formato y obligatoriedad
            if (!int.TryParse(cantidadStr, out int cantidad_DNI853) || cantidad_DNI853 <= 0)
                throw new Exception("err_CantidadValida");

            if (string.IsNullOrWhiteSpace(idFuncion) || string.IsNullOrWhiteSpace(idSector))
                throw new Exception("err_FuncionSectorObligatorios");

            // 2. Invocación de la regla de negocio específica para el stock/disponibilidad
            ValidarDisponibilidad_DNI853(cantidad_DNI853, disponibilidadActual);

            // 3. Armado del detalle y de la BE
            string detalleFormateado_DNI853 = $"Obra: {nombreObra} | Func: {fechaFunc.ToShortDateString()} {horaInicio}hs | Sector: {nombreSector}";

            BE_Entrada_DNI853 nuevoItem_DNI853 = new BE_Entrada_DNI853
            {
                IdFuncion_DNI853 = idFuncion,
                IdSector_DNI853 = idSector,
                Detalle_DNI853 = detalleFormateado_DNI853,
                Cantidad_DNI853 = cantidad_DNI853,
                PrecioUnitario_DNI853 = precioSector
            };

            listaCarrito_DNI853.Add(nuevoItem_DNI853);
        }

        // para verificar la disponibilidad
        private void ValidarDisponibilidad_DNI853(int cantidad, int disponibilidadActual)
        {
            if (cantidad > disponibilidadActual)
                throw new Exception("err_SuperaDisponibilidad");
        }
    }
}
