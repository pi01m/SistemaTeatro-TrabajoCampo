using BE;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Carrito_DNI853
    {
        private readonly string _connectionString_DNI853 = DAL_ConexionDB.ObtenerCadena();

        // Método para guardar el pedido de cantina usando ADO.NET Desconectado con Transacción
        public bool GuardarPedidoCantina_DNI853(BE_Pedido_DNI853 pedidoParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                conn_DNI853.Open();
                SqlTransaction transaction_DNI853 = conn_DNI853.BeginTransaction();

                try
                {
                    // 1. Guardar Cabecera del Pedido (DataSet + DataAdapter)
                    SqlDataAdapter adapterPedido_DNI853 = new SqlDataAdapter("SELECT * FROM PedidoCantina_DNI853 WHERE 1 = 0", conn_DNI853);
                    adapterPedido_DNI853.SelectCommand.Transaction = transaction_DNI853;
                    DataSet ds_DNI853 = new DataSet();
                    adapterPedido_DNI853.Fill(ds_DNI853, "PedidoCantina");

                    DataRow rowPedido_DNI853 = ds_DNI853.Tables["PedidoCantina"].NewRow();
                    rowPedido_DNI853["IdPedido_DNI853"] = pedidoParam_DNI853.IdPedido_DNI853;
                    rowPedido_DNI853["DNI_C_DNI853"] = pedidoParam_DNI853.DNI_C_DNI853;
                    rowPedido_DNI853["IdVendedor_DNI853"] = pedidoParam_DNI853.IdVendedor_DNI853;
                    rowPedido_DNI853["FechaVenta_DNI853"] = pedidoParam_DNI853.FechaVenta_DNI853;
                    rowPedido_DNI853["HoraVenta_DNI853"] = pedidoParam_DNI853.HoraVenta_DNI853;
                    rowPedido_DNI853["ImporteTotal_DNI853"] = pedidoParam_DNI853.ImporteTotal_DNI853;
                    rowPedido_DNI853["Estado_Venta_DNI853"] = pedidoParam_DNI853.Estado_Venta_DNI853;

                    ds_DNI853.Tables["PedidoCantina"].Rows.Add(rowPedido_DNI853);
                    SqlCommandBuilder builderPedido_DNI853 = new SqlCommandBuilder(adapterPedido_DNI853);
                    adapterPedido_DNI853.Update(ds_DNI853, "PedidoCantina");

                    // 2. Guardar Ítems del Pedido (Detalle)
                    SqlDataAdapter adapterItem_DNI853 = new SqlDataAdapter("SELECT * FROM ItemPedidoCantina_DNI853 WHERE 1 = 0", conn_DNI853);
                    adapterItem_DNI853.SelectCommand.Transaction = transaction_DNI853;
                    adapterItem_DNI853.Fill(ds_DNI853, "ItemPedidoCantina");

                    foreach (var item_DNI853 in pedidoParam_DNI853.Items_DNI853)
                    {
                        DataRow rowItem_DNI853 = ds_DNI853.Tables["ItemPedidoCantina"].NewRow();
                        rowItem_DNI853["IdItem_DNI853"] = item_DNI853.IdItem_DNI853;
                        rowItem_DNI853["IdPedido_DNI853"] = pedidoParam_DNI853.IdPedido_DNI853;
                        rowItem_DNI853["IdProducto_DNI853"] = item_DNI853.IdProducto_DNI853;
                        rowItem_DNI853["NombreProducto_DNI853"] = item_DNI853.NombreProducto_DNI853;
                        rowItem_DNI853["CantidadSolicitada_DNI853"] = item_DNI853.CantidadSolicitada_DNI853;
                        rowItem_DNI853["PrecioUnitario_DNI853"] = item_DNI853.PrecioUnitario_DNI853;
                        rowItem_DNI853["Subtotal_DNI853"] = item_DNI853.Subtotal_DNI853;

                        ds_DNI853.Tables["ItemPedidoCantina"].Rows.Add(rowItem_DNI853);
                    }

                    SqlCommandBuilder builderItem_DNI853 = new SqlCommandBuilder(adapterItem_DNI853);
                    adapterItem_DNI853.Update(ds_DNI853, "ItemPedidoCantina");

                    transaction_DNI853.Commit();
                    return true;
                }
                catch
                {
                    transaction_DNI853.Rollback();
                    throw;
                }
            }
        }

        // Método para listar pedidos (utilizado por el servicio de Dígitos Verificadores)
        public List<BE_Pedido_DNI853> ListarPedidosCantina_DNI853()
        {
            List<BE_Pedido_DNI853> lista_DNI853 = new List<BE_Pedido_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM PedidoCantina_DNI853", conn_DNI853);
                DataTable tabla_DNI853 = new DataTable();
                adapter_DNI853.Fill(tabla_DNI853);

                foreach (DataRow row_DNI853 in tabla_DNI853.Rows)
                {
                    lista_DNI853.Add(new BE_Pedido_DNI853
                    {
                        IdPedido_DNI853 = row_DNI853["IdPedido_DNI853"].ToString(),
                        DNI_C_DNI853 = row_DNI853["DNI_C_DNI853"].ToString(),
                        IdVendedor_DNI853 = row_DNI853["IdVendedor_DNI853"].ToString(),
                        FechaVenta_DNI853 = Convert.ToDateTime(row_DNI853["FechaVenta_DNI853"]),
                        HoraVenta_DNI853 = row_DNI853["HoraVenta_DNI853"].ToString(),
                        ImporteTotal_DNI853 = Convert.ToDecimal(row_DNI853["ImporteTotal_DNI853"]),
                        Estado_Venta_DNI853 = row_DNI853["Estado_Venta_DNI853"].ToString()
                    });
                }
            }
            return lista_DNI853;
        }

        public List<BE_Pedido_DNI853> ListarPedidosConItemCantina_DNI853()
        {
            List<BE_Pedido_DNI853> lista_DNI853 = new List<BE_Pedido_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                conn_DNI853.Open();

                // 1. Traer todos los pedidos (cabecera)
                SqlDataAdapter adapterPedido_DNI853 = new SqlDataAdapter("SELECT * FROM PedidoCantina_DNI853", conn_DNI853);
                DataTable tablaPedido_DNI853 = new DataTable();
                adapterPedido_DNI853.Fill(tablaPedido_DNI853);

                // 2. Traer todos los ítems de detalle de una sola vez
                SqlDataAdapter adapterItem_DNI853 = new SqlDataAdapter("SELECT * FROM ItemPedidoCantina_DNI853", conn_DNI853);
                DataTable tablaItem_DNI853 = new DataTable();
                adapterItem_DNI853.Fill(tablaItem_DNI853);

                foreach (DataRow row_DNI853 in tablaPedido_DNI853.Rows)
                {
                    string idPedido = row_DNI853["IdPedido_DNI853"].ToString();

                    // Filtrar los ítems correspondientes a este pedido
                    var itemsPedido = tablaItem_DNI853.AsEnumerable()
                        .Where(r => r["IdPedido_DNI853"].ToString() == idPedido)
                        .Select(r => new BE_ItemCarrito_DNI853
                        {
                            IdItem_DNI853 = r["IdItem_DNI853"].ToString(),
                            IdPedido_DNI853 = r["IdPedido_DNI853"].ToString(),
                            IdProducto_DNI853 = r["IdProducto_DNI853"].ToString(),
                            NombreProducto_DNI853 = r["NombreProducto_DNI853"].ToString(),
                            CantidadSolicitada_DNI853 = Convert.ToInt32(r["CantidadSolicitada_DNI853"]),
                            PrecioUnitario_DNI853 = Convert.ToDecimal(r["PrecioUnitario_DNI853"])
                        }).ToList();

                    lista_DNI853.Add(new BE_Pedido_DNI853
                    {
                        IdPedido_DNI853 = idPedido,
                        DNI_C_DNI853 = row_DNI853["DNI_C_DNI853"].ToString(),
                        IdVendedor_DNI853 = row_DNI853["IdVendedor_DNI853"].ToString(),
                        FechaVenta_DNI853 = Convert.ToDateTime(row_DNI853["FechaVenta_DNI853"]),
                        HoraVenta_DNI853 = row_DNI853["HoraVenta_DNI853"].ToString(),
                        ImporteTotal_DNI853 = Convert.ToDecimal(row_DNI853["ImporteTotal_DNI853"]),
                        Estado_Venta_DNI853 = row_DNI853["Estado_Venta_DNI853"].ToString(),
                        Items_DNI853 = itemsPedido // <--- ¡Aquí se asignan los productos correctamente!
                    });
                }
            }
            return lista_DNI853;
        }

        public void ActualizarEstadoPedido_DNI853(string idPedido, string nuevoEstado)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString_DNI853))
            {
                string query = "UPDATE PedidoCantina_DNI853 SET Estado_Venta_DNI853 = @estado WHERE IdPedido_DNI853 = @idPedido";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                    cmd.Parameters.AddWithValue("@idPedido", idPedido);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<BE_ItemCarrito_DNI853> ListarTodosLosItems_DNI853()
        {
            List<BE_ItemCarrito_DNI853> lista_DNI853 = new List<BE_ItemCarrito_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM ItemPedidoCantina_DNI853", conn_DNI853);
                DataTable tabla_DNI853 = new DataTable();
                adapter_DNI853.Fill(tabla_DNI853);

                foreach (DataRow r in tabla_DNI853.Rows)
                {
                    lista_DNI853.Add(new BE_ItemCarrito_DNI853
                    {
                        IdItem_DNI853 = r["IdItem_DNI853"].ToString(),
                        IdPedido_DNI853 = r["IdPedido_DNI853"].ToString(),
                        IdProducto_DNI853 = r["IdProducto_DNI853"].ToString(),
                        NombreProducto_DNI853 = r["NombreProducto_DNI853"].ToString(),
                        CantidadSolicitada_DNI853 = Convert.ToInt32(r["CantidadSolicitada_DNI853"]),
                        PrecioUnitario_DNI853 = Convert.ToDecimal(r["PrecioUnitario_DNI853"])
                    });
                }
            }
            return lista_DNI853;
        }
    }
}
