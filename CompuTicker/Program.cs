using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompuTicker.Application;
using CompuTicker.Business;
using CompuTicker.Models;
using CompuTicker.UI;

namespace CompuTicker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Inject all dependencies and configuration settings
            var mainForm = new MainForm(
                    new MainController(
                        httpAgent: new HttpAgent<EquationModel>(),
                        calculatorAggregate: new CalculatorAggregate(),
                        serviceUri: Config.GetServiceUri(),
                        pollingInterval: Config.GetPollingInterval()));

            System.Windows.Forms.Application.Run(mainForm);
        }
    }
}
