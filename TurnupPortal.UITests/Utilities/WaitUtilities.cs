using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;

namespace TurnupPortal.UITests.Utilities
{
    public class WaitUtilities : IWaitUtils
    {

        private IGlobalProperties _globalProperties;
        private IDefaultProperties _defaultProperties;
        private WebDriverWait _wait;

        public WaitUtilities(IGlobalProperties globalProperties, IDefaultProperties defaultProperties)
        {
            this._defaultProperties = defaultProperties;
            this._globalProperties = globalProperties;
        }


        public IWebElement GetElement(IWebDriver driver, By locator, string waitType, double time)
        {
            if (driver != null && !string.IsNullOrEmpty(waitType))
            {
               
                try
                {
                    _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
                    switch (waitType.ToLower())
                    {
                        case "visible":
                            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
                        case "clickable":
                            return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                        case "exists":
                            return _wait.Until(ExpectedConditions.ElementExists(locator));
                        case "selectable":

                        default:
                            return null!;

                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"{MethodBase.GetCurrentMethod()?.Name}  - {e.InnerException}");
                }
               

            }
            else
            {
                throw new ArgumentNullException($"Null arguments are provided in {MethodBase.GetCurrentMethod()?.Name} ");
            }

        }


        public ReadOnlyCollection<IWebElement> GetElements(IWebDriver driver, By locator, string waitType, double time)
        {
            if (driver != null && !string.IsNullOrEmpty(waitType))
            {
                try
                {
                    _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));

                    switch (waitType.ToLower())
                    {
                        case "presence":
                            return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
                        case "visibility":
                            return _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));

                        default:
                            return null!;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"{MethodBase.GetCurrentMethod()?.Name}  - {e.InnerException}");
                }

            }
            else
            {
                throw new ArgumentNullException($"Null arguments are provided in {MethodBase.GetCurrentMethod()?.Name} ");
            }

        }
    }
}
