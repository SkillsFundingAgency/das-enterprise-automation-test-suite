using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class TransferFundDetailsInErrorPage : TransferMatchingBasePage
    {
        protected override string PageTitle => string.Empty;

        protected override By PageHeader => By.XPath("/html/body/div[3]/h1");

        private static By ErrorMessage => By.XPath("/html/body/div[3]/h2");

        public TransferFundDetailsInErrorPage(ScenarioContext context) : base(context)
        {
            MultipleVerifyPage(
                [
                    () => VerifyPage(PageHeader, "Error"),
                    () => VerifyPage(ErrorMessage, "An error occurred while processing your request.")
                ]);
        }
    }
}