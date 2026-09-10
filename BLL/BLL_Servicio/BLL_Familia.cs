using DAL;
using Microsoft.Data.SqlClient;
using Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL.BLL_Servicio
{
    public class BLL_Familia
    {

        private DAL_Familia dal;
        private BLL_BitacoraEvento bllBitacora = new BLL_BitacoraEvento();
        private DAL_Rol dalRol;
        private BLL_Permiso bllPermiso;
        private BLL_DigitoVerificador bllDV = new BLL_DigitoVerificador();

        public BLL_Familia()
        {
           dal = new DAL_Familia();
            dalRol = new DAL_Rol();
            bllPermiso = new BLL_Permiso();
        }

        public List<Servicio_Familia> ObtenerFamiliasCompletas()
        {
            List<Servicio_Familia> familiasBasicas = dal.ListarFamilias();
            List<Servicio_Familia> familiasCompletas = new List<Servicio_Familia>();

            foreach (var f in familiasBasicas)
            {
                familiasCompletas.Add(this.ObtenerFamiliaCompleta(f.IdRol));
            }

            return familiasCompletas;
        }
        public void Guardar(Servicio_Familia familia, List<string> itemsAsignadosIniciales)
        {
            if (string.IsNullOrWhiteSpace(familia.Nombre))
                throw new Exception("err_NombreFamiliaObligatorio");

            if (dal.ExisteNombre(familia.Nombre))
                throw new Exception("err_FamiliaNombreExistente");

            if (itemsAsignadosIniciales == null || itemsAsignadosIniciales.Count < 2)
            {
                throw new Exception("err_FamiliaSinContenido");
            }

            List<string> permisosVistos = new List<string>();

            foreach (string idItem in itemsAsignadosIniciales)
            {
                Servicio_Familia subFam = this.BuscarFamilia(idItem);

                if (subFam != null)
                {
                    Servicio_Familia famCompleta = this.ObtenerFamiliaCompleta(idItem);
                    List<Servicio_Permiso> permisosDeSubfamilia = ObtenerTodosLosPermisos(famCompleta);

                    foreach (Servicio_Permiso p in permisosDeSubfamilia)
                    {
                        if (permisosVistos.Contains(p.IdRol))
                        {
                            throw new Exception("err_RedundanciaPermisoFamilia|" + p.Nombre);
                        }
                        permisosVistos.Add(p.IdRol);
                    }
                }
                else
                {
                    if (permisosVistos.Contains(idItem))
                    {
                        throw new Exception("err_RedundanciaPermisoSuelto");
                    }
                    permisosVistos.Add(idItem);
                }
            }

            dal.Guardar(familia.IdRol, familia.Nombre);

            foreach (string idItem in itemsAsignadosIniciales)
            {
                if (this.BuscarFamilia(idItem) != null)
                {
                    this.AsignarSubFamilia(familia.IdRol, idItem);
                }
                else
                {
                    this.AsignarPermiso(familia.IdRol, idItem);
                }
            }

            bllBitacora.RegistrarBitacora("Alta Familia: " + familia.Nombre, SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 2);
            bllDV.ActualizarDigitos(ObtenerFamiliaCompleta(familia.IdRol), this.ObtenerFamiliasCompletas(), "Familia");
        }

        private void CargarHijosRecursivo(Servicio_Familia familia)
        {
            List<Servicio_Familia> subFamilias = dal.ObtenerSubFamilias(familia.IdRol);

            if (subFamilias != null)
            {
                foreach (Servicio_Familia hija in subFamilias)
                {
                    familia.AgregarRol(hija);
                    CargarHijosRecursivo(hija);
                }
            }

            List<Servicio_Permiso> permisos = bllPermiso.ObtenerPermisosPorFamilia(familia.IdRol);

            if (permisos != null)
            {
                foreach (Servicio_Permiso permiso in permisos)
                {
                    familia.AgregarRol(permiso);
                }
            }
        }

        public void Modificar(Servicio_Familia familia)
        {
            if (string.IsNullOrWhiteSpace(familia.Nombre))
            {
                throw new Exception("err_NombreFamiliaObligatorio");
            }

            dal.Modificar(familia);
            bllBitacora.RegistrarBitacora("Modificación Familia: " + familia.Nombre, SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 2);
            bllDV.ActualizarDigitos(ObtenerFamiliaCompleta(familia.IdRol), this.ObtenerFamiliasCompletas(), "Familia");
        }

        public void Eliminar(string idFamilia)
        {
            if (string.IsNullOrWhiteSpace(idFamilia))
                throw new Exception("err_SeleccionarFamiliaEliminar");

            List<string> usosDetectados = new List<string>();

            List<Servicio_Familia> todosLosRoles = dalRol.ListarRoles();
            foreach (var rol in todosLosRoles)
            {
                List<Servicio_Familia> familiasDelRol = dalRol.ObtenerFamiliasPorRol(rol.IdRol);
                if (familiasDelRol.Any(f => f.IdRol == idFamilia))
                {
                    usosDetectados.Add($"Rol: {rol.Nombre}");
                }
            }

            List<Servicio_Familia> todasLasFamilias = dal.ListarFamilias();
            foreach (var padre in todasLasFamilias)
            {
                if (padre.IdRol == idFamilia) continue;

                Servicio_Familia famCompleta = this.ObtenerFamiliaCompleta(padre.IdRol);
                if (BuscarFamiliaRecursiva(famCompleta, idFamilia))
                {
                    usosDetectados.Add($"Familia Padre: {padre.Nombre}");
                }
            }

            if (usosDetectados.Count > 0)
            {
                throw new Exception("err_FamiliaEnUso|" + string.Join("\n", usosDetectados.Distinct()));
                       
            }

            dal.Eliminar(idFamilia);
            bllBitacora.RegistrarBitacora("Baja Familia ID: " + idFamilia, SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 2);
            bllDV.EliminarDigitoYRecalcular(idFamilia, this.ObtenerFamiliasCompletas(), "Familia");
        }

        public void AsignarPermiso(string idFamilia, string idPermiso)
        {
            if (string.IsNullOrWhiteSpace(idFamilia)) throw new Exception("err_SeleccionarFamilia");
            if (string.IsNullOrWhiteSpace(idPermiso)) throw new Exception("err_SeleccionarPermiso");

            if (this.TienePermiso(idFamilia, idPermiso))
            {
                throw new Exception("err_PermisoFamiliaRedundante");
            }
            List<string> idsRolesAfectados = ObtenerRolesQueContienenFamilia(idFamilia);
            List<string> rolesConConflicto = new List<string>();

            foreach (string idRol in idsRolesAfectados)
            {
                if (RolTienePermiso(idRol, idPermiso))
                {
                    rolesConConflicto.Add(dalRol.ObtenerNombreRol(idRol));
                }
            }

            if (rolesConConflicto.Count > 0)
            {
                throw new Exception("err_OperacionCanceladaRedundancia|" + string.Join(", ", rolesConConflicto));
   
            }
            dal.AsignarPermiso(idFamilia, idPermiso);
            bllBitacora.RegistrarBitacora("Permiso asignado a Familia ID: " + idFamilia, SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 1);
            bllDV.ActualizarDigitos(ObtenerFamiliaCompleta(idFamilia), this.ObtenerFamiliasCompletas(), "Familia");
        }

        private List<Servicio_Permiso> ObtenerPermisosDeFamiliaRecursivo(Servicio_Familia familia)
        {
            List<Servicio_Permiso> lista = new List<Servicio_Permiso>();
            if (familia.ObtenerHijos() == null) return lista;

            foreach (var hijo in familia.ObtenerHijos())
            {
                if (hijo is Servicio_Permiso p) lista.Add(p);
                else if (hijo is Servicio_Familia f) lista.AddRange(ObtenerPermisosDeFamiliaRecursivo(f));
            }
            return lista;
        }

        private List<Servicio_Permiso> ObtenerTodosLosPermisos(Servicio_Familia familia)
        {
            List<Servicio_Permiso> listaPlana = new List<Servicio_Permiso>();

            if (familia.ObtenerHijos() != null)
            {
                foreach (Servicio_Rol hijo in familia.ObtenerHijos())
                {
                    if (hijo is Servicio_Permiso permiso)
                    {
                        listaPlana.Add(permiso);
                    }
                    else if (hijo is Servicio_Familia subFamilia)
                    {
                        listaPlana.AddRange(ObtenerTodosLosPermisos(subFamilia));
                    }
                }
            }
            return listaPlana;
        }

        public void AsignarSubFamilia(string idPadre, string idHija)
        {
            if (string.IsNullOrWhiteSpace(idPadre)) throw new Exception("err_SeleccionarFamiliaPadre");
            if (string.IsNullOrWhiteSpace(idHija)) throw new Exception("err_SeleccionarFamiliaHija");
            if (idPadre == idHija) throw new Exception("err_FamiliaNoPuedeAsignarseSiMisma");
            if (TieneFamilia(idHija, idPadre)) throw new Exception("err_CicloFamilias");

            Servicio_Familia familiaHijaCompleta = this.ObtenerFamiliaCompleta(idHija);
            List<string> permisosRedundantes = new List<string>();
            List<Servicio_Permiso> todosLosPermisosHija = ObtenerTodosLosPermisos(familiaHijaCompleta);

            if (todosLosPermisosHija != null)
            {
                foreach (Servicio_Permiso permiso in todosLosPermisosHija)
                {
                    if (this.TienePermiso(idPadre, permiso.IdRol))
                    {
                        if (!permisosRedundantes.Contains(permiso.Nombre))
                        {
                            permisosRedundantes.Add(permiso.Nombre);
                        }
                    }
                }
            }
            List<string> idsRolesAfectados = ObtenerRolesQueContienenFamilia(idPadre);
            List<string> rolesConConflicto = new List<string>();

            foreach (string idRol in idsRolesAfectados)
            {
                foreach (var permiso in todosLosPermisosHija)
                {
                    if (RolTienePermiso(idRol, permiso.IdRol))
                    {
                        string nombreRol = dalRol.ObtenerNombreRol(idRol);
                        if (!rolesConConflicto.Contains(nombreRol))
                        {
                            rolesConConflicto.Add(nombreRol);
                        }
                    }
                }
            }

            if (rolesConConflicto.Count > 0)
            {
                throw new Exception("err_AsignacionFamiliaRedundanteRoles|" +string.Join(", ", rolesConConflicto));
        
            }
            if (permisosRedundantes.Count > 0)
            {
                throw new Exception("err_PermisosRedundantesFamilia|" +string.Join(", ", permisosRedundantes));
        
            }

            dal.AsignarSubFamilia(idPadre, idHija);
            bllBitacora.RegistrarBitacora("Asignación familia a familia", SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 2);
            bllDV.ActualizarDigitos(ObtenerFamiliaCompleta(idPadre), this.ObtenerFamiliasCompletas(), "Familia");
        }

        private bool RolTienePermiso(string idRol, string idPermiso)
        {
            if (dalRol.ExistePermiso(idRol, idPermiso)) return true;

            List<Servicio_Familia> familiasDelRol = dalRol.ObtenerFamiliasPorRol(idRol);
            foreach (var fam in familiasDelRol)
            {
                Servicio_Familia famCompleta = this.ObtenerFamiliaCompleta(fam.IdRol);
                if (this.TienePermisoRecursivo(famCompleta, idPermiso)) return true;
            }
            return false;
        }

        private List<string> ObtenerRolesQueContienenFamilia(string idFamiliaBuscada)
        {
            List<string> rolesAfectados = new List<string>();
            List<Servicio_Familia> todosLosRoles = dalRol.ListarRoles();

            foreach (var rol in todosLosRoles)
            {
                List<Servicio_Familia> familiasDelRol = dalRol.ObtenerFamiliasPorRol(rol.IdRol);
                foreach (var fam in familiasDelRol)
                {
                    if (fam.IdRol == idFamiliaBuscada)
                    {
                        rolesAfectados.Add(rol.IdRol);
                        break;
                    }

                    Servicio_Familia famCompleta = this.ObtenerFamiliaCompleta(fam.IdRol);
                    if (this.BuscarFamiliaRecursiva(famCompleta, idFamiliaBuscada))
                    {
                        rolesAfectados.Add(rol.IdRol);
                        break;
                    }
                }
            }
            return rolesAfectados;
        }

        private Servicio_Familia BuscarFamilia(string idFamilia)
        {
            List<Servicio_Familia> familias = dal.ListarFamilias();
            if (familias != null)
            {
                foreach (Servicio_Familia fam in familias)
                {
                    if (fam.IdRol == idFamilia) return fam;
                }
            }
            return null;
        }

        public bool TienePermiso(string idFamilia, string idPermiso)
        {
            Servicio_Familia familia = ObtenerFamiliaCompleta(idFamilia);
            return TienePermisoRecursivo(familia, idPermiso);
        }

        public bool TieneFamilia(string idPadre, string idHija)
        {
            Servicio_Familia familia = ObtenerFamiliaCompleta(idPadre);
            return BuscarFamiliaRecursiva(familia, idHija);
        }

        private bool BuscarFamiliaRecursiva(Servicio_Familia familia, string idBuscada)
        {
            foreach (Servicio_Rol item in familia.ObtenerHijos())
            {
                if (item is Servicio_Familia sub)
                {
                    if (sub.IdRol == idBuscada) return true;
                    if (BuscarFamiliaRecursiva(sub, idBuscada)) return true;
                }
            }
            return false;
        }

        private bool TienePermisoRecursivo(Servicio_Familia familia, string idPermiso)
        {
            foreach (Servicio_Rol item in familia.ObtenerHijos())
            {
                if (item is Servicio_Permiso)
                {
                    if (item.IdRol == idPermiso) return true;
                }
                if (item is Servicio_Familia subFamilia)
                {
                    if (TienePermisoRecursivo(subFamilia, idPermiso)) return true;
                }
            }
            return false;
        }

        public Servicio_Familia ObtenerFamiliaCompleta(string idFamilia)
        {
            Servicio_Familia familia = BuscarFamilia(idFamilia);
            CargarHijosRecursivo(familia);
            return familia;
        }

        public List<Servicio_Familia> ObtenerFamilias()
        {
            return dal.ListarFamilias();
        }

        public bool ExisteNombre(string nombre)
        {
            return dal.ExisteNombre(nombre);
        }

        public void DesasignarPermiso(string idFamilia, string idPermiso)
        {
            Servicio_Familia familiaCompleta = ObtenerFamiliaCompleta(idFamilia);
            if (familiaCompleta.ObtenerHijos().Count <= 2)
                throw new Exception("err_FamiliaUnSoloElemento");

            dal.DesasignarPermiso(idFamilia, idPermiso);
            bllBitacora.RegistrarBitacora("Permiso desasignado de Familia ID: " + idFamilia, SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 2);
            bllDV.ActualizarDigitos(ObtenerFamiliaCompleta(idFamilia), this.ObtenerFamiliasCompletas(), "Familia");
        }

        public void DesasignarSubFamilia(string padre, string hija)
        {
            Servicio_Familia familiaCompleta = ObtenerFamiliaCompleta(padre);
            if (familiaCompleta.ObtenerHijos().Count <= 2)
                throw new Exception("err_FamiliaUnSoloElemento");

            dal.DesasignarSubFamilia(padre, hija);
            bllBitacora.RegistrarBitacora("Subfamilia desasignada de Familia ID: " + padre, SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 2);
            bllDV.ActualizarDigitos(ObtenerFamiliaCompleta(padre), this.ObtenerFamiliasCompletas(), "Familia");
        }


        public void ValidarIntegridadJerarquia()
        {
            List<Servicio_Familia> familias = dal.ListarFamilias();

            if (familias == null || familias.Count == 0)
                return;

            foreach (Servicio_Familia familia in familias)
            {
                ValidarJerarquiaRecursiva(
                    familia.IdRol,
                    familia.Nombre,
                    new HashSet<string>(),
                    new HashSet<string>(),
                    new HashSet<string>());
            }
        }

        private void ValidarJerarquiaRecursiva( string idFamilia, string nombreFamilia, HashSet<string> familiasEnCamino, HashSet<string> familiasEncontradas,HashSet<string> permisosEncontrados)
        {
            // CICLO

            if (familiasEnCamino.Contains(idFamilia))
            {
                throw new Exception(
                     $"err_CicloFamilia|{nombreFamilia}");
            }

        

            if (!familiasEncontradas.Add(idFamilia))
            {
                throw new Exception(
                     $"err_FamiliaRepetidaJerarquia|{nombreFamilia}");
            }

            familiasEnCamino.Add(idFamilia);

          

            List<Servicio_Permiso> permisos =
                bllPermiso.ObtenerPermisosPorFamilia(idFamilia);

            if (permisos != null)
            {
                foreach (Servicio_Permiso permiso in permisos)
                {
                    if (!permisosEncontrados.Add(permiso.IdRol))
                    {
                        throw new Exception(
                            $"err_PermisoRepetidoJerarquia|{permiso.Nombre}");
                    }
                }
            }

  

            List<Servicio_Familia> hijas =
                dal.ObtenerSubFamilias(idFamilia);

            if (hijas != null)
            {
                foreach (Servicio_Familia hija in hijas)
                {
                    ValidarJerarquiaRecursiva(
                        hija.IdRol,
                        hija.Nombre,
                        familiasEnCamino,
                        familiasEncontradas,
                        permisosEncontrados);
                }
            }

            familiasEnCamino.Remove(idFamilia);
        }

        public List<Servicio_Familia> ObtenerSubFamilias(string idFamilia)
        {
            return dal.ObtenerSubFamilias(idFamilia);
        }
    } 
}
   
    