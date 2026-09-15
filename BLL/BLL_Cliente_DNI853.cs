using BE;
using BLL.BLL_Servicio;
using DAL;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL
{
    public class BLL_Cliente_DNI853
    {
        private DAL_Cliente_DNI853 objDalCliente_DNI853;
        private BLL_BitacoraEvento objBitacora_DNI853;
        private BLL_DigitoVerificador objDigitoVerificador_DNI853;

        public BLL_Cliente_DNI853()
        {
            objDalCliente_DNI853 = new DAL_Cliente_DNI853();
            objBitacora_DNI853 = new BLL_BitacoraEvento();
            objDigitoVerificador_DNI853 = new BLL_DigitoVerificador();
        }

        public List<BE_Cliente_DNI853> ListarClientes_DNI853()
        {
            return objDalCliente_DNI853.ListarClientes_DNI853();
        }

        public bool CrearCliente_DNI853(BE_Cliente_DNI853 clienteParam_DNI853)
        {
            // 1. Validaciones de negocio
            if (string.IsNullOrWhiteSpace(clienteParam_DNI853.DNI_C_DNI853))
                throw new Exception("err_DniClienteObligatorio");

            if (string.IsNullOrWhiteSpace(clienteParam_DNI853.Nombre_C_DNI853))
                throw new Exception("err_NombreClienteObligatorio");

            if (string.IsNullOrWhiteSpace(clienteParam_DNI853.Apellido_C_DNI853))
                throw new Exception("err_ApellidoClienteObligatorio");

            // 2. Inserción en Base de Datos
            bool resultado_DNI853 = objDalCliente_DNI853.InsertarCliente_DNI853(clienteParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 3. Actualización de Dígitos Verificadores
                List<BE_Cliente_DNI853> listaCompleta_DNI853 = this.ListarClientes_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(clienteParam_DNI853, listaCompleta_DNI853, "Cliente_DNI853");

                // 4. Registro Obligatorio en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Alta de Cliente",
                    loginActual_DNI853,
                    "Gestión Clientes",
                    2); // Criticidad Media
            }

            return resultado_DNI853;
        }

        public bool ModificarCliente_DNI853(BE_Cliente_DNI853 clienteParam_DNI853)
        {
            // 1. Validaciones de negocio
            if (string.IsNullOrWhiteSpace(clienteParam_DNI853.DNI_C_DNI853))
                throw new Exception("err_DniClienteObligatorio");

            if (string.IsNullOrWhiteSpace(clienteParam_DNI853.Nombre_C_DNI853))
                throw new Exception("err_NombreClienteObligatorio");

            if (string.IsNullOrWhiteSpace(clienteParam_DNI853.Apellido_C_DNI853))
                throw new Exception("err_ApellidoClienteObligatorio");

            // 2. Actualización en Base de Datos
            bool resultado_DNI853 = objDalCliente_DNI853.ActualizarCliente_DNI853(clienteParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 3. Actualización de Dígitos Verificadores
                List<BE_Cliente_DNI853> listaCompleta_DNI853 = this.ListarClientes_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(clienteParam_DNI853, listaCompleta_DNI853, "Cliente_DNI853");

                // 4. Registro en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Modificación de Cliente",
                    loginActual_DNI853,
                    "Gestión Clientes",
                    2);
            }

            return resultado_DNI853;
        }

        public bool EliminarCliente_DNI853(string dniClienteParam_DNI853)
        {
            // 1. Eliminación en Base de Datos
            bool resultado_DNI853 = objDalCliente_DNI853.EliminarCliente_DNI853(dniClienteParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 2. Actualización de Dígitos Verificadores (Borrado y Recálculo)
                List<BE_Cliente_DNI853> listaCompletaRestante_DNI853 = this.ListarClientes_DNI853();
                objDigitoVerificador_DNI853.EliminarDigitoYRecalcular(
                    dniClienteParam_DNI853,
                    listaCompletaRestante_DNI853,
                    "Cliente_DNI853");

                // 3. Registro en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Baja de Cliente",
                    loginActual_DNI853,
                    "Gestión Clientes",
                    3); // Criticidad Alta por ser borrado
            }

            return resultado_DNI853;
        }

        public BE_Cliente_DNI853 BuscarPorDNI_DNI853(string dni_DNI853)
        {
            if (string.IsNullOrWhiteSpace(dni_DNI853))
                throw new Exception("err_DniClienteObligatorio");

            return objDalCliente_DNI853.BuscarPorDNI_DNI853(dni_DNI853);
        }
    }
}
