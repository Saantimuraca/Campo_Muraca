using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var logDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "TecnoSoft", "TuApp", "logs");
            Directory.CreateDirectory(logDir);
            var log = Path.Combine(logDir, "startup.log");
            File.AppendAllText(log, $"[{DateTime.Now}] Main INICIO\n");

            /*Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => { File.AppendAllText(log, $"[{DateTime.Now}] ERROR UI: {e.Exception}\n"); MessageBox.Show(e.Exception.Message); };
            AppDomain.CurrentDomain.UnhandledException += (s, e) => { File.AppendAllText(log, $"[{DateTime.Now}] ERROR BG: {e.ExceptionObject}\n"); };*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                var admin = Admin_Forms.INSTANCIA;
                admin.Definir_Estado(new EstadoIniciarSesion());
                File.AppendAllText(log, $"[{DateTime.Now}] Después de Definir_Estado\n");
            }
            catch (Exception ex)
            {
                File.AppendAllText(log, $"[{DateTime.Now}] ERROR MAIN: {ex}\n");
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
    }
}
