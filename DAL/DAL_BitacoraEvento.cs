using Microsoft.Data.SqlClient;
using Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL
{
    public class DAL_BitacoraEvento
    {
        private readonly string _connectionString = DAL_ConexionDB.ObtenerCadena();
        //private readonly string _connectionString = "Data Source =.; Initial Catalog = BD_TeatroLux_DNI853; Integrated Security = True; Trust Server Certificate=True";

        public DAL_BitacoraEvento()
        {
          
        } 

        private List<Servicio_Bitacora> MapearTablaALista(DataTable tabla)
        {
            List<Servicio_Bitacora> listaEventos = new List<Servicio_Bitacora>();

            foreach (DataRow fila in tabla.Rows)
            {
                Servicio_Bitacora bit = new Servicio_Bitacora();

                bit.id_Evento = fila["idEvento"].ToString();
                bit.Evento = fila["Evento"].ToString();
                bit.Login = fila["Login"].ToString();
                bit.Modulo = fila["Modulo"].ToString();
                bit.Criticidad = Convert.ToInt32(fila["Criticidad"]);
                bit.Fecha = Convert.ToDateTime(fila["Fecha"]);
                bit.Hora = fila["Hora"].ToString();

                listaEventos.Add(bit);
            }

            return listaEventos;
        }
        public bool GuardarBitacora(Servicio_Bitacora bitacora)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter adapter =new SqlDataAdapter("SELECT * FROM Bitacora WHERE 1 = 0", conn);
                        

                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Bitacora");

                    DataTable tabla = ds.Tables["Bitacora"];

                    DataRow fila = tabla.NewRow();

                    fila["idEvento"] = bitacora.id_Evento;
                    fila["Evento"] = bitacora.Evento;
                    fila["Login"] = bitacora.Login;
                    fila["Modulo"] = bitacora.Modulo;
                    fila["Fecha"] = bitacora.Fecha.Date;
                    fila["Hora"] = bitacora.Hora;
                    fila["Criticidad"] = bitacora.Criticidad;

                    tabla.Rows.Add(fila);

                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    adapter.Update(ds, "Bitacora");

                    return true;
                }
            }
            catch (Exception ex)
            {
              
                return false;
            }
        }

        public List<Servicio_Bitacora> ListarBitacora()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter =new SqlDataAdapter("SELECT * FROM Bitacora ORDER BY Fecha DESC, Hora DESC", conn);
                    

                DataTable tablaVirtual = new DataTable();
                adapter.Fill(tablaVirtual);
                return MapearTablaALista(tablaVirtual);
            }
        }

        public List<Servicio_Bitacora> ListarUltimos3Dias()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
              
                string sql = @"SELECT * FROM Bitacora WHERE Fecha >= CONVERT(DATE, DATEADD(DAY, -3, GETDATE())) ORDER BY Fecha DESC, Hora DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable tablaVirtual = new DataTable();
                adapter.Fill(tablaVirtual);

                return MapearTablaALista(tablaVirtual);
            }
        }

        public List<Servicio_Bitacora> FiltrarBitacora(string login, DateTime desde, DateTime hasta, string modulo, string evento, int? criticidad)
        {
            if (hasta < desde) hasta = desde;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                StringBuilder sql = new StringBuilder("SELECT * FROM Bitacora WHERE 1=1 ");
                SqlCommand cmd = new SqlCommand();

                if (!string.IsNullOrWhiteSpace(login))
                {
                    sql.Append("AND Login LIKE @Login ");
                    cmd.Parameters.AddWithValue("@Login", "%" + login.Trim() + "%");
                }

                if (!string.IsNullOrWhiteSpace(modulo))
                {
                    sql.Append("AND Modulo LIKE @Modulo ");
                    cmd.Parameters.AddWithValue("@Modulo", "%" + modulo.Trim() + "%");
                }

                if (!string.IsNullOrWhiteSpace(evento))
                {
                    sql.Append("AND Evento LIKE @Evento ");
                    cmd.Parameters.AddWithValue("@Evento", "%" + evento.Trim() + "%");
                }

                // Criticidad sigue siendo igual (es un número exacto)
                if (criticidad.HasValue)
                {
                    sql.Append("AND Criticidad = @Criticidad ");
                    cmd.Parameters.AddWithValue("@Criticidad", criticidad.Value);
                }

                // Filtro de fechas (es obligatorio)
                sql.Append("AND Fecha BETWEEN @Desde AND @Hasta ");
                cmd.Parameters.AddWithValue("@Desde", desde.Date);
                cmd.Parameters.AddWithValue("@Hasta", hasta.Date.AddHours(23).AddMinutes(59).AddSeconds(59));

                sql.Append("ORDER BY Fecha DESC, Hora DESC");

                cmd.CommandText = sql.ToString();
                cmd.Connection = conn;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tablaVirtual = new DataTable();
                adapter.Fill(tablaVirtual);

                return MapearTablaALista(tablaVirtual);
            }
        }

     
    }
}
