using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuTicker.Application
{
    /// <summary>
    /// Custom event handler to include necessary event data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void TickerProcessedEventHandler(object sender, TickerProcessedEventArgs e);
}
