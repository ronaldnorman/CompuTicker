using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CompuTicker.Application
{
    /// <summary>
    /// Handles communication with an API or remote resource
    /// </summary>
    /// <typeparam name="TResource">Type of the object to convert the JSON response  content to</typeparam>
    public class HttpAgent<TResource> : IHttpAgent<TResource>
        where TResource : new()
    {
        // Adds a little retry fault tolerance
        private const int RETRY_COUNT = 3;
        private static readonly TimeSpan DELAY_SECONDS = TimeSpan.FromSeconds(3);

        // Event that notifies listeners of any connection issues
        public event EventHandler NetworkErrorEncountered;

        // A cancellable call to the api
        public async Task<TResource>
            GetResourceAsync(CancellationToken cancellationToken, string requestUri) 
        {
            var currentRetry = 0;

            // Retry loop only
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // The main call to an api 
                    using (var client = new HttpClient())
                    using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri))
                    using (var response = await client.SendAsync(request, cancellationToken))
                    {
                        response.EnsureSuccessStatusCode();
                        var resource = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<TResource>(resource);
                    }
                }
                catch (Exception ex)
                {
                    if (!(ex is OperationCanceledException))
                    {
                        // We have some kind of a connection error that we're working on, notify listeners
                        OnNetworkErrorEncountered(new EventArgs());

                        currentRetry++;

                        if (currentRetry > RETRY_COUNT)
                        {
                            throw;
                        }
                    }
                }

                await Task.Delay(DELAY_SECONDS);
            }

            return default(TResource);
        }

        private void OnNetworkErrorEncountered(EventArgs e)
        {
            NetworkErrorEncountered?.Invoke(this, e);
        }
    }
}
