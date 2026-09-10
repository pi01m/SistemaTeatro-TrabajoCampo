using IU;
using Microsoft.Data.SqlClient;
using Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IU.Properties;
using BLL.BLL_Servicio;

namespace CuentaClara_TrabajoCampo
{
    public partial class frmLogIn : Form, IObserverIdioma
    {
        private readonly BLL_Usuario _bllUsuario;
        private BLL_Idioma bllIdioma;
        private bool contraseñaVisible = false;
        public frmLogIn()
        {
            GestorIdioma.GetInstancia().Suscribir(this);
            InitializeComponent();
            _bllUsuario = new BLL_Usuario();
        }

        private void frmLogIn_Load_1(object sender, EventArgs e)
        {
            BLL_Usuario bllUsuario = new BLL_Usuario();

            try
            {

                if (!bllUsuario.ExisteAlgunaCuenta())
                {
                    MessageBox.Show("Es la primera vez que inicia el sistema. Por favor, registre al administrador inicial.");


                    FormCrearPrimerUsuario formAlta = new FormCrearPrimerUsuario();
                    formAlta.ShowDialog();

                    if (!bllUsuario.ExisteAlgunaCuenta())
                    {
                        MessageBox.Show("No se pudo crear el administrador. El sistema se cerrará.");
                        Application.Exit();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el estado del sistema: " + ex.Message);
            }

            bllIdioma = new BLL_Idioma();

            comboBox1.DataSource = bllIdioma.ListarIdiomasBD();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id_Idioma";

            txtContrasena.UseSystemPasswordChar = true;

            ojo.Text = "";
            CambiarImagenOjo(Resources.ojo_abierto);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                MostrarError(TraducirTexto("msg_DebeCompletarCampos"));
                return;
            }

            string nombreUsuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            btnIngresar.Enabled = false;

            try
            {

                bool loginExitoso = _bllUsuario.CargarCredenciales(nombreUsuario, contrasena);

                if (loginExitoso)
                {
                    string idIdioma = comboBox1.SelectedValue.ToString();
                    _bllUsuario.CambiarIdiomaEnSesion(idIdioma);

                    ConfigurarMenu();
                    MostrarPantallaPrincipal();
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                string mensaje = TraducirExcepcion(ex);
                string tituloError = TraducirTexto("msg_TituloErrorLogin") != "msg_TituloErrorLogin"
                                     ? TraducirTexto("msg_TituloErrorLogin")
                                     : TraducirTexto("msg_ErrorAutenticacion");

                MessageBox.Show(mensaje, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {

                btnIngresar.Enabled = true;
            }
        }
        private string TraducirExcepcion(Exception ex)
        {
            string[] partes = ex.Message.Split('|');

            string clave = partes[0];

            string mensaje = TraducirTexto(clave);

            if (partes.Length > 1)
            {
                mensaje += " " + partes[1];
            }

            return mensaje;
        }
        private void ConfigurarMenu()
        {
            Servicio_Usuario usuarioSesion = SessionManager.GetInstancia().GetUsuarioActual();
            if (usuarioSesion == null) return;

            foreach (Servicio_Rol permiso in usuarioSesion.Permisos.ListaPermisos)
            {

                System.Diagnostics.Debug.WriteLine($"Permiso cargado: {permiso.IdRol} – {permiso.Nombre}");
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtContrasena.Text)) return false;
            return true;
        }



        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private void MostrarPantallaPrincipal()
        {
            FormMenu fr = new FormMenu();

            this.Hide();

            fr.ShowDialog();

            this.Show();
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ActualizarIdioma()
        {
            string idIdioma = comboBox1.SelectedValue.ToString();

            BLL_Idioma bllIdioma = new BLL_Idioma();

            Servicio_Idioma idioma =
                bllIdioma.ObtenerIdiomaPorId(idIdioma);

            if (idioma == null)
                return;

            TraducirControles(this.Controls, idioma);
        }
        private string TraducirTexto(string clave)
        {
            string idIdioma = comboBox1.SelectedValue.ToString();

            BLL_Idioma bllIdioma = new BLL_Idioma();

            Servicio_Idioma idioma = bllIdioma.ObtenerIdiomaPorId(idIdioma);

            if (idioma == null)
                return clave;

            var etiqueta = idioma.Etiquetas.FirstOrDefault(x => x.Clave == clave);

            return etiqueta != null ? etiqueta.Texto : clave;
        }

        private void TraducirControles(Control.ControlCollection controles, Servicio_Idioma idioma)
        {
            foreach (Control c in controles)
            {
                if (c.Tag != null)
                {
                    string clave = c.Tag.ToString();

                    var etiqueta = idioma.Etiquetas.FirstOrDefault(x => x.Clave == clave);
                    if (etiqueta != null) c.Text = etiqueta.Texto;

                }

                if (c is DataGridView dgv)
                {
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        string clave = col.Name;

                        var etiqueta = idioma.Etiquetas.FirstOrDefault(x => x.Clave == clave);

                        if (etiqueta != null) col.HeaderText = etiqueta.Texto;

                    }
                }

                if (c.HasChildren)
                    TraducirControles(c.Controls, idioma);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarIdioma();
        }

        private void frmLogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);
        }

        private void frmLogIn_Resize(object sender, EventArgs e)
        {
            if (panelLogin != null)
            {

                panelLogin.Left = (this.ClientSize.Width - panelLogin.Width) / 2;
                panelLogin.Top = (this.ClientSize.Height - panelLogin.Height) / 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contraseñaVisible = !contraseñaVisible;

            if (contraseñaVisible)
            {
                // Mostrar contraseña
                txtContrasena.UseSystemPasswordChar = false;

                // Ojo cerrado
                CambiarImagenOjo(Resources.ojo_cerrado);
            }
            else
            {
                // Ocultar contraseña
                txtContrasena.UseSystemPasswordChar = true;

                // Ojo abierto
                CambiarImagenOjo(Resources.ojo_abierto);
            }
        }
        private void CambiarImagenOjo(Bitmap imagen)
        {
            ojo.Image = new Bitmap(imagen, new Size(38, 34));
            ojo.ImageAlign = ContentAlignment.MiddleCenter;
        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
