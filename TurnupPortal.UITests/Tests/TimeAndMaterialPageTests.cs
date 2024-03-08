using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Pages.Login;
using TurnupPortal.UITests.Pages.TimeAndMaterials;
using TurnupPortal.UITests.Reporting;
using TurnupPortal.UITests.TestBase;

namespace TurnupPortal.UITests.Tests
{
    [TestFixture]
    public class TimeAndMaterialPageTests : TestSetup
    {
        private LoginPageObjects loginPage;
        private TimeAndMaterialsPageObjects timeAndMaterialsPage;


        [SetUp]
        public void Setup()
        {
            base.Setup();
            _driverUtils!.InitializeDriver(Driver!);
            loginPage = new LoginPageObjects(_appUtilities!, _loginPageHelper!, _homePageHelper!);
            timeAndMaterialsPage = new TimeAndMaterialsPageObjects(_appUtilities!, _navigationHelper, _timeAndMaterialPageHelper!);
            loginPage.LoginWithValidUserAndPassword(_globalProperties!.ValidUser, _globalProperties!.ValidPassword);
            timeAndMaterialsPage.NavigateToPage("Time & Materials");

        }

        [Test, Order(1),]
        public void VerifyCreatingNewTimeAndMaterialRecord()
        {
            _extentTest = ExtentUtility.CreateTest(TestContext.CurrentContext!.Test.MethodName!);
            Assert.IsTrue(timeAndMaterialsPage.CreateNewRecord("Time","TA-12", "Test Description", "20.0"));

            
            // _homePageHelper!.LogoutUser();
        }

    }
}
