using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupPortal.UITests.Abstractions
{
    public interface IWaitUtils
    {
        IWebElement GetElement(IWebDriver driver, By locator, string waitType, double time);
        ReadOnlyCollection<IWebElement> GetElements(IWebDriver driver, By locator, string waitType, double time);
    }
}
