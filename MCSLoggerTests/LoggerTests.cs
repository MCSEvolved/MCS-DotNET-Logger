using MCSLogger.Interfaces;
using MCSLoggerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MCSLogger.Tests
{
    [TestClass()]
    public class LoggerTests
    {
        readonly string serviceID = "MCSLogger-DotNET-Tests";
        readonly string logURL = "https://api.mcsynergy.nl/tracker/message/new";
        [TestMethod()]
        public void LogInfoTest_MessageToConsole_ShouldNotThrow()
        {
            // Arrange
            Logger logger = new(logURL, serviceID)
            {
                ErrorOnHttpFail = true,
                SendLogsToServer = false
            };

            // Act
            logger.LogInfo("This is a test log of type info");
        }

        [TestMethod()]
        public void LogWarningTest_MessageToConsole_ShouldNotThrow()
        {
            //Arrange
            Logger logger = new(logURL, serviceID)
            {
                ErrorOnHttpFail = true,
                SendLogsToServer = false
            };

            //Act
            logger.LogWarning("This is a test log of type warning");
        }

        [TestMethod()]
        public void LogErrorTest_MessageToConsole_ShouldNotThrow()
        {
            Logger logger = new(logURL, serviceID)
            {
                ErrorOnHttpFail = true,
                SendLogsToServer = false
            };
            logger.LogError("This is a test log of type error");
        }

        [TestMethod()]
        public void LogDebugTest_MessageToConsole_ShouldNotThrow()
        {
            //Arrange
            Logger logger = new(logURL, serviceID)
            {
                ErrorOnHttpFail = true,
                SendLogsToServer = false
            };

            //Act
            logger.LogDebug("This is a test log of type debug");
        }

        [TestMethod()]
        public void LogInfoTest_WithMetaDataOnlyToConsole_ShouldNotThrow()
        {
            //Arrange
            Logger logger = new(logURL, serviceID)
            {
                ErrorOnHttpFail = true,
                SendLogsToServer = false
            };

            Dictionary<string, object> metaData = new()
            {
                { "metaDatakey1", "metaDataValue1" },
                { "metaDatakey2", "metaDataValue2" }
            };

            //Act
            logger.LogInfo("This is a test log of type info with metadata");
        }
    }
}