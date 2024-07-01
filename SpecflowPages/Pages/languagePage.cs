using MarsQA.Helpers;
using MarsQA.Utils;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine;
using SeleniumExtras.WaitHelpers;
using System.Drawing;
using System.Reflection.Emit;

namespace MarsQA.Pages
{
    public class LanguagePage
    {
        private static IWebElement AddNewButton => Driver.driver.FindElement(By.XPath("//div[@class='ui teal button '][text()='Add New']"));
        private static IWebElement AddLanguage => Driver.driver.FindElement(By.XPath("//input[@type='text' and @placeholder='Add Language']"));
        private static IWebElement AddLanguageLevel => Driver.driver.FindElement(By.XPath("//select [@class='ui dropdown' and @name='level']"));
        private static IWebElement AddButton => Driver.driver.FindElement(By.XPath("//input[@type='button' and @class='ui teal button']"));
        private static IWebElement EditPencilIcon => Driver.driver.FindElement(By.XPath("(//I[@class='outline write icon']) [1]"));
        private static IWebElement EditLanguage => Driver.driver.FindElement(By.XPath("//input[@type='text' and @placeholder='Add Language']"));
        private static IWebElement EditLanguageLevel => Driver.driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='level']"));
        private static IWebElement UpdateButton => Driver.driver.FindElement(By.XPath("//input[@type='button' and @class='ui teal button']"));
        //private static IWebElement DeletCrossIcon => Driver.driver.FindElement(By.XPath("(//I[@class='remove icon'])[1]"));

        public static IWebElement GetEditPencilIcon(IWebDriver driver, string language )
        {
            var tableRow = Driver.driver.FindElement(By.XPath($"//tr[td[text()='{language}']]"));
            var editPencilIcon = tableRow.FindElement(By.XPath("//I[@class='outline write icon']"));
            return editPencilIcon;
        }

        public static IWebElement GetDeletePencilIcon(IWebDriver driver, string language)
        {
            var tableRow = Driver.driver.FindElement(By.XPath($"//tr[td[text()='{language}']]"));
            var deletePencilIcon = tableRow.FindElement(By.XPath("//I[@class='remove icon']']"));
            return deletePencilIcon;
        }
        public void SuccessfullyAddNewLanguage(IWebDriver driver, string languageToBeAdd, string languageLevelToBeAdd)
        {
            Thread.Sleep(200);
            AddNewButton.Click();
            AddLanguage.SendKeys(languageToBeAdd);
            SelectElement dropdown = new SelectElement(AddLanguageLevel);    
            dropdown.SelectByText(languageLevelToBeAdd);
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(languageLevelToBeAdd));   
            AddButton.Click();

            //Assertion 
            string expectedMessage = $"{languageToBeAdd} has been added to your languages";
            AssertionPopupMessage(driver, expectedMessage);

            // visible added value
            //get the raw
            ViewLanguageInTable(driver,languageToBeAdd, languageLevelToBeAdd);
        }

        public void ViewLanguageInTable(IWebDriver driver, string language, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));           
            var languageRow = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//tr[td[text()='{language}'] and td[text()='{level}']]")));
            
            Assert.That(languageRow, Is.Not.Null);            
        }

        public void AssertionPopupMessage(IWebDriver driver, string expectedMessage)
        {
            WaitHelper.WaitToBeVisible(driver, "ClassName", "ns-box", 30);
            IWebElement toastMessageElement = driver.FindElement(By.ClassName("ns-box"));           
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        public void CannotBeAbleToAddnewLanguageWithoutAddingLanguageLevel(IWebDriver driver, string languageToBeAdd)
        {
            AddNewButton.Click();           
            AddLanguage.SendKeys(languageToBeAdd);  
            AddButton.Click();    
            
            //Assertion
            string expectedMessage = "Please enter language and level";
            AssertionPopupMessage(driver, expectedMessage);         
        }

        public void CannotBeAbleToAddExistingLanguageAndLanguageLevelAsANewLanguage(IWebDriver driver, string languageToBeAdd, string languageLevelToBeAdd)
        {
            AddNewButton.Click();
            //Assertion
            //WaitHelper.WaitToBeClickable(driver, "XPath", xPathaddLanguage, 30); 
            AddLanguage.SendKeys(languageToBeAdd);
            SelectElement dropdown = new SelectElement(AddLanguageLevel);            
            dropdown.SelectByText(languageLevelToBeAdd);
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(languageLevelToBeAdd));
            AddButton.Click();

            //Assertion
            string expectedMessage = "This language is already exist in your language list";
            AssertionPopupMessage(driver, expectedMessage);
        }      

        public void SuccessfullyEditExistingLanguageAndLanguageLevel(IWebDriver driver,string language, string level, string languageToBeEdit, string languageLevelToBeEdit)
        {
            var editPencilIcon = GetEditPencilIcon(driver, language);
            editPencilIcon.Click();
            //EditPencilIcon.Click();  
            EditLanguage.Clear();
            EditLanguage.SendKeys(languageToBeEdit);    
            SelectElement dropdown = new SelectElement(EditLanguageLevel);
            EditLanguageLevel.Click();
            EditLanguageLevel.SendKeys(languageLevelToBeEdit);
            EditLanguageLevel.SendKeys(Keys.Enter); 
            UpdateButton.Click();

            //Assertion
            string expectedMessage = $"{languageToBeEdit} has been updated to your languages";
            AssertionPopupMessage(driver, expectedMessage);
        }

        public void SuccsfullyEditOnlyExistingLanguageToANewLanguageWithoutEditLanguageLevel(IWebDriver driver, string language, string languageToBeEdit) 
        {
            var editPencilIcon = GetEditPencilIcon(driver, language);
            editPencilIcon.Click();
            //EditPencilIcon.Click();
            EditLanguage.Clear();
            EditLanguage.SendKeys(languageToBeEdit);            
            UpdateButton.Click();
            
            string expectedMessage = $"{languageToBeEdit} has been updated to your languages";
            AssertionPopupMessage(driver, expectedMessage);
        }
        
        public void SuccsfullyEditLanguageLevelWithoutEditLanguage(IWebDriver driver, string language, string level,string languageLevelToBeEdit)
        {
            EditPencilIcon.Click();            
            SelectElement dropdown = new SelectElement(EditLanguageLevel);
            EditLanguageLevel.Click();
            EditLanguageLevel.SendKeys(languageLevelToBeEdit);
            EditLanguageLevel.SendKeys(Keys.Enter);
            string languageText = EditLanguage.Text;
            UpdateButton.Click();

            //Assertion
            string expectedMessage = $"{languageText} has been updated to your languages";
            AssertionPopupMessage(driver, expectedMessage);
        }        

        public void CannotBeAbleToEditExistngLanguageAndLanguageLevelToAnotherExistingLanguage(IWebDriver driver, string language, string languageLevel, string languageToBeEdit, string languageLevelToBeEdit)
        {
            EditPencilIcon.Click();         
            EditLanguage.Clear();
            EditLanguage.SendKeys(languageToBeEdit); 
            SelectElement dropdown = new SelectElement(EditLanguageLevel);
            EditLanguageLevel.Click();
            EditLanguageLevel.SendKeys(languageLevelToBeEdit);
            EditLanguageLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();

            string expectedMessage = "This language is already added to your language list.";
            AssertionPopupMessage(driver, expectedMessage);
        }

        public void SuccessfullydeleteExistingLanguage(IWebDriver driver,string language) 
        {
            var editPencilIcon = GetEditPencilIcon(driver, language);
            editPencilIcon.Click();

            string expectedMessage = $"{language}has been deleted from your languages";
            AssertionPopupMessage(driver, expectedMessage);
        }

    }
}
