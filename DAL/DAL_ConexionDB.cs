using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ConexionDB
    {
      
        private static string ObtenerServidor()
        {
            string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CuentaClara");
            string rutaConfig = Path.Combine(appDataFolder, "servidor_config.txt");

            if (File.Exists(rutaConfig))
            {
                return File.ReadAllText(rutaConfig).Trim();
            }
            return "."; 
        }

       
        public static string ObtenerCadena()
        {
            string servidor = ObtenerServidor();
            return $"Data Source={servidor};Initial Catalog= BD_TeatroLux_DNI853;Integrated Security=True;TrustServerCertificate=True;";
        }


        public static string ObtenerCadenaMaster(string servidorParam)
        {
            string servidor = servidorParam ?? ObtenerServidor();
            return $"Data Source={servidor};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;";
        }
        public static bool VerificarBaseDatosExistente(string servidorElegido = null)
        {
            try
            {
              
                string connString = ObtenerCadenaMaster(servidorElegido);
                string consulta = "SELECT name FROM sys.databases WHERE name = 'BD_TeatroLux_DNI853'";

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(consulta, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt.Rows.Count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public DataTable ObtenerServidoresRed()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            return instance.GetDataSources();
        }


        public void EjecutarScriptSQL(string script, string servidor)
        {
            string connString = ObtenerCadenaMaster(servidor);
            string[] comandos = script.Split(new[] { "GO\r\n", "GO\n", "GO " }, StringSplitOptions.RemoveEmptyEntries);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                foreach (string comando in comandos)
                {
                    if (!string.IsNullOrWhiteSpace(comando))
                    {
                        using (SqlCommand cmd = new SqlCommand(comando, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}

