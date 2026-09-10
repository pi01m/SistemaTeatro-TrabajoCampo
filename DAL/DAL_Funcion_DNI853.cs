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
    public class DAL_Funcion_DNI853
    {
        private readonly string _connectionString_DNI853 = DAL_ConexionDB.ObtenerCadena();

        public DAL_Funcion_DNI853()
        {
        }

        public List<BE_Funcion_DNI853> ListarFunciones_DNI853()
        {
            List<BE_Funcion_DNI853> listaFunciones_DNI853 = new List<BE_Funcion_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Funcion_DNI853", conn_DNI853);
                DataTable tabla_DNI853 = new DataTable();
                adapter_DNI853.Fill(tabla_DNI853);

                foreach (DataRow fila_DNI853 in tabla_DNI853.Rows)
                {
                    BE_Funcion_DNI853 funcion_DNI853 = new BE_Funcion_DNI853
                    {
                        IdFuncion_DNI853 = fila_DNI853["IdFuncion_DNI853"].ToString(),
                        IdObra_DNI853 = fila_DNI853["IdObra_DNI853"].ToString(),
                        IdSala_DNI853 = fila_DNI853["IdSala_DNI853"].ToString(),
                        Fecha_DNI853 = Convert.ToDateTime(fila_DNI853["Fecha_DNI853"]),
                        HoraInicio_DNI853 = fila_DNI853["HoraInicio_DNI853"].ToString(),
                        HoraFinalizacion_DNI853 = fila_DNI853["HoraFinalizacion_DNI853"].ToString(),
                        Estado_DNI853 = fila_DNI853["Estado_DNI853"].ToString()
                    };

                    listaFunciones_DNI853.Add(funcion_DNI853);
                }
            }

            return listaFunciones_DNI853;
        }

        public bool InsertarFuncion_DNI853(BE_Funcion_DNI853 funcionParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Funcion_DNI853 WHERE 1 = 0", conn_DNI853);
                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Funcion_DNI853");

                DataRow fila_DNI853 = ds_DNI853.Tables["Funcion_DNI853"].NewRow();

                fila_DNI853["IdFuncion_DNI853"] = funcionParam_DNI853.IdFuncion_DNI853;
                fila_DNI853["IdObra_DNI853"] = funcionParam_DNI853.IdObra_DNI853;
                fila_DNI853["IdSala_DNI853"] = funcionParam_DNI853.IdSala_DNI853;
                fila_DNI853["Fecha_DNI853"] = funcionParam_DNI853.Fecha_DNI853;
                fila_DNI853["HoraInicio_DNI853"] = funcionParam_DNI853.HoraInicio_DNI853;
                fila_DNI853["HoraFinalizacion_DNI853"] = funcionParam_DNI853.HoraFinalizacion_DNI853;
                fila_DNI853["Estado_DNI853"] = funcionParam_DNI853.Estado_DNI853;

                ds_DNI853.Tables["Funcion_DNI853"].Rows.Add(fila_DNI853);

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Funcion_DNI853");

                return true;
            }
        }

        public bool ActualizarFuncion_DNI853(BE_Funcion_DNI853 funcionParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Funcion_DNI853 WHERE IdFuncion_DNI853 = @IdFuncion_DNI853", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@IdFuncion_DNI853", SqlDbType.VarChar, 50) { Value = funcionParam_DNI853.IdFuncion_DNI853 });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Funcion_DNI853");

                if (ds_DNI853.Tables["Funcion_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Funcion_DNI853"].Rows[0];

                fila_DNI853["IdObra_DNI853"] = funcionParam_DNI853.IdObra_DNI853;
                fila_DNI853["IdSala_DNI853"] = funcionParam_DNI853.IdSala_DNI853;
                fila_DNI853["Fecha_DNI853"] = funcionParam_DNI853.Fecha_DNI853;
                fila_DNI853["HoraInicio_DNI853"] = funcionParam_DNI853.HoraInicio_DNI853;
                fila_DNI853["HoraFinalizacion_DNI853"] = funcionParam_DNI853.HoraFinalizacion_DNI853;
                fila_DNI853["Estado_DNI853"] = funcionParam_DNI853.Estado_DNI853;

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Funcion_DNI853");

                return true;
            }
        }

        public bool EliminarFuncion_DNI853(string idFuncionParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Funcion_DNI853 WHERE IdFuncion_DNI853 = @IdFuncion_DNI853", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@IdFuncion_DNI853", SqlDbType.VarChar, 50) { Value = idFuncionParam_DNI853 });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Funcion_DNI853");

                if (ds_DNI853.Tables["Funcion_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Funcion_DNI853"].Rows[0];
                fila_DNI853.Delete();

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Funcion_DNI853");

                return true;
            }
        }
    }
}
