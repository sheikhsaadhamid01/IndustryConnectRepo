using TurnupPortal.UITests.Pages.Login;
using TurnupPortal.UITests.Reporting;
using TurnupPortal.UITests.TestBase;
using TurnupPortal.UITests.Utilities;

namespace TurnupPortal.UITests.Tests
{
    [TestFixture]
    public class LoginPageTests : TestSetup
    {

        private LoginPageObjects loginPage;

        
        [SetUp]
        public void Setup()
        {
            base.Setup();
            loginPage = new LoginPageObjects( _appUtilities!, _loginPageHelper!, _homePageHelper!);
            


        }

        [Test, Order(1), ]
        public void VerifyLoginWithValidCredentials()
        {
            _extentTest = ExtentUtility.CreateTest(TestContext.CurrentContext!.Test.MethodName!);
            _driverUtils!.InitializeDriver(Driver!);
            Assert.IsTrue(loginPage.LoginWithValidUserAndPassword(_globalProperties!.ValidUser, _globalProperties!.ValidPassword), "Login Failed.");
           // _homePageHelper!.LogoutUser();
        }

        [Test, Order(2)]
        public void VerifyLoginWithInvalidCredentials()
        {
            
            _driverUtils!.InitializeDriver(Driver!);

            string message = loginPage.LoginWithInValidCredentials(_globalProperties!.InvalidUser, _globalProperties!.InvalidPassword);
           
            Assert.AreEqual("Invalid username or password.", message);
        }

       
    }
}