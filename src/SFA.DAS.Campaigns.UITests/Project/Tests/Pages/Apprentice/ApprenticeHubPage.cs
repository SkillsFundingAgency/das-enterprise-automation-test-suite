using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Parent;
using System;
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

        protected By RealStories => By.CssSelector("a[href*='real-stories']");

        protected By ApprenticeshipBenefits => By.XPath("//a[contains(@href,'/apprentices/benefits-apprenticeship') and contains(text(), 'Learn more')]");

        protected By BecomingAnApprentice => By.CssSelector("a[href*='becoming-apprentice']");

        protected By Application => By.CssSelector("a[href*='applying-apprenticeship']");

        protected By Interview => By.CssSelector("a[href*='interview-process']"); 

        protected By BrowserInterest => By.CssSelector("a[href*='browse-by-interests']"); 

        protected By HelpShapeTheirCareer => By.CssSelector("a[href*='help-shape-their-career']"); 

        protected By SetUpService => By.CssSelector("a[href*='create-account']"); 

        protected By YourApprenticeship => By.CssSelector("a[href*='starting-apprenticeship']"); 

        protected By AssesmentAndCertification => By.CssSelector("a[href*='assessment-and-certification']");

        #endregion

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeHubPage(ScenarioContext context) : base(context) => _context = context;

        public void VerifySubHeadings() => VerifyFiuCards(() => NavigateToApprenticeshipHubPage());

        public ApprenticeRealStoriesPage NavigateToRealStoriesPage()
        {
            formCompletionHelper.ClickElement(RealStories);
            return new ApprenticeRealStoriesPage(_context);
        }
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

        public BrowseByInterestPage NavigateToBrowseInterestPage()
        {
            formCompletionHelper.ClickElement(BrowserInterest);
            return new BrowseByInterestPage(_context);
        }

        public SetUpServicePage NavigateToSetUpServiceAccountPage()
        {
            formCompletionHelper.ClickElement(SetUpService);
            return new SetUpServicePage(_context);
        }

        public AppBenefitsPage NavigateToBenefitsofApprenticeshipPage() => NavigateToAreApprenticeshipRightForYou(ApprenticeshipBenefits, (c) => new AppBenefitsPage(c));

        public HelpShapeTheirCareerPage NavigateToHelpShapeTheirCareerPage()
        {
            formCompletionHelper.ClickElement(HelpShapeTheirCareer);
            return new HelpShapeTheirCareerPage(_context);
        }

        public BecomingAnApprenticePage NavigateToWhatIsAnApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(BecomingAnApprentice);
            return new BecomingAnApprenticePage(_context);
        }

        public ApplicationPage NavigateToApplicationPage()
        {
            formCompletionHelper.ClickElement(Application);
            return new ApplicationPage(_context);
        }

        public InterviewPage NavigateToInterviewPage()
        {
            formCompletionHelper.ClickElement(Interview);
            return new InterviewPage(_context);
        }

        public YourApprenticeshipPage NavigateToYourApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(YourApprenticeship);
            return new YourApprenticeshipPage(_context);
        }

        public AssesmentAndCertificationPage NavigateToAssesmentAndCertificationPage()
        {
            formCompletionHelper.ClickElement(AssesmentAndCertification);
            return new AssesmentAndCertificationPage(_context);
        }

        public BrowseApprenticeshipPage NavigateToBrowseApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(BrowseApprenticeship);
            return new BrowseApprenticeshipPage(_context);
        }

        private TResult NavigateToAreApprenticeshipRightForYou<TResult>(By childLocator, Func<ScenarioContext, TResult> func) => NavigateTo(AreApprenticeshipRightForYou, childLocator, func);

    }
}
