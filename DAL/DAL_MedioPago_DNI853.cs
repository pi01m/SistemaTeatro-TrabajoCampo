using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public class DAL_MedioPago_DNI853
    {
        //private readonly string _connectionString_DNI853 = "Data Source =.; Initial Catalog = BD_TeatroLux_DNI853; Integrated Security = True; Trust Server Certificate=True";
        private string _connectionString_DNI853 = DAL_ConexionDB.ObtenerCadena();
        public List<BE_MedioPago_DNI853> ObtenerMediosDePago_DNI853()
        {
            List<BE_MedioPago_DNI853> listaMediosPago_DNI853 = new List<BE_MedioPago_DNI853>();
            using (SqlConnection conexion_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                string query_DNI853 = "SELECT * FROM MedioPago_DNI853";
                using (SqlDataAdapter adaptador_DNI853 = new SqlDataAdapter(query_DNI853, conexion_DNI853))
                {
                    DataTable tabla_DNI853 = new DataTable();
                    adaptador_DNI853.Fill(tabla_DNI853);

                    foreach (DataRow fila_DNI853 in tabla_DNI853.Rows)
                    {
                        BE_MedioPago_DNI853 medio_DNI853 = new BE_MedioPago_DNI853
                        {
                            IdMedioPago_DNI853 = fila_DNI853["IdMedioPago_DNI853"].ToString(),
                            Nombre_MedioPago_DNI853 = fila_DNI853["Nombre_MedioPago_DNI853"].ToString()
                        };
                        listaMediosPago_DNI853.Add(medio_DNI853);
                    }
                }
            }
            return listaMediosPago_DNI853;
        }
    }
}
