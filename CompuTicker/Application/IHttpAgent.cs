using System;
using System.Threading;
using System.Threading.Tasks;

namespace CompuTicker.Application
{
    public interface IHttpAgent<TResource>
    {
        event EventHandler NetworkErrorEncountered;
        Task<TResource>
            GetResourceAsync(CancellationToken cancellationToken, string requestUri);

    }
}
