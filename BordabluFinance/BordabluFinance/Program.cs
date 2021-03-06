using Presentation;
using Presentation.Classes;
using Presentation.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BordabluFinance
{
    static class Program
    {
        public static Bordablu mainForm;
        private static string appGuid = "c0a76b5a-12ab-45c5-b9d9-d693faa6e7b9";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new Bordablu();
            Cache.AddOrderForm = new AddOrderForm("Agregar Orden");
            Cache.ModifyOrderForm = null;
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    return;
                }
                Application.Run(mainForm);
            }
        }
    }
}
