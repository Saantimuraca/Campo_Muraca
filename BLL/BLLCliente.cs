using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BLL
{
    public class BLLCliente
    {
        DALCliente dalCliente = new DALCliente(); 
        public void Agregar(BECliente pCliente)
        {
            dalCliente.Agregar(pCliente);
        }

        public void CambiarEstado(BECliente pCliente)
        {
            dalCliente.CambiarEstado(pCliente);
        }

        public void Modificar(BECliente pCliente)
        {
            dalCliente.Modificar(pCliente);
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
