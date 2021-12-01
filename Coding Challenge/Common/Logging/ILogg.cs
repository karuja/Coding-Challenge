namespace Coding_Challenge.Common.Logging
{
    public interface ILogg
    {
        public void LogDebug(string message);

        public void LogError(string message);

        public void LogInformation(string message);

        public void LogWarning(string message);
    }
}