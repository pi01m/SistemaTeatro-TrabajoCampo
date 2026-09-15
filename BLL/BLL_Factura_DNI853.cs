using BE;
using BLL.BLL_Servicio;
using DAL;
using Microsoft.Data.SqlClient;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL
{
    public class BLL_Factura_DNI853
    {
        private DAL_Factura_DNI853 dalFactura_DNI853 = new DAL_Factura_DNI853();
        private BLL_Entrada_DNI853 bllEntrada_DNI853 = new BLL_Entrada_DNI853();
        private string _connectionString_DNI853 = DAL_ConexionDB.ObtenerCadena();

        public string RegistrarFactura_DNI853(BE_Factura_DNI853 factura_DNI853, List<BE_Entrada_DNI853> entradas_DNI853)
        {
            if (factura_DNI853 == null || entradas_DNI853 == null || entradas_DNI853.Count == 0)
                throw new Exception("err_DatosFacturaIncompletos");

            if (string.IsNullOrEmpty(factura_DNI853.Id_Factura_DNI853))
            {
                factura_DNI853.Id_Factura_DNI853 = "FAC_" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            }

            string idFacturaGenerada = string.Empty;

            // Manejo de la transacción unificada para asegurar atomicidad
            using (SqlConnection conexion_DNI853 = new SqlConnection(_connectionString_DNI853))
            {
                conexion_DNI853.Open();
                using (SqlTransaction transaccion_DNI853 = conexion_DNI853.BeginTransaction())
                {
                    try
                    {
                        // 1. Registramos la cabecera de la factura
                        idFacturaGenerada = dalFactura_DNI853.RegistrarFacturaUnica_DNI853(factura_DNI853, conexion_DNI853, transaccion_DNI853);

                        // 2. Registramos las entradas con la misma transacción
                        bllEntrada_DNI853.RegistrarEntradasDeFactura_DNI853(entradas_DNI853, idFacturaGenerada, conexion_DNI853, transaccion_DNI853);

                        // 3. Confirmamos la transacción (Aquí se libera el bloqueo de la BD)
                        transaccion_DNI853.Commit();
                    }
                    catch
                    {
                        transaccion_DNI853.Rollback();
                        throw;
                    }
                }
            }

            // 4. Actualizar Dígitos Verificadores con la conexión ya cerrada y libre de bloqueos
            if (!string.IsNullOrEmpty(idFacturaGenerada))
            {
                BLL_DigitoVerificador objDigitoVerificador = new BLL_DigitoVerificador();

                // Actualizar Dígito de la Factura
                List<BE_Factura_DNI853> listaFacturas = dalFactura_DNI853.ListarFacturas_DNI853();
                objDigitoVerificador.ActualizarDigitos(factura_DNI853, listaFacturas, "Factura_DNI853");

                // Actualizar Dígitos de las Entradas insertadas
                List<BE_Entrada_DNI853> listaEntradas = bllEntrada_DNI853.ListarEntradas_DNI853();
                foreach (var entrada in entradas_DNI853)
                {
                    objDigitoVerificador.ActualizarDigitos(entrada, listaEntradas, "Entrada_DNI853");
                }
            }

            return idFacturaGenerada;
        }

        public void GenerarFacturaPDF(string idFactura, string ruta)
        {
            DataSet ds = dalFactura_DNI853.ObtenerDatosFacturaDesconectado_DNI853(idFactura);
            if (ds.Tables["Factura"].Rows.Count == 0) return;

            DataRow filaFactura = ds.Tables["Factura"].Rows[0];
            DataTable tablaEntradas = ds.Tables["Entrada"];

            // Extraer datos de la factura
            string dniCliente = filaFactura["Id_Cliente_DNI853"].ToString();
            string loginVendedor = filaFactura["Vendedor_DNI853"] != DBNull.Value ? filaFactura["Vendedor_DNI853"].ToString() : "Sistema";
            string tipoPago = filaFactura["TipoPago_DNI853"].ToString();
            string banco = filaFactura["Banco_DNI853"] != DBNull.Value ? filaFactura["Banco_DNI853"].ToString() : string.Empty;
            string nroTarjeta = filaFactura["NumeroTarjeta_DNI853"] != DBNull.Value ? filaFactura["NumeroTarjeta_DNI853"].ToString() : string.Empty;
            string vencimientoTarjeta = filaFactura["FechaVencimiento_DNI853"] != DBNull.Value ? filaFactura["FechaVencimiento_DNI853"].ToString() : string.Empty;
            DateTime fechaEmision = Convert.ToDateTime(filaFactura["Fecha_DNI853"]);
            decimal importeTotal = Convert.ToDecimal(filaFactura["ImporteTotal_DNI853"]);
            string idPromocion = filaFactura["Id_Promocion_DNI853"] != DBNull.Value ? filaFactura["Id_Promocion_DNI853"].ToString() : string.Empty;

            // Buscar Nombre y Apellido del Cliente
            BLL_Cliente_DNI853 bllCliente = new BLL_Cliente_DNI853();
            BE_Cliente_DNI853 cliente = bllCliente.BuscarPorDNI_DNI853(dniCliente);
            string nombreCliente = cliente != null ? $"{cliente.Nombre_C_DNI853} {cliente.Apellido_C_DNI853}" : dniCliente;

            // Buscar Nombre y Apellido del Vendedor (a través de la BLL de usuarios o servicios)
            string nombreVendedor = loginVendedor;
            try
            {
                BLL_Rol bllRol = new BLL_Rol();
                // O puedes obtener el nombre del usuario logueado actualmente si coincide
                var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
                if (usuarioActual != null && usuarioActual.Login == loginVendedor)
                {
                    nombreVendedor = $"{usuarioActual.Login}"; // O su nombre real si tu entidad de usuario lo tiene
                }
            }
            catch { }

            // Buscar Datos de la Promoción usando su ID
            string nombrePromo = string.Empty;
            decimal valorDescuentoPromo = 0;
            if (!string.IsNullOrEmpty(idPromocion))
            {
                BLL_Promocion_DNI853 bllPromo = new BLL_Promocion_DNI853();
                var promoEncontrada = bllPromo.ObtenerPromocionesVigentes_DNI853()
                    .FirstOrDefault(p => p.IdPromo_DNI853 == idPromocion);

                if (promoEncontrada != null)
                {
                    nombrePromo = promoEncontrada.NombrePromo_DNI853;
                    valorDescuentoPromo = promoEncontrada.ValorDescuento_DNI853;
                }
            }

            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Size(QuestPDF.Helpers.PageSizes.A4);

                    // Cabecera del PDF
                    page.Header().Column(col =>
                    {
                        col.Item().Text("TeatroLux - Factura Oficial").FontSize(20).Bold().FontColor(QuestPDF.Helpers.Colors.Red.Medium);
                        col.Item().Text($"Comprobante Nro: {idFactura}").FontSize(12).SemiBold();
                        col.Item().LineHorizontal(1).LineColor(QuestPDF.Helpers.Colors.Grey.Lighten1);
                    });

                    // Contenido Principal
                    page.Content().Column(col =>
                    {
                        col.Spacing(10);
                        col.Item().PaddingBottom(5);

                        // Bloque de Datos (Cliente, Vendedor, Pago, Fechas)
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text($"Cliente: {nombreCliente}").Bold();
                                c.Item().Text($"DNI Cliente: {dniCliente}");
                                c.Item().Text($"Vendedor: {nombreVendedor}");
                            });
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text($"Fecha Emisión: {fechaEmision:dd/MM/yyyy HH:mm}").AlignRight();
                                c.Item().Text($"Tipo de Pago: {tipoPago}").AlignRight();
                                if (!string.IsNullOrEmpty(banco))
                                    c.Item().Text($"Banco: {banco} | Tarj: ****{nroTarjeta.Substring(Math.Max(0, nroTarjeta.Length - 4))}").AlignRight();
                                if (!string.IsNullOrEmpty(vencimientoTarjeta))
                                    c.Item().Text($"Vencimiento Tarjeta: {vencimientoTarjeta}").AlignRight();
                            });
                        });

                        col.Item().LineHorizontal(0.5f).LineColor(QuestPDF.Helpers.Colors.Grey.Lighten2);

                        // Tabla de Entradas
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                                columns.RelativeColumn(1);
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(QuestPDF.Helpers.Colors.Grey.Lighten3).Padding(5).Text("Detalle").Bold();
                                header.Cell().Background(QuestPDF.Helpers.Colors.Grey.Lighten3).Padding(5).Text("Cant.").Bold();
                                header.Cell().Background(QuestPDF.Helpers.Colors.Grey.Lighten3).Padding(5).Text("P. Unit.").Bold();
                                header.Cell().Background(QuestPDF.Helpers.Colors.Grey.Lighten3).Padding(5).Text("Subtotal").Bold();
                            });

                            foreach (DataRow fila in tablaEntradas.Rows)
                            {
                                table.Cell().Padding(5).Text(fila["Detalle_DNI853"].ToString());
                                table.Cell().Padding(5).Text(fila["Cantidad_DNI853"].ToString());
                                table.Cell().Padding(5).Text($"$ {Convert.ToDecimal(fila["PrecioUnitario_DNI853"]):N2}");
                                table.Cell().Padding(5).Text($"$ {Convert.ToDecimal(fila["Subtotal_DNI853"]):N2}");
                            }
                        });

                        col.Item().PaddingTop(10).LineHorizontal(0.5f).LineColor(QuestPDF.Helpers.Colors.Grey.Lighten2);

                        // Cálculo de Totales y Promoción
                        decimal subtotalBruto = 0;
                        foreach (DataRow fila in tablaEntradas.Rows)
                        {
                            subtotalBruto += Convert.ToDecimal(fila["Subtotal_DNI853"]);
                        }

                        col.Item().AlignRight().Column(c =>
                        {
                            c.Item().Text($"Subtotal: $ {subtotalBruto:N2}");

                            if (!string.IsNullOrEmpty(nombrePromo) && valorDescuentoPromo > 0)
                            {
                                c.Item().Text($"Promoción Aplicada ({nombrePromo}): - $ {valorDescuentoPromo:N2}").FontColor(QuestPDF.Helpers.Colors.Green.Darken2);
                            }

                            c.Item().PaddingTop(5).Text($"IMPORTE TOTAL: $ {importeTotal:N2}").FontSize(14).Bold();
                        });
                    });

                    // Pie de página
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Gracias por su compra en TeatroLux - Comprobante válido como entrada/factura. Página ");
                        x.CurrentPageNumber();
                    });
                });
            })
            .GeneratePdf(ruta);
        }
    }
}
