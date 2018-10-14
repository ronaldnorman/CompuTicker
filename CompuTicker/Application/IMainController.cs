using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuTicker.Application
{
    public interface IMainController
    {
        Task StartPolling();
        void StopPolling();

        event TickerProcessedEventHandler TickerProcessed;
        event EventHandler NetworkErrorEncountered;
    }
}
