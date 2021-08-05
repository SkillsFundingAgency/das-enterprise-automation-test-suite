using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Parent;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeHubPage : HubBasePage
    {
        protected override string PageTitle => "APPRENTICES";

        #region element /objects

        protected By AreApprenticeshipRightForYou => By.CssSelector("#fiu-app-menu-link-1");

        protected By HowDoTheyWork => By.CssSelector("#fiu-app-menu-link-2");

        protected By GettingStarted => By.CssSelector("#fiu-app-menu-link-3");

        protected By BrowseApprenticeship => By.CssSelector("#fiu-app-menu-link-4");

        protected By HelpShapeTheirCareer => By.CssSelector("a[href*='help-shape-their-career']"); 

        protected By SetUpService => By.CssSelector("a[href*='create-account']"); 

        #endregion

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeHubPage(ScenarioContext context) : base(context) => _context = context;

        public void VerifySubHeadings() => VerifyFiuCards(() => NavigateToApprenticeshipHubPage());

        public ApprenticeAreTheyRightForYouPage NavigateToAreApprenticeShipRightForMe()
        {
            formCompletionHelper.ClickElement(AreApprenticeshipRightForYou);
            return new ApprenticeAreTheyRightForYouPage(_context);
        }

        public ApprenticeHowDoTheyWorkPage NavigateToHowDoTheyWorkPage()
        {
            formCompletionHelper.ClickElement(HowDoTheyWork);
            return new ApprenticeHowDoTheyWorkPage(_context);
        }

        public GettingStartedPage NavigateToGettingStarted()
        {
            formCompletionHelper.ClickElement(GettingStarted);
            return new GettingStartedPage(_context);
        }

        public SetUpServicePage NavigateToSetUpServiceAccountPage()
        {
            formCompletionHelper.ClickElement(SetUpService);
            return new SetUpServicePage(_context);
        }

        public HelpShapeTheirCareerPage NavigateToHelpShapeTheirCareerPage()
        {
            formCompletionHelper.ClickElement(HelpShapeTheirCareer);
            return new HelpShapeTheirCareerPage(_context);
        }

        public BrowseApprenticeshipPage NavigateToBrowseApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(BrowseApprenticeship);
            return new BrowseApprenticeshipPage(_context);
        }
    }
}
