using AventStack.ExtentReports;
using MarsQA.Helpers;
using MarsQA.Pages;
using MarsQA.SpecflowPages.Helpers;

namespace MarsQA.Utils
{
    [Binding]
    public class Start : Driver
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportManager.InitReport();
        }

        [BeforeFeature("Language")]
        public static void CleanUpLanguage()
        {
            SignInAndNavigate();
            LanguagePage.CleaupAllLanguageDataBeforeStartTest();
            Close();
        }

        [BeforeFeature("Skill")]
        public static void CleanUpSkill()
        {
            SignInAndNavigate();
            SkillPage.NavigateToSkillForm();
            SkillPage.CleaupAllSkillDataBeforeStartTest();
            Close();
        }

        private static void SignInAndNavigate()
        {
            ExcelLibHelper.PopulateInCollection(@"SpecflowTests\Data\Mars.xlsx", "Credentials");
            //launch the browser
            Initialize();
            //call the SignIn class
            SignIn.SigninStep();
        }


        [BeforeScenario]
        public void SetupLanguage(ScenarioContext scenarioContext)
        {
            ExtentReportManager.CreateTest(scenarioContext.ScenarioInfo.Title);
            SignInAndNavigate();
            SignIn.SuccessfullyNavigateToProfilePageWithSelectedLanguageTab(driver);

        }


        [AfterScenario("CleanUp-Language", Order = 0)]
        public void CleanDataAfterRunScenarioLanguage(ScenarioContext scenarioContext)
        {          
            if (scenarioContext.ContainsKey("Language"))
            {
                var language = scenarioContext["Language"] as string;
                LanguagePage.CleanUpExistingLanguage(language);
                // Perform any additional cleanup or logging using the retrieved value
            }          

        }

        [AfterScenario("CleanUp-Language-All", Order = 0)]
        public void CleanDataAfterRunScenarioMaxLanguageAdded(ScenarioContext scenarioContext) 
        {
            LanguagePage.CleaupAllLanguageDataBeforeStartTest();
        }

        [AfterScenario("CleanUp-Skill", Order = 0)]
        public void CleanDataAfterRunScenarioSKill(ScenarioContext scenarioContext)
        {
            if (scenarioContext.ContainsKey("Skill"))
            {
                Thread.Sleep(3000);
                var skill = scenarioContext["Skill"] as string;
                SkillPage.CleanUpExistingSkill(skill);
                // Perform any additional cleanup or logging using the retrieved value
            }


        }


        [AfterScenario( Order =1)]
        public void TearDownLanguage()
        { 
        ////    // Screenshot
        ////    //string img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");
        ////   //test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));
        ////    //Close the browser
          Close();
             
        ////    // end test. (Reports)
        ////    //CommonMethods.Extent.EndTest(test);
            
        ////    // calling Flush writes everything to the log file (Reports)
        ////    //CommonMethods.Extent.Flush();
           

        }



        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepInfo = scenarioContext.StepContext.StepInfo.Text;

            if (scenarioContext.TestError == null)
            {
                ExtentReportManager.LogTestStep(Status.Pass, $"{stepType} {stepInfo}");
            }
            else
            {
                ExtentReportManager.LogTestStep(Status.Fail, $"{stepType} {stepInfo}\n{scenarioContext.TestError.Message}");
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportManager.FlushReport();
        }
    }
}
