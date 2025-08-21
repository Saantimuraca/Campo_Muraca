using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Servicios.Entidades;
using Servicios.Datos;
using System.Data;

namespace Servicios.Logica
{
    public class LogicaTraduccion
    {
        DatosTraduccion dalTraductor = new DatosTraduccion();
        public List<EntidadTraduccion> ListaTraduccion()
        {
            return dalTraductor.ListaTraducciones();
        }

        public bool EvaluarDisponibilidad()
        {
            return dalTraductor.EvaluarDisponibilidad();
        }

        public void ModificarTraduccion(Dictionary<string, string> cambios, int idIdioma)
        {
            dalTraductor.ModificarTraduccion(cambios, idIdioma);
            foreach(var par in cambios)
            {
                dalTraductor.AgregarDvh(dalTraductor.DevolverRow(par.Key, idIdioma), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dalTraductor.DevolverRow(par.Key, idIdioma)));
            }
            DatosDV.INSTANCIA.CalcularDvvTabla("Traduccion");
        }

        public void AgregarTraduccion(int idIdioma)
        {
            dalTraductor.AgregarTraduccion(idIdioma);
            foreach(DataRow row in dalTraductor.ColeccionDataRow(idIdioma))
            {
                dalTraductor.AgregarDvh(row, DatosDV.INSTANCIA.CalcularDVHRegistroBase64(row));
            }
            DatosDV.INSTANCIA.CalcularDvvTabla("Traduccion");
        }

        public void EliminarTraduccion(EntidadTraduccion pTraduccion)
        {
            dalTraductor.EliminarTraduccion(pTraduccion);
        }
    }
}
