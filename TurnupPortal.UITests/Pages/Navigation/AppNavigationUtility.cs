using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;
using TurnupPortal.UITests.Abstractions.Pages;

namespace TurnupPortal.UITests.Pages.Navigation
{
    public class AppNavigationUtility : INavigationHelper
    {
        private IDriverUtils _driverUtility;
        private IGlobalProperties _globalProperties;
        private IDefaultProperties _defaultProperties;
        private IWaitUtils _waitUtils;
        private IAppUtilities _appUtilities;

        public AppNavigationUtility(IDriverUtils driverUtils, IGlobalProperties globalProperties, IDefaultProperties defaultProperties, IWaitUtils waitUtils, IAppUtilities appUtilities)
        {
            this._defaultProperties = defaultProperties;
            this._globalProperties = globalProperties;
            this._driverUtility = driverUtils;
            this._waitUtils = waitUtils;
            _appUtilities = appUtilities;

        }

        public void NavigateToPage(string pageName)
        {
            string areaname = pageName.ToLower();
            switch (areaname)
            {
                case "administration":
                    {
                        AppNavigationLocators.AppArea = pageName;
                        _appUtilities.ClickElementByActions(AppNavigationLocators.AreaLocator);
                        break;
                    }
                case "customers":
                case "employees":
                case "time & materials":
                case "companies":
                    {
                        NavigateToAdminSections(pageName);
                        break;

                    }
                default:
                    {
                        AppNavigationLocators.AppArea = pageName;
                        _appUtilities.ClickElementByActions(AppNavigationLocators.AreaLocator);
                        break;
                    }

            }
           

            
            
            
        }

        private void NavigateToAdminSections(string pageName)
        {
            
            AppNavigationLocators.AppArea = "Administration ";
            _appUtilities.ClickElementByActions(AppNavigationLocators.AreaLocator);
            AppNavigationLocators.AppArea = pageName;
            _appUtilities.ClickElementByActions(AppNavigationLocators.AreaLocator);

        }

    }
}
