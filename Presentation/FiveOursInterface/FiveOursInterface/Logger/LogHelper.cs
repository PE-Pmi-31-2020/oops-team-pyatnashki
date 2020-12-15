using System;
using System.Collections.Generic;
using System.Text;

namespace FiveOursInterface.Logger
{
    public static class LogHelper
    {
        private static LogBase _logger = null;

        public static void Log(LogTarget target, LogType logType, string message)
        {
            switch (target)
            {
                case LogTarget.File:
                    _logger = new FileLogger();
                    _logger.Log($"{DateTime.Now} | {logType} | {message}");
                    break;
                default:
                    return;
            }
        }
    }
}
