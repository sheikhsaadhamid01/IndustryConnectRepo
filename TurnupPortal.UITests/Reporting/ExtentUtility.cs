using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;

namespace TurnupPortal.UITests.Reporting
{
    public  class ExtentUtility
    {
        #region Fields
        private static ExtentReports extentReports;
        private static ExtentTest _extentTest;
        private static ExtentTest _parentTest;
        private static IDefaultProperties _defaultProperties;
        private static string _currentFolder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../")?.FullName;
        private static string? _identifier = DateTime.Now.ToString("yyMMdd hhmmss");
        private static string? _results = _currentFolder + @"\Results\";
        private static string? _extentReportPath = _results + _identifier + @"\";

        #endregion


        #region Methods
        public static ExtentReports InitializeReporting()
        {


            
            extentReports = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(_extentReportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extentReports.AttachReporter(htmlReporter);
            extentReports.AddSystemInfo("Environment", "QA");
            extentReports.AddSystemInfo("Tester", Environment.UserName);
            extentReports.AddSystemInfo("MachineName", Environment.MachineName);


            return extentReports;
        }


        public static ExtentReports GetExtentReport()
        {
            if (extentReports == null)
            {
                InitializeReporting();
            }

            return extentReports!;
        }

        public static ExtentTest CreateParentTest(string name)
        {
            _parentTest = GetExtentReport().CreateTest(name);
            return _parentTest;

        }
        public static ExtentTest CreateTest(string testName)
        {
            _extentTest = _parentTest.CreateNode(testName);
            return _extentTest;
        }


        public static void EndReporting()
        {
            GetExtentReport().Flush();
        }


        public static void LogInfo(string message)
        {
            _extentTest.Info(message);
        }
        public static void LogWarning(string message)
        {
            _extentTest.Warning(message);
        }
        public static void LogError(string message)
        {
            _extentTest.Error(message);
        }
        public static void LogPass(string message)
        {
            _extentTest.Pass(message);
        }
        public static void LogFail(string message)
        {
            _extentTest.Fail(message);
        }

        public static void LogSkipped(string message)
        {
            _extentTest.Skip(message);
        }

        public static void LogScreenShot(string info, string image)
        {
            _extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }

        #endregion
    }
}
