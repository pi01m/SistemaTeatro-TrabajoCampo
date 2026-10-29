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
    public partial class FormGestionProducto_DNI853 : Form, IObserverIdioma
    {
        private BLL_Producto_DNI853 bllProducto_DNI853;
        private BLL_Rol bllRol_DNI853;
        private BLL_Idioma bllIdioma_DNI853;
        private BE_Producto_DNI853 productoSeleccionado_DNI853;

        public FormGestionProducto_DNI853()
        {
            InitializeComponent();
            bllProducto_DNI853 = new BLL_Producto_DNI853();
            bllRol_DNI853 = new BLL_Rol();
            bllIdioma_DNI853 = new BLL_Idioma();

            dgvProductos_DNI853.MultiSelect = false;
            dgvProductos_DNI853.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos_DNI853.ReadOnly = true;

            GestorIdioma.GetInstancia().Suscribir(this);
        }

        private void FormGestionProducto_DNI853_Load_1(object sender, EventArgs e)
        {
            FormGestionProducto_DNI853_Resize(null, null);
            CargarUsuarioActivo_DNI853();
            ActualizarIdioma();
            ActualizarGrillaProductos_DNI853();
            CargarCategorias_DNI853();
        }
        private void CargarCategorias_DNI853()
        {
            try
            {
                cmbCategoria_DNI853.Items.Clear();

               
                cmbCategoria_DNI853.Items.Add("Bebidas");
                cmbCategoria_DNI853.Items.Add("Snacks");
                cmbCategoria_DNI853.Items.Add("Golosinas");
                cmbCategoria_DNI853.Items.Add("Comida Rápida");
                

                if (cmbCategoria_DNI853.Items.Count > 0)
                    cmbCategoria_DNI853.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarGrillaProductos_DNI853()
        {
            try
            {
                dgvProductos_DNI853.DataSource = null;
                dgvProductos_DNI853.DataSource = bllProducto_DNI853.ListarProductos_DNI853();
                TraducirColumnasGrillas_DNI853();

                if (dgvProductos_DNI853.Rows.Count > 0)
                {
                    dgvProductos_DNI853.ClearSelection();
                    dgvProductos_DNI853.Rows[0].Selected = true;

                    if (dgvProductos_DNI853.Columns.Count > 0)
                    {
                        dgvProductos_DNI853.CurrentCell = dgvProductos_DNI853.Rows[0].Cells[0];
                    }

                    // Forzamos la carga de datos del primer elemento
                    productoSeleccionado_DNI853 = (BE_Producto_DNI853)dgvProductos_DNI853.Rows[0].DataBoundItem;
                    CargarDatosEnControles_DNI853(productoSeleccionado_DNI853);
                }
                else
                {
                    LimpiarControlesProducto_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEnControles_DNI853(BE_Producto_DNI853 productoParam_DNI853)
        {
            if (productoParam_DNI853 != null)
            {
                
                txtNombreProducto_DNI853.Text = productoParam_DNI853.NombreProducto_DNI853;
                cmbCategoria_DNI853.SelectedItem = productoParam_DNI853.Categoria_DNI853;
                txtPrecio_DNI853.Text = productoParam_DNI853.Precio_DNI853.ToString();
                txtStock_DNI853.Text = productoParam_DNI853.Stock_DNI853.ToString();

               
            }
        }

        private void LimpiarControlesProducto_DNI853()
        {
            
            txtNombreProducto_DNI853.Text = string.Empty;
            txtPrecio_DNI853.Text = string.Empty;
            txtStock_DNI853.Text = string.Empty;
            if (cmbCategoria_DNI853.Items.Count > 0)
                cmbCategoria_DNI853.SelectedIndex = 0;

            productoSeleccionado_DNI853 = null;
        }

        private void dgvProductos_DNI853_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos_DNI853.CurrentRow != null)
            {
                productoSeleccionado_DNI853 = (BE_Producto_DNI853)dgvProductos_DNI853.CurrentRow.DataBoundItem;
                CargarDatosEnControles_DNI853(productoSeleccionado_DNI853);
            }
        }

        private void btnNuevoProducto_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                // La UI solo captura strings/datos crudos de los controles visuales.
                // La creación del objeto BE, validaciones, bitácora y DV se realizan exclusivamente en la BLL.
                string id_DNI853 = "PRD-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
                string nombre_DNI853 = txtNombreProducto_DNI853.Text;
                string categoria_DNI853 = cmbCategoria_DNI853.SelectedItem?.ToString() ?? "";
                string precioStr_DNI853 = txtPrecio_DNI853.Text;
                string stockStr_DNI853 = txtStock_DNI853.Text;

                bool resultadoProc_DNI853 = bllProducto_DNI853.CrearProducto_DNI853(id_DNI853, nombre_DNI853, categoria_DNI853, precioStr_DNI853, stockStr_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_ProductoCreado"));
                    ActualizarGrillaProductos_DNI853();
                    LimpiarControlesProducto_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarProducto_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSeleccionado_DNI853 == null)
                    throw new Exception("err_SeleccioneProductoPrimero");

                productoSeleccionado_DNI853.NombreProducto_DNI853 = txtNombreProducto_DNI853.Text;
                productoSeleccionado_DNI853.Categoria_DNI853 = cmbCategoria_DNI853.SelectedItem?.ToString() ?? "";

                if (decimal.TryParse(txtPrecio_DNI853.Text, out decimal precio_DNI853))
                    productoSeleccionado_DNI853.Precio_DNI853 = precio_DNI853;

                if (int.TryParse(txtStock_DNI853.Text, out int stock_DNI853))
                    productoSeleccionado_DNI853.Stock_DNI853 = stock_DNI853;

                bool resultadoProc_DNI853 = bllProducto_DNI853.ModificarProducto_DNI853(productoSeleccionado_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_ProductoModificado"));
                    ActualizarGrillaProductos_DNI853();
                }
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProducto_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSeleccionado_DNI853 == null)
                    throw new Exception("err_SeleccioneProductoPrimero");

                bool resultadoProc_DNI853 = bllProducto_DNI853.EliminarProducto_DNI853(productoSeleccionado_DNI853.IdProducto_DNI853);
                if (resultadoProc_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("Exito_ProductoEliminado"));
                    ActualizarGrillaProductos_DNI853();
                    LimpiarControlesProducto_DNI853();
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

        private void FormGestionProducto_DNI853_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);
        }

        private void FormGestionProducto_DNI853_Resize(object sender, EventArgs e)
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
            if (dgvProductos_DNI853.Columns.Contains("IdProducto_DNI853"))
            {
                dgvProductos_DNI853.Columns["IdProducto_DNI853"].HeaderText = TraducirTexto_DNI853("ColIdProducto");
                dgvProductos_DNI853.Columns["IdProducto_DNI853"].Visible = true;
            }

            if (dgvProductos_DNI853.Columns.Contains("NombreProducto_DNI853"))
                dgvProductos_DNI853.Columns["NombreProducto_DNI853"].HeaderText = TraducirTexto_DNI853("ColNombreProducto");

            if (dgvProductos_DNI853.Columns.Contains("Categoria_DNI853"))
                dgvProductos_DNI853.Columns["Categoria_DNI853"].HeaderText = TraducirTexto_DNI853("ColCategoriaProducto");

            if (dgvProductos_DNI853.Columns.Contains("Precio_DNI853"))
                dgvProductos_DNI853.Columns["Precio_DNI853"].HeaderText = TraducirTexto_DNI853("ColPrecioProducto");

            if (dgvProductos_DNI853.Columns.Contains("Stock_DNI853"))
                dgvProductos_DNI853.Columns["Stock_DNI853"].HeaderText = TraducirTexto_DNI853("ColStockProducto");
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
