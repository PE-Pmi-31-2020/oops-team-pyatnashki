using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FiveOursInterface
{
    public abstract class LogBase
    {
        protected readonly object LockObj = new object();

        public abstract void Log(string message);
    }


    public class FileLogger : LogBase
    {
        public string LogFilePath { get; set; } = "log.txt";

        public override void Log(string message)
        {
            lock (LockObj)
            {
                using (StreamWriter streamWriter = new StreamWriter(LogFilePath, true))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
        }
    }

}
