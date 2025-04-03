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
    public class DALUsuario
    {

        private Gestor_Datos gestorDatos = Gestor_Datos.INSTANCIA;
        DALPermiso ormPermiso = new DALPermiso();

        public void AgregarUsuario(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").NewRow();
            drUsuario[0] = pUsuario.Dni_Usuario;
            drUsuario[1] = pUsuario.Nombre_Usuario;
            drUsuario[2] = pUsuario.Mail_Usuario;
            drUsuario[3] = pUsuario.Contraseña_Usuario;
            drUsuario[4] = pUsuario.Fecha_Nacimiento_Usuario;
            drUsuario[5] = pUsuario.Fecha_Creacion_Usuario;
            drUsuario[6] = pUsuario.Telefono_Usuario;
            drUsuario[7] = pUsuario.Estado_Usuario;
            drUsuario[8] = pUsuario.Rol.DevolverNombrePermiso();
            drUsuario[9] = pUsuario.Idioma;
            drUsuario[10] = pUsuario.Intentos;
            gestorDatos.DevolverTabla("Usuario").Rows.Add(drUsuario);
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void AumentarIntentos(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), drUsuario.Field<string>(3), drUsuario.Field<DateTime>(4), drUsuario.Field<DateTime>(5), drUsuario.Field<string>(6), drUsuario.Field<bool>(7), drUsuario.Field<string>(8), drUsuario.Field<string>(9), int.Parse(drUsuario[10].ToString()) + 1 };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void ReestablecerIntentos(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), drUsuario.Field<string>(3), drUsuario.Field<DateTime>(4), drUsuario.Field<DateTime>(5), drUsuario.Field<string>(6), drUsuario.Field<bool>(7), drUsuario.Field<string>(8), drUsuario.Field<string>(9), 0 };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void CambiarIdioma(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario["Idioma"] = pUsuario.Idioma;
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void DeshabilitarUsuario(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), drUsuario.Field<string>(3), drUsuario.Field<DateTime>(4), drUsuario.Field<DateTime>(5), drUsuario.Field<string>(6), false, drUsuario.Field<string>(8), drUsuario.Field<string>(9), 0 };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void HabilitarUsuario(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), drUsuario.Field<string>(3), drUsuario.Field<DateTime>(4), drUsuario.Field<DateTime>(5), drUsuario.Field<string>(6), true, drUsuario.Field<string>(8), drUsuario.Field<string>(9), 0 };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void ModificarUsuario(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), pUsuario.Nombre_Usuario, pUsuario.Mail_Usuario, drUsuario.Field<string>(3), pUsuario.Fecha_Nacimiento_Usuario, drUsuario.Field<DateTime>(5), pUsuario.Telefono_Usuario, drUsuario.Field<bool>(7), pUsuario.Rol.DevolverNombrePermiso(), drUsuario.Field<string>(9), drUsuario.Field<int>(10) };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public List<BE_Usuario> ListaUsuarios()
        {
            List<BE_Usuario> lista = new List<BE_Usuario>();
            foreach(DataRowView row in gestorDatos.DevolverTabla("Usuario").DefaultView)
            {
                BEPermisoCompuesto rol = (BEPermisoCompuesto)ormPermiso.DevolverPermisos("Roles").Find(x => x.DevolverNombrePermiso() == row[8].ToString());
                int edadUsuario = CalcularEdadUsuario(DateTime.Parse(row[4].ToString()));
                BE_Usuario usuario = new BE_Usuario(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), DateTime.Parse(row[4].ToString()), edadUsuario, DateTime.Parse(row[5].ToString()), row[6].ToString(), bool.Parse(row[7].ToString()), rol, row[9].ToString(), int.Parse(row[10].ToString()));
                lista.Add(usuario);
            }
            return lista;
        }

        public int CalcularEdadUsuario(DateTime pFechaNacimientoUsuario)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - pFechaNacimientoUsuario.Year;

            // Ajustar la edad si la persona no ha cumplido años este año
            if (fechaActual < pFechaNacimientoUsuario.AddYears(edad))
            {
                edad--;
            }

            return edad;
        }

        public void CambiarContraseña(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            if (drUsuario != null)
            {
                drUsuario["ContraseñaUsuario"] = pUsuario.Contraseña_Usuario;
            }
            gestorDatos.ActualizarPorTabla("Usuario");
        }
    }
}
