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
    }
}
