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

        // Variable para controlar el estado de la operación actual (NUEVO, MODIFICAR, ELIMINAR o vacío)
        private string operacionActual_DNI853 = string.Empty;

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
            ConfigurarEstadoInicial_DNI853();
        }

        private void ConfigurarEstadoInicial_DNI853()
        {
            operacionActual_DNI853 = string.Empty;
            listaPasos_DNI853.Items.Clear();
            DeshabilitarCampos_DNI853();
        }

        private void DeshabilitarCampos_DNI853()
        {
            txtDniCliente_DNI853.Enabled = false;
            txtNombreCliente_DNI853.Enabled = false;
            txtApellidoCliente_DNI853.Enabled = false;
            txtCorreoCliente_DNI853.Enabled = false;
            txtTelefonoCliente_DNI853.Enabled = false;
            txtDireccionCliente_DNI853.Enabled = false;
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

                // Si hay al menos una fila (incluso si es 1 sola), forzamos la selección manual
                // para garantizar que CurrentRow y DataBoundItem se asignen correctamente
                // aunque Windows Forms no dispare el evento SelectionChanged.
                if (dgvClientes_DNI853.Rows.Count > 0)
                {
                    dgvClientes_DNI853.ClearSelection();
                    dgvClientes_DNI853.Rows[0].Selected = true;
                    if (dgvClientes_DNI853.Columns.Count > 0)
                    {
                        dgvClientes_DNI853.CurrentCell = dgvClientes_DNI853.Rows[0].Cells[0];
                    }

                    // Forzamos manualmente la carga de controles con la primera fila
                    clienteSeleccionado_DNI853 = (BE_Cliente_DNI853)dgvClientes_DNI853.Rows[0].DataBoundItem;
                    txtDniCliente_DNI853.Text = clienteSeleccionado_DNI853.DNI_C_DNI853;
                    txtNombreCliente_DNI853.Text = clienteSeleccionado_DNI853.Nombre_C_DNI853;
                    txtApellidoCliente_DNI853.Text = clienteSeleccionado_DNI853.Apellido_C_DNI853;
                    txtCorreoCliente_DNI853.Text = clienteSeleccionado_DNI853.CorreoElectronico_C_DNI853;
                    txtTelefonoCliente_DNI853.Text = clienteSeleccionado_DNI853.Telefono_C_DNI853;
                    txtDireccionCliente_DNI853.Text = clienteSeleccionado_DNI853.Direccion_C_DNI853;
                }
                else
                {
                    LimpiarControlesCliente_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControlesCliente_DNI853()
        {
            txtDniCliente_DNI853.Text = string.Empty;
            txtNombreCliente_DNI853.Text = string.Empty;
            txtApellidoCliente_DNI853.Text = string.Empty;
            txtCorreoCliente_DNI853.Text = string.Empty;
            txtTelefonoCliente_DNI853.Text = string.Empty;
            txtDireccionCliente_DNI853.Text = string.Empty;
            clienteSeleccionado_DNI853 = null;
        }

        private void dgvClientes_DNI853_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes_DNI853.CurrentRow != null && string.IsNullOrEmpty(operacionActual_DNI853))
            {
                clienteSeleccionado_DNI853 = (BE_Cliente_DNI853)dgvClientes_DNI853.CurrentRow.DataBoundItem;

                txtDniCliente_DNI853.Text = clienteSeleccionado_DNI853.DNI_C_DNI853;
                txtNombreCliente_DNI853.Text = clienteSeleccionado_DNI853.Nombre_C_DNI853;
                txtApellidoCliente_DNI853.Text = clienteSeleccionado_DNI853.Apellido_C_DNI853;
                txtCorreoCliente_DNI853.Text = clienteSeleccionado_DNI853.CorreoElectronico_C_DNI853;
                txtTelefonoCliente_DNI853.Text = clienteSeleccionado_DNI853.Telefono_C_DNI853;
                txtDireccionCliente_DNI853.Text = clienteSeleccionado_DNI853.Direccion_C_DNI853;
            }
        }

        private void btnNuevoCliente_DNI853_Click(object sender, EventArgs e)
        {
            operacionActual_DNI853 = "NUEVO";
            LimpiarControlesCliente_DNI853();

            // Habilitar campos para ingreso
            txtDniCliente_DNI853.Enabled = true;
            txtNombreCliente_DNI853.Enabled = true;
            txtApellidoCliente_DNI853.Enabled = true;
            txtCorreoCliente_DNI853.Enabled = true;
            txtTelefonoCliente_DNI853.Enabled = true;
            txtDireccionCliente_DNI853.Enabled = true;

            // Mostrar pasos traducidos en la lista
            ActualizarListaPasos_DNI853();
        }

        private void btnModificarCliente_DNI853_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado_DNI853 == null)
            {
                MessageBox.Show(TraducirTexto_DNI853("Aviso_SeleccionarClienteModificar"), TraducirTexto_DNI853("TituloAviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            operacionActual_DNI853 = "MODIFICAR";

            // El DNI no se modifica por ser clave, el resto sí
            txtDniCliente_DNI853.Enabled = false;
            txtNombreCliente_DNI853.Enabled = true;
            txtApellidoCliente_DNI853.Enabled = true;
            txtCorreoCliente_DNI853.Enabled = true;
            txtTelefonoCliente_DNI853.Enabled = true;
            txtDireccionCliente_DNI853.Enabled = true;

            // Mostrar pasos traducidos en la lista
            ActualizarListaPasos_DNI853();
        }

        private void btnEliminarCliente_DNI853_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado_DNI853 == null)
            {
                MessageBox.Show(TraducirTexto_DNI853("Aviso_SeleccionarClienteEliminar"), TraducirTexto_DNI853("TituloAviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            operacionActual_DNI853 = "ELIMINAR";
            DeshabilitarCampos_DNI853();

            // Mostrar pasos traducidos en la lista
            ActualizarListaPasos_DNI853();
        }

        private void btnAplicar_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(operacionActual_DNI853))
                {
                    MessageBox.Show(TraducirTexto_DNI853("Aviso_SeleccionarOperacion"), TraducirTexto_DNI853("TituloAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (operacionActual_DNI853 == "NUEVO")
                {
                    BE_Cliente_DNI853 objNuevoCliente_DNI853 = new BE_Cliente_DNI853
                    {
                        DNI_C_DNI853 = txtDniCliente_DNI853.Text,
                        Nombre_C_DNI853 = txtNombreCliente_DNI853.Text,
                        Apellido_C_DNI853 = txtApellidoCliente_DNI853.Text,
                        CorreoElectronico_C_DNI853 = txtCorreoCliente_DNI853.Text,
                        Telefono_C_DNI853 = txtTelefonoCliente_DNI853.Text,
                        Direccion_C_DNI853 = txtDireccionCliente_DNI853.Text
                    };

                    bool resultadoProc_DNI853 = bllClientes_DNI853.CrearCliente_DNI853(objNuevoCliente_DNI853);
                    if (resultadoProc_DNI853)
                    {
                        MessageBox.Show(TraducirTexto_DNI853("Exito_ClienteCreado"), TraducirTexto_DNI853("TituloExito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (operacionActual_DNI853 == "MODIFICAR")
                {
                    if (clienteSeleccionado_DNI853 == null)
                        throw new Exception("err_SeleccioneClientePrimero");

                    clienteSeleccionado_DNI853.Nombre_C_DNI853 = txtNombreCliente_DNI853.Text;
                    clienteSeleccionado_DNI853.Apellido_C_DNI853 = txtApellidoCliente_DNI853.Text;
                    clienteSeleccionado_DNI853.CorreoElectronico_C_DNI853 = txtCorreoCliente_DNI853.Text;
                    clienteSeleccionado_DNI853.Telefono_C_DNI853 = txtTelefonoCliente_DNI853.Text;
                    clienteSeleccionado_DNI853.Direccion_C_DNI853 = txtDireccionCliente_DNI853.Text;

                    bool resultadoProc_DNI853 = bllClientes_DNI853.ModificarCliente_DNI853(clienteSeleccionado_DNI853);
                    if (resultadoProc_DNI853)
                    {
                        MessageBox.Show(TraducirTexto_DNI853("Exito_ClienteModificado"), TraducirTexto_DNI853("TituloExito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (operacionActual_DNI853 == "ELIMINAR")
                {
                    if (clienteSeleccionado_DNI853 == null)
                        throw new Exception("err_SeleccioneClientePrimero");

                    bool resultadoProc_DNI853 = bllClientes_DNI853.EliminarCliente_DNI853(clienteSeleccionado_DNI853.DNI_C_DNI853);
                    if (resultadoProc_DNI853)
                    {
                        MessageBox.Show(TraducirTexto_DNI853("Exito_ClienteEliminado"), TraducirTexto_DNI853("TituloExito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ActualizarGrillaClientes_DNI853();
                ConfigurarEstadoInicial_DNI853();
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_DNI853_Click(object sender, EventArgs e)
        {
            ActualizarGrillaClientes_DNI853();
            ConfigurarEstadoInicial_DNI853();
        }

        private void btnActualizar_DNI853_Click(object sender, EventArgs e)
        {
            ActualizarGrillaClientes_DNI853();
            ConfigurarEstadoInicial_DNI853();
        }

        private void panelContenedor_DNI853_Paint(object sender, PaintEventArgs e)
        {

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
            ActualizarListaPasos_DNI853();
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
            Servicio_Usuario usuarioActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual();
            if (usuarioActual_DNI853 == null) return claveParam_DNI853;

            string idIdiomaActual_DNI853 = usuarioActual_DNI853.Id_Idioma;
            Servicio_Idioma idiomaActual_DNI853 = bllIdioma_DNI853.ObtenerIdiomaPorId(idIdiomaActual_DNI853);

            if (idiomaActual_DNI853 == null) return claveParam_DNI853;

            var etiquetaObtenida_DNI853 = idiomaActual_DNI853.Etiquetas.FirstOrDefault(x => x.Clave == claveParam_DNI853);
            return etiquetaObtenida_DNI853 != null ? etiquetaObtenida_DNI853.Texto : claveParam_DNI853;
        }

        private void TraducirColumnasGrillas_DNI853()
        {
            if (dgvClientes_DNI853.Columns.Contains("DNI_C_DNI853"))
            {
                dgvClientes_DNI853.Columns["DNI_C_DNI853"].HeaderText = TraducirTexto_DNI853("ColDniCliente");
                dgvClientes_DNI853.Columns["DNI_C_DNI853"].Visible = true;
            }

            if (dgvClientes_DNI853.Columns.Contains("Nombre_C_DNI853"))
                dgvClientes_DNI853.Columns["Nombre_C_DNI853"].HeaderText = TraducirTexto_DNI853("ColNombreCliente");

            if (dgvClientes_DNI853.Columns.Contains("Apellido_C_DNI853"))
                dgvClientes_DNI853.Columns["Apellido_C_DNI853"].HeaderText = TraducirTexto_DNI853("ColApellidoCliente");

            if (dgvClientes_DNI853.Columns.Contains("CorreoElectronico_C_DNI853"))
                dgvClientes_DNI853.Columns["CorreoElectronico_C_DNI853"].HeaderText = TraducirTexto_DNI853("ColCorreoCliente");

            if (dgvClientes_DNI853.Columns.Contains("Telefono_C_DNI853"))
                dgvClientes_DNI853.Columns["Telefono_C_DNI853"].HeaderText = TraducirTexto_DNI853("ColTelefonoCliente");

            if (dgvClientes_DNI853.Columns.Contains("Direccion_C_DNI853"))
                dgvClientes_DNI853.Columns["Direccion_C_DNI853"].HeaderText = TraducirTexto_DNI853("ColDireccionCliente");
        }

        private void ActualizarListaPasos_DNI853()
        {
            listaPasos_DNI853.Items.Clear();

            if (operacionActual_DNI853 == "NUEVO")
            {
                listaPasos_DNI853.Items.Add(TraducirTexto_DNI853("Paso_Nuevo_1"));
                listaPasos_DNI853.Items.Add(TraducirTexto_DNI853("Paso_Nuevo_2"));
                listaPasos_DNI853.Items.Add(TraducirTexto_DNI853("Paso_Nuevo_3"));
            }
            else if (operacionActual_DNI853 == "MODIFICAR")
            {
                listaPasos_DNI853.Items.Add(TraducirTexto_DNI853("Paso_Modificar_1"));
                listaPasos_DNI853.Items.Add(TraducirTexto_DNI853("Paso_Modificar_2"));
                listaPasos_DNI853.Items.Add(TraducirTexto_DNI853("Paso_Modificar_3"));
            }
            else if (operacionActual_DNI853 == "ELIMINAR")
            {
                listaPasos_DNI853.Items.Add(TraducirTexto_DNI853("Paso_Eliminar_1"));
                listaPasos_DNI853.Items.Add(TraducirTexto_DNI853("Paso_Eliminar_2"));
            }
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
