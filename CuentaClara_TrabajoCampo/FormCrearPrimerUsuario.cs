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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IU
{
    public partial class FormCrearPrimerUsuario : Form
    {
        public FormCrearPrimerUsuario()
        {

            InitializeComponent();

        }

        private void FormCrearPrimerUsuario_Load(object sender, EventArgs e)
        {
            txt_Login.Text = txtNombre.Text + txtDNI.Text;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Servicio_Usuario usuario = new Servicio_Usuario();
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.DNI = txtDNI.Text;
                usuario.email = txtCorreo.Text;
                usuario.Login = txtNombre.Text + txtDNI.Text;
                usuario.IdRol = "R1";
                usuario.Activo = 1;


                BLL_Usuario bll = new BLL_Usuario();

                if (bll.CrearUsuario(usuario))
                {
                    MessageBox.Show(TraducirTexto("msg_UsuarioCreadoCorrectamente"));
                    this.Close();
                }
            }
            catch (Exception ex)
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
        private string TraducirTexto(string clave)
        {
            string idIdioma = "1";

            BLL_Idioma bllIdioma = new BLL_Idioma();

            Servicio_Idioma idioma = bllIdioma.ObtenerIdiomaPorId(idIdioma);

            if (idioma == null)
                return clave;

            var etiqueta = idioma.Etiquetas.FirstOrDefault(x => x.Clave == clave);

            return etiqueta != null ? etiqueta.Texto : clave;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            txt_Login.Text = txtNombre.Text + txtDNI.Text;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txt_Login.Text = txtNombre.Text + txtDNI.Text;
        }
    }
}
