using Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using BLL.BLL_Servicio;

namespace CuentaClara_TrabajoCampo
{
    public partial class FormGestionBitacora : Form, IObserverIdioma
    {
        private BLL_BitacoraEvento bll = new BLL_BitacoraEvento();
        private BLL_Usuario bllUsuario = new BLL_Usuario();
        private BLL_PDF bllPdf = new BLL_PDF();
        private BLL_Rol bllRol = new BLL_Rol();
        public FormGestionBitacora()
        {
            InitializeComponent();
            GestorIdioma.GetInstancia().Suscribir(this);
        }
        private void DeshabilitarBotones()
        {
            btnAplicar.Enabled = false;
            btnImprimir.Enabled = false;
            btnLimpiar.Enabled = false;
            btnSalir.Enabled = true;
        }
        private void RefrescarSesionUsuario()
        {
            var login = SessionManager.GetInstancia().GetUsuarioActual().Login;

            var bllUsuario = new BLL_Usuario();
            var usuarioActualizado = bllUsuario.RecargarUsuarioSesion(login);

            SessionManager.GetInstancia().SetUsuarioActual(usuarioActualizado);
        }
        private void ActualizarContador()
        {
            if (dgvBitacora.DataSource != null)
            {

                if (dgvBitacora.DataSource is List<Servicio_Bitacora> lista)
                {
                    label2.Text = lista.Count.ToString();
                }
                else
                {
                    label2.Text = dgvBitacora.Rows.Count.ToString();
                }
            }
            else
            {
                label2.Text = "0";
            }
        }
        private void BloquearBotonesSegunPermisos(Servicio_Usuario usuarioActual)
        {
            if (usuarioActual == null || usuarioActual.Permisos == null)
            {
                DeshabilitarBotones();
                return;
            }

            btnAplicar.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P6"); // Bitacora_Consultar
            btnImprimir.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P7"); // Bitacora_Exportar

            btnLimpiar.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P6");

            btnSalir.Enabled = true;
        }
        private void CargarLogins()
        {
            cboLogin.DataSource = bllUsuario.ListarLogins();
            cboLogin.DisplayMember = "Login";
            cboLogin.ValueMember = "Login";

            cboLogin.SelectedIndex = -1;
        }
        private void CargarUltimos3Dias()
        {
            dgvBitacora.DataSource = bll.ListarUltimos3Dias();

            dgvBitacora.Columns["Login"].HeaderText = TraducirTexto("Login");
            dgvBitacora.Columns["Evento"].HeaderText = TraducirTexto("Evento");
            dgvBitacora.Columns["Modulo"].HeaderText = TraducirTexto("Modulo");
            dgvBitacora.Columns["Criticidad"].HeaderText = TraducirTexto("Criticidad");
            dgvBitacora.Columns["Fecha"].HeaderText = TraducirTexto("Fecha");
            dgvBitacora.Columns["Hora"].HeaderText = TraducirTexto("Hora");


            lstMensajes.Items.Clear();
            //lstMensajes.Items.Add("Se cargaron los eventos de los últimos 3 días.");
            lstMensajes.Items.Add(TraducirTexto("EventosUltimos3Dias"));
            if (dgvBitacora.Rows.Count > 0) dgvBitacora.Rows[0].Selected = true;
            ActualizarContador();

        }


        private void FormGestionBitacora_Load_1(object sender, EventArgs e)
        {

            FormGestionBitacora_Resize(null, null);

            RefrescarSesionUsuario();
            List<string> listaEventos = bll.ObtenerEventosBase();

            listaEventos.Insert(0, "Todos");

            cboEvento.DataSource = listaEventos;
            cboEvento.SelectedIndex = 0;
            var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
            BLL_Rol bllRol = new BLL_Rol(); BloquearBotonesSegunPermisos(usuarioActual);

            string nombreLegibleDelRol = bllRol.ObtenerNombreRol(usuarioActual.IdRol);

            lblUsuarioActivo.Text = $"Usuario:";
            lblUsuarioValor.Text = $"{usuarioActual.Login}-{nombreLegibleDelRol}";

            CargarUltimos3Dias();
            ActualizarContador();
            CargarLogins();
            ActualizarIdioma();

        }

        private void dgvBitacora_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBitacora.SelectedRows.Count == 0 && dgvBitacora.CurrentRow == null) return;

            try
            {
                DataGridViewRow row = dgvBitacora.CurrentRow;


                if (row.Cells["Login"].Value != null)
                {
                    string login = row.Cells["Login"].Value.ToString();


                    Servicio_Usuario user = bllUsuario.ObtenerUsuarioPorLogin(login);

                    if (user != null)
                    {
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                    }
                    else
                    {

                        txtNombre.Text = "N/A";
                        txtApellido.Text = "N/A";
                    }
                }
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine("Error cargando detalles: " + ex.Message);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            dgvBitacora.DataSource = bll.FiltrarBitacora(cboLogin.Text, dtpFechaInicio.Value, dtpFechaFin.Value, cboModulo.Text, cboEvento.Text,

            string.IsNullOrEmpty(cboCriticidad.Text) ? (int?)null : Convert.ToInt32(cboCriticidad.Text));

            dgvBitacora.Refresh();

            ActualizarContador();

            lstMensajes.Items.Clear();

            if (dgvBitacora.Rows.Count > 0)
                //lstMensajes.Items.Add("Filtro aplicado correctamente. Registros encontrados: " + dgvBitacora.Rows.Count);
                lstMensajes.Items.Add(TraducirTexto("FiltroAplicado") + " " + dgvBitacora.Rows.Count);

            else
                //lstMensajes.Items.Add("No se encontraron registros para los filtros seleccionados.");
                lstMensajes.Items.Add(TraducirTexto("SinRegistros"));

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboLogin.SelectedIndex = -1;
            cboModulo.SelectedIndex = -1;
            cboEvento.SelectedIndex = -1;
            cboCriticidad.SelectedIndex = -1;

            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;

            lstMensajes.Items.Clear();
            //lstMensajes.Items.Add("Filtros restablecidos.");
            lstMensajes.Items.Add(TraducirTexto("FiltrosRestablecidos"));
            CargarUltimos3Dias();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Bitacora.pdf";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    string login = dgvBitacora.CurrentRow.Cells["Login"].Value.ToString();

                    List<Servicio_Bitacora> lista = (List<Servicio_Bitacora>)dgvBitacora.DataSource;

                    bllPdf.ExportarBitacora(lista, save.FileName, login);


                    //MessageBox.Show("PDF generado correctamente.");
                    MessageBox.Show(TraducirTexto("PdfGenerado"));
                }
            }
            catch (Exception ex)
            {
                string mensaje = TraducirExcepcion(ex);
                //MessageBox.Show("Error al generar el PDF: " + ex.Message);
                MessageBox.Show(TraducirTexto("ErrorPdf") + ": " + mensaje);
            }
        }

        private void FormGestionBitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);


        }

        public void ActualizarIdioma()
        {
            string idIdioma = SessionManager.GetInstancia().GetUsuarioActual().Id_Idioma;

            BLL_Idioma bllIdioma = new BLL_Idioma();

            Servicio_Idioma idioma = bllIdioma.ObtenerIdiomaPorId(idIdioma);

            if (idioma == null) return;


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

                if (c.HasChildren) TraducirControles(c.Controls, idioma);

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


        private void FormGestionBitacora_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                return;

            int altoDisponible = ClientSize.Height - panelInferior.Height;

            panelContenedor.Location = new Point(
                (ClientSize.Width - panelContenedor.Width) / 2,
                (altoDisponible - panelContenedor.Height) / 2
            );
        }

        private void lblUsuarioValor_Click(object sender, EventArgs e)
        {

        }

        private void cboEvento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
