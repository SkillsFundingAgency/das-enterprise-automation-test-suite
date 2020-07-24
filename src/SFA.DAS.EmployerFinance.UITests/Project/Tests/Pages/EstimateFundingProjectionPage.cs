using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class EstimateFundingProjectionPage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Estimate apprenticeships you could fund";

        private readonly ScenarioContext _context;

        private By StartButton => By.CssSelector("a[href*='forecasting/estimations/start-redirect']");

        public EstimateFundingProjectionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AddApprenticeshipsToEstimateCostPage Start()
        {
            formCompletionHelper.Click(StartButton);
            return new AddApprenticeshipsToEstimateCostPage(_context);
        }
    }
}
