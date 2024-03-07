using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
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
        

        public LoginPageObjects( IAppUtilities appUtilities, ILoginPageHelper loginPageHelper, IHomePageHelper homePageHelper)
        {
                
                this._appUtilities = appUtilities;
                this._loginPageHelper = loginPageHelper;
                this._homePageHelper = homePageHelper;
        }

        public bool LoginWithValidUserAndPassword(string userName, string password)
        {
            bool isUserNameDisplayedOnHomePage = false;
           _loginPageHelper?.EnterUserNamePasswordAndClickLogin(userName, password);

            isUserNameDisplayedOnHomePage = _homePageHelper!.IsGreetingDisplayedAfterLogin();

            return isUserNameDisplayedOnHomePage;
        }

        public string LoginWithInValidCredentials(string userName, string password)
        {
            _loginPageHelper?.EnterUserNamePasswordAndClickLogin(userName, password);
            string message = _appUtilities!.GetValidationText(LoginLocators.ValidationErrorMessage);
            return message;

        }

       
        
    }
}
