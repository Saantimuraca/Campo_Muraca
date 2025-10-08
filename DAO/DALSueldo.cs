using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace DAO
{
    public class DALSueldo
    {
        public void Modificar(BESueldo pSueldo)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Sueldo").Rows.Find(pSueldo.rol);
            dr["sueldo"] = pSueldo.sueldo;
            dr["comision"] = pSueldo.comision;
            dr["fechaModificacion"] = pSueldo.fechaModificacion;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Sueldo");
        }

        public BESueldo ObtenerPorRol(string pRol)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Sueldo").Rows.Find(pRol);
            if (dr != null)
            {
                return new BESueldo(dr["rol"].ToString(), Convert.ToDecimal(dr["sueldo"]), Convert.ToInt32(dr["comision"]), Convert.ToDateTime(dr["fechaModificacion"]));
            }
            else
            {
                return null;
            }
        }


    }
}
