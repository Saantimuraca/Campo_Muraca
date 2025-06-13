using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DAL
{
    public class Gestor_Datos
    {
        private static Gestor_Datos instancia;
        private static readonly object _lock = new object();
        public static Gestor_Datos INSTANCIA
        {
            get
            {
                if (instancia == null)
                {
                    lock (_lock)
                    {
                        if(instancia == null)
                        {
                            instancia = new Gestor_Datos();
                        }
                    }
                }
                return instancia;
            }
        }
        private DataSet BaseDeDatosEnMemoria;
        private SqlConnection cone;
        //Se configuran todos los adaptadores que se encargaran de manipular las tablas de las entidad de una forma dinamica y centralizada
        private Dictionary<string, SqlDataAdapter> DiccionarioDeAdaptadores = new Dictionary<string, SqlDataAdapter>();
        public Gestor_Datos()
        {
            BaseDeDatosEnMemoria = new DataSet();
            cone = new SqlConnection("Data Source=.;Initial Catalog=BdProyecto;Integrated Security=True");
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

            SqlDataAdapter Adaptador = new SqlDataAdapter(query, cone);
            DataTable TablaNombreDeLasTablas = new DataTable();
            Adaptador.Fill(TablaNombreDeLasTablas);

            foreach (DataRow Row in TablaNombreDeLasTablas.Rows)
            {

                if (!Regex.IsMatch(Row["TABLE_NAME"].ToString(), @"^[a-zA-Z0-9_]+$"))
                {
                    throw new InvalidOperationException("Nombre de tabla no válido.");
                }

                string queryDiccionario = $"SELECT * FROM {Row["TABLE_NAME"]}";

                SqlDataAdapter adapter = new SqlDataAdapter(queryDiccionario, cone);
                SqlCommandBuilder ConstructorDeComando = new SqlCommandBuilder(adapter);

                adapter.InsertCommand = ConstructorDeComando.GetInsertCommand();
                adapter.DeleteCommand = ConstructorDeComando.GetDeleteCommand();
                adapter.UpdateCommand = ConstructorDeComando.GetUpdateCommand();

                adapter.Fill(BaseDeDatosEnMemoria, $"{Row["TABLE_NAME"]}");

                int CantidadCollumnas = BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].Columns.Count;

                //Este If chequea los casos cuando sea una Tabla Normal y Una Tabla Intermedia.
                if (CantidadCollumnas == 2 || $"{Row["TABLE_NAME"]}" == "Traduccion" || $"{Row["TABLE_NAME"]}" == "ItemPedido")
                {
                    if($"{Row["TABLE_NAME"]}" == "Traduccion")
                    {
                        adapter.UpdateBatchSize = 100;
                    }
                    if($"{Row["TABLE_NAME"]}" != "Idioma" && $"{Row["TABLE_NAME"]}" != "Etiqueta" && $"{Row["TABLE_NAME"]}" != "CategoriaProductos")
                    {
                        BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].PrimaryKey = new DataColumn[] { BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].Columns[0], BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].Columns[1] };
                    }
                    else
                    {
                        BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].PrimaryKey = new DataColumn[] { BaseDeDatosEnMemoria.Tables[$"{Row["TABLE_NAME"]}"].Columns[0] };
                    }
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
                BaseDeDatosEnMemoria.Tables[ClaveValor.Key].Clear();
                ClaveValor.Value.Fill(BaseDeDatosEnMemoria, ClaveValor.Key);
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

        public SqlConnection DevolverConexion()
        {
            return cone;
        }
    }
}
