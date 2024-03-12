using AventStack.ExtentReports;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;
using TurnupPortal.UITests.Abstractions.Pages;
using TurnupPortal.UITests.DIContainerServices;
using TurnupPortal.UITests.Logging;
using TurnupPortal.UITests.Reporting;
using TurnupPortal.UITests.Utilities;

namespace TurnupPortal.UITests.TestBase
{
    public class TestSetup
    {

        protected IDefaultProperties? _defaultProperties;
        protected IGlobalProperties? _globalProperties;   
        protected IBrowserFactory? _browserFactory;
        protected IWaitUtils? _waitUtils;
        protected IAppUtilities? _appUtilities;
        protected IDriverUtils? _driverUtils;
        protected IServiceProvider? _service;
        protected IHomePageHelper? _homePageHelper;
        protected ILoginPageHelper? _loginPageHelper;
        protected INavigationHelper? _navigationHelper;
        protected ITimeAndMaterialPageHelper? _timeAndMaterialPageHelper;
        protected static ExtentTest? _parentTest;
        protected static ExtentTest? _extentTest;
        protected string _url = "";
        protected IWebDriver? driver;
        protected static log4net.ILog? _log;

        public IWebDriver? Driver { get; private set; }


        [OneTimeSetUp]
        public void InitTests()
        {
            _service = ContainerConfiguration.ConfigureService();

            if(_service != null)
            {
                _globalProperties = _service?.GetRequiredService<IGlobalProperties>();
                _defaultProperties = _service?.GetRequiredService<IDefaultProperties>();
                _browserFactory = _service?.GetRequiredService<IBrowserFactory>();
                _waitUtils = _service?.GetRequiredService<IWaitUtils>();
                _driverUtils = _service?.GetRequiredService<IDriverUtils>();
                _appUtilities = _service?.GetRequiredService<IAppUtilities>();

                _loginPageHelper = _service?.GetRequiredService<ILoginPageHelper>();
                _homePageHelper = _service?.GetRequiredService<IHomePageHelper>();
                _navigationHelper = _service?.GetRequiredService<INavigationHelper>();
                _timeAndMaterialPageHelper = _service?.GetRequiredService<ITimeAndMaterialPageHelper>();
            }
            ExtentUtility.CreateParentTest(GetType().Name);

            _log = LogHelper.InitializeLogging((System.Reflection.MethodBase.GetCurrentMethod()!.DeclaringType!.ToString()));
        }

        public void Setup()
        {
            Driver = _browserFactory!.GetWebDriver;
           
            Driver.Manage().Cookies.DeleteAllCookies();

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_globalProperties!.ImplicitWaitTime);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_globalProperties!.PageLoadTime);
            Driver.Manage().Cookies.DeleteAllCookies();
         
            
           
            _url = _globalProperties.AppURL;
            Driver.Navigate().GoToUrl(_url);



        }
        [TearDown]
        public void TestClosure()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : $"{TestContext.CurrentContext.Result.StackTrace}";

            switch (status)
            {
                case TestStatus.Failed:
                    ExtentUtility.LogFail(stacktrace);
                    var image = _driverUtils!.GetScreenShot(Driver!);
                    ExtentUtility.LogScreenShot("Please click to see Image of Failed Test", image);

                    break;

                case TestStatus.Skipped:
                    ExtentUtility.LogSkipped(stacktrace);
                    break;

                case TestStatus.Inconclusive:
                    ExtentUtility.LogInfo(stacktrace);
                    break;

                default:
                    if (string.IsNullOrEmpty(stacktrace))
                    {
                        ExtentUtility.LogPass($"Test Execution Completed Successfully for \"{TestContext.CurrentContext.Test.MethodName}\"");
                    }

                    break;
            }

            ExtentUtility.EndReporting();
            //_extentReports = null;
            _driverUtils!.Close();




        }


        [OneTimeTearDown]
        public void CloseEnvironment()
        {
            if (_driverUtils!.Driver != null)
            {
                _driverUtils!.Quit();
            }
             


        }
    }
}
