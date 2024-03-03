using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;

namespace TurnupPortal.UITests.Utilities
{
    public class AppUtilites : IAppUtilities
    {
        private IDriverUtils _driverUtility;
        private IGlobalProperties _globalProperties;
        private IDefaultProperties _defaultProperties;
        private IWaitUtils _waitUtils;
        private double _waitTime;


        public AppUtilites(IDriverUtils driverUtils, IGlobalProperties globalProperties, IDefaultProperties defaultProperties, IWaitUtils waitUtils)
        {
            this._defaultProperties = defaultProperties;
            this._globalProperties = globalProperties;
            this._driverUtility = driverUtils;
            this._waitUtils = waitUtils;
            _waitUtils = waitUtils;
            _waitTime = _globalProperties.ExplicitWaitTime;

        }


        public void EnterDataInInputField(string text, By locator)
        {
            try
            {
                IWebElement inputField = _waitUtils!.GetElement(_driverUtility.Driver, locator, "visible", _waitTime);
                _driverUtility.SendText(inputField, text);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        
        }

        public void ClickButton(By locator)
        {
            try
            {
                IWebElement button = _waitUtils!.GetElement(_driverUtility.Driver, locator, "clickable", _waitTime);
                _driverUtility.ClickElement(button);
            }
            
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetValidationText(By locator)
        {
            string validationText = "";
            IWebElement message = _waitUtils.GetElement(_driverUtility.Driver, locator, "visible", _waitTime);
            validationText = _driverUtility.GetElementText(message);
            return validationText;
        }


    }
}
