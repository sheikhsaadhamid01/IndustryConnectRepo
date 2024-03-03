using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;
using TurnupPortal.UITests.DIContainerServices;

namespace TurnupPortal.UITests.TestBase
{
    public class TestSetup
    {

        protected IDefaultProperties? _defaultProperties;
        protected IGlobalProperties? _globalProperties;   
        protected IBrowserFactory? _browserFactory;
        protected IServiceProvider? _service;
        protected string _url = "";
        protected IWebDriver driver;

        public IWebDriver Driver { get; private set; }


        [OneTimeSetUp]
        public void InitTests()
        {
            _service = ContainerConfiguration.ConfigureService();

            if(_service != null)
            {
                _globalProperties = _service?.GetRequiredService<IGlobalProperties>();
                _defaultProperties = _service?.GetRequiredService<IDefaultProperties>();
                _browserFactory = _service?.GetRequiredService<IBrowserFactory>();
            }
            


        }

        public void Setup()
        {
            Driver = _browserFactory.GetWebDriver;
            Driver.Manage().Cookies.DeleteAllCookies();

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(_globalProperties!.ImplicitWaitTime);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(_globalProperties!.PageLoadTime);
            _url = _globalProperties.AppURL;
            Driver.Navigate().GoToUrl(_globalProperties.AppURL);
        }


        [OneTimeTearDown]
        public void TearDown()
        {

            if (Driver != null)
            {
                Driver.Quit();


            }          


        }
    }
}
