using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class BLL_MedioPago_DNI853
    {
        private DAL_MedioPago_DNI853 dalMedioPago_DNI853 = new DAL_MedioPago_DNI853();

        public List<BE_MedioPago_DNI853> ObtenerMediosDePago_DNI853()
        {
            return dalMedioPago_DNI853.ObtenerMediosDePago_DNI853();
        }
    }
}
