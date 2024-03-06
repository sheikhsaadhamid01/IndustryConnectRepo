using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupPortal.UITests.Abstractions
{
    public interface IDefaultProperties
    {
        string AppSetttings { get; }
        string ConfigurationFile { get; }
        double DefaultImplicitWaitTime { get; }
        double DefaultExplicitWaitTime { get; }
        double PageLoadTime { get; }
        string ValidUserLogin { get; }
        string ValidPassword { get; }
        string InvalidUserLogin { get; }
        string InvalidPassword { get; }



    }
}
