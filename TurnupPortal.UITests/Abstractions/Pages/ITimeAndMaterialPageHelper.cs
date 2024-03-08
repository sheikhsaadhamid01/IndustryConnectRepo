using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupPortal.UITests.Abstractions.Pages
{
    public interface ITimeAndMaterialPageHelper
    {
        void EnterDataInFieldOfTimeAndMaterialPage(string typecode, string code, string description, string price);

        bool IsCodeAvailableOnPage(string code);
    }
}
