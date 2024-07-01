using MarsQA.Utils;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MarsQA.Helpers;
using SeleniumExtras.WaitHelpers;

namespace MarsQA.Pages
{
    public class SkillPage
    {

        private static IWebElement AddNewButton => Driver.driver.FindElement(By.XPath("//div[@class='ui teal button'][text()='Add New']"));
        private static IWebElement AddSkill => Driver.driver.FindElement(By.XPath("//input[@type='text' and @placeholder='Add Skill']"));
        private static IWebElement AddSkillLevel => Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown'][[text()='Choose Skill Level']"));
        private static IWebElement AddButton => Driver.driver.FindElement(By.XPath("//input[@type='button'and @class='ui teal button ']"));
        private static IWebElement EditPencilIcon => Driver.driver.FindElement(By.XPath("//I[@class='outline write icon'][1]\r\n"));
        private static IWebElement EditSkill => Driver.driver.FindElement(By.XPath("//input[@type='text' and @placeholder='Add Skill']"));
        private static IWebElement EditSkillLevel => Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown'][text()='option value']"));
        private static IWebElement UpdateButton => Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown'][text()='option value']"));
        private static IWebElement DeletCrossIcon => Driver.driver.FindElement(By.XPath("//I[@class='remove icon'][1]"));


        public void SuccessfullyAddNewSkill(IWebDriver driver,string skillToBeAdd, string skillLevelToBeAdd)

        {
            Thread.Sleep(200);
            AddNewButton.Click();
            AddSkill.SendKeys(skillToBeAdd);
            SelectElement dropdown = new SelectElement(AddSkillLevel);            
            dropdown.SelectByText(skillLevelToBeAdd);            
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(skillLevelToBeAdd));
            AddButton.Click();

            string expectedMessage = $"{skillToBeAdd} has been added to your languages";
            AssertionPopupMessage(driver, expectedMessage);

            // visible added value
            ViewSkillInTable(driver, skillLevelToBeAdd, skillLevelToBeAdd);
        }

        public void ViewSkillInTable(IWebDriver driver, string skill, string level)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var skillRow = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//tr[td[text()='{skill}'] and td[text()='{level}']]")));

            Assert.That(skillRow, Is.Not.Null);
        }

        public void AssertionPopupMessage(IWebDriver driver, string expectedMessage)
        {
            WaitHelper.WaitToBeVisible(driver, "ClassName", "ns-box", 30);
            IWebElement toastMessageElement = driver.FindElement(By.ClassName("ns-box"));
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        public void CannotBeAbleToAddnewSkillWithoutAddingSkillLevel(IWebDriver driver, string skillToBeAdd)

        {
            Thread.Sleep(200);
            AddNewButton.Click();        
            AddSkill.SendKeys(skillToBeAdd); 
            AddButton.Click();

            //Assertion
            string expectedMessage = $"{skillToBeAdd} has been added to your languages";
            AssertionPopupMessage(driver, expectedMessage);
        }

        public void CannotBeAbleToAddExistingSkillAndSkillLevelAsANewSkill(IWebDriver driver, string skillToBeAdd, string skillLevelToBeAdd)

        {           
            AddNewButton.Click();
            AddSkill.SendKeys(skillToBeAdd);
            SelectElement dropdown = new SelectElement(AddSkillLevel);            
            dropdown.SelectByText(skillLevelToBeAdd);
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(skillLevelToBeAdd));            
            AddButton.Click();

            //Assertion
            string expectedMessage = $"{skillToBeAdd} has been added to your languages";
            AssertionPopupMessage(driver, expectedMessage);
        }

        public void SuccessfullyEditExistingSkillAndSkillLevel(IWebDriver driver, string skillToBeEdit, string skillLevelToBeEdit)

        {           
            EditPencilIcon.Click();            
            EditSkill.Clear();
            EditSkill.SendKeys(skillToBeEdit);            
            SelectElement dropdown = new SelectElement(EditSkillLevel);
            EditSkillLevel.Click();
            EditSkillLevel.SendKeys(skillLevelToBeEdit);
            EditSkillLevel.SendKeys(Keys.Enter);            
            UpdateButton.Click();

            //Assertion
            string expectedMessage = $"{skillToBeEdit} has been added to your languages";
            AssertionPopupMessage(driver, expectedMessage);
        }

        public void SuccsfullyEditOnlyExistingSkillToANewSkillWithoutEditSkillLevel(IWebDriver driver, string skillToBeEdit)

        {            
            EditPencilIcon.Click();            
            EditSkill.Clear();
            EditSkill.SendKeys(skillToBeEdit);            
            UpdateButton.Click();

            string expectedMessage = $"{skillToBeEdit} has been added to your languages";
            AssertionPopupMessage(driver, expectedMessage);
        }

        public void SuccsfullyEditSkillLevelWithoutEditSkill(IWebDriver driver, string skillLevelToBeEdit)       

        {          
          
            EditPencilIcon.Click();           
            SelectElement dropdown = new SelectElement(EditSkillLevel);
            EditSkillLevel.Click();
            EditSkillLevel.SendKeys(skillLevelToBeEdit);
            EditSkillLevel.SendKeys(Keys.Enter);
            string skillText =EditSkill.Text;
            UpdateButton.Click();

            string expectedMessage = $"{skillText} has been added to your languages";
            AssertionPopupMessage(driver, expectedMessage);
        }

        public void CannotBeAbleToEditExistngSkillAndSkillLevelToAnotherExistingSkill(IWebDriver driver, string skillToBeEdit, string skillLevelToBeEdit)
        {
            EditPencilIcon.Click();
            EditSkill.Clear();
            EditSkill.SendKeys(skillToBeEdit);
            SelectElement dropdown = new SelectElement(EditSkillLevel);
            EditSkillLevel.Click();
            EditSkillLevel.SendKeys(skillLevelToBeEdit);
            EditSkillLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();

            string expectedMessage = "This skill is already added to your skill list.";
            AssertionPopupMessage(driver, expectedMessage);
        }


        public void deleteExistingSkill(IWebDriver driver)
        {
            DeletCrossIcon.Click();

        }

    }
}
