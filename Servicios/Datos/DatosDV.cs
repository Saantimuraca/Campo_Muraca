using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAO;

namespace Servicios.Datos
{
    public class DatosDV
    {
        private static DatosDV instancia;
        public static DatosDV INSTANCIA
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new DatosDV();
                }
                return instancia;
            }
        }
        private readonly List<IIntegridadRepositorio> readers;
        private const string claveSecreta = "Clave_Secreta";


        private DatosDV()
        {
            readers = new List<IIntegridadRepositorio>();
            Inicializar();
        }

        public void Inicializar()
        {
            readers.Add(DALCategoria.INSTANCIA);
            readers.Add(DALCliente.INSTANCIA);
            readers.Add(DALPedido.INSTANCIA);
            readers.Add(DALProducto.INSTANCIA);
            readers.Add(DALCategoria.INSTANCIA);
            readers.Add(DatosBitacora.INSTANCIA);
            readers.Add(DatosFactura.INSTANCIA);
            readers.Add(DatosIdioma.INSTANCIA);
            readers.Add(DatosPermiso.INSTANCIA);
            readers.Add(DatosTraduccion.INSTANCIA);
            readers.Add(DatosUsuario.INSTANCIA);
        }

        public string CalcularDVHRegistroBase64(DataRow row)
        {
            byte[] dvhComoBytes = CalcularDVHRegistroBytes(row);
            string dvhCalculado = ConvertirDVABase64(dvhComoBytes);
            return dvhCalculado;
        }

        public string ConvertirDVABase64(byte[] dvhBytes)
        {
            return Convert.ToBase64String(dvhBytes).TrimEnd('=');
        }

        public byte[] CalcularDVHRegistroBytes(DataRow row)
        {
            string stringCanonico = ObtenerStringCanonico(row);
            byte[] dvhComoBytes = StringCanonicoHMAC(stringCanonico, claveSecreta);
            return dvhComoBytes;
        }

        public bool VerificarIntegridadBD()
        {
            foreach (IIntegridadRepositorio reader in readers)
            {
                foreach (DataRow row in reader.ObtenerEntidades())
                {
                    string dvhAlmacenado = row["dvh"]?.ToString();
                    string dvhCalculado = CalcularDVHRegistroBase64(row);
                    if (string.IsNullOrEmpty(dvhAlmacenado) ||
                        !string.Equals(dvhAlmacenado, dvhCalculado))
                    {
                        return false;
                    }
                }
            }
            Dictionary<string, string> dvv = CalcularDVVTablas();
            foreach (string key in dvv.Keys)
            {
                DataRow row = Gestor_Datos.INSTANCIA.DevolverTabla("DigitoVerificador").Rows.Find(key);
                if (!string.Equals(row["dvv"].ToString(), dvv[key]))
                    return false;
            }
            return true;
            /*Dictionary<string, string> dvv = CalcularDVVTablas();
            foreach (string key in dvv.Keys)
            {
                DataRow row = Gestor_Datos.INSTANCIA.DevolverTabla("DigitoVerificador").Rows.Find(key);
                row["DVV"] = dvv[key];
            }
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("DigitoVerificador");
            return true;*/

        }

        public string ObtenerStringCanonico(DataRow row)
        {
            int contador = 0;
            string dvh = "";
            foreach (DataColumn col in row.Table.Columns)
            {
                if (col.ColumnName.Equals("dvh", StringComparison.OrdinalIgnoreCase))
                    continue;
                dvh += contador + "..." + col.ColumnName + "..." + NormalizarValorCampo(row[col.ColumnName]).ToString();
                contador++;
            }
            return dvh;
        }

        public string NormalizarValorCampo(object v)
        {
            if (v == null || v == DBNull.Value) return "NULL";
            if (v is bool b) return b ? "1" : "0";
            if (v is DateTime dt)
            {
                if (dt.Kind == DateTimeKind.Unspecified)
                    dt = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
                var utc = dt.ToUniversalTime();
                var sql = new SqlDateTime(utc);
                return sql.Value.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            }
            if (v is DateTimeOffset dto)
            {
                var sql = new SqlDateTime(dto.UtcDateTime);
                return sql.Value.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            }
            // byte[] → HEX mayúsculas sin guiones
            var bytes = v as byte[];
            if (bytes != null)
            {
                return BitConverter.ToString(bytes).Replace("-", string.Empty);
            }
            // IFormattable (números/decimales, etc.) con InvariantCulture
            var formattable = v as IFormattable;
            if (formattable != null) return formattable.ToString(null, CultureInfo.InvariantCulture);
            return v.ToString() ?? "NULL";
        }

        private static string BytesToHex(byte[] data)
        {
            var sb = new StringBuilder(data.Length * 2);
            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("X2")); // 2 dígitos hex, mayúsculas
            return sb.ToString();
        }

        static byte[] StringCanonicoHMAC(string stringCanonico, string claveSecreta)
        {
            using (var h = new HMACSHA256(Encoding.UTF8.GetBytes(claveSecreta)))
            {
                return h.ComputeHash(Encoding.UTF8.GetBytes(stringCanonico));
            }
        }

        static byte[] StringCanonicoHMAC(byte[] dvhsConcatenados, string claveSecreta)
        {
            using (var h = new HMACSHA256(Encoding.UTF8.GetBytes(claveSecreta)))
            {
                return h.ComputeHash(dvhsConcatenados);
            }
        }

        public Dictionary<string, string> CalcularDVVTablas()
        {
            Dictionary<string, MemoryStream> mapaDVV = new Dictionary<string, MemoryStream>();
            foreach (IIntegridadRepositorio reader in readers)
            {
                foreach (DataRow row in reader.ObtenerEntidades())
                {
                    if (!mapaDVV.ContainsKey(row.Table.TableName.ToString()))
                        mapaDVV[row.Table.TableName.ToString()] = new MemoryStream();
                    byte[] dvhComoBytes = CalcularDVHRegistroBytes(row);

                    mapaDVV[row.Table.TableName].Write(BitConverter.GetBytes(dvhComoBytes.Length), 0, 4);
                    mapaDVV[row.Table.TableName].Write(dvhComoBytes, 0, dvhComoBytes.Length);
                }
            }
            Dictionary<string, string> dvv = new Dictionary<string, string>();
            foreach (string key in mapaDVV.Keys)
            {

                dvv[key] = ConvertirDVABase64(StringCanonicoHMAC(mapaDVV[key].ToArray(), claveSecreta));
                mapaDVV[key].Dispose();
            }
            return dvv;
        }

        public void CalcularDvvTabla(string pTabla)
        {
            Dictionary<string, string> dvv = CalcularDVVTablas();
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("DigitoVerificador").Rows.Find(pTabla);
            dr["dvv"] = dvv[pTabla];
            dr["fechaActualizacion"] = DateTime.Now;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("DigitoVerificador");
        }
    }
}
