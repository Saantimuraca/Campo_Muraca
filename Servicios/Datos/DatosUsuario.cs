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
    public class DatosUsuario : IIntegridadRepositorio
    {
        private static DatosUsuario instancia;
        public static DatosUsuario INSTANCIA
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new DatosUsuario();
                }
                return instancia;
            }
        }
        private Gestor_Datos gestorDatos = Gestor_Datos.INSTANCIA;
        DatosPermiso ormPermiso = new DatosPermiso();

        public void AgregarUsuario(EntidadUsuario pUsuario)
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

        public void AgregarDvh(DataRow dr, string pDvh)
        {
            dr["dvh"] = pDvh;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Usuario");
        }

        public DataRow DevolverRow(string pDni)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Usuario").Rows.Find(pDni);
            return dr;
        }

        public void AumentarIntentos(EntidadUsuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), drUsuario.Field<string>(3), drUsuario.Field<DateTime>(4), drUsuario.Field<DateTime>(5), drUsuario.Field<string>(6), drUsuario.Field<bool>(7), drUsuario.Field<string>(8), drUsuario.Field<string>(9), int.Parse(drUsuario[10].ToString()) + 1 };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void ReestablecerIntentos(EntidadUsuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), drUsuario.Field<string>(3), drUsuario.Field<DateTime>(4), drUsuario.Field<DateTime>(5), drUsuario.Field<string>(6), drUsuario.Field<bool>(7), drUsuario.Field<string>(8), drUsuario.Field<string>(9), 0 };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void CambiarIdioma(EntidadUsuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario["Idioma"] = pUsuario.Idioma;
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void DeshabilitarUsuario(EntidadUsuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), drUsuario.Field<string>(3), drUsuario.Field<DateTime>(4), drUsuario.Field<DateTime>(5), drUsuario.Field<string>(6), false, drUsuario.Field<string>(8), drUsuario.Field<string>(9), 0 };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void HabilitarUsuario(EntidadUsuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), drUsuario.Field<string>(3), drUsuario.Field<DateTime>(4), drUsuario.Field<DateTime>(5), drUsuario.Field<string>(6), true, drUsuario.Field<string>(8), drUsuario.Field<string>(9), 0 };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void ModificarUsuario(EntidadUsuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), pUsuario.Nombre_Usuario, pUsuario.Mail_Usuario, drUsuario.Field<string>(3), pUsuario.Fecha_Nacimiento_Usuario, drUsuario.Field<DateTime>(5), pUsuario.Telefono_Usuario, drUsuario.Field<bool>(7), pUsuario.Rol.DevolverNombrePermiso(), drUsuario.Field<string>(9), drUsuario.Field<int>(10) };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public List<EntidadUsuario> ListaUsuarios()
        {
            List<EntidadUsuario> lista = new List<EntidadUsuario>();
            foreach(DataRowView row in gestorDatos.DevolverTabla("Usuario").DefaultView)
            {
                EntidadPermisoCompuesto rol = (EntidadPermisoCompuesto)ormPermiso.DevolverPermisos("Roles").Find(x => x.DevolverNombrePermiso() == row[8].ToString());
                int edadUsuario = CalcularEdadUsuario(DateTime.Parse(row[4].ToString()));
                EntidadUsuario usuario = new EntidadUsuario(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), DateTime.Parse(row[4].ToString()), edadUsuario, DateTime.Parse(row[5].ToString()), row[6].ToString(), bool.Parse(row[7].ToString()), rol, row[9].ToString(), int.Parse(row[10].ToString()));
                lista.Add(usuario);
            }
            return lista;
        }

        public int CalcularEdadUsuario(DateTime pFechaNacimientoUsuario)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - pFechaNacimientoUsuario.Year;

            if (fechaActual < pFechaNacimientoUsuario.AddYears(edad))
            {
                edad--;
            }

            return edad;
        }

        public void CambiarContraseña(EntidadUsuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            if (drUsuario != null)
            {
                drUsuario["ContraseñaUsuario"] = pUsuario.Contraseña_Usuario;
            }
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public IEnumerable<DataRow> ObtenerEntidades()
        {
            return Gestor_Datos.INSTANCIA.DevolverTabla("Usuario").Rows.Cast<DataRow>().OrderBy(r => r.Field<string>("dniUsuario"));
        }

        public List<EntidadHistoriaUsuario> ListaHistoriaUsuario()
        {
            List<EntidadHistoriaUsuario> lista = new List<EntidadHistoriaUsuario> ();
            foreach(DataRowView row in Gestor_Datos.INSTANCIA.DevolverTabla("HistoriaUsuario").DefaultView)
            {
                EntidadPermisoCompuesto rol = ormPermiso.DevolverPermsisosArbol().Find(x => x.DevolverNombrePermiso() == row["rol"].ToString()) as EntidadPermisoCompuesto;
                EntidadHistoriaUsuario historia = new EntidadHistoriaUsuario(int.Parse(row["id"].ToString()), row["dniUsuario"].ToString(), row["nombre"].ToString(), row["mail"].ToString(),
                    row["contraseña"].ToString(), DateTime.Parse(row["fechaNacimiento"].ToString()), DateTime.Parse(row["fechaCreacion"].ToString()), row["telefono"].ToString(),
                    bool.Parse(row["estado"].ToString()), rol, row["idioma"].ToString(), DateTime.Parse(row["fechaModificacion"].ToString()));
                lista.Add(historia);
            }
            return lista;
        }

        public void RollBack(EntidadUsuario pUsuario)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            dr["dniUsuario"] = pUsuario.Dni_Usuario;
            dr["NombreUsuario"] = pUsuario.Nombre_Usuario;
            dr["MailUsuario"] = pUsuario.Mail_Usuario;
            dr["ContraseñaUsuario"] = pUsuario.Contraseña_Usuario;
            dr["FechaNacimientoUsuario"] = pUsuario.Fecha_Nacimiento_Usuario;
            dr["FechaCreacionUsuario"] = pUsuario.Fecha_Creacion_Usuario;
            dr["TelefonoUsuario"] = pUsuario.Telefono_Usuario;
            dr["EstadoUsuario"] = pUsuario.Estado_Usuario;
            dr["Rol"] = pUsuario.Rol;
            dr["Idioma"] = pUsuario.Idioma;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Usuario");
        }

        /*public void AgregarDvhHistoria(DataRow dr, string pDvh)
        {
            dr["dvh"] = pDvh;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("HistoriaUsuario");
        }

        public DataRow DevolverRowHistoria(int pId)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("HistoriaUsuario").Rows.Find(pId);
            return dr;
        }

        public int DevolverUltimoIdHistoria()
        {
            int maxId = 0;
            foreach (DataRow row in Gestor_Datos.INSTANCIA.DevolverTabla("HistoriaUsuario").Rows)
            {
                int id = int.Parse(row["id"].ToString());
                if (id > maxId)
                    maxId = id;
            }
            return maxId;
        }*/

        public void AgregarHistoria(EntidadUsuario pUsuario)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("HistoriaUsuario").NewRow();
            dr["id"] = 0;
            dr["dniUsuario"] = pUsuario.Dni_Usuario;
            dr["nombre"] = pUsuario.Nombre_Usuario;
            dr["mail"] = pUsuario.Mail_Usuario;
            dr["contraseña"] = pUsuario.Contraseña_Usuario;
            dr["fechaNacimiento"] = pUsuario.Fecha_Nacimiento_Usuario;
            dr["fechaCreacion"] = pUsuario.Fecha_Creacion_Usuario;
            dr["telefono"] = pUsuario.Telefono_Usuario;
            dr["estado"] = pUsuario.Estado_Usuario;
            dr["rol"] = pUsuario.Rol.DevolverNombrePermiso();
            dr["idioma"] = pUsuario.Idioma;
            dr["intentos"] = pUsuario.Intentos;
            dr["fechaModificacion"] = DateTime.Now;
            Gestor_Datos.INSTANCIA.DevolverTabla("HistoriaUsuario").Rows.Add(dr);
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("HistoriaUsuario");
        }
    }
}
