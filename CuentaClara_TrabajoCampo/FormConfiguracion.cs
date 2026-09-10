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
    public partial class FormConfiguracion : Form, IObserverIdioma
    {
        private BLL_Usuario bllUsuario = new BLL_Usuario();

        private BLL_Idioma bllIdioma = new BLL_Idioma();
        public FormConfiguracion()
        {
            InitializeComponent();
            GestorIdioma.GetInstancia().Suscribir(this);
        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormConfiguracion_Load(object sender, EventArgs e)
        {
            cmbIdioma.DataSource = bllIdioma.ListarIdiomasBD();
            cmbIdioma.DisplayMember = "Nombre";
            cmbIdioma.ValueMember = "Id_Idioma";
            ActualizarIdioma();
        }

        private void btnGuardarr_Click(object sender, EventArgs e)
        {
            if (cmbIdioma.SelectedValue == null) return;
            string nuevoIdioma = cmbIdioma.SelectedValue.ToString();
            
            bllUsuario.CambiarIdiomaEnSesion(nuevoIdioma);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ActualizarIdioma()
        {
            string idIdioma = cmbIdioma.SelectedValue.ToString();

            BLL_Idioma bllIdioma = new BLL_Idioma();

            Servicio_Idioma idioma =
                bllIdioma.ObtenerIdiomaPorId(idIdioma);

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

        private void FormConfiguracion_FormClosed(object sender, FormClosedEventArgs e)
        {

          GestorIdioma.GetInstancia().Desuscribir(this);

        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarIdioma();
        }
    }
}
