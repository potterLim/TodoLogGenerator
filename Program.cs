using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoLogGenerator
{
    /// <summary>
    /// The entry point for the TODO Log Generator application.
    /// Sets up the application environment and launches the main form.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Initializes application settings and runs the main form.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enables visual styles and sets compatible text rendering for the application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Runs the MainForm, which is the main window of the application
            Application.Run(new MainForm());
        }
    }
}
