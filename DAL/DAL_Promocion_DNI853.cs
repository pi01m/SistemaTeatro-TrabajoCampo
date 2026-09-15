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
    public class DAL_Promocion_DNI853
    {
        private readonly string _connectionString_DNI853 = DAL_ConexionDB.ObtenerCadena();

        public DAL_Promocion_DNI853()
        {
        }

        public List<BE_Promocion_DNI853> ListarPromociones_DNI853()
        {
            List<BE_Promocion_DNI853> listaPromociones_DNI853 = new List<BE_Promocion_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Promocion_DNI853", conn_DNI853);
                DataTable tabla_DNI853 = new DataTable();
                adapter_DNI853.Fill(tabla_DNI853);

                foreach (DataRow fila_DNI853 in tabla_DNI853.Rows)
                {
                    BE_Promocion_DNI853 promocion_DNI853 = new BE_Promocion_DNI853
                    {
                        IdPromo_DNI853 = fila_DNI853["IdPromo_DNI853"].ToString(),
                        NombrePromo_DNI853 = fila_DNI853["NombrePromo_DNI853"].ToString(),
                        TipoPromo_DNI853 = fila_DNI853["TipoPromo_DNI853"].ToString(),
                        ValorDescuento_DNI853 = Convert.ToDecimal(fila_DNI853["ValorDescuento_DNI853"]),
                        FechaInicio_DNI853 = Convert.ToDateTime(fila_DNI853["FechaInicio_DNI853"]),
                        FechaFin_DNI853 = Convert.ToDateTime(fila_DNI853["FechaFin_DNI853"]),
                        EstadoPromo_DNI853 = fila_DNI853["EstadoPromo_DNI853"].ToString(),
                        DestinoPromo_DNI853 = fila_DNI853["DestinoPromo_DNI853"] != DBNull.Value ? fila_DNI853["DestinoPromo_DNI853"].ToString() : string.Empty
                    };

                    listaPromociones_DNI853.Add(promocion_DNI853);
                }
            }

            return listaPromociones_DNI853;
        }

        public bool InsertarPromocion_DNI853(BE_Promocion_DNI853 promocionParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Promocion_DNI853 WHERE 1 = 0", conn_DNI853);
                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Promocion_DNI853");

                DataRow fila_DNI853 = ds_DNI853.Tables["Promocion_DNI853"].NewRow();

                fila_DNI853["IdPromo_DNI853"] = promocionParam_DNI853.IdPromo_DNI853;
                fila_DNI853["NombrePromo_DNI853"] = promocionParam_DNI853.NombrePromo_DNI853;
                fila_DNI853["TipoPromo_DNI853"] = promocionParam_DNI853.TipoPromo_DNI853;
                fila_DNI853["ValorDescuento_DNI853"] = promocionParam_DNI853.ValorDescuento_DNI853;
                fila_DNI853["FechaInicio_DNI853"] = promocionParam_DNI853.FechaInicio_DNI853;
                fila_DNI853["FechaFin_DNI853"] = promocionParam_DNI853.FechaFin_DNI853;
                fila_DNI853["EstadoPromo_DNI853"] = promocionParam_DNI853.EstadoPromo_DNI853;
                fila_DNI853["DestinoPromo_DNI853"] = string.IsNullOrEmpty(promocionParam_DNI853.DestinoPromo_DNI853) ? (object)DBNull.Value : promocionParam_DNI853.DestinoPromo_DNI853;
                ds_DNI853.Tables["Promocion_DNI853"].Rows.Add(fila_DNI853);

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Promocion_DNI853");

                return true;
            }
        }

        public bool ActualizarPromocion_DNI853(BE_Promocion_DNI853 promocionParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Promocion_DNI853 WHERE IdPromo_DNI853 = @IdPromo_DNI853", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@IdPromo_DNI853", SqlDbType.VarChar, 50) { Value = promocionParam_DNI853.IdPromo_DNI853 });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Promocion_DNI853");

                if (ds_DNI853.Tables["Promocion_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Promocion_DNI853"].Rows[0];

                fila_DNI853["NombrePromo_DNI853"] = promocionParam_DNI853.NombrePromo_DNI853;
                fila_DNI853["TipoPromo_DNI853"] = promocionParam_DNI853.TipoPromo_DNI853;
                fila_DNI853["ValorDescuento_DNI853"] = promocionParam_DNI853.ValorDescuento_DNI853;
                fila_DNI853["FechaInicio_DNI853"] = promocionParam_DNI853.FechaInicio_DNI853;
                fila_DNI853["FechaFin_DNI853"] = promocionParam_DNI853.FechaFin_DNI853;
                fila_DNI853["EstadoPromo_DNI853"] = promocionParam_DNI853.EstadoPromo_DNI853;
                fila_DNI853["DestinoPromo_DNI853"] = string.IsNullOrEmpty(promocionParam_DNI853.DestinoPromo_DNI853) ? (object)DBNull.Value : promocionParam_DNI853.DestinoPromo_DNI853;
                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Promocion_DNI853");

                return true;
            }
        }

        public bool EliminarPromocion_DNI853(string idPromoParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Promocion_DNI853 WHERE IdPromo_DNI853 = @IdPromo_DNI853", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@IdPromo_DNI853", SqlDbType.VarChar, 50) { Value = idPromoParam_DNI853 });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Promocion_DNI853");

                if (ds_DNI853.Tables["Promocion_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Promocion_DNI853"].Rows[0];
                fila_DNI853.Delete();

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Promocion_DNI853");

                return true;
            }
        }

        // Método específico para la venta, adaptado a los nombres reales de tus propiedades y columnas
        public List<BE_Promocion_DNI853> ObtenerPromocionesVigentes_DNI853()
        {
            List<BE_Promocion_DNI853> listaPromociones_DNI853 = new List<BE_Promocion_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                // Filtramos por las promociones activas o vigentes según tu estructura de base de datos
                string query_DNI853 = "SELECT * FROM Promocion_DNI853 WHERE EstadoPromo_DNI853 = 'Activo' OR FechaFin_DNI853 >= GETDATE()";
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter(query_DNI853, conn_DNI853);
                DataTable tabla_DNI853 = new DataTable();
                adapter_DNI853.Fill(tabla_DNI853);

                foreach (DataRow fila_DNI853 in tabla_DNI853.Rows)
                {
                    BE_Promocion_DNI853 promocion_DNI853 = new BE_Promocion_DNI853
                    {
                        IdPromo_DNI853 = fila_DNI853["IdPromo_DNI853"].ToString(),
                        NombrePromo_DNI853 = fila_DNI853["NombrePromo_DNI853"].ToString(),
                        TipoPromo_DNI853 = fila_DNI853["TipoPromo_DNI853"].ToString(),
                        ValorDescuento_DNI853 = Convert.ToDecimal(fila_DNI853["ValorDescuento_DNI853"]),
                        FechaInicio_DNI853 = Convert.ToDateTime(fila_DNI853["FechaInicio_DNI853"]),
                        FechaFin_DNI853 = Convert.ToDateTime(fila_DNI853["FechaFin_DNI853"]),
                        EstadoPromo_DNI853 = fila_DNI853["EstadoPromo_DNI853"].ToString(),
                        DestinoPromo_DNI853 = fila_DNI853["DestinoPromo_DNI853"] != DBNull.Value ? fila_DNI853["DestinoPromo_DNI853"].ToString() : string.Empty
                    };

                    listaPromociones_DNI853.Add(promocion_DNI853);
                }
            }

            return listaPromociones_DNI853;
        }


    }
}
