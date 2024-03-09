using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;
using TurnupPortal.UITests.TestBase;
using System.Reflection;
using System.Security.Policy;
using log4net;

namespace TurnupPortal.UITests.Utilities
{
    public class DriverUtilities :  IDriverUtils
    {
       
            
        
        private Actions? _actions;
        private static log4net.ILog? _log = LogManager.GetLogger(MethodBase.GetCurrentMethod()!.DeclaringType);

        public IWebDriver? Driver { get; private set; }


        public IWebDriver InitializeDriver(IWebDriver driver)
        {
            if (this.Driver == null)
            {
                _log.Debug("Initialized Driver.");
                this.Driver = driver;
                _log.Debug("Initialized Driver Actions.");
                _actions = new Actions(this.Driver);
            }
            _log.Debug($"Return Driver object: {Driver}");
            return Driver;
        }

        public void NavigateToUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                _log.Debug($"Navigation to URL : {url}");
                Driver?.Navigate().GoToUrl(url);
            }
            else
            {
                _log.Error($"Null or Empty value provided for {MethodBase.GetCurrentMethod()?.Name}");
                throw new ArgumentException($"Null or Empty value provided for {MethodBase.GetCurrentMethod()?.Name}");
            }
        }
       
        public void SendText(IWebElement element, string text)
        {
            if (element != null && !string.IsNullOrEmpty(text))
            {
                _log!.Debug("Clicking element through Javascript Executor");
                ClickThroughJavascript(element);
                _log.Debug("Clearing any data in input field");
                element.Clear();
                _log.Debug($"Sending {text} in input field.");
                element.SendKeys(text);
                
            }
            else
            {
                _log.Error("Null or Empty values are provided");
                throw new ArgumentException("Null or Empty values are provided");
            }
        }


        public void ClickElement(IWebElement element)
        {
            _log.Debug("Clicking element");
            element.Click();

        }


        public void ClickThroughJavascript(IWebElement element)
        {
            _log.Debug("Initializing JavaScript Executor");
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver!;
            _log.Debug("Executing Javacript click on element.");
            js.ExecuteScript("arguments[0].click();", element);
        }

        public string GetElementText(IWebElement element)
        {
            string elementText = string.Empty;
            if (element != null)
            {
                _log.Debug("Getting Element Text from the element");
                elementText = element.Text.Trim();
                _log.Debug($"Text : {elementText}");
            }

            return elementText;
        }
       

        public bool IsDisplayed(IWebElement element)
        {
            _log.Debug($"Returning element if its displayed {element.Displayed}");
            return element.Displayed;
        }
        public void Close()
        {
            if (Driver != null)
            {
                _log.Debug("Closing the Driver and making it null to release the object.");
                Driver.Close();
                Driver = null;
            }
        }

        public string GetScreenShot(IWebDriver driver)
        {

            ITakesScreenshot takeScreenShot = (ITakesScreenshot)driver;
            Screenshot screenshot = takeScreenShot.GetScreenshot();
            var image = screenshot.AsBase64EncodedString;
            return image;


        }

        public void MoveToElementAndClick(IWebElement element)
        {
            _actions!
                .MoveToElement(element)
                .Click()
                .Build()
                .Perform();
        }

        public void SwtichToAlertAndAccept()
        {
            Driver!.SwitchTo().Alert().Accept();
        }

        public void SwitchToAlertandDecline()
        {
            Driver!.SwitchTo().Alert().Dismiss();
        }

        public void Quit()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}
