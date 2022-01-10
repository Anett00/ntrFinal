using FuseNit.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuseNit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Pages.LogIn.LogIn logIn = new Pages.LogIn.LogIn();
            if (logIn.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new HomePage(HomePage.user));
            }
        }
    }
}
