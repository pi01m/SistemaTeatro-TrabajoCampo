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
    public class DAL_Cliente_DNI853
    {
        private readonly string _connectionString_DNI853 = DAL_ConexionDB.ObtenerCadena();

        public DAL_Cliente_DNI853()
        {
        }

        public List<BE_Cliente_DNI853> ListarClientes_DNI853()
        {
            List<BE_Cliente_DNI853> listaClientes_DNI853 = new List<BE_Cliente_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Cliente_DNI853", conn_DNI853);
                DataTable tabla_DNI853 = new DataTable();
                adapter_DNI853.Fill(tabla_DNI853);

                foreach (DataRow fila_DNI853 in tabla_DNI853.Rows)
                {
                    BE_Cliente_DNI853 cliente_DNI853 = new BE_Cliente_DNI853
                    {
                        DNI_C = fila_DNI853["DNI_C"].ToString(),
                        Nombre_C = fila_DNI853["Nombre_C"].ToString(),
                        Apellido_C = fila_DNI853["Apellido_C"].ToString(),
                        CorreoElectronico_C = fila_DNI853["CorreoElectronico_C"].ToString(),
                        Telefono_C = fila_DNI853["Telefono_C"].ToString(),
                        Direccion_C = fila_DNI853["Direccion_C"].ToString()
                    };

                    listaClientes_DNI853.Add(cliente_DNI853);
                }
            }

            return listaClientes_DNI853;
        }

        public bool InsertarCliente_DNI853(BE_Cliente_DNI853 clienteParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Cliente_DNI853 WHERE 1 = 0", conn_DNI853);
                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Cliente_DNI853");

                DataRow fila_DNI853 = ds_DNI853.Tables["Cliente_DNI853"].NewRow();

                fila_DNI853["DNI_C"] = clienteParam_DNI853.DNI_C;
                fila_DNI853["Nombre_C"] = clienteParam_DNI853.Nombre_C;
                fila_DNI853["Apellido_C"] = clienteParam_DNI853.Apellido_C;
                fila_DNI853["CorreoElectronico_C"] = clienteParam_DNI853.CorreoElectronico_C;
                fila_DNI853["Telefono_C"] = clienteParam_DNI853.Telefono_C;
                fila_DNI853["Direccion_C"] = clienteParam_DNI853.Direccion_C;

                ds_DNI853.Tables["Cliente_DNI853"].Rows.Add(fila_DNI853);

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Cliente_DNI853");

                return true;
            }
        }

        public bool ActualizarCliente_DNI853(BE_Cliente_DNI853 clienteParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Cliente_DNI853 WHERE DNI_C = @DNI_C", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@DNI_C", SqlDbType.VarChar, 50) { Value = clienteParam_DNI853.DNI_C });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Cliente_DNI853");

                if (ds_DNI853.Tables["Cliente_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Cliente_DNI853"].Rows[0];

                fila_DNI853["Nombre_C"] = clienteParam_DNI853.Nombre_C;
                fila_DNI853["Apellido_C"] = clienteParam_DNI853.Apellido_C;
                fila_DNI853["CorreoElectronico_C"] = clienteParam_DNI853.CorreoElectronico_C;
                fila_DNI853["Telefono_C"] = clienteParam_DNI853.Telefono_C;
                fila_DNI853["Direccion_C"] = clienteParam_DNI853.Direccion_C;

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Cliente_DNI853");

                return true;
            }
        }

        public bool EliminarCliente_DNI853(string dniClienteParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Cliente_DNI853 WHERE DNI_C = @DNI_C", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@DNI_C", SqlDbType.VarChar, 50) { Value = dniClienteParam_DNI853 });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Cliente_DNI853");

                if (ds_DNI853.Tables["Cliente_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Cliente_DNI853"].Rows[0];
                fila_DNI853.Delete();

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Cliente_DNI853");

                return true;
            }
        }
    }
}
