using BLL.BLL_Servicio;
using Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
namespace IU
{
    public partial class FormGestionPromocion_DNI853 : Form, IObserverIdioma
    {
        // Instancia de BLL Propia del negocio terminada en _DNI853
        private BLL_Promocion_DNI853 bllPromociones_DNI853;

        // Instancias de BLL de Servicios generales
        private BLL_Rol bllRol_DNI853;
        private BLL_Idioma bllIdioma_DNI853;

        // Variable de estado
        private BE_Promocion_DNI853 promocionSeleccionada_DNI853;

        public FormGestionPromocion_DNI853()
        {
            InitializeComponent();
            // Inicialización de gestores
            bllPromociones_DNI853 = new BLL_Promocion_DNI853();
            bllRol_DNI853 = new BLL_Rol();
            bllIdioma_DNI853 = new BLL_Idioma();

            // Configuración visual de la grilla
            dgvPromociones_DNI853.MultiSelect = false;
            dgvPromociones_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPromociones_DNI853.ReadOnly = true;

            // Suscripción al Patrón Observer de Idioma
            GestorIdioma.GetInstancia().Suscribir(this);
        }

        private void FormGestionPromocion_DNI853_Load(object sender, EventArgs e)
        {
            CargarUsuarioActivo_DNI853();
            ActualizarIdioma();

            // Carga inicial de opciones para el ComboBox de destino si no se hizo desde el diseñador
            if (cboDestinoPromo_DNI853.Items.Count == 0)
            {
                cboDestinoPromo_DNI853.Items.Add("Entradas");
                cboDestinoPromo_DNI853.Items.Add("Cantina");
            }

            ActualizarGrillaPromociones_DNI853();
        }

        // ====================================================================
        // GESTIÓN DE PROMOCIONES
        // ====================================================================

        private void ActualizarGrillaPromociones_DNI853()
        {
            try
            {
                dgvPromociones_DNI853.DataSource = null;
                dgvPromociones_DNI853.DataSource = bllPromociones_DNI853.ListarPromociones_DNI853();
                TraducirColumnasGrillas_DNI853();
                LimpiarControlesPromocion_DNI853();
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControlesPromocion_DNI853()
        {
            txtNombrePromo_DNI853.Text = string.Empty;
            if (cboTipoPromo_DNI853.Items.Count > 0) cboTipoPromo_DNI853.SelectedIndex = 0;
            txtValorDescuento_DNI853.Text = string.Empty;
            dtpFechaInicio_DNI853.Value = DateTime.Now;
            dtpFechaFin_DNI853.Value = DateTime.Now.AddDays(30);
            if (cboEstadoPromo_DNI853.Items.Count > 0) cboEstadoPromo_DNI853.SelectedIndex = 0;
            if (cboDestinoPromo_DNI853.Items.Count > 0) cboDestinoPromo_DNI853.SelectedIndex = 0;
            promocionSeleccionada_DNI853 = null;
        }

        private void dgvPromociones_DNI853_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPromociones_DNI853.CurrentRow != null)
            {
                promocionSeleccionada_DNI853 = (BE_Promocion_DNI853)dgvPromociones_DNI853.CurrentRow.DataBoundItem;

                txtNombrePromo_DNI853.Text = promocionSeleccionada_DNI853.NombrePromo_DNI853;
                cboTipoPromo_DNI853.SelectedItem = promocionSeleccionada_DNI853.TipoPromo_DNI853;
                txtValorDescuento_DNI853.Text = promocionSeleccionada_DNI853.ValorDescuento_DNI853.ToString();
                dtpFechaInicio_DNI853.Value = promocionSeleccionada_DNI853.FechaInicio_DNI853;
                dtpFechaFin_DNI853.Value = promocionSeleccionada_DNI853.FechaFin_DNI853;
                cboEstadoPromo_DNI853.SelectedItem = promocionSeleccionada_DNI853.EstadoPromo_DNI853;
                cboDestinoPromo_DNI853.SelectedItem = promocionSeleccionada_DNI853.DestinoPromo_DNI853;
            }
        }

        private void btnNuevaPromo_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Promocion_DNI853 objNuevaPromo_DNI853 = new BE_Promocion_DNI853
                {
                    NombrePromo_DNI853 = txtNombrePromo_DNI853.Text,
                    TipoPromo_DNI853 = cboTipoPromo_DNI853.SelectedItem?.ToString(),
                    ValorDescuento_DNI853 = decimal.Parse(txtValorDescuento_DNI853.Text),
                    FechaInicio_DNI853 = dtpFechaInicio_DNI853.Value,
                    FechaFin_DNI853 = dtpFechaFin_DNI853.Value,
                    EstadoPromo_DNI853 = cboEstadoPromo_DNI853.SelectedItem?.ToString(),
                    DestinoPromo_DNI853 = cboDestinoPromo_DNI853.SelectedItem?.ToString()
                };

                bool resultadoProc_DNI853 = bllPromociones_DNI853.CrearPromocion_DNI853(objNuevaPromo_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_PromocionCreada"));
                    ActualizarGrillaPromociones_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarPromo_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (promocionSeleccionada_DNI853 == null)
                    throw new Exception("err_SeleccionePromocionPrimero");

                promocionSeleccionada_DNI853.NombrePromo_DNI853 = txtNombrePromo_DNI853.Text;
                promocionSeleccionada_DNI853.TipoPromo_DNI853 = cboTipoPromo_DNI853.SelectedItem?.ToString();
                promocionSeleccionada_DNI853.ValorDescuento_DNI853 = decimal.Parse(txtValorDescuento_DNI853.Text);
                promocionSeleccionada_DNI853.FechaInicio_DNI853 = dtpFechaInicio_DNI853.Value;
                promocionSeleccionada_DNI853.FechaFin_DNI853 = dtpFechaFin_DNI853.Value;
                promocionSeleccionada_DNI853.EstadoPromo_DNI853 = cboEstadoPromo_DNI853.SelectedItem?.ToString();
                promocionSeleccionada_DNI853.DestinoPromo_DNI853 = cboDestinoPromo_DNI853.SelectedItem?.ToString();

                bool resultadoProc_DNI853 = bllPromociones_DNI853.ModificarPromocion_DNI853(promocionSeleccionada_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_PromocionModificada"));
                    ActualizarGrillaPromociones_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarPromo_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (promocionSeleccionada_DNI853 == null)
                    throw new Exception("err_SeleccionePromocionPrimero");

                bool resultadoProc_DNI853 = bllPromociones_DNI853.EliminarPromocion_DNI853(promocionSeleccionada_DNI853.IdPromo_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_PromocionEliminada"));
                    ActualizarGrillaPromociones_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ====================================================================
        // EVENTOS GENERALES
        // ====================================================================
        private void btnSalir_DNI853_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormGestionPromocion_DNI853_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);
        }

        private void FormGestionPromocion_DNI853_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                return;

            int altoDisponible_DNI853 = ClientSize.Height - panelInferior_DNI853.Height;

            panelContenedor_DNI853.Location = new Point(
                (ClientSize.Width - panelContenedor_DNI853.Width) / 2,
                (altoDisponible_DNI853 - panelContenedor_DNI853.Height) / 2
            );
        }

        // ====================================================================
        // MANEJO DE SESIÓN Y SEGURIDAD
        // ====================================================================

        private void CargarUsuarioActivo_DNI853()
        {
            Servicio_Usuario usuarioActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual();

            if (usuarioActual_DNI853 != null)
            {
                string nombreRol_DNI853 = bllRol_DNI853.ObtenerNombreRol(usuarioActual_DNI853.IdRol);
                lblUsuarioValor_DNI853.Text = $"{usuarioActual_DNI853.Login} - {nombreRol_DNI853}";
                BloquearBotonesSegunPermisos_DNI853(usuarioActual_DNI853);
            }
        }

        private void BloquearBotonesSegunPermisos_DNI853(Servicio_Usuario usuarioActual_DNI853)
        {
            if (usuarioActual_DNI853 == null || usuarioActual_DNI853.Permisos == null)
            {
                btnNuevaPromo_DNI853.Enabled = false;
                btnModificarPromo_DNI853.Enabled = false;
                btnEliminarPromo_DNI853.Enabled = false;
                return;
            }
        }

        // ====================================================================
        // PATRÓN OBSERVER: IDIOMA
        // ====================================================================

        public void ActualizarIdioma()
        {
            Servicio_Usuario usuarioActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual();
            if (usuarioActual_DNI853 == null) return;

            string idIdioma_DNI853 = usuarioActual_DNI853.Id_Idioma;
            Servicio_Idioma idiomaActual_DNI853 = bllIdioma_DNI853.ObtenerIdiomaPorId(idIdioma_DNI853);

            if (idiomaActual_DNI853 == null) return;

            TraducirControles_DNI853(this.Controls, idiomaActual_DNI853);
            TraducirColumnasGrillas_DNI853();
        }

        private void TraducirControles_DNI853(Control.ControlCollection controles_DNI853, Servicio_Idioma idioma_DNI853)
        {
            foreach (Control control_DNI853 in controles_DNI853)
            {
                if (control_DNI853.Tag != null)
                {
                    string clave_DNI853 = control_DNI853.Tag.ToString();
                    var etiqueta_DNI853 = idioma_DNI853.Etiquetas.FirstOrDefault(x => x.Clave == clave_DNI853);

                    if (etiqueta_DNI853 != null)
                        control_DNI853.Text = etiqueta_DNI853.Texto;
                }

                if (control_DNI853.HasChildren)
                {
                    TraducirControles_DNI853(control_DNI853.Controls, idioma_DNI853);
                }
            }
        }

        private string TraducirTexto_DNI853(string claveParam_DNI853)
        {
            string idIdiomaActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Id_Idioma;
            Servicio_Idioma idiomaActual_DNI853 = bllIdioma_DNI853.ObtenerIdiomaPorId(idIdiomaActual_DNI853);

            if (idiomaActual_DNI853 == null) return claveParam_DNI853;

            var etiquetaObtenida_DNI853 = idiomaActual_DNI853.Etiquetas.FirstOrDefault(x => x.Clave == claveParam_DNI853);
            return etiquetaObtenida_DNI853 != null ? etiquetaObtenida_DNI853.Texto : claveParam_DNI853;
        }

        private void TraducirColumnasGrillas_DNI853()
        {
            if (dgvPromociones_DNI853.Columns.Contains("NombrePromo_DNI853"))
                dgvPromociones_DNI853.Columns["NombrePromo_DNI853"].HeaderText = TraducirTexto_DNI853("ColNombrePromo");

            if (dgvPromociones_DNI853.Columns.Contains("TipoPromo_DNI853"))
                dgvPromociones_DNI853.Columns["TipoPromo_DNI853"].HeaderText = TraducirTexto_DNI853("ColTipoPromo");

            if (dgvPromociones_DNI853.Columns.Contains("ValorDescuento_DNI853"))
                dgvPromociones_DNI853.Columns["ValorDescuento_DNI853"].HeaderText = TraducirTexto_DNI853("ColValorDescuento");

            if (dgvPromociones_DNI853.Columns.Contains("FechaInicio_DNI853"))
                dgvPromociones_DNI853.Columns["FechaInicio_DNI853"].HeaderText = TraducirTexto_DNI853("ColFechaInicio");

            if (dgvPromociones_DNI853.Columns.Contains("FechaFin_DNI853"))
                dgvPromociones_DNI853.Columns["FechaFin_DNI853"].HeaderText = TraducirTexto_DNI853("ColFechaFin");

            if (dgvPromociones_DNI853.Columns.Contains("EstadoPromo_DNI853"))
                dgvPromociones_DNI853.Columns["EstadoPromo_DNI853"].HeaderText = TraducirTexto_DNI853("ColEstadoPromo");

            if (dgvPromociones_DNI853.Columns.Contains("DestinoPromo_DNI853"))
                dgvPromociones_DNI853.Columns["DestinoPromo_DNI853"].HeaderText = TraducirTexto_DNI853("ColDestinoPromo");
        }

        private string TraducirExcepcion_DNI853(Exception ex_DNI853)
        {
            string[] partesExcepcion_DNI853 = ex_DNI853.Message.Split('|');
            string claveEx_DNI853 = partesExcepcion_DNI853[0];
            string mensajeTraducido_DNI853 = TraducirTexto_DNI853(claveEx_DNI853);

            if (partesExcepcion_DNI853.Length > 1)
            {
                mensajeTraducido_DNI853 += " " + partesExcepcion_DNI853[1];
            }
            return mensajeTraducido_DNI853;
        }
    }
}
