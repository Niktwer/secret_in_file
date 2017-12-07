using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace secret_true_version
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string password;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                
            SingleInstanceApplication.Run(new Form_begin(),StartupNextInstanceHandler);
        }

            static void StartupNextInstanceHandler(object sender, StartupNextInstanceEventArgs e)
            {
                // for e.CommandLine...
            }

    }
}
