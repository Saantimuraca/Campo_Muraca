using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Servicios.Entidades;
using Servicios.Datos;

namespace Servicios.Logica
{
    public class LogicaTraduccion
    {
        DatosTraduccion dalTraductor = new DatosTraduccion();
        public List<EntidadTraduccion> ListaTraduccion()
        {
            return dalTraductor.ListaTraducciones();
        }

        public void ModificarTraduccion(Dictionary<string, string> cambios, int idIdioma)
        {
            dalTraductor.ModificarTraduccion(cambios, idIdioma);
        }

        public void AgregarTraduccion(int idIdioma)
        {
            dalTraductor.AgregarTraduccion(idIdioma);
        }

        public void EliminarTraduccion(EntidadTraduccion pTraduccion)
        {
            dalTraductor.EliminarTraduccion(pTraduccion);
        }
    }
}
