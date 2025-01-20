using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Gestor_Datos
    {
        //Aplicamos El Patrón Creacional Singleton Para Asegurar La Unicidad De La Clase.
        private static Gestor_Datos instancia;
        public static Gestor_Datos INSTANCIA
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Gestor_Datos();
                }
                return instancia;
            }
        }
        private DataSet BaseDeDatosEnMemoria;
        private SqlConnection co;
        private Dictionary<string, SqlDataAdapter> DiccionarioDeAdaptadores = new Dictionary<string, SqlDataAdapter>();
        public Gestor_Datos()
        {
            BaseDeDatosEnMemoria = new DataSet();
            co = new SqlConnection("");
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
            SqlDataAdapter Adaptador = new SqlDataAdapter(query, co);
            DataTable TablaNombreDeLasTablas = new DataTable();
            Adaptador.Fill(TablaNombreDeLasTablas);
            foreach (DataRow Row in TablaNombreDeLasTablas.Rows)
            {
                string queryDiccionario = $"SELECT * FROM [{Row["TABLE_NAME"]}]";
                SqlDataAdapter adapter = new SqlDataAdapter(queryDiccionario, co);
                SqlCommandBuilder ConstructorDeComando = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = ConstructorDeComando.GetInsertCommand();
                adapter.DeleteCommand = ConstructorDeComando.GetDeleteCommand();
                adapter.UpdateCommand = ConstructorDeComando.GetUpdateCommand();
                adapter.Fill(BaseDeDatosEnMemoria, $"{Row["TABLE_NAME"]}");
                int CantidadRegistros = BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].Rows.Count;
                
                if (CantidadRegistros == 2)
                {
                    BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].PrimaryKey = new DataColumn[] { BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].Columns[0], BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].Columns[1] };
                }
                else
                {
                    BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].PrimaryKey = new DataColumn[] { BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].Columns[0] };
                }
                DiccionarioDeAdaptadores.Add((Row["TABLE_NAME"] as string), adapter);
            }
        }

        public DataTable DevolverTabla(string NombreTabla)
        {
            return BaseDeDatosEnMemoria.Tables[NombreTabla];
        }
        public void ActualizarGeneral()
        {
            foreach (KeyValuePair<string, SqlDataAdapter> ClaveValor in DiccionarioDeAdaptadores)
            {
                ClaveValor.Value.Update(BaseDeDatosEnMemoria, ClaveValor.Key);
            }
        }
        public void ActualizarPorTabla(string NombreTabla)
        {
            DiccionarioDeAdaptadores[NombreTabla].Update(BaseDeDatosEnMemoria, NombreTabla);
            BaseDeDatosEnMemoria.Tables[NombreTabla].Clear();
            DiccionarioDeAdaptadores[NombreTabla].Fill(BaseDeDatosEnMemoria, NombreTabla);
        }

        public void RechazarGeneral()
        {
            BaseDeDatosEnMemoria.RejectChanges();
        }
        public void RechazarPorTabla(string NombreTabla)
        {
            BaseDeDatosEnMemoria.Tables[NombreTabla].RejectChanges();
        }
        public void RechazarPorRegistro(DataRow Registro)
        {
            Registro.RejectChanges();
        }
    }
}
