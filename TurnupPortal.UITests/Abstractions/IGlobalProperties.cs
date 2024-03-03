using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupPortal.UITests.Abstractions
{
    public interface IGlobalProperties
    {
        string? AppURL { get; }
        string? BrowserURL { get; }
        string? ValidUser { get; }
        string? ValidPassword { get; }
        string? InvalidUser { get; }
        string? InvalidPassword { get; }


        void InitializeAppConfiguration();



    }
}
