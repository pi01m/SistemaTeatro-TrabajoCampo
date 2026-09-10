using BE;
using BLL.BLL_Servicio;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BLL_Sector_DNI853
    {
        private DAL_Sector_DNI853 objDalSector_DNI853;
        private BLL_BitacoraEvento objBitacora_DNI853;
        private BLL_DigitoVerificador objDigitoVerificador_DNI853;

        public BLL_Sector_DNI853()
        {
            objDalSector_DNI853 = new DAL_Sector_DNI853();
            objBitacora_DNI853 = new BLL_BitacoraEvento();
            objDigitoVerificador_DNI853 = new BLL_DigitoVerificador();
        }

        public List<BE_Sector_DNI853> ListarSectoresPorSala_DNI853(string idSalaParam_DNI853) // Recibe string
        {
            return objDalSector_DNI853.ListarSectoresPorSala_DNI853(idSalaParam_DNI853);
        }

        public List<BE_Sector_DNI853> ListarTodosSectores_DNI853()
        {
            return objDalSector_DNI853.ListarTodosSectores_DNI853();
        }

        public bool CrearSector_DNI853(BE_Sector_DNI853 sectorParam_DNI853)
        {
            if (string.IsNullOrWhiteSpace(sectorParam_DNI853.NombreSector_DNI853))
                throw new Exception("err_NombreSectorObligatorio");

            if (sectorParam_DNI853.Capacidad_DNI853 <= 0)
                throw new Exception("err_CapacidadSectorInvalida");

            // Si el ID es string y no viene asignado, lo generamos automáticamente
            if (string.IsNullOrEmpty(sectorParam_DNI853.IdSector_DNI853))
            {
                sectorParam_DNI853.IdSector_DNI853 = "SEC_" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            }

            bool resultado_DNI853 = objDalSector_DNI853.InsertarSector_DNI853(sectorParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                List<BE_Sector_DNI853> listaCompleta_DNI853 = this.ListarTodosSectores_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(sectorParam_DNI853, listaCompleta_DNI853, "Sector_DNI853");

                objBitacora_DNI853.RegistrarBitacora(
                    "Alta de Sector",
                    loginActual_DNI853,
                    "Gestión Sectores",
                    2);
            }

            return resultado_DNI853;
        }

        public bool ModificarSector_DNI853(BE_Sector_DNI853 sectorParam_DNI853)
        {
            if (string.IsNullOrWhiteSpace(sectorParam_DNI853.NombreSector_DNI853))
                throw new Exception("err_NombreSectorObligatorio");

            bool resultado_DNI853 = objDalSector_DNI853.ActualizarSector_DNI853(sectorParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                List<BE_Sector_DNI853> listaCompleta_DNI853 = this.ListarTodosSectores_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(sectorParam_DNI853, listaCompleta_DNI853, "Sector_DNI853");

                objBitacora_DNI853.RegistrarBitacora(
                    "Modificación de Sector",
                    loginActual_DNI853,
                    "Gestión Sectores",
                    2);
            }

            return resultado_DNI853;
        }

        public bool EliminarSector_DNI853(string idSectorParam_DNI853) 
        {
            bool resultado_DNI853 = objDalSector_DNI853.EliminarSector_DNI853(idSectorParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                List<BE_Sector_DNI853> listaCompletaRestante_DNI853 = this.ListarTodosSectores_DNI853();
                objDigitoVerificador_DNI853.EliminarDigitoYRecalcular(
                    idSectorParam_DNI853,
                    listaCompletaRestante_DNI853,
                    "Sector_DNI853");

                objBitacora_DNI853.RegistrarBitacora(
                    "Baja de Sector",
                    loginActual_DNI853,
                    "Gestión Sectores",
                    3);
            }

            return resultado_DNI853;
        }
    }
}
