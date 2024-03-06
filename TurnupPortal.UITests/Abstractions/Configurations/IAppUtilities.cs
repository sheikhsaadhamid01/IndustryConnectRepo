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

        void ClickButton(By locator);

        string GetValidationText(By locator);

        bool IsElementDisplayed(By locator);
    }
}
