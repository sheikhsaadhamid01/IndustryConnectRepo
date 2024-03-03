using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupPortal.UITests.Pages.Login
{
    public class LoginLocators
    {
        public static By UserNameField { get => By.XPath("//input[@id='UserName']") ; }
        public static By PasswordField { get => By.XPath("//input[@id='Password']"); }

        public static By LoginButton { get => By.XPath("//input[@type='submit']"); }

        public static By RememberMeCheckBox { get => By.XPath("//input[@id='RememberMe']"); }

        public static By ValidationErrorMessage { get => By.XPath("//div[@class='validation-summary-errors']//li"); }


    }
}
