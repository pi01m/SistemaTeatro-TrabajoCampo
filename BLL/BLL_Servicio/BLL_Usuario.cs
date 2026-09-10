using DAL;
using Microsoft.IdentityModel.Protocols;
using Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
namespace BLL.BLL_Servicio
{
    public class BLL_Usuario
    {
        private readonly BLL_BitacoraEvento _bitacoraServicio;
        private readonly DAL_Usuario _dalUsuario;
        private readonly DAL_Familia _dalFamiliaPermiso;
        private readonly Servicio_Cripto _encriptadorServicio;
        private readonly SessionManager _sm;
        private readonly BLL_DigitoVerificador _bllDV;

        public BLL_Usuario()
        {
            _dalUsuario = new DAL_Usuario();

            _encriptadorServicio = new Servicio_Cripto();

            _bitacoraServicio = new BLL_BitacoraEvento();
            _bllDV = new BLL_DigitoVerificador();



            _sm = SessionManager.GetInstancia();
        }
        public bool ExisteAlgunaCuenta()
        {
            
            return _dalUsuario.HayUsuariosRegistrados();
        }
        private void ValidarDatosBasicos(string dni, string nombre, string apellido, string email)
        {

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
                throw new Exception("err_NombreApellidoObligatorios");
             

            if (!Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$") || !Regex.IsMatch(apellido, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
                throw new Exception("err_NombreApellidoSoloLetras");


            if (string.IsNullOrWhiteSpace(dni) || !Regex.IsMatch(dni, @"^\d{8}$"))
                throw new Exception("err_DniFormatoInvalido");


            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new Exception("err_EmailFormatoInvalido");
        }
        public List<Servicio_Usuario> ListarUsuarios()
        {
            return _dalUsuario.ListarUsuarios();
        }
        public DataTable ListarUsuariosActivos()
        {
            return _dalUsuario.ListarUsuariosActivos();
        }

        public void AsignarPermisos(List<Servicio_Rol> permisos, Servicio_Usuario usuario) {
            foreach (Servicio_Rol permiso in permisos)
            {
                usuario.Permisos.AgregarRol(permiso);
            }
        }

        public bool CargarCredenciales(string nombreUsuario, string contraseña) {

            string hash = _encriptadorServicio.CalcularHash(contraseña);
            return IniciarSesion(nombreUsuario, hash);
        }

        public bool CompararHash(string hashIngresado, string hashBD) {

            return string.Equals(hashIngresado, hashBD, StringComparison.OrdinalIgnoreCase);
        }

        public bool IncrementarIntentos(string login)
        {
            try
            {
               _dalUsuario.IncrementarIntentos(login);
 
                Servicio_Usuario usuarioActualizado = _dalUsuario.ObtenerUsuarioPorLogin(login);
                List<Servicio_Usuario> todos = _dalUsuario.ListarUsuarios();

                _bllDV.ActualizarDigitos(usuarioActualizado, todos, "Usuario");

                _bitacoraServicio.RegistrarBitacora("Login Incorrecto - DV Actualizado", login, "Seguridad", 1);
                return true;
            }
            catch (Exception ex)
            {
                // Loguea el error real para saber si falló el DAL o el DV
                return false;
            }
        }
        public bool CrearUsuario(Servicio_Usuario usuario)
    
        {
            // 1. Validaciones (Si fallan, lanzan una excepción que llega al Form)
            ValidarDatosBasicos(usuario.DNI, usuario.Nombre, usuario.Apellido, usuario.email);

            if (_dalUsuario.ExisteUsuario(usuario.Login))
                throw new Exception("err_UsuarioYaExiste"); // Clave para traducir en el Form

            if (_dalUsuario.ExisteEmail(usuario.email))
                throw new Exception("err_EmailYaExiste");


            string contraseñaInicial = usuario.Apellido + usuario.DNI;
            usuario.Password = _encriptadorServicio.CalcularHash(contraseñaInicial);
            usuario.Bloqueo = 0;

            // 2. Intentamos guardar en la BD
            bool resultado = _dalUsuario.CrearUsuario(usuario);

            if (resultado)
            {
                // 3. ACTUALIZACIÓN DE DÍGITOS (Aquí es donde se corrige el Modo Emergencia)
                try
                {
                    List<Servicio_Usuario> todos = this.ListarUsuarios();
                    _bllDV.ActualizarDigitos(usuario, todos, "Usuario");
                    _bitacoraServicio.RegistrarBitacora("Usuario Creado", usuario.Login, "Administración", 3);
                }
                catch (Exception ex)
                {
                    // Si falla la seguridad, lanzamos un error que el usuario debe saber
                    throw new Exception("err_ErrorActualizacionDV");
                }
            }

            return resultado;

        }
        public void ReiniciarIntentos(string login)
        {
            _dalUsuario.ReiniciarIntentos(login);
        }

        public bool DesbloquearUsuario(string login)
        {
            try
            {
                this.ReiniciarIntentos(login);
                Servicio_Usuario usuarioActualizado = _dalUsuario.ObtenerUsuarioPorLogin(login);
                List<Servicio_Usuario> todos = this.ListarUsuarios();
                _bllDV.ActualizarDigitos(usuarioActualizado, todos, "Usuario");
                _bitacoraServicio.RegistrarBitacora("Usuario Desbloqueado", login, "Seguridad", 1);
                return true;
            }
            catch
            {
                return false;
            }

        }

        private bool IniciarSesion(string nombreUsuario, string hash)
        {
            try
            {
                BLL_DigitoVerificador bllDV = new BLL_DigitoVerificador();
                bllDV.ValidarTodaLaBase();
            }
            catch (ExcepcionIntegridad ex)
            {
                Servicio_Usuario usuarioAdmin = _dalUsuario.ObtenerUsuarioPorLogin(nombreUsuario);

                if (usuarioAdmin != null && usuarioAdmin.IdRol == "R1")
                {
                    usuarioAdmin.ModoEmergencia = true;
                    usuarioAdmin.ErrorIntegridad = ex;

                    usuarioAdmin = ConstruirPermisos(usuarioAdmin);

                    _sm.CrearSesion(usuarioAdmin);

                    _bitacoraServicio.RegistrarBitacora(
                        "Acceso de emergencia por violación de integridad",
                        nombreUsuario,
                        "Seguridad",
                        1);

                    return true;
                }

                _bitacoraServicio.RegistrarBitacora(
                    "Violación de integridad detectada: " + ex.Message,
                    nombreUsuario,
                    "Seguridad",
                    1);

                throw new Exception("err_SistemaMantenimiento");
            }

            Servicio_Usuario usuarioExistente = _dalUsuario.ObtenerUsuarioPorLogin(nombreUsuario);

            if (usuarioExistente == null)
            {
                // El usuario no existe. Cortamos el flujo aquí. No se descuentan intentos a nadie.
                throw new Exception("err_UsuarioNoRegistrado");
            }


            int intentos = _dalUsuario.ObtenerIntentos(nombreUsuario);

            if (intentos >= 3)
            {
                _bitacoraServicio.RegistrarBitacora(
                    "Intento de login bloqueado",
                    nombreUsuario,
                    "Seguridad",
                    1);

                throw new Exception("err_UsuarioBloqueado");
            }

            Servicio_Usuario usuario = _dalUsuario.AutenticarUsuario(nombreUsuario, hash);

            if (usuario == null)
            {
                IncrementarIntentos(nombreUsuario);

                int intentosActualizados = _dalUsuario.ObtenerIntentos(nombreUsuario);

                throw new Exception("err_IntentosRestantes| " + ( 3 - intentosActualizados)); 
                    
            }


            if (!VerificarEstadoUsuario(usuario))
            {
                _bitacoraServicio.RegistrarBitacora("Usuario bloqueado o inactivo",nombreUsuario,"Seguridad",1);

                throw new Exception("err_UsuarioInactivoBloqueado");
                    
            }

            if (string.IsNullOrWhiteSpace(usuario.IdRol))
            {
                _bitacoraServicio.RegistrarBitacora(
                    "Intento de login sin rol asignado",
                    nombreUsuario,
                    "Seguridad",
                    2);

                throw new Exception("err_UsuarioSinRol");
                   
            }


            BLL_Rol bllRol = new BLL_Rol();
            BLL_Familia bllFamilia = new BLL_Familia();
            BLL_Permiso bllPermiso = new BLL_Permiso();



            usuario.Permisos =new Servicio_Familia(usuario.IdRol,"Raíz_Permisos_" + usuario.Login);

            List<Servicio_Permiso> permisosDirectos = bllPermiso.ObtenerPermisosPorRol(usuario.IdRol);
 
            if (permisosDirectos != null)
            {
                foreach (Servicio_Permiso permiso in permisosDirectos)
                {
                    usuario.Permisos.AgregarRol(permiso);
                }
            }

            List<Servicio_Familia> familiasDelRol =bllRol.ObtenerFamiliasPorRol(usuario.IdRol);
 
            if (familiasDelRol != null)
            {
                foreach (Servicio_Familia familiaLigera in familiasDelRol)
                {

                    Servicio_Familia familiaCompleta =
                        bllFamilia.ObtenerFamiliaCompleta(familiaLigera.IdRol);


                    usuario.Permisos.AgregarRol(familiaCompleta);
                }
            }




            _sm.CrearSesion(usuario);



            _bitacoraServicio.RegistrarBitacora("Login correcto",
                
                usuario.Login,
                "Seguridad",
                1);




            return true;
        }

        private Servicio_Usuario ConstruirPermisos(Servicio_Usuario usuario)
        {
            BLL_Rol bllRol = new BLL_Rol();
            BLL_Familia bllFamilia = new BLL_Familia();
            BLL_Permiso bllPermiso = new BLL_Permiso();

            usuario.Permisos =
                new Servicio_Familia(usuario.IdRol, "Raíz_Permisos_" + usuario.Login);

            var permisos = bllPermiso.ObtenerPermisosPorRol(usuario.IdRol);
            if (permisos != null)
                foreach (var p in permisos)
                    usuario.Permisos.AgregarRol(p);

            var familias = bllRol.ObtenerFamiliasPorRol(usuario.IdRol);
            if (familias != null)
                foreach (var f in familias)
                {
                    var familiaCompleta = bllFamilia.ObtenerFamiliaCompleta(f.IdRol);
                    usuario.Permisos.AgregarRol(familiaCompleta);
                }

            return usuario;
        }

        public Servicio_Usuario RecargarUsuarioSesion(string login)
        {
            Servicio_Usuario usuario = _dalUsuario.ObtenerUsuarioPorLogin(login);

            if (usuario == null) return null;

            Servicio_Usuario usuarioSesion = _sm.GetUsuarioActual();

            if (usuarioSesion != null)
            {
                usuario.Id_Idioma = usuarioSesion.Id_Idioma;
            }

            BLL_Rol bllRol = new BLL_Rol();
            BLL_Familia bllFamilia = new BLL_Familia();
            BLL_Permiso bllPermiso = new BLL_Permiso();

            usuario.Permisos = new Servicio_Familia(usuario.IdRol, "ROOT_" + login);

            var permisos = bllPermiso.ObtenerPermisosPorRol(usuario.IdRol);
            if (permisos != null)
                foreach (var p in permisos)
                    usuario.Permisos.AgregarRol(p);

            var familias = bllRol.ObtenerFamiliasPorRol(usuario.IdRol);
            if (familias != null)
                foreach (var f in familias)
                {
                    var familiaCompleta = bllFamilia.ObtenerFamiliaCompleta(f.IdRol);
                    usuario.Permisos.AgregarRol(familiaCompleta);
                }

            return usuario;
        }


        public void CerrarSesion()
        {
            Servicio_Usuario usuario = _sm.GetUsuarioActual();

            if (usuario == null) return;

            string idiomaAnterior = _dalUsuario.ObtenerUsuarioPorLogin(usuario.Login)?.Id_Idioma;
            string idiomaActual = usuario.Id_Idioma;

            if (!string.IsNullOrEmpty(idiomaActual))
            {
                _dalUsuario.ActualizarIdiomaUsuario(usuario.Login, idiomaActual);

               
                Servicio_Usuario usuarioActualizado = _dalUsuario.ObtenerUsuarioPorLogin(usuario.Login);
                List<Servicio_Usuario> todos = this.ListarUsuarios();
                _bllDV.ActualizarDigitos(usuarioActualizado, todos, "Usuario");
            }

            
            if (!string.IsNullOrEmpty(idiomaAnterior) && idiomaAnterior != idiomaActual)
            {
                _bitacoraServicio.RegistrarBitacora("Actualización de Idioma", usuario.Login,"Administración", 3);
            }

            _bitacoraServicio.RegistrarBitacora( "Cerrar Sesión",usuario.Login,"Seguridad",1);
  
            

            _sm.CerrarSesion();
        }
        

        public int ObtenerIntentos(string login)
        {
            return _dalUsuario.ObtenerIntentos(login);
        }

        private bool VerificarEstadoUsuario(Servicio_Usuario usuario)
        {
            if (usuario.Activo != 1) return false;

            if (usuario.Bloqueo >= 3) return false;

            return true;
        }

        public Servicio_Usuario ObtenerUsuario(string dni)
        {
            return _dalUsuario.ObtenerUsuario(dni);
        }
        public Servicio_Usuario ObtenerUsuarioPorLogin(string login)
        {
            return _dalUsuario.ObtenerUsuarioPorLogin(login);
        }
        public bool CambiarEstadoUsuario(string dni, int activo)
        {
            try
            {
                
                _dalUsuario.CambiarEstadoUsuario(dni, activo);

                Servicio_Usuario usuario = _dalUsuario.ObtenerUsuario(dni);
                List<Servicio_Usuario> todos = this.ListarUsuarios();
                _bllDV.ActualizarDigitos(usuario, todos, "Usuario");
                _bitacoraServicio.RegistrarBitacora(activo == 1 ? "Activar Usuario" : "Desactivar Usuario", ObtenerUsuario(dni).Login, "Administración", 3);

                return true; 
            }
            catch
            {
                return false; 
            }

        }

        public bool ModificarUsuario(string dni,string nuevoNombre,string nuevoApellido, string nuevoEmail, string nuevoRol)
        {
           
                ValidarDatosBasicos(dni, nuevoNombre, nuevoApellido, nuevoEmail);
                Servicio_Usuario usuario = _dalUsuario.ObtenerUsuario(dni);

                if (usuario == null) throw new Exception("err_UsuarioNoEncontrado");
                if (!VerificarEstadoUsuario(usuario)) throw new Exception("err_UsuarioEstadoInvalido");

                if (_dalUsuario.ExisteEmail(nuevoEmail, dni))throw new Exception("err_EmailYaExiste");
                
                usuario.Nombre = nuevoNombre;
                usuario.Apellido = nuevoApellido;
                usuario.email = nuevoEmail;
                usuario.IdRol = nuevoRol;
                usuario.Login = nuevoNombre + dni;
                _dalUsuario.ModificarUsuario(usuario);

                Servicio_Usuario admin =_sm.GetUsuarioActual();

                List<Servicio_Usuario> todos = this.ListarUsuarios();
                _bllDV.ActualizarDigitos(usuario, todos, "Usuario");
                _bitacoraServicio.RegistrarBitacora("Usuario Modificado",admin.Login,"Administración",3);

                return true;
           
        }
      
        public DataTable ListarLogins()
        {
            return _dalUsuario.ListarLogins();
        }

        public bool CambiarClave(string claveActual, string claveNueva)
        {
            
            SessionManager session = SessionManager.GetInstancia();
            Servicio_Usuario usuarioActual = session.GetUsuarioActual();

            if (usuarioActual == null) return false;
            string hashActual = _encriptadorServicio.CalcularHash(claveActual);

            Servicio_Usuario usuarioValidado = _dalUsuario.AutenticarUsuario(usuarioActual.Login, hashActual);
            if (usuarioValidado == null)
            {
                return false; 
            }
            string nuevoHash = _encriptadorServicio.CalcularHash(claveNueva);

            bool actualizacionExitosa = _dalUsuario.ActualizarClave(usuarioActual.Login, nuevoHash);
            if (actualizacionExitosa)
            {

                Servicio_Usuario usuario = _dalUsuario.ObtenerUsuarioPorLogin(usuarioActual.Login);
                List<Servicio_Usuario> todos = this.ListarUsuarios();
                _bllDV.ActualizarDigitos(usuario, todos, "Usuario");
            }
            _bitacoraServicio.RegistrarBitacora("Cambio Clave", SessionManager.GetInstancia().GetUsuarioActual().Login, "Seguridad", 1);
            return actualizacionExitosa;
        }

        public void CambiarIdiomaEnSesion(string? idIdioma)
        {
            Servicio_Usuario usuario = _sm.GetUsuarioActual();

            if (usuario == null || string.IsNullOrEmpty(idIdioma))
                return;

            string idiomaAnterior = usuario.Id_Idioma;

            if (idiomaAnterior != idIdioma)
            {
                _bitacoraServicio.RegistrarBitacora( "Cambio de Idioma en Sesión", usuario.Login,"Administración",3);                    
               
            }

            usuario.Id_Idioma = idIdioma;

            _sm.SetUsuarioActual(usuario);

            GestorIdioma.GetInstancia().Notificar();



        }
      
    }
}
