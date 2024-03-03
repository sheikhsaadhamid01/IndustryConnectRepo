using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;



namespace TurnupPortal.UITests.Params
{
    public class GlobalProperties : IGlobalProperties
    {

        #region Fields

        private IConfigurationRoot? _builder;
        private IDefaultProperties _properties;

        #endregion

        #region Properties
        public string? AppURL { get; private set; }
        public string? Browser {  get; private set; }
        public double ImplicitWaitTime { get; private set; }
        public double ExplicitWaitTime { get; private set; }
        public double PageLoadTime { get; set; }
        public string? ValidUser { get; private set; }  
        public string? ValidPassword { get; private set; }

        public string? InvalidUser { get; private set; }
        public string? InvalidPassword { get; private set; }

     

        #endregion


        #region Constructor
        public GlobalProperties(IDefaultProperties defaultProperties)
        {
            _properties = defaultProperties;
            InitializeAppConfiguration();
        }




        #endregion


        #region Methods
        /*
         * Method used to initialize and assign values to all properties from AppSetting.json file.
         * 
         * */
        public void InitializeAppConfiguration()
        {
            if (_properties is not null)
            {
                try
                {

                    string configFilePath = _properties.ConfigurationFile;
                    string settingsPath = _properties.AppSetttings;
                    _builder = new ConfigurationBuilder()
                                        .SetBasePath(_properties!.ConfigurationFile)
                                        .AddJsonFile(_properties!.AppSetttings)
                                        .Build();

                    InitializeProperties();

                }
                catch (FileNotFoundException ex)
                {


                    System.Environment.Exit(0);
                }
            }
        }

        private void InitializeProperties()
        {
            // Setup App URL. 
            AppURL = string.IsNullOrEmpty(_builder?["APPURL"])
                 ? ""
                 : _builder?["APPURL"];

            // Setup Browser from the the values provided in AppSettings.json file. Chrome is set as default if no value provided in AppSettings.json file
            Browser = string.IsNullOrEmpty(_builder?["BrowserType"])
                 ? "chrome"
                 : _builder?["BrowserType"];

            //Setup Implicit time from AppSettings.json file
            ImplicitWaitTime = string.IsNullOrEmpty(_builder?["ImplicitWaitTime"])
                ? _properties.DefaultImplicitWaitTime
                : Convert.ToDouble(_builder["ImplicitWaitTime"]);

            //Setup Explicit Time from AppSettings.json file
            ExplicitWaitTime = string.IsNullOrEmpty(_builder?["ExplicitWaitTime"])
              ? _properties.DefaultExplicitWaitTime
              : Convert.ToDouble(_builder["ExplicitWaitTime"]);

            //Setup PageLoad time from AppSettings.json file
            PageLoadTime = string.IsNullOrEmpty(_builder?["PageLoadTime"])
              ? _properties.DefaultExplicitWaitTime
              : Convert.ToDouble(_builder["PageLoadTime"]);

            //Setup Valid username from AppSettings.json file
            ValidUser = string.IsNullOrEmpty(_builder?["ValidUserLogin"])
                ? _properties.ValidUserLogin
                : _builder?["ValidUserLogin"];

            //Setup password from AppSettings.json file
            ValidPassword = string.IsNullOrEmpty(_builder?["ValidUserPassword"])
               ? _properties.ValidPassword
               : _builder?["ValidUserPassword"];

            //Setup InvalidUser name from AppSettings.json file
            InvalidUser = string.IsNullOrEmpty(_builder?["InvalidUserLogin"])
                ? _properties.InvalidUserLogin
                : _builder?["InvalidUserLogin"];

            //Setup Invalid Password from AppSettings.json file
            InvalidPassword = string.IsNullOrEmpty(_builder?["InvalidUserPassword"])
               ? _properties.InvalidPassword
               : _builder?["InvalidUserPassword"];


        }

        #endregion



    }
}
