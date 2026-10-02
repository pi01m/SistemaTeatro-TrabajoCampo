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
        private DAL_Factura_DNI853 objDalFactura_DNI853 = new DAL_Factura_DNI853();
        private BLL_DigitoVerificador objBllDigitoVerif_DNI853 = new BLL_DigitoVerificador();
        private BLL_BitacoraEvento objBllBitacora_DNI853 = new BLL_BitacoraEvento(); // Instancia de Bitácora

        // Inserta la Factura de forma independiente y recalcula los DVs
        public string RegistrarFacturaUnica_DNI853(BE_Factura_DNI853 factura_DNI853)
        {
            if (string.IsNullOrEmpty(factura_DNI853.Id_Factura_DNI853))
                factura_DNI853.Id_Factura_DNI853 = "FAC_" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper();

            string idGenerado_DNI853 = objDalFactura_DNI853.RegistrarFacturaUnica_DNI853(factura_DNI853);

            // Actualizamos DVs
            List<BE_Factura_DNI853> listaFacturas_DNI853 = objDalFactura_DNI853.ListarFacturas_DNI853();
            objBllDigitoVerif_DNI853.ActualizarDigitos(factura_DNI853, listaFacturas_DNI853, "Factura_DNI853");

            var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
            string loginUsuario = usuarioActual != null ? usuarioActual.Login : "Sistema";
            objBllBitacora_DNI853.RegistrarBitacora($"Factura registrada", loginUsuario, "Ventas", 2);
            return idGenerado_DNI853;
        }

        public void ValidarDatosTarjeta_DNI853(string banco, string numeroTarjeta, string fechaVencimiento)
        {
            if (string.IsNullOrWhiteSpace(banco))
                throw new Exception("err_BancoVacio");

            // Validar que la tarjeta tenga exactamente 16 dígitos y sean solo números
            if (string.IsNullOrWhiteSpace(numeroTarjeta) || numeroTarjeta.Length != 16 || !numeroTarjeta.All(char.IsDigit))
                throw new Exception("err_TarjetaInvalida");

            // Validar formato de fecha MM/AA
            if (string.IsNullOrWhiteSpace(fechaVencimiento) || !fechaVencimiento.Contains("/") || fechaVencimiento.Length != 5)
                throw new Exception("err_FormatoVencimiento");

            string[] partesFecha = fechaVencimiento.Split('/');
            if (partesFecha.Length != 2 || !int.TryParse(partesFecha[0], out int mes) || !int.TryParse(partesFecha[1], out int anio))
                throw new Exception("err_FormatoVencimiento");

            if (mes < 1 || mes > 12)
                throw new Exception("err_MesInvalido");

            // Validar que la tarjeta no esté vencida (comparando con el año y mes actual)
            int anioActual = DateTime.Now.Year % 100; // Obtenemos los últimos dos dígitos del año (ej: 2026 -> 26)
            int mesActual = DateTime.Now.Month;

            if (anio < anioActual || (anio == anioActual && mes < mesActual))
                throw new Exception("err_TarjetaVencida");
        }



        public void GenerarFacturaPDF(string idFactura, string ruta)
        {
            DataSet ds = objDalFactura_DNI853.ObtenerDatosFacturaDesconectado_DNI853(idFactura);
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

            // Buscar Nombre y Apellido del Vendedor
            string nombreVendedor = loginVendedor;
            try
            {
                var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
                if (usuarioActual != null && usuarioActual.Login == loginVendedor)
                {
                    nombreVendedor = $"{usuarioActual.Login}";
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

            // === AGRUPAR LAS ENTRADAS EN MEMORIA (Para mostrarlas como el carrito) ===
            var entradasAgrupadas = tablaEntradas.AsEnumerable()
                .GroupBy(row => new {
                    Detalle = row["Detalle_DNI853"].ToString(),
                    PrecioUnitario = Convert.ToDecimal(row["PrecioUnitario_DNI853"])
                })
                .Select(g => new {
                    Detalle = g.Key.Detalle,
                    Cantidad = g.Count(), // Cuenta cuántas entradas hay iguales para sumar la cantidad
                    PrecioUnitario = g.Key.PrecioUnitario,
                    Subtotal = g.Count() * g.Key.PrecioUnitario
                })
                .ToList();

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

                        // Tabla de Entradas Agrupadas
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

                            foreach (var grupo in entradasAgrupadas)
                            {
                                table.Cell().Padding(5).Text(grupo.Detalle);
                                table.Cell().Padding(5).Text(grupo.Cantidad.ToString());
                                table.Cell().Padding(5).Text($"$ {grupo.PrecioUnitario:N2}");
                                table.Cell().Padding(5).Text($"$ {grupo.Subtotal:N2}");
                            }
                        });

                        col.Item().PaddingTop(10).LineHorizontal(0.5f).LineColor(QuestPDF.Helpers.Colors.Grey.Lighten2);

                        // Cálculo de Totales y Promoción basados en los grupos
                        decimal subtotalBruto = entradasAgrupadas.Sum(g => g.Subtotal);

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
