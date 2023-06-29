namespace MCSLogger.Interfaces
{
    public interface ILogger
    {
        bool PrintToConsole { get; set; }
        bool ErrorOnHttpFail { get; set; }
        bool SendLogsToServer { get; set; }
        string ServiceID { get; set; }


        void LogDebug(string message, Dictionary<string, object>? metaData = null);
        void LogError(string message, Dictionary<string, object>? metaData = null);
        void LogInfo(string message, Dictionary<string, object>? metaData = null);
        void LogWarning(string message, Dictionary<string, object>? metaData = null);
    }
}