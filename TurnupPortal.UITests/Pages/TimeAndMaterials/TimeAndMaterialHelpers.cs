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
          
            

        }

        public void EnterDataInFieldOfTimeAndMaterialPage(string typecode, string code, string description)
        {
            TimeAndMaterialsLocators.TypeCodeValue = typecode;

            _appUtilities.ClickElementByActions(TimeAndMaterialsLocators.TypeCodeDropDown);
            
            _appUtilities.ClickElementByActions(TimeAndMaterialsLocators.TypeCodeDropDownValue);
            _appUtilities.EnterDataInInputField(code, TimeAndMaterialsLocators.CodeField);
            _appUtilities.EnterDataInInputField(description, TimeAndMaterialsLocators.DescriptionField);
            
            _appUtilities.ClickElement(TimeAndMaterialsLocators.SaveButton);
            


        }

       

        public bool FindCodeOnPage(string code)
        {
            bool isCodeAvailable = false;
            _appUtilities.ClickElement(TimeAndMaterialsLocators.FirstPageIcon);
            TimeAndMaterialsLocators.CodeName = code;
            while(!isCodeAvailable)
            {
                try
                {
                    isCodeAvailable = _appUtilities.IsElementDisplayed(TimeAndMaterialsLocators.AddedRecord);
                    if (isCodeAvailable)
                    {
                        break;
                    }
                }
                catch
                {
                    _appUtilities.ClickElement(TimeAndMaterialsLocators.NextPageIcon);
                    continue;
                }
                
               
               
            }

            return isCodeAvailable;
        }


    }
}
