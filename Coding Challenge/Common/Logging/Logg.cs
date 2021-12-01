using Microsoft.Extensions.Logging;

namespace Coding_Challenge.Common.Logging
{
    public class Logg : ILogg
    {
        private readonly ILogger logger;

        public Logg(ILogger<Logg> logger)
        {
            this.logger = logger;
        }

        public void LogDebug(string message)
        {
            this.logger.LogDebug(message);
        }

        public void LogError(string message)
        {
            this.logger.LogError(message);
        }

        public void LogInformation(string message)
        {
            this.logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            this.logger.LogWarning(message);
        }
    }
}