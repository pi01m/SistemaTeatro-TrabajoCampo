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
    public class DAL_Sector_DNI853
    {
        private readonly string _connectionString_DNI853 = DAL_ConexionDB.ObtenerCadena();

        public DAL_Sector_DNI853()
        {
        }

        public List<BE_Sector_DNI853> ListarSectoresPorSala_DNI853(string idSalaParam_DNI853)
        {
            List<BE_Sector_DNI853> listaSectores_DNI853 = new List<BE_Sector_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Sector_DNI853 WHERE IdSala_DNI853 = @IdSala_DNI853", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@IdSala_DNI853", SqlDbType.VarChar, 50) { Value = idSalaParam_DNI853 });

                DataTable tabla_DNI853 = new DataTable();
                adapter_DNI853.Fill(tabla_DNI853);

                foreach (DataRow fila_DNI853 in tabla_DNI853.Rows)
                {
                    BE_Sector_DNI853 sector_DNI853 = new BE_Sector_DNI853
                    {
                        IdSector_DNI853 = fila_DNI853["IdSector_DNI853"].ToString(),
                        IdSala_DNI853 = fila_DNI853["IdSala_DNI853"].ToString(),
                        NombreSector_DNI853 = fila_DNI853["NombreSector_DNI853"].ToString(),
                        Ubicacion_DNI853 = fila_DNI853["Ubicacion_DNI853"].ToString(),
                        Capacidad_DNI853 = Convert.ToInt32(fila_DNI853["Capacidad_DNI853"]),
                        Precio_DNI853 = Convert.ToDecimal(fila_DNI853["Precio_DNI853"])
                    };

                    listaSectores_DNI853.Add(sector_DNI853);
                }
            }

            return listaSectores_DNI853;
        }

        public List<BE_Sector_DNI853> ListarTodosSectores_DNI853()
        {
            List<BE_Sector_DNI853> listaSectores_DNI853 = new List<BE_Sector_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Sector_DNI853", conn_DNI853);
                DataTable tabla_DNI853 = new DataTable();
                adapter_DNI853.Fill(tabla_DNI853);

                foreach (DataRow fila_DNI853 in tabla_DNI853.Rows)
                {
                    BE_Sector_DNI853 sector_DNI853 = new BE_Sector_DNI853
                    {
                        IdSector_DNI853 = fila_DNI853["IdSector_DNI853"].ToString(),
                        IdSala_DNI853 = fila_DNI853["IdSala_DNI853"].ToString(),
                        NombreSector_DNI853 = fila_DNI853["NombreSector_DNI853"].ToString(),
                        Ubicacion_DNI853 = fila_DNI853["Ubicacion_DNI853"].ToString(),
                        Capacidad_DNI853 = Convert.ToInt32(fila_DNI853["Capacidad_DNI853"]),
                        Precio_DNI853 = Convert.ToDecimal(fila_DNI853["Precio_DNI853"])
                    };

                    listaSectores_DNI853.Add(sector_DNI853);
                }
            }

            return listaSectores_DNI853;
        }

        public bool InsertarSector_DNI853(BE_Sector_DNI853 sectorParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Sector_DNI853 WHERE 1 = 0", conn_DNI853);
                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Sector_DNI853");

                DataRow fila_DNI853 = ds_DNI853.Tables["Sector_DNI853"].NewRow();

                // Asignamos ambos IDs como string
                fila_DNI853["IdSector_DNI853"] = sectorParam_DNI853.IdSector_DNI853;
                fila_DNI853["IdSala_DNI853"] = sectorParam_DNI853.IdSala_DNI853;
                fila_DNI853["NombreSector_DNI853"] = sectorParam_DNI853.NombreSector_DNI853;
                fila_DNI853["Ubicacion_DNI853"] = sectorParam_DNI853.Ubicacion_DNI853;
                fila_DNI853["Capacidad_DNI853"] = sectorParam_DNI853.Capacidad_DNI853;
                fila_DNI853["Precio_DNI853"] = sectorParam_DNI853.Precio_DNI853;

                ds_DNI853.Tables["Sector_DNI853"].Rows.Add(fila_DNI853);

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Sector_DNI853");

                return true;
            }
        }

        public bool ActualizarSector_DNI853(BE_Sector_DNI853 sectorParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Sector_DNI853 WHERE IdSector_DNI853 = @IdSector_DNI853", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@IdSector_DNI853", SqlDbType.VarChar, 50) { Value = sectorParam_DNI853.IdSector_DNI853 });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Sector_DNI853");

                if (ds_DNI853.Tables["Sector_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Sector_DNI853"].Rows[0];

                fila_DNI853["IdSala_DNI853"] = sectorParam_DNI853.IdSala_DNI853;
                fila_DNI853["NombreSector_DNI853"] = sectorParam_DNI853.NombreSector_DNI853;
                fila_DNI853["Ubicacion_DNI853"] = sectorParam_DNI853.Ubicacion_DNI853;
                fila_DNI853["Capacidad_DNI853"] = sectorParam_DNI853.Capacidad_DNI853;
                fila_DNI853["Precio_DNI853"] = sectorParam_DNI853.Precio_DNI853;

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Sector_DNI853");

                return true;
            }
        }

        public bool EliminarSector_DNI853(string idSectorParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Sector_DNI853 WHERE IdSector_DNI853 = @IdSector_DNI853", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@IdSector_DNI853", SqlDbType.VarChar, 50) { Value = idSectorParam_DNI853 });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Sector_DNI853");

                if (ds_DNI853.Tables["Sector_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Sector_DNI853"].Rows[0];
                fila_DNI853.Delete();

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Sector_DNI853");

                return true;
            }
        }

        // Obtiene los sectores correspondientes a la sala asociada a la función seleccionada
        public List<BE_Sector_DNI853> ObtenerSectoresPorFuncion_DNI853(string idFuncion_DNI853)
        {
            List<BE_Sector_DNI853> listaSectores_DNI853 = new List<BE_Sector_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                // Busca los sectores filtrando a través de la sala configurada en la función
                string query_DNI853 = @"SELECT s.* FROM Sector_DNI853 s
                                         INNER JOIN Funcion_DNI853 f ON s.IdSala_DNI853 = f.IdSala_DNI853
                                         WHERE f.IdFuncion_DNI853 = @IdFuncion";

                using (SqlCommand cmd_DNI853 = new SqlCommand(query_DNI853, conn_DNI853))
                {
                    cmd_DNI853.Parameters.Add(new SqlParameter("@IdFuncion", SqlDbType.VarChar, 50) { Value = idFuncion_DNI853 });

                    SqlDataAdapter adapter_DNI853 = new SqlDataAdapter(cmd_DNI853);
                    DataTable tabla_DNI853 = new DataTable();
                    adapter_DNI853.Fill(tabla_DNI853);

                    foreach (DataRow fila_DNI853 in tabla_DNI853.Rows)
                    {
                        BE_Sector_DNI853 sector_DNI853 = new BE_Sector_DNI853
                        {
                            IdSector_DNI853 = fila_DNI853["IdSector_DNI853"].ToString(),
                            IdSala_DNI853 = fila_DNI853["IdSala_DNI853"].ToString(),
                            NombreSector_DNI853 = fila_DNI853["NombreSector_DNI853"].ToString(),
                            Ubicacion_DNI853 = fila_DNI853["Ubicacion_DNI853"].ToString(),
                            Capacidad_DNI853 = Convert.ToInt32(fila_DNI853["Capacidad_DNI853"]),
                            Precio_DNI853 = Convert.ToDecimal(fila_DNI853["Precio_DNI853"])
                        };

                        listaSectores_DNI853.Add(sector_DNI853);
                    }
                }
            }

            return listaSectores_DNI853;
        }
    }
}
