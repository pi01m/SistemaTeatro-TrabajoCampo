using DAL;
using Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace BLL.BLL_Servicio
{
    public class BLL_BitacoraEvento
    {
        private  DAL_BitacoraEvento _dal;

        public BLL_BitacoraEvento()
        {
            _dal = new DAL_BitacoraEvento();
        }

        public void RegistrarBitacora(string evento,string login,string modulo,int criticidad){
            Servicio_Bitacora bitacora = new Servicio_Bitacora
            {
                id_Evento = Guid.NewGuid().ToString(), //aleatorioo
                Evento = evento,
                Login = login,
                Modulo = modulo,
                Criticidad = criticidad,
                Fecha = DateTime.Now.Date,
                Hora = DateTime.Now.ToString("HH:mm:ss")
            };

            bool guardadoExitoso = _dal.GuardarBitacora(bitacora);
        }

        public List<Servicio_Bitacora> ListarBitacora()
        {
            return _dal.ListarBitacora();
        }

        public List<Servicio_Bitacora> ListarUltimos3Dias()
        {
            return _dal.ListarUltimos3Dias();
        }

        public List<Servicio_Bitacora> FiltrarBitacora(string login, DateTime desde, DateTime hasta, string modulo, string evento, int? criticidad)
        {

            return _dal.FiltrarBitacora(login, desde, hasta, modulo, evento, criticidad);
        }
        public List<string> ObtenerEventosBase()
        {
            return new List<string>
        {
      
        "Login Incorrecto - DV Actualizado",
        "Usuario Creado",
        "Usuario Desbloqueado",
        "Acceso de emergencia por violación de integridad",
        "Violación de integridad detectada",
        "Intento de login bloqueado",
        "Usuario bloqueado o inactivo",
        "Intento de login sin rol asignado",
        "Login correcto",
        "Actualización de Idioma",
        "Cerrar Sesión",
        "Activar Usuario",
        "Desactivar Usuario",
        "Usuario Modificado",
        "Cambio Clave",
        "Cambio de Idioma en Sesión",

      
        "Alta Familia",
        "Modificación Familia",
        "Baja Familia",
        "Permiso asignado a Familia",
        "Asignación familia a familia",
        "Permiso desasignado de Familia",
        "Subfamilia desasignada de Familia",

       
        "Alta Perfil (Rol)",
        "Permiso asignado al Rol",
        "Asignación de familias a rol",
        "Permiso desasignado del Rol",
        "Familia desasignada del Rol",
        "Modificación de Rol",
        "Baja de Rol",

     
        "Backup exitoso",

        
        "Impresión/Exportación de Bitácora",

  
        "Recalculo de Dígitos Verificadores de Usuario",
        "Recalculo de Dígitos Verificadores de Roles",
        "Recalculo de Dígitos Verificadores de Familias",
        "Recalculo de Dígitos Verificadores de Permisos",
        "Recalculo de Dígitos Verificadores de Idiomas"
    };
        }

    }
}
