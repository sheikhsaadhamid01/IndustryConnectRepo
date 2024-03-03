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
    public class GlobalProperties
    {

        #region Fields

        private IConfigurationRoot? _builder;
        private IDefaultProperties _properties;

        #endregion

        #region Properties
        public string? AppURL { get; private set; }
        public string? Browser {  get; private set; }
        public double? ImplicityWaitTime { get; private set; }
        public double? ExplicitWaitTime { get; private set; }
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
        }




        #endregion


        #region Methods
        public void InitializeAppConfiguration()
        {
            if (_properties is not null)
            {
                try
                {
                    _builder = new ConfigurationBuilder()
                                        .SetBasePath(_properties!.ConfigurationFile)
                                        .AddJsonFile(_properties!.AppSetttings)
                                        .Build();

                }
                catch (FileNotFoundException ex)
                {


                    System.Environment.Exit(0);
                }
            }
        }

        private void InitializeProperties()
        {
            AppURL = string.IsNullOrEmpty(_builder?["APPURL"])
                 ? ""
                 : _builder?["APPURL"];
            Browser = string.IsNullOrEmpty(_builder?["BrowserType"])
                 ? ""
                 : _builder?["BrowserType"];

            ImplicityWaitTime = string.IsNullOrEmpty(_builder?["ImplicitWaitTime"])
                ? _properties.DefaultImplicitWaitTime
                : Convert.ToDouble(_builder["ImplicitWaitTime"]);

            ExplicitWaitTime = string.IsNullOrEmpty(_builder?["ExplicitWaitTime"])
              ? _properties.DefaultExplicitWaitTime
              : Convert.ToDouble(_builder["ExplicitWaitTime"]);

            PageLoadTime = string.IsNullOrEmpty(_builder?["PageLoadTime"])
              ? _properties.DefaultExplicitWaitTime
              : Convert.ToDouble(_builder["PageLoadTime"]);

            ValidUser = string.IsNullOrEmpty(_builder?["ValidUserLogin"])
                ? _properties.ValidUserLogin
                : _builder?["ValidUserLogin"];

            ValidPassword = string.IsNullOrEmpty(_builder?["ValidUserPassword"])
               ? _properties.ValidPassword
               : _builder?["ValidUserPassword"];

            InvalidUser = string.IsNullOrEmpty(_builder?["InvalidUserLogin"])
                ? _properties.InvalidUserLogin
                : _builder?["InvalidUserLogin"];

            InvalidPassword = string.IsNullOrEmpty(_builder?["InvalidUserPassword"])
               ? _properties.InvalidPassword
               : _builder?["InvalidUserPassword"];


        }

        #endregion



    }
}
