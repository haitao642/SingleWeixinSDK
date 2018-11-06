using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public static class LogHelper
    {
        public static log4net.ILog LogI = log4net.LogManager.GetLogger(ConfigValue.AppLogName);

        public static void LogInfo(string message)
        {
            if (ConfigValue.DBAppErrors)
            {
                LogI.Info(message);
            }
        }
        public static void LogDebug(string message)
        {
            if (!ConfigValue.DBAppErrors)
            {
                LogI.Info(message);
            }
        }
    }

    /// <summary>
    /// 智能遥控器接口的日志
    /// </summary>
    public static class LogSmartHelper
    {
        public static log4net.ILog LogSmart = log4net.LogManager.GetLogger("SmartLog");

        public static void LogInfo(string message)
        {
            LogSmart.Error(message);
        }
    }
}
