using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class FundingProjectionPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Funding projection";

        private By EstimateButton => By.CssSelector("a[href*='forecasting/estimations/start']");

        public FundingProjectionPage(ScenarioContext context) : base(context) => VerifyPage();

        public EstimateFundingProjectionPage GoToEstimateFundingProjectionPage()
        {
            formCompletionHelper.Click(EstimateButton);
            return new EstimateFundingProjectionPage(_context);
        }
    }
}
