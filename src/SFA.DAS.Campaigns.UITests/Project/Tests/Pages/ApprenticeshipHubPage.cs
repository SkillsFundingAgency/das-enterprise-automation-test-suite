using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class ApprenticeshipHubPage : CampaingnsBasePage
    {
        protected override string PageTitle => "APPRENTICE HUB";

        protected override By PageHeader => By.CssSelector(".header__caption--apprentice");

        protected By AreApprenticeshipRightForYou => By.CssSelector("#link-nav-apprentice-1");

        protected By HowDoTheyWork => By.CssSelector("#link-nav-apprentice-2");

        protected By GettingStarted => By.CssSelector("#link-nav-apprentice-3");

        protected By FindAnApprenticeship => By.CssSelector("#link-nav-apprentice-4");

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

        public ApprenticeshipHubPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public RealStoriesPage NavigateToRealStoriesPage() => NavigateToAreApprenticeshipRightForYou(RealStories, (c) => new RealStoriesPage(c));

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

        private TResult NavigateTo<TResult>(By parentLocator, By childLocator, Func<ScenarioContext, TResult> func)
        {
            formCompletionHelper.ClickElement(() =>
            {
                pageInteractionHelper.FocusTheElement(parentLocator);
                return pageInteractionHelper.FindElement(childLocator);
            });

            return func(_context);
        }
    }
}
