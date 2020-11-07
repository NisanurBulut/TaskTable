using NLog;
using TaskTable.Business.Interfaces;

namespace TaskTable.Business.Logger
{
    public class NLogger : INLogger
    {
        public void ErrorLog(string message)
        {
            var logger = LogManager.GetLogger("loggerFile");
            logger.Log(LogLevel.Error, message);
        }
    }
}
