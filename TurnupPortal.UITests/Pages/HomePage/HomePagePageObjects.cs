using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;

namespace TurnupPortal.UITests.Pages.HomePage
{
    public class HomePagePageObjects
    {
        private IDriverUtils? _driverUtility;
        private IGlobalProperties? _globalProperties;
        private IDefaultProperties? _defaultProperties;
        private IAppUtilities? _appUtilities;

        public HomePagePageObjects(IDriverUtils driverUtils, IGlobalProperties globalProperties, IDefaultProperties defaultProperties, IAppUtilities appUtilities)
        {
            this._driverUtility = driverUtils;
            this._globalProperties = globalProperties;
            this._defaultProperties = defaultProperties;
            this._appUtilities = appUtilities;
        }

        public bool IsGreetingDisplayedAfterLogin()
        {
            bool isDisplayed = false;


            return isDisplayed;
        }
    }
}
