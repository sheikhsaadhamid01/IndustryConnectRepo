using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;
using TurnupPortal.UITests.Abstractions.Pages;

namespace TurnupPortal.UITests.Pages.HomePage
{
    public class HomePageHelper : IHomePageHelper
    {
        private IDriverUtils? _driverUtility;
        private IGlobalProperties? _globalProperties;
        private IDefaultProperties? _defaultProperties;
        private IAppUtilities? _appUtilities;

        public HomePageHelper(IDriverUtils driverUtils, IGlobalProperties globalProperties, IDefaultProperties defaultProperties, IAppUtilities appUtilities)
        {
            this._driverUtility = driverUtils;
            this._globalProperties = globalProperties;
            this._defaultProperties = defaultProperties;
            this._appUtilities = appUtilities;
        }

        public bool IsGreetingDisplayedAfterLogin()
        {
            return _appUtilities!.IsElementDisplayed(HomePageLocators.UserNameHeader);
        }

        public void LogoutUser()
        {
            _appUtilities!.ClickElementByActions(HomePageLocators.UserNameHeader);
            _appUtilities!.ClickElementByActions(HomePageLocators.Logoff);
        }
    }
}
