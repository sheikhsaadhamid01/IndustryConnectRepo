using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;

namespace TurnupPortal.UITests.Pages.Login
{
    public class LoginPageHelperMethods
    {
        private IDriverUtils _driverUtility;
        private IGlobalProperties _globalProperties;
        private IDefaultProperties _defaultProperties;
        private IAppUtilities _appUtilities;

        public LoginPageHelperMethods(IDriverUtils driverUtils, IGlobalProperties globalProperties, IDefaultProperties defaultProperties, IAppUtilities appUtilities)
        {
                this._defaultProperties = defaultProperties;
                this._globalProperties = globalProperties;
                this._driverUtility = driverUtils;
        }

        public void LoginWithValidUserAndPassword(string userName, string password)
        {
            EnterUserNamePasswordAndClickLogin(userName, password);
        }

        public void LoginWithInValidCredentials(string userName, string password)
        {
            EnterUserNamePasswordAndClickLogin(userName, password);
            string message = _appUtilities.GetValidationText(LoginLocators.ValidationErrorMessage);
        }

        private void EnterUserNamePasswordAndClickLogin(string userName, string password)
        {
            _appUtilities.EnterDataInInputField(userName, LoginLocators.UserNameField);
            _appUtilities.EnterDataInInputField(password, LoginLocators.PasswordField);
            _appUtilities.ClickButton(LoginLocators.LoginButton);
        }
        
    }
}
