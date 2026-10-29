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
    public class DAL_Producto_DNI853
    {
        private readonly string _connectionString_DNI853 = DAL_ConexionDB.ObtenerCadena();

        public DAL_Producto_DNI853()
        {
        }

        public List<BE_Producto_DNI853> ListarProductos_DNI853()
        {
            List<BE_Producto_DNI853> listaProductos_DNI853 = new List<BE_Producto_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Producto_DNI853", conn_DNI853);
                DataTable tabla_DNI853 = new DataTable();
                adapter_DNI853.Fill(tabla_DNI853);

                foreach (DataRow fila_DNI853 in tabla_DNI853.Rows)
                {
                    BE_Producto_DNI853 producto_DNI853 = new BE_Producto_DNI853
                    {
                        IdProducto_DNI853 = fila_DNI853["IdProducto_DNI853"].ToString(),
                        NombreProducto_DNI853 = fila_DNI853["NombreProducto_DNI853"].ToString(),
                        Categoria_DNI853 = fila_DNI853["Categoria_DNI853"].ToString(),
                        Precio_DNI853 = Convert.ToDecimal(fila_DNI853["Precio_DNI853"]),
                        Stock_DNI853 = Convert.ToInt32(fila_DNI853["Stock_DNI853"])
                    };

                    listaProductos_DNI853.Add(producto_DNI853);
                }
            }

            return listaProductos_DNI853;
        }

        public bool InsertarProducto_DNI853(BE_Producto_DNI853 productoParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Producto_DNI853 WHERE 1 = 0", conn_DNI853);
                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Producto_DNI853");

                DataRow fila_DNI853 = ds_DNI853.Tables["Producto_DNI853"].NewRow();

                fila_DNI853["IdProducto_DNI853"] = productoParam_DNI853.IdProducto_DNI853;
                fila_DNI853["NombreProducto_DNI853"] = productoParam_DNI853.NombreProducto_DNI853;
                fila_DNI853["Categoria_DNI853"] = productoParam_DNI853.Categoria_DNI853;
                fila_DNI853["Precio_DNI853"] = productoParam_DNI853.Precio_DNI853;
                fila_DNI853["Stock_DNI853"] = productoParam_DNI853.Stock_DNI853;

                ds_DNI853.Tables["Producto_DNI853"].Rows.Add(fila_DNI853);

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Producto_DNI853");

                return true;
            }
        }

        public bool ActualizarProducto_DNI853(BE_Producto_DNI853 productoParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Producto_DNI853 WHERE IdProducto_DNI853 = @IdProducto_DNI853", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@IdProducto_DNI853", SqlDbType.VarChar, 50) { Value = productoParam_DNI853.IdProducto_DNI853 });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Producto_DNI853");

                if (ds_DNI853.Tables["Producto_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Producto_DNI853"].Rows[0];

                fila_DNI853["NombreProducto_DNI853"] = productoParam_DNI853.NombreProducto_DNI853;
                fila_DNI853["Categoria_DNI853"] = productoParam_DNI853.Categoria_DNI853;
                fila_DNI853["Precio_DNI853"] = productoParam_DNI853.Precio_DNI853;
                fila_DNI853["Stock_DNI853"] = productoParam_DNI853.Stock_DNI853;

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Producto_DNI853");

                return true;
            }
        }

        public bool EliminarProducto_DNI853(string idProductoParam_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Producto_DNI853 WHERE IdProducto_DNI853 = @IdProducto_DNI853", conn_DNI853);
                adapter_DNI853.SelectCommand.Parameters.Add(new SqlParameter("@IdProducto_DNI853", SqlDbType.VarChar, 50) { Value = idProductoParam_DNI853 });

                DataSet ds_DNI853 = new DataSet();
                adapter_DNI853.Fill(ds_DNI853, "Producto_DNI853");

                if (ds_DNI853.Tables["Producto_DNI853"].Rows.Count == 0)
                    return false;

                DataRow fila_DNI853 = ds_DNI853.Tables["Producto_DNI853"].Rows[0];
                fila_DNI853.Delete();

                SqlCommandBuilder builder_DNI853 = new SqlCommandBuilder(adapter_DNI853);
                adapter_DNI853.Update(ds_DNI853, "Producto_DNI853");

                return true;
            }
        }
    }
}
