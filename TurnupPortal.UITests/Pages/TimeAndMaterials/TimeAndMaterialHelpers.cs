using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions;
using TurnupPortal.UITests.Abstractions.Pages;

namespace TurnupPortal.UITests.Pages.TimeAndMaterials
{
    public class TimeAndMaterialHelpers : ITimeAndMaterialPageHelper
    {

        private IAppUtilities _appUtilities;

        public TimeAndMaterialHelpers(IAppUtilities appUtilities)
        {
            this._appUtilities = appUtilities;
        }

        public void EnterDataInFieldOfTimeAndMaterialPage(string typecode, string code, string description, string price)
        {
             TimeAndMaterialsLocators.TypeCodeValue = typecode;
            
            _appUtilities.ClickElementByActions(TimeAndMaterialsLocators.TypeCodeDropDown);
            _appUtilities.ClickElementByActions(TimeAndMaterialsLocators.TypeCodeDropDownValue);
            _appUtilities.EnterDataInInputField(code, TimeAndMaterialsLocators.CodeField);
            _appUtilities.EnterDataInInputField(description, TimeAndMaterialsLocators.DescriptionField);
            _appUtilities.EnterDataInInputField(price, TimeAndMaterialsLocators.PriceField);
            _appUtilities.ClickElement(TimeAndMaterialsLocators.SaveButton);
            _appUtilities.ClickElement(TimeAndMaterialsLocators.LastPageIcon);

        }


        public bool IsCodeAvailableOnPage(string code)
        {
            bool isCodeAvailable = false;
            _appUtilities.ClickElement(TimeAndMaterialsLocators.FirstPageIcon);
            TimeAndMaterialsLocators.CodeName = code;
            while(!isCodeAvailable)
            {
                isCodeAvailable = _appUtilities.IsElementDisplayed(TimeAndMaterialsLocators.AddedRecord);
                if (isCodeAvailable)
                {
                    break;
                }
                _appUtilities.ClickElement(TimeAndMaterialsLocators.NextPageIcon);
            }

            return isCodeAvailable;
        }


    }
}
