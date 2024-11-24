using Serilog;

namespace backend.Utils
{
    public class ApplicationLogger
    {
        public void LogDebug(string message)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("~/Logs/debug-logs.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:1j}{NewLine}{Exception}").CreateLogger();
            Log.Debug(message);
        }

        public void LogInformation(string message)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("~/Logs/information-logs.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:1j}{NewLine}{Exception}").CreateLogger();
            Log.Information(message);
        }

        public void LogWarning(string message)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("~/Logs/warning-logs.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:1j}{NewLine}{Exception}").CreateLogger();
            Log.Warning(message);
        }

        public void LogError(string message)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("~/Logs/error-logs.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:1j}{NewLine}{Exception}").CreateLogger();
            Log.Error(message);
        }

        public void LogFatal(string message)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("~/Logs/fatal-logs.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:1j}{NewLine}{Exception}").CreateLogger();
            Log.Fatal(message);
        }
    }
}
