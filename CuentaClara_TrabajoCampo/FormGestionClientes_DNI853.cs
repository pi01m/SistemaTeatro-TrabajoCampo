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
using BLL;
using BE;
namespace IU
{
    public partial class FormGestionClientes_DNI853 : Form, IObserverIdioma
    {
        // Instancia de BLL Propia del negocio terminada en _DNI853
        private BLL_Cliente_DNI853 bllClientes_DNI853;

        // Instancias de BLL de Servicios generales
        private BLL_Rol bllRol_DNI853;
        private BLL_Idioma bllIdioma_DNI853;

        // Variable de estado
        private BE_Cliente_DNI853 clienteSeleccionado_DNI853;
        public FormGestionClientes_DNI853()
        {
            InitializeComponent();
            // Inicialización de gestores
            bllClientes_DNI853 = new BLL_Cliente_DNI853();
            bllRol_DNI853 = new BLL_Rol();
            bllIdioma_DNI853 = new BLL_Idioma();

            // Configuración visual de la grilla
            dgvClientes_DNI853.MultiSelect = false;
            dgvClientes_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes_DNI853.ReadOnly = true;

            // Suscripción al Patrón Observer de Idioma
            GestorIdioma.GetInstancia().Suscribir(this);
        }

        private void FormGestionClientes_DNI853_Load(object sender, EventArgs e)
        {
            CargarUsuarioActivo_DNI853();
            ActualizarIdioma();
            ActualizarGrillaClientes_DNI853();
        }

        // ====================================================================
        // GESTIÓN DE CLIENTES
        // ====================================================================

        private void ActualizarGrillaClientes_DNI853()
        {
            try
            {
                dgvClientes_DNI853.DataSource = null;
                dgvClientes_DNI853.DataSource = bllClientes_DNI853.ListarClientes_DNI853();
                TraducirColumnasGrillas_DNI853();
                LimpiarControlesCliente_DNI853();
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControlesCliente_DNI853()
        {
            txtDniCliente_DNI853.Text = string.Empty;
            txtDniCliente_DNI853.Enabled = true; // Habilitado para permitir ingresar nuevo DNI
            txtNombreCliente_DNI853.Text = string.Empty;
            txtApellidoCliente_DNI853.Text = string.Empty;
            txtCorreoCliente_DNI853.Text = string.Empty;
            txtTelefonoCliente_DNI853.Text = string.Empty;
            txtDireccionCliente_DNI853.Text = string.Empty;
            clienteSeleccionado_DNI853 = null;
        }

        private void dgvClientes_DNI853_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes_DNI853.CurrentRow != null)
            {
                clienteSeleccionado_DNI853 = (BE_Cliente_DNI853)dgvClientes_DNI853.CurrentRow.DataBoundItem;

                txtDniCliente_DNI853.Text = clienteSeleccionado_DNI853.DNI_C;
                txtDniCliente_DNI853.Enabled = false; // El DNI es clave primaria y no debe modificarse al actualizar
                txtNombreCliente_DNI853.Text = clienteSeleccionado_DNI853.Nombre_C;
                txtApellidoCliente_DNI853.Text = clienteSeleccionado_DNI853.Apellido_C;
                txtCorreoCliente_DNI853.Text = clienteSeleccionado_DNI853.CorreoElectronico_C;
                txtTelefonoCliente_DNI853.Text = clienteSeleccionado_DNI853.Telefono_C;
                txtDireccionCliente_DNI853.Text = clienteSeleccionado_DNI853.Direccion_C;
            }
        }

        private void btnNuevoCliente_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Cliente_DNI853 objNuevoCliente_DNI853 = new BE_Cliente_DNI853
                {
                    DNI_C = txtDniCliente_DNI853.Text,
                    Nombre_C = txtNombreCliente_DNI853.Text,
                    Apellido_C = txtApellidoCliente_DNI853.Text,
                    CorreoElectronico_C = txtCorreoCliente_DNI853.Text,
                    Telefono_C = txtTelefonoCliente_DNI853.Text,
                    Direccion_C = txtDireccionCliente_DNI853.Text
                };

                bool resultadoProc_DNI853 = bllClientes_DNI853.CrearCliente_DNI853(objNuevoCliente_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_ClienteCreado"));
                    ActualizarGrillaClientes_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarCliente_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteSeleccionado_DNI853 == null)
                    throw new Exception("err_SeleccioneClientePrimero");

                clienteSeleccionado_DNI853.DNI_C = txtDniCliente_DNI853.Text;
                clienteSeleccionado_DNI853.Nombre_C = txtNombreCliente_DNI853.Text;
                clienteSeleccionado_DNI853.Apellido_C = txtApellidoCliente_DNI853.Text;
                clienteSeleccionado_DNI853.CorreoElectronico_C = txtCorreoCliente_DNI853.Text;
                clienteSeleccionado_DNI853.Telefono_C = txtTelefonoCliente_DNI853.Text;
                clienteSeleccionado_DNI853.Direccion_C = txtDireccionCliente_DNI853.Text;

                bool resultadoProc_DNI853 = bllClientes_DNI853.ModificarCliente_DNI853(clienteSeleccionado_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_ClienteModificado"));
                    ActualizarGrillaClientes_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelContenedor_DNI853_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEliminarCliente_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteSeleccionado_DNI853 == null)
                    throw new Exception("err_SeleccioneClientePrimero");

                bool resultadoProc_DNI853 = bllClientes_DNI853.EliminarCliente_DNI853(clienteSeleccionado_DNI853.DNI_C);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_ClienteEliminado"));
                    ActualizarGrillaClientes_DNI853();
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

        private void FormGestionClientes_DNI853_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);
        }

        private void FormGestionClientes_DNI853_Resize(object sender, EventArgs e)
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
                btnNuevoCliente_DNI853.Enabled = false;
                btnModificarCliente_DNI853.Enabled = false;
                btnEliminarCliente_DNI853.Enabled = false;
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
            if (dgvClientes_DNI853.Columns.Contains("DNI_C"))
                dgvClientes_DNI853.Columns["DNI_C"].HeaderText = TraducirTexto_DNI853("ColDniCliente");

            if (dgvClientes_DNI853.Columns.Contains("Nombre_C"))
                dgvClientes_DNI853.Columns["Nombre_C"].HeaderText = TraducirTexto_DNI853("ColNombreCliente");

            if (dgvClientes_DNI853.Columns.Contains("Apellido_C"))
                dgvClientes_DNI853.Columns["Apellido_C"].HeaderText = TraducirTexto_DNI853("ColApellidoCliente");

            if (dgvClientes_DNI853.Columns.Contains("CorreoElectronico_C"))
                dgvClientes_DNI853.Columns["CorreoElectronico_C"].HeaderText = TraducirTexto_DNI853("ColCorreoCliente");

            if (dgvClientes_DNI853.Columns.Contains("Telefono_C"))
                dgvClientes_DNI853.Columns["Telefono_C"].HeaderText = TraducirTexto_DNI853("ColTelefonoCliente");

            if (dgvClientes_DNI853.Columns.Contains("Direccion_C"))
                dgvClientes_DNI853.Columns["Direccion_C"].HeaderText = TraducirTexto_DNI853("ColDireccionCliente");
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
