using BLL.BLL_Servicio;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IU
{
    public partial class FormPrimeraVez : Form
    {
        private BLL_Instalador bllInstalador = new BLL_Instalador();
        public FormPrimeraVez()
        {
            InitializeComponent();
        }

        private void FormPrimeraVez_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //listaServidores.Items.Clear();

            //try
            //{

            //    SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            //    DataTable table = instance.GetDataSources();

            //    foreach (DataRow row in table.Rows)
            //    {
            //        string serverName = row["ServerName"].ToString();
            //        string instanceName = row["InstanceName"].ToString();

            //        if (string.IsNullOrEmpty(instanceName))listaServidores.Items.Add(serverName);

            //        else listaServidores.Items.Add($"{serverName}\\{instanceName}");

            //    }


            //    if (listaServidores.Items.Count == 0)
            //    {
            //        listaServidores.Items.Add(".");
            //        listaServidores.Items.Add(".\\SQLEXPRESS");
            //        MessageBox.Show("No se detectaron servidores automáticamente en la red. Se agregaron las opciones locales por defecto ( . y .\\SQLEXPRESS ). También puedes escribir el nombre manualmente en la lista si lo deseas.", "Búsqueda finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al buscar servidores: " + ex.Message);
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
            this.Cursor = Cursors.WaitCursor;
            listaServidores.Items.Clear();

            try
            {
                List<string> servidores = bllInstalador.ObtenerListaServidores();

                foreach (string srv in servidores)
                {
                    listaServidores.Items.Add(srv);
                }

                if (servidores.Count == 2 && servidores.Contains("."))
                {
                    MessageBox.Show("No se detectaron servidores automáticamente en la red. Se agregaron las opciones locales por defecto ( . y .\\SQLEXPRESS ). También puedes escribir el nombre manualmente en la lista si lo deseas.", "Búsqueda finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar servidores: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (listaServidores.SelectedItem == null && string.IsNullOrWhiteSpace(listaServidores.Text))
            {
                MessageBox.Show("Por favor, selecciona o escribe el nombre de un servidor SQL.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string servidorElegido = listaServidores.SelectedItem != null? listaServidores.SelectedItem.ToString() : listaServidores.Text.Trim();
               
                
            this.Cursor = Cursors.WaitCursor;
            btnGuardar.Enabled = false;

            try
            {

                //var assembly = typeof(FormPrimeraVez).Assembly;

                //MessageBox.Show(assembly.Location);

                //string recursos = string.Join(Environment.NewLine, assembly.GetManifestResourceNames());

                //MessageBox.Show(recursos);

                var assembly = typeof(FormPrimeraVez).Assembly;

                using Stream stream = assembly.GetManifestResourceStream("IU.SetupData.sql");

                if (stream == null)
                    throw new Exception("No se encontró el recurso SetupData.sql.");

                using StreamReader reader = new StreamReader(stream);

                string script = reader.ReadToEnd();

                bllInstalador.InstalarBaseDeDatos(servidorElegido, script);

                MessageBox.Show("¡Base de datos instalada y configurada con éxito!",
                    "Configuración Completa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                btnGuardar.Enabled = true;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        private void EjecutarScriptSQL(string path, string connString)
        {
            string script = File.ReadAllText(path);
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string[] comandos = script.Split(new[] { "GO\r\n", "GO\n", "GO " }, StringSplitOptions.RemoveEmptyEntries);
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
