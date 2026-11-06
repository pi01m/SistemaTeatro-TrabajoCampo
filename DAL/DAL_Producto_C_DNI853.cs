using BE;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Producto_C_DNI853
    {
        private readonly string _connectionString_DNI853 = DAL_ConexionDB.ObtenerCadena();

        public List<BE_Producto_C_DNI853> ListarBitacora_DNI853(string codProd, string nombre, DateTime? fechaIni, DateTime? fechaFin)
        {
            List<BE_Producto_C_DNI853> lista_DNI853 = new List<BE_Producto_C_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                string query_DNI853 = @"SELECT IdCambio_DNI853, IdProducto_DNI853, Fecha_DNI853, Hora_DNI853, 
                                               NombreProducto_DNI853, Categoria_DNI853, Precio_DNI853, Stock_DNI853, Act_DNI853 
                                        FROM Producto_C_DNI853 
                                        WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(codProd))
                    query_DNI853 += " AND IdProducto_DNI853 LIKE @CodProd";

                if (!string.IsNullOrWhiteSpace(nombre))
                    query_DNI853 += " AND NombreProducto_DNI853 LIKE @Nombre";

                if (fechaIni.HasValue)
                    query_DNI853 += " AND Fecha_DNI853 >= @FechaIni";

                if (fechaFin.HasValue)
                    query_DNI853 += " AND Fecha_DNI853 <= @FechaFin";

                query_DNI853 += " ORDER BY IdCambio_DNI853 DESC";

                SqlCommand cmd_DNI853 = new SqlCommand(query_DNI853, conn_DNI853);

                if (!string.IsNullOrWhiteSpace(codProd))
                    cmd_DNI853.Parameters.AddWithValue("@CodProd", $"%{codProd}%");

                if (!string.IsNullOrWhiteSpace(nombre))
                    cmd_DNI853.Parameters.AddWithValue("@Nombre", $"%{nombre}%");

                if (fechaIni.HasValue)
                    cmd_DNI853.Parameters.AddWithValue("@FechaIni", fechaIni.Value.Date);

                if (fechaFin.HasValue)
                    cmd_DNI853.Parameters.AddWithValue("@FechaFin", fechaFin.Value.Date);

                conn_DNI853.Open();
                using (SqlDataReader reader_DNI853 = cmd_DNI853.ExecuteReader())
                {
                    while (reader_DNI853.Read())
                    {
                        lista_DNI853.Add(new BE_Producto_C_DNI853
                        {
                            IdCambio_DNI853 = Convert.ToInt32(reader_DNI853["IdCambio_DNI853"]),
                            IdProducto_DNI853 = reader_DNI853["IdProducto_DNI853"].ToString(),
                            Fecha_DNI853 = Convert.ToDateTime(reader_DNI853["Fecha_DNI853"]),
                            Hora_DNI853 = (TimeSpan)reader_DNI853["Hora_DNI853"],
                            NombreProducto_DNI853 = reader_DNI853["NombreProducto_DNI853"].ToString(),
                            Categoria_DNI853 = reader_DNI853["Categoria_DNI853"].ToString(),
                            Precio_DNI853 = Convert.ToDecimal(reader_DNI853["Precio_DNI853"]),
                            Stock_DNI853 = Convert.ToInt32(reader_DNI853["Stock_DNI853"]),
                            Act_DNI853 = Convert.ToBoolean(reader_DNI853["Act_DNI853"])
                        });
                    }
                }
            }

            return lista_DNI853;
        }
    }
}
