using DAO;
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
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BdProyecto;Integrated Security=True"))
            {
                con.Open();
                string consulta = $@"BACKUP DATABASE [{nombreDBActual}] TO DISK = '{"C:\\Users\\Santi\\OneDrive\\Escritorio\\UAI\\Proyecto\\Sistema\\Campo_Muraca\\Backup\\BdProyecto.bak"}'"; 
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void HacerRespaldo()
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BdProyecto;Integrated Security=True"))
            {
                con.Open();
                string consulta = $@"use [master] ALTER DATABASE [{nombreDBActual}] set offline with rollback immediate restore database [{nombreDBActual}] from disk = '{"C:\\Users\\Santi\\OneDrive\\Escritorio\\UAI\\Proyecto\\Sistema\\Campo_Muraca\\Backup\\BdProyecto.bak"}' with replace";
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
