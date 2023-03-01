using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace OpenFlows.SCADASignal.SA.Support.Logging;

public static class Logging
{
    #region Public Static Methods
    public static void SetupLogger(
        LogEventLevel logEventLevel = LogEventLevel.Information,
        string logTemplate = "{Timestamp:HH:mm:ss.ff} | {Level:u3} | {Message}{NewLine}{Exception}")
    {

        var logLevelStr = ConfigurationManager.AppSettings["LogEventLevel"];
        var logTemplateStr = ConfigurationManager.AppSettings["LogTemplate"];
        if (!string.IsNullOrEmpty(logLevelStr))
        {
            try
            {
                logEventLevel = (LogEventLevel)Convert.ToInt16(logLevelStr);
            }
            catch { }
        }
        else
        {
            logEventLevel = LogEventLevel.Information;
        }

#if DEBUG
        logEventLevel = LogEventLevel.Debug;
#endif


        if (!string.IsNullOrEmpty(logTemplateStr))
            logTemplate = logTemplateStr;


        var genericLogFilePath = AppManager.Instance.AppGenericLogFilePath;

        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.ControlledBy(LoggingLevelSwitch) // Default's to Information 
            .WriteTo.Console(outputTemplate: logTemplate, theme: AnsiConsoleTheme.Code)
            .WriteTo.Debug(outputTemplate: logTemplate)
            .WriteTo.File(
                genericLogFilePath,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7,
                flushToDiskInterval: TimeSpan.FromSeconds(5),
                outputTemplate: logTemplate)
            .CreateLogger();

        LoggingLevelSwitch.MinimumLevel = logEventLevel;

        Log.Information(new string('█', 100));
        Log.Debug($"Logger is ready. Path: {genericLogFilePath}");
    }

    public static string GetLogFilePath()
    {
        var logDirectoryInfo = new FileInfo(AppManager.Instance.AppGenericLogFilePath).Directory;
        if (!logDirectoryInfo.Exists)
            return String.Empty;

        var logFilePath = logDirectoryInfo.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
        Log.Information($"Latest modified log file: {logFilePath.FullName}");

        return logFilePath.FullName;
    }
    #endregion

    #region Public Static Properties
    public static LoggingLevelSwitch LoggingLevelSwitch { get; } = new LoggingLevelSwitch();
    #endregion

    #region Private Properties
    #endregion

}
