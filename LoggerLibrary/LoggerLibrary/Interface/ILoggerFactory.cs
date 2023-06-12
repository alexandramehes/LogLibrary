using LoggerLibrary.Model;

namespace LoggerLibrary.Interface
{
    public interface ILoggerFactory : IDisposable
    {
        Task CreateAsyncLog(Log log);
    }
}
