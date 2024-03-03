using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;

namespace TurnupPortal.UITests.Params
{
    public class DefaultProperties : IDefaultProperties
    {
        #region Properties
        private string? _currentFolder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../")?.FullName;
        public string AppSetttings { get => "appSettings.json"; }

        public string ConfigurationFile { get => _currentFolder + @"\Resources\"; }

        public double DefaultImplicitWaitTime { get => 10; }
        public double DefaultExplicitWaitTime { get => 10; }

        public double PageLoadTime { get => 10; }

        public string ValidUserLogin { get => "hari"; }
        public string ValidPassword { get => "123123"; }

        public string InvalidUserLogin { get => "TestInvalidUser"; }
        public string InvalidPassword { get => "123123232"; }


        #endregion
    }
}
