namespace CQRS.Application.Contracts.Logging
{
    public interface IAppLogger<T>
    {
        void LogInfo(string message, params object[] args);
        void LogWarn(string message, params object[] args);
        void LogDebug(string message, params object[] args);
        void LogError(string message, params object[] args);
    }
}
