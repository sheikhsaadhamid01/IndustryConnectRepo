using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;
using TurnupPortal.UITests.Abstractions.Pages;

namespace TurnupPortal.UITests.Pages.Login
{
    public class LoginPageHelpers : ILoginPageHelper
    {
        private IAppUtilities _appUtilities;

        public LoginPageHelpers(IAppUtilities appUtilities)
        {
            this._appUtilities = appUtilities;
        }



        public void EnterUserNamePasswordAndClickLogin(string userName, string password)
        {
            _appUtilities.EnterDataInInputField(userName, LoginLocators.UserNameField);
            _appUtilities.EnterDataInInputField(password, LoginLocators.PasswordField);
            _appUtilities.ClickButton(LoginLocators.LoginButton);
        }
    }
}
