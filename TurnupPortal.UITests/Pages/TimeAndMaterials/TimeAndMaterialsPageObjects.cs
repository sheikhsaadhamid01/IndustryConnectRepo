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
using System.Linq.Expressions;

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
            try
            {
                _appUtilities!.ClickElement(TimeAndMaterialsLocators.CreateNew);
                _timeAndMaterialPageHelper.EnterDataInFieldOfTimeAndMaterialPage(typecode, code, description, price);
                _appUtilities.ClickElement(TimeAndMaterialsLocators.LastPageIcon);
                TimeAndMaterialsLocators.CodeName = code;
                isRecordCreated = _appUtilities!.IsElementDisplayed(TimeAndMaterialsLocators.AddedRecord);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return isRecordCreated;
            

        }



        public bool EditTimeAndMaterialRecord(string typecode, string oldcode, string newcode, string description)
        {
            bool isRecordEditted = false;
            if (string.IsNullOrEmpty(typecode) && string.IsNullOrEmpty(oldcode) && string.IsNullOrEmpty(newcode) && string.IsNullOrEmpty(description))
            {
                throw new ArgumentException($"Null or Empty string provided as argument for method {MethodBase.GetCurrentMethod()!.Name}");
            }
            try
            {
                bool isRecordAvailableOnPage = _timeAndMaterialPageHelper.FindCodeOnPage(oldcode);
                if (isRecordAvailableOnPage)
                {

                    _appUtilities!.ClickElement(TimeAndMaterialsLocators.EditCode);

                    _timeAndMaterialPageHelper.EnterDataInFieldOfTimeAndMaterialPage(typecode, newcode, description);

                    TimeAndMaterialsLocators.CodeName = newcode;

                    isRecordEditted = _appUtilities.IsElementDisplayed(TimeAndMaterialsLocators.AddedRecord);

                }
                else
                {
                    throw new ElementNotVisibleException($"No record available in Time And Material Page with name: {oldcode}");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
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
            try
            {
                bool isRecordAvailableOnPage = _timeAndMaterialPageHelper.FindCodeOnPage(code);
                if (isRecordAvailableOnPage)
                {
                    TimeAndMaterialsLocators.CodeName = code;
                    _appUtilities?.ClickElement(TimeAndMaterialsLocators.DeleteCode);
                    _appUtilities?.HandleConfirmationPopUP("accept");

                    int count = _appUtilities!.GetElementsCount(TimeAndMaterialsLocators.AddedRecord);
                    if (count == 0)
                    {
                        isRecordDeleted = true;
                    }

                }
            }
           catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            

            

            return isRecordDeleted;
        }



    }
}
