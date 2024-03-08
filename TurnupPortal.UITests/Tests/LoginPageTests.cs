using AventStack.ExtentReports;
using System.Net.NetworkInformation;
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

            try
            {
                _extentTest.Log(Status.Info, "About to Initialise Driver");
                _driverUtils!.InitializeDriver(Driver!);
                _extentTest.Log(Status.Info, $"About to perform login with username: {_globalProperties!.ValidUser} and password: {_globalProperties!.ValidPassword}");
                Assert.IsTrue(loginPage.LoginWithValidUserAndPassword(_globalProperties!.ValidUser, _globalProperties!.ValidPassword), "Login Failed.");
            }
            catch (Exception ex)
            {
                _extentTest.Log(Status.Fail, ex.InnerException);
                Assert.Fail(ex.Message);
            }
            // _homePageHelper!.LogoutUser();
        }

        [Test, Order(2)]
        public void VerifyLoginWithInvalidCredentials()
        {
            _extentTest = ExtentUtility.CreateTest(TestContext.CurrentContext!.Test.MethodName!);
            try
            {
                _extentTest.Log(Status.Info, "About to Initialise Driver");
                _driverUtils!.InitializeDriver(Driver!);
               
                _extentTest.Log(Status.Info, $"About to perform login with username: {_globalProperties!.InvalidUser} and password: {_globalProperties!.InvalidPassword}");
                string message = loginPage.LoginWithInValidCredentials(_globalProperties!.InvalidUser, _globalProperties!.InvalidPassword);

                Assert.AreEqual("Invalid username or password.", message);
            }
            catch (Exception ex)
            {
                _extentTest.Log(Status.Fail, ex.InnerException);
                Assert.Fail( ex.Message);
            }
            
        }

       
    }
}