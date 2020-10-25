using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.Service.CustomLogger
{
    public class NLogLogger
    {
        public void LogWithNLog(string message)
        {
            var logger = LogManager.GetLogger("loggerfile");
            logger.Log(LogLevel.Error, message);
        }
    }
}
