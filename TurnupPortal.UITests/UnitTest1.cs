using TurnupPortal.UITests.Pages.Login;
using TurnupPortal.UITests.TestBase;

namespace TurnupPortal.UITests
{
    public class Tests : TestSetup
    {

        private LoginPageObjects loginPage;

        public Tests()
        {
            loginPage = new LoginPageObjects(_driverUtils!, _globalProperties!, _defaultProperties!, _appUtilities!, _loginPageHelper!);
        }
        [SetUp]
        public void Setup()
        {
            base.Setup();
            
        }

        [Test]
        public void VerifyLoginWithValidCredentials()
        {
            loginPage.LoginWithInValidCredentials(_globalProperties!.ValidUser, _globalProperties!.ValidPassword);
        }
    }
}