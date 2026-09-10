using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio;
namespace BLL.BLL_Servicio
{
    public class BLL_PDF
    {
        private Servicio_PDF servicioPdf = new Servicio_PDF();
        private BLL_BitacoraEvento bllBitacora = new BLL_BitacoraEvento();
        private DataTable ConvertirListaADateTable(List<Servicio_Bitacora> lista)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("idEvento");
            tabla.Columns.Add("Evento");
            tabla.Columns.Add("Login");
            tabla.Columns.Add("Modulo");
            tabla.Columns.Add("Criticidad", typeof(int));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("Hora");

            foreach (var item in lista)
            {
                tabla.Rows.Add(item.id_Evento, item.Evento, item.Login, item.Modulo, item.Criticidad, item.Fecha, item.Hora);
            }
            return tabla;
        }
        public void ExportarBitacora(List<Servicio_Bitacora> listaEventos, string ruta, string login)
        {
            DataTable tabla = ConvertirListaADateTable(listaEventos);
            servicioPdf.GenerarBitacoraPDF(tabla, ruta);

            bllBitacora.RegistrarBitacora("Impresión/Exportación de Bitácora", login,"Adminitración",3);  
                
        }
    }
}

