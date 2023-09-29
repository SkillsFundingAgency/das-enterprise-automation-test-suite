using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class EstimateFundingProjectionPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Estimate apprenticeships you could fund";

        private static By StartButton => By.CssSelector("a[href*='forecasting/estimations/start-redirect']");

        public EstimateFundingProjectionPage(ScenarioContext context) : base(context) => VerifyPage();

        public void ClickStart() => formCompletionHelper.Click(StartButton);
    }
}
