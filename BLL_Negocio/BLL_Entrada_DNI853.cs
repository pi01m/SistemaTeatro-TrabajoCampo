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
    public class BLL_Entrada_DNI853
    {
        private DAL_Entrada_DNI853 objDalEntrada_DNI853 = new DAL_Entrada_DNI853();
        private BLL_DigitoVerificador objBllDigitoVerif_DNI853 = new BLL_DigitoVerificador();
        private BLL_BitacoraEvento objBllBitacora_DNI853 = new BLL_BitacoraEvento();
        public List<BE_Entrada_DNI853> ListarEntradas_DNI853()
        {
            return objDalEntrada_DNI853.ListarEntradas_DNI853();
        }

        public void PrepararYRegistrarEntradas_DNI853(List<BE_Entrada_DNI853> entradasDelCarrito_DNI853, string idFactura_DNI853)
        {
            if (entradasDelCarrito_DNI853 == null || entradasDelCarrito_DNI853.Count == 0) return;

            List<BE_Entrada_DNI853> ticketsIndividualesParaBD = new List<BE_Entrada_DNI853>();

            // Desglosamos cada renglón del carrito según su cantidad
            foreach (var itemCarrito in entradasDelCarrito_DNI853)
            {
                int cantidad = itemCarrito.Cantidad_DNI853 > 0 ? itemCarrito.Cantidad_DNI853 : 1;

                for (int i = 0; i < cantidad; i++)
                {
                    BE_Entrada_DNI853 ticketIndividual = new BE_Entrada_DNI853
                    {
                        Id_Entrada_DNI853 = "ENT_" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper(),
                        Id_Factura_DNI853 = idFactura_DNI853,
                        IdFuncion_DNI853 = itemCarrito.IdFuncion_DNI853,
                        IdSector_DNI853 = itemCarrito.IdSector_DNI853,
                        Detalle_DNI853 = itemCarrito.Detalle_DNI853,
                        Cantidad_DNI853 = 1, // Unitario para la lógica interna si hace falta
                        PrecioUnitario_DNI853 = itemCarrito.PrecioUnitario_DNI853
                    };

                    ticketsIndividualesParaBD.Add(ticketIndividual);
                }
            }

            // 1. Guardamos los tickets independientes en la base de datos
            objDalEntrada_DNI853.RegistrarEntradas_DNI853(ticketsIndividualesParaBD);

            // 2. Registro de DVs post-inserción para cada ticket generado
            List<BE_Entrada_DNI853> listaTodas_DNI853 = objDalEntrada_DNI853.ListarEntradas_DNI853();
            foreach (var entradaInsertada in ticketsIndividualesParaBD)
            {
                objBllDigitoVerif_DNI853.ActualizarDigitos(entradaInsertada, listaTodas_DNI853, "Entrada_DNI853");
            }

            // 3. Bitácora
            var usuarioActual = SessionManager.GetInstancia().GetUsuarioActual();
            string loginUsuario = usuarioActual != null ? usuarioActual.Login : "Sistema";
            objBllBitacora_DNI853.RegistrarBitacora($"Registro de entradas", loginUsuario, "Ventas", 2);
        }

        // Genera el PDF de entradas llamándose directamente desde la UI o BLL usando el ID de factura
        public void GenerarEntradasPDF(string idFactura, string ruta)
        {
            var entradasDeFactura = this.ListarEntradas_DNI853()
                 .Where(e => e.Id_Factura_DNI853 == idFactura)
                 .ToList();

            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);

                    // --- CABECERA GENERAL DEL DOCUMENTO ---
                    page.Header().Column(col =>
                    {
                        col.Item().Text("TeatroLux").FontSize(26).Bold().FontColor(Colors.Red.Darken3);
                        col.Item().Text("Tickets Oficiales de Entrada").FontSize(14).SemiBold().FontColor(Colors.Grey.Darken2);
                        col.Item().Text($"Factura de respaldo: {idFactura}").FontSize(10).FontColor(Colors.Grey.Medium);
                        col.Item().PaddingBottom(20).LineHorizontal(2).LineColor(Colors.Red.Darken3);
                    });

                    // --- CUERPO DE TICKETS ---
                    page.Content().Column(col =>
                    {
                        col.Spacing(15);

                        foreach (var entrada in entradasDeFactura)
                        {
                            col.Item().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Row(row =>
                            {
                                // Información principal del evento
                                row.RelativeItem().Padding(12).Column(ticketDetails =>
                                {
                                    ticketDetails.Item().Text("TICKET INDIVIDUAL / ACCESO VÁLIDO").FontSize(8).Bold().FontColor(Colors.Green.Darken2);

                                    ticketDetails.Item().PaddingTop(6).Text(entrada.Detalle_DNI853)
                                        .FontSize(11).SemiBold().FontColor(Colors.Black);

                                    ticketDetails.Item().PaddingTop(10).Row(r =>
                                    {
                                        r.RelativeItem().Column(c =>
                                        {
                                            c.Item().Text("TIPO DE ACCESO").FontSize(7).Bold().FontColor(Colors.Grey.Darken2);
                                            c.Item().Text("General (1 Persona)").FontSize(10).Bold();
                                        });
                                        r.RelativeItem().Column(c =>
                                        {
                                            c.Item().Text("CÓDIGO DE TICKET").FontSize(7).Bold().FontColor(Colors.Grey.Darken2);
                                            c.Item().Text(entrada.Id_Entrada_DNI853).FontSize(10).Bold();
                                        });
                                    });
                                });

                                // Línea divisoria simulando troquel
                                row.ConstantItem(1).Background(Colors.White).LineVertical(1).LineColor(Colors.Grey.Medium);

                                // Talón de control (puerta)
                                row.ConstantItem(110).Background(Colors.Red.Darken3).Padding(12).Column(stub =>
                                {
                                    stub.Item().AlignCenter().Text("CONTROL").FontSize(10).Bold().FontColor(Colors.White);
                                    stub.Item().PaddingTop(10).AlignCenter().Text("1 PERSONA").FontSize(11).Bold().FontColor(Colors.White);
                                    stub.Item().PaddingTop(10).AlignCenter().Text(entrada.Id_Entrada_DNI853.Substring(0, Math.Min(entrada.Id_Entrada_DNI853.Length, 8)))
                                        .FontSize(8).FontColor(Colors.Grey.Lighten2);
                                });
                            });
                        }
                    });

                    // --- PIE DE PÁGINA ---
                    page.Footer().AlignCenter().Column(footer =>
                    {
                        footer.Item().Text("Presente este documento (impreso o digital) en el ingreso del teatro.").FontSize(10).Italic().FontColor(Colors.Grey.Darken1);
                        footer.Item().Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                            x.Span(" de ");
                            x.TotalPages();
                        });
                    });
                });
            })
            .GeneratePdf(ruta);
        }

    }
}
