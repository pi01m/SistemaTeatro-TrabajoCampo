using BE;
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
using BLL_Negocio; 

namespace IU
{
    public partial class FormGestionVentaEntradas_DNI853 : Form, IObserverIdioma
    {
        private BLL_Factura_DNI853 objBllFactura_DNI853 = new BLL_Factura_DNI853();
        private BLL_Funcion_DNI853 objBllFuncion_DNI853 = new BLL_Funcion_DNI853();
        private BLL_Cliente_DNI853 objBllCliente_DNI853 = new BLL_Cliente_DNI853();
        private BLL_Promocion_DNI853 objBllPromocion_DNI853 = new BLL_Promocion_DNI853();
        private BLL_MedioPago_DNI853 objBllMedioPago_DNI853 = new BLL_MedioPago_DNI853();
        private BLL_Entrada_DNI853 objBllEntrada_DNI853 = new BLL_Entrada_DNI853();
        private BLL_Obra_DNI853 objBllObra_DNI853 = new BLL_Obra_DNI853();
        private BLL_Sector_DNI853 objBllSector_DNI853 = new BLL_Sector_DNI853();

        // Servicios
        private BLL_Rol objBllRol_DNI853 = new BLL_Rol();
        private BLL_Idioma objBllIdioma_DNI853 = new BLL_Idioma();

        // Nuevo BLL Carrito (sin DAL)
        private BLL_Carrito_DNI853 objBllCarrito_DNI853 = new BLL_Carrito_DNI853();

        // Variables globales para el manejo de importes y estado
        private decimal importeTotal_DNI853 = 0;
        private string idClienteActual_DNI853 = string.Empty;
        private string idVentaConfirmada_DNI853 = string.Empty;

        // Constructor del formulario
        public FormGestionVentaEntradas_DNI853()
        {
            InitializeComponent();
            GestorIdioma.GetInstancia().Suscribir(this);
        }

        // Evento Load
        private void FormGestionVentaEntradas_DNI853_Load(object sender, EventArgs e)
        {
            CargarUsuarioActivo_DNI853();
            ActualizarIdioma();
            ConfigurarCarrito_DNI853();
            CargarCombosIniciales_DNI853();

            // Estado Inicial: Libre armado de carrito, pago bloqueado
            BloquearControlesPostVenta_DNI853(false);
            BloquearControlesPago_DNI853(true);
        }

        // ====================================================================
        // ESTADOS DE LA PANTALLA
        // ====================================================================

        private void BloquearControlesPago_DNI853(bool bloquear_DNI853)
        {
            // Bloquea o desbloquea los controles de pago y promos
            cboPromocion_DNI853.Enabled = !bloquear_DNI853;
            cboMedioPago_DNI853.Enabled = !bloquear_DNI853;
            btnCobrarEntradas_DNI853.Enabled = !bloquear_DNI853;

            if (bloquear_DNI853)
            {
                txtBanco_DNI853.Enabled = false;
                txtNroTarjeta_DNI853.Enabled = false;
                txtVencimiento_DNI853.Enabled = false;
            }
        }

        private void BloquearControlesPostVenta_DNI853(bool ventaFinalizada_DNI853)
        {
            // Si la venta está finalizada, bloqueamos hasta el carrito
            btnConfirmarVenta_DNI853.Enabled = !ventaFinalizada_DNI853;
            btnAgregarItem_DNI853.Enabled = !ventaFinalizada_DNI853;
            btnQuitarItem_DNI853.Enabled = !ventaFinalizada_DNI853;

            btnImprimirFactura_DNI853.Enabled = ventaFinalizada_DNI853;
            btnImprimirEntradas_DNI853.Enabled = ventaFinalizada_DNI853;

            
        }

        // ====================================================================
        // CARGA Y ACTUALIZACIÓN DE GRILLAS
        // ====================================================================

        private void ActualizarGrillaFunciones_DNI853()
        {
            try
            {
                dgvFunciones_DNI853.DataSource = null;

                if (cboObra_DNI853.SelectedValue == null) return;

                string valorSeleccionado_DNI853 = cboObra_DNI853.SelectedValue?.ToString();

                var obraSeleccionada_DNI853 = objBllObra_DNI853.ListarObras_DNI853()
                    .FirstOrDefault(o => o.IdObra_DNI853 == valorSeleccionado_DNI853 || o.NombreObra_DNI853 == valorSeleccionado_DNI853);

                string idObraReal_DNI853 = obraSeleccionada_DNI853 != null ? obraSeleccionada_DNI853.IdObra_DNI853 : valorSeleccionado_DNI853;

                // Traemos todas las funciones confirmadas vigentes para esta obra
                var listaFunciones_DNI853 = objBllFuncion_DNI853.ObtenerFuncionesConfirmadasPorObra_DNI853(idObraReal_DNI853);
                dgvFunciones_DNI853.DataSource = listaFunciones_DNI853;

                TraducirColumnasGrillas_DNI853();
                dgvSectores_DNI853.DataSource = null;

                if (dgvFunciones_DNI853.Rows.Count > 0)
                {
                    dgvFunciones_DNI853.ClearSelection();
                    dgvFunciones_DNI853.Rows[0].Selected = true;

                    foreach (DataGridViewColumn col in dgvFunciones_DNI853.Columns)
                    {
                        if (col.Visible)
                        {
                            dgvFunciones_DNI853.CurrentCell = dgvFunciones_DNI853.Rows[0].Cells[col.Index];
                            break;
                        }
                    }

                    string idFuncionSeleccionada_DNI853 = dgvFunciones_DNI853.Rows[0].Cells["IdFuncion_DNI853"].Value?.ToString();
                    ActualizarGrillaSectores_DNI853(idFuncionSeleccionada_DNI853);
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarGrillaSectores_DNI853(string idFuncionParam_DNI853)
        {
            try
            {
                dgvSectores_DNI853.DataSource = null;

                if (!string.IsNullOrEmpty(idFuncionParam_DNI853))
                {
                    dgvSectores_DNI853.DataSource = objBllSector_DNI853.ObtenerSectoresPorFuncion_DNI853(idFuncionParam_DNI853);
                    TraducirColumnasGrillas_DNI853();

                    if (dgvSectores_DNI853.Rows.Count > 0)
                    {
                        dgvSectores_DNI853.ClearSelection();
                        dgvSectores_DNI853.Rows[0].Selected = true;

                        foreach (DataGridViewColumn col in dgvSectores_DNI853.Columns)
                        {
                            if (col.Visible)
                            {
                                dgvSectores_DNI853.CurrentCell = dgvSectores_DNI853.Rows[0].Cells[col.Index];
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarCarrito_DNI853()
        {
            try
            {
                if (dgvCarrito_DNI853 != null)
                {
                    dgvCarrito_DNI853.DataSource = null;
                    dgvCarrito_DNI853.DataSource = objBllCarrito_DNI853.ObtenerCarrito_DNI853();

                    TraducirColumnasGrillas_DNI853();

                    if (dgvCarrito_DNI853.Rows.Count > 0)
                    {
                        dgvCarrito_DNI853.ClearSelection();
                        dgvCarrito_DNI853.Rows[0].Selected = true;

                        foreach (DataGridViewColumn col in dgvCarrito_DNI853.Columns)
                        {
                            if (col.Visible)
                            {
                                dgvCarrito_DNI853.CurrentCell = dgvCarrito_DNI853.Rows[0].Cells[col.Index];
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombosIniciales_DNI853()
        {
            cboObra_DNI853.DataSource = objBllObra_DNI853.ObtenerObrasEnCartelera_DNI853();
            cboObra_DNI853.DisplayMember = "NombreObra_DNI853";
            cboObra_DNI853.ValueMember = "IdObra_DNI853";

            cboPromocion_DNI853.DataSource = objBllPromocion_DNI853.ObtenerPromocionesVigentesParaEntradas_DNI853();
            cboMedioPago_DNI853.DataSource = objBllMedioPago_DNI853.ObtenerMediosDePago_DNI853();

            HabilitarCamposTarjeta_DNI853(false);
        }

        private void btnBuscarFunciones_DNI853_Click(object sender, EventArgs e)
        {
            ActualizarGrillaFunciones_DNI853();
        }

        private void dgvFunciones_DNI853_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFunciones_DNI853.CurrentRow != null)
            {
                string idFuncion_DNI853 = dgvFunciones_DNI853.CurrentRow.Cells["IdFuncion_DNI853"].Value?.ToString();
                ActualizarGrillaSectores_DNI853(idFuncion_DNI853);
            }
        }

        // ====================================================================
        // EVENTOS DEL CARRITO
        // ====================================================================

        private void btnAgregarItem_DNI853_Click(object sender, EventArgs e)
        {
            if (dgvFunciones_DNI853.CurrentRow == null || dgvSectores_DNI853.CurrentRow == null)
            {
                MessageBox.Show(TraducirTexto_DNI853("MsgSeleccioneFuncionSector"), TraducirTexto_DNI853("TituloAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Captura de datos planos desde los controles de la UI
                string idFuncion_DNI853 = dgvFunciones_DNI853.CurrentRow.Cells["IdFuncion_DNI853"].Value?.ToString();
                string idSector_DNI853 = dgvSectores_DNI853.CurrentRow.Cells["IdSector_DNI853"].Value?.ToString();
                string nombreObra_DNI853 = cboObra_DNI853.Text;
                DateTime fechaFunc_DNI853 = Convert.ToDateTime(dgvFunciones_DNI853.CurrentRow.Cells["Fecha_DNI853"].Value);
                string horaInicioFunc_DNI853 = dgvFunciones_DNI853.CurrentRow.Cells["HoraInicio_DNI853"].Value?.ToString();
                string nombreSector_DNI853 = dgvSectores_DNI853.CurrentRow.Cells["NombreSector_DNI853"].Value?.ToString();
                decimal precioSector_DNI853 = Convert.ToDecimal(dgvSectores_DNI853.CurrentRow.Cells["Precio_DNI853"].Value);
                int dispActual_DNI853 = Convert.ToInt32(dgvSectores_DNI853.CurrentRow.Cells["Capacidad_DNI853"].Value);

                // Se delega todo el trabajo duro, validación y encapsulamiento a la BLL
                objBllCarrito_DNI853.AgregarItem_DNI853(
                    idFuncion_DNI853,
                    idSector_DNI853,
                    nombreObra_DNI853,
                    fechaFunc_DNI853,
                    horaInicioFunc_DNI853,
                    nombreSector_DNI853,
                    txtCantidad_DNI853.Text,
                    precioSector_DNI853,
                    dispActual_DNI853
                );

                ConfigurarCarrito_DNI853();
                RecalcularTotalCarrito_DNI853();
                txtCantidad_DNI853.Clear();
            }
            catch (Exception ex)
            {
                // Manejo centralizado de excepciones lanzadas por la BLL mediante traducciones
                string mensajeError = TraducirTexto_DNI853(ex.Message);
                if (ex.Message == "err_SuperaDisponibilidad")
                {
                    int dispActual_DNI853 = Convert.ToInt32(dgvSectores_DNI853.CurrentRow.Cells["Capacidad_DNI853"].Value);
                    mensajeError = $"{mensajeError} ({dispActual_DNI853})";
                }

                MessageBox.Show(mensajeError, TraducirTexto_DNI853("TituloAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuitarItem_DNI853_Click(object sender, EventArgs e)
        {
            if (dgvCarrito_DNI853.CurrentRow != null)
            {
                BE_Entrada_DNI853 itemSeleccionado_DNI853 = (BE_Entrada_DNI853)dgvCarrito_DNI853.CurrentRow.DataBoundItem;
                objBllCarrito_DNI853.QuitarItem_DNI853(itemSeleccionado_DNI853);

                // REFRESCAR PANTALLA
                ConfigurarCarrito_DNI853();
                RecalcularTotalCarrito_DNI853();
            }
        }

        private void RecalcularTotalCarrito_DNI853()
        {
            importeTotal_DNI853 = objBllCarrito_DNI853.CalcularTotalSinDescuento_DNI853();

            if (cboPromocion_DNI853.SelectedItem != null && importeTotal_DNI853 > 0)
            {
                BE_Promocion_DNI853 promo_DNI853 = (BE_Promocion_DNI853)cboPromocion_DNI853.SelectedItem;
                importeTotal_DNI853 -= promo_DNI853.ValorDescuento_DNI853;
            }

            txtImporteTotal_DNI853.Text = $"$ {importeTotal_DNI853:N2}";
        }

        private void cboPromocion_DNI853_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalcularTotalCarrito_DNI853();
        }

        // ====================================================================
        // GESTIÓN DE CLIENTE
        // ====================================================================

        private void btnBuscarCliente_DNI853_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDniCliente_DNI853.Text)) return;

            try
            {
                BE_Cliente_DNI853 cliente_DNI853 = objBllCliente_DNI853.BuscarPorDNI_DNI853(txtDniCliente_DNI853.Text);
                if (cliente_DNI853 != null)
                {
                    idClienteActual_DNI853 = cliente_DNI853.DNI_C_DNI853;
                    txtNombreCliente_DNI853.Text = $"{cliente_DNI853.Nombre_C_DNI853} {cliente_DNI853.Apellido_C_DNI853}";
                }
                else
                {
                    MessageBox.Show(TraducirTexto_DNI853("MsgClienteNoRegistrado"), TraducirTexto_DNI853("TituloInformacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    idClienteActual_DNI853 = string.Empty;
                    txtNombreCliente_DNI853.Clear();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarCliente_DNI853_Click(object sender, EventArgs e)
        {
            FormGestionClientes_DNI853 formClientes_DNI853 = new FormGestionClientes_DNI853();
            formClientes_DNI853.ShowDialog();

            if (!string.IsNullOrEmpty(txtDniCliente_DNI853.Text))
            {
                btnBuscarCliente_DNI853.PerformClick();
            }
        }

        // ====================================================================
        // MEDIOS DE PAGO Y CONFIRMACIÓN
        // ====================================================================

        private void cboMedioPago_DNI853_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esTarjeta_DNI853 = cboMedioPago_DNI853.Text.ToUpper().Contains("TARJETA");
            HabilitarCamposTarjeta_DNI853(esTarjeta_DNI853);
        }

        private void HabilitarCamposTarjeta_DNI853(bool habilitar_DNI853)
        {
            txtBanco_DNI853.Enabled = habilitar_DNI853;
            txtNroTarjeta_DNI853.Enabled = habilitar_DNI853;
            txtVencimiento_DNI853.Enabled = habilitar_DNI853;

            if (!habilitar_DNI853)
            {
                txtBanco_DNI853.Clear();
                txtNroTarjeta_DNI853.Clear();
                txtVencimiento_DNI853.Clear();
            }
        }

        // Paso 2: Confirma el armado, bloquea carrito, habilita pagos
        private void btnConfirmarVenta_DNI853_Click(object sender, EventArgs e)
        {
            if (objBllCarrito_DNI853.ObtenerCantidadItems_DNI853() == 0)
            {
                MessageBox.Show(TraducirTexto_DNI853("MsgCarritoVacio"), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(idClienteActual_DNI853))
            {
                MessageBox.Show(TraducirTexto_DNI853("MsgDebeSeleccionarCliente"), TraducirTexto_DNI853("TituloValidacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BloquearControlesPago_DNI853(false);
            btnConfirmarVenta_DNI853.Enabled = false;
            btnAgregarItem_DNI853.Enabled = false;
            btnQuitarItem_DNI853.Enabled = false;
        }

        // Paso 3: Procesa, Descuenta, Graba Factura y Entradas por separado 
        private void btnCobrarEntradas_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar Tarjeta
                if (txtBanco_DNI853.Enabled)
                {
                    objBllFactura_DNI853.ValidarDatosTarjeta_DNI853(txtBanco_DNI853.Text, txtNroTarjeta_DNI853.Text, txtVencimiento_DNI853.Text);
                }

                // 2. Descontar Stock Sector por Sector independientemente
                foreach (var item_DNI853 in objBllCarrito_DNI853.ObtenerCarrito_DNI853())
                {
                    bool stockDescontado_DNI853 = objBllFuncion_DNI853.DescontarStockSector_DNI853(item_DNI853.IdFuncion_DNI853, item_DNI853.IdSector_DNI853, item_DNI853.Cantidad_DNI853);
                    if (!stockDescontado_DNI853)
                    {
                        throw new Exception($"err_SinDisponibilidadSuficiente|En el sector {item_DNI853.IdSector_DNI853}");
                    }
                }

                var usuarioActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual();
                string loginVendedor_DNI853 = usuarioActual_DNI853 != null ? usuarioActual_DNI853.Login : "Sistema";
                string idPromocionSeleccionada_DNI853 = string.Empty;

                if (cboPromocion_DNI853.SelectedItem != null)
                {
                    idPromocionSeleccionada_DNI853 = ((BE_Promocion_DNI853)cboPromocion_DNI853.SelectedItem).IdPromo_DNI853;
                }

                //BE_Factura_DNI853 nuevaFactura_DNI853 = new BE_Factura_DNI853
                //{
                //    Id_Factura_DNI853 = "FAC_" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper(),
                //    DNI_C_DNI853 = idClienteActual_DNI853,
                //    ImporteTotal_DNI853 = importeTotal_DNI853,
                //    TipoPago_DNI853 = cboMedioPago_DNI853.Text,
                //    Banco_DNI853 = txtBanco_DNI853.Enabled ? txtBanco_DNI853.Text : string.Empty,
                //    NumeroTarjeta_DNI853 = txtNroTarjeta_DNI853.Enabled ? txtNroTarjeta_DNI853.Text : string.Empty,
                //    FechaVencimiento_DNI853 = txtVencimiento_DNI853.Enabled ? txtVencimiento_DNI853.Text : string.Empty,
                //    Fecha_DNI853 = DateTime.Now,
                //    Vendedor_DNI853 = loginVendedor_DNI853,
                //    IdPromocion_DNI853 = idPromocionSeleccionada_DNI853
                //};

                // 3. Registrar Factura (Actualiza sus DVs internamente)
                idVentaConfirmada_DNI853 = objBllFactura_DNI853.RegistrarFacturaUnica_DNI853(idClienteActual_DNI853, importeTotal_DNI853, cboMedioPago_DNI853.Text, txtBanco_DNI853.Enabled ? txtBanco_DNI853.Text : string.Empty, txtNroTarjeta_DNI853.Enabled ? txtNroTarjeta_DNI853.Text : string.Empty, txtVencimiento_DNI853.Enabled ? txtVencimiento_DNI853.Text : string.Empty, loginVendedor_DNI853, idPromocionSeleccionada_DNI853);

                // 4. Registrar Entradas (Actualiza sus DVs internamente)
                List<BE_Entrada_DNI853> listaEntradas_DNI853 = objBllCarrito_DNI853.ObtenerCarrito_DNI853().ToList();
                objBllEntrada_DNI853.PrepararYRegistrarEntradas_DNI853(listaEntradas_DNI853, idVentaConfirmada_DNI853);

                MessageBox.Show(TraducirTexto_DNI853("MsgVentaRegistrada"), TraducirTexto_DNI853("TituloExito"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                BloquearControlesPago_DNI853(true);
                BloquearControlesPostVenta_DNI853(true);
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimirFactura_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(idVentaConfirmada_DNI853))
                {
                    MessageBox.Show(TraducirTexto_DNI853("MsgDebeConfirmarVentaPrimero"), TraducirTexto_DNI853("TituloAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog sfd_DNI853 = new SaveFileDialog() { Filter = "PDF file|*.pdf", FileName = $"Factura_{idVentaConfirmada_DNI853}.pdf" })
                {
                    if (sfd_DNI853.ShowDialog() == DialogResult.OK)
                    {
                        objBllFactura_DNI853.GenerarFacturaEntradasPDF(idVentaConfirmada_DNI853, sfd_DNI853.FileName);
                        MessageBox.Show(TraducirTexto_DNI853("MsgPdfFacturaGenerado"), TraducirTexto_DNI853("TituloExito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimirEntradas_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(idVentaConfirmada_DNI853))
                {
                    MessageBox.Show(TraducirTexto_DNI853("MsgDebeConfirmarVentaPrimero"), TraducirTexto_DNI853("TituloAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog sfd_DNI853 = new SaveFileDialog() { Filter = "PDF file|*.pdf", FileName = $"Entradas_{idVentaConfirmada_DNI853}.pdf" })
                {
                    if (sfd_DNI853.ShowDialog() == DialogResult.OK)
                    {
                        objBllEntrada_DNI853.GenerarEntradasPDF(idVentaConfirmada_DNI853, sfd_DNI853.FileName);
                        MessageBox.Show(TraducirTexto_DNI853("MsgPdfEntradasGenerado"), TraducirTexto_DNI853("TituloExito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_DNI853_Click(object sender, EventArgs e)
        {
            objBllCarrito_DNI853.LimpiarCarrito_DNI853();
            ConfigurarCarrito_DNI853();
            RecalcularTotalCarrito_DNI853();
            txtDniCliente_DNI853.Clear();
            txtNombreCliente_DNI853.Clear();
            idClienteActual_DNI853 = string.Empty;
            idVentaConfirmada_DNI853 = string.Empty;
            cboPromocion_DNI853.SelectedIndex = -1;
            cboMedioPago_DNI853.SelectedIndex = -1;

            BloquearControlesPostVenta_DNI853(false);
            BloquearControlesPago_DNI853(true);
        }

        private void btnSalir_DNI853_Click(object sender, EventArgs e)
        {
            if (objBllCarrito_DNI853.ObtenerCantidadItems_DNI853() > 0 && btnConfirmarVenta_DNI853.Enabled)
            {
                DialogResult resultado_DNI853 = MessageBox.Show(TraducirTexto_DNI853("MsgVentaEnCursoSalir"), TraducirTexto_DNI853("TituloConfirmacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado_DNI853 == DialogResult.No) return;
            }
            this.Close();
        }

        // Evento que se desencadena al cerrar el formulario para desuscribirse del gestor de idioma
        private void FormGestionVentaEntradas_DNI853_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);
        }

        // ====================================================================
        // MANEJO DE SESIÓN Y SEGURIDAD
        // ====================================================================

        private void CargarUsuarioActivo_DNI853()
        {
            Servicio_Usuario usuarioActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual();

            if (usuarioActual_DNI853 != null)
            {
                string nombreRol_DNI853 = objBllRol_DNI853.ObtenerNombreRol(usuarioActual_DNI853.IdRol);
                lblUsuarioValor_DNI853.Text = $"{usuarioActual_DNI853.Login} - {nombreRol_DNI853}";
            }
        }

        // ====================================================================
        // PATRÓN OBSERVER Y TRADUCCIÓN
        // ====================================================================

        public void ActualizarIdioma()
        {
            Servicio_Usuario usuarioActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual();
            if (usuarioActual_DNI853 == null) return;

            string idIdioma_DNI853 = usuarioActual_DNI853.Id_Idioma;
            Servicio_Idioma idiomaActual_DNI853 = objBllIdioma_DNI853.ObtenerIdiomaPorId(idIdioma_DNI853);

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
            Servicio_Usuario usuarioActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual();
            if (usuarioActual_DNI853 == null) return claveParam_DNI853;

            string idIdiomaActual_DNI853 = usuarioActual_DNI853.Id_Idioma;
            if (string.IsNullOrEmpty(idIdiomaActual_DNI853)) return claveParam_DNI853;

            Servicio_Idioma idiomaActual_DNI853 = objBllIdioma_DNI853.ObtenerIdiomaPorId(idIdiomaActual_DNI853);
            if (idiomaActual_DNI853 == null || idiomaActual_DNI853.Etiquetas == null) return claveParam_DNI853;

            var etiquetaObtenida_DNI853 = idiomaActual_DNI853.Etiquetas.FirstOrDefault(x => x.Clave == claveParam_DNI853);
            return etiquetaObtenida_DNI853 != null ? etiquetaObtenida_DNI853.Texto : claveParam_DNI853;
        }

        private void TraducirColumnasGrillas_DNI853()
        {
            // --- Grilla de Funciones ---
            if (dgvFunciones_DNI853.Columns.Contains("IdFuncion_DNI853"))
                dgvFunciones_DNI853.Columns["IdFuncion_DNI853"].Visible = false;

            if (dgvFunciones_DNI853.Columns.Contains("IdObra_DNI853"))
                dgvFunciones_DNI853.Columns["IdObra_DNI853"].Visible = false;

            if (dgvFunciones_DNI853.Columns.Contains("Fecha_DNI853"))
                dgvFunciones_DNI853.Columns["Fecha_DNI853"].HeaderText = TraducirTexto_DNI853("ColFecha");

            if (dgvFunciones_DNI853.Columns.Contains("HoraInicio_DNI853"))
                dgvFunciones_DNI853.Columns["HoraInicio_DNI853"].HeaderText = TraducirTexto_DNI853("ColHoraInicio");

            if (dgvFunciones_DNI853.Columns.Contains("Estado_DNI853"))
                dgvFunciones_DNI853.Columns["Estado_DNI853"].HeaderText = TraducirTexto_DNI853("ColEstado");

            // --- Grilla de Sectores ---
            if (dgvSectores_DNI853.Columns.Contains("IdSector_DNI853"))
                dgvSectores_DNI853.Columns["IdSector_DNI853"].Visible = false;

            if (dgvSectores_DNI853.Columns.Contains("IdFuncion_DNI853"))
                dgvSectores_DNI853.Columns["IdFuncion_DNI853"].Visible = false;

            if (dgvSectores_DNI853.Columns.Contains("NombreSector_DNI853"))
                dgvSectores_DNI853.Columns["NombreSector_DNI853"].HeaderText = TraducirTexto_DNI853("ColNombreSector");

            if (dgvSectores_DNI853.Columns.Contains("Capacidad_DNI853"))
                dgvSectores_DNI853.Columns["Capacidad_DNI853"].HeaderText = TraducirTexto_DNI853("ColCapacidad");

            if (dgvSectores_DNI853.Columns.Contains("Precio_DNI853"))
                dgvSectores_DNI853.Columns["Precio_DNI853"].HeaderText = TraducirTexto_DNI853("ColPrecio");

            // --- Grilla de Carrito ---
            if (dgvCarrito_DNI853.Columns.Contains("Id_Entrada_DNI853"))
                dgvCarrito_DNI853.Columns["Id_Entrada_DNI853"].Visible = false;

            if (dgvCarrito_DNI853.Columns.Contains("Id_Factura_DNI853"))
                dgvCarrito_DNI853.Columns["Id_Factura_DNI853"].Visible = false;

            if (dgvCarrito_DNI853.Columns.Contains("IdFuncion_DNI853"))
                dgvCarrito_DNI853.Columns["IdFuncion_DNI853"].Visible = false;

            if (dgvCarrito_DNI853.Columns.Contains("IdSector_DNI853"))
                dgvCarrito_DNI853.Columns["IdSector_DNI853"].Visible = false;

            if (dgvCarrito_DNI853.Columns.Contains("Detalle_DNI853"))
            {
                dgvCarrito_DNI853.Columns["Detalle_DNI853"].HeaderText = TraducirTexto_DNI853("ColDetalle");
                
            }

            if (dgvCarrito_DNI853.Columns.Contains("Cantidad_DNI853"))
                dgvCarrito_DNI853.Columns["Cantidad_DNI853"].HeaderText = TraducirTexto_DNI853("ColCantidad");

            if (dgvCarrito_DNI853.Columns.Contains("PrecioUnitario_DNI853"))
                dgvCarrito_DNI853.Columns["PrecioUnitario_DNI853"].HeaderText = TraducirTexto_DNI853("ColPrecioUnitario");

            if (dgvCarrito_DNI853.Columns.Contains("Subtotal_DNI853"))
                dgvCarrito_DNI853.Columns["Subtotal_DNI853"].HeaderText = TraducirTexto_DNI853("ColSubtotal");
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

        private void cboObra_DNI853_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarGrillaFunciones_DNI853();
        }

        private void btnNuevaVenta_DNI853_Click(object sender, EventArgs e)
        {
            btnLimpiar_DNI853_Click(sender, e);
        }
    }
}
