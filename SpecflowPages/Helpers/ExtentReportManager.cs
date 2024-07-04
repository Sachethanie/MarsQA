using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MarsQA.Helpers;

namespace MarsQA.SpecflowPages.Helpers
{
    public class ExtentReportManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        public static void InitReport()
        {
            var spark = new ExtentSparkReporter(ConstantHelpers.ReportHTMLPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(spark);
        }

        public static void CreateTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public static ExtentTest GetTest()
        {
            return _test;
        }

        public static void LogTestStep(Status status, string message)
        {
            _test.Log(status, message);
        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}
