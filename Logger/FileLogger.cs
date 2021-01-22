using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string? filePath;
        public string FilePath
        {
            get => filePath!;
            set => filePath = value ?? throw new ArgumentNullException(null);
        }

        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            TextWriter appendMessage;
            if (FilePath != null && File.Exists(FilePath))
            {
                appendMessage = new StreamWriter(FilePath);
                string dateTime = DateTime.Now.ToString("yyyy-MM-dd_HH:mm");
                appendMessage.WriteLine("Date/time: " + dateTime);
                appendMessage.WriteLine(base.ClassName);
                appendMessage.WriteLine(logLevel);
                appendMessage.WriteLine(message);
                appendMessage.Close();
            }else{
                throw new FileNotFoundException();
            }
        }
    }
}
