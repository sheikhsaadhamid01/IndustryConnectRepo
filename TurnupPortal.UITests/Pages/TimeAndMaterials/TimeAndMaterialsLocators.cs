using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnupPortal.UITests.Pages.TimeAndMaterials
{
    public class TimeAndMaterialsLocators
    {
        public static By CreateNew { get => By.XPath("//a[text()='Create New']"); }
        public static string? CodeName { get; set; }

        public static By EditCode { get => By.XPath(".//td[text()='"+CodeName+"']//parent::tr//a[@class='k-button k-button-icontext k-grid-Edit']"); }
        public static By DeleteCode { get => By.XPath(".//td[text()='"+CodeName+"']//parent::tr//a[@class='k-button k-button-icontext k-grid-Delete']"); }

        public static By AddedRecord { get => By.XPath(".//td[text()='"+CodeName+"']"); }
        
        #region Create and Edit Locators

        public static string? TypeCodeValue { get; set; }
        public static By TypeCodeDropDown { get => By.XPath("//span[@aria-activedescendant='TypeCode_option_selected']"); }

        public static By TypeCodeDropDownValue { get => By.XPath(".//div[@id='TypeCode-list']//li[text()='"+TypeCodeValue+"']"); }

        public static By CodeField { get => By.XPath("//input[@class='text-box single-line' and @name='Code']"); }

        public static By DescriptionField { get => By.XPath("//input[@class='text-box single-line' and @name='Description']"); }

        public static By PriceField { get => By.XPath("//input[@id='Price']"); }

        public static By SaveButton { get => By.XPath("//input[@id='SaveButton']"); }



        #endregion


        

        #region Pagination

        public static By LastPageIcon { get => By.XPath(".//span[text()='Go to the last page']"); }
        public static By NextPageIcon { get => By.XPath(".//span[text()='Go to the next page']"); }
        public static By FirstPageIcon { get => By.XPath(".//span[text()='Go to the first page']"); }

        #endregion

    }
}
