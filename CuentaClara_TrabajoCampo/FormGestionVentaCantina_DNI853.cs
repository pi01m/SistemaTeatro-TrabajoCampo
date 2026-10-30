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
    public partial class FormGestionVentaCantina_DNI853 : Form, IObserverIdioma
    {
        private BLL_MedioPago_DNI853 bllMedioPago_DNI853;
        private BLL_Factura_DNI853 bllFactura_DNI853;
        private BLL_Cliente_DNI853 bllCliente_DNI853;
        private BLL_Rol bllRol_DNI853;
        private BLL_Idioma bllIdioma_DNI853;
        private BLL_Carrito_DNI853 bllCarrito_DNI853;
        private BLL_Promocion_DNI853 bllPromocion_DNI853;

        private string idFacturaGenerada_DNI853 = string.Empty;
        private BE_Pedido_DNI853 pedidoSeleccionado_DNI853 = null;
        private decimal subtotalBase_DNI853 = 0;
        public FormGestionVentaCantina_DNI853()
        {
            InitializeComponent();

            bllMedioPago_DNI853 = new BLL_MedioPago_DNI853();
            bllFactura_DNI853 = new BLL_Factura_DNI853();
            bllCliente_DNI853 = new BLL_Cliente_DNI853();
            bllRol_DNI853 = new BLL_Rol();
            bllIdioma_DNI853 = new BLL_Idioma();

            bllCarrito_DNI853 = new BLL_Carrito_DNI853();
            bllPromocion_DNI853 = new BLL_Promocion_DNI853();
            GestorIdioma.GetInstancia().Suscribir(this);
        }


        private void FormGestionVentaCantina_DNI853_Load(object sender, EventArgs e)
        {
            CargarUsuarioActivo_DNI853();
            CargarMediosPago_DNI853();
            CargarDonaciones_DNI853();
            CargarPromociones_DNI853();
            ActualizarIdioma();
            EstadoInicial_DNI853();
        }

        private void dgvPedidos_DNI853_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPedidos_DNI853.CurrentRow != null)
            {
                pedidoSeleccionado_DNI853 = (BE_Pedido_DNI853)dgvPedidos_DNI853.CurrentRow.DataBoundItem;

                // === SOLUCIÓN: Limpiar el DataSource antes de asignar el nuevo ===
                dgvDetalleVenta_DNI853.DataSource = null;
                dgvDetalleVenta_DNI853.DataSource = pedidoSeleccionado_DNI853.Items_DNI853;

                TraducirColumnasGrillas_DNI853();

                subtotalBase_DNI853 = pedidoSeleccionado_DNI853.ImporteTotal_DNI853;
                CalcularTotalConDonacion_DNI853();

                btnConfirmarVenta_DNI853.Enabled = true;
            }
            else
            {
                pedidoSeleccionado_DNI853 = null;
                dgvDetalleVenta_DNI853.DataSource = null;
                subtotalBase_DNI853 = 0;
                txtImporteTotal_DNI853.Text = "$ 0.00";
                btnConfirmarVenta_DNI853.Enabled = false;
            }
        }

        private void cboMedioPago_DNI853_SelectedIndexChanged(object sender, EventArgs e)
        {
            var medio = (BE_MedioPago_DNI853)cboMedioPago_DNI853.SelectedItem;
            bool esTarjeta = medio != null && (medio.Nombre_MedioPago_DNI853.ToLower().Contains("tarjeta") ||
                                               medio.Nombre_MedioPago_DNI853.ToLower().Contains("debito") ||
                                               medio.Nombre_MedioPago_DNI853.ToLower().Contains("credito"));

            txtBanco_DNI853.Enabled = esTarjeta;
            txtNroTarjeta_DNI853.Enabled = esTarjeta;
            txtVencimiento_DNI853.Enabled = esTarjeta;

            if (!esTarjeta)
            {
                txtBanco_DNI853.Clear();
                txtNroTarjeta_DNI853.Clear();
                txtVencimiento_DNI853.Clear();
            }
        }

        private void CmbDonacionPorcentaje_DNI853_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularTotalConDonacion_DNI853();
        }

        private void btnBuscarPedido_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = txtDniCliente_DNI853.Text.Trim();
                if (string.IsNullOrEmpty(dni))
                    throw new Exception("err_DniClienteObligatorio");

                // Buscar cliente en BLL
                BE_Cliente_DNI853 cliente = bllCliente_DNI853.BuscarPorDNI_DNI853(dni);
                if (cliente != null)
                    txtNombreCliente_DNI853.Text = $"{cliente.Nombre_C_DNI853} {cliente.Apellido_C_DNI853}";
                else
                    txtNombreCliente_DNI853.Text = TraducirTexto_DNI853("MsgConsumidorFinal");

                // Solicitar los pedidos a la BLL
                var pedidosPendientes = bllCarrito_DNI853.ListarPedidosCantina_DNI853()
                                        .Where(p => p.DNI_C_DNI853 == dni && p.Estado_Venta_DNI853 == "PendientePago")
                                        .ToList();

                dgvPedidos_DNI853.DataSource = pedidosPendientes;
                TraducirColumnasGrillas_DNI853();
                if (dgvPedidos_DNI853.Rows.Count > 0)
                {
                    dgvPedidos_DNI853.ClearSelection();
                    dgvPedidos_DNI853.Rows[0].Selected = true;

                    if (dgvPedidos_DNI853.Columns.Count > 0)
                    {
                        dgvPedidos_DNI853.CurrentCell = dgvPedidos_DNI853.Rows[0].Cells[0];
                    }
                }
                else
                {
                    MessageBox.Show(TraducirTexto_DNI853("MsgSinPedidosPendientes"), TraducirTexto_DNI853("TituloInformacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_DNI853_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_DNI853_Click(object sender, EventArgs e)
        {
            EstadoInicial_DNI853();
        }

        private void btnConfirmarVenta_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (pedidoSeleccionado_DNI853 == null)
                    throw new Exception("err_DebeSeleccionarPedido");

                var medioPago = (BE_MedioPago_DNI853)cboMedioPago_DNI853.SelectedItem;
                if (medioPago == null)
                    throw new Exception("err_MedioPagoObligatorio");

                if (txtBanco_DNI853.Enabled)
                {
                    bllFactura_DNI853.ValidarDatosTarjeta_DNI853(txtBanco_DNI853.Text, txtNroTarjeta_DNI853.Text, txtVencimiento_DNI853.Text);
                }

                string idPromocionSeleccionada = string.Empty;
                if (cboPromocion_DNI853.SelectedItem != null)
                {
                    idPromocionSeleccionada = ((BE_Promocion_DNI853)cboPromocion_DNI853.SelectedItem).IdPromo_DNI853;
                }


                string dniCliente = txtDniCliente_DNI853.Text.Trim();
                decimal totalFinal = decimal.Parse(txtImporteTotal_DNI853.Text.Replace("$", "").Trim());

                var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
                string vendedor = usuarioActual != null ? usuarioActual.Login : "Sistema";

                // Registrar Factura final en BD
                idFacturaGenerada_DNI853 = bllFactura_DNI853.RegistrarFacturaUnica_DNI853(
                    dniCliente,
                    totalFinal,
                    medioPago.Nombre_MedioPago_DNI853,
                    txtBanco_DNI853.Text,
                    txtNroTarjeta_DNI853.Text,
                    txtVencimiento_DNI853.Text,
                    vendedor,
                    idPromocionSeleccionada,
                    pedidoSeleccionado_DNI853.IdPedido_DNI853
                );

                // Actualizar Estado del Pedido utilizando la BLL (Pasar a Pagado)
                bllCarrito_DNI853.ActualizarEstadoPedido_DNI853(pedidoSeleccionado_DNI853.IdPedido_DNI853, "Pagado");
                bllCarrito_DNI853.DescontarStockProductos_DNI853(pedidoSeleccionado_DNI853.Items_DNI853);
                MessageBox.Show($"{TraducirTexto_DNI853("MsgVentaConfirmadaExito")}\nFactura: {idFacturaGenerada_DNI853}", TraducirTexto_DNI853("TituloExito"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnConfirmarVenta_DNI853.Enabled = false;
                btnImprimirFactura_DNI853.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimirFactura_DNI853_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idFacturaGenerada_DNI853)) return;

            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Archivos PDF (*.pdf)|*.pdf",
                    FileName = $"Factura_Cantina_{idFacturaGenerada_DNI853}.pdf"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var medioPago = (BE_MedioPago_DNI853)cboMedioPago_DNI853.SelectedItem;
                    decimal totalFinal = decimal.Parse(txtImporteTotal_DNI853.Text.Replace("$", "").Trim());
                    var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
                    string vendedor = usuarioActual != null ? usuarioActual.Login : "Sistema";

                    // Llamamos al nuevo método exclusivo de Cantina
                    bllFactura_DNI853.GenerarFacturaCantinaPDF(
                        idFacturaGenerada_DNI853,
                        txtDniCliente_DNI853.Text.Trim(),
                        vendedor,
                        medioPago.Nombre_MedioPago_DNI853,
                        txtBanco_DNI853.Text,
                        txtNroTarjeta_DNI853.Text,
                        totalFinal,
                        pedidoSeleccionado_DNI853.Items_DNI853, // Le pasamos la lista de productos directamente
                        sfd.FileName
                    );

                    MessageBox.Show(TraducirTexto_DNI853("MsgFacturaImpresaExito"), TraducirTexto_DNI853("TituloExito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EstadoInicial_DNI853();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // MÉTODOS AUXILIARES Y DE CONFIGURACIÓN
        // ==========================================

        private void EstadoInicial_DNI853()
        {
            txtDniCliente_DNI853.Clear();
            txtNombreCliente_DNI853.Clear();
            txtBanco_DNI853.Clear();
            txtNroTarjeta_DNI853.Clear();
            txtVencimiento_DNI853.Clear();
            txtImporteTotal_DNI853.Text = "$ 0.00";

            dgvPedidos_DNI853.DataSource = null;
            dgvDetalleVenta_DNI853.DataSource = null;

            if (cboMedioPago_DNI853.Items.Count > 0) cboMedioPago_DNI853.SelectedIndex = 0;
            if (CmbDonacionPorcentaje_DNI853.Items.Count > 0) CmbDonacionPorcentaje_DNI853.SelectedIndex = 0;

            cboPromocion_DNI853.SelectedIndex = -1; 

            btnConfirmarVenta_DNI853.Enabled = false;
            btnImprimirFactura_DNI853.Enabled = false;
            idFacturaGenerada_DNI853 = string.Empty;
            pedidoSeleccionado_DNI853 = null;
            subtotalBase_DNI853 = 0;
        }

        private void CargarMediosPago_DNI853()
        {
            try
            {
                cboMedioPago_DNI853.DataSource = bllMedioPago_DNI853.ObtenerMediosDePago_DNI853();
            }
            catch (Exception ex)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDonaciones_DNI853()
        {
            CmbDonacionPorcentaje_DNI853.Items.Clear();
            CmbDonacionPorcentaje_DNI853.Items.Add("0%");
            CmbDonacionPorcentaje_DNI853.Items.Add("5%");
            CmbDonacionPorcentaje_DNI853.Items.Add("10%");
            CmbDonacionPorcentaje_DNI853.Items.Add("15%");
            CmbDonacionPorcentaje_DNI853.Items.Add("20%");
            CmbDonacionPorcentaje_DNI853.SelectedIndex = 0;
        }

        private void CalcularTotalConDonacion_DNI853()
        {
            if (pedidoSeleccionado_DNI853 == null) return;

            string seleccion = CmbDonacionPorcentaje_DNI853.SelectedItem?.ToString().Replace("%", "") ?? "0";

            if (decimal.TryParse(seleccion, out decimal porcentaje))
            {
                decimal montoDonacion = subtotalBase_DNI853 * (porcentaje / 100);
                decimal totalConDonacion = subtotalBase_DNI853 + montoDonacion;

                if (cboPromocion_DNI853.SelectedItem != null && totalConDonacion > 0)
                {
                    BE_Promocion_DNI853 promo = (BE_Promocion_DNI853)cboPromocion_DNI853.SelectedItem;
                    totalConDonacion -= promo.ValorDescuento_DNI853;

                    // Evitamos que quede un total negativo
                    if (totalConDonacion < 0) totalConDonacion = 0;
                }

                txtImporteTotal_DNI853.Text = $"$ {totalConDonacion:N2}";
            }
        }

        private void CargarUsuarioActivo_DNI853()
        {
            Servicio_Usuario usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
            if (usuarioActual != null)
            {
                string nombreRol = bllRol_DNI853.ObtenerNombreRol(usuarioActual.IdRol);
                if (this.Controls.Find("lblUsuarioValor_DNI853", true).FirstOrDefault() is Label lbl)
                    lbl.Text = $"{usuarioActual.Login} - {nombreRol}";
            }
        }

        private void FormGestionVentaCantina_DNI853_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);
        }

        // ==========================================
        // PATRÓN OBSERVER E IDIOMAS
        // ==========================================
        public void ActualizarIdioma()
        {
            Servicio_Usuario usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
            if (usuarioActual == null) return;

            Servicio_Idioma idiomaActual = bllIdioma_DNI853.ObtenerIdiomaPorId(usuarioActual.Id_Idioma);
            if (idiomaActual == null) return;

            TraducirControles_DNI853(this.Controls, idiomaActual);
            TraducirColumnasGrillas_DNI853();
        }

        private void TraducirControles_DNI853(Control.ControlCollection controles, Servicio_Idioma idioma)
        {
            foreach (Control control in controles)
            {
                if (control.Tag != null)
                {
                    string clave = control.Tag.ToString();
                    var etiqueta = idioma.Etiquetas.FirstOrDefault(x => x.Clave == clave);
                    if (etiqueta != null)
                        control.Text = etiqueta.Texto;
                }

                if (control.HasChildren)
                {
                    TraducirControles_DNI853(control.Controls, idioma);
                }
            }
        }

        private string TraducirTexto_DNI853(string claveParam)
        {
            Servicio_Usuario usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
            if (usuarioActual == null) return claveParam;

            Servicio_Idioma idiomaActual = bllIdioma_DNI853.ObtenerIdiomaPorId(usuarioActual.Id_Idioma);
            if (idiomaActual == null || idiomaActual.Etiquetas == null) return claveParam;

            var etiqueta = idiomaActual.Etiquetas.FirstOrDefault(x => x.Clave == claveParam);
            return etiqueta != null ? etiqueta.Texto : claveParam;
        }

        private void TraducirColumnasGrillas_DNI853()
        {
            if (dgvPedidos_DNI853.Columns.Contains("IdPedido_DNI853"))
                dgvPedidos_DNI853.Columns["IdPedido_DNI853"].HeaderText = TraducirTexto_DNI853("ColNroPedido");

            if (dgvPedidos_DNI853.Columns.Contains("DNI_C_DNI853"))
                dgvPedidos_DNI853.Columns["DNI_C_DNI853"].Visible = false;

            if (dgvPedidos_DNI853.Columns.Contains("IdVendedor_DNI853"))
                dgvPedidos_DNI853.Columns["IdVendedor_DNI853"].HeaderText = TraducirTexto_DNI853("ColVendedor");

            if (dgvPedidos_DNI853.Columns.Contains("FechaVenta_DNI853"))
                dgvPedidos_DNI853.Columns["FechaVenta_DNI853"].HeaderText = TraducirTexto_DNI853("ColFecha");

            if (dgvPedidos_DNI853.Columns.Contains("HoraVenta_DNI853"))
                dgvPedidos_DNI853.Columns["HoraVenta_DNI853"].Visible = false;

            if (dgvPedidos_DNI853.Columns.Contains("ImporteTotal_DNI853"))
                dgvPedidos_DNI853.Columns["ImporteTotal_DNI853"].HeaderText = TraducirTexto_DNI853("ColTotal");

            if (dgvPedidos_DNI853.Columns.Contains("Estado_Venta_DNI853"))
                dgvPedidos_DNI853.Columns["Estado_Venta_DNI853"].HeaderText = TraducirTexto_DNI853("ColEstado");

            if (dgvDetalleVenta_DNI853.Columns.Contains("IdItem_DNI853"))
                dgvDetalleVenta_DNI853.Columns["IdItem_DNI853"].Visible = false;

            if (dgvDetalleVenta_DNI853.Columns.Contains("IdPedido_DNI853"))
                dgvDetalleVenta_DNI853.Columns["IdPedido_DNI853"].Visible = false;

            if (dgvDetalleVenta_DNI853.Columns.Contains("IdProducto_DNI853"))
                dgvDetalleVenta_DNI853.Columns["IdProducto_DNI853"].Visible = false;

            if (dgvDetalleVenta_DNI853.Columns.Contains("NombreProducto_DNI853"))
                dgvDetalleVenta_DNI853.Columns["NombreProducto_DNI853"].HeaderText = TraducirTexto_DNI853("ColNombreProducto");

            if (dgvDetalleVenta_DNI853.Columns.Contains("CantidadSolicitada_DNI853"))
                dgvDetalleVenta_DNI853.Columns["CantidadSolicitada_DNI853"].HeaderText = TraducirTexto_DNI853("ColCantidad");

            if (dgvDetalleVenta_DNI853.Columns.Contains("PrecioUnitario_DNI853"))
                dgvDetalleVenta_DNI853.Columns["PrecioUnitario_DNI853"].HeaderText = TraducirTexto_DNI853("ColPrecioUnitario");

            if (dgvDetalleVenta_DNI853.Columns.Contains("Subtotal_DNI853"))
                dgvDetalleVenta_DNI853.Columns["Subtotal_DNI853"].HeaderText = TraducirTexto_DNI853("ColSubtotal");
        }

        private string TraducirExcepcion_DNI853(Exception ex)
        {
            string[] partes = ex.Message.Split('|');
            string mensaje = TraducirTexto_DNI853(partes[0]);
            if (partes.Length > 1) mensaje += " " + partes[1];
            return mensaje;
        }

        private void panelContenedor_DNI853_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboPromocion_DNI853_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularTotalConDonacion_DNI853();
        }
        private void CargarPromociones_DNI853()
        {
            try
            {
                
                cboPromocion_DNI853.DataSource = bllPromocion_DNI853.ObtenerPromocionesVigentesParaCantina_DNI853();
                cboPromocion_DNI853.DisplayMember = "NombrePromo_DNI853";
                cboPromocion_DNI853.ValueMember = "IdPromo_DNI853";
                cboPromocion_DNI853.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
