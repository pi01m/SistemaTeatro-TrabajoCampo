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
    public partial class FormGestionCarritoCantina_DNI853 : Form, IObserverIdioma
    {
        private BLL_Carrito_DNI853 bllCarrito_DNI853;
        private BLL_Cliente_DNI853 bllCliente_DNI853;
        private BLL_Rol bllRol_DNI853;
        private BLL_Idioma bllIdioma_DNI853;
        private string idClienteActual_DNI853 = string.Empty;

        // Lista original para filtrado local en memoria
        private List<BE_Producto_DNI853> listaProductosOriginal_DNI853;

        public FormGestionCarritoCantina_DNI853()
        {
            InitializeComponent();
            bllCarrito_DNI853 = new BLL_Carrito_DNI853();
            bllCliente_DNI853 = new BLL_Cliente_DNI853();
            bllRol_DNI853 = new BLL_Rol();
            bllIdioma_DNI853 = new BLL_Idioma();

            GestorIdioma.GetInstancia().Suscribir(this);
        }

        private void FormGestionCarritoCantina_DNI853_Load(object sender, EventArgs e)
        {
            CargarUsuarioActivo_DNI853();
            ActualizarIdioma();
            CargarDatosIniciales_DNI853();
            ConfigurarCarrito_DNI853();
        }

        private void CargarDatosIniciales_DNI853()
        {
            try
            {
                listaProductosOriginal_DNI853 = bllCarrito_DNI853.ListarProductos_DNI853();

                // Cargar categorías incluyendo "Todas" para ver todos los productos
                var categorias = listaProductosOriginal_DNI853
                    .Select(p => p.Categoria_DNI853)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList();

                categorias.Insert(0, "Todas");

                cboCategoria_DNI853.DataSource = categorias;
                if (cboCategoria_DNI853.Items.Count > 0)
                    cboCategoria_DNI853.SelectedIndex = 0;

                AplicarFiltrosProductos_DNI853();
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltrosProductos_DNI853()
        {
            if (listaProductosOriginal_DNI853 == null) return;

            string textoBusqueda = txtBuscarProducto_DNI853.Text.Trim().ToLower();
            string categoriaSeleccionada = cboCategoria_DNI853.SelectedItem?.ToString() ?? "Todas";

            var productosFiltrados = listaProductosOriginal_DNI853.Where(p =>
            {
                bool cumpleCategoria = (categoriaSeleccionada == "Todas" || p.Categoria_DNI853 == categoriaSeleccionada);
                bool cumpleTexto = string.IsNullOrEmpty(textoBusqueda) ||
                                   p.NombreProducto_DNI853.ToLower().Contains(textoBusqueda) ||
                                   p.IdProducto_DNI853.ToLower().Contains(textoBusqueda);

                return cumpleCategoria && cumpleTexto;
            }).ToList();

            dgvProductos_DNI853.DataSource = null;
            dgvProductos_DNI853.DataSource = productosFiltrados;
            TraducirColumnasGrillas_DNI853();

            if (dgvProductos_DNI853.Rows.Count > 0)
            {
                dgvProductos_DNI853.ClearSelection();
                dgvProductos_DNI853.Rows[0].Selected = true;

                // Esto es clave para que el CurrentRow no sea nulo al tocar el botón de "Agregar"
                if (dgvProductos_DNI853.Columns.Count > 0)
                {
                    dgvProductos_DNI853.CurrentCell = dgvProductos_DNI853.Rows[0].Cells[0];
                }
            }
        }

        private void txtBuscarProducto_DNI853_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltrosProductos_DNI853();
        }

        private void cboCategoria_DNI853_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltrosProductos_DNI853();
        }

        private void ConfigurarCarrito_DNI853()
        {
            dgvCarrito_DNI853.DataSource = null;
            dgvCarrito_DNI853.DataSource = bllCarrito_DNI853.ObtenerCarritoProducto_DNI853();
            TraducirColumnasGrillas_DNI853();
            ActualizarTotal_DNI853();
        }

        private void ActualizarTotal_DNI853()
        {
            decimal total = bllCarrito_DNI853.CalcularImporteTotal_DNI853();
            txtImporteTotal_DNI853.Text = $"$ {total:N2}";
        }

        private void btnAgregarItem_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos_DNI853.CurrentRow == null)
                    throw new Exception("err_SeleccioneProductoPrimero");

                BE_Producto_DNI853 productoSeleccionado = (BE_Producto_DNI853)dgvProductos_DNI853.CurrentRow.DataBoundItem;

                bllCarrito_DNI853.AgregarItem_DNI853(
                    productoSeleccionado.IdProducto_DNI853,
                    productoSeleccionado.NombreProducto_DNI853,
                    productoSeleccionado.Precio_DNI853,
                    productoSeleccionado.Stock_DNI853,
                    txtCantidad_DNI853.Text
                );

                ConfigurarCarrito_DNI853();
                txtCantidad_DNI853.Text = "1";
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloAtencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuitarItem_DNI853_Click(object sender, EventArgs e)
        {
            if (dgvCarrito_DNI853.CurrentRow != null)
            {
                BE_ItemCarrito_DNI853 item = (BE_ItemCarrito_DNI853)dgvCarrito_DNI853.CurrentRow.DataBoundItem;
                bllCarrito_DNI853.QuitarItemProducto_DNI853(item);
                ConfigurarCarrito_DNI853();
            }
        }

        private void btnBuscarCliente_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = txtDniCliente_DNI853.Text.Trim();
                if (string.IsNullOrEmpty(dni))
                    throw new Exception("err_DniClienteObligatorio");

                BE_Cliente_DNI853 cliente = bllCliente_DNI853.BuscarPorDNI_DNI853(dni);
                if (cliente != null)
                {
                    idClienteActual_DNI853 = cliente.DNI_C_DNI853;
                    txtNombreCliente_DNI853.Text = $"{cliente.Nombre_C_DNI853} {cliente.Apellido_C_DNI853}";
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
            FormGestionClientes_DNI853 formClientes = new FormGestionClientes_DNI853();
            formClientes.ShowDialog();

            if (!string.IsNullOrEmpty(txtDniCliente_DNI853.Text))
            {
                btnBuscarCliente_DNI853_Click(sender, e);
            }
        }

        private void btnConfirmarPedido_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(idClienteActual_DNI853))
                    throw new Exception("err_DebeAsociarClientePrimero");

                string idPedido = bllCarrito_DNI853.ConfirmarPedido_DNI853(idClienteActual_DNI853);

                MessageBox.Show($"{TraducirTexto_DNI853("MsgPedidoGuardadoExito")}: {idPedido}", TraducirTexto_DNI853("TituloExito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNuevaVenta_DNI853_Click(sender, e);
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevaVenta_DNI853_Click(object sender, EventArgs e)
        {
            bllCarrito_DNI853.LimpiarCarritoProducto_DNI853();
            ConfigurarCarrito_DNI853();
            txtDniCliente_DNI853.Clear();
            txtNombreCliente_DNI853.Clear();
            idClienteActual_DNI853 = string.Empty;
            txtBuscarProducto_DNI853.Clear();
            if (cboCategoria_DNI853.Items.Count > 0)
                cboCategoria_DNI853.SelectedIndex = 0;
            CargarDatosIniciales_DNI853();
        }

        private void btnLimpiar_DNI853_Click(object sender, EventArgs e)
        {
            btnNuevaVenta_DNI853_Click(sender, e);
        }

        private void btnSalir_DNI853_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormGestionCarritoCantina_DNI853_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);
        }

        private void CargarUsuarioActivo_DNI853()
        {
            Servicio_Usuario usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
            if (usuarioActual != null)
            {
                string nombreRol = bllRol_DNI853.ObtenerNombreRol(usuarioActual.IdRol);
                lblUsuarioValor_DNI853.Text = $"{usuarioActual.Login} - {nombreRol}";
            }
        }

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
            // Grilla Productos
            if (dgvProductos_DNI853.Columns.Contains("IdProducto_DNI853"))
                dgvProductos_DNI853.Columns["IdProducto_DNI853"].Visible = false;

            if (dgvProductos_DNI853.Columns.Contains("NombreProducto_DNI853"))
                dgvProductos_DNI853.Columns["NombreProducto_DNI853"].HeaderText = TraducirTexto_DNI853("ColNombreProducto");

            if (dgvProductos_DNI853.Columns.Contains("Categoria_DNI853"))
                dgvProductos_DNI853.Columns["Categoria_DNI853"].HeaderText = TraducirTexto_DNI853("ColCategoriaProducto");

            if (dgvProductos_DNI853.Columns.Contains("Precio_DNI853"))
                dgvProductos_DNI853.Columns["Precio_DNI853"].HeaderText = TraducirTexto_DNI853("ColPrecioProducto");

            if (dgvProductos_DNI853.Columns.Contains("Stock_DNI853"))
                dgvProductos_DNI853.Columns["Stock_DNI853"].HeaderText = TraducirTexto_DNI853("ColStockProducto");

            // Grilla Carrito
            if (dgvCarrito_DNI853.Columns.Contains("IdItem_DNI853"))
                dgvCarrito_DNI853.Columns["IdItem_DNI853"].Visible = false;

            if (dgvCarrito_DNI853.Columns.Contains("IdPedido_DNI853"))
                dgvCarrito_DNI853.Columns["IdPedido_DNI853"].Visible = false;

            if (dgvCarrito_DNI853.Columns.Contains("IdProducto_DNI853"))
                dgvCarrito_DNI853.Columns["IdProducto_DNI853"].Visible = false;

            if (dgvCarrito_DNI853.Columns.Contains("NombreProducto_DNI853"))
                dgvCarrito_DNI853.Columns["NombreProducto_DNI853"].HeaderText = TraducirTexto_DNI853("ColNombreProducto");

            if (dgvCarrito_DNI853.Columns.Contains("CantidadSolicitada_DNI853"))
                dgvCarrito_DNI853.Columns["CantidadSolicitada_DNI853"].HeaderText = TraducirTexto_DNI853("ColCantidad");

            if (dgvCarrito_DNI853.Columns.Contains("PrecioUnitario_DNI853"))
                dgvCarrito_DNI853.Columns["PrecioUnitario_DNI853"].HeaderText = TraducirTexto_DNI853("ColPrecioUnitario");

            if (dgvCarrito_DNI853.Columns.Contains("Subtotal_DNI853"))
                dgvCarrito_DNI853.Columns["Subtotal_DNI853"].HeaderText = TraducirTexto_DNI853("ColSubtotal");
        }

        private string TraducirExcepcion_DNI853(Exception ex_DNI853)
        {
            string[] partes = ex_DNI853.Message.Split('|');
            string mensaje = TraducirTexto_DNI853(partes[0]);
            if (partes.Length > 1) mensaje += " " + partes[1];
            return mensaje;
        }
    }
}
