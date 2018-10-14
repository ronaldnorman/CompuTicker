using System;
using System.Configuration;

namespace CompuTicker.Application
{
    /// <summary>
    /// Wraps all app configurable settings
    /// </summary>
    public static class Config
    {
        public static string GetServiceUri()
        {
            return ConfigurationManager.AppSettings["ServiceUri"];
        }

        public static TimeSpan GetPollingInterval()
        {
            var pollingIntervalSeconds =
                Convert.ToInt32(ConfigurationManager.AppSettings["PollingIntervalSeconds"]);

            return TimeSpan.FromSeconds(pollingIntervalSeconds);
        }

    }
}
