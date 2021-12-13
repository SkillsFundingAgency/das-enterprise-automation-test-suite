using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public abstract class ApprenticeBasePage : HubBasePage
    {
        protected override By PageHeader => SubPageHeader;

        protected By AreApprenticeshipRightForYou => By.CssSelector("#fiu-app-menu-link-1");

        protected By HowDoTheyWork => By.CssSelector("#fiu-app-menu-link-2");

        protected By GettingStarted => By.CssSelector("#fiu-app-menu-link-3");

        protected By BrowseApprenticeship => By.CssSelector("#fiu-app-menu-link-4");

        #region Helpers and Context
        
        #endregion

        protected ApprenticeBasePage(ScenarioContext context) : base(context)  { }

        public ApprenticeAreTheyRightForYouPage NavigateToAreApprenticeShipRightForMe()
        {
            formCompletionHelper.ClickElement(AreApprenticeshipRightForYou);
            return new ApprenticeAreTheyRightForYouPage(context);
        }

        public ApprenticeHowDoTheyWorkPage NavigateToHowDoTheyWorkPage()
        {
            formCompletionHelper.ClickElement(HowDoTheyWork);
            return new ApprenticeHowDoTheyWorkPage(context);
        }

        public GettingStartedPage NavigateToGettingStarted()
        {
            formCompletionHelper.ClickElement(GettingStarted);
            return new GettingStartedPage(context);
        }

        public BrowseApprenticeshipPage NavigateToBrowseApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(BrowseApprenticeship);
            return new BrowseApprenticeshipPage(context);
        }
    }
}