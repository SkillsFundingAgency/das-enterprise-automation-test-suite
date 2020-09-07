using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Features.Apprentice;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class ApprenticeHubPage : CampaingnsPage
    {
          protected override string PageTitle => "Error";
        //protected override string PageTitle => "BECOME";

        #region  Constants and Strings
        private string BecomeAnApprenticePageFiuCard1Heading => "Real stories";
        private string BecomeAnApprenticePageFiuCard2Heading => "What are the benefits of an apprenticeship?";

        private string BecomeAnApprenticePageFiuCard3Heading => "Advice for parents";
        private string BecomeAnApprenticePageFiuCard4Heading => "Browse by interest";
        private string BecomeAnApprenticePageFiuCard5Heading => "What is an apprenticeship";
        private string BecomeAnApprenticePageFiuCard6Heading => "Applying for an apprenticeship";
        private string BecomeAnApprenticePageFiuCard7Heading => "The interview process";
      
        private string BecomeAnApprenticePageFiuCard8Heading => "Starting your apprenticeship";

        private string BecomeAnApprenticePageFiuCard9Heading => "Assessment and certification";
       
        private string BecomeAnApprenticePageFiuCard10Heading => "Set up a service account";

        private string BecomeAnApprenticePageFiuCard11Heading => "Get help and support";

        #endregion 

        #region element /objects
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
       
        protected By AreApprenticeshipRightForYou => By.CssSelector("#fiu-app-menu-link-1");
  
        protected By HowDoTheyWork => By.CssSelector("#fiu-app-menu-link-2");

        protected By GettingStarted => By.CssSelector("#fiu-app-menu-link-3");

        protected By FindAnApprenticeship => By.CssSelector("#fiu-app-menu-link-4");

        protected By RealStories => By.CssSelector(".fiu-card__link--citizens");

        protected By ApprenticeshipBenefits => By.XPath("//a[contains(@href,'/apprentices/benefits-apprenticeship') and contains(text(), 'Learn more')]");

        protected By WhatIsAnApprenticeship => By.CssSelector("#link-nav-app-step-1");

        protected By Application => By.CssSelector("#link-nav-app-step-3");

        protected By Interview => By.CssSelector("#link-nav-app-step-4");

        protected By YourApprenticeship => By.CssSelector("#link-nav-app-step-5");

        protected By AssesmentAndCertification => By.CssSelector("#link-nav-app-step-6");

        private By FiuBecomeAnApprenticeCard1 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Real stories')]");
        private By FiuBecomeAnApprenticeCard2 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'What are the benefits of an apprenticeship?')]");
        private By FiuBecomeAnApprenticeCard3 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Advice for parents')]");
        private By FiuBecomeAnApprenticeCard4 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Browse by interest')]");
        private By FiuBecomeAnApprenticeCard5 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'What is an apprenticeship')]");
        private By FiuBecomeAnApprenticeCard6 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Applying for an apprenticeship')]");
        private By FiuBecomeAnApprenticeCard7 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'The interview process')]");
        private By FiuBecomeAnApprenticeCard8 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Starting your apprenticeship')]");
        private By FiuBecomeAnApprenticeCard9 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Assessment and certification')]");
        private By FiuBecomeAnApprenticeCard10 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Set up a service account')]");
        //private By FiuBecomeAnApprenticeCard11 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Find apprenticeship training')]");
        //private By FiuBecomeAnApprenticeCard12 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Find apprenticeship training')]");
        #endregion

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeHubPage(ScenarioContext context) : base(context)
        {
            _context = context;
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
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

        public ApprenticeHubPage VerifyBecomeAnApprenticeCard1()
        {
            pageInteractionHelper.VerifyText(FiuBecomeAnApprenticeCard1, BecomeAnApprenticePageFiuCard1Heading);
            return new ApprenticeHubPage(_context);
        }

        public ApprenticeHubPage VerifyBecomeAnApprenticeCard2()
        {
            pageInteractionHelper.VerifyText(FiuBecomeAnApprenticeCard2, BecomeAnApprenticePageFiuCard2Heading);
            return new ApprenticeHubPage(_context);
        }

        public ApprenticeHubPage VerifyBecomeAnApprenticeCard3()
        {
            pageInteractionHelper.VerifyText(FiuBecomeAnApprenticeCard3, BecomeAnApprenticePageFiuCard3Heading);
            return new ApprenticeHubPage(_context);
        }

        public ApprenticeHubPage VerifyBecomeAnApprenticeCard4()
        {
            pageInteractionHelper.VerifyText(FiuBecomeAnApprenticeCard4, BecomeAnApprenticePageFiuCard4Heading);
            return new ApprenticeHubPage(_context);
        }

        public ApprenticeHubPage VerifyBecomeAnApprenticeCard5()
        {
            pageInteractionHelper.VerifyText(FiuBecomeAnApprenticeCard5, BecomeAnApprenticePageFiuCard5Heading);
            return new ApprenticeHubPage(_context);
        }
        public ApprenticeHubPage VerifyBecomeAnApprenticeCard6()
        {
            pageInteractionHelper.VerifyText(FiuBecomeAnApprenticeCard6, BecomeAnApprenticePageFiuCard6Heading);
            return new ApprenticeHubPage(_context);
        }
        public ApprenticeHubPage VerifyBecomeAnApprenticeCard7()
        {
            pageInteractionHelper.VerifyText(FiuBecomeAnApprenticeCard7, BecomeAnApprenticePageFiuCard7Heading);
            return new ApprenticeHubPage(_context);
        }
        public ApprenticeHubPage VerifyBecomeAnApprenticeCard8()
        {
            pageInteractionHelper.VerifyText(FiuBecomeAnApprenticeCard8, BecomeAnApprenticePageFiuCard8Heading);
            return new ApprenticeHubPage(_context);
        }
        public ApprenticeHubPage VerifyBecomeAnApprenticeCard9()
        {
            pageInteractionHelper.VerifyText(FiuBecomeAnApprenticeCard9, BecomeAnApprenticePageFiuCard9Heading);
            return new ApprenticeHubPage(_context);
        }
        public ApprenticeHubPage VerifyBecomeAnApprenticeCard10()
        {
            pageInteractionHelper.VerifyText(FiuBecomeAnApprenticeCard10, BecomeAnApprenticePageFiuCard10Heading);
            return new ApprenticeHubPage(_context);
        }

    }
}
