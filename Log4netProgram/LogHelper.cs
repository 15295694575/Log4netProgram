using System;
using System.IO;
using System.Threading.Tasks;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace Log4netProgram
{
    /// <summary>
    /// 日志的公共帮助类 
    /// </summary>
    public class LogHelper
    {
        private static ILog log;

        static LogHelper()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config")));
            log = log4net.LogManager.GetLogger("myLogger");
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="msg">信息</param>
        public static void ErrorLog(object msg)
        {
            Task.Run(() => log.Error(msg));
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="ex">异常</param>
        public static void ErrorLog(Exception ex)
        {
            Task.Run(() => log.Error(ex.Message + "/r/n" + ex.Source + "/r/n" + ex.TargetSite.ToString() + "/r/n" + ex.StackTrace));
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="ex">异常</param>
        public static void ErrorLog(object msg, Exception ex)
        {
            if (ex == null)
            {
                Task.Run(() => log.Error(msg));
            }
            else
            {
                Task.Run(() => log.Error(msg, ex));
            }
        }

        /// <summary>
        /// 写入info日志
        /// </summary>
        /// <param name="msg">信息</param>
        public static void InfoLog(object msg)
        {
            Task.Run(() => log.Info(msg));
        }
    }
}