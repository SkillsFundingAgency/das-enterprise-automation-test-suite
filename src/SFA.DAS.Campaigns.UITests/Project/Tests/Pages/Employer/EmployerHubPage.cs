using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerHubPage : EmployerBasePage
    {
        protected override string PageTitle => "EMPLOYERS";

        protected override By PageHeader => PageHeaderTag;
        
        protected By SearchForAnApprenticeship => By.CssSelector("#fiu-panel-link-fat");

        protected By FundingAnApprenticeship => By.CssSelector("a[href='/employers/funding-an-apprenticeship']");

        protected By RegisterInterest => By.CssSelector("#fiu-panel-link-reg-int-emp");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EmployerHubPage(ScenarioContext context) : base(context) => _context = context;

        public void VerifySubHeadings() => VerifyFiuCards(() => NavigateToEmployerHubPage());

        public FundingAnApprenticeshipPage NavigateToFundingAnApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(FundingAnApprenticeship);
            return new FundingAnApprenticeshipPage(_context);
        }

        public SearchForAnApprenticeshipPage NavigateToFindAnApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(SearchForAnApprenticeship);
            return new SearchForAnApprenticeshipPage(_context);
        }

        public RegisterInterestPage NavigateToRegisterInterestPage()
        {
            formCompletionHelper.ClickElement(RegisterInterest);
            return new RegisterInterestPage(_context);
        }
    }
}
