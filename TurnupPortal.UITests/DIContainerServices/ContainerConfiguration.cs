using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;
using TurnupPortal.UITests.Params;
using TurnupPortal.UITests.TestBase;
using TurnupPortal.UITests.Utilities;

namespace TurnupPortal.UITests.DIContainerServices
{
    public class ContainerConfiguration
    {
        #region Fields
        
        static IServiceCollection? serviceCollection;
        static IServiceCollection? pageHelperServices;
        static IServiceCollection? pageObjectsServices;

        #endregion

        #region Methods

        /// <summary>
        ///  ConfigureService method initializes and store different types of objects in ISserviceCollection.
        /// </summary>
        /// <returns>the collection of objects as IServiceProvider</returns>
        
        public static IServiceProvider ConfigureService()
        {
            serviceCollection = new ServiceCollection();

            #region Config Elements

            serviceCollection.AddSingleton<IGlobalProperties, GlobalProperties>();
            serviceCollection.AddSingleton<IDefaultProperties, DefaultProperties>();
            serviceCollection.AddSingleton<IBrowserFactory, BrowserFactory>();
            serviceCollection.AddSingleton<IWaitUtils, WaitUtilities>();
            serviceCollection.AddSingleton<IDriverUtils, DriverUtilities>();
            serviceCollection.AddSingleton<IAppUtilities, AppUtilites>();
            #endregion

            #region Pages

            #endregion

            return serviceCollection!.BuildServiceProvider();

        }
        #endregion
    }
}
