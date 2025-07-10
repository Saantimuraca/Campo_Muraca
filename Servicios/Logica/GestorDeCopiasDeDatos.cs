using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class GestorDeCopiasDeDatos
    {
        private string nombreDBActual = "BdProyecto";

        public void HacerBackUp()
        {
            string carpetaBackup = "C:\\BackUp_TecnoSoft";
            if (!Directory.Exists(carpetaBackup))
                Directory.CreateDirectory(carpetaBackup);
            string nombreArchivo = $"Backup_TecnoSoft.bak";
            string archivoBackUp = Path.Combine(carpetaBackup, nombreArchivo);
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BdProyecto;Integrated Security=True"))
            {
                con.Open();
                string consulta = $@"BACKUP DATABASE [{nombreDBActual}] TO DISK = '{archivoBackUp}'"; 
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void HacerRespaldo()
        {
            string carpetaBackup = $"C:\\BackUp_TecnoSoft\\Backup_TecnoSoft.bak";
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BdProyecto;Integrated Security=True"))
            {
                con.Open();
                string consulta = $@"use [master] ALTER DATABASE [{nombreDBActual}] set offline with rollback immediate restore database [{nombreDBActual}] from disk = '{carpetaBackup}' with replace";
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
