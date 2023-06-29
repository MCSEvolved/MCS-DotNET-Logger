# MCSLogger
A package for handling logs like sending them to a server and writing them to a console in a nice format. 

## How to install
You can download it from the nuget package manager in visual studio or you can run: 

```dotnet add package mcslogger```

in the command prompt / shell.

## How to use

## Settings
You can set the settings for the logger by creating a new logger setting the values during construction.

```csharp
Logger logger = new(logURL, serviceID, authorizationHandler)
{
    ErrorOnHttpFail = true,     //Default is false
    SendLogsToServer = true,    //Default is true
    PrintToConsole = true       //Default is true
};
```

#### ErrorOnHttpFail  
If set to true, the logger will throw an exception if it fails to send the log to the server. If set to false, it will just print the error to the console.
Send

#### SendLogsToServer  
If set to true, the logger will try to send logs to the specified URL.

#### PrintToConsole  
If set to true, the logger will print the logs to the console.
