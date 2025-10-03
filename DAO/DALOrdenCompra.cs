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
    public class DALOrdenCompra
    {
        public void CrearOrden(BEOrdenCompra pOrdenCompra)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("OrdenCompra").NewRow();
            dr["id"] = 0;
            dr["estado"] = pOrdenCompra.estado;
            dr["fecha"] = pOrdenCompra.fecha;
            Gestor_Datos.INSTANCIA.DevolverTabla("OrdenCompra").Rows.Add(dr);
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("OrdenCompra");
        }

        public int DevolverUltimoId()
        {
            int maxId = 0;
            foreach (DataRow row in Gestor_Datos.INSTANCIA.DevolverTabla("OrdenCompra").Rows)
            {
                int id = int.Parse(row["id"].ToString());
                if (id > maxId)
                    maxId = id;
            }
            return maxId;
        }

        public List<BEOrdenCompra> Ordenes()
        {
            List<BEOrdenCompra> lista = new List<BEOrdenCompra>();
            foreach (DataRow row in Gestor_Datos.INSTANCIA.DevolverTabla("OrdenCompra").Rows)
            {
                BEOrdenCompra orden = new BEOrdenCompra(row["estado"].ToString(), DateTime.Parse(row["fecha"].ToString()), int.Parse(row["id"].ToString()));
                lista.Add(orden);
            }
            return lista;
        }

        public void Finalizar(int pidOrden)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("OrdenCompra").Select("id = " + pidOrden).FirstOrDefault();
            if (dr != null)
            {
                dr["estado"] = "Finalizada";
                Gestor_Datos.INSTANCIA.ActualizarPorTabla("OrdenCompra");
            }
        }
    }
}
