﻿using BE;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DALBitacora
    {
        Gestor_Datos gpbd = Gestor_Datos.INSTANCIA;
        DALUsuario dalUsuario = new DALUsuario();
        public void RegistrarBitacora(BEBitacora pBitacora)
        {
            DataRow drBitacora = gpbd.DevolverTabla("Bitacora").NewRow();
            drBitacora["idBitacora"] = pBitacora.idBitacora;
            drBitacora["fechaHora"] = pBitacora.fechaHora;
            drBitacora["dniUsuario"] = pBitacora.usuario.Dni_Usuario;
            drBitacora["accion"] = pBitacora.accion;
            gpbd.DevolverTabla("Bitacora").Rows.Add(drBitacora);
            gpbd.ActualizarPorTabla("Bitacora");
        }

        public List<BEBitacora> ListaBitacora()
        {
            List<BEBitacora> lista = new List<BEBitacora>();
            foreach(DataRowView row in gpbd.DevolverTabla("Bitacora").DefaultView)
            {
                if(row != null)
                {
                    DataRow drUsuario = gpbd.DevolverTabla("Usuario").Rows.Find(row[2].ToString());
                    BEPermisoCompuesto rol = new BEPermisoCompuesto(drUsuario[9].ToString());
                    BE_Usuario usuario = new BE_Usuario(drUsuario[0].ToString(), drUsuario[1].ToString(), drUsuario[2].ToString(), drUsuario[3].ToString(),
                        DateTime.Parse(drUsuario[4].ToString()), DateTime.Parse(drUsuario[5].ToString()), drUsuario[6].ToString(),
                        bool.Parse(drUsuario[7].ToString()), rol, drUsuario[9].ToString(), int.Parse(drUsuario[10].ToString()));
                    BEBitacora bitacora = new BEBitacora(int.Parse(row[0].ToString()), DateTime.Parse(row[1].ToString()), usuario, row[3].ToString());
                    lista.Add(bitacora);
                }
            }
            return lista;
            //string pMailUsuario, string pContraseñaUsuario, DateTime pFechaNacimientoUsuario, int pEdadUsuario, DateTime pFechaCreacionUsuario, string pTelefonoUsuario, bool pEstadoUsuario, BEPermisoCompuesto rol, string idioma, int intentos
        }
    }
}
