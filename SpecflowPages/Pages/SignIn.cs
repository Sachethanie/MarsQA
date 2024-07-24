﻿using MarsQA.Helpers;
using MarsQA.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using RazorEngine;
using SeleniumExtras.WaitHelpers;

namespace MarsQA.Pages
{
    public class SignIn : Driver
    {
        private static IWebElement SignInBtn =>  driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In']"));
        private static IWebElement Email => driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]"));
        private static IWebElement Password => driver.FindElement(By.XPath("//INPUT[@type='password']"));
        private static IWebElement LoginBtn => driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']"));

        public static string SignOutXpath = "//button[@class='ui green basic button'][text()='Sign Out']";
        public static void SigninStep()
        {
            Driver.NavigateUrl();
            SignInBtn.Click();
            Email.SendKeys(ExcelLibHelper.ReadData(2,"username"));
            Password.SendKeys(ExcelLibHelper.ReadData(2, "password"));
            LoginBtn.Click();
            WaitHelper.WaitToBeVisible(LocatorType.xPath, SignOutXpath, 5);
           
        }
        public static void Login()
        {
            Driver.NavigateUrl();

            //Enter Url
            Driver.driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In']")).Click();

            //Enter Username
            Driver.driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]")).SendKeys("");

            //Enter password
            Driver.driver.FindElement(By.XPath("//INPUT[@type='password']")).SendKeys("");

            //Click on Login Button
            Driver.driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']")).Click();

        }

        public static void SuccessfullyNavigateToProfilePageWithSelectedLanguageTab(IWebDriver driver)
        {
            string expectedUrl = $"{BaseUrl}/Account/Profile";
            string actualUrl = driver.Url;
            Assert.That(actualUrl, Is.EqualTo(expectedUrl), $"The URL {actualUrl} is not as expected.");
        }
    }
}