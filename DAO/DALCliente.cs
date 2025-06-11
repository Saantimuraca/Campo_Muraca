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
    public class DALCliente
    {

        public void Agregar(BECliente pCliente)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Cliente").NewRow();
            dr["dniCliente"] = pCliente.dni;
            dr["mail"] = pCliente.mail;
            dr["nombre"] = pCliente.nombre;
            dr["condicionIVA"] = pCliente.condicionIVA;
            dr["isActivo"] = true;
            dr["telefono"] = pCliente.telefono;
            Gestor_Datos.INSTANCIA.DevolverTabla("Cliente").Rows.Add(dr);
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Cliente");
        }

        public void CambiarEstado(BECliente pCliente)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Cliente").Rows.Find(pCliente.dni);
            dr["isActivo"] = !pCliente.isActivo;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Cliente");
        }

        public void Modificar(BECliente pCliente)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Cliente").Rows.Find(pCliente.dni);
            dr["mail"] = pCliente.mail;
            dr["nombre"] = pCliente.nombre;
            dr["condicionIVA"] = pCliente.condicionIVA;
            dr["telefono"] = pCliente.telefono;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Cliente");
        }

        public List<BECliente> ListaClientes()
        {
            List<BECliente> lista = new List<BECliente>();
            foreach(DataRowView row in Gestor_Datos.INSTANCIA.DevolverTabla("Cliente").DefaultView)
            {
                BECliente cliente = new BECliente(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), bool.Parse(row[4].ToString()), row[5].ToString());
                lista.Add(cliente);
            }
            return lista;
        }
    }
}
