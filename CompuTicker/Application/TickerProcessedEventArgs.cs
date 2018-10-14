using CompuTicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuTicker.Application
{
    /// <summary>
    /// Arguments for the main event that provides the UI with the details to display
    /// </summary>
    public class TickerProcessedEventArgs : EventArgs
    {
        public double Result { get; set; }
        public EquationModel Equation { get; set; }
        public DateTime DateProcessed { get; set; }
    }
}
