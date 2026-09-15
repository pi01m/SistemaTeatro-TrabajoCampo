using BE;
using BLL;
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
namespace IU
{
    public partial class FormGestionFunciones_DNI853 : Form, IObserverIdioma
    {
        // Instancias de BLL Propias del negocio terminadas en _DNI853
        private BLL_Funcion_DNI853 bllFunciones_DNI853;
        private BLL_Obra_DNI853 bllObras_DNI853;
        private BLL_Sala_DNI853 bllSalas_DNI853;

        // Instancias de BLL de Servicios generales
        private BLL_Rol bllRol_DNI853;
        private BLL_Idioma bllIdioma_DNI853;

        // Variable de estado
        private BE_Funcion_DNI853 funcionSeleccionada_DNI853;
        public FormGestionFunciones_DNI853()
        {
            InitializeComponent();
            // Inicialización de gestores
            bllFunciones_DNI853 = new BLL_Funcion_DNI853();
            bllObras_DNI853 = new BLL_Obra_DNI853();
            bllSalas_DNI853 = new BLL_Sala_DNI853();
            bllRol_DNI853 = new BLL_Rol();
            bllIdioma_DNI853 = new BLL_Idioma();

            // Configuración visual de la grilla
            dgvFunciones_DNI853.MultiSelect = false;
            dgvFunciones_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFunciones_DNI853.ReadOnly = true;

            // Suscripción al Patrón Observer de Idioma
            GestorIdioma.GetInstancia().Suscribir(this);
        }

        private void FormGestionFunciones_DNI853_Load(object sender, EventArgs e)
        {
            CargarUsuarioActivo_DNI853();
            ActualizarIdioma();
            CargarCombos_DNI853();
            ActualizarGrillaFunciones_DNI853();
        }

        // ====================================================================
        // CARGA DE COMBOS Y GRILLA
        // ====================================================================

        private void CargarCombos_DNI853()
        {
            try
            {
                // Cargar ComboBox de Obras 
                cboObra_DNI853.DataSource = null;
                cboObra_DNI853.DataSource = bllObras_DNI853.ListarObrasDisponibles_DNI853();
                cboObra_DNI853.DisplayMember = "NombreObra_DNI853";
                cboObra_DNI853.ValueMember = "IdObra_DNI853";

                // Cargar ComboBox de Salas
                cboSala_DNI853.DataSource = null;
                cboSala_DNI853.DataSource = bllSalas_DNI853.ListarSalas_DNI853();
                cboSala_DNI853.DisplayMember = "NombreSala_DNI853";
                cboSala_DNI853.ValueMember = "IdSala_DNI853";
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarGrillaFunciones_DNI853()
        {
            try
            {
                dgvFunciones_DNI853.DataSource = null;
                dgvFunciones_DNI853.DataSource = bllFunciones_DNI853.ListarFunciones_DNI853();
                TraducirColumnasGrillas_DNI853();
                LimpiarControlesFuncion_DNI853();
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControlesFuncion_DNI853()
        {
            if (cboObra_DNI853.Items.Count > 0) cboObra_DNI853.SelectedIndex = 0;
            if (cboSala_DNI853.Items.Count > 0) cboSala_DNI853.SelectedIndex = 0;
            if (cboEstado_DNI853.Items.Count > 0) cboEstado_DNI853.SelectedIndex = 0;
            dtpFecha_DNI853.Value = DateTime.Now;
            txtHoraInicio_DNI853.Text = string.Empty;
            txtHoraFinalizacion_DNI853.Text = string.Empty;
            funcionSeleccionada_DNI853 = null;
        }

        private void dgvFunciones_DNI853_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFunciones_DNI853.CurrentRow != null)
            {
                funcionSeleccionada_DNI853 = (BE_Funcion_DNI853)dgvFunciones_DNI853.CurrentRow.DataBoundItem;

                cboObra_DNI853.SelectedValue = funcionSeleccionada_DNI853.IdObra_DNI853;
                cboSala_DNI853.SelectedValue = funcionSeleccionada_DNI853.IdSala_DNI853;
                dtpFecha_DNI853.Value = funcionSeleccionada_DNI853.Fecha_DNI853;
                txtHoraInicio_DNI853.Text = funcionSeleccionada_DNI853.HoraInicio_DNI853;
                txtHoraFinalizacion_DNI853.Text = funcionSeleccionada_DNI853.HoraFinalizacion_DNI853;
                cboEstado_DNI853.SelectedItem = funcionSeleccionada_DNI853.Estado_DNI853;
            }
        }

        private void btnNuevaFuncion_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Funcion_DNI853 objNuevaFuncion_DNI853 = new BE_Funcion_DNI853
                {
                    IdObra_DNI853 = cboObra_DNI853.SelectedValue?.ToString(),
                    IdSala_DNI853 = cboSala_DNI853.SelectedValue?.ToString(),
                    Fecha_DNI853 = dtpFecha_DNI853.Value,
                    HoraInicio_DNI853 = txtHoraInicio_DNI853.Text,
                    HoraFinalizacion_DNI853 = txtHoraFinalizacion_DNI853.Text,
                    Estado_DNI853 = cboEstado_DNI853.SelectedItem?.ToString()
                };

                bool resultadoProc_DNI853 = bllFunciones_DNI853.CrearFuncion_DNI853(objNuevaFuncion_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_FuncionCreada"));
                    ActualizarGrillaFunciones_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarFuncion_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (funcionSeleccionada_DNI853 == null)
                    throw new Exception("err_SeleccioneFuncionPrimero");

                funcionSeleccionada_DNI853.IdObra_DNI853 = cboObra_DNI853.SelectedValue?.ToString();
                funcionSeleccionada_DNI853.IdSala_DNI853 = cboSala_DNI853.SelectedValue?.ToString();
                funcionSeleccionada_DNI853.Fecha_DNI853 = dtpFecha_DNI853.Value;
                funcionSeleccionada_DNI853.HoraInicio_DNI853 = txtHoraInicio_DNI853.Text;
                funcionSeleccionada_DNI853.HoraFinalizacion_DNI853 = txtHoraFinalizacion_DNI853.Text;
                funcionSeleccionada_DNI853.Estado_DNI853 = cboEstado_DNI853.SelectedItem?.ToString();

                bool resultadoProc_DNI853 = bllFunciones_DNI853.ModificarFuncion_DNI853(funcionSeleccionada_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_FuncionModificada"));
                    ActualizarGrillaFunciones_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarFuncion_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (funcionSeleccionada_DNI853 == null)
                    throw new Exception("err_SeleccioneFuncionPrimero");

                bool resultadoProc_DNI853 = bllFunciones_DNI853.EliminarFuncion_DNI853(funcionSeleccionada_DNI853.IdFuncion_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_FuncionEliminada"));
                    ActualizarGrillaFunciones_DNI853();
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

        private void FormGestionFunciones_DNI853_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);
        }

        private void FormGestionFunciones_DNI853_Resize(object sender, EventArgs e)
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
                btnNuevaFuncion_DNI853.Enabled = false;
                btnModificarFuncion_DNI853.Enabled = false;
                btnEliminarFuncion_DNI853.Enabled = false;
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
            if (dgvFunciones_DNI853.Columns.Contains("IdObra_DNI853"))
                dgvFunciones_DNI853.Columns["IdObra_DNI853"].HeaderText = TraducirTexto_DNI853("ColObra");

            if (dgvFunciones_DNI853.Columns.Contains("IdSala_DNI853"))
                dgvFunciones_DNI853.Columns["IdSala_DNI853"].HeaderText = TraducirTexto_DNI853("ColSala");

            if (dgvFunciones_DNI853.Columns.Contains("Fecha_DNI853"))
                dgvFunciones_DNI853.Columns["Fecha_DNI853"].HeaderText = TraducirTexto_DNI853("ColFecha");

            if (dgvFunciones_DNI853.Columns.Contains("HoraInicio_DNI853"))
                dgvFunciones_DNI853.Columns["HoraInicio_DNI853"].HeaderText = TraducirTexto_DNI853("ColHoraInicio");

            if (dgvFunciones_DNI853.Columns.Contains("HoraFinalizacion_DNI853"))
                dgvFunciones_DNI853.Columns["HoraFinalizacion_DNI853"].HeaderText = TraducirTexto_DNI853("ColHoraFinalizacion");

            if (dgvFunciones_DNI853.Columns.Contains("Estado_DNI853"))
                dgvFunciones_DNI853.Columns["Estado_DNI853"].HeaderText = TraducirTexto_DNI853("ColEstado");
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
