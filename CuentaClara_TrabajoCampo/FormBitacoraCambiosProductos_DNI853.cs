using BE;
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
    public partial class FormBitacoraCambiosProductos_DNI853 : Form, IObserverIdioma
    {
        private BLL_Idioma bllIdioma_DNI853;
        private BLL_Producto_C_DNI853 bllBitacoraProducto_DNI853;
        private BLL_Rol bllRol_DNI853;
        public FormBitacoraCambiosProductos_DNI853()
        {
            InitializeComponent();
            bllIdioma_DNI853 = new BLL_Idioma();
            bllBitacoraProducto_DNI853 = new BLL_Producto_C_DNI853();
            bllRol_DNI853 = new BLL_Rol();
            GestorIdioma.GetInstancia().Suscribir(this);
        }

        private void FormBitacoraCambiosProductos_DNI853_Load(object sender, EventArgs e)
        {
            CargarUsuarioActivo_DNI853();
            ActualizarIdioma();
            InicializarFiltros_DNI853();
            CargarBitacora_DNI853();
        }

        private void InicializarFiltros_DNI853()
        {
            dtpFechaIni_DNI853.Value = DateTime.Now.AddDays(-30);
            dtpFechaFin_DNI853.Value = DateTime.Now;
            txt_codProductoFiltro_DNI853.Clear();
            txtNombre_DNI853.Clear();
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
        private void CargarBitacora_DNI853()
        {
            try
            {
                string codProd_DNI853 = txt_codProductoFiltro_DNI853.Text.Trim();
                string nombre_DNI853 = txtNombre_DNI853.Text.Trim();
                DateTime fechaIni_DNI853 = dtpFechaIni_DNI853.Value.Date;
                DateTime fechaFin_DNI853 = dtpFechaFin_DNI853.Value.Date;

                var listaHistorial_DNI853 = bllBitacoraProducto_DNI853.ListarBitacora_DNI853(
                    codProd_DNI853,
                    nombre_DNI853,
                    fechaIni_DNI853,
                    fechaFin_DNI853
                );

                dgvBitacora_DNI853.DataSource = null;
                dgvBitacora_DNI853.DataSource = listaHistorial_DNI853;

                TraducirColumnasGrillas_DNI853();
            }
            catch (Exception ex_DNI853)
            {
                MessageBox.Show(TraducirExcepcion_DNI853(ex_DNI853), TraducirTexto_DNI853("TituloError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAplicar_DNI853_Click(object sender, EventArgs e)
        {
            CargarBitacora_DNI853();
        }

        private void btnLimpiar_DNI853_Click(object sender, EventArgs e)
        {
            InicializarFiltros_DNI853();
            CargarBitacora_DNI853();
        }

        private void btnActivar_DNI853_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBitacora_DNI853.CurrentRow == null)
                    throw new Exception("err_SeleccioneRegistroBitacora");

                BE_Producto_C_DNI853 registroSeleccionado_DNI853 = (BE_Producto_C_DNI853)dgvBitacora_DNI853.CurrentRow.DataBoundItem;

                bool exito_DNI853 = bllBitacoraProducto_DNI853.ActivarRegistroHistorico_DNI853(registroSeleccionado_DNI853);

                if (exito_DNI853)
                {
                    MessageBox.Show(TraducirTexto_DNI853("MsgRegistroActivadoExito"), TraducirTexto_DNI853("TituloExito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora_DNI853();
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

        private void FormBitacoraCambiosProductos_DNI853_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);
        }

        #region traduccion de idiomass

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
            if (dgvBitacora_DNI853.Columns.Count == 0) return;

            if (dgvBitacora_DNI853.Columns.Contains("IdCambio_DNI853"))
                dgvBitacora_DNI853.Columns["IdCambio_DNI853"].Visible = false;

            if (dgvBitacora_DNI853.Columns.Contains("IdProducto_DNI853"))
                dgvBitacora_DNI853.Columns["IdProducto_DNI853"].HeaderText = TraducirTexto_DNI853("ColCodProd");

            if (dgvBitacora_DNI853.Columns.Contains("Fecha_DNI853"))
                dgvBitacora_DNI853.Columns["Fecha_DNI853"].HeaderText = TraducirTexto_DNI853("ColFecha");

            if (dgvBitacora_DNI853.Columns.Contains("Hora_DNI853"))
                dgvBitacora_DNI853.Columns["Hora_DNI853"].HeaderText = TraducirTexto_DNI853("ColHora");

            if (dgvBitacora_DNI853.Columns.Contains("NombreProducto_DNI853"))
                dgvBitacora_DNI853.Columns["NombreProducto_DNI853"].HeaderText = TraducirTexto_DNI853("ColNombreProducto");

            if (dgvBitacora_DNI853.Columns.Contains("Stock_DNI853"))
                dgvBitacora_DNI853.Columns["Stock_DNI853"].HeaderText = TraducirTexto_DNI853("ColExistencias");

            if (dgvBitacora_DNI853.Columns.Contains("Categoria_DNI853"))
                dgvBitacora_DNI853.Columns["Categoria_DNI853"].HeaderText = TraducirTexto_DNI853("ColDescCategoria");

            if (dgvBitacora_DNI853.Columns.Contains("Precio_DNI853"))
                dgvBitacora_DNI853.Columns["Precio_DNI853"].HeaderText = TraducirTexto_DNI853("ColPrecioProducto");

            if (dgvBitacora_DNI853.Columns.Contains("Act_DNI853"))
                dgvBitacora_DNI853.Columns["Act_DNI853"].HeaderText = TraducirTexto_DNI853("ColActivo");
        }

        private string TraducirExcepcion_DNI853(Exception ex_DNI853)
        {
            string[] partes = ex_DNI853.Message.Split('|');
            string mensaje = TraducirTexto_DNI853(partes[0]);
            if (partes.Length > 1) mensaje += " " + partes[1];
            return mensaje;
        }

        #endregion

        private void FormBitacoraCambiosProductos_DNI853_Resize(object sender, EventArgs e)
        {
            if (panelContenedor_DNI853 != null)
            {
                // Esta matemática calcula el centro exacto de la pantalla
                panelContenedor_DNI853.Left = (this.ClientSize.Width - panelContenedor_DNI853.Width) / 2;
                panelContenedor_DNI853.Top = (this.ClientSize.Height - panelContenedor_DNI853.Height) / 2;
            }
        }
    }
}
