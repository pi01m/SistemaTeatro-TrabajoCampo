using DAL;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.BLL_Servicio
{
    public class BLL_Idioma
    {
        private readonly DAL_Idioma _dalIdioma;
        public BLL_Idioma()
        {
            _dalIdioma = new DAL_Idioma();
        }

        public List<Servicio_Idioma> ListarIdiomas()
        {
            return _dalIdioma.ListarIdiomas();
        }

        public bool CrearIdioma(Servicio_Idioma idioma)
        {
            try
            {
                if (idioma == null)return false;
                if (string.IsNullOrWhiteSpace(idioma.Nombre))return false;
                if (_dalIdioma.ExisteIdioma(idioma.Nombre))return false;    

                bool resultado = _dalIdioma.CrearIdioma(idioma);

                return resultado;
            }
            catch
            {
                return false;
            }
        }

        public Servicio_Idioma ObtenerIdioma(string nombre)
        {
            return _dalIdioma.ObtenerIdioma(nombre);
        }

        public bool AgregarEtiqueta(string nombreIdioma, string clave, string texto)
        {
            Servicio_Idioma idioma =
        _dalIdioma.ObtenerIdioma(nombreIdioma);

            if (idioma == null)
                return false;

            foreach (Servicio_Etiqueta e in idioma.Etiquetas)
            {
                if (e.Clave == clave)
                {
                    return false;
                }
            }

            Servicio_Etiqueta etiqueta =
                new Servicio_Etiqueta();

            etiqueta.Clave = clave;
            etiqueta.Texto = texto;

            idioma.Etiquetas.Add(etiqueta);

            _dalIdioma.GuardarIdiomaActualizado(idioma);

            return true;
        }

        public bool ModificarEtiqueta(string nombreIdioma, string clave, string textoNuevo)
        {
            Servicio_Idioma idioma =_dalIdioma.ObtenerIdioma(nombreIdioma);
                
            if (idioma == null)
            {
                return false;
            }
            Servicio_Etiqueta? etiqueta = idioma.Etiquetas.Find(x => x.Clave == clave);
               
            if (etiqueta == null)
            {
                return false;
            }

            etiqueta.Texto = textoNuevo;

            return _dalIdioma.GuardarIdiomaActualizado(idioma);
        }
        public List<Servicio_Idioma> ListarIdiomasBD()
        {
            return _dalIdioma.DameIdiomasBD();
        }

        public Servicio_Idioma ObtenerIdiomaPorId(string idIdioma)
        {
            List<Servicio_Idioma> idiomasBD = _dalIdioma.DameIdiomasBD();

            Servicio_Idioma idiomaBD =idiomasBD.FirstOrDefault(x => x.Id_Idioma == idIdioma);
              
            if (idiomaBD == null)return null;
             
            return _dalIdioma.ObtenerIdioma(idiomaBD.Nombre);
        }

       
    }
}
