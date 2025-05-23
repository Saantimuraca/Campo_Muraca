﻿using BE;
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
        ORMPermiso ormPermiso = new ORMPermiso();

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
            drUsuario[9] = pUsuario.Rol.DevolverNombrePermiso();
            drUsuario[10] = pUsuario.Idioma;
            drUsuario[11] = pUsuario.Intentos;
            gestorDatos.DevolverTabla("Usuario").Rows.Add(drUsuario);
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void AumentarIntentos(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), drUsuario.Field<string>(3), drUsuario.Field<DateTime>(4), drUsuario.Field<int>(5), drUsuario.Field<DateTime>(6), drUsuario.Field<string>(7), drUsuario.Field<bool>(8), drUsuario.Field<string>(9), drUsuario.Field<string>(10), int.Parse(drUsuario[11].ToString()) + 1 };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void ReestablecerIntentos(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), drUsuario.Field<string>(3), drUsuario.Field<DateTime>(4), drUsuario.Field<int>(5), drUsuario.Field<DateTime>(6), drUsuario.Field<string>(7), drUsuario.Field<bool>(8), drUsuario.Field<string>(9), drUsuario.Field<string>(10), 0 };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void DeshabilitarUsuario(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), drUsuario.Field<string>(3), drUsuario.Field<DateTime>(4), drUsuario.Field<int>(5), drUsuario.Field<DateTime>(6), drUsuario.Field<string>(7), false, drUsuario.Field<string>(9), drUsuario.Field<string>(10), 0 };
            gestorDatos.ActualizarPorTabla("Usuario");
        }

        public void HabilitarUsuario(BE_Usuario pUsuario)
        {
            DataRow drUsuario = gestorDatos.DevolverTabla("Usuario").Rows.Find(pUsuario.Dni_Usuario);
            drUsuario.ItemArray = new object[] { drUsuario.Field<string>(0), drUsuario.Field<string>(1), drUsuario.Field<string>(2), drUsuario.Field<string>(3), drUsuario.Field<DateTime>(4), drUsuario.Field<int>(5), drUsuario.Field<DateTime>(6), drUsuario.Field<string>(7), true, drUsuario.Field<string>(9), drUsuario.Field<string>(10), 0 };
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
                BEPermisoCompuesto rol = (BEPermisoCompuesto)ormPermiso.DevolverPermisos("Roles").Find(x => x.DevolverNombrePermiso() == row[9].ToString());
                BE_Usuario usuario = new BE_Usuario(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), DateTime.Parse(row[4].ToString()), int.Parse(row[5].ToString()), DateTime.Parse(row[6].ToString()), row[7].ToString(), bool.Parse(row[8].ToString()), rol, row[10].ToString(), int.Parse(row[11].ToString()));
                lista.Add(usuario);
            }
            return lista;
        }
    }
}
