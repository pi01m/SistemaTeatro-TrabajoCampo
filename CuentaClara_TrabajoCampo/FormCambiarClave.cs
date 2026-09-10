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
    public partial class FormCambiarClave : Form, IObserverIdioma
    {
        BLL_Usuario _bllUsuario;
        BLL_BitacoraEvento _bllBitacoraEvento;
        public FormCambiarClave()
        {
            InitializeComponent();
            GestorIdioma.GetInstancia().Suscribir(this);
        }

        private void FormCambiarClave_Load_1(object sender, EventArgs e)
        {
            var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
            BLL_Rol bllRol = new BLL_Rol();


            string nombreLegibleDelRol = bllRol.ObtenerNombreRol(usuarioActual.IdRol);

            lblUsuarioActivo.Text = TraducirTexto("lbl_Usuario");
            lblUsuarioValor.Text = $"{usuarioActual.Login}-{nombreLegibleDelRol}";
            _bllUsuario = new BLL_Usuario();
            _bllBitacoraEvento = new BLL_BitacoraEvento();
            ActualizarIdioma();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtClaveActual.Text) || string.IsNullOrWhiteSpace(txtNuevaClave.Text))
                {
                    MessageBox.Show(TraducirTexto("msg_CamposObligatorios"),TraducirTexto("msg_Atencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string ClaveVieja = txtClaveActual.Text;
                string ClaveNueva = txtNuevaClave.Text;
                bool resultado = _bllUsuario.CambiarClave(ClaveVieja, ClaveNueva);

                if (resultado)
                {
                    MessageBox.Show(TraducirTexto("msg_ClaveModificadaCorrectamente"),TraducirTexto("msg_Exito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(TraducirTexto("msg_ErrorCambioClave"),TraducirTexto("msg_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                string mensaje = TraducirExcepcion(ex);

                MessageBox.Show(mensaje);
            }
        }

        private void FormCambiarClave_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);

            
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
    }
}
