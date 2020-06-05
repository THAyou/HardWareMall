using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HardwareMall.Tool
{
    /// <summary>
    /// 日志服务类
    /// </summary>
    public static class LogService
    {
        private static Logger FileLogger = LogManager.GetLogger("FileLog");
        private static Logger DataBaseLogger = LogManager.GetLogger("DatabaseLog");
        private static bool LogToDataBase = ConfigHelper.Configuration["LogToDataBase"] == "1";

        public static void Trace(string message)
        {
            Task.Factory.StartNew(() =>
            {
                FileLogger.Trace(message);
                if (LogToDataBase)
                    DataBaseLogger.Trace(message);
            });
        }

        public static void Debug(string message)
        {
            Task.Factory.StartNew(() =>
            {
                FileLogger.Debug(message);
                if (LogToDataBase)
                    DataBaseLogger.Debug(message);
            });
        }

        public static void Error(string message)
        {
            Task.Factory.StartNew(() =>
            {
                FileLogger.Error(message);
                if (LogToDataBase)
                    DataBaseLogger.Error(message);
            });
        }

        public static void Info(string message)
        {
            Task.Factory.StartNew(() =>
            {
                FileLogger.Info(message);
                if (LogToDataBase)
                    DataBaseLogger.Info(message);
            });
        }

        public static void Warn(string message)
        {
            Task.Factory.StartNew(() =>
            {
                FileLogger.Warn(message);
                if (LogToDataBase)
                    DataBaseLogger.Warn(message);
            });
        }

        public static void Fatal(string message)
        {
            Task.Factory.StartNew(() =>
            {
                FileLogger.Fatal(message);
                if (LogToDataBase)
                    DataBaseLogger.Fatal(message);
            });
        }
    }
}
