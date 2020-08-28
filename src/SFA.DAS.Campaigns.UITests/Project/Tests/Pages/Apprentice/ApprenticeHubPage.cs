using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Features.Apprentice;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeHubPage : CampaingnsPage
    {
        protected override string PageTitle => "BECOME AN APPRENTICE";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        protected By AreApprenticeshipRightForYou => By.CssSelector("#fiu-app-menu-link-1");
  
        protected By HowDoTheyWork => By.CssSelector("#fiu-app-menu-link-2");

        protected By GettingStarted => By.CssSelector("#fiu-app-menu-link-3");

        protected By FindAnApprenticeship => By.CssSelector("#fiu-app-menu-link-4");

        protected By RealStories => By.CssSelector("#link-nav-app-real-stories");

        protected By ApprenticeshipBenefits => By.CssSelector("#link-nav-app-benefits");

        protected By WhatIsAnApprenticeship => By.CssSelector("#link-nav-app-step-1");

        protected By Application => By.CssSelector("#link-nav-app-step-3");

        protected By Interview => By.CssSelector("#link-nav-app-step-4");

        protected By YourApprenticeship => By.CssSelector("#link-nav-app-step-5");

        protected By AssesmentAndCertification => By.CssSelector("#link-nav-app-step-6");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

       public ApprenticeHubPage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) => _context = context;

        public ApprenticeRealStoriesPage NavigateToRealStoriesPage()
        {
            //formCompletionHelper.ClickElement(RealStories);
            return new ApprenticeRealStoriesPage(_context);
        }
        public AreApprenticeShipRightForMePage NavigateToAreApprenticeShipRightForMe()
        {
            formCompletionHelper.ClickElement(AreApprenticeshipRightForYou);
            return new AreApprenticeShipRightForMePage(_context);
        }

        public HowDoTheyWorkPage NavigateToHowDoTheyWorkPage()
        {
            formCompletionHelper.ClickElement(HowDoTheyWork);
            return new HowDoTheyWorkPage(_context);
        }

         public GettingStartedPage NavigateToGettingStarted()
        {
            formCompletionHelper.ClickElement(GettingStarted);
            return new GettingStartedPage(_context);
        }

        public AppBenefitsPage NavigateToBenefitsofApprenticeshipPage() => NavigateToAreApprenticeshipRightForYou(ApprenticeshipBenefits, (c) => new AppBenefitsPage(c));

        public WhatIsAnApprenticeshipPage NavigateToWhatIsAnApprenticeshipPage() => NavigateToHowDoTheyWork(WhatIsAnApprenticeship, (c) => new WhatIsAnApprenticeshipPage(c));

        public ApplicationPage NavigateToApplicationPage() => NavigateToHowDoTheyWork(Application, (c) => new ApplicationPage(c));

        public InterviewPage NavigateToInterviewPage() => NavigateToHowDoTheyWork(Interview, (c) => new InterviewPage(c));

        public YourApprenticeshipPage NavigateToYourApprenticeshipPage() => NavigateToGettingStarted(YourApprenticeship, (c) => new YourApprenticeshipPage(c));

        public AssesmentAndCertificationPage NavigateToAssesmentAndCertificationPage() => NavigateToGettingStarted(AssesmentAndCertification, (c) => new AssesmentAndCertificationPage(c));

        public FindAnApprenticeshipPage NavigateToFindAnApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(FindAnApprenticeship);
            return new FindAnApprenticeshipPage(_context);
        }

        private TResult NavigateToAreApprenticeshipRightForYou<TResult>(By childLocator, Func<ScenarioContext, TResult> func) => NavigateTo(AreApprenticeshipRightForYou, childLocator, func);

        private TResult NavigateToHowDoTheyWork<TResult>(By childLocator, Func<ScenarioContext, TResult> func) => NavigateTo(HowDoTheyWork, childLocator, func);

        private TResult NavigateToGettingStarted<TResult>(By childLocator, Func<ScenarioContext, TResult> func) => NavigateTo(GettingStarted, childLocator, func);

        //public BecomeAnApprenticePage ClickBecomeAnApprenticeLink()
        //{
        //    formCompletionHelper.ClickElement()

        //    return new BecomeAnApprenticePage(_context);
        //}
    }
}
