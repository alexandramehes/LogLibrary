using LoggerLibrary.Interface;
using LoggerLibrary.Model;

namespace LoggerLibrary
{
    public class ConsoleLogger : ILoggerFactory
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public async Task CreateAsyncLog(Log log)
        {
            if (log.Message.Length > 1000)
            {
                throw new Exception("Log message can't be longer than 1000 characters.");
            }

            switch (log.Type)
            {
                case LogType.Info:
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;

                case LogType.Error:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;

                case LogType.Debug:
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;

                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }
            Console.WriteLine($"{DateTime.Now} [{log.Type}] {log.Message}");
            Console.ResetColor();
        }
    }
}