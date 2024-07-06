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
using RazorEngine;

namespace MarsQA.Pages
{
    public class SkillPage
    {
        private static IWebElement AddNewButton => Driver.driver.FindElement(By.XPath("//div[@class='ui teal button'][text()='Add New']"));
        private static IWebElement AddSkill => Driver.driver.FindElement(By.XPath("//input[@type='text' and @placeholder='Add Skill']"));
        private static IWebElement AddSkillLevel => Driver.driver.FindElement(By.XPath("//select[@class='ui fluid dropdown' and @name='level']"));
        private static IWebElement AddButton => Driver.driver.FindElement(By.XPath("//input[@type='button'and @class='ui teal button ']"));        
        private static IWebElement UpdateButton => Driver.driver.FindElement(By.XPath("//input[@type='button' and @class='ui teal button']"));
       
        public void NavigateToSkillForm(IWebDriver driver)
        {
            IWebElement skillTab = driver.FindElement(By.XPath("//a[@class='item' and text()='Skills']"));
            skillTab.Click();
        }

        public static IWebElement GetEditPencilIcon(IWebDriver driver, string skill)
        {
            return driver.FindElement(By.XPath($"//tr[td[text()='{skill}']]//i[contains(@class, 'outline write icon')]"));
        }

        public static IWebElement GetDeletePencilIcon(IWebDriver driver, string skill)
        {
            return driver.FindElement(By.XPath($"//tr[td[text()='{skill}']]//i[contains(@class, 'remove icon')]"));
        }       

        public void ViewSkillInTable(IWebDriver driver, string skill, string level)
        {
            var skillRow = driver.FindElements(By.XPath($"//tr[td[text()='{skill}'] and td[text()='{level}']]"));
            Assert.That(skillRow, Is.Not.Null, "skill {skill}, level {level} was not found in the list");
        }

        public void CannotViewSkillInTable(IWebDriver driver, string skill)
        {
            var skillRow = driver.FindElements(By.XPath($"//tr[td[text()='{skill}']]"));
            Assert.That(skillRow, Is.Empty, $"skill {skill} was found in the list, but it should have been deleted.");
        }

        public void AssertionPopupMessage(IWebDriver driver, string expectedMessage)
        {
            WaitHelper.WaitToBeVisible(driver, LocatorType.ClassName, "ns-box", 30);
            IWebElement toastMessageElement = driver.FindElement(By.ClassName("ns-box"));
            string actualMessage = toastMessageElement.Text;
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        public void SuccessfullyAddNewSkill(IWebDriver driver,string skillToBeAdd, string skillLevelToBeAdd)
        {
            AddNewButton.Click();
            AddSkill.SendKeys(skillToBeAdd);
            SelectElement dropdown = new SelectElement(AddSkillLevel);            
            dropdown.SelectByText(skillLevelToBeAdd);            
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo(skillLevelToBeAdd));
            AddButton.Click();           
        }  

        public void CannotBeAbleToAddnewSkillWithoutAddingSkillLevel(IWebDriver driver, string skillToBeAdd)
        {           
            AddNewButton.Click();        
            AddSkill.SendKeys(skillToBeAdd); 
            AddButton.Click();
        }      

        public void SuccessfullyEditExistingSkillAndSkillLevel(IWebDriver driver,string skill,string level, string skillToBeEdit, string skillLevelToBeEdit)
        {
            var editPencilIcon = GetEditPencilIcon(driver, skill);
            editPencilIcon.Click();
            AddSkill.Clear();
            AddSkill.SendKeys(skillToBeEdit);            
            SelectElement dropdown = new SelectElement(AddSkillLevel);
            AddSkillLevel.Click();
            AddSkillLevel.SendKeys(skillLevelToBeEdit);
            AddSkillLevel.SendKeys(Keys.Enter);            
            UpdateButton.Click();
        }

        public void SuccsfullyEditOnlyExistingSkillToANewSkillWithoutEditSkillLevel(IWebDriver driver,string skill, string skillToBeEdit)
        {
            var editPencilIcon = GetEditPencilIcon(driver, skill);
            editPencilIcon.Click();
            AddSkill.Clear();
            AddSkill.SendKeys(skillToBeEdit);            
            UpdateButton.Click();
        }

        public void SuccsfullyEditSkillLevelWithoutEditSkill(IWebDriver driver,string skill, string skillLevel, string skillLevelToBeEdit)   
        {
            var editPencilIcon = GetEditPencilIcon(driver, skill);
            editPencilIcon.Click();
            SelectElement dropdown = new SelectElement(AddSkillLevel);
            AddSkillLevel.Click();
            AddSkillLevel.SendKeys(skillLevelToBeEdit);
            AddSkillLevel.SendKeys(Keys.Enter);            
            UpdateButton.Click();
        }

        public void CannotBeAbleToEditExistngSkillAndSkillLevelToAnotherExistingSkill(IWebDriver driver,string skill,string level, string skillToBeEdit, string skillLevelToBeEdit)
        {
            var editPencilIcon = GetEditPencilIcon(driver, skill);
            editPencilIcon.Click();
            AddSkill.Clear();
            AddSkill.SendKeys(skillToBeEdit);
            SelectElement dropdown = new SelectElement(AddSkillLevel);
            AddSkillLevel.Click();
            AddSkillLevel.SendKeys(skillLevelToBeEdit);
            AddSkillLevel.SendKeys(Keys.Enter);
            UpdateButton.Click();
        }

        public void SuccesffullydeleteExistingSkill(IWebDriver driver,string skill)
        {
            var deletePencilIcon = GetDeletePencilIcon(driver, skill);
            deletePencilIcon.Click();

        }

    }
}
