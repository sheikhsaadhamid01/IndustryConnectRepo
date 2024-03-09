using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TurnupPortal.UITests.Logging
{
    public class LogHelper
    {

        #region Fields

        private IDefaultVariables _iDefaultVariables;

        #endregion

        #region Constructor
        /// <summary>
        /// Initialize the logger with a specific Log level
        // Writes logs to a file available Results folder
        /// </summary>
        public LogHelper(IDefaultVariables iDefaultVariables)
        {
            this._iDefaultVariables = iDefaultVariables;

        }
        #endregion


        #region Methods
        /// <summary>
        /// Initialize Logger for a calling class, provided as a string parameter.
        /// </summary>
        /// <param name="classname"></param>
        /// <returns></returns>
        public static log4net.ILog InitializeLogging(string classname)
        {
            if (string.IsNullOrEmpty(classname))
            {

                Debug.WriteLine("No Class name is provided.");
            }
            ConfigureLoggingXML();
            return log4net.LogManager.GetLogger(classname);



        }

        private static void ConfigureLoggingXML()
        {
            var configFilePath = "..\\..\\..\\Resources\\Log4netSettings.xml";
            var log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(configFilePath));

            var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            var log4NetXml = log4netConfig["Log4NetSettings"]["log4net"];
            log4net.Config.XmlConfigurator.Configure(repo, log4NetXml);
        }



        #endregion
    }
}
