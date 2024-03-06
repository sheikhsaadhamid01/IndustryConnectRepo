using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupPortal.UITests.Abstractions
{
    public interface IGlobalProperties
    {
        string AppURL { get; }
        string Browser { get; }
        string ValidUser { get; }
        double ImplicitWaitTime { get; }
        double ExplicitWaitTime { get; }
        double PageLoadTime { get; }
        string ValidPassword { get; }
        string InvalidUser { get; }
        string InvalidPassword { get; }


        void InitializeAppConfiguration();



    }
}
