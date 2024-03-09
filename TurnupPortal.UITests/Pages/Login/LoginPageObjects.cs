using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;
using TurnupPortal.UITests.Abstractions.Pages;
using TurnupPortal.UITests.TestBase;

namespace TurnupPortal.UITests.Pages.Login
{
    public class LoginPageObjects 
    {
        
        private IAppUtilities? _appUtilities;
        private ILoginPageHelper? _loginPageHelper;
        private IHomePageHelper? _homePageHelper;
        private static log4net.ILog? _log;



        public LoginPageObjects( IAppUtilities appUtilities, ILoginPageHelper loginPageHelper, IHomePageHelper homePageHelper)
        {
                
                this._appUtilities = appUtilities;
                this._loginPageHelper = loginPageHelper;
                this._homePageHelper = homePageHelper;
                _log = LogManager.GetLogger(MethodBase.GetCurrentMethod()!.DeclaringType);
        }   

        public bool LoginWithValidUserAndPassword(string userName, string password)
        {
            bool isUserNameDisplayedOnHomePage = false;
            _log!.Info($"About to perform login with Valid Credentials {userName} and {password}");
           _loginPageHelper?.EnterUserNamePasswordAndClickLogin(userName, password);
            _log!.Info($"About to verify if user is navigated to Home page and Greeting text is displayed.");
            isUserNameDisplayedOnHomePage = _homePageHelper!.IsGreetingDisplayedAfterLogin();
            _log.Info($"About to return {isUserNameDisplayedOnHomePage} after the login operation is completed.");
            return isUserNameDisplayedOnHomePage;
        }

        public string LoginWithInValidCredentials(string userName, string password)
        {
            _log!.Info($"About to perform login with Innalid Credentials {userName} and {password}");
            _loginPageHelper?.EnterUserNamePasswordAndClickLogin(userName, password);
            _log!.Info("About to verify and get the text of the Validation message after invalid Login.");
            string message = _appUtilities!.GetValidationText(LoginLocators.ValidationErrorMessage);
            _log!.Info($"Validation Message: {message}");
            return message;

        }

       
        
    }
}
