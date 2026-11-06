using BE;
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL_Negocio
{
    public class BLL_Sector_C_DNI853
    {
        private DAL_Sector_C_DNI853 objDalBitacora_DNI853;
        private BLL_Sector_DNI853 objBllSector_DNI853;

        public BLL_Sector_C_DNI853()
        {
            objDalBitacora_DNI853 = new DAL_Sector_C_DNI853();
            objBllSector_DNI853 = new BLL_Sector_DNI853();
        }

        public List<BE_Sector_C_DNI853> ListarBitacora_DNI853(string codSector_DNI853, string nombre_DNI853, DateTime fechaIni_DNI853, DateTime fechaFin_DNI853)
        {
            return objDalBitacora_DNI853.ListarBitacora_DNI853(codSector_DNI853, nombre_DNI853, fechaIni_DNI853, fechaFin_DNI853);
        }

        public bool ActivarRegistroHistorico_DNI853(BE_Sector_C_DNI853 registroSeleccionado_DNI853)
        {
            if (registroSeleccionado_DNI853 == null)
                throw new Exception("err_SeleccioneRegistroBitacora");

            // Verificar si el sector existe en el maestro de sectores
            var sectoresActuales_DNI853 = objBllSector_DNI853.ListarTodosSectores_DNI853();
            bool existeEnMaestro_DNI853 = sectoresActuales_DNI853.Any(s => s.IdSector_DNI853 == registroSeleccionado_DNI853.IdSector_DNI853);

            BE_Sector_DNI853 sectorAActivar_DNI853 = new BE_Sector_DNI853
            {
                IdSector_DNI853 = registroSeleccionado_DNI853.IdSector_DNI853,
                IdSala_DNI853 = registroSeleccionado_DNI853.IdSala_DNI853,
                NombreSector_DNI853 = registroSeleccionado_DNI853.NombreSector_DNI853,
                Ubicacion_DNI853 = registroSeleccionado_DNI853.Ubicacion_DNI853,
                Capacidad_DNI853 = registroSeleccionado_DNI853.Capacidad_DNI853,
                Precio_DNI853 = registroSeleccionado_DNI853.Precio_DNI853
            };

            if (existeEnMaestro_DNI853)
            {
                // Si existe en el maestro, se actualiza al valor histórico (dispara Trigger + DV + Bitácora Eventos)
                return objBllSector_DNI853.ModificarSector_DNI853(sectorAActivar_DNI853);
            }
            else
            {
                // Si había sido eliminado físicamente, se reinserta en el maestro (dispara Trigger + DV + Bitácora Eventos)
                return objBllSector_DNI853.CrearSector_DNI853(sectorAActivar_DNI853);
            }
        }
    }
}
