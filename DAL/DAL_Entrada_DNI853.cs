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
    public class DAL_Entrada_DNI853
    {
        private string _connectionString_DNI853 = DAL_ConexionDB.ObtenerCadena();
        public DAL_Entrada_DNI853() { }

        public List<BE_Entrada_DNI853> ListarEntradas_DNI853()
        {
            List<BE_Entrada_DNI853> listaEntradas_DNI853 = new List<BE_Entrada_DNI853>();

            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapter_DNI853 = new SqlDataAdapter("SELECT * FROM Entrada_DNI853", conn_DNI853);
                DataTable tabla_DNI853 = new DataTable();
                adapter_DNI853.Fill(tabla_DNI853);

                foreach (DataRow fila_DNI853 in tabla_DNI853.Rows)
                {
                    BE_Entrada_DNI853 entrada_DNI853 = new BE_Entrada_DNI853
                    {
                        Id_Entrada_DNI853 = fila_DNI853["Id_Entrada_DNI853"].ToString(),
                        Id_Factura_DNI853 = fila_DNI853["Id_Factura_DNI853"].ToString(),
                        IdFuncion_DNI853 = fila_DNI853["Id_Funcion_DNI853"].ToString(),
                        IdSector_DNI853 = fila_DNI853["Id_Sector_DNI853"].ToString(),
                        Detalle_DNI853 = fila_DNI853["Detalle_DNI853"].ToString(),

                        // SOLUCIÓN: Recuperar la cantidad (o forzarla a 1 si no es una columna de la tabla)
                        Cantidad_DNI853 = fila_DNI853.Table.Columns.Contains("Cantidad_DNI853") ? Convert.ToInt32(fila_DNI853["Cantidad_DNI853"]) : 1,

                        PrecioUnitario_DNI853 = Convert.ToDecimal(fila_DNI853["PrecioUnitario_DNI853"])
                    };

                    listaEntradas_DNI853.Add(entrada_DNI853);
                }
            }

            return listaEntradas_DNI853;
        }

        public void RegistrarEntradas_DNI853(List<BE_Entrada_DNI853> entradas_DNI853)
        {
            using (SqlConnection conn_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                SqlDataAdapter adapterEntrada_DNI853 = new SqlDataAdapter("SELECT * FROM Entrada_DNI853 WHERE 1 = 0", conn_DNI853);
                DataSet dsEntrada_DNI853 = new DataSet();
                adapterEntrada_DNI853.Fill(dsEntrada_DNI853, "Entrada");
                DataTable tablaEntrada_DNI853 = dsEntrada_DNI853.Tables["Entrada"];

                foreach (BE_Entrada_DNI853 entrada_DNI853 in entradas_DNI853)
                {
                    DataRow filaEntrada_DNI853 = tablaEntrada_DNI853.NewRow();
                    filaEntrada_DNI853["Id_Entrada_DNI853"] = entrada_DNI853.Id_Entrada_DNI853;
                    filaEntrada_DNI853["Id_Factura_DNI853"] = entrada_DNI853.Id_Factura_DNI853;
                    filaEntrada_DNI853["Id_Funcion_DNI853"] = entrada_DNI853.IdFuncion_DNI853;
                    filaEntrada_DNI853["Id_Sector_DNI853"] = entrada_DNI853.IdSector_DNI853;
                    filaEntrada_DNI853["Detalle_DNI853"] = entrada_DNI853.Detalle_DNI853;

                    // Si la columna existe en BD, asegúrate de guardarla:
                    if (tablaEntrada_DNI853.Columns.Contains("Cantidad_DNI853"))
                    {
                        filaEntrada_DNI853["Cantidad_DNI853"] = entrada_DNI853.Cantidad_DNI853;
                    }

                    filaEntrada_DNI853["PrecioUnitario_DNI853"] = entrada_DNI853.PrecioUnitario_DNI853;

                    tablaEntrada_DNI853.Rows.Add(filaEntrada_DNI853);
                }

                SqlCommandBuilder builderEntrada_DNI853 = new SqlCommandBuilder(adapterEntrada_DNI853);
                adapterEntrada_DNI853.Update(dsEntrada_DNI853, "Entrada");
            }
        }
    }
}
