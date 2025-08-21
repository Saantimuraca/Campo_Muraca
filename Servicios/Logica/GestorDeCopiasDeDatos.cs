using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string nombreArchivo = $"Backup_{DateTime.Now:ddmmyyyyhhmmss}.bak";
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
        public bool HacerRespaldo()
        {
            using (var ofd = new OpenFileDialog()
            {
                Title = "Seleccionar archivo de backup (.bak)",
                InitialDirectory = @"C:\BackUp_TecnoSoft",                
                Filter = "Backup de SQL Server (*.bak)|*.bak",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false
            })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return false;
                string rutaBackUp = ofd.FileName;
                try
                {
                    //.\\SQLEXPRESS
                    var cs = "Data Source=.;Initial Catalog=BdProyecto;Integrated Security=True";
                    using (var con = new SqlConnection(cs))
                    {
                        con.Open();
                        string consulta = $@"use [master] ALTER DATABASE [{nombreDBActual}] set offline with rollback immediate restore database [{nombreDBActual}] from disk = '{rutaBackUp}' with replace";
                        using (var cmd = new SqlCommand(consulta, con))
                        {
                            cmd.Parameters.AddWithValue("@pDb", nombreDBActual);
                            cmd.Parameters.AddWithValue("@pBackup", rutaBackUp);
                            cmd.CommandTimeout = 0;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
