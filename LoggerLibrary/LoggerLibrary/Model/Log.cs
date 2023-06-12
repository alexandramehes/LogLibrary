namespace LoggerLibrary.Model
{
    public class Log
    {
        public LogType Type { get; set; }
        public string Message { get; set; }

        public Log(LogType type, string message)
        {
            Type = type;
            Message = message;
        }
    }

    public enum LogType
    {
        Info,
        Error,
        Debug
    }
}
