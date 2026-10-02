using BLL.BLL_Servicio;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
namespace BLL
{
    public class BLL_Sala_DNI853
    {
        // Instancias OBLIGATORIAS para cumplir con las reglas del sistema
        private DAL_Sala_DNI853 objDalSala_DNI853;
        private BLL_BitacoraEvento objBitacora_DNI853;
        private BLL_DigitoVerificador objDigitoVerificador_DNI853;

        public BLL_Sala_DNI853()
        {
            objDalSala_DNI853 = new DAL_Sala_DNI853();
            objBitacora_DNI853 = new BLL_BitacoraEvento();
            objDigitoVerificador_DNI853 = new BLL_DigitoVerificador();
        }

        public List<BE_Sala_DNI853> ListarSalas_DNI853()
        {
            return objDalSala_DNI853.ListarSalas_DNI853();
        }

        public bool CrearSala_DNI853(BE_Sala_DNI853 salaParam_DNI853)
        {
            // 1. Validaciones de negocio
            if (string.IsNullOrWhiteSpace(salaParam_DNI853.NombreSala_DNI853))
                throw new Exception("err_NombreSalaObligatorio");

            if (salaParam_DNI853.Capacidad_DNI853 <= 0)
                throw new Exception("err_CapacidadInvalida");

            // Autogeneración de ID tipo string si no viene asignado
            if (string.IsNullOrEmpty(salaParam_DNI853.IdSala_DNI853))
            {
                salaParam_DNI853.IdSala_DNI853 = "SAL_" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            }

            // 2. Insertar en la Base de Datos a través de la DAL
            bool resultado_DNI853 = objDalSala_DNI853.InsertarSala_DNI853(salaParam_DNI853);

            if (resultado_DNI853)
            {
                // Obtenemos el usuario activo para la bitácora
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 3. ACTUALIZACIÓN DE DÍGITOS VERIFICADORES
                List<BE_Sala_DNI853> listaCompleta_DNI853 = this.ListarSalas_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(salaParam_DNI853, listaCompleta_DNI853, "Sala_DNI853");

                // 4. REGISTRO EN BITÁCORA (Obligatorio)
                objBitacora_DNI853.RegistrarBitacora(
                    "Alta de Sala",
                    loginActual_DNI853,
                    "Gestión Salas",
                    2); // Criticidad Media
            }

            return resultado_DNI853;
        }

        public bool ModificarSala_DNI853(BE_Sala_DNI853 salaParam_DNI853)
        {
            // 1. Validaciones de negocio
            if (string.IsNullOrWhiteSpace(salaParam_DNI853.NombreSala_DNI853))
                throw new Exception("err_NombreSalaObligatorio");

            // 2. Actualizar en Base de Datos
            bool resultado_DNI853 = objDalSala_DNI853.ActualizarSala_DNI853(salaParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 3. ACTUALIZACIÓN DE DÍGITOS VERIFICADORES
                List<BE_Sala_DNI853> listaCompleta_DNI853 = this.ListarSalas_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(salaParam_DNI853, listaCompleta_DNI853, "Sala_DNI853");

                // 4. REGISTRO EN BITÁCORA
                objBitacora_DNI853.RegistrarBitacora(
                    "Modificación de Sala",
                    loginActual_DNI853,
                    "Gestión Salas",
                    2);
            }

            return resultado_DNI853;
        }

        public bool EliminarSala_DNI853(string idSalaParam_DNI853)
        {
            // IMPORTANTE: Antes de eliminar, verificar si tiene sectores hijos.
            // (Asumiremos que tienes una BLL_Sector_DNI853 para hacer esta validación, o delegas a la BD)
            BLL_Sector_DNI853 validadorSectores_DNI853 = new BLL_Sector_DNI853();
            var sectoresHijos_DNI853 = validadorSectores_DNI853.ListarSectoresPorSala_DNI853(idSalaParam_DNI853);

            if (sectoresHijos_DNI853.Count > 0)
            {
                throw new Exception("err_SalaTieneSectoresAsociados"); // No se puede eliminar si tiene hijos
            }

            // 1. Eliminar en Base de Datos
            bool resultado_DNI853 = objDalSala_DNI853.EliminarSala_DNI853(idSalaParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 2. ACTUALIZACIÓN DE DÍGITOS VERIFICADORES (Borrado)
                // Usamos el método EliminarDigitoYRecalcular que me pasaste en tu ejemplo
                List<BE_Sala_DNI853> listaCompletaRestante_DNI853 = this.ListarSalas_DNI853();
                objDigitoVerificador_DNI853.EliminarDigitoYRecalcular(
                    idSalaParam_DNI853.ToString(),
                    listaCompletaRestante_DNI853,
                    "Sala_DNI853");

                // 3. REGISTRO EN BITÁCORA
                objBitacora_DNI853.RegistrarBitacora(
                    "Baja de Sala",
                    loginActual_DNI853,
                    "Gestión Salas",
                    3); // Criticidad Alta por ser borrado
            }

            return resultado_DNI853;
        }
    }
}
