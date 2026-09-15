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
    public partial class FormGestionObrasDNI853 : Form, IObserverIdioma
    {
        private BLL_Obra_DNI853 bllObras_DNI853;
        private BLL_Rol bllRol_DNI853;
        private BLL_Idioma bllIdioma_DNI853;
        private BE_Obra_DNI853 obraSeleccionada_DNI853;

        public FormGestionObrasDNI853()
        {
            InitializeComponent();
            bllObras_DNI853 = new BLL_Obra_DNI853();
            bllRol_DNI853 = new BLL_Rol();
            bllIdioma_DNI853 = new BLL_Idioma();

            dgvObras_DNI853.MultiSelect = false;
            dgvObras_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvObras_DNI853.ReadOnly = true;

            GestorIdioma.GetInstancia().Suscribir(this);
        }

        private void FormGestionObrasDNI853_Load(object sender, EventArgs e)
        {
            FormGestionObrasDNI853_Resize(null, null);
            CargarUsuarioActivo_DNI853();
            CargarEstadosComboBox_DNI853();
            ActualizarIdioma();
            ActualizarGrillaObras_DNI853();
        }

        private void CargarEstadosComboBox_DNI853()
        {
            // Puedes ajustar o cargar estos valores según los estados que maneje tu sistema/teatro
            cmb_EstadoObra_DNI853.Items.Clear();
            cmb_EstadoObra_DNI853.Items.Add("Activa");
            cmb_EstadoObra_DNI853.Items.Add("Inactiva");
            

            if (cmb_EstadoObra_DNI853.Items.Count > 0)
                cmb_EstadoObra_DNI853.SelectedIndex = 0;
        }

        private void ActualizarGrillaObras_DNI853()
        {
            try
            {
                dgvObras_DNI853.DataSource = null;
                dgvObras_DNI853.DataSource = bllObras_DNI853.ListarObras_DNI853();
                TraducirColumnasGrillas_DNI853();
                LimpiarControlesObra_DNI853();
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControlesObra_DNI853()
        {
            txtNombreObra_DNI853.Text = string.Empty;
            txtDescripcionObra_DNI853.Text = string.Empty;
            if (cmb_EstadoObra_DNI853.Items.Count > 0)
                cmb_EstadoObra_DNI853.SelectedIndex = 0;

            obraSeleccionada_DNI853 = null;
        }

        private void dgvObras_DNI853_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvObras_DNI853.CurrentRow != null)
            {
                obraSeleccionada_DNI853 = (BE_Obra_DNI853)dgvObras_DNI853.CurrentRow.DataBoundItem;

                txtNombreObra_DNI853.Text = obraSeleccionada_DNI853.NombreObra_DNI853;
                txtDescripcionObra_DNI853.Text = obraSeleccionada_DNI853.DescripcionObra_DNI853;

                // Seleccionar el estado correspondiente en el ComboBox
                if (!string.IsNullOrEmpty(obraSeleccionada_DNI853.Estado_DNI853))
                {
                    cmb_EstadoObra_DNI853.SelectedItem = obraSeleccionada_DNI853.Estado_DNI853;
                }
            }
        }

        private void btnNuevaObra_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Obra_DNI853 objNuevaObra_DNI853 = new BE_Obra_DNI853
                {
                    NombreObra_DNI853 = txtNombreObra_DNI853.Text,
                    DescripcionObra_DNI853 = txtDescripcionObra_DNI853.Text,
                    Estado_DNI853 = cmb_EstadoObra_DNI853.SelectedItem?.ToString() ?? "Activa"
                };

                bool resultadoProc_DNI853 = bllObras_DNI853.CrearObra_DNI853(objNuevaObra_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_ObraCreada"));
                    ActualizarGrillaObras_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarObra_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (obraSeleccionada_DNI853 == null)
                    throw new Exception("err_SeleccioneObraPrimero");

                obraSeleccionada_DNI853.NombreObra_DNI853 = txtNombreObra_DNI853.Text;
                obraSeleccionada_DNI853.DescripcionObra_DNI853 = txtDescripcionObra_DNI853.Text;
                obraSeleccionada_DNI853.Estado_DNI853 = cmb_EstadoObra_DNI853.SelectedItem?.ToString() ?? "Activa";

                bool resultadoProc_DNI853 = bllObras_DNI853.ModificarObra_DNI853(obraSeleccionada_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_ObraModificada"));
                    ActualizarGrillaObras_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarObra_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (obraSeleccionada_DNI853 == null)
                    throw new Exception("err_SeleccioneObraPrimero");

                bool resultadoProc_DNI853 = bllObras_DNI853.EliminarObra_DNI853(obraSeleccionada_DNI853.IdObra_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_ObraEliminada"));
                    ActualizarGrillaObras_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_DNI853_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormGestionObrasDNI853_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);
        }

        private void FormGestionObrasDNI853_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                return;

            int altoDisponible_DNI853 = ClientSize.Height - panelInferior_DNI853.Height;

            panelContenedor_DNI853.Location = new Point(
                (ClientSize.Width - panelContenedor_DNI853.Width) / 2,
                (altoDisponible_DNI853 - panelContenedor_DNI853.Height) / 2
            );
        }

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
                btnNuevaObra_DNI853.Enabled = false;
                btnModificarObra_DNI853.Enabled = false;
                btnEliminarObra_DNI853.Enabled = false;
                return;
            }
        }

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
            if (dgvObras_DNI853.Columns.Contains("NombreObra_DNI853"))
                dgvObras_DNI853.Columns["NombreObra_DNI853"].HeaderText = TraducirTexto_DNI853("ColNombreObra");

            if (dgvObras_DNI853.Columns.Contains("DescripcionObra_DNI853"))
                dgvObras_DNI853.Columns["DescripcionObra_DNI853"].HeaderText = TraducirTexto_DNI853("ColDescripcionObra");

            if (dgvObras_DNI853.Columns.Contains("Estado_DNI853"))
                dgvObras_DNI853.Columns["Estado_DNI853"].HeaderText = TraducirTexto_DNI853("ColEstadoObra");
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
