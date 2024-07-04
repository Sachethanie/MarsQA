using MarsQA.Helpers;
using MarsQA.Utils;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MarsQA.Pages
{
    public class LanguagePage
    {
        private static IWebElement AddNewButton => Driver.driver.FindElement(By.XPath("//div[@class='ui teal button '][text()='Add New']"));
        private static IWebElement AddLanguage => Driver.driver.FindElement(By.XPath("//input[@type='text' and @placeholder='Add Language']"));
        private static IWebElement AddLanguageLevel => Driver.driver.FindElement(By.XPath("//select [@class='ui dropdown' and @name='level']"));
        private static IWebElement AddButton => Driver.driver.FindElement(By.XPath("//input[@type='button' and @class='ui teal button']"));        
        private static IWebElement UpdateButton => Driver.driver.FindElement(By.XPath("//input[@type='button' and @class='ui teal button']"));
        
        public static IWebElement GetEditPencilIcon(IWebDriver driver, string language )

        {
            return driver.FindElement(By.XPath($"//tr[td[text()='{language}']]//i[contains(@class, 'outline write icon')]"));           
        }

        public static IWebElement GetDeletePencilIcon(IWebDriver driver, string language)

        {
            return driver.FindElement(By.XPath($"//tr[td[text()='{language}']]//i[contains(@class, 'remove icon')]"));
        }

        public void SuccessfullyAddNewLanguage(IWebDriver driver, string languageToBeAdd, string languageLevelToBeAdd)

        {
            AddNewButton.Click();
            AddLanguage.SendKeys(languageToBeAdd);
            SelectElement dropdown = new SelectElement(AddLanguageLevel);    
            dropdown.SelectByText(languageLevelToBeAdd);
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(languageLevelToBeAdd));   
            AddButton.Click();            
        }

        public void ViewLanguageInTable(IWebDriver driver, string language, string level)

        {           
            var languageRow = driver.FindElements(By.XPath($"//tr[td[text()='{language}'] and td[text()='{level}']]"));            
            Assert.That(languageRow, Is.Not.Null, "$Language {language}, level {level} was not found in the list");            
        }

        public void CannotViewLanguageInTable(IWebDriver driver, string language)

        {
            var languageRows = driver.FindElements(By.XPath($"//tr[td[text()='{language}']]"));
            Assert.That(languageRows, Is.Empty, $"Language {language} was found in the list, but it should have been deleted.");
        }

        public void AssertionPopupMessage(IWebDriver driver, string expectedMessage)

        {
            WaitHelper.WaitToBeVisible(driver, LocatorType.ClassName, "ns-box",30);
            IWebElement toastMessageElement = driver.FindElement(By.ClassName("ns-box"));           
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        public void CannotBeAbleToAddnewLanguageWithoutAddingLanguageLevel(IWebDriver driver, string languageToBeAdd)

        {
            AddNewButton.Click();
            AddLanguage.SendKeys(languageToBeAdd);
            AddButton.Click();
        }   

        public void SuccessfullyEditExistingLanguageAndLanguageLevel(IWebDriver driver,string language, string level, string languageToBeEdit, string languageLevelToBeEdit)

        {
            var editPencilIcon = GetEditPencilIcon(driver, language);
            editPencilIcon.Click();
            AddLanguage.Clear();
            AddLanguage.SendKeys(languageToBeEdit);    
            SelectElement dropdown = new SelectElement(AddLanguageLevel);
            AddLanguageLevel.Click();
            AddLanguageLevel.SendKeys(languageLevelToBeEdit);
            AddLanguageLevel.SendKeys(Keys.Enter); 
            UpdateButton.Click();
        }

        public void SuccsfullyEditOnlyExistingLanguageToANewLanguageWithoutEditLanguageLevel(IWebDriver driver, string language, string languageToBeEdit)

        {
            var editPencilIcon = GetEditPencilIcon(driver, language);
            editPencilIcon.Click();
            AddLanguage.Clear();
            AddLanguage.SendKeys(languageToBeEdit);
            UpdateButton.Click();
        }        
        
        public void SuccsfullyEditLanguageLevelWithoutEditLanguage(IWebDriver driver, string language, string level,string languageLevelToBeEdit)

        {
            var editPencilIcon = GetEditPencilIcon(driver, language);
            editPencilIcon.Click();
            SelectElement dropdown = new SelectElement(AddLanguageLevel);
            AddLanguageLevel.Click();
            AddLanguageLevel.SendKeys(languageLevelToBeEdit);
            AddLanguageLevel.SendKeys(Keys.Enter);            
            UpdateButton.Click();
        }        

        public void CannotBeAbleToEditExistngLanguageAndLanguageLevelToAnotherExistingLanguage(IWebDriver driver, string language, string languageLevel, string languageToBeEdit, string languageLevelToBeEdit)

        {
            var editPencilIcon = GetEditPencilIcon(driver, language);
            editPencilIcon.Click();
            AddLanguage.Clear();
            AddLanguage.SendKeys(languageToBeEdit); 
            SelectElement dropdown = new SelectElement(AddLanguageLevel);
            AddLanguageLevel.Click();
            AddLanguageLevel.SendKeys(languageLevelToBeEdit);
            AddLanguageLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();            
        }

        public void SuccessfullydeleteExistingLanguage(IWebDriver driver,string language) 

        {
            var deletePencilIcon = GetDeletePencilIcon(driver, language);
            deletePencilIcon.Click();
            
        }


        public void WhenIAddLanguagesUntilICannotAddMore(IWebDriver driver,string language, string languageLevel)
        {
           // language = 0;  
            bool canAddMore = true;
            int maxLanguagesToTry = 4; // Arbitrary large number to test the limit

            for (int i = 0; i < maxLanguagesToTry && canAddMore; i++)
            {
                try
                {
                    AddNewButton.Click();

                    // Locate and fill the language field
                    // var languageField = driver.FindElement(By.XPath("//input[@name='language']"));
                    AddLanguage.Clear();
                    AddLanguage.SendKeys($"Language{i}");

                    // Locate and fill the level field
                    AddLanguageLevel.SendKeys(languageLevel);
                    AddLanguageLevel.SendKeys(Keys.Enter);

                    // Locate and click the add button
                    
                    AddButton.Click();

                    // Wait for the language to be added (this might require a more sophisticated wait)
                    System.Threading.Thread.Sleep(500);

                    // Check if the language was added (e.g., by checking if it appears in a list)
                    //var addedLanguageElement = driver.FindElement(By.XPath($"//td[text()='Language{i}']"));
                    if (language == null)
                    {
                        canAddMore = false;
                    }
                    else
                    {
                       i++;
                    }
                }
                catch (NoSuchElementException)
                {
                    canAddMore = false;
                }
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"An error occurred: {ex.Message}");
                //    canAddMore = false;
                //}
            }
        }


    }
}
