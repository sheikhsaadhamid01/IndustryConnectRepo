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
using log4net;

namespace TurnupPortal.UITests.Pages.TimeAndMaterials
{
    public class TimeAndMaterialsPageObjects
    {
       
        private IAppUtilities? _appUtilities;      
        private INavigationHelper? _navigationHelper;
        private ITimeAndMaterialPageHelper _timeAndMaterialPageHelper;
        private static log4net.ILog? _log;


        public TimeAndMaterialsPageObjects( IAppUtilities appUtilities,  INavigationHelper? navigationHelper, ITimeAndMaterialPageHelper timeAndMaterialPageHelper)
        {            
            this._appUtilities = appUtilities;           
            this._navigationHelper = navigationHelper;
            this._timeAndMaterialPageHelper = timeAndMaterialPageHelper;
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod()!.DeclaringType);
        }

        public void NavigateToPage(string pageName)
        {
            if (string.IsNullOrEmpty(pageName))
            {
                _log!.Error($"Null or Empty string provided as argument for method {MethodBase.GetCurrentMethod()!.Name}");
                throw new ArgumentException($"Null or Empty string provided as argument for method {MethodBase.GetCurrentMethod()!.Name}");
            }
            _log!.Info($"About to Navigate to {pageName} page ");
            _navigationHelper?.NavigateToPage(pageName);
        }

        public bool CreateNewRecord(string typecode, string code, string description, string price)
        {
            bool isRecordCreated = false;
            if(string.IsNullOrEmpty(typecode) && string.IsNullOrEmpty(code) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(price)) 
            {
                _log!.Error($"Null or Empty string provided as argument for method {MethodBase.GetCurrentMethod()!.Name}");
                throw new ArgumentException($"Null or Empty string provided as argument for method {MethodBase.GetCurrentMethod()!.Name}");
            }
            try
            {
                _log!.Info("About to Click on Create New button");
                _appUtilities!.ClickElement(TimeAndMaterialsLocators.CreateNew);
                _log!.Info($"About to enter Date in the Fields of Time & Material Page. Data values are TypeCode:{typecode},Code: {code},Description: {description} and Price: {price}");
                _timeAndMaterialPageHelper.EnterDataInFieldOfTimeAndMaterialPage(typecode, code, description, price);
                _log!.Info("About to Click on Pagination -> Last Page icon to get the last .");
                _appUtilities.ClickElement(TimeAndMaterialsLocators.LastPageIcon);
                _log!.Info($"About to set Code name as : {code}");
                TimeAndMaterialsLocators.CodeName = code;
                _log!.Info("About to verify if Added record is displayed on the page");
                isRecordCreated = _appUtilities!.IsElementDisplayed(TimeAndMaterialsLocators.AddedRecord);
               
            }
            catch (Exception e)
            {
                _log.Error(e.Message);
                throw new Exception(e.Message);
            }
            _log.Info($"About to return Record created as {isRecordCreated}");
            return isRecordCreated;
            

        }



        public bool EditTimeAndMaterialRecord(string typecode, string oldcode, string newcode, string description)
        {
            bool isRecordEditted = false;
            if (string.IsNullOrEmpty(typecode) && string.IsNullOrEmpty(oldcode) && string.IsNullOrEmpty(newcode) && string.IsNullOrEmpty(description))
            {
                _log!.Error($"Null or Empty string provided as argument for method {MethodBase.GetCurrentMethod()!.Name}");
                throw new ArgumentException($"Null or Empty string provided as argument for method {MethodBase.GetCurrentMethod()!.Name}");
            }
            try
            {
                _log!.Info($"About to find {oldcode} is available on any page in Time & Material Data grid.");
                bool isRecordAvailableOnPage = _timeAndMaterialPageHelper.FindCodeOnPage(oldcode);
                if (isRecordAvailableOnPage)
                {
                    _log!.Info($"{oldcode} found on the page.");
                    _log!.Info($"About to click on Edit button of {oldcode}");
                    _appUtilities!.ClickElement(TimeAndMaterialsLocators.EditCode);
                    _log!.Info($"About to update fields with new Typecode:{typecode}, Code:{newcode}, Description: {description}");
                    _timeAndMaterialPageHelper.EnterDataInFieldOfTimeAndMaterialPage(typecode, newcode, description);
                    _log!.Info($"About to set codename in locators to build a locator for a specific record. code: {newcode}");
                    TimeAndMaterialsLocators.CodeName = newcode;
                    _log!.Info("About to verify if Editted record is updated on the data grid.");
                    isRecordEditted = _appUtilities.IsElementDisplayed(TimeAndMaterialsLocators.AddedRecord);

                }
                else
                {
                    _log.Error($"No record available in Time And Material Page with name: {oldcode}");
                    throw new ElementNotVisibleException($"No record available in Time And Material Page with name: {oldcode}");
                }
            }
            catch (Exception e)
            {
                _log!.Error(e.Message);
                throw new Exception(e.Message);
            }

            return isRecordEditted;
        }


        public bool DeleteTimeAndMaterialRecord(string code)
        {

            bool isRecordDeleted = false;
            if (string.IsNullOrEmpty(code) )
            {
                _log.Error($"Null or Empty string provided as argument for method {MethodBase.GetCurrentMethod()!.Name}");
                throw new ArgumentException($"Null or Empty string provided as argument for method {MethodBase.GetCurrentMethod()!.Name}");
            }
            try
            {
                _log!.Info($"About to find {code} is available on any page in Time & Material Data grid.");
                bool isRecordAvailableOnPage = _timeAndMaterialPageHelper.FindCodeOnPage(code);
                if (isRecordAvailableOnPage)
                {
                    _log!.Info($"{code} found on the page.");
                    _log!.Info($"About to set codename in locators to build a locator for a specific record. code: {code}");
                    TimeAndMaterialsLocators.CodeName = code;
                    _log!.Info($"About to click on Delete button for code: {code} ");
                    _appUtilities?.ClickElement(TimeAndMaterialsLocators.DeleteCode);
                    _log.Info("About to accept Deletion Popup message");
                    _appUtilities?.HandleConfirmationPopUP("accept");
                    _log.Info($"About to verify if there are any elements available on page with code: {code} after deletion");
                    int count = _appUtilities!.GetElementsCount(TimeAndMaterialsLocators.AddedRecord);
                    _log.Info($"Total number of Elements available on page with codename as {code} =  {count}");
                    if (count == 0)
                    {
                      
                        isRecordDeleted = true;
                    }

                }
            }
           catch (Exception e)
            {
                _log.Error(e.Message);
                throw new Exception(e.Message);
            }



            _log.Info($"About to return record deleted as {isRecordDeleted}. ");

            return isRecordDeleted;
        }



    }
}
