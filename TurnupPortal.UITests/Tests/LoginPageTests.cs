using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using TurnupPortal.UITests.Pages.Login;
using TurnupPortal.UITests.Reporting;
using TurnupPortal.UITests.TestBase;
using TurnupPortal.UITests.Utilities;

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
            loginPage = new LoginPageObjects(_driverUtils!, _globalProperties!, _defaultProperties!, _appUtilities!, _loginPageHelper!, _homePageHelper!);
            


        }

        [Test, Order(1)]
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