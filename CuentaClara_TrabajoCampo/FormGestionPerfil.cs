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
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IU
{
    public partial class FormGestionPerfil : Form, IObserverIdioma
    {
        private string modoActual = "";
        private string idNodoSeleccionado = "";
        private string tipoNodoSeleccionado = "";
        private string nombreNodoSeleccionado = "";


        private BLL_Familia bllFamilia;
        private BLL_Permiso bllPermiso;
        private BLL_Rol bllRol;

        public FormGestionPerfil()
        {
            InitializeComponent();
            GestorIdioma.GetInstancia().Suscribir(this);
        }
        private void RefrescarSesionUsuario()
        {
            var login = SessionManager.GetInstancia().GetUsuarioActual().Login;

            BLL_Usuario bllUsuario = new BLL_Usuario();

            var usuarioActualizado = bllUsuario.RecargarUsuarioSesion(login);

            SessionManager.GetInstancia().SetUsuarioActual(usuarioActualizado);
        }
        private void DesmarcarCheckedLists()
        {
            for (int i = 0; i < clbPermiso.Items.Count; i++) clbPermiso.SetItemChecked(i, false);
            for (int i = 0; i < clbFamilia.Items.Count; i++) clbFamilia.SetItemChecked(i, false);
        }

        private void FormGestionPerfil_Load(object sender, EventArgs e)
        {
            FormGestionPerfil_Resize(null, null);
            bllFamilia = new BLL_Familia();
            bllPermiso = new BLL_Permiso();
            bllRol = new BLL_Rol();

            var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
            RefrescarSesionUsuario();
            BloquearBotonesSegunPermisos();

            string nombreLegibleDelRol = bllRol.ObtenerNombreRol(usuarioActual.IdRol);
            var bllUsuario = new BLL_Usuario();



            var usuarioActualizado = bllUsuario.RecargarUsuarioSesion(SessionManager.GetInstancia().GetUsuarioActual().Login);
            SessionManager.GetInstancia().SetUsuarioActual(usuarioActualizado);

            label5.Text = $"{usuarioActual.Login} -  {nombreLegibleDelRol}";

            CargarCombos();
            MostrarArbol();
            ActualizarIdioma();

            btnAplicar.Enabled = false;
            clbFamilia.Enabled = false;
            clbPermiso.Enabled = false;
            cmbFamiliaHija.Enabled = false;
            cmbFamilia.Enabled = false;
            radioBtn_Rol.Enabled = false;
            radioBtn_Familia.Enabled = false;
        }
        private void DeshabilitarBotones()
        {

            btnCrear.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            btnAsignarPermiso.Enabled = false;
            btnAsignarFamilia.Enabled = false;
            button1.Enabled = false;
            btnAplicar.Enabled = false;

            btnSalir.Enabled = true;


            radioBtn_Rol.Enabled = false;
            radioBtn_Familia.Enabled = false;


            cmbRol.Enabled = false;
            cmbFamilia.Enabled = false;
            cmbFamiliaHija.Enabled = false;

            clbPermiso.Enabled = false;
            clbFamilia.Enabled = false;


            treeView1.Enabled = false;
            treeViewVistaPrevia.Enabled = false;


            DesmarcarCheckedLists();

            modoActual = "";
            idNodoSeleccionado = "";
            tipoNodoSeleccionado = "";
            nombreNodoSeleccionado = "";
        }

        private void BloquearBotonesSegunPermisos()
        {
            var usuario = SessionManager.GetInstancia().GetUsuarioActual();

            if (usuario == null || usuario.Permisos == null)
            {
                DeshabilitarBotones();
                return;
            }

            BLL_Rol bllRol = new BLL_Rol();
            bool Tiene(string p) => bllRol.ValidarPermisoEnArbol(usuario.Permisos, p);

            bool seleccionoRolOFamilia =
                radioBtn_Rol.Checked || radioBtn_Familia.Checked;

            bool enModoAsignacion =
                modoActual == "ASIGNAR_PERMISO" || modoActual == "ASIGNAR_FAMILIA";

            bool enModoEdicion =
                modoActual == "CREAR" ||
                modoActual == "MODIFICAR" ||
                modoActual == "ELIMINAR" ||
                modoActual == "DESASIGNAR";



            btnCrear.Enabled =
                Tiene("Rol_Crear") || Tiene("Familia_Crear");

            btnModificar.Enabled =
                Tiene("Rol_Modificar") || Tiene("Familia_Modificar");

            btnEliminar.Enabled =
                Tiene("Rol_Eliminar") || Tiene("Familia_Eliminar");

            btnAsignarPermiso.Enabled =
                (Tiene("Rol_AsignarPermiso") || Tiene("Familia_AsignarPermiso"))
                && !enModoEdicion;

            btnAsignarFamilia.Enabled =
                (Tiene("Rol_AsignarFamilia") || Tiene("Familia_AsignarFamilia"))
                && !enModoEdicion;

            button1.Enabled =
                (Tiene("Rol_DesasignarPermiso") ||
                 Tiene("Familia_DesasignarPermiso") ||
                 Tiene("Rol_DesasignarFamilia") ||
                 Tiene("Familia_DesasignarFamilia"))
                && !enModoEdicion;



            btnAplicar.Enabled =
                enModoEdicion || enModoAsignacion;



            radioBtn_Rol.Enabled = enModoEdicion || enModoAsignacion;
            radioBtn_Familia.Enabled = enModoEdicion || enModoAsignacion;



            cmbRol.Enabled = (modoActual == "ASIGNAR_PERMISO" && radioBtn_Rol.Checked);
            cmbFamilia.Enabled = radioBtn_Familia.Checked &&
                                 (modoActual == "ASIGNAR_FAMILIA" || modoActual == "CREAR");

            cmbFamiliaHija.Enabled = modoActual == "ASIGNAR_FAMILIA" && radioBtn_Familia.Checked;

            clbPermiso.Enabled =
                modoActual == "CREAR" ||
                modoActual == "ASIGNAR_PERMISO" ||
                (modoActual == "ASIGNAR_FAMILIA" && radioBtn_Familia.Checked);

            clbFamilia.Enabled =
                modoActual == "CREAR" ||
                modoActual == "ASIGNAR_FAMILIA" ||
                (modoActual == "ASIGNAR_PERMISO" && radioBtn_Rol.Checked);
        }
        private void CargarCombos()
        {

            clbPermiso.DataSource = null;
            clbPermiso.Items.Clear();
            clbPermiso.DataSource = bllPermiso.ListarPermisos();
            clbPermiso.DisplayMember = "Nombre";
            clbPermiso.ValueMember = "IdRol";

            List<Servicio_Familia> familias = bllFamilia.ObtenerFamilias();


            clbFamilia.DataSource = null;
            clbFamilia.Items.Clear();
            clbFamilia.DataSource = new List<Servicio_Familia>(familias);
            clbFamilia.DisplayMember = "Nombre";
            clbFamilia.ValueMember = "IdRol";

            cmbFamiliaHija.DataSource = null;
            cmbFamiliaHija.DataSource = new List<Servicio_Familia>(familias);
            cmbFamiliaHija.DisplayMember = "Nombre";
            cmbFamiliaHija.ValueMember = "IdRol";

            cmbFamilia.DataSource = null;
            cmbFamilia.DataSource = new List<Servicio_Familia>(familias);
            cmbFamilia.DisplayMember = "Nombre";
            cmbFamilia.ValueMember = "IdRol";

            List<Servicio_Familia> roles = bllRol.ObtenerRoles();
            cmbRol.DataSource = null;
            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "IdRol";
        }

        private void MostrarVistaPreviaFamilia(string idFamilia)
        {
            treeViewVistaPrevia.Nodes.Clear();

            if (string.IsNullOrEmpty(idFamilia)) return;

            try
            {

                Servicio_Familia familiaCompleta = bllFamilia.ObtenerFamiliaCompleta(idFamilia);

                if (familiaCompleta != null)
                {

                    TreeNode nodoRaiz = new TreeNode("[F] " + familiaCompleta.Nombre);
                    treeViewVistaPrevia.Nodes.Add(nodoRaiz);


                    DibujarComposite(nodoRaiz, familiaCompleta);

                    treeViewVistaPrevia.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                string mensaje = TraducirExcepcion(ex);
                MessageBox.Show(TraducirTexto("msg_ErrorVistaPrevia") +mensaje);

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
        private void DibujarComposite(TreeNode nodoPadre, Servicio_Familia familiaArmada)
        {
            if (familiaArmada != null && familiaArmada.ObtenerHijos() != null)
            {
                foreach (Servicio_Rol item in familiaArmada.ObtenerHijos())
                {
                    string prefijo = (item is Servicio_Familia) ? "[F] " : "[P] ";
                    TreeNode nodoHijo = new TreeNode(prefijo + item.Nombre);
                    nodoHijo.Tag = item.IdRol;

                    nodoPadre.Nodes.Add(nodoHijo);

                    if (item is Servicio_Familia subFamilia)
                    {
                        DibujarComposite(nodoHijo, subFamilia);
                    }
                }
            }
        }


        private void MostrarArbol()
        {
            treeView1.Nodes.Clear();

            List<Servicio_Familia> listaRoles = bllRol.ObtenerRoles();

            if (listaRoles != null)
            {
                foreach (Servicio_Familia rol in listaRoles)
                {
                    string idRol = rol.IdRol;
                    string nombreRol = rol.Nombre;

                    TreeNode nodoRol = new TreeNode("[ROL] " + nombreRol);
                    nodoRol.Tag = idRol;
                    treeView1.Nodes.Add(nodoRol);

                    List<Servicio_Familia> familiasDelRol = bllRol.ObtenerFamiliasPorRol(idRol);
                    if (familiasDelRol != null)
                    {
                        foreach (Servicio_Familia fam in familiasDelRol)
                        {
                            string idFam = fam.IdRol;
                            string nombreFam = fam.Nombre;

                            TreeNode nodoFam = new TreeNode("[F] " + nombreFam);
                            nodoFam.Tag = idFam;
                            nodoRol.Nodes.Add(nodoFam);

                            Servicio_Familia familiaCompleta = bllFamilia.ObtenerFamiliaCompleta(idFam);
                            if (familiaCompleta != null)
                            {
                                DibujarComposite(nodoFam, familiaCompleta);
                            }
                        }
                    }

                    List<Servicio_Permiso> permisosRol = bllPermiso.ObtenerPermisosPorRol(idRol);
                    if (permisosRol != null)
                    {
                        foreach (Servicio_Permiso perm in permisosRol)
                        {
                            string idPermiso = perm.IdRol;
                            string nombrePermiso = perm.Nombre;

                            TreeNode nodoPermiso = new TreeNode("[P] " + nombrePermiso);
                            nodoPermiso.Tag = idPermiso;
                            nodoRol.Nodes.Add(nodoPermiso);
                        }
                    }
                }
            }

            treeView1.ExpandAll();

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                idNodoSeleccionado = e.Node.Tag.ToString();
                string textoNodo = e.Node.Text;

                nombreNodoSeleccionado = textoNodo.Replace("[ROL] ", "").Replace("[F] ", "").Replace("[P] ", "");

                if (textoNodo.StartsWith("[ROL]"))
                {
                    tipoNodoSeleccionado = "ROL";
                }
                else if (textoNodo.StartsWith("[F]"))
                {
                    tipoNodoSeleccionado = "FAMILIA";
                }
                else if (textoNodo.StartsWith("[P]"))
                {
                    tipoNodoSeleccionado = "PERMISO";
                }
            }
        }
        private string ObtenerIdRolDesdeArbol()
        {
            if (treeView1.SelectedNode == null) return null;

            TreeNode nodo = treeView1.SelectedNode;


            while (nodo.Parent != null)
            {
                nodo = nodo.Parent;
            }


            if (nodo.Text.StartsWith("[ROL]"))
            {
                return nodo.Tag.ToString();
            }

            return null;
        }
        private void AsignarFamilia()
        {
            try
            {


                if (radioBtn_Rol.Checked) //Asignar Familia a ROL
                {

                    if (clbFamilia.CheckedItems.Count == 0)
                    {
                        //MessageBox.Show("Seleccione al menos una familia de la lista.");
                        MessageBox.Show(TraducirTexto("msg_SeleccioneFamilia"));
                        return;
                    }

                    BLL_Rol bllRol = new BLL_Rol();
                    string idRol = cmbRol.SelectedValue.ToString();

                    foreach (Servicio_Familia item in clbFamilia.CheckedItems)
                    {
                        string idFamilia = item.IdRol;
                        if (bllRol.ExisteRedundanciaPermisos(idRol, idFamilia))
                        {
                            MessageBox.Show(TraducirTexto("msg_ErrorIntegridadFamiliaPermisos"),
                                           TraducirTexto("msg_RedundanciaDetectada"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Saltamos este elemento
                        }
                        string nombreFamilia = item.Nombre;

                        string conflictos = bllRol.VerificarRedundanciasRol(idRol, idFamilia);
                        bool limpiar = false;

                        if (!string.IsNullOrEmpty(conflictos))
                        {
                            DialogResult r = MessageBox.Show(string.Format(TraducirTexto("msg_FamiliaContienePermisos"), nombreFamilia, conflictos), TraducirTexto("msg_ConflictoPermisos"), MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                            if (r == DialogResult.Yes)
                            {
                                limpiar = true;
                            }
                            else
                            {
                                continue;
                            }

                        }
                        bllRol.AsignarFamiliaARol(idRol, idFamilia, limpiar);
                    }


                    MessageBox.Show(TraducirTexto("msg_FamiliasAsignadasRol"));
                    LimpiarModo();
                }
                else if (radioBtn_Familia.Checked)
                {
                    if (cmbFamilia.SelectedValue == null || cmbFamiliaHija.SelectedValue == null)
                    {
                        MessageBox.Show(TraducirTexto("msg_SeleccioneFamiliaPadreHija"));
                        return;
                    }
                    BLL_Familia bllFamilia = new BLL_Familia();
                    string idPadre = cmbFamilia.SelectedValue.ToString();
                    string idHija = cmbFamiliaHija.SelectedValue.ToString();

                    if (idPadre == idHija)
                    {
                        MessageBox.Show(TraducirTexto("msg_FamiliaNoPuedeAsignarseMisma"));
                        return;
                    }

                    // Validación de redundancia antes de asignar
                    if (bllFamilia.TieneFamilia(idPadre, idHija))
                    {
                        MessageBox.Show(TraducirTexto("msg_RelacionFamiliasYaExisteOCiclo"));
                        return;
                    }

                    bllFamilia.AsignarSubFamilia(idPadre, idHija);
                    MessageBox.Show(TraducirTexto("msg_FamiliaAsignadaCorrectamente"));
                    LimpiarModo();
                    //// 2. Buscamos el contexto del Rol (el padre de toda la jerarquía)
                    //string idRolContexto = ObtenerIdRolDesdeArbol();

                    //if (string.IsNullOrEmpty(idRolContexto))
                    //{
                    //    MessageBox.Show("Por favor, seleccione un nodo dentro de un Rol en el árbol.");
                    //    return;
                    //}

                    //// 3. VALIDAMOS ANTES DE HACER NADA EN LA BASE DE DATOS
                    //BLL_Rol bllRolValidacion = new BLL_Rol();
                    //if (bllRolValidacion.EsRedundanteAsignar(idRolContexto, idHija))
                    //{
                    //    MessageBox.Show("Error: La familia ya existe en la jerarquía de este perfil.",
                    //                    "Error de integridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    //bllFamilia.AsignarSubFamilia(idPadre, idHija);

                    //MessageBox.Show(TraducirTexto("msg_FamiliaAsignadaCorrectamente"));
                    //LimpiarModo();
                }
                else
                {

                    MessageBox.Show(TraducirTexto("msg_SeleccioneRolOFamilia"));
                }
            }
            catch (Exception ex)
            {
                string mensaje = TraducirExcepcion(ex);
                MessageBox.Show(mensaje);
            }
        }

        private void AsignarPermiso()
        {
            try
            {
                if (clbPermiso.CheckedItems.Count == 0)
                {

                    MessageBox.Show(TraducirTexto("msg_SeleccionePermiso"));
                    return;
                }
                if (radioBtn_Rol.Checked)
                {
                    string idRol = cmbRol.SelectedValue.ToString();
                    BLL_Rol bllRol = new BLL_Rol();

                    int asignados = 0;
                    foreach (Servicio_Permiso item in clbPermiso.CheckedItems)
                    {
                        string idPermiso = item.IdRol;

                        if (!bllRol.RolTienePermisoRecursivo(idRol, idPermiso))
                        {
                            bllRol.AsignarPermiso(idRol, idPermiso);
                            asignados++;
                        }
                        else
                        {
                            MessageBox.Show(string.Format(TraducirTexto("msg_RolYaPoseePermiso"), item.Nombre));
                        }

                    }

                    if (asignados > 0)
                    {

                        MessageBox.Show(string.Format(TraducirTexto("msg_PermisosAsignadosCorrectamente"), asignados));

                    }

                    LimpiarModo();

                }
                else if (radioBtn_Familia.Checked)
                {
                    string idFamilia = cmbFamilia.SelectedValue.ToString();

                    BLL_Familia bllFamilia = new BLL_Familia();
                    int asignados = 0;

                    foreach (Servicio_Permiso item in clbPermiso.CheckedItems)
                    {
                        string idPermiso = item.IdRol;

                        if (!bllFamilia.TienePermiso(idFamilia, idPermiso))
                        {
                            bllFamilia.AsignarPermiso(idFamilia, idPermiso);
                            asignados++;
                        }
                        else
                        {
                            MessageBox.Show(string.Format(
                                TraducirTexto("msg_FamiliaYaPoseePermiso"),
                                item.Nombre));
                        }
                    }


                    MessageBox.Show(TraducirTexto("msg_PermisoAsignadoCorrectamente"));
                    LimpiarModo();
                }
                else
                {

                    MessageBox.Show(TraducirTexto("msg_SeleccioneRolOFamilia"));
                }
            }
            catch (Exception ex)
            {
                string mensaje = TraducirExcepcion(ex);
                MessageBox.Show(mensaje);
            }
        }

        private void ModificarFamilia()
        {
            try
            {
                if (clbFamilia.CheckedItems.Count == 0)
                {
                    MessageBox.Show(TraducirTexto("msg_SeleccioneFamiliaModificar"));
                    return;
                }
                if (clbFamilia.CheckedItems.Count > 1)
                {
                    MessageBox.Show(TraducirTexto("msg_SoloUnaFamiliaModificar"));
                    return;
                }

                Servicio_Familia familiaSeleccionada = (Servicio_Familia)clbFamilia.CheckedItems[0];
                string idFamilia = familiaSeleccionada.IdRol;
                string nombreActual = familiaSeleccionada.Nombre;

                //string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nuevo nombre", "Modificar Familia", nombreActual);
                string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(TraducirTexto("msg_IngreseNuevoNombre"), TraducirTexto("msg_ModificarFamilia"), nombreActual);

                if (string.IsNullOrWhiteSpace(nuevoNombre)) return;

                BLL_Familia bllFamilia = new BLL_Familia();

                if (bllFamilia.ExisteNombre(nuevoNombre))
                {
                    //MessageBox.Show("Ya existe una familia con ese nombre.");
                    MessageBox.Show(TraducirTexto("msg_FamiliaYaExiste"));
                    return;
                }

                Servicio_Familia familia = new Servicio_Familia(idFamilia, nuevoNombre);
                bllFamilia.Modificar(familia);


                MessageBox.Show(TraducirTexto("msg_FamiliaModificadaCorrectamente"));
                LimpiarModo();
            }
            catch (Exception ex)
            {
                string mensaje = TraducirExcepcion(ex);
                MessageBox.Show(mensaje);
            }
        }

    

        private void EliminarFamilia()
        {
            try
            {
                if (clbFamilia.CheckedItems.Count == 0)
                {
                    MessageBox.Show(TraducirTexto("msg_SeleccioneFamiliaModificar"));
                    return;
                }

                if (clbFamilia.CheckedItems.Count > 1)
                {
                    MessageBox.Show(TraducirTexto("msg_SoloUnaFamiliaModificar"));
                    return;
                }

                Servicio_Familia familiaAEliminar = (Servicio_Familia)clbFamilia.CheckedItems[0];

                BLL_Familia bllFamilia = new BLL_Familia();
                bllFamilia.Eliminar(familiaAEliminar.IdRol);

                MessageBox.Show(TraducirTexto("msg_FamiliaEliminadaCorrectamente"));
                LimpiarModo();
                CargarCombos();
                MostrarArbol();
            }
            catch (Exception ex)
            {
                string mensaje = TraducirExcepcion(ex);
                MessageBox.Show(mensaje, TraducirTexto("msg_ErrorEliminar"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearFamilia()
        {
            try
            {
                // 1. Validación en la Interfaz: Controlamos que haya tildado mínimo 2 elementos 
                // para no hacer trabajar a la BLL innecesariamente.
                if ((clbPermiso.CheckedItems.Count + clbFamilia.CheckedItems.Count) < 2)
                {
                    MessageBox.Show(TraducirTexto("msg_FamiliaMinComponentes"), TraducirTexto("msg_Validacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                // 2. Pedimos el nombre al usuario
                string nombre = Microsoft.VisualBasic.Interaction.InputBox(TraducirTexto("msg_IngreseNombreFamilia"), TraducirTexto("msg_NuevaFamilia"));

                if (string.IsNullOrWhiteSpace(nombre)) return;

                // 3. Ya no validamos el nombre acá, de eso se encarga la BLL. 
                // Tampoco instanciamos y guardamos la familia acá. 
                // Vamos a preparar la "caja" con todo lo que el usuario eligió.

                List<string> elementosSeleccionados = new List<string>();

                // Agregamos los IDs de los Permisos
                foreach (Servicio_Permiso perm in clbPermiso.CheckedItems)
                {
                    elementosSeleccionados.Add(perm.IdRol);
                }

                // Agregamos los IDs de las Familias (Subfamilias)
                foreach (Servicio_Familia subFam in clbFamilia.CheckedItems)
                {
                    elementosSeleccionados.Add(subFam.IdRol);
                }

                // 4. Preparamos el objeto Familia principal
                string idNuevaFamilia = Guid.NewGuid().ToString();
                Servicio_Familia familia = new Servicio_Familia(idNuevaFamilia, nombre);

                // 5. Instanciamos la BLL y le mandamos el paquete completo
                BLL_Familia bllFamilia = new BLL_Familia();

                // Llamamos al nuevo método Guardar que armamos (Familia + Lista de IDs)
                bllFamilia.Guardar(familia, elementosSeleccionados);

                // Si la BLL no arrojó ninguna Excepción, significa que TODO salió bien
                MessageBox.Show(TraducirTexto("msg_FamiliaGuardadaCorrectamente"));
                LimpiarModo();
                CargarCombos();
                MostrarArbol();
            }
            catch (Exception ex)
            {
                // Si falló el nombre, si falló la cantidad mínima en la BLL, o si hubo una 
                // redundancia no resuelta, el error salta acá y LA FAMILIA NO SE CREÓ EN LA BD.
                string mensaje = TraducirExcepcion(ex);
                MessageBox.Show(mensaje, TraducirTexto("msg_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DesasignarElemento()
        {
            try
            {
                TreeNode nodoSeleccionado = treeView1.SelectedNode;

                if (nodoSeleccionado == null)
                {
                    //MessageBox.Show("Por favor, seleccione un elemento del árbol para quitarlo.");
                    MessageBox.Show(TraducirTexto("msg_SeleccioneElementoArbolQuitar"));
                    return;
                }

                if (nodoSeleccionado.Parent == null)
                {
                    //MessageBox.Show("No se puede quitar un Rol principal desde aquí.");
                    MessageBox.Show(TraducirTexto("msg_NoQuitarRolPrincipal"));
                    return;
                }

                TreeNode nodoPadre = nodoSeleccionado.Parent;

                string idHijo = nodoSeleccionado.Tag.ToString();
                string idPadre = nodoPadre.Tag.ToString();

                string tipoHijo = nodoSeleccionado.Text.StartsWith("[F]") ? "FAMILIA" : "PERMISO";
                string tipoPadre = nodoPadre.Text.StartsWith("[ROL]") ? "ROL" : "FAMILIA";

                BLL_Rol bllRol = new BLL_Rol();
                BLL_Familia bllFamilia = new BLL_Familia();

                if (tipoPadre == "ROL" && tipoHijo == "PERMISO")
                {
                    bllRol.DesasignarPermiso(idPadre, idHijo);
                }
                else if (tipoPadre == "ROL" && tipoHijo == "FAMILIA")
                {
                    bllRol.DesasignarFamilia(idPadre, idHijo);
                }
                else if (tipoPadre == "FAMILIA" && tipoHijo == "PERMISO")
                {
                    bllFamilia.DesasignarPermiso(idPadre, idHijo);
                }
                else if (tipoPadre == "FAMILIA" && tipoHijo == "FAMILIA")
                {
                    bllFamilia.DesasignarSubFamilia(idPadre, idHijo);
                }


                MessageBox.Show(TraducirTexto("msg_ElementoDesvinculadoCorrectamente"));
                LimpiarModo();
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error al intentar desasignar: " + ex.Message);
                string mensaje = TraducirExcepcion(ex);
                MessageBox.Show(TraducirTexto("msg_ErrorDesasignar") + ": " + mensaje);
            }
        }

        private void CrearRol()
        {
            try
            {
                if (clbPermiso.CheckedItems.Count == 0 && clbFamilia.CheckedItems.Count == 0)
                {
                    MessageBox.Show(TraducirTexto("msg_RolVacioNoPermitido"), TraducirTexto("msg_Validacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }

                string nombre = Microsoft.VisualBasic.Interaction.InputBox(TraducirTexto("msg_IngreseNombreRol"), TraducirTexto("msg_NuevoRol"));
                if (string.IsNullOrWhiteSpace(nombre)) return;

                List<string> permisosSeleccionados = new List<string>();
                foreach (Servicio_Permiso perm in clbPermiso.CheckedItems)
                {
                    permisosSeleccionados.Add(perm.IdRol);
                }
                List<string> familiasSeleccionadas = new List<string>();
                foreach (Servicio_Familia fam in clbFamilia.CheckedItems)
                {
                    familiasSeleccionadas.Add(fam.IdRol);
                }
                string idNuevoPerfil = Guid.NewGuid().ToString();
                Servicio_Familia perfil = new Servicio_Familia(idNuevoPerfil, nombre);

                bllRol.CrearRol(perfil, familiasSeleccionadas, permisosSeleccionados);

                MessageBox.Show(TraducirTexto("msg_RolCreadoExito"));
                LimpiarModo();
                CargarCombos();
                MostrarArbol();
            }
            catch (Exception ex)
            {
                string mensaje = TraducirExcepcion(ex);
                MessageBox.Show(mensaje, TraducirTexto("err_ErrorCrearRol"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificarRol()
        {
            try
            {
                //if (tipoNodoSeleccionado != "ROL")
                //{
                //    //MessageBox.Show("Seleccione un Perfil [ROL]");
                //    MessageBox.Show(TraducirTexto("msg_SeleccionePerfilRol"));
                //    return;
                //}
                if (cmbRol.SelectedItem == null)
                {
                    MessageBox.Show(TraducirTexto("msg_SeleccioneRolCombo"));
                    return;
                }
                Servicio_Familia rolSeleccionado = (Servicio_Familia)cmbRol.SelectedItem;

                string idRol = rolSeleccionado.IdRol;
                string nombreActual = rolSeleccionado.Nombre;
                //string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox("Nuevo nombre del Rol", "Modificar Rol", nombreNodoSeleccionado);
                string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox(
                        TraducirTexto("msg_NuevoNombreRol"),
                        TraducirTexto("msg_ModificarRol"),
                        nombreActual
                    );

                if (string.IsNullOrWhiteSpace(nuevoNombre)) return;

                if (string.IsNullOrWhiteSpace(nuevoNombre) || nuevoNombre == nombreActual) return;

                if (nuevoNombre.ToUpper() != nombreActual.ToUpper() && bllRol.ExisteNombre(nuevoNombre))
                {
                    //MessageBox.Show("Ya existe un Rol con ese nombre. Elija otro.");
                    MessageBox.Show(TraducirTexto("msg_RolYaExisteNombre"));
                    return;
                }

                bllRol.ModificarRol(idRol, nuevoNombre);

                //MessageBox.Show("Rol modificado correctamente.");
                MessageBox.Show(TraducirTexto("msg_RolModificadoCorrectamente"));

                MostrarArbol();
                CargarCombos();
            }
            catch (Exception ex)
            {
                string mensaje = TraducirExcepcion(ex);
                MessageBox.Show(mensaje);
            }
        }

        private void EliminarPerfil()
        {
            try
            {
                if (tipoNodoSeleccionado != "ROL")
                {
                    //MessageBox.Show( "Seleccione un Perfil [ROL]");
                    MessageBox.Show(TraducirTexto("msg_SeleccionePerfilRol"));
                    return;
                }

                //DialogResult r =
                //    MessageBox.Show(
                //        "¿Eliminar perfil?",
                //        "Confirmación",
                //        MessageBoxButtons.YesNo);

                DialogResult r = MessageBox.Show(TraducirTexto("msg_EliminarPerfil"), TraducirTexto("msg_Confirmacion"), MessageBoxButtons.YesNo);

                bllRol.EliminarRol(idNodoSeleccionado);

                MessageBox.Show(TraducirTexto("msg_RolEliminadoCorrectamente"));

                //MessageBox.Show(
                //    "Perfil eliminado correctamente."); 

                MessageBox.Show(TraducirTexto("msg_PerfilEliminadoCorrectamente"));

                MostrarArbol();
                CargarCombos();
            }
            catch (Exception ex)
            {
                string mensaje = TraducirExcepcion(ex);
                MessageBox.Show(mensaje);
            }
        }


        private void btnAsignarPermiso_Click_1(object sender, EventArgs e)
        {
            modoActual = "ASIGNAR_PERMISO";
            listBox1.Items.Clear();
            //listBox1.Items.Add("1. Seleccione arriba si lo asignará a un ROL o a una FAMILIA.");
            //listBox1.Items.Add("Modo asignar permiso a...");
            listBox1.Items.Add(TraducirTexto("lst_AsignarPermisoInstruccion1"));
            listBox1.Items.Add(TraducirTexto("lst_ModoAsignarPermiso"));


            radioBtn_Rol.Enabled = true;
            radioBtn_Familia.Enabled = true;
            radioBtn_Rol.Checked = false;
            radioBtn_Familia.Checked = false;

            cmbRol.Enabled = false;
            clbFamilia.Enabled = false;
            cmbFamilia.Enabled = false;
            cmbFamiliaHija.Enabled = false;
            btnAplicar.Enabled = true;
        }

        private void btnAsignarFamilia_Click(object sender, EventArgs e)
        {
            modoActual = "ASIGNAR_FAMILIA";
            listBox1.Items.Clear();
            //listBox1.Items.Add("1. Seleccione arriba si la asignará a un ROL o a otra FAMILIA.");
            //listBox1.Items.Add("Modo asignar familia a ...");

            listBox1.Items.Add(TraducirTexto("lst_AsignarFamiliaInstruccion1"));
            listBox1.Items.Add(TraducirTexto("lst_ModoAsignarFamilia"));

            radioBtn_Rol.Enabled = true;
            radioBtn_Familia.Enabled = true;
            radioBtn_Rol.Checked = false;
            radioBtn_Familia.Checked = false;

            btnAsignarPermiso.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            button1.Enabled = false;
            clbFamilia.Enabled = true;

            cmbRol.Enabled = false;
            clbFamilia.Enabled = false;
            cmbFamiliaHija.Enabled = false;

            btnAplicar.Enabled = true;
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            modoActual = "MODIFICAR";
            listBox1.Items.Clear();
            //listBox1.Items.Add("Modo modificar FAMILIA seleccionada\n");
            //listBox1.Items.Add("1. Seleccione una Familia [F] o Rol [R] en el árbol.");
            //listBox1.Items.Add("2. Presione Aplicar.");
            //listBox1.Items.Add("3. Ingrese el nuevo nombre en la ventana emergente.");

            listBox1.Items.Add(TraducirTexto("lst_ModoModificarFamilia"));
            listBox1.Items.Add(TraducirTexto("lst_ModificarFamiliaPaso1"));
            listBox1.Items.Add(TraducirTexto("lst_ModificarFamiliaPaso2"));
            listBox1.Items.Add(TraducirTexto("lst_ModificarFamiliaPaso3"));

            radioBtn_Rol.Enabled = false;
            radioBtn_Familia.Enabled = false;
            radioBtn_Rol.Checked = true;
            radioBtn_Familia.Checked = true;

            btnAsignarFamilia.Enabled = false;
            btnAsignarPermiso.Enabled = false;
            btnEliminar.Enabled = false;
            btnCrear.Enabled = false;
            button1.Enabled = false;

            clbFamilia.Enabled = true;
            cmbRol.Enabled = false;

            cmbFamiliaHija.Enabled = false;
            btnAplicar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            modoActual = "ELIMINAR";
            listBox1.Items.Clear();

            //listBox1.Items.Add("Modo ELIMINAR FAMILIA/ROL (Baja completa)");
            //listBox1.Items.Add("1. Seleccione una Familia [F] o Rol [R] en el árbol.");
            //listBox1.Items.Add("2. Presione Aplicar para destruirla del sistema.");

            listBox1.Items.Add(TraducirTexto("lst_ModoEliminarFamiliaRol"));
            listBox1.Items.Add(TraducirTexto("lst_EliminarPaso1"));
            listBox1.Items.Add(TraducirTexto("lst_EliminarPaso2"));

            treeView1.Enabled = false;
            cmbFamilia.Enabled = false;
            cmbFamiliaHija.Enabled = false;
            cmbRol.Enabled = false;
            clbPermiso.Enabled = false;
            radioBtn_Rol.Enabled = false;
            radioBtn_Familia.Enabled = false;

            clbFamilia.Enabled = true;
            btnAplicar.Enabled = true;
            btnAplicar.Enabled = true;
        }

        private void btnCrear_Click_1(object sender, EventArgs e)
        {
            modoActual = "CREAR";
            treeView1.Enabled = false;
            listBox1.Items.Clear();
            //listBox1.Items.Add("Modo CREAR");
            //listBox1.Items.Add("1. Elegir Rol/Familia.");
            listBox1.Items.Add(TraducirTexto("lst_ModoCrear"));
            listBox1.Items.Add(TraducirTexto("lst_CrearPaso1"));

            radioBtn_Rol.Enabled = false;
            radioBtn_Familia.Enabled = false;
            radioBtn_Rol.Checked = false;
            radioBtn_Familia.Checked = false;

            btnAsignarFamilia.Enabled = false;
            btnAsignarPermiso.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            button1.Enabled = false;

            radioBtn_Rol.Enabled = true;
            radioBtn_Familia.Enabled = true;

            cmbFamiliaHija.Enabled = false;
            btnAplicar.Enabled = true;

            CargarCombos();
        }

        private void radioBtn_Rol_CheckedChanged_1(object sender, EventArgs e)
        {
            BloquearBotonesSegunPermisos();
            if (modoActual == "CREAR" && radioBtn_Rol.Checked)
            {
                listBox1.Items.Clear();
                //listBox1.Items.Add(">>> MODO: CREAR NUEVO PERFIL (ROL) <<<");
                //listBox1.Items.Add("1. Seleccione en las listas todos los Permisos y/o Familias iniciales.");
                //listBox1.Items.Add("2. Recuerde que NO puede quedar vacío (es obligatorio marcar al menos uno).");
                //listBox1.Items.Add("3. Presione el botón 'Aplicar'.");
                //listBox1.Items.Add("4. Ingrese el nombre del nuevo Perfil en la ventana emergente.");

                listBox1.Items.Add(TraducirTexto("lst_ModoCrearPerfilRolTitulo"));
                listBox1.Items.Add(TraducirTexto("lst_CrearPerfilPaso1"));
                listBox1.Items.Add(TraducirTexto("lst_CrearPerfilPaso2"));
                listBox1.Items.Add(TraducirTexto("lst_CrearPerfilPaso3"));
                listBox1.Items.Add(TraducirTexto("lst_CrearPerfilPaso4"));


                clbPermiso.Enabled = true;
                clbFamilia.Enabled = true;
                cmbFamiliaHija.Enabled = false;
                cmbRol.Enabled = false;

                DesmarcarCheckedLists();
            }
            if (modoActual == "ASIGNAR_PERMISO" && radioBtn_Rol.Checked)
            {
                listBox1.Items.Clear();
                //listBox1.Items.Add("Asignando permiso a ROL:");
                //listBox1.Items.Add("1. Elija el ROL del ComboBox.");
                //listBox1.Items.Add("2. Elija el PERMISO en la lista desplegable.");
                //listBox1.Items.Add("3. Presione Aplicar.");
                listBox1.Items.Add(TraducirTexto("lst_AsignarPermisoRolTitulo"));
                listBox1.Items.Add(TraducirTexto("lst_AsignarPermisoRolPaso1"));
                listBox1.Items.Add(TraducirTexto("lst_AsignarPermisoRolPaso2"));
                listBox1.Items.Add(TraducirTexto("lst_AsignarPermisoRolPaso3"));
                cmbRol.Enabled = true;
                clbPermiso.Enabled = true;
                clbFamilia.Enabled = false;
                cmbFamiliaHija.Enabled = false;
            }
            if (modoActual == "ASIGNAR_FAMILIA" && radioBtn_Rol.Checked)
            {
                listBox1.Items.Clear();
                //listBox1.Items.Add("Modo asignar familia a ROL");
                //listBox1.Items.Add("1. Elija el ROL del ComboBox.");
                //listBox1.Items.Add("2. Elija la FAMILIA en la lista desplegable.");
                //listBox1.Items.Add("3. Presione Aplicar.");

                listBox1.Items.Add(TraducirTexto("lst_ModoAsignarFamiliaRol"));
                listBox1.Items.Add(TraducirTexto("lst_AsignarFamiliaRolPaso1"));
                listBox1.Items.Add(TraducirTexto("lst_AsignarFamiliaRolPaso2"));
                listBox1.Items.Add(TraducirTexto("lst_AsignarFamiliaRolPaso3"));

                cmbRol.Enabled = true;
                clbFamilia.Enabled = true;
                cmbFamiliaHija.Enabled = false;

            }
            if ((modoActual == "MODIFICAR" & radioBtn_Rol.Checked))
                {
                listBox1.Items.Clear();
                //listBox1.Items.Add("Modo modificar ROL");
                //listBox1.Items.Add("1. Elija el ROL del ComboBox.");
                //listBox1.Items.Add("3. Presione Aplicar.");

                cmbRol.Enabled = true;
                btnAplicar.Enabled = true;

            }

        }

        private void radioBtn_Familia_CheckedChanged(object sender, EventArgs e)
        {
            BloquearBotonesSegunPermisos();
            if (modoActual == "CREAR" && radioBtn_Familia.Checked)
            {
                listBox1.Items.Clear();
                //listBox1.Items.Add(">>> MODO: CREAR NUEVA FAMILIA <<<");
                //listBox1.Items.Add("1. Seleccione los Permisos y/o Subfamilias que compondrán esta familia.");
                //listBox1.Items.Add("2. Es OBLIGATORIO tildar al menos un elemento.");
                //listBox1.Items.Add("3. Presione 'Aplicar' e ingrese el nombre de la Familia.");

                listBox1.Items.Add(TraducirTexto("lst_ModoCrearFamiliaTitulo"));
                listBox1.Items.Add(TraducirTexto("lst_CrearFamiliaPaso1"));
                listBox1.Items.Add(TraducirTexto("lst_CrearFamiliaPaso2"));
                listBox1.Items.Add(TraducirTexto("lst_CrearFamiliaPaso3"));

                clbPermiso.Enabled = true;
                cmbFamilia.Enabled = true;
                cmbFamiliaHija.Enabled = false;
                cmbRol.Enabled = false;

                DesmarcarCheckedLists();
            }
            if (modoActual == "ASIGNAR_PERMISO" && radioBtn_Familia.Checked)
            {
                listBox1.Items.Clear();
                //listBox1.Items.Add("Modo asignar permiso a FAMILIA");
                //listBox1.Items.Add("1. Elija la FAMILIA en la lista desplegable determinada.");
                //listBox1.Items.Add("2. Elija el PERMISO en la lista desplegable determinada.");
                //listBox1.Items.Add("3. Presione Aplicar.");

                listBox1.Items.Add(TraducirTexto("lst_ModoAsignarPermisoFamilia"));
                listBox1.Items.Add(TraducirTexto("lst_AsignarPermisoFamiliaPaso1"));
                listBox1.Items.Add(TraducirTexto("lst_AsignarPermisoFamiliaPaso2"));
                listBox1.Items.Add(TraducirTexto("lst_AsignarPermisoFamiliaPaso3"));

                clbFamilia.Enabled = true;

                cmbRol.Enabled = false;
                cmbFamiliaHija.Enabled = false;
                cmbFamilia.Enabled = true;
                clbPermiso.Enabled = true;
                clbFamilia.Enabled = false;
            }
            if (modoActual == "ASIGNAR_FAMILIA" && radioBtn_Familia.Checked)
            {
                listBox1.Items.Clear();
                //listBox1.Items.Add("Modo asignar familia a FAMILIA");
                //listBox1.Items.Add("1. Elija la Familia CONTENEDORA del ComboBox.");
                //listBox1.Items.Add("2. Elija la Familia a INSERTAR del ComboBox.");
                //listBox1.Items.Add("3. Presione Aplicar.");

                listBox1.Items.Add(TraducirTexto("lst_ModoAsignarFamiliaFamilia"));
                listBox1.Items.Add(TraducirTexto("lst_AsignarFamiliaFamiliaPaso1"));
                listBox1.Items.Add(TraducirTexto("lst_AsignarFamiliaFamiliaPaso2"));//
                listBox1.Items.Add(TraducirTexto("lst_AsignarFamiliaFamiliaPaso3"));//

                cmbFamilia.Enabled = true;
                cmbFamiliaHija.Enabled = true;
                cmbRol.Enabled = false;
                clbFamilia.Enabled = false;
                clbPermiso.Enabled = false;

            }

            if ((modoActual == "MODIFICAR" & radioBtn_Familia.Checked))
            {
                listBox1.Items.Clear();
                //listBox1.Items.Add("Modo modificar FAMILIA");
                //listBox1.Items.Add("1. Elija la FAMILIA de la lista.");
                //listBox1.Items.Add("3. Presione Aplicar.");
                listBox1.Items.Add(TraducirTexto("msg_ModoModificarFamilia"));
                listBox1.Items.Add(TraducirTexto("msg_ElijaFamiliaLista"));
                listBox1.Items.Add(TraducirTexto("msg_PresioneAplicar"));
                clbFamilia.Enabled = true;
                btnAplicar.Enabled = true;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            modoActual = "DESASIGNAR";

            listBox1.Items.Clear();
            //listBox1.Items.Add("Modo DESASIGNAR seleccionado");
            //listBox1.Items.Add("1. Seleccione un [P] o [F] del árbol.");
            //listBox1.Items.Add("2. Presione Aplicar para quitarlo.");

            listBox1.Items.Add(TraducirTexto("lst_ModoDesasignarSeleccionado"));
            listBox1.Items.Add(TraducirTexto("lst_DesasignarPaso1"));
            listBox1.Items.Add(TraducirTexto("lst_DesasignarPaso2"));

            radioBtn_Rol.Enabled = false;
            radioBtn_Familia.Enabled = false;
            radioBtn_Rol.Checked = false;
            radioBtn_Familia.Checked = false;
            btnAsignarFamilia.Enabled = false;
            btnAsignarPermiso.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            cmbRol.Enabled = false;
            clbFamilia.Enabled = false;

            cmbFamiliaHija.Enabled = false;


            btnAplicar.Enabled = true;
        }
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (modoActual)
                {
                    case "CREAR":
                        if (radioBtn_Rol.Checked)
                            CrearRol();
                        else
                            CrearFamilia();
                        break;
                    case "MODIFICAR":
                        if (radioBtn_Rol.Checked) ModificarRol();
                        else ModificarFamilia();
                        
                        break;
                    case "ELIMINAR":
                        if (tipoNodoSeleccionado == "ROL")
                            EliminarPerfil();
                        else
                            EliminarFamilia();
                        break;
                    case "ASIGNAR_PERMISO":
                        AsignarPermiso();
                        break;
                    case "ASIGNAR_FAMILIA":
                        AsignarFamilia();
                        break;
                    case "DESASIGNAR":
                        DesasignarElemento();
                        break;
                }
            }
            catch (Exception ex)
            {
                string mensaje = TraducirExcepcion(ex);
                MessageBox.Show(mensaje);
            }

            CargarCombos();
            MostrarArbol();
        }
        private void LimpiarModo()
        {
            modoActual = "";

            idNodoSeleccionado = "";
            tipoNodoSeleccionado = "";
            nombreNodoSeleccionado = "";

            listBox1.Items.Clear();
            radioBtn_Rol.Enabled = false;
            radioBtn_Familia.Enabled = false;
            radioBtn_Rol.Checked = false;
            radioBtn_Familia.Checked = false;
            clbPermiso.Enabled = false;
            clbFamilia.Enabled = false;
            DesmarcarCheckedLists();
            cmbRol.Enabled = false;
            btnCrear.Enabled = true;
            cmbFamiliaHija.Enabled = false;
            btnAsignarFamilia.Enabled = true;
            btnAsignarPermiso.Enabled = true;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            button1.Enabled = true;
            btnAplicar.Enabled = false;
            treeView1.SelectedNode = null;
            treeViewVistaPrevia.Nodes.Clear();
            treeView1.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarModo();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clbFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbFamilia.SelectedItem is Servicio_Familia familiaSeleccionada)
            {

                string idFam = familiaSeleccionada.IdRol;

                MostrarVistaPreviaFamilia(idFam);
            }
        }

        private void FormGestionPerfil_FormClosed(object sender, FormClosedEventArgs e)
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
        private void FormGestionPerfil_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                return;

            int altoDisponible = ClientSize.Height - panelInferior.Height;

            panel1.Location = new Point(
                (ClientSize.Width - panel1.Width) / 2,
                (altoDisponible - panel1.Height) / 2
            );
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
