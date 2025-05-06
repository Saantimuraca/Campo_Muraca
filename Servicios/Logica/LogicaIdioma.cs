using DAL;
using Servicios.Entidades;
using Servicios.Logica;
using Servicios.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Logica
{
    public class LogicaIdioma
    {
        DatosIdioma dalIdioma = new DatosIdioma();
        LogicaTraduccion bllTraduccion = new LogicaTraduccion();  

        public List<EntidadIdioma> ListaIdiomas()
        {
            return dalIdioma.ListaIdiomas();
        }

        public bool IsRepetido(string pIdioma)
        {
            return ListaIdiomas().Find(x => x.idioma == pIdioma) == null ? false : true;
        }

        public void AgregarIdioma(EntidadIdioma pIdioma)
        {
            dalIdioma.Agregar(pIdioma);
            foreach(EntidadTraduccion traduccion in bllTraduccion.ListaTraduccion())
            {
                if(traduccion.idioma == "Español")
                {
                    EntidadTraduccion t = new EntidadTraduccion(traduccion.textoTraducir, pIdioma.idioma, "");
                    bllTraduccion.AgregarTraduccion(t);
                }
            }
        }

        public void EliminarIdioma(EntidadIdioma pIdioma)
        {
            foreach (EntidadTraduccion traduccion in bllTraduccion.ListaTraduccion())
            {
                if(traduccion.idioma == pIdioma.idioma)
                {
                    bllTraduccion.EliminarTraduccion(traduccion);
                }
            }
            dalIdioma.Eliminar(pIdioma);
        }

        public void ModificarIdioma(EntidadIdioma pIdiomaModificar, EntidadIdioma pIdiomaModificado)
        {
            dalIdioma.Modificar(pIdiomaModificar, pIdiomaModificado);
            bllTraduccion.ModificarIdiomaTraduccion(pIdiomaModificado, pIdiomaModificar);
        }
    }
}
