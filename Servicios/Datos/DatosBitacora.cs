using DAL;
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
        Gestor_Datos gpbd = Gestor_Datos.INSTANCIA;
        DatosUsuario dalUsuario = new DatosUsuario();
        public void RegistrarBitacora(EntidadBitacora pBitacora)
        {
            DataRow drBitacora = gpbd.DevolverTabla("Bitacora").NewRow();
            drBitacora["idBitacora"] = pBitacora.idBitacora;
            drBitacora["fechaHora"] = pBitacora.fechaHora;
            drBitacora["dniUsuario"] = pBitacora.usuario.Dni_Usuario;
            drBitacora["accion"] = pBitacora.accion;
            gpbd.DevolverTabla("Bitacora").Rows.Add(drBitacora);
            gpbd.ActualizarPorTabla("Bitacora");
        }

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
                    EntidadBitacora bitacora = new EntidadBitacora(int.Parse(row[0].ToString()), DateTime.Parse(row[1].ToString()), usuario, row[3].ToString());
                    lista.Add(bitacora);
                }
            }
            return lista;
            //string pMailUsuario, string pContraseñaUsuario, DateTime pFechaNacimientoUsuario, int pEdadUsuario, DateTime pFechaCreacionUsuario, string pTelefonoUsuario, bool pEstadoUsuario, BEPermisoCompuesto rol, string idioma, int intentos
        }
    }
}
