using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupPortal.UITests.Pages.Navigation
{
    public class AppNavigationLocators
    {
        public static string AppArea {  get; set; } 
        public static By AreaLocator { get => By.XPath(".//a[text()='"+AppArea+" ']"); }
        public static By Administration { get => By.XPath(".//a[text()='Administration ']"); }


    }
}
