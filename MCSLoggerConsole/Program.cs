using MCSLogger;
using MCSLogger.Interfaces;
using MCSLoggerConsole;

IAuthorizationHandler authorizationHandler = new AuthorizationHandlerStub();

string logURL = "https://api.mcsynergy.nl/tracker/message/new";
string serviceID = "MCSLogger-DotNET-Tests";

Logger logger = new(logURL, serviceID, authorizationHandler)
{
    ErrorOnHttpFail = true,
    SendLogsToServer = true
};

logger.LogInfo("This is a test log of type info via console app");
logger.LogWarning("This is a test log of type warning via console app");
logger.LogError("This is a test log of type error via console app");
logger.LogDebug("This is a test log of type debug via console app");
