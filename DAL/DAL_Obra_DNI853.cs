using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public class DAL_Obra_DNI853
    {
        private readonly string _connectionString_DNI853 = DAL_ConexionDB.ObtenerCadena();

        public DAL_Obra_DNI853()
        {
        }

        public List<BE_Obra_DNI853> ListarObras_DNI853()
        {
            List<BE_Obra_DNI853> listaObras_DNI853 = new List<BE_Obra_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Obra_DNI853", conn_DNI853);
                DataTable tabla_DNI853 = new DataTable();
                adapter_DNI853.Fill(tabla_DNI853);

                foreach (DataRow fila_DNI853 in tabla_DNI853.Rows)
                {
                    BE_Obra_DNI853 obra_DNI853 = new BE_Obra_DNI853
                    {
                        IdObra_DNI853 = fila_DNI853["IdObra_DNI853"].ToString(),
                        NombreObra_DNI853 = fila_DNI853["NombreObra_DNI853"].ToString(),
                        DescripcionObra_DNI853 = fila_DNI853["DescripcionObra_DNI853"].ToString()
                    };

                    listaObras_DNI853.Add(obra_DNI853);
                }
            }

            return listaObras_DNI853;
        }

        public bool InsertarObra_DNI853(BE_Obra_DNI853 obraParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Obra_DNI853 WHERE 1 = 0", conn_DNI853);
                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Obra_DNI853");

                DataRow fila_DNI853 = ds_DNI853.Tables["Obra_DNI853"].NewRow();

                fila_DNI853["IdObra_DNI853"] = obraParam_DNI853.IdObra_DNI853;
                fila_DNI853["NombreObra_DNI853"] = obraParam_DNI853.NombreObra_DNI853;
                fila_DNI853["DescripcionObra_DNI853"] = obraParam_DNI853.DescripcionObra_DNI853;

                ds_DNI853.Tables["Obra_DNI853"].Rows.Add(fila_DNI853);

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Obra_DNI853");

                return true;
            }
        }

        public bool ActualizarObra_DNI853(BE_Obra_DNI853 obraParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Obra_DNI853 WHERE IdObra_DNI853 = @IdObra_DNI853", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@IdObra_DNI853", SqlDbType.VarChar, 50) { Value = obraParam_DNI853.IdObra_DNI853 });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Obra_DNI853");

                if (ds_DNI853.Tables["Obra_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Obra_DNI853"].Rows[0];

                fila_DNI853["NombreObra_DNI853"] = obraParam_DNI853.NombreObra_DNI853;
                fila_DNI853["DescripcionObra_DNI853"] = obraParam_DNI853.DescripcionObra_DNI853;

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Obra_DNI853");

                return true;
            }
        }

        public bool EliminarObra_DNI853(string idObraParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Obra_DNI853 WHERE IdObra_DNI853 = @IdObra_DNI853", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@IdObra_DNI853", SqlDbType.VarChar, 50) { Value = idObraParam_DNI853 });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Obra_DNI853");

                if (ds_DNI853.Tables["Obra_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Obra_DNI853"].Rows[0];
                fila_DNI853.Delete();

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Obra_DNI853");

                return true;
            }
        }
    }
}
