using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnupPortal.UITests.Abstractions.Pages;
using TurnupPortal.UITests.Abstractions;
using System.Reflection;
using OpenQA.Selenium;
using System.Reflection.Emit;

namespace TurnupPortal.UITests.Pages.TimeAndMaterials
{
    public class TimeAndMaterialsPageObjects
    {
       
        private IAppUtilities? _appUtilities;      
        private INavigationHelper? _navigationHelper;
        private ITimeAndMaterialPageHelper _timeAndMaterialPageHelper;


        public TimeAndMaterialsPageObjects( IAppUtilities appUtilities,  INavigationHelper? navigationHelper, ITimeAndMaterialPageHelper timeAndMaterialPageHelper)
        {            
            this._appUtilities = appUtilities;           
            this._navigationHelper = navigationHelper;
            this._timeAndMaterialPageHelper = timeAndMaterialPageHelper;
        }

        public void NavigateToPage(string pageName)
        {
            if (string.IsNullOrEmpty(pageName))
            {
                throw new ArgumentException($"Null or Empty string provided as argument for method {MethodBase.GetCurrentMethod()!.Name}");
            }
            _navigationHelper?.NavigateToPage(pageName);
        }

        public bool CreateNewRecord(string typecode, string code, string description, string price)
        {
            bool isRecordCreated = false;
            if(string.IsNullOrEmpty(typecode) && string.IsNullOrEmpty(code) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(price)) 
            {
                throw new ArgumentException($"Null or Empty string provided as argument for method {MethodBase.GetCurrentMethod()!.Name}");
            }
            _appUtilities!.ClickElement(TimeAndMaterialsLocators.CreateNew);
            _timeAndMaterialPageHelper.EnterDataInFieldOfTimeAndMaterialPage(typecode, code, description, price);
            
            isRecordCreated = _appUtilities!.IsElementDisplayed(TimeAndMaterialsLocators.AddedRecord);

            return isRecordCreated;
            

        }



        public bool EditTimeAndMaterialRecord(string typecode, string oldcode, string newcode, string description, string price)
        {
            bool isRecordEditted = false;
            if (string.IsNullOrEmpty(typecode) && string.IsNullOrEmpty(oldcode) && string.IsNullOrEmpty(newcode) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(price))
            {
                throw new ArgumentException($"Null or Empty string provided as argument for method {MethodBase.GetCurrentMethod()!.Name}");
            }

            bool isRecordAvailableOnPage = _timeAndMaterialPageHelper.IsCodeAvailableOnPage(oldcode);
            if(isRecordAvailableOnPage)
            {
                
                _appUtilities!.ClickElement(TimeAndMaterialsLocators.EditCode);

                _timeAndMaterialPageHelper.EnterDataInFieldOfTimeAndMaterialPage(typecode, newcode, description, price);
                TimeAndMaterialsLocators.CodeName = newcode;

                isRecordEditted = _appUtilities.IsElementDisplayed(TimeAndMaterialsLocators.AddedRecord);
                
            }
            else
            {
                throw new ElementNotVisibleException($"No record available in Time And Material Page with name: {oldcode}");
            }
            return isRecordEditted;
        }


        public bool DeleteTimeAndMaterialRecord(string code)
        {

            bool isRecordDeleted = false;
            if (string.IsNullOrEmpty(code) )
            {
                throw new ArgumentException($"Null or Empty string provided as argument for method {MethodBase.GetCurrentMethod()!.Name}");
            }

            TimeAndMaterialsLocators.CodeName = code;
            _appUtilities?.ClickElement(TimeAndMaterialsLocators.DeleteCode);
            _appUtilities?.HandleConfirmationPopUP("delete");
            isRecordDeleted = !(_appUtilities!.IsElementDisplayed(TimeAndMaterialsLocators.AddedRecord));

            return isRecordDeleted;
        }



    }
}
