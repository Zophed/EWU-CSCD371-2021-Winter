using System;
using System.IO;

namespace Logger
{
    public class LogFactory
    {
        private string? FilePath { get; set; }

        public void ConfigureFileLogger(string filePath)
        {
            this.FilePath = filePath;
        }

        public BaseLogger? CreateLogger(string className)
        {
            /*
             * Cancels the operation if the filePath value was not assignmed by
             * the ConfigureFileLogger method
            */
            if (FilePath == null)
            {
                return null;
            }
            else if (!File.Exists(FilePath))
            {
                return null;
            }

            FileLogger logger = new FileLogger(FilePath) { ClassName = className };
               
            return logger;  
        }
    }
}
