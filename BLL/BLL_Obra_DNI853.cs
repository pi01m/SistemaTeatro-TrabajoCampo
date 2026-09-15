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

            if (string.IsNullOrWhiteSpace(obraParam_DNI853.Estado_DNI853))
                throw new Exception("err_EstadoObraObligatorio");

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
            // 1. Validaciones básicas de campos obligatorios
            if (string.IsNullOrWhiteSpace(obraParam_DNI853.NombreObra_DNI853))
                throw new Exception("err_NombreObraObligatorio");

            if (string.IsNullOrWhiteSpace(obraParam_DNI853.DescripcionObra_DNI853))
                throw new Exception("err_DescripcionObraObligatoria");

            if (string.IsNullOrWhiteSpace(obraParam_DNI853.Estado_DNI853))
                throw new Exception("err_EstadoObraObligatorio");

            // 2. BUSCAR EL ESTADO ORIGINAL DE LA OBRA EN LA BASE DE DATOS
            var obraOriginal_DNI853 = this.ListarObras_DNI853()
                .FirstOrDefault(o => o.IdObra_DNI853 == obraParam_DNI853.IdObra_DNI853);

            BLL_Funcion_DNI853 bllFuncion_DNI853 = new BLL_Funcion_DNI853();
            bool tieneFuncionesAsignadas_DNI853 = false;

            if (obraOriginal_DNI853 != null)
            {
                tieneFuncionesAsignadas_DNI853 = bllFuncion_DNI853.ListarFunciones_DNI853()
                    .Any(f => f.IdObra_DNI853 == obraParam_DNI853.IdObra_DNI853);

                // REGLA 1: Si tiene funciones y el usuario intenta ponerla manualmente en "Activa"
                if (tieneFuncionesAsignadas_DNI853 && obraParam_DNI853.Estado_DNI853 == "Activa")
                {
                    obraParam_DNI853.Estado_DNI853 = "En Cartelera";
                }

                // REGLA 2: Bloquear paso manual de En Cartelera a Activa
                if (obraOriginal_DNI853.Estado_DNI853 == "En Cartelera" && obraParam_DNI853.Estado_DNI853 == "Activa")
                {
                    throw new Exception("err_NoSePuedePasarAActivaUnaObraEnCartelera");
                }
            }

            // 3. Actualización de la Obra en Base de Datos
            bool resultado_DNI853 = objDalObra_DNI853.ActualizarObra_DNI853(obraParam_DNI853);

            if (resultado_DNI853)
            {
                // --- REGLA EN CASCADA: SI LA OBRA PASÓ A "Inactiva", CANCELAR SUS FUNCIONES ---
                if (obraParam_DNI853.Estado_DNI853 == "Inactiva")
                {
                    // Obtenemos todas las funciones asociadas a esta obra
                    var funcionesDeLaObra = bllFuncion_DNI853.ListarFunciones_DNI853()
                        .Where(f => f.IdObra_DNI853 == obraParam_DNI853.IdObra_DNI853)
                        .ToList();

                    foreach (var funcion in funcionesDeLaObra)
                    {
                        // Cambiamos el estado de cada función a "Cancelada" o "Inactiva"
                        funcion.Estado_DNI853 = "Cancelada"; // Asegúrate de usar el valor de estado que manejen tus funciones
                        bllFuncion_DNI853.ModificarFuncion_DNI853(funcion);
                    }
                }
                // --------------------------------------------------------------------------

                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 4. Actualización de Dígitos Verificadores de la Obra
                List<BE_Obra_DNI853> listaCompleta_DNI853 = this.ListarObras_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(obraParam_DNI853, listaCompleta_DNI853, "Obra_DNI853");

                // 5. Registro en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Modificación de Obra (Inactivación)",
                    loginActual_DNI853,
                    "Gestión Obras",
                    2);
            }

            return resultado_DNI853;
        } 
        public List<BE_Obra_DNI853> ObtenerObrasEnCartelera_DNI853()
        {
            return objDalObra_DNI853.ObtenerObrasEnCartelera_DNI853();
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

        public List<BE_Obra_DNI853> ListarObrasDisponibles_DNI853()
        { 
            return objDalObra_DNI853.ObtenerObrasDisponibles_DNI853();
        }

        public void VerificarYActualizarEstadoAEnCartelera_DNI853(string idObra_DNI853)
        {
            // Buscamos la obra por su ID dentro de la lista completa
            var obra_DNI853 = this.ListarObras_DNI853()
                .FirstOrDefault(o => o.IdObra_DNI853 == idObra_DNI853);

            // Si la obra existe y su estado es "Activa", la actualizamos a "En Cartelera"
            if (obra_DNI853 != null && obra_DNI853.Estado_DNI853 == "Activa")
            {
                obra_DNI853.Estado_DNI853 = "En Cartelera";
                this.ModificarObra_DNI853(obra_DNI853); // Esto ya maneja la BD, los dígitos verificadores y la bitácora de la obra
            }
        }
    }
}
