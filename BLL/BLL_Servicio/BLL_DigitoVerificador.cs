using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
namespace BLL.BLL_Servicio
{
    public class BLL_DigitoVerificador
    {
        private Servicio_Calcular servicioCalcular;
        private BLL_BitacoraEvento bllBitacora;
        private DAL_DigitoVerificador dalDigito;
        private DAL_Usuario dalUsuario;
        private DAL_Idioma dalIdioma;
        private DAL_Permiso dalPermiso;
        private Servicio_VerificadorDigito servicioVerificador;
        public BLL_DigitoVerificador()
        {
            servicioCalcular = new Servicio_Calcular();
            bllBitacora = new BLL_BitacoraEvento();
            dalDigito = new DAL_DigitoVerificador();
            dalUsuario = new DAL_Usuario();
            dalIdioma = new DAL_Idioma();
            servicioVerificador = new Servicio_VerificadorDigito();
            dalPermiso = new DAL_Permiso();
  
        }


        public ExcepcionIntegridad ValidarIntegridad<T>(List<T> listaRegistros, string nombreTabla) where T : IVerificable
        {
            string cadenaAcumuladaParaDVV = "";

            var listaOrdenada = listaRegistros
                .OrderBy(x => x.ObtenerIdentificadorFila())
                .ToList();

            List<string> registrosAlterados = new List<string>();


            foreach (T registro in listaOrdenada)
            {
                string dvhCalculado = servicioCalcular.CalcularDVH(registro);

                string nombreFila =
                    $"{nombreTabla}_{registro.ObtenerIdentificadorFila()}";

                Servicio_DigitoVerificadorVertical registroBD =
                    dalDigito.ObtenerRegistroDigito(nombreFila);

                // Solo se marca "modificado" si YA existía un DVH previo y no coincide.
                // Si registroBD es null, es un registro nuevo sin baseline: no es una alteración.
                
                if (registroBD != null &&!servicioVerificador.EsValido(dvhCalculado, registroBD.DVH))
                {
                    registrosAlterados.Add(registro.ObtenerIdentificadorFila());
                }
                cadenaAcumuladaParaDVV += dvhCalculado;
            }

            List<string> registrosGuardados =
                dalDigito.ObtenerRegistrosDVH(nombreTabla);

            List<string> registrosActuales =
                listaRegistros
                .Select(x => nombreTabla + "_" + x.ObtenerIdentificadorFila())
                .ToList();

            List<string> eliminados =
                registrosGuardados
                .Where(x => !registrosActuales.Contains(x))
                .ToList();

            string dvvCalculado =
                servicioCalcular.CalcularHash(cadenaAcumuladaParaDVV);

            Servicio_DigitoVerificadorVertical maestro =
                dalDigito.ObtenerRegistroDigito(nombreTabla + "_MAESTRO");

            bool errorDVV =maestro == null ||!servicioVerificador.EsValido(dvvCalculado, maestro.DVV);
     

            if (registrosAlterados.Count == 0 &&
                eliminados.Count == 0 &&
                !errorDVV)
            {
                return null; // tabla íntegra, no hay nada que reportar
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Violación de integridad en la tabla '{nombreTabla}'.");

            if (registrosAlterados.Count > 0)
            {
                sb.AppendLine();
                sb.AppendLine("Registros modificados:");
                foreach (string r in registrosAlterados)
                    sb.AppendLine("- " + r);
            }

            if (eliminados.Count > 0)
            {
                sb.AppendLine();
                sb.AppendLine("Registros eliminados:");
                foreach (string r in eliminados)
                    sb.AppendLine("- " + r);
            }

            if (errorDVV)
            {
                sb.AppendLine();
                sb.AppendLine("El DVV de la tabla es incorrecto.");
            }

            string mensaje = sb.ToString();

            bllBitacora.RegistrarBitacora(
                mensaje,
                "Sistema",
                "Seguridad",
                1);

            return new ExcepcionIntegridad(
                nombreTabla,
                registrosAlterados,
                eliminados,
                errorDVV,
                mensaje);
        }

        public void ValidarTodaLaBase()
        {
            List<ExcepcionIntegridad> errores = new List<ExcepcionIntegridad>();

            // ---------- Sector_DNI853 ----------
            DAL_Sector_DNI853 dalSector_DNI853 = new DAL_Sector_DNI853();
            var errorSector_DNI853 = ValidarIntegridad(
                dalSector_DNI853.ListarTodosSectores_DNI853(),
                "Sector_DNI853");

            if (errorSector_DNI853 != null)
                errores.Add(errorSector_DNI853);

            // ---------- Sala_DNI853 ----------
            DAL_Sala_DNI853 dalSala_DNI853 = new DAL_Sala_DNI853();
            var errorSala_DNI853 = ValidarIntegridad(
                dalSala_DNI853.ListarSalas_DNI853(),
                "Sala_DNI853");

            if (errorSala_DNI853 != null)
                errores.Add(errorSala_DNI853);

            // ---------- Promocion_DNI853 ----------
            DAL_Promocion_DNI853 dalPromocion_DNI853 = new DAL_Promocion_DNI853();
            var errorPromocion_DNI853 = ValidarIntegridad(
                dalPromocion_DNI853.ListarPromociones_DNI853(),
                "Promocion_DNI853");

            if (errorPromocion_DNI853 != null)
                errores.Add(errorPromocion_DNI853);

            // ---------- Obra_DNI853 ----------
            DAL_Obra_DNI853 dalObra_DNI853 = new DAL_Obra_DNI853();
            var errorObra_DNI853 = ValidarIntegridad(
                dalObra_DNI853.ListarObras_DNI853(),
                "Obra_DNI853");

            if (errorObra_DNI853 != null)
                errores.Add(errorObra_DNI853);

            // ---------- MedioPago_DNI853 ----------
            DAL_MedioPago_DNI853 dalMedioPago_DNI853 = new DAL_MedioPago_DNI853();
            var errorMedioPago_DNI853 = ValidarIntegridad(
                dalMedioPago_DNI853.ObtenerMediosDePago_DNI853(),
                "MedioPago_DNI853");

            if (errorMedioPago_DNI853 != null)
                errores.Add(errorMedioPago_DNI853);

            // ---------- Funcion_DNI853 ----------
            DAL_Funcion_DNI853 dalFuncion_DNI853 = new DAL_Funcion_DNI853();
            var errorFuncion_DNI853 = ValidarIntegridad(
                dalFuncion_DNI853.ListarFunciones_DNI853(),
                "Funcion_DNI853");

            if (errorFuncion_DNI853 != null)
                errores.Add(errorFuncion_DNI853);

            // ---------- Factura_DNI853 ----------
            DAL_Factura_DNI853 dalFactura_DNI853 = new DAL_Factura_DNI853();
            var errorFactura_DNI853 = ValidarIntegridad(
                dalFactura_DNI853.ListarFacturas_DNI853(),
                "Factura_DNI853");

            if (errorFactura_DNI853 != null)
                errores.Add(errorFactura_DNI853);

            // ---------- Entrada_DNI853 ----------
            DAL_Entrada_DNI853 dalEntrada_DNI853 = new DAL_Entrada_DNI853();
            var errorEntrada_DNI853 = ValidarIntegridad(
                dalEntrada_DNI853.ListarEntradas_DNI853(),
                "Entrada_DNI853");

            if (errorEntrada_DNI853 != null)
                errores.Add(errorEntrada_DNI853);

            // ---------- Cliente_DNI853 ----------
            DAL_Cliente_DNI853 dalCliente_DNI853 = new DAL_Cliente_DNI853();
            var errorCliente_DNI853 = ValidarIntegridad(
                dalCliente_DNI853.ListarClientes_DNI853(),
                "Cliente_DNI853");

            if (errorCliente_DNI853 != null)
                errores.Add(errorCliente_DNI853);

            // ---------- Idioma ----------
            var errorIdioma = ValidarIntegridad(
                dalIdioma.DameIdiomasBD(),
                "Idioma");

            if (errorIdioma != null)
                errores.Add(errorIdioma);

            // ---------- Permiso ----------
            var errorPermiso = ValidarIntegridad(
                dalPermiso.ListarPermisos(),
                "Permiso");

            if (errorPermiso != null)
                errores.Add(errorPermiso);


            // ---------- Usuario ----------
            var errorUsuario = ValidarIntegridad(
                dalUsuario.ListarUsuarios(),
                "Usuario");

            if (errorUsuario != null)
                errores.Add(errorUsuario);

            // ---------- Rol ----------
            DAL_Rol dalRol = new DAL_Rol();

            BLL_Rol bllRol = new BLL_Rol();

            List<Servicio_Familia> roles = dalRol.ListarRoles();

            List<Servicio_Familia> rolesCompletos = new List<Servicio_Familia>();

            foreach (var rol in roles)
            {
                rolesCompletos.Add(
                    bllRol.ObtenerRolCompleto(rol.IdRol));
            }

            var errorRol = ValidarIntegridad(
                rolesCompletos,
                "Rol");

            //var errorRol = ValidarIntegridad(
            //    dalRol.ListarRoles(),
            //    "Rol");

            if (errorRol != null)
                errores.Add(errorRol);

            // ---------- Familia ----------
            DAL_Familia dalFamilia = new DAL_Familia();

            List<Servicio_Familia> familias = dalFamilia.ListarFamilias();

            List<Servicio_Familia> familiasCompletas = new List<Servicio_Familia>();

            BLL_Familia bllFamilia = new BLL_Familia();

            foreach (var f in familias)
            {
                familiasCompletas.Add(
                    bllFamilia.ObtenerFamiliaCompleta(f.IdRol));
            }

            var errorFamilia = ValidarIntegridad(
                familiasCompletas,
                "Familia");

            //var errorFamilia = ValidarIntegridad(
            //    dalFamilia.ListarFamilias(),
            //    "Familia");

            if (errorFamilia != null)
                errores.Add(errorFamilia);

            if (errores.Count > 0)
                throw new ExcepcionIntegridad(errores);
        }

        public void EliminarDigitoYRecalcular<T>(string idElementoEliminado, List<T> listaCompleta, string nombreTabla) where T : IVerificable
        {

            string nombreFila = $"{nombreTabla}_{idElementoEliminado}";
            dalDigito.EliminarRegistroDigito(nombreFila);


            var listaOrdenada = listaCompleta.OrderBy(x => x.ObtenerIdentificadorFila()).ToList();
            string cadenaAcumulada = "";

            foreach (T registro in listaOrdenada)
            {
                cadenaAcumulada += servicioCalcular.CalcularDVH(registro);
            }

            string dvvFinal = servicioCalcular.CalcularHash(cadenaAcumulada);
            string nombreMaestro = $"{nombreTabla}_MAESTRO";

            Servicio_DigitoVerificadorVertical nuevoDVV = new Servicio_DigitoVerificadorVertical(dvvFinal, nombreMaestro);
            dalDigito.GuardarDVV(nuevoDVV);
        }


        public void ActualizarDigitos<T>(T entidadModificada, List<T> listaCompleta, string nombreTabla) where T : IVerificable
        {
            
            string dvhCalculado = servicioCalcular.CalcularDVH(entidadModificada);
            string nombreFila = $"{nombreTabla}_{entidadModificada.ObtenerIdentificadorFila()}";

            Servicio_DigitoVerificadorVertical nuevoDVH = new Servicio_DigitoVerificadorVertical();
            nuevoDVH.Nombre = nombreFila;
            nuevoDVH.DVH = dvhCalculado;

            dalDigito.GuardarDVH(nuevoDVH);

            var listaOrdenada = listaCompleta.OrderBy(x => x.ObtenerIdentificadorFila()).ToList();

            string cadenaAcumulada = "";
            foreach (T registro in listaOrdenada)
            {

                cadenaAcumulada += servicioCalcular.CalcularDVH(registro);
            }

            string dvvFinal = servicioCalcular.CalcularHash(cadenaAcumulada);
            string nombreMaestro = $"{nombreTabla}_MAESTRO";


            Servicio_DigitoVerificadorVertical nuevoDVV = new Servicio_DigitoVerificadorVertical(dvvFinal, nombreMaestro);

            dalDigito.GuardarDVV(nuevoDVV);
        }

        public void RecalcularDigitos()
        {
            string log = SessionManager.GetInstancia().GetUsuarioActual().Login;
            RecalcularUsuarios(log);
            RecalcularRoles(log);
            RecalcularFamilias(log);
            RecalcularIdiomas(log);
            RecalcularPermisos(log);

            ///negocio
            RecalcularClientes_DNI853(log);
            RecalcularEntradas_DNI853(log);
            RecalcularFacturas_DNI853(log);
            RecalcularFunciones_DNI853(log);
            RecalcularMediosPago_DNI853(log);
            RecalcularObras_DNI853(log);
            RecalcularPromociones_DNI853(log);
            RecalcularSalas_DNI853(log);
            RecalcularSectores_DNI853(log);
        }

        private void RecalcularUsuarios(string log)
        {
            dalDigito.EliminarDVHDeTabla("Usuario");
            List<Servicio_Usuario> usuarios = dalUsuario.ListarUsuarios().OrderBy(u => u.ObtenerIdentificadorFila()).ToList();
            string cadenaDVV = "";

            foreach (Servicio_Usuario usuario in usuarios)
            {
                string dvh = servicioCalcular.CalcularDVH(usuario);

                Servicio_DigitoVerificadorVertical reg = new Servicio_DigitoVerificadorVertical();

                reg.Nombre = "Usuario_" + usuario.ObtenerIdentificadorFila();
                reg.DVH = dvh;

                dalDigito.GuardarDVH(reg);

                cadenaDVV += dvh;
            }

            string dvv = servicioCalcular.CalcularHash(cadenaDVV);

            Servicio_DigitoVerificadorVertical maestro = new Servicio_DigitoVerificadorVertical();

            maestro.Nombre = "Usuario_MAESTRO";
            maestro.DVV = dvv;

            dalDigito.GuardarDVV(maestro);

            bllBitacora.RegistrarBitacora( "Recalculo de Dígitos Verificadores de Usuario", log,"Seguridad",1);     
        }

        private void RecalcularRoles(string log)
        {
            BLL_Rol bllRol = new BLL_Rol();

            // Validar integridad del árbol del rol antes de recalcular DV
            bllRol.ValidarIntegridadRoles();

            dalDigito.EliminarDVHDeTabla("Rol");

            DAL_Rol dalRol = new DAL_Rol();
            List<Servicio_Familia> roles = dalRol.ListarRoles().OrderBy(r => r.ObtenerIdentificadorFila()) .ToList();

            string cadenaDVV = "";
            foreach (Servicio_Familia rol in roles)
            {
                Servicio_Familia rolCompleto =
                    bllRol.ObtenerRolCompleto(rol.IdRol);

                string dvh = servicioCalcular.CalcularDVH(rolCompleto);

                Servicio_DigitoVerificadorVertical reg =
                    new Servicio_DigitoVerificadorVertical
                    {
                        Nombre = "Rol_" + rol.IdRol,
                        DVH = dvh
                    };

                dalDigito.GuardarDVH(reg);

                cadenaDVV += dvh;
            }

            //foreach (Servicio_Familia rol in roles)
            //{
            //    string dvh = servicioCalcular.CalcularDVH(rol);
            //    Servicio_DigitoVerificadorVertical reg = new Servicio_DigitoVerificadorVertical
            //    {
            //        Nombre = "Rol_" + rol.ObtenerIdentificadorFila(),
            //        DVH = dvh
            //    };

            //    dalDigito.GuardarDVH(reg);
            //    cadenaDVV += dvh;
            //}

            string dvv = servicioCalcular.CalcularHash(cadenaDVV);
            Servicio_DigitoVerificadorVertical maestro = new Servicio_DigitoVerificadorVertical(dvv, "Rol_MAESTRO");
            dalDigito.GuardarDVV(maestro);

            bllBitacora.RegistrarBitacora("Recalculo de Dígitos Verificadores de Roles", log , "Seguridad", 1);
        }

        private void RecalcularFamilias(string log)
        {
            BLL_Familia bllFamilia = new BLL_Familia();

            bllFamilia.ValidarIntegridadJerarquia();

            dalDigito.EliminarDVHDeTabla("Familia");

            DAL_Familia dalFam = new DAL_Familia();

            List<Servicio_Familia> familias = dalFam.ListarFamilias()
                .OrderBy(f => f.ObtenerIdentificadorFila())
                .ToList();

            string cadenaDVV = "";

            foreach (Servicio_Familia familia in familias)
            {
                // Cargar la familia completa con permisos y subfamilias
                Servicio_Familia familiaCompleta =
                    bllFamilia.ObtenerFamiliaCompleta(familia.IdRol);

                string dvh = servicioCalcular.CalcularDVH(familiaCompleta);

                Servicio_DigitoVerificadorVertical reg = new Servicio_DigitoVerificadorVertical
                {
                    Nombre = "Familia_" + familia.IdRol,
                    DVH = dvh
                };

                dalDigito.GuardarDVH(reg);

                cadenaDVV += dvh;
            }

            //DAL_Familia dalFam = new DAL_Familia("Data Source=.;Initial Catalog=BD_CuentaClara;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            //List<Servicio_Familia> familias = dalFam.ListarFamilias() .OrderBy(f => f.ObtenerIdentificadorFila()) .ToList();

            //string cadenaDVV = "";

            //foreach (Servicio_Familia familia in familias)
            //{
            //    string dvh = servicioCalcular.CalcularDVH(familia);
            //    Servicio_DigitoVerificadorVertical reg = new Servicio_DigitoVerificadorVertical
            //    {
            //        Nombre = "Familia_" + familia.ObtenerIdentificadorFila(),
            //        DVH = dvh
            //    };

            //    dalDigito.GuardarDVH(reg);
            //    cadenaDVV += dvh;
            //}

            string dvv = servicioCalcular.CalcularHash(cadenaDVV);
            Servicio_DigitoVerificadorVertical maestro = new Servicio_DigitoVerificadorVertical(dvv, "Familia_MAESTRO");
            dalDigito.GuardarDVV(maestro);

            bllBitacora.RegistrarBitacora("Recalculo de Dígitos Verificadores de Familias", log, "Seguridad", 1);
        }


        private void RecalcularPermisos(string log)
        {
            dalDigito.EliminarDVHDeTabla("Permiso");

            List<Servicio_Permiso> permisos =
                dalPermiso.ListarPermisos()
                          .OrderBy(p => p.ObtenerIdentificadorFila())
                          .ToList();

            string cadenaDVV = "";

            foreach (Servicio_Permiso permiso in permisos)
            {
                string dvh = servicioCalcular.CalcularDVH(permiso);

                Servicio_DigitoVerificadorVertical reg =
                    new Servicio_DigitoVerificadorVertical();

                reg.Nombre = "Permiso_" + permiso.ObtenerIdentificadorFila();
                reg.DVH = dvh;

                dalDigito.GuardarDVH(reg);

                cadenaDVV += dvh;
            }

            string dvv = servicioCalcular.CalcularHash(cadenaDVV);

            Servicio_DigitoVerificadorVertical maestro =
                new Servicio_DigitoVerificadorVertical();

            maestro.Nombre = "Permiso_MAESTRO";
            maestro.DVV = dvv;

            dalDigito.GuardarDVV(maestro);

            bllBitacora.RegistrarBitacora(
                "Recalculo de Dígitos Verificadores de Permisos",
                log,
                "Seguridad",
                1);
        }


        private void RecalcularIdiomas(string log)
        {
            dalDigito.EliminarDVHDeTabla("Idioma");

            List<Servicio_Idioma> idiomas =
                dalIdioma.DameIdiomasBD()
                         .OrderBy(i => i.ObtenerIdentificadorFila())
                         .ToList();

            string cadenaDVV = "";

            foreach (Servicio_Idioma idioma in idiomas)
            {
                string dvh = servicioCalcular.CalcularDVH(idioma);

                Servicio_DigitoVerificadorVertical reg =
                    new Servicio_DigitoVerificadorVertical();

                reg.Nombre = "Idioma_" + idioma.ObtenerIdentificadorFila();
                reg.DVH = dvh;

                dalDigito.GuardarDVH(reg);

                cadenaDVV += dvh;
            }

            string dvv = servicioCalcular.CalcularHash(cadenaDVV);
            
            Servicio_DigitoVerificadorVertical maestro =
                new Servicio_DigitoVerificadorVertical();

            maestro.Nombre = "Idioma_MAESTRO";
            maestro.DVV = dvv;

            dalDigito.GuardarDVV(maestro);

            bllBitacora.RegistrarBitacora(
                "Recalculo de Dígitos Verificadores de Idiomas",
                log,
                "Seguridad",
                1);
        }

        private void RecalcularClientes_DNI853(string log_DNI853)
        {
            dalDigito.EliminarDVHDeTabla("Cliente_DNI853");

            DAL_Cliente_DNI853 dalCliente_DNI853 = new DAL_Cliente_DNI853();
            List<BE_Cliente_DNI853> clientes_DNI853 = dalCliente_DNI853.ListarClientes_DNI853()
                .OrderBy(c_DNI853 => c_DNI853.ObtenerIdentificadorFila())
                .ToList();

            string cadenaDVV_DNI853 = "";

            foreach (BE_Cliente_DNI853 cliente_DNI853 in clientes_DNI853)
            {
                string dvh_DNI853 = servicioCalcular.CalcularDVH(cliente_DNI853);

                Servicio_DigitoVerificadorVertical reg_DNI853 = new Servicio_DigitoVerificadorVertical();
                reg_DNI853.Nombre = "Cliente_DNI853_" + cliente_DNI853.ObtenerIdentificadorFila();
                reg_DNI853.DVH = dvh_DNI853;

                dalDigito.GuardarDVH(reg_DNI853);
                cadenaDVV_DNI853 += dvh_DNI853;
            }

            string dvvFinal_DNI853 = servicioCalcular.CalcularHash(cadenaDVV_DNI853);

            Servicio_DigitoVerificadorVertical maestro_DNI853 = new Servicio_DigitoVerificadorVertical();
            maestro_DNI853.Nombre = "Cliente_DNI853_MAESTRO";
            maestro_DNI853.DVV = dvvFinal_DNI853;

            dalDigito.GuardarDVV(maestro_DNI853);

            bllBitacora.RegistrarBitacora("Recalculo de Dígitos Verificadores de Clientes", log_DNI853, "Seguridad", 1);
        }

        private void RecalcularEntradas_DNI853(string log_DNI853)
        {
            dalDigito.EliminarDVHDeTabla("Entrada_DNI853");

            DAL_Entrada_DNI853 dalEntrada_DNI853 = new DAL_Entrada_DNI853();
            List<BE_Entrada_DNI853> entradas_DNI853 = dalEntrada_DNI853.ListarEntradas_DNI853()
                .OrderBy(e_DNI853 => e_DNI853.ObtenerIdentificadorFila())
                .ToList();

            string cadenaDVV_DNI853 = "";

            foreach (BE_Entrada_DNI853 entrada_DNI853 in entradas_DNI853)
            {
                string dvh_DNI853 = servicioCalcular.CalcularDVH(entrada_DNI853);

                Servicio_DigitoVerificadorVertical reg_DNI853 = new Servicio_DigitoVerificadorVertical();
                reg_DNI853.Nombre = "Entrada_DNI853_" + entrada_DNI853.ObtenerIdentificadorFila();
                reg_DNI853.DVH = dvh_DNI853;

                dalDigito.GuardarDVH(reg_DNI853);
                cadenaDVV_DNI853 += dvh_DNI853;
            }

            string dvvFinal_DNI853 = servicioCalcular.CalcularHash(cadenaDVV_DNI853);

            Servicio_DigitoVerificadorVertical maestro_DNI853 = new Servicio_DigitoVerificadorVertical();
            maestro_DNI853.Nombre = "Entrada_DNI853_MAESTRO";
            maestro_DNI853.DVV = dvvFinal_DNI853;

            dalDigito.GuardarDVV(maestro_DNI853);

            bllBitacora.RegistrarBitacora("Recalculo de Dígitos Verificadores de Entradas", log_DNI853, "Seguridad", 1);
        }

        private void RecalcularFacturas_DNI853(string log_DNI853)
        {
            dalDigito.EliminarDVHDeTabla("Factura_DNI853");

            DAL_Factura_DNI853 dalFactura_DNI853 = new DAL_Factura_DNI853();
            List<BE_Factura_DNI853> facturas_DNI853 = dalFactura_DNI853.ListarFacturas_DNI853()
                .OrderBy(f_DNI853 => f_DNI853.ObtenerIdentificadorFila())
                .ToList();

            string cadenaDVV_DNI853 = "";

            foreach (BE_Factura_DNI853 factura_DNI853 in facturas_DNI853)
            {
                string dvh_DNI853 = servicioCalcular.CalcularDVH(factura_DNI853);

                Servicio_DigitoVerificadorVertical reg_DNI853 = new Servicio_DigitoVerificadorVertical();
                reg_DNI853.Nombre = "Factura_DNI853_" + factura_DNI853.ObtenerIdentificadorFila();
                reg_DNI853.DVH = dvh_DNI853;

                dalDigito.GuardarDVH(reg_DNI853);
                cadenaDVV_DNI853 += dvh_DNI853;
            }

            string dvvFinal_DNI853 = servicioCalcular.CalcularHash(cadenaDVV_DNI853);

            Servicio_DigitoVerificadorVertical maestro_DNI853 = new Servicio_DigitoVerificadorVertical();
            maestro_DNI853.Nombre = "Factura_DNI853_MAESTRO";
            maestro_DNI853.DVV = dvvFinal_DNI853;

            dalDigito.GuardarDVV(maestro_DNI853);

            bllBitacora.RegistrarBitacora("Recalculo de Dígito Verificador de Facturas", log_DNI853, "Seguridad", 1);
        }

        private void RecalcularFunciones_DNI853(string log_DNI853)
        {
            dalDigito.EliminarDVHDeTabla("Funcion_DNI853");

            DAL_Funcion_DNI853 dalFuncion_DNI853 = new DAL_Funcion_DNI853();
            List<BE_Funcion_DNI853> funciones_DNI853 = dalFuncion_DNI853.ListarFunciones_DNI853()
                .OrderBy(f_DNI853 => f_DNI853.ObtenerIdentificadorFila())
                .ToList();

            string cadenaDVV_DNI853 = "";

            foreach (BE_Funcion_DNI853 funcion_DNI853 in funciones_DNI853)
            {
                string dvh_DNI853 = servicioCalcular.CalcularDVH(funcion_DNI853);

                Servicio_DigitoVerificadorVertical reg_DNI853 = new Servicio_DigitoVerificadorVertical();
                reg_DNI853.Nombre = "Funcion_DNI853_" + funcion_DNI853.ObtenerIdentificadorFila();
                reg_DNI853.DVH = dvh_DNI853;

                dalDigito.GuardarDVH(reg_DNI853);
                cadenaDVV_DNI853 += dvh_DNI853;
            }

            string dvvFinal_DNI853 = servicioCalcular.CalcularHash(cadenaDVV_DNI853);

            Servicio_DigitoVerificadorVertical maestro_DNI853 = new Servicio_DigitoVerificadorVertical();
            maestro_DNI853.Nombre = "Funcion_DNI853_MAESTRO";
            maestro_DNI853.DVV = dvvFinal_DNI853;

            dalDigito.GuardarDVV(maestro_DNI853);

            bllBitacora.RegistrarBitacora("Recalculo de Dígitos Verificadores de Funciones", log_DNI853, "Seguridad", 1);
        }

        private void RecalcularMediosPago_DNI853(string log_DNI853)
        {
            dalDigito.EliminarDVHDeTabla("MedioPago_DNI853");

            DAL_MedioPago_DNI853 dalMedioPago_DNI853 = new DAL_MedioPago_DNI853();
            List<BE_MedioPago_DNI853> medios_DNI853 = dalMedioPago_DNI853.ObtenerMediosDePago_DNI853()
                .OrderBy(m_DNI853 => m_DNI853.ObtenerIdentificadorFila())
                .ToList();

            string cadenaDVV_DNI853 = "";

            foreach (BE_MedioPago_DNI853 medio_DNI853 in medios_DNI853)
            {
                string dvh_DNI853 = servicioCalcular.CalcularDVH(medio_DNI853);

                Servicio_DigitoVerificadorVertical reg_DNI853 = new Servicio_DigitoVerificadorVertical();
                reg_DNI853.Nombre = "MedioPago_DNI853_" + medio_DNI853.ObtenerIdentificadorFila();
                reg_DNI853.DVH = dvh_DNI853;

                dalDigito.GuardarDVH(reg_DNI853);
                cadenaDVV_DNI853 += dvh_DNI853;
            }

            string dvvFinal_DNI853 = servicioCalcular.CalcularHash(cadenaDVV_DNI853);

            Servicio_DigitoVerificadorVertical maestro_DNI853 = new Servicio_DigitoVerificadorVertical();
            maestro_DNI853.Nombre = "MedioPago_DNI853_MAESTRO";
            maestro_DNI853.DVV = dvvFinal_DNI853;

            dalDigito.GuardarDVV(maestro_DNI853);

            bllBitacora.RegistrarBitacora("Recalculo de Dígitos Verificadores de Medios de Pago", log_DNI853, "Seguridad", 1);
        }

        private void RecalcularObras_DNI853(string log_DNI853)
        {
            dalDigito.EliminarDVHDeTabla("Obra_DNI853");

            DAL_Obra_DNI853 dalObra_DNI853 = new DAL_Obra_DNI853();
            List<BE_Obra_DNI853> obras_DNI853 = dalObra_DNI853.ListarObras_DNI853()
                .OrderBy(o_DNI853 => o_DNI853.ObtenerIdentificadorFila())
                .ToList();

            string cadenaDVV_DNI853 = "";

            foreach (BE_Obra_DNI853 obra_DNI853 in obras_DNI853)
            {
                string dvh_DNI853 = servicioCalcular.CalcularDVH(obra_DNI853);

                Servicio_DigitoVerificadorVertical reg_DNI853 = new Servicio_DigitoVerificadorVertical();
                reg_DNI853.Nombre = "Obra_DNI853_" + obra_DNI853.ObtenerIdentificadorFila();
                reg_DNI853.DVH = dvh_DNI853;

                dalDigito.GuardarDVH(reg_DNI853);
                cadenaDVV_DNI853 += dvh_DNI853;
            }

            string dvvFinal_DNI853 = servicioCalcular.CalcularHash(cadenaDVV_DNI853);

            Servicio_DigitoVerificadorVertical maestro_DNI853 = new Servicio_DigitoVerificadorVertical();
            maestro_DNI853.Nombre = "Obra_DNI853_MAESTRO";
            maestro_DNI853.DVV = dvvFinal_DNI853;

            dalDigito.GuardarDVV(maestro_DNI853);

            bllBitacora.RegistrarBitacora("Recalculo de Dígitos Verificadores de Obras", log_DNI853, "Seguridad", 1);
        }

        private void RecalcularPromociones_DNI853(string log_DNI853)
        {
            dalDigito.EliminarDVHDeTabla("Promocion_DNI853");

            DAL_Promocion_DNI853 dalPromocion_DNI853 = new DAL_Promocion_DNI853();
            List<BE.BE_Promocion_DNI853> promociones_DNI853 = dalPromocion_DNI853.ListarPromociones_DNI853()
                .OrderBy(p_DNI853 => p_DNI853.ObtenerIdentificadorFila())
                .ToList();

            string cadenaDVV_DNI853 = "";

            foreach (BE.BE_Promocion_DNI853 promocion_DNI853 in promociones_DNI853)
            {
                string dvh_DNI853 = servicioCalcular.CalcularDVH(promocion_DNI853);

                Servicio_DigitoVerificadorVertical reg_DNI853 = new Servicio_DigitoVerificadorVertical();
                reg_DNI853.Nombre = "Promocion_DNI853_" + promocion_DNI853.ObtenerIdentificadorFila();
                reg_DNI853.DVH = dvh_DNI853;

                dalDigito.GuardarDVH(reg_DNI853);
                cadenaDVV_DNI853 += dvh_DNI853;
            }

            string dvvFinal_DNI853 = servicioCalcular.CalcularHash(cadenaDVV_DNI853);

            Servicio_DigitoVerificadorVertical maestro_DNI853 = new Servicio_DigitoVerificadorVertical();
            maestro_DNI853.Nombre = "Promocion_DNI853_MAESTRO";
            maestro_DNI853.DVV = dvvFinal_DNI853;

            dalDigito.GuardarDVV(maestro_DNI853);

            bllBitacora.RegistrarBitacora("Recalculo de Dígitos Verificadores de Promociones", log_DNI853, "Seguridad", 1);
        }

        private void RecalcularSalas_DNI853(string log_DNI853)
        {
            dalDigito.EliminarDVHDeTabla("Sala_DNI853");

            DAL_Sala_DNI853 dalSala_DNI853 = new DAL_Sala_DNI853();
            List<BE_Sala_DNI853> salas_DNI853 = dalSala_DNI853.ListarSalas_DNI853()
                .OrderBy(s_DNI853 => s_DNI853.ObtenerIdentificadorFila())
                .ToList();

            string cadenaDVV_DNI853 = "";

            foreach (BE_Sala_DNI853 sala_DNI853 in salas_DNI853)
            {
                string dvh_DNI853 = servicioCalcular.CalcularDVH(sala_DNI853);

                Servicio_DigitoVerificadorVertical reg_DNI853 = new Servicio_DigitoVerificadorVertical();
                reg_DNI853.Nombre = "Sala_DNI853_" + sala_DNI853.ObtenerIdentificadorFila();
                reg_DNI853.DVH = dvh_DNI853;

                dalDigito.GuardarDVH(reg_DNI853);
                cadenaDVV_DNI853 += dvh_DNI853;
            }

            string dvvFinal_DNI853 = servicioCalcular.CalcularHash(cadenaDVV_DNI853);

            Servicio_DigitoVerificadorVertical maestro_DNI853 = new Servicio_DigitoVerificadorVertical();
            maestro_DNI853.Nombre = "Sala_DNI853_MAESTRO";
            maestro_DNI853.DVV = dvvFinal_DNI853;

            dalDigito.GuardarDVV(maestro_DNI853);

            bllBitacora.RegistrarBitacora("Recalculo de Dígitos Verificadores de Salas", log_DNI853, "Seguridad", 1);
        }

        private void RecalcularSectores_DNI853(string log_DNI853)
        {
            dalDigito.EliminarDVHDeTabla("Sector_DNI853");

            DAL_Sector_DNI853 dalSector_DNI853 = new DAL_Sector_DNI853();
            List<BE.BE_Sector_DNI853> sectores_DNI853 = dalSector_DNI853.ListarTodosSectores_DNI853()
                .OrderBy(s_DNI853 => s_DNI853.ObtenerIdentificadorFila())
                .ToList();

            string cadenaDVV_DNI853 = "";

            foreach (BE.BE_Sector_DNI853 sector_DNI853 in sectores_DNI853)
            {
                string dvh_DNI853 = servicioCalcular.CalcularDVH(sector_DNI853);

                Servicio_DigitoVerificadorVertical reg_DNI853 = new Servicio_DigitoVerificadorVertical();
                reg_DNI853.Nombre = "Sector_DNI853_" + sector_DNI853.ObtenerIdentificadorFila();
                reg_DNI853.DVH = dvh_DNI853;

                dalDigito.GuardarDVH(reg_DNI853);
                cadenaDVV_DNI853 += dvh_DNI853;
            }

            string dvvFinal_DNI853 = servicioCalcular.CalcularHash(cadenaDVV_DNI853);

            Servicio_DigitoVerificadorVertical maestro_DNI853 = new Servicio_DigitoVerificadorVertical();
            maestro_DNI853.Nombre = "Sector_DNI853_MAESTRO";
            maestro_DNI853.DVV = dvvFinal_DNI853;

            dalDigito.GuardarDVV(maestro_DNI853);

            bllBitacora.RegistrarBitacora("Recalculo de Dígitos Verificadores de Sectores", log_DNI853, "Seguridad", 1);
        }
    }
}
