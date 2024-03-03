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

namespace TurnupPortal.UITests.DIContainerServices
{
    public class ContainerConfiguration
    {
        #region Fields
        /// <summary>
        ///  ConfigureService method initializes and store different types of objects in ISserviceCollection and returns the collection of objects as IServiceProvider
        /// </summary>
        /// <returns></returns>
        /// 
        static IServiceCollection serviceCollection;
        static IServiceCollection pageHelperServices;
        static IServiceCollection pageObjectsServices;

        #endregion

        public static IServiceProvider ConfigureService()
        {
            serviceCollection = new ServiceCollection();

            #region Config Elements

            serviceCollection.AddSingleton<IGlobalProperties, GlobalProperties>();
            serviceCollection.AddSingleton<IDefaultProperties, DefaultProperties>();
            serviceCollection.AddSingleton<IBrowserFactory, BrowserFactory>();

            #endregion

            #region Pages

            #endregion

            return serviceCollection!.BuildServiceProvider();

        }

    }
}
