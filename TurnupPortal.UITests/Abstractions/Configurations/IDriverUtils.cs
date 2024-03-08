using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupPortal.UITests.Abstractions
{
    public interface IDriverUtils
    {
        IWebDriver? Driver { get; }

        void Close();
        IWebDriver InitializeDriver(IWebDriver driver);
        void NavigateToUrl(string url);
        void SendText(IWebElement element, string text);
        void ClickElement(IWebElement element);
        string GetScreenShot(IWebDriver driver);

        void ClickThroughJavascript(IWebElement element);
        string GetElementText(IWebElement element);
        bool IsDisplayed(IWebElement element);
        void SwtichToAlertAndAccept();
        public void SwitchToAlertandDecline();
        void MoveToElementAndClick(IWebElement element);
        void Quit();

    }
}
