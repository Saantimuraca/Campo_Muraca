using BE;
using DAO;
using Servicios.Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        public void Serializar(List<BECliente> pLista)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<BECliente>));
            string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nombreArchivo = $"Clientes_{DateTime.Now}";
            string path = Path.Combine(documentos, nombreArchivo);
            using (FileStream fs = new FileStream(nombreArchivo, FileMode.Create))
            {
                serializer.Serialize(fs, pLista);
            }
        }
    }
}
