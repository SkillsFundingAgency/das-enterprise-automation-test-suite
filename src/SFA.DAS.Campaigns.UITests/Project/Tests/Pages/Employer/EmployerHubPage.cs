using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerHubPage : HubBasePage
    {
        protected override string PageTitle => "EMPLOYERS";

        protected By FavCount => By.CssSelector(".fiu-navigation__favourites-link__count");
       
        protected By AreTheyRightForYou = By.CssSelector("a[href='/employers/are-they-right-for-you-employers']");
        
        protected By HowDoTheyWork => By.CssSelector("a[href= '/employers/how-do-they-work-for-employers']");

        protected By SettingItUp => By.CssSelector("a[href='/employers/setting-it-up']");
        
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

        public EmployerAreTheyRightForYouPage NavigateToAreTheyRightForYouPage()
        {
            formCompletionHelper.ClickElement(AreTheyRightForYou);
            return new EmployerAreTheyRightForYouPage(_context);
        }

        public SearchForAnApprenticeshipPage NavigateToFindAnApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(SearchForAnApprenticeship);
            return new SearchForAnApprenticeshipPage(_context);
        }

        public EmployerHowDoTheyWorkPage ClickHowDoTheyWorkLink()
        {
            formCompletionHelper.ClickElement(HowDoTheyWork);
            return new EmployerHowDoTheyWorkPage(_context);
        }

        public SettingItUpPage ClickSettingUpLink()
        {
            formCompletionHelper.ClickElement(SettingItUp);
            return new SettingItUpPage(_context);
        }

        public RegisterInterestPage NavigateToRegisterInterestPage()
        {
            formCompletionHelper.ClickElement(RegisterInterest);
            return new RegisterInterestPage(_context);
        }
    }
}
