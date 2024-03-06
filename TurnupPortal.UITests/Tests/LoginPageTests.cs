using TurnupPortal.UITests.Pages.Login;
using TurnupPortal.UITests.TestBase;

namespace TurnupPortal.UITests.Tests
{
    public class Tests : TestSetup
    {

        private LoginPageObjects loginPage;

        public Tests()
        {

        }
        [SetUp]
        public void Setup()
        {
            base.Setup();
            loginPage = new LoginPageObjects(_driverUtils!, _globalProperties!, _defaultProperties!, _appUtilities!, _loginPageHelper!, _homePageHelper);
            _driverUtils!.InitializeDriver(Driver!);


        }

        [Test, Order(1)]
        public void VerifyLoginWithValidCredentials()
        {
            Assert.IsTrue(loginPage.LoginWithValidUserAndPassword(_globalProperties!.ValidUser, _globalProperties!.ValidPassword), "Login Failed.");
        }

        [Test, Order(2)]
        public void VerifyLoginWithInvalidCredentials()
        {
            Assert.AreEqual("Invalid username or password.", loginPage.LoginWithInValidCredentials(_globalProperties!.InvalidUser, _globalProperties!.InvalidPassword));
        }
    }
}