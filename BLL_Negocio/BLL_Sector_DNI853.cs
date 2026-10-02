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

        public List<BE_Sector_DNI853> ListarSectoresPorSala_DNI853(string idSalaParam_DNI853)
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

            if (string.IsNullOrWhiteSpace(sectorParam_DNI853.IdSala_DNI853))
                throw new Exception("err_DebeSeleccionarSala");

            // --- VALIDACIÓN DE CAPACIDAD MÁXIMA DE LA SALA ---
            BLL_Sala_DNI853 bllSala_DNI853 = new BLL_Sala_DNI853();
            var sala_DNI853 = bllSala_DNI853.ListarSalas_DNI853()
                .FirstOrDefault(s => s.IdSala_DNI853 == sectorParam_DNI853.IdSala_DNI853);

            if (sala_DNI853 != null)
            {
                // Obtenemos los sectores que ya están cargados en esta sala
                var sectoresActuales_DNI853 = this.ListarSectoresPorSala_DNI853(sectorParam_DNI853.IdSala_DNI853);

                // Sumamos las capacidades existentes
                int capacidadOcupada_DNI853 = sectoresActuales_DNI853.Sum(s => s.Capacidad_DNI853);

                // Verificamos si al sumar el nuevo sector se supera la capacidad de la sala
                if ((capacidadOcupada_DNI853 + sectorParam_DNI853.Capacidad_DNI853) > sala_DNI853.Capacidad_DNI853)
                {
                    // Lanza un error indicando que se supera el límite de la sala
                    throw new Exception($"err_CapacidadSalaSuperada|Capacidad máxima de la sala: {sala_DNI853.Capacidad_DNI853}. Ocupada actual: {capacidadOcupada_DNI853}.");
                }
            }
            // ------------------------------------------------

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

            if (sectorParam_DNI853.Capacidad_DNI853 <= 0)
                throw new Exception("err_CapacidadSectorInvalida");

            // --- VALIDACIÓN DE CAPACIDAD MÁXIMA EN MODIFICACIÓN ---
            BLL_Sala_DNI853 bllSala_DNI853 = new BLL_Sala_DNI853();
            var sala_DNI853 = bllSala_DNI853.ListarSalas_DNI853()
                .FirstOrDefault(s => s.IdSala_DNI853 == sectorParam_DNI853.IdSala_DNI853);

            if (sala_DNI853 != null)
            {
                // Obtenemos los sectores de la sala EXCLUYENDO el sector que estamos modificando actualmente
                var sectoresActuales_DNI853 = this.ListarSectoresPorSala_DNI853(sectorParam_DNI853.IdSala_DNI853)
                    .Where(s => s.IdSector_DNI853 != sectorParam_DNI853.IdSector_DNI853);

                int capacidadOcupada_DNI853 = sectoresActuales_DNI853.Sum(s => s.Capacidad_DNI853);

                if ((capacidadOcupada_DNI853 + sectorParam_DNI853.Capacidad_DNI853) > sala_DNI853.Capacidad_DNI853)
                {
                    throw new Exception($"err_CapacidadSalaSuperada|Capacidad máxima de la sala: {sala_DNI853.Capacidad_DNI853}.");
                }
            }
            // -----------------------------------------------------

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

        public List<BE_Sector_DNI853> ObtenerSectoresPorFuncion_DNI853(string idFuncion_DNI853)
        {
            return objDalSector_DNI853.ObtenerSectoresPorFuncion_DNI853(idFuncion_DNI853);
        }
    }
}
