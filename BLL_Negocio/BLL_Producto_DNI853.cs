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
    public class BLL_Producto_DNI853
    {
        private DAL_Producto_DNI853 objDalProducto_DNI853;
        private BLL_BitacoraEvento objBitacora_DNI853;
        private BLL_DigitoVerificador objDigitoVerificador_DNI853;

        public BLL_Producto_DNI853()
        {
            objDalProducto_DNI853 = new DAL_Producto_DNI853();
            objBitacora_DNI853 = new BLL_BitacoraEvento();
            objDigitoVerificador_DNI853 = new BLL_DigitoVerificador();
        }

        public List<BE_Producto_DNI853> ListarProductos_DNI853()
        {
            return objDalProducto_DNI853.ListarProductos_DNI853();
        }

        private void ValidarProducto_DNI853(BE_Producto_DNI853 productoParam_DNI853)
        {
            if (productoParam_DNI853 == null)
                throw new Exception("err_ProductoNulo");

            if (string.IsNullOrWhiteSpace(productoParam_DNI853.IdProducto_DNI853))
                throw new Exception("err_IdProductoObligatorio");

            if (string.IsNullOrWhiteSpace(productoParam_DNI853.NombreProducto_DNI853))
                throw new Exception("err_NombreProductoObligatorio");

            if (productoParam_DNI853.Precio_DNI853 < 0)
                throw new Exception("err_PrecioProductoInvalido");
        }

        public bool CrearProducto_DNI853(string id, string nombre, string categoria, string precioStr, string stockStr)
        {
            if (!decimal.TryParse(precioStr, out decimal precio))
                throw new Exception("err_PrecioProductoInvalido");

            if (!int.TryParse(stockStr, out int stock))
                throw new Exception("err_StockProductoInvalido");

            // 1. La BLL es la única encargada de instanciar y armar la BE
            BE_Producto_DNI853 objNuevoProducto_DNI853 = new BE_Producto_DNI853
            {
                IdProducto_DNI853 = id,
                NombreProducto_DNI853 = nombre,
                Categoria_DNI853 = categoria,
                Precio_DNI853 = precio,
                Stock_DNI853 = stock
            };

            // 2. Validaciones de negocio
            ValidarProducto_DNI853(objNuevoProducto_DNI853);

            // 3. Inserción en Base de Datos (DAL)
            bool resultado_DNI853 = objDalProducto_DNI853.InsertarProducto_DNI853(objNuevoProducto_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                // 4. Actualización de Dígitos Verificadores
                List<BE_Producto_DNI853> listaCompleta_DNI853 = this.ListarProductos_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(objNuevoProducto_DNI853, listaCompleta_DNI853, "Producto_DNI853");

                // 5. Registro Obligatorio en Bitácora
                objBitacora_DNI853.RegistrarBitacora(
                    "Alta de Producto",
                    loginActual_DNI853,
                    "Gestión Productos",
                    2);
            }

            return resultado_DNI853;
        }

        public bool ModificarProducto_DNI853(BE_Producto_DNI853 productoParam_DNI853)
        {
            ValidarProducto_DNI853(productoParam_DNI853);

            bool resultado_DNI853 = objDalProducto_DNI853.ActualizarProducto_DNI853(productoParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                List<BE_Producto_DNI853> listaCompleta_DNI853 = this.ListarProductos_DNI853();
                objDigitoVerificador_DNI853.ActualizarDigitos(productoParam_DNI853, listaCompleta_DNI853, "Producto_DNI853");

                objBitacora_DNI853.RegistrarBitacora(
                    "Modificación de Producto",
                    loginActual_DNI853,
                    "Gestión Productos",
                    2);
            }

            return resultado_DNI853;
        }

        public bool EliminarProducto_DNI853(string idProductoParam_DNI853)
        {
            bool resultado_DNI853 = objDalProducto_DNI853.EliminarProducto_DNI853(idProductoParam_DNI853);

            if (resultado_DNI853)
            {
                string loginActual_DNI853 = SessionManager.GetInstancia().GetUsuarioActual().Login;

                List<BE_Producto_DNI853> listaCompletaRestante_DNI853 = this.ListarProductos_DNI853();
                objDigitoVerificador_DNI853.EliminarDigitoYRecalcular(
                    idProductoParam_DNI853,
                    listaCompletaRestante_DNI853,
                    "Producto_DNI853");

                objBitacora_DNI853.RegistrarBitacora(
                    "Baja de Producto",
                    loginActual_DNI853,
                    "Gestión Productos",
                    3);
            }

            return resultado_DNI853;
        }
    }
}
