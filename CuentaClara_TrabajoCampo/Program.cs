using IU;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using BLL.BLL_Servicio;

namespace CuentaClara_TrabajoCampo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
        
            ApplicationConfiguration.Initialize();

            BLL_Instalador gestorInstalacion = new BLL.BLL_Servicio.BLL_Instalador();

            if (gestorInstalacion.EsNecesarioInstalar())
            {
                FormPrimeraVez frmConfig = new FormPrimeraVez();

                if (frmConfig.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("La configuración inicial es obligatoria para iniciar el sistema.", "Instalación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Application.Run(new frmLogIn());
        }
    }
}