using LoggerLibrary.Interface;
using LoggerLibrary.Model;

namespace LoggerLibrary
{
    public class FileLogger : ILoggerFactory
    {
        private string _filePath;
        private const long MaxSize = 5 * 1024;

        public FileLogger(string filePath)
        {
            this._filePath = filePath;
        }

        public async Task CreateAsyncLog(Log log)
        {
            string logFileFolder = Path.GetDirectoryName(_filePath);
            string fileName = Path.GetFileNameWithoutExtension(_filePath);
            string fileExtension = Path.GetExtension(_filePath);

            string logFile = CreateNextLogFilePath(logFileFolder, fileName, 1, fileExtension);
            int nextNum = 2;

            while (File.Exists(logFile))
            {
                logFile = CreateNextLogFilePath(logFileFolder, fileName, nextNum, fileExtension);
                nextNum++;
            }

            if (File.Exists(_filePath) && new FileInfo(_filePath).Length >= MaxSize)
            {
                File.Move(_filePath, logFile);
            }

            using (StreamWriter streamWriter = File.AppendText(_filePath))
            {
                await streamWriter.WriteLineAsync(BuildLogRecord(log.Type, log.Message));
            }
        }

        public string CreateNextLogFilePath(string logFileFolder, string fileName, int nextNum, string fileExtension)
        {
            return Path.Combine(logFileFolder, $"{fileName}.{nextNum}{fileExtension}");
        }

        public string BuildLogRecord(LogType type, string msg) => $"{DateTime.Now} [{type}] {msg}";

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
