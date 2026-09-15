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
    public class DAL_Factura_DNI853
    {
        private string _connectionString_DNI853 = DAL_ConexionDB.ObtenerCadena();

        public List<BE_Factura_DNI853> ListarFacturas_DNI853()
        {
            List<BE_Factura_DNI853> listaFacturas_DNI853 = new List<BE_Factura_DNI853>();

            using (SqlConnection conexion_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Factura_DNI853", conexion_DNI853);
                DataTable tabla_DNI853 = new DataTable();
                adapter_DNI853.Fill(tabla_DNI853);

                foreach (DataRow fila_DNI853 in tabla_DNI853.Rows)
                {
                    BE_Factura_DNI853 factura_DNI853 = new BE_Factura_DNI853
                    {
                        Id_Factura_DNI853 = fila_DNI853["Id_Factura_DNI853"].ToString(),
                        DNI_C_DNI853 = fila_DNI853["Id_Cliente_DNI853"].ToString(),
                        ImporteTotal_DNI853 = Convert.ToDecimal(fila_DNI853["ImporteTotal_DNI853"]),
                        TipoPago_DNI853 = fila_DNI853["TipoPago_DNI853"].ToString(),
                        Banco_DNI853 = fila_DNI853["Banco_DNI853"] != DBNull.Value ? fila_DNI853["Banco_DNI853"].ToString() : string.Empty,
                        NumeroTarjeta_DNI853 = fila_DNI853["NumeroTarjeta_DNI853"] != DBNull.Value ? fila_DNI853["NumeroTarjeta_DNI853"].ToString() : string.Empty,
                        FechaVencimiento_DNI853 = fila_DNI853["FechaVencimiento_DNI853"] != DBNull.Value ? fila_DNI853["FechaVencimiento_DNI853"].ToString() : string.Empty,
                        Fecha_DNI853 = Convert.ToDateTime(fila_DNI853["Fecha_DNI853"]),
                        Vendedor_DNI853 = fila_DNI853["Vendedor_DNI853"] != DBNull.Value ? fila_DNI853["Vendedor_DNI853"].ToString() : string.Empty,
                        IdPromocion_DNI853 = fila_DNI853["Id_Promocion_DNI853"] != DBNull.Value ? fila_DNI853["Id_Promocion_DNI853"].ToString() : string.Empty
                    };

                    listaFacturas_DNI853.Add(factura_DNI853);
                }
            }

            return listaFacturas_DNI853;
        }

        // Solo inserta la cabecera de la factura (retorna la conexión abierta y la transacción si se requiere, o recibe parámetros)
        public string RegistrarFacturaUnica_DNI853(BE_Factura_DNI853 factura_DNI853, SqlConnection conexion_DNI853, SqlTransaction transaccion_DNI853)
        {
            SqlDataAdapter adapterFactura = new SqlDataAdapter("SELECT * FROM Factura_DNI853 WHERE 1 = 0", conexion_DNI853);
            adapterFactura.SelectCommand.Transaction = transaccion_DNI853;

            DataSet dsFactura = new DataSet();
            adapterFactura.Fill(dsFactura, "Factura");
            DataTable tablaFactura = dsFactura.Tables["Factura"];

            DataRow filaFactura = tablaFactura.NewRow();
            filaFactura["Id_Factura_DNI853"] = factura_DNI853.Id_Factura_DNI853;
            filaFactura["Id_Cliente_DNI853"] = factura_DNI853.DNI_C_DNI853;
            filaFactura["ImporteTotal_DNI853"] = factura_DNI853.ImporteTotal_DNI853;
            filaFactura["TipoPago_DNI853"] = factura_DNI853.TipoPago_DNI853;
            filaFactura["Banco_DNI853"] = string.IsNullOrEmpty(factura_DNI853.Banco_DNI853) ? (object)DBNull.Value : factura_DNI853.Banco_DNI853;
            filaFactura["NumeroTarjeta_DNI853"] = string.IsNullOrEmpty(factura_DNI853.NumeroTarjeta_DNI853) ? (object)DBNull.Value : factura_DNI853.NumeroTarjeta_DNI853;
            filaFactura["FechaVencimiento_DNI853"] = string.IsNullOrEmpty(factura_DNI853.FechaVencimiento_DNI853) ? (object)DBNull.Value : factura_DNI853.FechaVencimiento_DNI853;
            filaFactura["Fecha_DNI853"] = DateTime.Now;
            filaFactura["Vendedor_DNI853"] = string.IsNullOrEmpty(factura_DNI853.Vendedor_DNI853) ? (object)DBNull.Value : factura_DNI853.Vendedor_DNI853;
            filaFactura["Id_Promocion_DNI853"] = string.IsNullOrEmpty(factura_DNI853.IdPromocion_DNI853) ? (object)DBNull.Value : factura_DNI853.IdPromocion_DNI853; 
            tablaFactura.Rows.Add(filaFactura);

            SqlCommandBuilder builderFactura = new SqlCommandBuilder(adapterFactura);
            adapterFactura.Update(dsFactura, "Factura");

            return factura_DNI853.Id_Factura_DNI853;
        }

        public DataSet ObtenerDatosFacturaDesconectado_DNI853(string idFactura_DNI853)
        {
            DataSet ds_DNI853 = new DataSet();

            using (SqlConnection conexion_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                using (SqlDataAdapter daFactura = new SqlDataAdapter($"SELECT * FROM Factura_DNI853 WHERE Id_Factura_DNI853 = '{idFactura_DNI853}'", conexion_DNI853))
                {
                    daFactura.Fill(ds_DNI853, "Factura");
                }

                using (SqlDataAdapter daEntrada = new SqlDataAdapter($"SELECT * FROM Entrada_DNI853 WHERE Id_Factura_DNI853 = '{idFactura_DNI853}'", conexion_DNI853))
                {
                    daEntrada.Fill(ds_DNI853, "Entrada");
                }
            }

            return ds_DNI853;
        }
    }
}
