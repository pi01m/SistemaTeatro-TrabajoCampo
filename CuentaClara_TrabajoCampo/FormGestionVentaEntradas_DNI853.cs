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

namespace IU
{
    public partial class FormGestionVentaEntradas_DNI853 : Form, IObserverIdioma
    {
        // Instancias de las clases de la capa de negocio (BLL) separadas por procesos
        private BLL_Factura_DNI853 bllVenta_DNI853 = new BLL_Factura_DNI853();
        private BLL_Funcion_DNI853 bllFuncion_DNI853 = new BLL_Funcion_DNI853();
        private BLL_Cliente_DNI853 bllCliente_DNI853 = new BLL_Cliente_DNI853();
        private BLL_Promocion_DNI853 bllPromocion_DNI853 = new BLL_Promocion_DNI853();
        private BLL_MedioPago_DNI853 bllMedioPago_DNI853 = new BLL_MedioPago_DNI853();
        private BLL_Entrada_DNI853 bllEntrada_DNI853 = new BLL_Entrada_DNI853();
        private BLL_Obra_DNI853 bllObra_DNI853 = new BLL_Obra_DNI853();
        private BLL_Sector_DNI853 bllSector_DNI853 = new BLL_Sector_DNI853();
        // Instancias de BLL de Servicios generales para roles e idioma
        private BLL_Rol bllRol_DNI853 = new BLL_Rol();
        private BLL_Idioma bllIdioma_DNI853 = new BLL_Idioma();

        // Lista observable para almacenar temporalmente los ítems seleccionados en el carrito de compras (usando BE_Entrada_DNI853)
        private BindingList<BE_Entrada_DNI853> carrito_DNI853;

        // Variables globales para el manejo de importes, identificación del cliente y control de la venta
        private decimal importeTotal_DNI853 = 0;
        private string idClienteActual_DNI853 = string.Empty;
        private string idVentaConfirmada_DNI853 = string.Empty;

        // Constructor del formulario que inicializa componentes y se suscribe al patrón Observer de Idioma
        public FormGestionVentaEntradas_DNI853()
        {
            InitializeComponent();

            // Suscripción al Patrón Observer de Idioma
            GestorIdioma.GetInstancia().Suscribir(this);
        }

        // Evento que se ejecuta al cargar el formulario, configurando usuario activo, idioma, carrito y controles
        private void FormGestionVentaEntradas_DNI853_Load(object sender, EventArgs e)
        {
            CargarUsuarioActivo_DNI853();
            ActualizarIdioma();
            ConfigurarCarrito_DNI853();
            CargarCombosIniciales_DNI853();
            BloquearControlesPostVenta_DNI853(false);
        }

        // Configura las columnas y el origen de datos de la grilla del carrito de compras
        private void ConfigurarCarrito_DNI853()
        {
            carrito_DNI853 = new BindingList<BE_Entrada_DNI853>();
            dgvCarrito_DNI853.DataSource = carrito_DNI853;

            // Ocultar IDs internos que no deben verse
            if (dgvCarrito_DNI853.Columns.Contains("Id_Entrada_DNI853"))
                dgvCarrito_DNI853.Columns["Id_Entrada_DNI853"].Visible = false;

            if (dgvCarrito_DNI853.Columns.Contains("Id_Factura_DNI853"))
                dgvCarrito_DNI853.Columns["Id_Factura_DNI853"].Visible = false;

            if (dgvCarrito_DNI853.Columns.Contains("IdFuncion_DNI853"))
                dgvCarrito_DNI853.Columns["IdFuncion_DNI853"].Visible = false;

            if (dgvCarrito_DNI853.Columns.Contains("IdSector_DNI853"))
                dgvCarrito_DNI853.Columns["IdSector_DNI853"].Visible = false;

            // Mostrar y traducir las columnas útiles
            if (dgvCarrito_DNI853.Columns.Contains("Detalle_DNI853"))
            {
                dgvCarrito_DNI853.Columns["Detalle_DNI853"].HeaderText = TraducirTexto_DNI853("ColDetalle");
                dgvCarrito_DNI853.Columns["Detalle_DNI853"].Width = 250; // Damos buen espacio para leer la info
            }

            if (dgvCarrito_DNI853.Columns.Contains("Cantidad_DNI853"))
                dgvCarrito_DNI853.Columns["Cantidad_DNI853"].HeaderText = TraducirTexto_DNI853("ColCantidad");

            if (dgvCarrito_DNI853.Columns.Contains("PrecioUnitario_DNI853"))
                dgvCarrito_DNI853.Columns["PrecioUnitario_DNI853"].HeaderText = TraducirTexto_DNI853("ColPrecioUnitario");

            if (dgvCarrito_DNI853.Columns.Contains("Subtotal_DNI853"))
                dgvCarrito_DNI853.Columns["Subtotal_DNI853"].HeaderText = TraducirTexto_DNI853("ColSubtotal");
        }

        // Carga los elementos iniciales en los ComboBox de obras, promociones y medios de pago utilizando sus respectivas BLL
        private void CargarCombosIniciales_DNI853()
        {
            cboObra_DNI853.DataSource = bllObra_DNI853.ObtenerObrasEnCartelera_DNI853();

            // 2. Después definimos qué propiedad se muestra visualmente
            cboObra_DNI853.DisplayMember = "NombreObra_DNI853";

            // 3. Y por último definimos qué propiedad actúa como el valor interno (el ID)
            cboObra_DNI853.ValueMember = "IdObra_DNI853";
            cboPromocion_DNI853.DataSource = bllPromocion_DNI853.ObtenerPromocionesVigentesParaEntradas_DNI853();
            cboMedioPago_DNI853.DataSource = bllMedioPago_DNI853.ObtenerMediosDePago_DNI853();

            // Deshabilitar inicialmente los campos correspondientes a la tarjeta de crédito/débito
            HabilitarCamposTarjeta_DNI853(false);
        }

        // Busca las funciones disponibles para la obra y fecha seleccionadas por el usuario (IdObra es string)
        private void btnBuscarFunciones_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtenemos el valor seleccionado del combo
                string valorSeleccionado_DNI853 = cboObra_DNI853.SelectedValue?.ToString();

                // VALIDACIÓN DEFENSIVA: Si por error el SelectedValue devolvió el nombre ("Dracula"), 
                // buscamos la obra en la lista para obtener su verdadero ID.
                var obraSeleccionada = bllObra_DNI853.ListarObras_DNI853()
                    .FirstOrDefault(o => o.IdObra_DNI853 == valorSeleccionado_DNI853 || o.NombreObra_DNI853 == valorSeleccionado_DNI853);

                string idObraReal_DNI853 = obraSeleccionada != null ? obraSeleccionada.IdObra_DNI853 : valorSeleccionado_DNI853;
                DateTime fecha_DNI853 = dtpFechaFuncion_DNI853.Value.Date;

                // Consultamos usando el ID real
                dgvFunciones_DNI853.DataSource = bllFuncion_DNI853.ObtenerFuncionesConfirmadas_DNI853(idObraReal_DNI853, fecha_DNI853);
                dgvSectores_DNI853.DataSource = null;
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Actualiza los sectores disponibles cuando el usuario selecciona una función distinta en la grilla (IdFuncion es string)
        private void dgvFunciones_DNI853_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFunciones_DNI853.CurrentRow != null)
            {
                string idFuncion_DNI853 = dgvFunciones_DNI853.CurrentRow.Cells["IdFuncion_DNI853"].Value?.ToString();
                dgvSectores_DNI853.DataSource = bllSector_DNI853.ObtenerSectoresPorFuncion_DNI853(idFuncion_DNI853);
            }
        }

        // Valida la disponibilidad y agrega un ítem (entrada) al carrito de compras (IDs como string)
        private void btnAgregarItem_DNI853_Click(object sender, EventArgs e)
        {
            if (dgvFunciones_DNI853.CurrentRow == null || dgvSectores_DNI853.CurrentRow == null)
            {
                MessageBox.Show(TraducirTexto_DNI853("MsgSeleccioneFuncionSector"), TraducirTexto_DNI853("TituloAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidad_DNI853.Text, out int cantidad_DNI853) || cantidad_DNI853 <= 0)
            {
                MessageBox.Show(TraducirTexto_DNI853("MsgCantidadValida"), TraducirTexto_DNI853("TituloAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int dispActual_DNI853 = Convert.ToInt32(dgvSectores_DNI853.CurrentRow.Cells["Capacidad_DNI853"].Value);
            if (cantidad_DNI853 > dispActual_DNI853)
            {
                MessageBox.Show($"{TraducirTexto_DNI853("MsgSuperaDisponibilidad")} ({dispActual_DNI853})", TraducirTexto_DNI853("TituloSinDisponibilidad"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idFuncion_DNI853 = dgvFunciones_DNI853.CurrentRow.Cells["IdFuncion_DNI853"].Value?.ToString();
            string idSector_DNI853 = dgvSectores_DNI853.CurrentRow.Cells["IdSector_DNI853"].Value?.ToString();
            decimal precioSector_DNI853 = Convert.ToDecimal(dgvSectores_DNI853.CurrentRow.Cells["Precio_DNI853"].Value);

            // Capturamos los textos descriptivos directamente de las grillas visuales
            string nombreSector_DNI853 = dgvSectores_DNI853.CurrentRow.Cells["NombreSector_DNI853"].Value?.ToString();
            string horaInicioFunc_DNI853 = dgvFunciones_DNI853.CurrentRow.Cells["HoraInicio_DNI853"].Value?.ToString();
            DateTime fechaFunc_DNI853 = Convert.ToDateTime(dgvFunciones_DNI853.CurrentRow.Cells["Fecha_DNI853"].Value);

            // Armamos un detalle estructurado que incluya Obra, Función (Fecha/Hora) y Sector
            string detalleFormateado_DNI853 = $"Obra: {cboObra_DNI853.Text} | Func: {fechaFunc_DNI853.ToShortDateString()} {horaInicioFunc_DNI853}hs | Sector: {nombreSector_DNI853}";

            BE_Entrada_DNI853 nuevoItem_DNI853 = new BE_Entrada_DNI853
            {
                IdFuncion_DNI853 = idFuncion_DNI853,
                IdSector_DNI853 = idSector_DNI853,
                Detalle_DNI853 = detalleFormateado_DNI853, // <--- Aquí guardamos todo de forma legible
                Cantidad_DNI853 = cantidad_DNI853,
                PrecioUnitario_DNI853 = precioSector_DNI853
            };

            carrito_DNI853.Add(nuevoItem_DNI853);
            RecalcularTotalCarrito_DNI853();
            txtCantidad_DNI853.Clear();
        }

        // Remueve el ítem seleccionado actualmente de la grilla del carrito de compras
        private void btnQuitarItem_DNI853_Click(object sender, EventArgs e)
        {
            if (dgvCarrito_DNI853.CurrentRow != null)
            {
                BE_Entrada_DNI853 itemSeleccionado_DNI853 = (BE_Entrada_DNI853)dgvCarrito_DNI853.CurrentRow.DataBoundItem;
                carrito_DNI853.Remove(itemSeleccionado_DNI853);
                RecalcularTotalCarrito_DNI853();
            }
        }

        // Recalcula el importe total de la venta sumando los subtotales del carrito y aplicando descuentos de promoción si corresponde
        private void RecalcularTotalCarrito_DNI853()
        {
            importeTotal_DNI853 = 0;

            foreach (BE_Entrada_DNI853 item_DNI853 in carrito_DNI853)
            {
                importeTotal_DNI853 += item_DNI853.Subtotal_DNI853;
            }

            // Aplica la promoción seleccionada si existe un descuento vigente
            if (cboPromocion_DNI853.SelectedItem != null && importeTotal_DNI853 > 0)
            {
                BE_Promocion_DNI853 promo_DNI853 = (BE_Promocion_DNI853)cboPromocion_DNI853.SelectedItem;
                importeTotal_DNI853 -= promo_DNI853.ValorDescuento_DNI853;
            }

            txtImporteTotal_DNI853.Text = $"$ {importeTotal_DNI853:N2}";
        }

        // Evento que recalcula el total al cambiar la promoción seleccionada en el ComboBox
        private void cboPromocion_DNI853_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalcularTotalCarrito_DNI853();
        }

        // Busca los datos de un cliente registrado utilizando el número de DNI ingresado
        private void btnBuscarCliente_DNI853_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDniCliente_DNI853.Text)) return;

            try
            {
                BE_Cliente_DNI853 cliente_DNI853 = bllCliente_DNI853.BuscarPorDNI_DNI853(txtDniCliente_DNI853.Text);
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

        // Abre el formulario de gestión de clientes para registrar un nuevo cliente en el sistema
        private void btnRegistrarCliente_DNI853_Click(object sender, EventArgs e)
        {
            FormGestionClientes_DNI853 formClientes_DNI853 = new FormGestionClientes_DNI853();
            formClientes_DNI853.ShowDialog();

            // Intenta buscar automáticamente al cliente recién registrado si el DNI estaba escrito
            if (!string.IsNullOrEmpty(txtDniCliente_DNI853.Text))
            {
                btnBuscarCliente_DNI853.PerformClick();
            }
        }

        // Habilita o deshabilita los campos de tarjeta según el medio de pago seleccionado
        private void cboMedioPago_DNI853_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esTarjeta_DNI853 = cboMedioPago_DNI853.Text.ToUpper().Contains("TARJETA");
            HabilitarCamposTarjeta_DNI853(esTarjeta_DNI853);
        }

        // Controla la disponibilidad y limpieza de los campos de texto correspondientes a la tarjeta
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

        // Valida las condiciones obligatorias, procesa el pago y registra la venta completa con sus entradas en la base de datos
        private void btnConfirmarVenta_DNI853_Click(object sender, EventArgs e)
        {
            if (carrito_DNI853.Count == 0)
            {
                MessageBox.Show(TraducirTexto_DNI853("MsgCarritoVacio"), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(idClienteActual_DNI853))
            {
                MessageBox.Show(TraducirTexto_DNI853("MsgDebeSeleccionarCliente"), TraducirTexto_DNI853("TituloValidacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtBanco_DNI853.Enabled && (string.IsNullOrWhiteSpace(txtNroTarjeta_DNI853.Text) || string.IsNullOrWhiteSpace(txtBanco_DNI853.Text)))
            {
                MessageBox.Show(TraducirTexto_DNI853("MsgCompleteDatosTarjeta"), TraducirTexto_DNI853("TituloValidacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var usuarioActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual();
                string loginVendedor_DNI853 = usuarioActual_DNI853 != null ? usuarioActual_DNI853.Login : "Sistema";

                // CAPTURAR EL ID DE LA PROMOCIÓN SELECCIONADA
                string idPromocionSeleccionada = string.Empty;
                if (cboPromocion_DNI853.SelectedItem != null)
                {
                    BE_Promocion_DNI853 promoSeleccionada = (BE_Promocion_DNI853)cboPromocion_DNI853.SelectedItem;
                    idPromocionSeleccionada = promoSeleccionada.IdPromo_DNI853; 
                }

                BE_Factura_DNI853 nuevaVenta_DNI853 = new BE_Factura_DNI853
                {
                    DNI_C_DNI853 = idClienteActual_DNI853,
                    ImporteTotal_DNI853 = importeTotal_DNI853,
                    TipoPago_DNI853 = cboMedioPago_DNI853.Text,
                    Banco_DNI853 = txtBanco_DNI853.Enabled ? txtBanco_DNI853.Text : string.Empty,
                    NumeroTarjeta_DNI853 = txtNroTarjeta_DNI853.Enabled ? txtNroTarjeta_DNI853.Text : string.Empty,
                    FechaVencimiento_DNI853 = txtVencimiento_DNI853.Enabled ? txtVencimiento_DNI853.Text : string.Empty,
                    Fecha_DNI853 = DateTime.Now,
                    Vendedor_DNI853 = loginVendedor_DNI853,
                    IdPromocion_DNI853 = idPromocionSeleccionada 
                };

                List<BE_Entrada_DNI853> listaEntradas_DNI853 = carrito_DNI853.ToList();
                idVentaConfirmada_DNI853 = bllVenta_DNI853.RegistrarFactura_DNI853(nuevaVenta_DNI853, listaEntradas_DNI853);

                MessageBox.Show(TraducirTexto_DNI853("MsgVentaRegistrada"), TraducirTexto_DNI853("TituloExito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                BloquearControlesPostVenta_DNI853(true);
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Genera y guarda el PDF de la factura utilizando un diálogo de archivo
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
                        bllVenta_DNI853.GenerarFacturaPDF(idVentaConfirmada_DNI853, sfd_DNI853.FileName);
                        MessageBox.Show(TraducirTexto_DNI853("MsgPdfFacturaGenerado"), TraducirTexto_DNI853("TituloExito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Genera y guarda el PDF de las entradas utilizando un diálogo de archivo
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
                        // Llamamos directamente a la BLL de entradas como solicitaste
                        bllEntrada_DNI853.GenerarEntradasPDF(idVentaConfirmada_DNI853, sfd_DNI853.FileName);

                        MessageBox.Show(TraducirTexto_DNI853("MsgPdfEntradasGenerado"), TraducirTexto_DNI853("TituloExito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Limpia todos los campos del formulario para reiniciar el proceso o iniciar una nueva venta
        private void btnLimpiar_DNI853_Click(object sender, EventArgs e)
        {
            carrito_DNI853.Clear();
            RecalcularTotalCarrito_DNI853();
            txtDniCliente_DNI853.Clear();
            txtNombreCliente_DNI853.Clear();
            idClienteActual_DNI853 = string.Empty;
            idVentaConfirmada_DNI853 = string.Empty;
            cboPromocion_DNI853.SelectedIndex = -1;
            cboMedioPago_DNI853.SelectedIndex = -1;

            BloquearControlesPostVenta_DNI853(false);
        }

        // Gestiona el estado de habilitación de los botones de carga y de impresión tras finalizar una venta
        private void BloquearControlesPostVenta_DNI853(bool ventaConfirmada_DNI853)
        {
            btnConfirmarVenta_DNI853.Enabled = !ventaConfirmada_DNI853;
            btnAgregarItem_DNI853.Enabled = !ventaConfirmada_DNI853;
            btnQuitarItem_DNI853.Enabled = !ventaConfirmada_DNI853;

            btnImprimirFactura_DNI853.Enabled = ventaConfirmada_DNI853;
            btnImprimirEntradas_DNI853.Enabled = ventaConfirmada_DNI853;

            btnLimpiar_DNI853.Text = ventaConfirmada_DNI853 ? TraducirTexto_DNI853("BtnNuevaVenta") : TraducirTexto_DNI853("BtnCancelarVenta");
        }

        // Cierra el formulario actual validando si existe una venta pendiente sin confirmar
        private void btnSalir_DNI853_Click(object sender, EventArgs e)
        {
            if (carrito_DNI853.Count > 0 && btnConfirmarVenta_DNI853.Enabled)
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
                string nombreRol_DNI853 = bllRol_DNI853.ObtenerNombreRol(usuarioActual_DNI853.IdRol);
                lblUsuarioValor_DNI853.Text = $"{usuarioActual_DNI853.Login} - {nombreRol_DNI853}";
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
            ConfigurarCarrito_DNI853();
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
