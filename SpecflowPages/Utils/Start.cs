using AventStack.ExtentReports;
using MarsQA.Helpers;
using MarsQA.Pages;
using MarsQA.SpecflowPages.Helpers;
using TechTalk.SpecFlow;
using static MarsQA.Helpers.CommonMethods;

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


        [BeforeScenario]
        public void Setup(ScenarioContext scenarioContext)
        {
            ExtentReportManager.CreateTest(scenarioContext.ScenarioInfo.Title);
            ExcelLibHelper.PopulateInCollection(@"SpecflowTests\Data\Mars.xlsx", "Credentials");
            //launch the browser
            Initialize();            
            //call the SignIn class
            SignIn.SigninStep();
        }

        [AfterScenario]
        public void TearDown()
        {

            // Screenshot
            string img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");
           //test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));
            //Close the browser
            Close();
             
            // end test. (Reports)
            //CommonMethods.Extent.EndTest(test);
            
            // calling Flush writes everything to the log file (Reports)
            //CommonMethods.Extent.Flush();
           

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
