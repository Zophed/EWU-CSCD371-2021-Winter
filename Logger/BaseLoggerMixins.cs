using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params int[] arr)
        {
            
             if (baseLogger == null)
             {
                 throw new ArgumentNullException(nameof(baseLogger));
             }
             else
             {
                 baseLogger.Log(LogLevel.Error, string.Format(message, arr[0]));
             }
        }

        public static void Warning(this BaseLogger baseLogger, string message, params int[] arr)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                baseLogger.Log(LogLevel.Error, string.Format(message, arr[0]));
            }
        }

        public static void Information(this BaseLogger baseLogger, string message, params int[] arr)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                baseLogger.Log(LogLevel.Error, string.Format(message, arr[0]));
            }
        }

        public static void Debug(this BaseLogger baseLogger, string message, params int[] arr)
        {

            if (baseLogger == null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                baseLogger.Log(LogLevel.Error, string.Format(message, arr[0]));
            }
        }

    }
}
