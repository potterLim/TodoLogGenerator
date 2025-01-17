using System;
using System.IO;

namespace TodoLogGenerator
{
    /// <summary>
    /// Logger class that handles logging of exceptions and errors.
    /// Logs are saved in a "Logs" directory, and the error details are appended to the "ErrorLog.txt" file.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Logs an exception to the "ErrorLog.txt" file in the "Logs" directory.
        /// If the "Logs" directory doesn't exist, it will be created.
        /// </summary>
        /// <param name="filePath">The path of the file where the exception occurred.</param>
        /// <param name="ex">The exception that needs to be logged.</param>
        public static void LogException(string filePath, Exception ex)
        {
            string logsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            // Ensure that the Logs directory exists, create it if it doesn't
            if (!Directory.Exists(logsDirectory))
            {
                Directory.CreateDirectory(logsDirectory);
            }

            string logFilePath = Path.Combine(logsDirectory, "ErrorLog.txt");

            try
            {
                // Append the exception details to the log file, with a timestamp
                File.AppendAllText(logFilePath,
                    $"{DateTime.Now}: Error processing file '{filePath}': {ex.Message}{Environment.NewLine}");
            }
            catch
            {
                // Silently ignore any logging failures to prevent further exceptions
            }
        }
    }
}
