using BLL.BLL_Servicio;
using IU;
using Servicio;
using System.Diagnostics;

namespace CuentaClara_TrabajoCampo
{
    public partial class FormMenu : Form, IObserverIdioma
    {

        private BLL_Usuario bllUsuario = new BLL_Usuario();
        private BLL_Rol bllRol = new BLL_Rol();
        public FormMenu()
        {
            InitializeComponent();
            GestorIdioma.GetInstancia().Suscribir(this);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormGestionBitacora frm = new FormGestionBitacora();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormGestionUsuarios frm = new FormGestionUsuarios();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }



        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            bllUsuario.CerrarSesion();
            this.Hide();
            frmLogIn login = new frmLogIn();
            login.ShowDialog();

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormGestionPerfil frm = new FormGestionPerfil();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormCambiarClave frm = new FormCambiarClave();
            this.Hide();
            frm.ShowDialog();
            this.Show();

        }

        private void DeshabilitarTodosLosBotones()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            btnInicio.Enabled = false;
            btn_Funciones_DNI853.Enabled = false;
            btnGraficos_DNI853.Enabled = false;
            btn_Obras_DNI853.Enabled = false;
            btn_Ventas_DNI853.Enabled = false;
           
            button7.Enabled = false;
        }

        private bool ValidarPermisoEnArbol(Servicio_Rol componente, string idPermisoBuscado)
        {
            if (componente == null) return false;


            if (componente.IdRol == idPermisoBuscado)
                return true;


            if (componente is Servicio_Familia familia)
            {
                foreach (Servicio_Rol hijo in familia.ObtenerHijos())
                {

                    if (ValidarPermisoEnArbol(hijo, idPermisoBuscado))
                    {
                        return true;
                    }
                }
            }


            return false;
        }
        private void Bloquear(Servicio_Usuario usuarioActual)
        {
            if (usuarioActual == null || usuarioActual.Permisos == null)
            {
                DeshabilitarTodosLosBotones();
                return;
            }

            button1.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P41");
            button3.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P42");
            button2.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P43");
            button5.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P44");
            btnInicio.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "InicioMenu");
            btn_Funciones_DNI853.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P24");
            btnGraficos_DNI853.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P27");
            btn_SalasySectores_DNI853.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P26");
            btn_Promociones_DNI853.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P46");
            btn_Obras_DNI853.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P25");
            btn_Ventas_DNI853.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P23");
            btn_Clientes_DNI853.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P47");
            button7.Enabled = bllRol.ValidarPermisoEnArbol(usuarioActual.Permisos, "P36");
        }

        public void ActualizarIdioma()
        {
            string idIdioma = SessionManager.GetInstancia().GetUsuarioActual().Id_Idioma;

            BLL_Idioma bllIdioma = new BLL_Idioma();

            Servicio_Idioma idioma = bllIdioma.ObtenerIdiomaPorId(idIdioma);

            if (idioma == null)
                return;

            TraducirControles(this.Controls, idioma);

        }


        private void TraducirControles(Control.ControlCollection controles, Servicio_Idioma idioma)
        {
            foreach (Control c in controles)
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
            string idIdioma = SessionManager.GetInstancia().GetUsuarioActual().Id_Idioma;

            BLL_Idioma bllIdioma = new BLL_Idioma();

            Servicio_Idioma idioma = bllIdioma.ObtenerIdiomaPorId(idIdioma);

            if (idioma == null)
                return clave;

            var etiqueta = idioma.Etiquetas.FirstOrDefault(x => x.Clave == clave);

            return etiqueta != null ? etiqueta.Texto : clave;
        }



        private void FormMenu_Load(object sender, EventArgs e)
        {
            var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
            BLL_Rol bllRol = new BLL_Rol();
            string nombreLegibleDelRol = bllRol.ObtenerNombreRol(usuarioActual.IdRol);

            lblUsuario.Text = $"Usuario:";
            label1.Text = $"{usuarioActual.Login}-{nombreLegibleDelRol}";

            if (usuarioActual != null && usuarioActual.ModoEmergencia && usuarioActual.ErrorIntegridad != null)

            {
                //string mensaje =
                //@"ATENCIÓN

                //El sistema detectó una violación de integridad.

                //";

                string mensaje =
                TraducirTexto("Atencion") +
                Environment.NewLine + Environment.NewLine +
                TraducirTexto("ViolacionIntegridad") +
                Environment.NewLine + Environment.NewLine;

                foreach (ExcepcionIntegridad error in usuarioActual.ErrorIntegridad.Errores)
                {
                    //mensaje += $"Tabla: {error.Tabla}{Environment.NewLine}";

                    mensaje += TraducirTexto("Tabla") + ": " + error.Tabla + Environment.NewLine;

                    if (error.RegistrosModificados.Count > 0)
                    {
                        //mensaje += "Registros modificados:" + Environment.NewLine;
                        mensaje += TraducirTexto("RegistrosModificados") + Environment.NewLine;

                        foreach (string reg in error.RegistrosModificados)
                        {
                            mensaje += "- " + reg + Environment.NewLine;
                        }
                    }

                    if (error.RegistrosEliminados.Count > 0)
                    {
                        //mensaje += "Registros eliminados:" + Environment.NewLine;
                        mensaje += TraducirTexto("RegistrosEliminados") + Environment.NewLine;


                        foreach (string reg in error.RegistrosEliminados)
                        {
                            mensaje += "- " + reg + Environment.NewLine;
                        }
                    }

                    if (error.ErrorDVV)
                    {
                        //mensaje += "Error detectado en DVV de la tabla."
                        //         + Environment.NewLine;
                        mensaje += TraducirTexto("ErrorDVV") + Environment.NewLine;


                    }

                    if (error.RegistrosModificados.Count == 0 &&
                        error.RegistrosEliminados.Count == 0 &&
                        !error.ErrorDVV)
                    {
                        //mensaje += "Se detectó una alteración estructural de la tabla."
                        //         + Environment.NewLine;
                        mensaje += TraducirTexto("AlteracionEstructural") + Environment.NewLine;


                    }

                    mensaje += Environment.NewLine;
                    //mensaje += $"Detalle: {error.Message}{Environment.NewLine}";
                    mensaje += Environment.NewLine;
                }


                //                mensaje += @"  El sistema está funcionando en Modo Emergencia.



                //                Revise la base de datos antes de continuar.";

                ////             mensaje +=
                // @"
                ////                // El sistema está funcionando en Modo Emergencia.

                // Revise la base de datos antes de continuar.";

                mensaje +=
                Environment.NewLine +
                TraducirTexto("ModoEmergenciaFinal");

                //MessageBox.Show(
                //    mensaje,
                //    "Modo Emergencia",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Warning);


                MessageBox.Show(mensaje, TraducirTexto("ModoEmergencia"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                usuarioActual.ErrorIntegridad = null;
                SessionManager.GetInstancia().SetUsuarioActual(usuarioActual);
            }




            Bloquear(usuarioActual);
            ActualizarIdioma();
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorIdioma.GetInstancia().Desuscribir(this);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormGestionIdioma frm = new FormGestionIdioma();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void lblBD_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)//cambiar idioma
        {
            FormConfiguracion frm = new FormConfiguracion();
            frm.ShowDialog();
        }


        private void panelUsuario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormGestionRespaldo frm = new FormGestionRespaldo();
            frm.ShowDialog();
        }

        private void panelMovimientos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)//boton de ayuda
        {
            string ruta = Path.Combine(Application.StartupPath, "Manual_de_Usuario_e_Instalacion.pdf");

            if (File.Exists(ruta))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = ruta,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show(
                    TraducirTexto("err_ManualNoEncontrado"),
                    TraducirTexto("Ayuda"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btn_Ventas_DNI853_Click(object sender, EventArgs e)
        {
            FormGestionVentaEntradas_DNI853 frm = new FormGestionVentaEntradas_DNI853();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnGraficos_DNI853_Click(object sender, EventArgs e)
        {

        }

        private void btn_Obras_DNI853_Click(object sender, EventArgs e)
        {
            FormGestionObrasDNI853 frm = new FormGestionObrasDNI853();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btn_SalasySectores_DNI853_Click(object sender, EventArgs e)
        {
            FormGestionSalasySectores_DNI853 frm = new FormGestionSalasySectores_DNI853();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btn_Funciones_DNI853_Click(object sender, EventArgs e)
        {
            FormGestionFunciones_DNI853 frm = new FormGestionFunciones_DNI853();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btn_Promociones_DNI853_Click(object sender, EventArgs e)
        {
            FormGestionPromocion_DNI853 frm = new FormGestionPromocion_DNI853();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btn_Clientes_DNI853_Click(object sender, EventArgs e)
        {
            FormGestionClientes_DNI853 frm = new FormGestionClientes_DNI853();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}

