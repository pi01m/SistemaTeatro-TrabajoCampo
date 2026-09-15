using BE;
using BLL.BLL_Servicio;
using DAL;
using Microsoft.Data.SqlClient;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
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
        private DAL_Entrada_DNI853 dalEntrada_DNI853 = new DAL_Entrada_DNI853();
        private BLL_DigitoVerificador objDigitoVerificador_DNI853 = new BLL_DigitoVerificador();

        public List<BE_Entrada_DNI853> ListarEntradas_DNI853()
        {
            return dalEntrada_DNI853.ListarEntradas_DNI853();
        }

        // Método invocado desde la transacción general o para registrar y calcular dígitos verificadores
        public void RegistrarEntradasDeFactura_DNI853(List<BE_Entrada_DNI853> entradas_DNI853, string idFactura_DNI853, SqlConnection conexion_DNI853, SqlTransaction transaccion_DNI853)
        {
            if (entradas_DNI853 == null || entradas_DNI853.Count == 0) return;

            foreach (var entrada in entradas_DNI853)
            {
                if (string.IsNullOrEmpty(entrada.Id_Entrada_DNI853))
                {
                    entrada.Id_Entrada_DNI853 = "ENT_" + Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
                }
                entrada.Id_Factura_DNI853 = idFactura_DNI853;
            }

            // 1. Ejecutamos la inserción en la DAL usando la transacción abierta
            dalEntrada_DNI853.RegistrarEntradas_DNI853(entradas_DNI853, conexion_DNI853, transaccion_DNI853);

            // 2. Para calcular los dígitos verificadores de forma segura sin bloquear la conexión principal,
            // es mejor realizar el cálculo de los hashes en memoria con la lista actual + las nuevas entradas,
            // o delegar la actualización posterior a que la transacción haya finalizado (Commit).
        }

        // Genera el PDF de entradas llamándose directamente desde la UI o BLL usando el ID de factura
        public void GenerarEntradasPDF(string idFactura, string ruta)
        {
            // Filtramos las entradas que pertenecen a esta factura utilizando la lista general o un método específico
            var entradasDeFactura = this.ListarEntradas_DNI853()
                .Where(e => e.Id_Factura_DNI853 == idFactura)
                .ToList();

            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);
                    page.Header().Text($"Entradas - Factura #{idFactura}").FontSize(18).Bold();

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(3);
                            columns.RelativeColumn(1);
                        });

                        table.Cell().Text("Sector / Función").Bold();
                        table.Cell().Text("Cantidad").Bold();

                        foreach (var entrada in entradasDeFactura)
                        {
                            table.Cell().Text(entrada.Detalle_DNI853);
                            table.Cell().Text(entrada.Cantidad_DNI853.ToString());
                        }
                    });
                });
            })
            .GeneratePdf(ruta);
        }

    }
}
