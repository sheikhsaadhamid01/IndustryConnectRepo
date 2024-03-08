using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupPortal.UITests.Abstractions
{
    public interface IAppUtilities
    {

        void EnterDataInInputField(string text, By locator);

        void  ClickElement(By locator);

        string GetValidationText(By locator);
        void HandleConfirmationPopUP(string value);
        int GetElementsCount(By locator);
        bool IsElementDisplayed(By locator);
        void ClickElementByActions(By locator);
    }
}
