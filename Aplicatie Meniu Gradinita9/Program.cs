using System;
using System.Windows.Forms;
using QuestPDF.Infrastructure;
using QuestPDF.Companion;
using QuestPDF.Fluent;


namespace Aplicatie_Meniu_Gradinita9
{
    internal static class Program
    {
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            QuestPDF.Settings.License = LicenseType.Community;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
           

        }
    }
}
