using BE;
using BLL.BLL_Servicio;
using DAL;
using Servicio;
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
        private BindingList<BE_ItemCarrito_DNI853> listaCarritoProducto_DNI853;
        private BindingList<BE_Entrada_DNI853> listaCarrito_DNI853;
        
        private DAL_Carrito_DNI853 objDalCantina_DNI853;
        private BLL_BitacoraEvento objBitacora_DNI853;
        private BLL_DigitoVerificador objDigitoVerificador_DNI853;
        private DAL_Producto_DNI853 dalProducto;
        private BLL_Producto_DNI853 bllProducto;
        public BLL_Carrito_DNI853() 
        {
            listaCarrito_DNI853 = new BindingList<BE_Entrada_DNI853>();
            listaCarritoProducto_DNI853 = new BindingList<BE_ItemCarrito_DNI853>(); 
            objDalCantina_DNI853 = new DAL_Carrito_DNI853();
            objBitacora_DNI853 = new BLL_BitacoraEvento();
            objDigitoVerificador_DNI853 = new BLL_DigitoVerificador();
            dalProducto = new DAL_Producto_DNI853();
            bllProducto = new BLL_Producto_DNI853();
        }

        //ENTRADAS
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

       
        private void ValidarDisponibilidad_DNI853(int cantidad, int disponibilidadActual)
        {
            if (cantidad > disponibilidadActual)
                throw new Exception("err_SuperaDisponibilidad");
        }


        //PRODUCTOS
        public string ConfirmarPedido_DNI853(string dniCliente)
        {
            if (listaCarritoProducto_DNI853.Count == 0)
                throw new Exception("err_CarritoVacio");

            if (string.IsNullOrWhiteSpace(dniCliente))
                throw new Exception("err_DniClienteObligatorio");

            var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
            string idVendedor = usuarioActual != null ? usuarioActual.Login : "Sistema";
            string idPedido = "PED_" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper();

            BE_Pedido_DNI853 nuevoPedido = new BE_Pedido_DNI853
            {
                IdPedido_DNI853 = idPedido,
                DNI_C_DNI853 = dniCliente,
                IdVendedor_DNI853 = idVendedor,
                FechaVenta_DNI853 = DateTime.Now,
                HoraVenta_DNI853 = DateTime.Now.ToString("HH:mm:ss"),
                ImporteTotal_DNI853 = CalcularTotal_DNI853(),
                Estado_Venta_DNI853 = "PendientePago",
                Items_DNI853 = listaCarritoProducto_DNI853.ToList()
            };

            // Guardar en base de datos mediante la DAL
            bool resultado = objDalCantina_DNI853.GuardarPedidoCantina_DNI853(nuevoPedido);
            
            if (resultado)
            {
                // Actualizar Dígitos Verificadores y registrar en la Bitácora del sistema
                List<BE_Pedido_DNI853> listaCompleta = objDalCantina_DNI853.ListarPedidosCantina_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(nuevoPedido, listaCompleta, "PedidoCantina_DNI853");

                objBitacora_DNI853.RegistrarBitacora(
                    "Registro de Pedido de Cantina",
                    idVendedor,
                    "Gestión Cantina",
                    2);
            }

            return idPedido;
        }

       
        public List<BE_Producto_DNI853> ListarProductos_DNI853()
        { 
            return bllProducto.ListarProductos_DNI853();
        }

        public decimal CalcularImporteTotal_DNI853()
        {
            return CalcularTotal_DNI853();
        }
         
        public decimal CalcularTotal_DNI853()
        {
            return listaCarritoProducto_DNI853.Sum(item_DNI853 => item_DNI853.Subtotal_DNI853);
        }
        public void AgregarItem_DNI853(string idProducto_DNI853, string nombreProducto_DNI853, decimal precio_DNI853, int stock_DNI853, string cantidadStr)
        {
            if (!int.TryParse(cantidadStr, out int cantidad_DNI853) || cantidad_DNI853 <= 0)
                throw new Exception("err_CantidadValida");

            if (string.IsNullOrWhiteSpace(idProducto_DNI853)) 
                throw new Exception("err_ProductoObligatorio");

            ValidarDisponibilidad_DNI853(cantidad_DNI853, stock_DNI853);

            var itemExistente = listaCarritoProducto_DNI853.FirstOrDefault(i => i.IdProducto_DNI853 == idProducto_DNI853);
            if (itemExistente != null)
            {
                if ((itemExistente.CantidadSolicitada_DNI853 + cantidad_DNI853) > stock_DNI853)
                    throw new Exception("err_SuperaStockDisponible");

                itemExistente.CantidadSolicitada_DNI853 += cantidad_DNI853;
                listaCarritoProducto_DNI853.ResetBindings();
            }
            else
            {
                BE_ItemCarrito_DNI853 nuevoItem_DNI853 = new BE_ItemCarrito_DNI853
                {
                    IdItem_DNI853 = "ITEM_" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper(),
                    IdProducto_DNI853 = idProducto_DNI853,
                    NombreProducto_DNI853 = nombreProducto_DNI853,
                    CantidadSolicitada_DNI853 = cantidad_DNI853,
                    PrecioUnitario_DNI853 = precio_DNI853
                };

                listaCarritoProducto_DNI853.Add(nuevoItem_DNI853);
            }
        }

        public void QuitarItemProducto_DNI853(BE_ItemCarrito_DNI853 item)
        {
            if (item != null)
            {
                listaCarritoProducto_DNI853.Remove(item);
            }
        }

        public void LimpiarCarritoProducto_DNI853()
        {
            listaCarritoProducto_DNI853.Clear();
        }

        public BindingList<BE_ItemCarrito_DNI853> ObtenerCarritoProducto_DNI853()
        {
            return listaCarritoProducto_DNI853;
        }

        public List<BE_Pedido_DNI853> ListarPedidosCantina_DNI853()
        {
            // Puente hacia la DAL para que la UI obtenga los pedidos sin conectarse a datos
            return objDalCantina_DNI853.ListarPedidosConItemCantina_DNI853();
        }
         
        public void ActualizarEstadoPedido_DNI853(string idPedido, string nuevoEstado)
        {
            // Llama a la DAL para cambiar el estado (ej: de "PendientePago" a "Pagado")
            objDalCantina_DNI853.ActualizarEstadoPedido_DNI853(idPedido, nuevoEstado);

            // Recalcular dígitos verificadores porque se modificó un registro en la BD
            List<BE_Pedido_DNI853> listaCompleta = objDalCantina_DNI853.ListarPedidosCantina_DNI853();

            // Buscamos el pedido modificado en la lista para pasarlo al DV
            BE_Pedido_DNI853 pedidoModificado = listaCompleta.FirstOrDefault(p => p.IdPedido_DNI853 == idPedido);
            if (pedidoModificado != null)
            {
                objDigitoVerificador_DNI853.ActualizarDigitos(pedidoModificado, listaCompleta, "PedidoCantina_DNI853");
                var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
                string loginVendedor = usuarioActual != null ? usuarioActual.Login : "Sistema";

                objBitacora_DNI853.RegistrarBitacora(
                    $"Estado de pedido actualizado",
                    loginVendedor,
                    "Gestión Cantina",
                    2);
            }
        }

        public void DescontarStockProductos_DNI853(List<BE_ItemCarrito_DNI853> itemsVendidos)
        {
           
            List<BE_Producto_DNI853> listaProductos = bllProducto.ListarProductos_DNI853();

            foreach (var item in itemsVendidos)
            {
                // Buscamos el producto original
                BE_Producto_DNI853 producto = listaProductos.FirstOrDefault(p => p.IdProducto_DNI853 == item.IdProducto_DNI853);

                if (producto != null)
                {
                    // Restamos la cantidad vendida
                    producto.Stock_DNI853 -= item.CantidadSolicitada_DNI853;

                    // Usamos tu método existente que ya maneja DAL, DV y Bitácora
                    bllProducto.ModificarProducto_DNI853(producto);
                }
            }
        }
    }
}
