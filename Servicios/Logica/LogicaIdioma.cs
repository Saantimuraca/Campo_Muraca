﻿using DAL;
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
        LogicaUsuario lu = new LogicaUsuario();

        public List<EntidadIdioma> ListaIdiomas()
        {
            return dalIdioma.ListaIdiomas();
        }

        public void ModificarDisponibilidad(EntidadIdioma pIdioma, bool pDisponibilidad)
        {
            dalIdioma.ModificarDisponibilidad(pIdioma, pDisponibilidad);
        }

        public bool IsRepetido(string pIdioma)
        {
            return ListaIdiomas().Find(x => x.idioma.Equals(pIdioma, StringComparison.OrdinalIgnoreCase)) == null ? false : true;
        }

        public void AgregarIdioma(EntidadIdioma pIdioma)
        {
            dalIdioma.Agregar(pIdioma);
            bllTraduccion.AgregarTraduccion(ListaIdiomas().Find(x => x.idioma == pIdioma.idioma).idIdioma);
        }

        public void EliminarIdioma(EntidadIdioma pIdioma)
        {
            foreach(EntidadUsuario usuario in lu.ListaUsuarios())
            {
                if(usuario.Idioma == pIdioma.idioma) { lu.CambiarIdioma(usuario, "Español"); }
            }
            foreach (EntidadTraduccion traduccion in bllTraduccion.ListaTraduccion().Where(x => x.idioma == pIdioma.idioma))
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
        }
    }
}
