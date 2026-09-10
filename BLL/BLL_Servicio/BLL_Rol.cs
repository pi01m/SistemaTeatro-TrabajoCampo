using DAL;
using Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.BLL_Servicio
{
    public class BLL_Rol
    {
        private DAL_Rol dal;
        private BLL_BitacoraEvento bllBitacora = new BLL_BitacoraEvento();
        private BLL_DigitoVerificador bllDV = new BLL_DigitoVerificador();
        private BLL_Permiso bllPermiso = new BLL_Permiso();
        private BLL_Familia bllFamilia = new BLL_Familia();
        public BLL_Rol()
        {
            dal = new DAL_Rol();
        }
        public List<Servicio_Familia> ObtenerRolesCompletos()
        {
            List<Servicio_Familia> rolesBasicos = dal.ListarRoles();
            List<Servicio_Familia> rolesCompletos = new List<Servicio_Familia>();

            foreach (var r in rolesBasicos)
            {
                rolesCompletos.Add(this.ObtenerRolCompleto(r.IdRol));
            }

            return rolesCompletos;
        }
        public void CrearRol(Servicio_Familia rol, List<string> idFamilias, List<string> idPermisos)
        {
            if (string.IsNullOrWhiteSpace(rol.Nombre))
                throw new Exception("err_NombreFamiliaObligatorio");

            if (dal.ExisteNombre(rol.Nombre))
                throw new Exception("err_RolNombreExiste");

            int totalElementos = (idFamilias != null ? idFamilias.Count : 0) + (idPermisos != null ? idPermisos.Count : 0);
            if (totalElementos < 1)
            {
                throw new Exception("err_RolVacio");
            }

            List<string> permisosVistos = new List<string>();
            List<string> nombresRedundantes = new List<string>();
            BLL_Familia bllFam = new BLL_Familia();

            if (idFamilias != null)
            {
                foreach (string idFam in idFamilias)
                {
                    Servicio_Familia famCompleta = bllFam.ObtenerFamiliaCompleta(idFam);
                    List<Servicio_Permiso> permisosDeEstaFamilia = ObtenerPermisosDeFamiliaRecursivo(famCompleta);

                    foreach (Servicio_Permiso p in permisosDeEstaFamilia)
                    {
                        if (permisosVistos.Contains(p.IdRol))
                        {
                            if (!nombresRedundantes.Contains(p.Nombre)) nombresRedundantes.Add(p.Nombre);
                        }
                        else
                        {
                            permisosVistos.Add(p.IdRol);
                        }
                    }
                }
            }

            if (idPermisos != null)
            {
                foreach (string idPerm in idPermisos)
                {
                    if (permisosVistos.Contains(idPerm))
                    {
                        throw new Exception("err_PermisosSueltosRedundantes");
                    }
                    permisosVistos.Add(idPerm);
                }
            }

            if (nombresRedundantes.Count > 0)
            {
                throw new Exception("err_RolPermisosRedundantes|" + string.Join(", ", nombresRedundantes));
            }

            dal.CrearRol(rol.IdRol, rol.Nombre);

            if (idFamilias != null)
            {
                foreach (string idFam in idFamilias)
                {
                    this.AsignarFamiliaARol(rol.IdRol, idFam, false);
                }
            }

            if (idPermisos != null)
            {
                foreach (string idPerm in idPermisos)
                {
                    this.AsignarPermiso(rol.IdRol, idPerm);
                }
            }

            bllBitacora.RegistrarBitacora("Alta Perfil (Rol): " + rol.Nombre, SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 2);
            bllDV.ActualizarDigitos(this.ObtenerRolCompleto(rol.IdRol), this.ObtenerRolesCompletos(), "Rol");
        }

        public List<Servicio_Familia> ObtenerRoles()
        {
            return dal.ListarRoles();
        }

        public void AsignarPermiso(string idRol, string idPermiso)
        {
            if (string.IsNullOrWhiteSpace(idRol)) throw new Exception("err_SeleccioneRol");
            if (string.IsNullOrWhiteSpace(idPermiso)) throw new Exception("err_SeleccionePermiso");
            if (dal.ExistePermiso(idRol, idPermiso)) throw new Exception("err_RolYaPoseePermiso");

            dal.AsignarPermiso(idRol, idPermiso);
            bllBitacora.RegistrarBitacora("Permiso asignado al Rol ID: " + idRol, SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 2);

           
            var rolesCompletos = this.ObtenerRolesCompletos();
       
            var rolModificado = this.ObtenerRolCompleto(idRol);

            bllDV.ActualizarDigitos(rolModificado, rolesCompletos, "Rol");
        }

        public string ObtenerNombreRol(string idRol)
        {
            return dal.ObtenerNombreRol(idRol);
        }

        public bool TienePermiso(string idRol, string idPermiso)
        {
            return dal.ExistePermiso(idRol, idPermiso);
        }

        public string VerificarRedundanciasRol(string idRol, string idFamilia)
        {
            BLL_Familia bllFam = new BLL_Familia();
            Servicio_Familia familiaCompleta = bllFam.ObtenerFamiliaCompleta(idFamilia);
            List<string> redundantes = new List<string>();

            if (familiaCompleta != null && familiaCompleta.ObtenerHijos() != null)
            {
                foreach (Servicio_Rol itemHijo in familiaCompleta.ObtenerHijos())
                {
                    if (!(itemHijo is Servicio_Familia))
                    {
                        if (this.TienePermiso(idRol, itemHijo.IdRol))
                        {
                            redundantes.Add(itemHijo.Nombre);
                        }
                    }
                }
            }
            return string.Join(", ", redundantes);
        }

        public void AsignarFamiliaARol(string idRol, string idFamilia, bool limpiarRedundancias)
        {
            if (string.IsNullOrWhiteSpace(idRol)) throw new Exception("err_SeleccioneRol");
            if (string.IsNullOrWhiteSpace(idFamilia)) throw new Exception("err_SeleccioneFamilia");
            if (dal.ExisteFamilia(idRol, idFamilia)) throw new Exception("err_FamiliaYaAsignada");

            BLL_Familia bllFam = new BLL_Familia();
            Servicio_Familia familiaCompleta = bllFam.ObtenerFamiliaCompleta(idFamilia);

            List<string> permisosRedundantes = new List<string>();
            if (familiaCompleta != null && familiaCompleta.ObtenerHijos() != null)
            {
                foreach (Servicio_Rol itemHijo in familiaCompleta.ObtenerHijos())
                {
                    if (!(itemHijo is Servicio_Familia))
                    {
                        if (this.TienePermiso(idRol, itemHijo.IdRol))
                        {
                            permisosRedundantes.Add(itemHijo.Nombre);
                        }
                    }
                }
            }
            if (permisosRedundantes.Count > 0)
            {
                throw new Exception("err_FamiliaPermisosRedundantes|" + string.Join(", ", permisosRedundantes));
            }

            dal.AsignarFamilia(idRol, idFamilia);
            bllBitacora.RegistrarBitacora("Asignación de familias a rol", SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 2);

            var rolesCompletos = this.ObtenerRolesCompletos();
         
            var rolModificado = this.ObtenerRolCompleto(idRol);

            bllDV.ActualizarDigitos(rolModificado, rolesCompletos, "Rol");
        }

        public List<Servicio_Familia> ObtenerFamiliasPorRol(string idRol)
        {
            return dal.ObtenerFamiliasPorRol(idRol);
        }

        public void DesasignarPermiso(string idRol, string idPermiso)
        {
            dal.DesasignarPermiso(idRol, idPermiso);
            bllBitacora.RegistrarBitacora("Permiso desasignado del Rol ID: " + idRol, SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 2);

            var rolesCompletos = this.ObtenerRolesCompletos();
            // Obtenemos la entidad modificada completamente hidratada
            var rolModificado = this.ObtenerRolCompleto(idRol);

            bllDV.ActualizarDigitos(rolModificado, rolesCompletos, "Rol");
        }

        public void DesasignarFamilia(string idRol, string idFamilia)
        {
            dal.DesasignarFamilia(idRol, idFamilia);
            bllBitacora.RegistrarBitacora("Familia desasignada del Rol ID: " + idRol, SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 2);

            var rolesCompletos = this.ObtenerRolesCompletos();
            // Obtenemos la entidad modificada completamente hidratada
            var rolModificado = this.ObtenerRolCompleto(idRol);

            bllDV.ActualizarDigitos(rolModificado, rolesCompletos, "Rol");
        }

        public void ModificarRol(string idRol, string nombre)
        {
            if (string.IsNullOrWhiteSpace(idRol)) throw new Exception("err_SeleccioneRol");
            if (string.IsNullOrWhiteSpace(nombre)) throw new Exception("err_NombreFamiliaObligatorio");

            dal.ModificarRol(idRol, nombre);
            bllBitacora.RegistrarBitacora("Modificación de Rol: " + nombre, SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 2);

            var rolesCompletos = this.ObtenerRolesCompletos();
           
            var rolModificado = this.ObtenerRolCompleto(idRol);

            bllDV.ActualizarDigitos(rolModificado, rolesCompletos, "Rol");
        }

        public void EliminarRol(string idRol)
        {
            if (string.IsNullOrWhiteSpace(idRol)) throw new Exception("err_SeleccioneRol");

            string nombre = ObtenerNombreRol(idRol);
            dal.EliminarRelacionesRol(idRol);
            dal.EliminarRol(idRol);

            bllBitacora.RegistrarBitacora("Baja de Rol: " + nombre, SessionManager.GetInstancia().GetUsuarioActual().Login, "Gestión de Perfiles y Autorización", 2);
            bllDV.EliminarDigitoYRecalcular(idRol, this.ObtenerRolesCompletos(), "Rol");
        }

        public bool ExisteNombre(string nombre)
        {
            return dal.ExisteNombre(nombre);
        }

        public bool RolTienePermisoRecursivo(string idRol, string idPermiso)
        {
            if (TienePermiso(idRol, idPermiso)) return true;
            List<Servicio_Familia> familiasDelRol = ObtenerFamiliasPorRol(idRol);

            if (familiasDelRol != null)
            {
                BLL_Familia bllFam = new BLL_Familia();
                foreach (Servicio_Familia familia in familiasDelRol)
                {
                    Servicio_Familia famCompleta = bllFam.ObtenerFamiliaCompleta(familia.IdRol);
                    if (FamiliaContienePermiso(famCompleta, idPermiso)) return true;
                }
            }
            return false;
        }

        private bool FamiliaContienePermiso(Servicio_Familia familia, string idPermisoBuscado)
        {
            if (familia != null && familia.ObtenerHijos() != null)
            {
                foreach (Servicio_Rol hijo in familia.ObtenerHijos())
                {
                    if (hijo is Servicio_Familia subFamilia)
                    {
                        if (FamiliaContienePermiso(subFamilia, idPermisoBuscado)) return true;
                    }
                    else
                    {
                        if (hijo.IdRol == idPermisoBuscado) return true;
                    }
                }
            }
            return false;
        }

        public bool ValidarPermisoEnArbol(Servicio_Rol componente, string idPermisoBuscado)
        {
            return ValidarRecursivo(componente, idPermisoBuscado, 0);
        }

        public bool EsRedundanteAsignar(string idRol, string idFamiliaHija)
        {
            List<Servicio_Familia> familiasDelRol = dal.ObtenerFamiliasPorRol(idRol);
            BLL_Familia bllFam = new BLL_Familia();

            foreach (Servicio_Familia familiaEnRol in familiasDelRol)
            {
                if (familiaEnRol.IdRol == idFamiliaHija) return true;
                Servicio_Familia famCompleta = bllFam.ObtenerFamiliaCompleta(familiaEnRol.IdRol);
                if (FamiliaContieneFamilia(famCompleta, idFamiliaHija))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidarRecursivo(Servicio_Rol componente, string permisoBuscado, int profundidad)
        {
            if (profundidad > 10) return false;
            if (componente == null) return false;

            if (string.Equals(componente.IdRol, permisoBuscado, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(componente.Nombre, permisoBuscado, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (componente is Servicio_Familia familia)
            {
                foreach (Servicio_Rol hijo in familia.ObtenerHijos())
                {
                    if (ValidarRecursivo(hijo, permisoBuscado, profundidad + 1)) return true;
                }
            }
            return false;
        }

        private bool FamiliaContieneFamilia(Servicio_Familia familia, string idFamiliaBuscada)
        {
            if (familia != null && familia.ObtenerHijos() != null)
            {
                foreach (Servicio_Rol hijo in familia.ObtenerHijos())
                {
                    if (hijo is Servicio_Familia subFamilia)
                    {
                        if (subFamilia.IdRol == idFamiliaBuscada) return true;
                        if (FamiliaContieneFamilia(subFamilia, idFamiliaBuscada)) return true;
                    }
                }
            }
            return false;
        }

        public bool ExisteRedundanciaPermisos(string idRol, string idFamiliaNueva)
        {
            BLL_Familia bllFam = new BLL_Familia();
            Servicio_Familia familiaNueva = bllFam.ObtenerFamiliaCompleta(idFamiliaNueva);
            List<Servicio_Permiso> listaPermisos = ObtenerPermisosDeFamiliaRecursivo(familiaNueva);

            foreach (var permiso in listaPermisos)
            {
                if (this.RolTienePermisoRecursivo(idRol, permiso.IdRol))
                {
                    return true;
                }
            }
            return false;
        }

        private List<Servicio_Permiso> ObtenerPermisosDeFamiliaRecursivo(Servicio_Familia familia)
        {
            List<Servicio_Permiso> lista = new List<Servicio_Permiso>();
            if (familia.ObtenerHijos() != null)
            {
                foreach (var hijo in familia.ObtenerHijos())
                {
                    if (hijo is Servicio_Permiso p) lista.Add(p);
                    else if (hijo is Servicio_Familia f) lista.AddRange(ObtenerPermisosDeFamiliaRecursivo(f));
                }
            }
            return lista;
        }

        public void ValidarIntegridadRoles()
        {
            List<Servicio_Familia> roles = dal.ListarRoles();

            if (roles == null || roles.Count == 0)
                return;

            foreach (Servicio_Familia rol in roles)
            {
                ValidarRolRecursivo(
                    rol.IdRol,
                    rol.Nombre,
                    new HashSet<string>(),
                    new HashSet<string>());
            }
        }

        private void ValidarRolRecursivo(
      string idRol,
      string nombreRol,
      HashSet<string> familiasEncontradas,
      HashSet<string> permisosEncontrados)
        {
            // ==========================
            // PERMISOS DIRECTOS DEL ROL
            // ==========================

            List<Servicio_Permiso> permisosDirectos =
                dal.ObtenerPermisosPorRol(idRol);

            if (permisosDirectos != null)
            {
                foreach (Servicio_Permiso permiso in permisosDirectos)
                {
                    if (!permisosEncontrados.Add(permiso.IdRol))
                    {
                        throw new Exception(
                            $"err_PermisoRepetidoRol| P:{permiso.Nombre} - R:{nombreRol}");
                    }
                }
            }

            // ==========================
            // FAMILIAS DEL ROL
            // ==========================

            List<Servicio_Familia> familias =
                dal.ObtenerFamiliasPorRol(idRol);

            if (familias != null)
            {
                foreach (Servicio_Familia familia in familias)
                {
                    ValidarFamiliaDelRol(
                        familia.IdRol,
                        familia.Nombre,
                        nombreRol,
                        familiasEncontradas,
                        permisosEncontrados,
                        new HashSet<string>());
                }
            }
        }


        private void ValidarFamiliaDelRol(string idFamilia, string nombreFamilia,string nombreRol,HashSet<string> familiasEncontradas,HashSet<string> permisosEncontrados,HashSet<string> familiasEnCamino)
        {


            if (familiasEnCamino.Contains(idFamilia))
            {
                throw new Exception(
                   $"err_CicloFamiliaRol|F:{nombreFamilia},R:{nombreRol}");
            }


            if (!familiasEncontradas.Add(idFamilia))
            {
                throw new Exception(
                    $"err_FamiliaRepetidaRol|F:{nombreFamilia},R:{nombreRol}");
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
                            $"err_PermisoRepetidoRol|Permission: P:{permiso.Nombre},R:{nombreRol}");
                    }
                }
            }


            List<Servicio_Familia> hijas =
                bllFamilia.ObtenerSubFamilias(idFamilia);

            if (hijas != null)
            {
                foreach (Servicio_Familia hija in hijas)
                {
                    ValidarFamiliaDelRol(
                        hija.IdRol,
                        hija.Nombre,
                        nombreRol,
                        familiasEncontradas,
                        permisosEncontrados,
                        familiasEnCamino);
                }
            }

            familiasEnCamino.Remove(idFamilia);
        }

        public Servicio_Familia ObtenerRolCompleto(string idRol)
        {
            Servicio_Familia rol =
                this.ObtenerRoles()
                    .First(r => r.IdRol == idRol);

            // permisos directos
            foreach (var permiso in dal.ObtenerPermisosPorRol(idRol))
            {
                rol.AgregarRol(permiso);
            }

            // familias completas
            foreach (var familia in dal.ObtenerFamiliasPorRol(idRol))
            {
                rol.AgregarRol(
                    bllFamilia.ObtenerFamiliaCompleta(familia.IdRol));
            }

            return rol;
        }
    }
}