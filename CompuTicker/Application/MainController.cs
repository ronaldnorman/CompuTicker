using CompuTicker.Business;
using CompuTicker.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CompuTicker.Application
{
    /// <summary>
    /// Orchestrates the steps to be executed among different components and updates the UI through events
    /// </summary>
    public class MainController : IMainController
    {
        private IHttpAgent<EquationModel> _httpAgent;
        private ICalculatorAggregate _calculatorAggregate;
        private string _serviceUri;
        private TimeSpan _pollingInterval;

        private CancellationTokenSource _cancellationTokenSource;

        // Events supported 
        public event TickerProcessedEventHandler TickerProcessed;
        public event EventHandler NetworkErrorEncountered;

        // Inject all dependencies
        public MainController(
            IHttpAgent<EquationModel> httpAgent,
            ICalculatorAggregate calculatorAggregate,
            string serviceUri,
            TimeSpan pollingInterval)
        {
            _httpAgent = httpAgent;
            _calculatorAggregate = calculatorAggregate;
            _serviceUri = serviceUri;
            _pollingInterval = pollingInterval;

            _httpAgent.NetworkErrorEncountered += this.OnNetworkErrorEncountered;
        }

        // Cancellable steps orchestration that starts the polling per the configured settings
        public async Task StartPolling()
        {
            using (_cancellationTokenSource = new CancellationTokenSource())
            {
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    // Get the equation from the service
                    var equationModel =
                        await _httpAgent.GetResourceAsync(_cancellationTokenSource.Token, _serviceUri);

                    // Calculate the result
                    var result =
                        await _calculatorAggregate.Calculate(equationModel);

                    // Fire the event to notify observers
                    FireTickerProcessedEvent(
                        new TickerProcessedEventArgs
                        {
                            DateProcessed = DateTime.Now,
                            Equation = equationModel,
                            Result = result
                        });

                    // Wait for the polling interval configured
                    await Task.Delay(_pollingInterval, _cancellationTokenSource.Token);
                }
            }
        }

        public void StopPolling()
        {
            _cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Notify the UI of every calculation
        /// </summary>
        /// <param name="e">Event argument containing the data load: equation and result</param>
        protected virtual void FireTickerProcessedEvent(TickerProcessedEventArgs e)
        {
            TickerProcessed?.Invoke(this, e);
        }

        private void OnNetworkErrorEncountered(object sender, EventArgs e)
        {
            this.NetworkErrorEncountered?.Invoke(this, e);
        }
    }
}
