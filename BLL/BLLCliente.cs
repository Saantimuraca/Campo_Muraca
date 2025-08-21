using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;
using Servicios.Datos;

namespace BLL
{
    public class BLLCliente
    {
        DALCliente dalCliente = new DALCliente(); 
        public void Agregar(BECliente pCliente)
        {
            dalCliente.Agregar(pCliente);
            dalCliente.AgregarDvh(dalCliente.DevolverRow(pCliente.dni), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dalCliente.DevolverRow(pCliente.dni)));
            DatosDV.INSTANCIA.CalcularDvvTabla("Cliente");
        }

        public void CambiarEstado(BECliente pCliente)
        {
            dalCliente.CambiarEstado(pCliente);
            dalCliente.AgregarDvh(dalCliente.DevolverRow(pCliente.dni), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dalCliente.DevolverRow(pCliente.dni)));
            DatosDV.INSTANCIA.CalcularDvvTabla("Cliente");
        }

        public void Modificar(BECliente pCliente)
        {
            dalCliente.Modificar(pCliente);
            dalCliente.AgregarDvh(dalCliente.DevolverRow(pCliente.dni), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dalCliente.DevolverRow(pCliente.dni)));
            DatosDV.INSTANCIA.CalcularDvvTabla("Cliente");
        }

        public List<BECliente> ListaClientes()
        {
            return dalCliente.ListaClientes();
        }

        public bool ExisteCliente(string dni)
        {
            return ListaClientes().Find(x => x.dni == dni) == null ? false : true;
        }
    }
}
