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
    public class BLL_Promocion_DNI853
    {
        private DAL_Promocion_DNI853 objDalPromocion_DNI853;
        private BLL_BitacoraEvento objBitacora_DNI853;
        private BLL_DigitoVerificador objDigitoVerificador_DNI853;

        public BLL_Promocion_DNI853()
        {
            objDalPromocion_DNI853 = new DAL_Promocion_DNI853();
            objBitacora_DNI853 = new BLL_BitacoraEvento();
            objDigitoVerificador_DNI853 = new BLL_DigitoVerificador();
        }

        public List<BE_Promocion_DNI853> ListarPromociones_DNI853()
        {
            return objDalPromocion_DNI853.ListarPromociones_DNI853();
        }

        public bool CrearPromocion_DNI853(BE_Promocion_DNI853 promocionParam_DNI853)
        {
            // 1. Validaciones de negocio
            if (string.IsNullOrWhiteSpace(promocionParam_DNI853.NombrePromo_DNI853))
                throw new Exception("err_NombrePromoObligatorio");

            if (promocionParam_DNI853.ValorDescuento_DNI853 <= 0)
                throw new Exception("err_ValorDescuentoInvalido");

            if (promocionParam_DNI853.FechaInicio_DNI853 > promocionParam_DNI853.FechaFin_DNI853)
                throw new Exception("err_FechasPromocionInvalidas");

            // 2. Autogeneración de ID tipo string si no viene asignado
            if (string.IsNullOrEmpty(promocionParam_DNI853.IdPromo_DNI853))
            {
                promocionParam_DNI853.IdPromo_DNI853 = "PRM_" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            }

            // 3. Inserción en Base de Datos
            bool resultado_DNI853 = objDalPromocion_DNI853.InsertarPromocion_DNI853(promocionParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 4. Actualización de Dígitos Verificadores
                List<BE_Promocion_DNI853> listaCompleta_DNI853 = this.ListarPromociones_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(promocionParam_DNI853, listaCompleta_DNI853, "Promocion_DNI853");

                // 5. Registro Obligatorio en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Alta de Promoción",
                    loginActual_DNI853,
                    "Gestión Promociones",
                    2); // Criticidad Media
            }

            return resultado_DNI853;
        }

        public bool ModificarPromocion_DNI853(BE_Promocion_DNI853 promocionParam_DNI853)
        {
            // 1. Validaciones de negocio
            if (string.IsNullOrWhiteSpace(promocionParam_DNI853.NombrePromo_DNI853))
                throw new Exception("err_NombrePromoObligatorio");

            if (promocionParam_DNI853.ValorDescuento_DNI853 <= 0)
                throw new Exception("err_ValorDescuentoInvalido");

            if (promocionParam_DNI853.FechaInicio_DNI853 > promocionParam_DNI853.FechaFin_DNI853)
                throw new Exception("err_FechasPromocionInvalidas");

            // 2. Actualización en Base de Datos
            bool resultado_DNI853 = objDalPromocion_DNI853.ActualizarPromocion_DNI853(promocionParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 3. Actualización de Dígitos Verificadores
                List<BE_Promocion_DNI853> listaCompleta_DNI853 = this.ListarPromociones_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(promocionParam_DNI853, listaCompleta_DNI853, "Promocion_DNI853");

                // 4. Registro en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Modificación de Promoción",
                    loginActual_DNI853,
                    "Gestión Promociones",
                    2);
            }

            return resultado_DNI853;
        }

        public bool EliminarPromocion_DNI853(string idPromoParam_DNI853)
        {
            // 1. Eliminación en Base de Datos
            bool resultado_DNI853 = objDalPromocion_DNI853.EliminarPromocion_DNI853(idPromoParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 2. Actualización de Dígitos Verificadores (Borrado y Recálculo)
                List<BE_Promocion_DNI853> listaCompletaRestante_DNI853 = this.ListarPromociones_DNI853();
                objDigitoVerificador_DNI853.EliminarDigitoYRecalcular(
                    idPromoParam_DNI853,
                    listaCompletaRestante_DNI853,
                    "Promocion_DNI853");

                // 3. Registro en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Baja de Promoción",
                    loginActual_DNI853,
                    "Gestión Promociones",
                    3); // Criticidad Alta por ser borrado
            }

            return resultado_DNI853;
        }

        public List<BE_Promocion_DNI853> ObtenerPromocionesVigentes_DNI853()
        {
            return objDalPromocion_DNI853.ObtenerPromocionesVigentes_DNI853();
        }

        public List<BE_Promocion_DNI853> ObtenerPromocionesVigentesParaEntradas_DNI853()
        {
            // Llama al método existente y aplica el filtro por destino en la capa de negocio
            return this.ObtenerPromocionesVigentes_DNI853()
                       .Where(p => p.DestinoPromo_DNI853 == "Entradas")
                       .ToList();
        }
    }
}
