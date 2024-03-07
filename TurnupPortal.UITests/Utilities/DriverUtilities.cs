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

namespace TurnupPortal.UITests.Utilities
{
    public class DriverUtilities :  IDriverUtils
    {
       
            
        
        private Actions? _actions;

        public IWebDriver? Driver { get; private set; }


        public IWebDriver InitializeDriver(IWebDriver driver)
        {
            if (this.Driver == null)
            {
                this.Driver = driver;
                _actions = new Actions(this.Driver);
            }
            return Driver;
        }

        public void NavigateToUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                Driver?.Navigate().GoToUrl(url);
            }
            else
            {
                throw new ArgumentException($"Null or Empty value provided for {MethodBase.GetCurrentMethod()?.Name}");
            }
        }

        public void SendText(IWebElement element, string text)
        {
            if (element != null && !string.IsNullOrEmpty(text))
            {

                _actions!.MoveToElement(element).Click().SendKeys(text).Build().Perform();
                
            }
            else
            {
                throw new ArgumentException("Null or Empty values are provided");
            }
        }


        public void ClickElement(IWebElement element)
        {
            element.Click();

        }


        public void ClickThroughJavascript(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver!;
            js.ExecuteScript("arguments[0].click();", element);
        }

        public string GetElementText(IWebElement element)
        {
            string elementText = string.Empty;
            if (element != null)
            {
                elementText = element.Text.Trim();
            }

            return elementText;
        }


        public bool IsDisplayed(IWebElement element)
        {
            return element.Displayed;
        }
        public void Close()
        {
            if (Driver != null)
            {
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
            IAlert alert = (IAlert)Driver!;
            alert.Accept();
        }

        public void SwitchToAlertandDecline()
        {
            IAlert alert = (IAlert)Driver!;
            alert.Dismiss();
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
