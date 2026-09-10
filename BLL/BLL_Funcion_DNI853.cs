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
    public class BLL_Funcion_DNI853
    {
        private DAL_Funcion_DNI853 objDalFuncion_DNI853;
        private BLL_BitacoraEvento objBitacora_DNI853;
        private BLL_DigitoVerificador objDigitoVerificador_DNI853;

        public BLL_Funcion_DNI853()
        {
            objDalFuncion_DNI853 = new DAL_Funcion_DNI853();
            objBitacora_DNI853 = new BLL_BitacoraEvento();
            objDigitoVerificador_DNI853 = new BLL_DigitoVerificador();
        }

        public List<BE_Funcion_DNI853> ListarFunciones_DNI853()
        {
            return objDalFuncion_DNI853.ListarFunciones_DNI853();
        }

        public bool CrearFuncion_DNI853(BE_Funcion_DNI853 funcionParam_DNI853)
        {
            // 1. Validaciones de negocio
            if (string.IsNullOrWhiteSpace(funcionParam_DNI853.IdObra_DNI853))
                throw new Exception("err_DebeSeleccionarObra");

            if (string.IsNullOrWhiteSpace(funcionParam_DNI853.IdSala_DNI853))
                throw new Exception("err_DebeSeleccionarSala");

            if (string.IsNullOrWhiteSpace(funcionParam_DNI853.HoraInicio_DNI853))
                throw new Exception("err_HoraInicioObligatoria");

            if (string.IsNullOrWhiteSpace(funcionParam_DNI853.Estado_DNI853))
                throw new Exception("err_EstadoObligatorio");

            // 2. Autogeneración de ID tipo string si no viene asignado
            if (string.IsNullOrEmpty(funcionParam_DNI853.IdFuncion_DNI853))
            {
                funcionParam_DNI853.IdFuncion_DNI853 = "FUN_" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            }

            // 3. Inserción en Base de Datos
            bool resultado_DNI853 = objDalFuncion_DNI853.InsertarFuncion_DNI853(funcionParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 4. Actualización de Dígitos Verificadores
                List<BE_Funcion_DNI853> listaCompleta_DNI853 = this.ListarFunciones_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(funcionParam_DNI853, listaCompleta_DNI853, "Funcion_DNI853");

                // 5. Registro Obligatorio en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Alta de Función",
                    loginActual_DNI853,
                    "Gestión Funciones",
                    2); // Criticidad Media
            }

            return resultado_DNI853;
        }

        public bool ModificarFuncion_DNI853(BE_Funcion_DNI853 funcionParam_DNI853)
        {
            // 1. Validaciones de negocio
            if (string.IsNullOrWhiteSpace(funcionParam_DNI853.IdObra_DNI853))
                throw new Exception("err_DebeSeleccionarObra");

            if (string.IsNullOrWhiteSpace(funcionParam_DNI853.IdSala_DNI853))
                throw new Exception("err_DebeSeleccionarSala");

            if (string.IsNullOrWhiteSpace(funcionParam_DNI853.HoraInicio_DNI853))
                throw new Exception("err_HoraInicioObligatoria");

            if (string.IsNullOrWhiteSpace(funcionParam_DNI853.Estado_DNI853))
                throw new Exception("err_EstadoObligatorio");

            // 2. Actualización en Base de Datos
            bool resultado_DNI853 = objDalFuncion_DNI853.ActualizarFuncion_DNI853(funcionParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 3. Actualización de Dígitos Verificadores
                List<BE_Funcion_DNI853> listaCompleta_DNI853 = this.ListarFunciones_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(funcionParam_DNI853, listaCompleta_DNI853, "Funcion_DNI853");

                // 4. Registro en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Modificación de Función",
                    loginActual_DNI853,
                    "Gestión Funciones",
                    2);
            }

            return resultado_DNI853;
        }

        public bool EliminarFuncion_DNI853(string idFuncionParam_DNI853)
        {
            // 1. Eliminación en Base de Datos
            bool resultado_DNI853 = objDalFuncion_DNI853.EliminarFuncion_DNI853(idFuncionParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 2. Actualización de Dígitos Verificadores (Borrado y Recálculo)
                List<BE_Funcion_DNI853> listaCompletaRestante_DNI853 = this.ListarFunciones_DNI853();
                objDigitoVerificador_DNI853.EliminarDigitoYRecalcular(
                    idFuncionParam_DNI853,
                    listaCompletaRestante_DNI853,
                    "Funcion_DNI853");

                // 3. Registro en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Baja de Función",
                    loginActual_DNI853,
                    "Gestión Funciones",
                    3); // Criticidad Alta por ser borrado
            }

            return resultado_DNI853;
        }
    }
}
