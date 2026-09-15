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
                        Cantidad_DNI853 = Convert.ToInt32(fila_DNI853["Cantidad_DNI853"]),
                        PrecioUnitario_DNI853 = Convert.ToDecimal(fila_DNI853["PrecioUnitario_DNI853"])
                    };

                    listaEntradas_DNI853.Add(entrada_DNI853);
                }
            }

            return listaEntradas_DNI853;
        }

        // Método encargado exclusivamente de insertar las entradas usando la misma transacción abierta
        public void RegistrarEntradas_DNI853(List<BE_Entrada_DNI853> entradas_DNI853, SqlConnection conexion_DNI853, SqlTransaction transaccion_DNI853)
        {
            SqlDataAdapter adapterEntrada = new SqlDataAdapter("SELECT * FROM Entrada_DNI853 WHERE 1 = 0", conexion_DNI853);
            adapterEntrada.SelectCommand.Transaction = transaccion_DNI853;

            DataSet dsEntrada = new DataSet();
            adapterEntrada.Fill(dsEntrada, "Entrada");
            DataTable tablaEntrada = dsEntrada.Tables["Entrada"];

            foreach (BE_Entrada_DNI853 entrada in entradas_DNI853)
            {
                DataRow filaEntrada = tablaEntrada.NewRow();
                filaEntrada["Id_Entrada_DNI853"] = entrada.Id_Entrada_DNI853;
                filaEntrada["Id_Factura_DNI853"] = entrada.Id_Factura_DNI853;
                filaEntrada["Id_Funcion_DNI853"] = entrada.IdFuncion_DNI853;
                filaEntrada["Id_Sector_DNI853"] = entrada.IdSector_DNI853;
                filaEntrada["Detalle_DNI853"] = entrada.Detalle_DNI853;
                filaEntrada["Cantidad_DNI853"] = entrada.Cantidad_DNI853;
                filaEntrada["PrecioUnitario_DNI853"] = entrada.PrecioUnitario_DNI853;
                filaEntrada["Subtotal_DNI853"] = entrada.Subtotal_DNI853;

                tablaEntrada.Rows.Add(filaEntrada);
            }

            SqlCommandBuilder builderEntrada = new SqlCommandBuilder(adapterEntrada);
            adapterEntrada.Update(dsEntrada, "Entrada");
        }
    }
}
