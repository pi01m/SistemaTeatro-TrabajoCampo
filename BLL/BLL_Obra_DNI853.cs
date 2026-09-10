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
    public class BLL_Obra_DNI853
    {
        private DAL_Obra_DNI853 objDalObra_DNI853;
        private BLL_BitacoraEvento objBitacora_DNI853;
        private BLL_DigitoVerificador objDigitoVerificador_DNI853;

        public BLL_Obra_DNI853()
        {
            objDalObra_DNI853 = new DAL_Obra_DNI853();
            objBitacora_DNI853 = new BLL_BitacoraEvento();
            objDigitoVerificador_DNI853 = new BLL_DigitoVerificador();
        }

        public List<BE_Obra_DNI853> ListarObras_DNI853()
        {
            return objDalObra_DNI853.ListarObras_DNI853();
        }

        public bool CrearObra_DNI853(BE_Obra_DNI853 obraParam_DNI853)
        {
            // 1. Validaciones de negocio
            if (string.IsNullOrWhiteSpace(obraParam_DNI853.NombreObra_DNI853))
                throw new Exception("err_NombreObraObligatorio");

            if (string.IsNullOrWhiteSpace(obraParam_DNI853.DescripcionObra_DNI853))
                throw new Exception("err_DescripcionObraObligatoria");

            // 2. Autogeneración de ID tipo string si no viene asignado
            if (string.IsNullOrEmpty(obraParam_DNI853.IdObra_DNI853))
            {
                obraParam_DNI853.IdObra_DNI853 = "OBR_" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            }

            // 3. Inserción en Base de Datos
            bool resultado_DNI853 = objDalObra_DNI853.InsertarObra_DNI853(obraParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 4. Actualización de Dígitos Verificadores
                List<BE_Obra_DNI853> listaCompleta_DNI853 = this.ListarObras_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(obraParam_DNI853, listaCompleta_DNI853, "Obra_DNI853");

                // 5. Registro Obligatorio en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Alta de Obra",
                    loginActual_DNI853,
                    "Gestión Obras",
                    2); // Criticidad Media
            }

            return resultado_DNI853;
        }

        public bool ModificarObra_DNI853(BE_Obra_DNI853 obraParam_DNI853)
        {
            // 1. Validaciones de negocio
            if (string.IsNullOrWhiteSpace(obraParam_DNI853.NombreObra_DNI853))
                throw new Exception("err_NombreObraObligatorio");

            if (string.IsNullOrWhiteSpace(obraParam_DNI853.DescripcionObra_DNI853))
                throw new Exception("err_DescripcionObraObligatoria");

            // 2. Actualización en Base de Datos
            bool resultado_DNI853 = objDalObra_DNI853.ActualizarObra_DNI853(obraParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 3. Actualización de Dígitos Verificadores
                List<BE_Obra_DNI853> listaCompleta_DNI853 = this.ListarObras_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(obraParam_DNI853, listaCompleta_DNI853, "Obra_DNI853");

                // 4. Registro en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Modificación de Obra",
                    loginActual_DNI853,
                    "Gestión Obras",
                    2);
            }

            return resultado_DNI853;
        }

        public bool EliminarObra_DNI853(string idObraParam_DNI853)
        {
            // 1. Eliminación en Base de Datos
            bool resultado_DNI853 = objDalObra_DNI853.EliminarObra_DNI853(idObraParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 2. Actualización de Dígitos Verificadores (Borrado y Recálculo)
                List<BE_Obra_DNI853> listaCompletaRestante_DNI853 = this.ListarObras_DNI853();
                objDigitoVerificador_DNI853.EliminarDigitoYRecalcular(
                    idObraParam_DNI853,
                    listaCompletaRestante_DNI853,
                    "Obra_DNI853");

                // 3. Registro en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Baja de Obra",
                    loginActual_DNI853,
                    "Gestión Obras",
                    3); // Criticidad Alta por ser borrado
            }

            return resultado_DNI853;
        }
    }
}
