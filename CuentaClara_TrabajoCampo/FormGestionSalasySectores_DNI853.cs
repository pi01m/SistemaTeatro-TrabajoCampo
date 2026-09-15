using BLL.BLL_Servicio;
using BLL;
using Servicio;
using BE;
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
    public partial class FormGestionSalasySectores_DNI853 : Form, IObserverIdioma
    {
        // Instancias de BLL Propias del negocio terminadas en _DNI853
        private BLL_Sala_DNI853 bllSalas_DNI853;
        private BLL_Sector_DNI853 bllSectores_DNI853;

        // Instancias de BLL de Servicios generales
        private BLL_Rol bllRol_DNI853;
        private BLL_Idioma bllIdioma_DNI853;

        // Variables de estado
        private BE_Sala_DNI853 salaSeleccionada_DNI853;
        private BE_Sector_DNI853 sectorSeleccionado_DNI853;
        private string modoActualSalas_DNI853;
        private string modoActualSectores_DNI853;

        public FormGestionSalasySectores_DNI853()
        {
            InitializeComponent();

            // Inicialización de gestores
            bllSalas_DNI853 = new BLL_Sala_DNI853();
            bllSectores_DNI853 = new BLL_Sector_DNI853();
            bllRol_DNI853 = new BLL_Rol();
            bllIdioma_DNI853 = new BLL_Idioma();

            // Configuración visual de las grillas
            dgvSalas_DNI853.MultiSelect = false;
            dgvSalas_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalas_DNI853.ReadOnly = true;

            dgvSectores_DNI853.MultiSelect = false;
            dgvSectores_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSectores_DNI853.ReadOnly = true;

            // Suscripción al Patrón Observer de Idioma
            GestorIdioma.GetInstancia().Suscribir(this);
        }

        private void FormGestionSalasySectores_DNI853_Load(object sender, EventArgs e)
        {
            FormGestionSalasySectores_DNI853_Resize(null, null);
            CargarUsuarioActivo_DNI853();
            ActualizarIdioma();
            ActualizarGrillaSalas_DNI853();

            modoActualSalas_DNI853 = "ModoConsulta";
            modoActualSectores_DNI853 = "ModoConsulta";
        }


        // ====================================================================
        // GESTIÓN DE SALAS (MAESTRO)
        // ====================================================================

        private void ActualizarGrillaSalas_DNI853()
        {
            try
            {
                dgvSalas_DNI853.DataSource = null;
                var listaSalas = bllSalas_DNI853.ListarSalas_DNI853();
                dgvSalas_DNI853.DataSource = listaSalas;

                TraducirColumnasGrillas_DNI853();
                LimpiarControlesSector_DNI853();
                dgvSectores_DNI853.DataSource = null;

                // Si hay al menos una sala, forzamos la selección de la primera fila 
                // para garantizar que se invoque el pintado de datos y no quede en null.
                if (dgvSalas_DNI853.Rows.Count > 0)
                {
                    dgvSalas_DNI853.ClearSelection();
                    dgvSalas_DNI853.Rows[0].Selected = true;
                    dgvSalas_DNI853.CurrentCell = dgvSalas_DNI853.Rows[0].Cells[0];

                    // Forzamos manualmente la carga del objeto seleccionado por si el evento no salta
                    salaSeleccionada_DNI853 = (BE_Sala_DNI853)dgvSalas_DNI853.Rows[0].DataBoundItem;
                    txtNombreSala_DNI853.Text = salaSeleccionada_DNI853.NombreSala_DNI853;
                    txtUbicacionSala_DNI853.Text = salaSeleccionada_DNI853.Ubicacion_DNI853;
                    txtCapacidadSala_DNI853.Text = salaSeleccionada_DNI853.Capacidad_DNI853.ToString();
                    ActualizarGrillaSectores_DNI853(salaSeleccionada_DNI853.IdSala_DNI853);
                }
                else
                {
                    LimpiarControlesSala_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControlesSala_DNI853()
        {
            txtNombreSala_DNI853.Text = string.Empty;
            txtUbicacionSala_DNI853.Text = string.Empty;
            txtCapacidadSala_DNI853.Text = string.Empty;
            salaSeleccionada_DNI853 = null;
        }

        private void dgvSalas_DNI853_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSalas_DNI853.CurrentRow != null)
            {
                salaSeleccionada_DNI853 = (BE_Sala_DNI853)dgvSalas_DNI853.CurrentRow.DataBoundItem;

                txtNombreSala_DNI853.Text = salaSeleccionada_DNI853.NombreSala_DNI853;
                txtUbicacionSala_DNI853.Text = salaSeleccionada_DNI853.Ubicacion_DNI853;
                txtCapacidadSala_DNI853.Text = salaSeleccionada_DNI853.Capacidad_DNI853.ToString();

                // Aquí pasamos el IdSala como string
                ActualizarGrillaSectores_DNI853(salaSeleccionada_DNI853.IdSala_DNI853);
            }
        }

        private void btnNuevaSala_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Sala_DNI853 objNuevaSala_DNI853 = new BE_Sala_DNI853
                {
                    NombreSala_DNI853 = txtNombreSala_DNI853.Text,
                    Ubicacion_DNI853 = txtUbicacionSala_DNI853.Text,
                    Capacidad_DNI853 = int.Parse(txtCapacidadSala_DNI853.Text)
                };

                bool resultadoProc_DNI853 = bllSalas_DNI853.CrearSala_DNI853(objNuevaSala_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_SalaCreada"));
                    ActualizarGrillaSalas_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarSala_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (salaSeleccionada_DNI853 == null)
                    throw new Exception("err_SeleccioneSalaPrimero");

                salaSeleccionada_DNI853.NombreSala_DNI853 = txtNombreSala_DNI853.Text;
                salaSeleccionada_DNI853.Ubicacion_DNI853 = txtUbicacionSala_DNI853.Text;
                salaSeleccionada_DNI853.Capacidad_DNI853 = int.Parse(txtCapacidadSala_DNI853.Text);

                bool resultadoProc_DNI853 = bllSalas_DNI853.ModificarSala_DNI853(salaSeleccionada_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_SalaModificada"));
                    ActualizarGrillaSalas_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarSala_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (salaSeleccionada_DNI853 == null)
                    throw new Exception("err_SeleccioneSalaPrimero");

                // Recibe string por el cambio de ID
                bool resultadoProc_DNI853 = bllSalas_DNI853.EliminarSala_DNI853(salaSeleccionada_DNI853.IdSala_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_SalaEliminada"));
                    ActualizarGrillaSalas_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================================
        // GESTIÓN DE SECTORES (DETALLE)
        // ====================================================================

        private void ActualizarGrillaSectores_DNI853(string idSalaParam_DNI853) // Cambiado a string
        {
            try
            {
                dgvSectores_DNI853.DataSource = null;
                dgvSectores_DNI853.DataSource = bllSectores_DNI853.ListarSectoresPorSala_DNI853(idSalaParam_DNI853);
                TraducirColumnasGrillas_DNI853();
                LimpiarControlesSector_DNI853();
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControlesSector_DNI853()
        {
            txtNombreSector_DNI853.Text = string.Empty;
            txtUbicacionSector_DNI853.Text = string.Empty;
            txtCapacidadSector_DNI853.Text = string.Empty;
            sectorSeleccionado_DNI853 = null;
        }

        private void dgvSectores_DNI853_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSectores_DNI853.CurrentRow != null)
            {
                sectorSeleccionado_DNI853 = (BE_Sector_DNI853)dgvSectores_DNI853.CurrentRow.DataBoundItem;

                txtNombreSector_DNI853.Text = sectorSeleccionado_DNI853.NombreSector_DNI853;
                txtUbicacionSector_DNI853.Text = sectorSeleccionado_DNI853.Ubicacion_DNI853;
                txtCapacidadSector_DNI853.Text = sectorSeleccionado_DNI853.Capacidad_DNI853.ToString();
                txtPrecioSector_DNI853.Text = sectorSeleccionado_DNI853.Precio_DNI853.ToString("N2");
            }
        }

        private void btnNuevoSector_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (salaSeleccionada_DNI853 == null)
                    throw new Exception("err_DebeSeleccionarSala");

                BE_Sector_DNI853 objNuevoSector_DNI853 = new BE_Sector_DNI853
                {
                    IdSala_DNI853 = salaSeleccionada_DNI853.IdSala_DNI853,
                    NombreSector_DNI853 = txtNombreSector_DNI853.Text,
                    Ubicacion_DNI853 = txtUbicacionSector_DNI853.Text,
                    Capacidad_DNI853 = int.Parse(txtCapacidadSector_DNI853.Text),
                    Precio_DNI853 = decimal.Parse(txtPrecioSector_DNI853.Text)
                };

                bool resultadoProc_DNI853 = bllSectores_DNI853.CrearSector_DNI853(objNuevoSector_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_SectorCreado"));
                    ActualizarGrillaSectores_DNI853(salaSeleccionada_DNI853.IdSala_DNI853);
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarSector_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (sectorSeleccionado_DNI853 == null)
                    throw new Exception("err_SeleccioneSectorPrimero");

                sectorSeleccionado_DNI853.NombreSector_DNI853 = txtNombreSector_DNI853.Text;
                sectorSeleccionado_DNI853.Ubicacion_DNI853 = txtUbicacionSector_DNI853.Text;
                sectorSeleccionado_DNI853.Capacidad_DNI853 = int.Parse(txtCapacidadSector_DNI853.Text);
                sectorSeleccionado_DNI853.Precio_DNI853 = decimal.Parse(txtPrecioSector_DNI853.Text);
                bool resultadoProc_DNI853 = bllSectores_DNI853.ModificarSector_DNI853(sectorSeleccionado_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_SectorModificado"));
                    ActualizarGrillaSectores_DNI853(salaSeleccionada_DNI853.IdSala_DNI853);
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarSector_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (sectorSeleccionado_DNI853 == null)
                    throw new Exception("err_SeleccioneSectorPrimero");

                // IdSector_DNI853 pasa string
                bool resultadoProc_DNI853 = bllSectores_DNI853.EliminarSector_DNI853(sectorSeleccionado_DNI853.IdSector_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_SectorEliminado"));
                    ActualizarGrillaSectores_DNI853(salaSeleccionada_DNI853.IdSala_DNI853);
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

        private void FormGestionSalasySectores_DNI853_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);
        }

        private void FormGestionSalasySectores_DNI853_Resize(object sender_DNI853, EventArgs e_DNI853)
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
                btnNuevaSala_DNI853.Enabled = false;
                btnModificarSala_DNI853.Enabled = false;
                btnEliminarSala_DNI853.Enabled = false;
                btnNuevoSector_DNI853.Enabled = false;
                btnModificarSector_DNI853.Enabled = false;
                btnEliminarSector_DNI853.Enabled = false;
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
            if (dgvSalas_DNI853.Columns.Contains("NombreSala_DNI853"))
                dgvSalas_DNI853.Columns["NombreSala_DNI853"].HeaderText = TraducirTexto_DNI853("ColNombreSala");

            if (dgvSalas_DNI853.Columns.Contains("Ubicacion_DNI853"))
                dgvSalas_DNI853.Columns["Ubicacion_DNI853"].HeaderText = TraducirTexto_DNI853("ColUbicacion");

            if (dgvSalas_DNI853.Columns.Contains("Capacidad_DNI853"))
                dgvSalas_DNI853.Columns["Capacidad_DNI853"].HeaderText = TraducirTexto_DNI853("ColCapacidad");

            if (dgvSectores_DNI853.Columns.Contains("NombreSector_DNI853"))
                dgvSectores_DNI853.Columns["NombreSector_DNI853"].HeaderText = TraducirTexto_DNI853("ColNombreSector");

            if (dgvSectores_DNI853.Columns.Contains("Ubicacion_DNI853"))
                dgvSectores_DNI853.Columns["Ubicacion_DNI853"].HeaderText = TraducirTexto_DNI853("ColUbicacion");

            if (dgvSectores_DNI853.Columns.Contains("Capacidad_DNI853"))
                dgvSectores_DNI853.Columns["Capacidad_DNI853"].HeaderText = TraducirTexto_DNI853("ColCapacidad");

            if (dgvSectores_DNI853.Columns.Contains("Precio_DNI853"))
                dgvSectores_DNI853.Columns["Precio_DNI853"].HeaderText = TraducirTexto_DNI853("ColPrecio");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
