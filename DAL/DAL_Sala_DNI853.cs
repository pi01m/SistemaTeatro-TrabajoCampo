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
    public class DAL_Sala_DNI853
    {
        private readonly string _connectionString_DNI853 = DAL_ConexionDB.ObtenerCadena();

        public DAL_Sala_DNI853()
        {
        }

        public List<BE_Sala_DNI853> ListarSalas_DNI853()
        {
            List<BE_Sala_DNI853> listaSalas_DNI853 = new List<BE_Sala_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Sala_DNI853", conn_DNI853);
                DataTable tabla_DNI853 = new DataTable();
                adapter_DNI853.Fill(tabla_DNI853);

                foreach (DataRow fila_DNI853 in tabla_DNI853.Rows)
                {
                    BE_Sala_DNI853 sala_DNI853 = new BE_Sala_DNI853
                    {
                        IdSala_DNI853 = fila_DNI853["IdSala_DNI853"].ToString(), 
                        NombreSala_DNI853 = fila_DNI853["NombreSala_DNI853"].ToString(),
                        Ubicacion_DNI853 = fila_DNI853["Ubicacion_DNI853"].ToString(),
                        Capacidad_DNI853 = Convert.ToInt32(fila_DNI853["Capacidad_DNI853"])
                    };

                    listaSalas_DNI853.Add(sala_DNI853);
                }
            }

            return listaSalas_DNI853;
        }

        public bool InsertarSala_DNI853(BE_Sala_DNI853 salaParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Sala_DNI853 WHERE 1 = 0", conn_DNI853);
                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Sala_DNI853");

                DataRow fila_DNI853 = ds_DNI853.Tables["Sala_DNI853"].NewRow();

                // Al ser string, asignamos el ID manualmente en la fila nueva
                fila_DNI853["IdSala_DNI853"] = salaParam_DNI853.IdSala_DNI853;
                fila_DNI853["NombreSala_DNI853"] = salaParam_DNI853.NombreSala_DNI853;
                fila_DNI853["Ubicacion_DNI853"] = salaParam_DNI853.Ubicacion_DNI853;
                fila_DNI853["Capacidad_DNI853"] = salaParam_DNI853.Capacidad_DNI853;

                ds_DNI853.Tables["Sala_DNI853"].Rows.Add(fila_DNI853);

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Sala_DNI853");

                return true;
            }
        }

        public bool ActualizarSala_DNI853(BE_Sala_DNI853 salaParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Sala_DNI853 WHERE IdSala_DNI853 = @IdSala_DNI853", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@IdSala_DNI853", SqlDbType.VarChar, 50) { Value = salaParam_DNI853.IdSala_DNI853 });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Sala_DNI853");

                if (ds_DNI853.Tables["Sala_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Sala_DNI853"].Rows[0];

                fila_DNI853["NombreSala_DNI853"] = salaParam_DNI853.NombreSala_DNI853;
                fila_DNI853["Ubicacion_DNI853"] = salaParam_DNI853.Ubicacion_DNI853;
                fila_DNI853["Capacidad_DNI853"] = salaParam_DNI853.Capacidad_DNI853;

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Sala_DNI853");

                return true;
            }
        }

        public bool EliminarSala_DNI853(string idSalaParam_DNI853) // Recibe string
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Sala_DNI853 WHERE IdSala_DNI853 = @IdSala_DNI853", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@IdSala_DNI853", SqlDbType.VarChar, 50) { Value = idSalaParam_DNI853 });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Sala_DNI853");

                if (ds_DNI853.Tables["Sala_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Sala_DNI853"].Rows[0];
                fila_DNI853.Delete();

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Sala_DNI853");

                return true;
            }
        }
    }
}
