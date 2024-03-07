using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupPortal.UITests.Pages.HomePage
{
    public  class HomePageLocators
    {

        public static By UserNameHeader { get => By.XPath(".//a[contains(text(), 'Hello')]"); }

        public static By Logoff { get => By.XPath(".//a[text()='Log off']"); }

    }
}
