using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using DAL;

namespace DAO
{
    public class DALPedido
    {
        private static DALPedido instancia;
        public static DALPedido INSTANCIA
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new DALPedido();
                }
                return instancia;
            }
        }
        DALCliente dalCliente = new DALCliente();
        public void Agregar(BEPedido pPedido)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Pedido").NewRow();
            dr["idPedido"] = pPedido.id;
            dr["dniCliente"] = pPedido.cliente.dni;
            dr["estado"] = pPedido.estado;
            dr["fecha"] = pPedido.fecha;
            dr["total"] = pPedido.total;
            dr["dniVendedor"] = pPedido.dniVendedor;
            Gestor_Datos.INSTANCIA.DevolverTabla("Pedido").Rows.Add(dr);
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Pedido");
        }

        /*public void AgregarDvhPedido(DataRow dr, string pDvh)
        {
            dr["dvh"] = pDvh;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Pedido");
        }*/

        /*public void AgregarDvhItemPedido(DataRow dr, string pDvh)
        {
            dr["dvh"] = pDvh;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("ItemPedido");
        }*/

        /*public DataRow DevolverRowPedido(int pId)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Pedido").Rows.Find(pId);
            return dr;
        }*/

        /*public DataRow DevolverRowItemPedido(int pIdPedido, int pIdProducto)
        {
            object[] clave = { pIdPedido, pIdProducto };
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("ItemPedido").Rows.Find(clave);
            return dr;
        }*/

        public void AgregarItemPedido(int pIdPedido, int pIdProducto, int pCantidad)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("ItemPedido").NewRow();
            dr["idPedido"] = pIdPedido;
            dr["idProducto"] = pIdProducto;
            dr["cantidad"] = pCantidad;
            Gestor_Datos.INSTANCIA.DevolverTabla("ItemPedido").Rows.Add(dr);
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("ItemPedido");
        }

        public List<BEPedido> ListarPedido()
        {
            List<BEPedido> lista = new List<BEPedido>();
            foreach(DataRowView row in Gestor_Datos.INSTANCIA.DevolverTabla("Pedido").DefaultView)
            {
                BECliente cliente = dalCliente.ListaClientes().Find(x => x.dni == row[1].ToString());
                BEPedido pedido = new BEPedido(cliente, row[2].ToString(), DateTime.Parse(row[3].ToString()), decimal.Parse(row[4].ToString()), row[5].ToString(), int.Parse(row[0].ToString()));
                if (row[6] != null)
                {
                    pedido.Motivo = row[6].ToString();
                }
                lista.Add(pedido);
            }
            return lista;
        }

        public void CambiarEstado(string pEstado, int pId, string pMotivo = "")
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Pedido").Rows.Find(pId);
            dr["estado"] = pEstado;
            if(pMotivo != "") { dr["motivo"] = pMotivo; }
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Pedido");
        }

        public Dictionary<int, int> DetallePedido(int pId)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            foreach (DataRowView row in Gestor_Datos.INSTANCIA.DevolverTabla("ItemPedido").DefaultView)
            {
                if (int.Parse(row[0].ToString()) == pId)
                {
                    d.Add(int.Parse(row[1].ToString()), int.Parse(row[1].ToString()));
                }
            }
            return d;
        }

        public List<string[]> ItemsFactura(int pId)
        {
            List<string[]> lista = new List<string[]>();
            foreach(DataRowView row in Gestor_Datos.INSTANCIA.DevolverTabla("ItemPedido").DefaultView)
            {
                if (int.Parse(row[0].ToString()) == pId)
                {
                    DataRow drProducto = Gestor_Datos.INSTANCIA.DevolverTabla("Producto").Rows.Find(int.Parse(row[1].ToString()));
                    string[] vector = new string[] { drProducto[1].ToString(), row[2].ToString(), drProducto[3].ToString() };
                    lista.Add(vector);
                }
            }
            return lista;   
        }

        public void AdjuntarFactura(int nroFactura, int idPedido)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Pedido").Rows.Find(idPedido);
            dr["nroFactura"] = nroFactura;
            dr["estado"] = "Facturado";
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Pedido");
        }

        /*public IEnumerable<DataRow> ObtenerEntidades()
        {
            return Gestor_Datos.INSTANCIA.DevolverTabla("Pedido").Rows.Cast<DataRow>().OrderBy(r => r.Field<int>("idPedido"));
        }*/
    }
}
