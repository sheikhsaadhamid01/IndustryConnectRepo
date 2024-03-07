using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;
using TurnupPortal.UITests.Params;

namespace TurnupPortal.UITests.TestBase
{
    public class BrowserFactory : IBrowserFactory
    {
        private IDefaultProperties _defaultProperties;
        private IGlobalProperties _globalProperties;
        private IWebDriver _driver;


        public BrowserFactory(IDefaultProperties defaultProperties, IGlobalProperties globalProperties)
        {
            this._defaultProperties = defaultProperties;
            this._globalProperties = globalProperties;
        }
        public WebDriver GetWebDriver
        {
            get
            {
                switch (_globalProperties.Browser)
                {
                    case "chrome":
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--incognito");
                        return new ChromeDriver(options);

                    case "firefox":
                        return new FirefoxDriver();

                    case "edge":
                        return new EdgeDriver();

                    default:
                        return new ChromeDriver();
                }
            }
        }
    }
}
