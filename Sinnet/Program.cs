using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sinnet.controller;

namespace Sinnet
{
    static class Program
    {
        private const String dataFilePath = @"C:\projects\sinnet\data\results-open.csv";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainController mainController = new MainController(dataFilePath);
            MainForm form = new MainForm(mainController);
            Application.Run(form);
        }
    }
}
