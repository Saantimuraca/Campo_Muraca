using DAL;
using DAO;
using Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Datos
{
    public class DatosBitacora
    {
        private static DatosBitacora instancia;
        public static DatosBitacora INSTANCIA
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new DatosBitacora();
                }
                return instancia;
            }
        }
        Gestor_Datos gpbd = Gestor_Datos.INSTANCIA;
        public void RegistrarBitacora(EntidadBitacora pBitacora)
        {
            DataRow drBitacora = gpbd.DevolverTabla("Bitacora").NewRow();
            drBitacora["idBitacora"] = pBitacora.idBitacora;
            drBitacora["fechaHora"] = pBitacora.fechaHora;
            drBitacora["dniUsuario"] = pBitacora.usuario.Dni_Usuario;
            drBitacora["accion"] = pBitacora.accion;
            drBitacora["criticidad"] = pBitacora.criticidad;
            gpbd.DevolverTabla("Bitacora").Rows.Add(drBitacora);
            gpbd.ActualizarPorTabla("Bitacora");
        }

        /*public void AgregarDvh(DataRow dr, string pDvh)
        {
            dr["dvh"] = pDvh;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Bitacora");
        }

        public DataRow DevolverRow(int pId)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Bitacora").Rows.Find(pId);
            return dr;
        }*/

        public List<EntidadBitacora> ListaBitacora()
        {
            List<EntidadBitacora> lista = new List<EntidadBitacora>();
            foreach(DataRowView row in gpbd.DevolverTabla("Bitacora").DefaultView)
            {
                if(row != null)
                {
                    DataRow drUsuario = gpbd.DevolverTabla("Usuario").Rows.Find(row[2].ToString());
                    EntidadPermisoCompuesto rol = new EntidadPermisoCompuesto(drUsuario[9].ToString());
                    EntidadUsuario usuario = new EntidadUsuario(drUsuario[0].ToString(), drUsuario[1].ToString(), drUsuario[2].ToString(), drUsuario[3].ToString(),
                        DateTime.Parse(drUsuario[4].ToString()), DateTime.Parse(drUsuario[5].ToString()), drUsuario[6].ToString(),
                        bool.Parse(drUsuario[7].ToString()), rol, drUsuario[9].ToString(), int.Parse(drUsuario[10].ToString()));
                    EntidadBitacora bitacora = new EntidadBitacora(int.Parse(row[0].ToString()), DateTime.Parse(row[1].ToString()), usuario, row[3].ToString(), int.Parse(row[4].ToString()));
                    lista.Add(bitacora);
                }
            }
            return lista;
        }

        /*public IEnumerable<DataRow> ObtenerEntidades()
        {
            return Gestor_Datos.INSTANCIA.DevolverTabla("Bitacora").Rows.Cast<DataRow>().OrderBy(r => r.Field<int>("idBitacora"));
        }*/
    }
}
