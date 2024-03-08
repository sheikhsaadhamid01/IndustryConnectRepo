using AventStack.ExtentReports;
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

        [Test, Order(1)]
        public void VerifyCreatingNewTimeAndMaterialRecord()
        {
            _extentTest = ExtentUtility.CreateTest(TestContext.CurrentContext!.Test.MethodName!);
            try
            {
                _extentTest.Log(Status.Info, $"About to create a new Time & Material Record.");
                Assert.IsTrue(timeAndMaterialsPage.CreateNewRecord(_globalProperties!.TypeCode!, _globalProperties!.Code!, _globalProperties!.Description!, _globalProperties!.Price!));
            }

            catch (Exception ex)
            {
                _extentTest.Log(Status.Fail, ex.Message);
                Assert.Fail(ex.Message);
            }
            

            
            // _homePageHelper!.LogoutUser();
        }

        [Test, Order(2)]
        public void VerifyEdittingTimeAndMaterialRecord()
        {
            _extentTest = ExtentUtility.CreateTest(TestContext.CurrentContext!.Test.MethodName!);

            try
            {
                _extentTest.Log(Status.Info, $"About to create a Edit Time & Material Record with code name: {_globalProperties!.CodeToEdit}.");
                Assert.IsTrue(timeAndMaterialsPage.EditTimeAndMaterialRecord(_globalProperties!.NewTypeCode!, _globalProperties!.CodeToEdit!, _globalProperties!.NewCode!, _globalProperties!.NewDescription!));
            }
            catch (Exception ex)
            {
                _extentTest.Log(Status.Fail, ex.Message);
                Assert.Fail(ex.Message);
            }


            // _homePageHelper!.LogoutUser();
        }

        [Test, Order(3)]
        public void VerifyDeletingTimeAndMaterialRecord()
        {
            _extentTest = ExtentUtility.CreateTest(TestContext.CurrentContext!.Test.MethodName!);
            try
            {
                _extentTest.Log(Status.Info, $"About to create a Delete Time & Material Record withe Code name: {_globalProperties!.CodeToDelete}.");
                Assert.IsTrue(timeAndMaterialsPage.DeleteTimeAndMaterialRecord(_globalProperties!.CodeToDelete!));
            }
            catch (Exception ex)
            {
                _extentTest.Log(Status.Fail, ex.Message);
                Assert.Fail(ex.Message);
            }


            // _homePageHelper!.LogoutUser();
        }

    }
}
