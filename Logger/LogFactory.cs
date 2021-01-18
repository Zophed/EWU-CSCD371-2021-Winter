using System;
using System.IO;

namespace Logger
{
    public class LogFactory
    {
        public string? FilePath { get; private set; }
        private string? ClassName { get; set; } = "LogFactory";
        public BaseLogger CreateLogger(string className)
        {
            BaseLogger? logger = null;
            if (className == nameof(FileLogger))
            {
                ClassName = className;
                string filePath = GetFilePath();
                ConfigureFileLogger(filePath);
#pragma warning disable CS8604 // Possible null reference argument.
                FileLogger fileLogger = new FileLogger(FilePath);
#pragma warning restore CS8604 // Possible null reference argument.
                logger = fileLogger;
                
            }
            if(logger != null)
            {
                return logger;
            }
            
            else
            {
                throw new NullReferenceException("BaseLogger is null, try again");
            }
        }

        public void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;
        }

        private static string GetFilePath()
        {
            return Path.GetRandomFileName();
        }
    }
}
