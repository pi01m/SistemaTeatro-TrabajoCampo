using BLL.BLL_Servicio;
using Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CuentaClara_TrabajoCampo
{
    public partial class FormGestionUsuarios : Form, IObserverIdioma
    {
        private BLL_Usuario bll = new BLL_Usuario();
        private BLL_Rol bllRol = new BLL_Rol();
        private string modoActual;
        public FormGestionUsuarios()
        {
            InitializeComponent();
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.ReadOnly = true;

            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            GestorIdioma.GetInstancia().Suscribir(this);
      
        }

        

        private void RefrescarSesionUsuario()
        {
            var login = SessionManager.GetInstancia().GetUsuarioActual().Login;

            var bllUsuario = new BLL_Usuario();
            var usuarioActualizado = bllUsuario.RecargarUsuarioSesion(login);

            SessionManager.GetInstancia().SetUsuarioActual(usuarioActualizado);

            var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();

           
            BloquearBotonesSegunPermisos(usuarioActual);

           
            string nombreRol = bllRol.ObtenerNombreRol(usuarioActual.IdRol);
            label1.Text = $"{usuarioActual.Login} - {nombreRol}";
        }

        private void CargarUsuarios()
        {
            if (radioBtnTodosUser.Checked)
            {
                dgvUsuarios.DataSource = bll.ListarUsuarios();
                dgvUsuarios.Columns["Permisos"].Visible = false;
                dgvUsuarios.Columns["ModoEmergencia"].Visible = false;
                dgvUsuarios.Columns["ErrorIntegridad"].Visible = false;
            }
            else if (radioBtnUserActivos.Checked)
            {
                dgvUsuarios.DataSource = bll.ListarUsuariosActivos();
            }
            TraducirColumnasUsuarios();
            dgvUsuarios.Refresh();

        }

        private void BloquearBotonesSegunPermisos(Servicio_Usuario usuarioActual)
        {
            if (usuarioActual == null || usuarioActual.Permisos == null)
            {
                DeshabilitarBotonesEdicion();
                return;
            }
           
            btnCrear.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P1");
            btnModificar.Enabled =bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P2");
            btnActivarDesactivar.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P3");
            btnDesbloquear.Enabled =bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P4");
                
            bool puedeEditar = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P2");

        }

        private void DeshabilitarBotonesEdicion()
        {
            btnCrear.Enabled = false;
            btnModificar.Enabled = false;
            btnDesbloquear.Enabled = false;
            btnActivarDesactivar.Enabled = false;
            btnAplicar.Enabled = false;
        }
        private void FormGestionUsuarios_Load_1(object sender, EventArgs e)
        {
            FormGestionUsuarios_Resize(null, null);
            radioBtnTodosUser.Checked = true;

            RefrescarSesionUsuario();

            var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
            BloquearBotonesSegunPermisos(usuarioActual);
            string nombreRol = bllRol.ObtenerNombreRol(usuarioActual.IdRol);
            label1.Text = $"{usuarioActual.Login}-{nombreRol}";

            cmbRol.DataSource = bllRol.ObtenerRoles();
            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "IdRol";
            CargarUsuarios();

            btnAplicar.Enabled = false;
            btnCancelar.Enabled = false;
            lblTotalUsuarios.Text = dgvUsuarios.Rows.Count.ToString();

            ActualizarIdioma();

            BloquearCampos();

            modoActual = "ModoConsulta";

            lstMensajes.Items.Clear();
            //lstMensajes.Items.Add("Modo Consulta");
            lstMensajes.Items.Add(TraducirTexto("ModoConsulta"));
        }

        private void HabilitarCamposEdicion()
        {
            txtNombre.ReadOnly = false;
            txtApellido.ReadOnly = false;
            txtCorreo.ReadOnly = false;
        }
        private void RestaurarModoConsulta()
        {
            BloquearCampos();

            btnAplicar.Enabled = false;
            btnCancelar.Enabled = false;

            btnCrear.Enabled = true;
            btnModificar.Enabled = true;
            btnDesbloquear.Enabled = true;
            btnActivarDesactivar.Enabled = true;

            modoActual = "ModoConsulta";

            lstMensajes.Items.Clear();
            //lstMensajes.Items.Add("Modo Consulta");
            lstMensajes.Items.Add(TraducirTexto("ModoConsulta"));
        }

        private void BloquearCampos()
        {
            txtDNI.ReadOnly = true;
            txtApellido.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtCorreo.ReadOnly = true;

            txtLogin.ReadOnly = true;
            chkActivo.Enabled = false;
            cmbRol.Enabled = false;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            FormCrearUsuario frm = new FormCrearUsuario();

            frm.ShowDialog(); CargarUsuarios();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            HabilitarCamposEdicion();

            btnAplicar.Enabled = true;
            btnCancelar.Enabled = true;

            btnCrear.Enabled = false;
            btnDesbloquear.Enabled = false;
            btnActivarDesactivar.Enabled = false;
            cmbRol.Enabled = true;

            modoActual = "ModoModificar";

            lstMensajes.Items.Clear();
            //lstMensajes.Items.Add("Modo Modificar");
            lstMensajes.Items.Add(TraducirTexto("ModoModificar"));
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            btnAplicar.Enabled = true;
            btnCancelar.Enabled = true;

            btnCrear.Enabled = false;
            btnModificar.Enabled = false;
            btnActivarDesactivar.Enabled = false;

            modoActual = "ModoDesbloquear";


            lstMensajes.Items.Clear();
            //lstMensajes.Items.Add("Modo Desbloquear");
            lstMensajes.Items.Add(TraducirTexto("ModoDesbloquear"));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            RestaurarModoConsulta();

            CargarUsuarios();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null) return;

            txtDNI.Text = dgvUsuarios.CurrentRow.Cells["DNI"].Value.ToString();
            txtApellido.Text = dgvUsuarios.CurrentRow.Cells["Apellido"].Value.ToString();
            txtNombre.Text = dgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
            txtCorreo.Text = dgvUsuarios.CurrentRow.Cells["email"].Value.ToString();
            txtLogin.Text = dgvUsuarios.CurrentRow.Cells["Login"].Value.ToString();
            string idRol = dgvUsuarios.CurrentRow.Cells["IdRol"].Value.ToString();
            cmbRol.Text = bllRol.ObtenerNombreRol(idRol);
            chkActivo.Checked = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Activo"].Value) == 1;

        }


        private void btnActivarDesactivar_Click(object sender, EventArgs e)
        {
            chkActivo.Enabled = true;

            btnAplicar.Enabled = true;
            btnCancelar.Enabled = true;

            btnCrear.Enabled = false;
            btnModificar.Enabled = false;
            btnDesbloquear.Enabled = false;

            modoActual = "ModoActivarDesactivar";

            lstMensajes.Items.Clear();
            //lstMensajes.Items.Add("Modo Activar / Desactivar");
            lstMensajes.Items.Add(TraducirTexto("ModoActivarDesactivar"));
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {


                if (modoActual == "ModoModificar")
                {
                    string nuevoIdRol = cmbRol.SelectedValue.ToString();
                    bool resultado = bll.ModificarUsuario(txtDNI.Text, txtNombre.Text, txtApellido.Text, txtCorreo.Text, nuevoIdRol);

                    //MessageBox.Show(resultado ? "Usuario modificado" : "No se pudo modificar");
                    MessageBox.Show(resultado ? TraducirTexto("UsuarioModificado") : TraducirTexto("NoSePudoModificar"));

                }

                else if (modoActual == "ModoDesbloquear")
                {
                    int intentos = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Bloqueo"].Value);


                    if (intentos < 3)
                    {
                        //MessageBox.Show("El usuario seleccionado no se encuentra bloqueado.");
                        MessageBox.Show(TraducirTexto("UsuarioNoBloqueado"));
                        return;
                    }


                    //MessageBox.Show("Usuario desbloqueado correctamente.");

                    bool rta = bll.DesbloquearUsuario(txtLogin.Text);
                    if (rta)
                    {
                        MessageBox.Show(TraducirTexto("UsuarioDesbloqueado"));
                    }
                    else
                    {
                        MessageBox.Show(TraducirTexto("ErrorDesbloquearUsuario"));
                    }

                    CargarUsuarios();

                    RestaurarModoConsulta();
                }

                else if (modoActual == "ModoActivarDesactivar")
                {
                    int activo = chkActivo.Checked ? 1 : 0;

                    bool resultado = bll.CambiarEstadoUsuario(txtDNI.Text, activo);

                    //MessageBox.Show("Estado actualizado correctamente.");

                    if (resultado)
                    {
                        MessageBox.Show(TraducirTexto("EstadoActualizado"));
                    }
                    else
                    {
                        MessageBox.Show(TraducirTexto("err_NoSePudoActualizarEstadoUsuario"));
                    }

                }

                CargarUsuarios();

                RestaurarModoConsulta();
            } 
            catch(Exception ex) 
            {
                string mensaje = TraducirExcepcion(ex);

                MessageBox.Show(mensaje);
            }
        }

        private string TraducirExcepcion(Exception ex)
        {
            string[] partes = ex.Message.Split('|');

            string clave = partes[0];

            string mensaje = TraducirTexto(clave);

            if (partes.Length > 1)
            {
                mensaje += " " + partes[1];
            }

            return mensaje;
        }

        private void radioBtnUserActivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void radioBtnTodosUser_CheckedChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void FormGestionUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);

        }

        public void ActualizarIdioma()
        {
            string idIdioma = SessionManager.GetInstancia().GetUsuarioActual().Id_Idioma;

            BLL_Idioma bllIdioma = new BLL_Idioma();

            Servicio_Idioma idioma = bllIdioma.ObtenerIdiomaPorId(idIdioma);

            if (idioma == null)
                return;

            TraducirControles(this.Controls, idioma);
            TraducirColumnasUsuarios();
        }

        private void TraducirControles(Control.ControlCollection controls, Servicio_Idioma idioma)
        {
            foreach (Control c in controls)
            {
                if (c.Tag != null)
                {
                    string clave = c.Tag.ToString();

                    var etiqueta = idioma.Etiquetas.FirstOrDefault(x => x.Clave == clave);
                    if (etiqueta != null) c.Text = etiqueta.Texto;

                }

                if (c is DataGridView dgv)
                {
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        string clave = col.Name;

                        var etiqueta = idioma.Etiquetas.FirstOrDefault(x => x.Clave == clave);

                        if (etiqueta != null) col.HeaderText = etiqueta.Texto;

                    }
                }

                if (c.HasChildren)
                    TraducirControles(c.Controls, idioma);
            }
        }
        private string TraducirTexto(string clave)
        {
            string idIdioma =
                SessionManager.GetInstancia()
                .GetUsuarioActual()
                .Id_Idioma;

            BLL_Idioma bllIdioma = new BLL_Idioma();

            Servicio_Idioma idioma = bllIdioma.ObtenerIdiomaPorId(idIdioma);

            if (idioma == null)
                return clave;

            var etiqueta = idioma.Etiquetas.FirstOrDefault(x => x.Clave == clave);

            return etiqueta != null ? etiqueta.Texto : clave;
        }

        private void TraducirColumnasUsuarios()
        {
            dgvUsuarios.Columns["DNI"].HeaderText = TraducirTexto("DNI");
            dgvUsuarios.Columns["Apellido"].HeaderText = TraducirTexto("Apellido");
            dgvUsuarios.Columns["Nombre"].HeaderText = TraducirTexto("Nombre");
            dgvUsuarios.Columns["email"].HeaderText = TraducirTexto("Email");
            dgvUsuarios.Columns["Login"].HeaderText = TraducirTexto("Login");
            dgvUsuarios.Columns["IdRol"].HeaderText = TraducirTexto("Rol");
            dgvUsuarios.Columns["Activo"].HeaderText = TraducirTexto("Activo");

            dgvUsuarios.Columns["Password"].HeaderText = TraducirTexto("Password");
            dgvUsuarios.Columns["Bloqueo"].HeaderText = TraducirTexto("Bloqueo");
            dgvUsuarios.Columns["Id_Idioma"].HeaderText = TraducirTexto("Idioma");
        }

        private void FormGestionUsuarios_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                return;

            int altoDisponible = ClientSize.Height - panelInferior.Height;

            panelContenedor.Location = new Point(
                (ClientSize.Width - panelContenedor.Width) / 2,
                (altoDisponible - panelContenedor.Height) / 2
            );
        }
    }
}

