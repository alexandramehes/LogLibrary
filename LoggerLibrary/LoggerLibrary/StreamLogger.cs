using LoggerLibrary.Interface;
using LoggerLibrary.Model;

namespace LoggerLibrary
{
    public class StreamLogger : ILoggerFactory
    {
        private Stream _stream;
        private StreamWriter _streamWriter;

        public StreamLogger(Stream _stream)
        {
            this._stream = _stream;
            _streamWriter = new StreamWriter(_stream);
        }

        public async Task CreateAsyncLog(Log log)
        {
            await _streamWriter.WriteLineAsync($"{DateTime.Now} [{log.Type}] {log.Message}");
            _streamWriter.Flush();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
