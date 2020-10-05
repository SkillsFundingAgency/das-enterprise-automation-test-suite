using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeHubPage : CampaingnsPage
    {
        protected override string PageTitle => "BECOME AN APPRENTICE";

        #region element /objects
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        protected By AreApprenticeshipRightForYou => By.CssSelector("#fiu-app-menu-link-1");
        protected By HowDoTheyWork => By.CssSelector("#fiu-app-menu-link-2");

        protected By GettingStarted => By.CssSelector("#fiu-app-menu-link-3");

        protected By FindAnApprenticeship => By.CssSelector("#fiu-app-menu-link-4");

        protected By RealStories => By.CssSelector(".fiu-card__link--citizens");

        protected By ApprenticeshipBenefits => By.XPath("//a[contains(@href,'/apprentices/benefits-apprenticeship') and contains(text(), 'Learn more')]");

        protected By WhatIsAnApprenticeship => By.CssSelector("#fiu-app-hub-card-5");

        protected By Application => By.CssSelector("#fiu-app-hub-card-6");

        protected By Interview => By.CssSelector("#fiu-app-hub-card-7");

        protected By BrowserInterest => By.CssSelector("#fiu-app-hub-card-4");

        protected By AdviceForParents => By.CssSelector("#fiu-app-hub-card-3");

        protected By SetUpService => By.CssSelector("#fiu-app-hub-card-10");

        protected By SiteMap => By.CssSelector("#link-footer-sitemap");

        protected By YourApprenticeship => By.CssSelector("#fiu-app-hub-card-8");

        protected By AssesmentAndCertification => By.CssSelector("#fiu-app-hub-card-9");

        private By FiuCardHeading => By.CssSelector(".fiu-card__heading");

        #endregion

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeHubPage(ScenarioContext context) : base(context) => _context = context;

        public void VerifySubHeadings()
        {
            List<IWebElement> func() => pageInteractionHelper.FindElements(FiuCardHeading).ToList();

            VerifyPage(func, "Real stories");
            VerifyPage(func, "What are the benefits of an apprenticeship?");
            VerifyPage(func, "Help shape their career");
            VerifyPage(func, "Browse by interest");
            VerifyPage(func, "Becoming an apprentice");
            VerifyPage(func, "Applying for an apprenticeship");
            VerifyPage(func, "The interview process");
            VerifyPage(func, "Starting your apprenticeship");
            VerifyPage(func, "Assessment and certification");
            VerifyPage(func, "Set up a service account");
        }

        public ApprenticeRealStoriesPage NavigateToRealStoriesPage()
        {
            formCompletionHelper.ClickElement(RealStories);
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


        public SiteMapPage NavigateToSiteMapPage()
        {
            formCompletionHelper.ClickElement(SiteMap);
            return new SiteMapPage(_context);
        }

        public AppBenefitsPage NavigateToBenefitsofApprenticeshipPage() => NavigateToAreApprenticeshipRightForYou(ApprenticeshipBenefits, (c) => new AppBenefitsPage(c));

        public HelpShapeTheirCareerPage NavigateToAdviceForParentPage()
        {
            formCompletionHelper.ClickElement(AdviceForParents);
            return new HelpShapeTheirCareerPage(_context);
        }

        public WhatIsAnApprenticeshipPage NavigateToWhatIsAnApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(WhatIsAnApprenticeship);
            return new WhatIsAnApprenticeshipPage(_context);
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

        public FindAnApprenticeshipPage NavigateToFindAnApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(FindAnApprenticeship);
            return new FindAnApprenticeshipPage(_context);
        }

        private TResult NavigateToAreApprenticeshipRightForYou<TResult>(By childLocator, Func<ScenarioContext, TResult> func) => NavigateTo(AreApprenticeshipRightForYou, childLocator, func);

    }
}
