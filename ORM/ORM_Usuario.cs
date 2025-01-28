using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ORM_Usuario
    {

        private Gestor_Datos gestorDatos = Gestor_Datos.INSTANCIA;

        public void AgregarUsuario(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").NewRow();
            drUsuario[0] = pUsuario.Dni_Usuario;
            drUsuario[1] = pUsuario.Nombre_Usuario;
            drUsuario[2] = pUsuario.Mail_Usuario;
            drUsuario[3] = pUsuario.Contraseña_Usuario;
            drUsuario[4] = pUsuario.Fecha_Nacimiento_Usuario;
            drUsuario[5] = pUsuario.Edad_Usuario;
            drUsuario[6] = pUsuario.Fecha_Creacion_Usuario;
            drUsuario[7] = pUsuario.Telefono_Usuario;
            drUsuario[8] = pUsuario.Estado_Usuario;
            gestorDatos.DevolverTabla("Usuario").Rows.Add(drUsuario);
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void DeshabilitarUsuario(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), drUsuario.Field<string>(3), drUsuario.Field<DateTime>(4), drUsuario.Field<int>(5), drUsuario.Field<DateTime>(6), drUsuario.Field<int>(7), false };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void HabilitarUsuario(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            string nombreUsuario = drUsuario[1].ToString();
            int añoNacimiento = int.Parse(DateTime.Parse(drUsuario[4].ToString()).ToString());
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), $"{nombreUsuario}{añoNacimiento.ToString()}", drUsuario.Field<DateTime>(4), drUsuario.Field<int>(5), drUsuario.Field<DateTime>(6), drUsuario.Field<int>(7), true };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void ModificarUsuario(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), pUsuario.Nombre_Usuario, pUsuario.Mail_Usuario, drUsuario.Field<string>(3), pUsuario.Fecha_Nacimiento_Usuario, pUsuario.Edad_Usuario, drUsuario.Field<DateTime>(5), pUsuario.Telefono_Usuario, drUsuario.Field<bool>(7) };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public List<BE_Usuario> ListaUsuarios()
        {
            List<BE_Usuario> lista = new List<BE_Usuario>();
            foreach(DataRowView row in gestorDatos.DevolverTabla("Usuario").DefaultView)
            {
                BE_Usuario usuario = new BE_Usuario(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), DateTime.Parse(row[4].ToString()), int.Parse(row[5].ToString()), DateTime.Parse(row[6].ToString()), row[7].ToString(), bool.Parse(row[8].ToString()));
                lista.Add(usuario);
            }
            return lista;
        }
    }
}
