using DAL;
using Microsoft.Data.SqlClient;
using Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL_Servicio
{
    public class BLL_Permiso
    {
        private DAL_Permiso dal;

        public BLL_Permiso()
        {
          dal = new DAL_Permiso();
        }

        public List<Servicio_Permiso> ObtenerPermisosPorFamilia(string idFamilia)
        {
            
            return dal.ObtenerPermisosPorFamilia(idFamilia);
        }
        public List<Servicio_Permiso> ObtenerPermisosPorRol(string idUsuario)
        {
            return dal.ObtenerPermisosPorRol(idUsuario);
        }
        public List<Servicio_Permiso> ListarPermisos()
        {
            return dal.ListarPermisos();
        }
    }
}
