using BLL.BLL_Servicio;
using Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CuentaClara_TrabajoCampo
{
    public partial class FormCrearUsuario : Form, IObserverIdioma
    {
        public FormCrearUsuario()
        {
            InitializeComponent();
            GestorIdioma.GetInstancia().Suscribir(this);
        }

        private BLL_Rol bllRol = new BLL_Rol();

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                Servicio_Usuario usuario = new Servicio_Usuario();


                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.DNI = txtDNI.Text;
                usuario.email = txtCorreo.Text;
                //txtLogin.Text = txtNombre.Text + txtDNI.Text;
                //usuario.Login = txtLogin.Text;
                usuario.IdRol = cmbRol.SelectedValue.ToString();
                usuario.Activo = chkActivo.Checked ? 1 : 0;
                usuario.Login = txtNombre.Text + txtDNI.Text;

                BLL_Usuario bll = new BLL_Usuario();


                if (bll.CrearUsuario(usuario))
                {
                    MessageBox.Show(TraducirTexto("msg_UsuarioCreadoCorrectamente"));

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                string mensaje = TraducirExcepcion(ex);

                MessageBox.Show(mensaje);
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
       
        private string TraducirTexto(string clave)
        {
            string idIdioma = SessionManager.GetInstancia().GetUsuarioActual().Id_Idioma;

            BLL_Idioma bllIdioma = new BLL_Idioma();

            Servicio_Idioma idioma = bllIdioma.ObtenerIdiomaPorId(idIdioma);

            if (idioma == null)
                return clave;

            var etiqueta = idioma.Etiquetas.FirstOrDefault(x => x.Clave == clave);

            return etiqueta != null ? etiqueta.Texto : clave;
        }
        private void FormCrearUsuario_Load_1(object sender, EventArgs e)
        {
            cmbRol.DataSource = null;
            cmbRol.DataSource = bllRol.ObtenerRoles();
            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "IdRol";
            ActualizarIdioma();
            if (!posicionInicializada)
            {
                posicionOriginalPanel = panelPrincipal.Location;
                posicionInicializada = true;
            }

            ReacomodarPanel();
        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormCrearUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);


        }

        public void ActualizarIdioma()
        {
            string idIdioma =
            SessionManager.GetInstancia()
            .GetUsuarioActual()
            .Id_Idioma;

            BLL_Idioma bllIdioma = new BLL_Idioma();

            Servicio_Idioma idioma = bllIdioma.ObtenerIdiomaPorId(idIdioma);

            if (idioma == null)
                return;

            TraducirControles(this.Controls, idioma);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Point posicionOriginalPanel;
        private bool posicionInicializada = false;

        private void ReacomodarPanel()
        {
            if (!posicionInicializada)
                return;

            panelPrincipal.Location = new Point(
                (ClientSize.Width - panelPrincipal.Width) / 2,
                (ClientSize.Height - panelPrincipal.Height) / 2);
        }

        private void FormCrearUsuario_Resize(object sender, EventArgs e)
        {
            ReacomodarPanel();
        }
    }
}
