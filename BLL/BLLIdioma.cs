using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLIdioma
    {
        DALIdioma dalIdioma = new DALIdioma();
        BLLTraduccion bllTraduccion = new BLLTraduccion();  

        public List<BEIdioma> ListaIdiomas()
        {
            return dalIdioma.ListaIdiomas();
        }

        public bool IsRepetido(string pIdioma)
        {
            return ListaIdiomas().Find(x => x.idioma == pIdioma) == null ? false : true;
        }

        public void AgregarIdioma(BEIdioma pIdioma)
        {
            dalIdioma.Agregar(pIdioma);
            foreach(BETraduccion traduccion in bllTraduccion.ListaTraduccion())
            {
                if(traduccion.idioma == "Español")
                {
                    BETraduccion t = new BETraduccion(traduccion.textoTraducir, pIdioma.idioma, "");
                    bllTraduccion.AgregarTraduccion(t);
                }
            }
        }

        public void EliminarIdioma(BEIdioma pIdioma)
        {
            foreach (BETraduccion traduccion in bllTraduccion.ListaTraduccion())
            {
                if(traduccion.idioma == pIdioma.idioma)
                {
                    bllTraduccion.EliminarTraduccion(traduccion);
                }
            }
            dalIdioma.Eliminar(pIdioma);
        }

        public void ModificarIdioma(BEIdioma pIdiomaModificar, BEIdioma pIdiomaModificado)
        {
            dalIdioma.Modificar(pIdiomaModificar, pIdiomaModificado);
            bllTraduccion.ModificarIdiomaTraduccion(pIdiomaModificado, pIdiomaModificar);
        }
    }
}
