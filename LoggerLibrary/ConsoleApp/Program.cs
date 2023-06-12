using LoggerLibrary;
using LoggerLibrary.Model;

class Program
{
    static void Main(string[] args)
    {
        Log infoLog = new Log(LogType.Info, "Info log message");
        Log errorLog = new Log(LogType.Error, "Error log message");
        Log debugLog = new Log(LogType.Debug, "Debug log message");

        //ConsoleLogger
        LoggerLibrary.Interface.ILoggerFactory consoleLogger = new ConsoleLogger();
        consoleLogger.CreateAsyncLog(infoLog);
        consoleLogger.CreateAsyncLog(errorLog);
        consoleLogger.CreateAsyncLog(debugLog);

        //FileLogger
        LoggerLibrary.Interface.ILoggerFactory fileLogger = new FileLogger("log.txt");
        fileLogger.CreateAsyncLog(infoLog);
        fileLogger.CreateAsyncLog(errorLog);
        fileLogger.CreateAsyncLog(debugLog);

        //StreamLogger
        using (MemoryStream stream = new MemoryStream())
        {
            LoggerLibrary.Interface.ILoggerFactory streamLogger = new StreamLogger(stream);
            streamLogger.CreateAsyncLog(infoLog);
            streamLogger.CreateAsyncLog(errorLog);
            streamLogger.CreateAsyncLog(debugLog);

            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string log = reader.ReadToEnd();

            Console.WriteLine(log);
        }
    }
}