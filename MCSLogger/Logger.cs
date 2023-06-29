using System.Net;
using System.Net.Http.Json;
using MCSLogger.Interfaces;

namespace MCSLogger
{
    public class Logger : ILogger
    {
        private readonly HttpClient httpClient;
        private readonly IAuthorizationHandler? authorizationHandler;
        private readonly bool endpointShouldBeAuthorized = false;
        public string ServiceID { get; set; }
        public bool PrintToConsole { get; set; } = true;
        public bool ErrorOnHttpFail { get; set; } = false;
        public bool SendLogsToServer { get; set; } = true;

        /// <summary>
        /// Create an Instance of Logger. <br/>
        /// <paramref name="serviceID"/> is the ID of the service (e.g. Emerald-Exchange). <br/>
        /// <paramref name="logURL"/> is the full url of the endpoint where a log can be posted (e.g. https://api.mcsynergy.nl/message/new).
        /// </summary>  
        public Logger(string logURL, string serviceID)
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri(logURL),
            };

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer ");
            ServiceID = serviceID;
        }

        public Logger(string logURL, string serviceID, IAuthorizationHandler authorizationHandler)
        {
            Uri addressURI = new(logURL);
            httpClient = new HttpClient()
            {
                BaseAddress = addressURI
            };
            httpClient.DefaultRequestHeaders.Host = addressURI.Host;

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer ");
            ServiceID = serviceID;
            this.authorizationHandler = authorizationHandler;
            endpointShouldBeAuthorized = true;
            SetAuthorizationHeaderWithNewToken();
        }

        public void LogInfo(string message, Dictionary<string, object>? metaData = null)
        {
            HandleLog(LogLevel.Info, message, metaData);
        }

        public void LogWarning(string message, Dictionary<string, object>? metaData = null)
        {
            HandleLog(LogLevel.Warning, message);
        }

        public void LogError(string message, Dictionary<string, object>? metaData = null)
        {
            HandleLog(LogLevel.Error, message);
        }

        public void LogDebug(string message, Dictionary<string, object>? metaData = null)
        {
            HandleLog(LogLevel.Debug, message, metaData);
        }

        private void HandleLog(LogLevel type, string message, Dictionary<string, object>? metaData = null)
        {
            Log log = new(type, ServiceID, message, metaData);
            if (PrintToConsole)
            {
                PrintLog(log);
            }
            if (SendLogsToServer)
            {
                SendLog(log);
            }
        }

        private async void SendLog(Log log)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("", log);

            if (response.StatusCode == HttpStatusCode.Unauthorized && endpointShouldBeAuthorized)
            {
                SetAuthorizationHeaderWithNewToken();
                response = await httpClient.PostAsJsonAsync("", log);
            }

            if (!response.IsSuccessStatusCode && ErrorOnHttpFail)
            {
                throw new HttpRequestException($"Failed to send log to server. Status code: {response.StatusCode}. Message: {response.Content}");
            }
        }

        private async void SetAuthorizationHeaderWithNewToken()
        {
            if (authorizationHandler == null)
            {
                throw new Exception("AuthorizationHandler is null");
            }

            httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {await authorizationHandler.GetIdToken()}");
        }

        private void PrintLog(Log log)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = GetConsoleColor(log.Type);

            Console.Write($"[{log.Type}] ");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(log.Content);

            Console.ForegroundColor = oldColor;
        }

        private ConsoleColor GetConsoleColor(LogLevel type)
        {
            return type switch
            {
                LogLevel.Info => ConsoleColor.Green,
                LogLevel.Warning => ConsoleColor.DarkYellow,
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Debug => ConsoleColor.DarkGray,
                _ => ConsoleColor.White
            };
        }
    }
}