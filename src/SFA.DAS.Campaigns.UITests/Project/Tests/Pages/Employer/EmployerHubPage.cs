using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerHubPage : CampaingnsPage
    {
        protected override string PageTitle => "Page not found";

        #region  Constants and Strings
        private string HireAnApprenticePageFiuCard1Heading => "Real stories";
        private string HireAnApprenticePageFiuCard2Heading => "Benefits to your organisation";

        private string HireAnApprenticePageFiuCard3Heading => "Hiring an apprentice";
        private string HireAnApprenticePageFiuCard4Heading => "Upskilling your current staff";
        private string HireAnApprenticePageFiuCard5Heading => "Funding an apprenticeship";
        private string HireAnApprenticePageFiuCard6Heading => "Training your apprentice";
        private string HireAnApprenticePageFiuCard7Heading => "End-point assessments";

        private string HireAnApprenticePageFiuCard8Heading => "Choose the right apprenticeship";

        private string HireAnApprenticePageFiuCard9Heading => "Choose a training provider";

        private string HireAnApprenticePageFiuCard10Heading => "Set up a service account";

        private string HireAnApprenticePageFiuCard11Heading => "Get help and support";

        #endregion 


        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected By Basket => By.CssSelector("a[href='/Basket/View']");

        protected By FavCount => By.CssSelector(".favourites-link__count");

        protected By AreApprenticeshipRightForMe => By.Id("fiu-emp-menu-link-1");

        protected By HowDoTheyWork => By.CssSelector("a[href= '/employers/how-do-they-work']");

        protected By SettingItUp => By.CssSelector("a[href='/employers/setting-it-up']");
        
        protected By EnployerGuide => By.CssSelector("a[href='/employers/guides']");


        protected By SearchForAnApprenticeship => By.CssSelector("a[href ='/employers/find-apprenticeship-training']");


        protected By RealStories => By.CssSelector("#fiu-emp-hub-card-1");

        protected By EmployerBenefits => By.CssSelector("#lfiu-emp-hub-card-2");

        protected By HiringAnApprentice => By.CssSelector("#fiu-emp-hub-card-3");

        protected By UpskillingYourCurrentStaff => By.CssSelector("#fiu-emp-hub-card-4");

        protected By FundingAnApprenticeship => By.CssSelector("#fiu-emp-hub-card-5");

        protected By TrainingYourApprenticeship => By.CssSelector("#fiu-emp-hub-card-6");

        protected By EndPointAssessments => By.CssSelector("#fiu-emp-hub-card-7");

        protected By PreparingAndMonitoring => By.CssSelector("#link-nav-emp-step-5");

        protected By ChooseTheRightApprenticeship => By.CssSelector("#fiu-emp-hub-card-8");

        protected By ChooseATrainingProvider => By.CssSelector("#fiu-emp-hub-card-9");

        protected By SetUpServiceAccountr => By.CssSelector("#fiu-emp-hub-card-10");

        private By FiuHireAnApprenticeCard1 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Real stories')]");
        private By FiuHireAnApprenticeCard2 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Benefits to your organisation')]");
        private By FiuHireAnApprenticeCard3 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Hiring an apprentice')]");
        private By FiuHireAnApprenticeCard4 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Upskilling your current staff')]");
        private By FiuHireAnApprenticeCard5 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Funding an apprenticeship')]");
        private By FiuHireAnApprenticeCard6 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Training your apprentice')]");
        private By FiuHireAnApprenticeCard7 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'End-point assessments')]");
        private By FiuHireAnApprenticeCard8 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Choose the right apprenticeship')]");
        private By FiuHireAnApprenticeCard9 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Choose a training provider')]");
        private By FiuHireAnApprenticeCard10 => By.XPath("//h3[contains(@class, 'fiu-card__heading') and contains(text(), 'Set up a service account')]");




        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EmployerHubPage(ScenarioContext context) : base(context, true)
        {
            _context = context;
            pageInteractionHelper.VerifyPageLoad(PageHeader, PageTitle);
        }

        //public EmployerRealStoriesPage NavigateToRealStoriesPage() => NavigateToAreApprenticeshipRightForYou(RealStories, (c) => new EmployerRealStoriesPage(c));

        //public EmpBenefitsPage NavigateToEmpBenefitsPage() => NavigateToAreApprenticeshipRightForYou(EmployerBenefits, (c) => new EmpBenefitsPage(c));

        public FundingAnApprenticeshipPage NavigateToFundingAnApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(FundingAnApprenticeship);
            return new FundingAnApprenticeshipPage(_context);
        }

        public AreTheyRightFoeYouPage NavigateToAreTheyRightForYouPage()
        {
            formCompletionHelper.ClickElement(AreApprenticeshipRightForMe);
            return new AreTheyRightFoeYouPage(_context);
        }

        public TrainingYourApprenticePage NavigateToTrainingYourApprenticePage()
        {
            formCompletionHelper.ClickElement(TrainingYourApprenticeship);
            return new TrainingYourApprenticePage(_context);
         }

        public UpSkillingYourCurrentStaffPage NavigateToUpSkillingYourCurrentStaffPage()
        {
            formCompletionHelper.ClickElement(UpskillingYourCurrentStaff);
            return new UpSkillingYourCurrentStaffPage(_context);
        }

        public EndPointAssessmentPage NavigateToEndPointAssesmentPage()
        {
            formCompletionHelper.ClickElement(EndPointAssessments);
            return new EndPointAssessmentPage(_context);
        }

        public PreparingAndMonitoringPage NavigateToPreparingAndMonitoringPage()
        {
            formCompletionHelper.ClickElement(PreparingAndMonitoring);
            return new PreparingAndMonitoringPage(_context);
        }

        public ChooseTheRightApprenticeshipPage NavigateToChooseTheRightApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(ChooseTheRightApprenticeship);
            return new ChooseTheRightApprenticeshipPage(_context);
        }

        public ChooseTheTrainingProviderPage NavigateToChooseTheTrainingProviderPage()
        {
            formCompletionHelper.ClickElement(ChooseATrainingProvider);
            return new ChooseTheTrainingProviderPage(_context);
        }
        public SearchForAnApprenticeshipPage NavigateToFindAnApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(SearchForAnApprenticeship);
            return new SearchForAnApprenticeshipPage(_context);
        }

        public HowDoTheyWorkPage ClickHowDoTheyWorkLink()
        {
            formCompletionHelper.ClickElement(HowDoTheyWork);
            return new HowDoTheyWorkPage(_context);
        }

        public SettingItUpPage ClickSettingUpLink()
        {
            formCompletionHelper.ClickElement(SettingItUp);
            return new SettingItUpPage(_context);
        }

        public EmployerGuidePage NavigateEmployerGuidePage()
        {
            formCompletionHelper.ClickElement(EnployerGuide);
            return new EmployerGuidePage(_context);
        }

        //     private TResult NavigateToAreApprenticeshipRightForYou<TResult>(By childLocator, Func<ScenarioContext, TResult> func) => NavigateTo(AreApprenticeshipRightForYou, childLocator, func);

        private TResult NavigateToHowDoTheyWork<TResult>(By childLocator, Func<ScenarioContext, TResult> func) => NavigateTo(HowDoTheyWork, childLocator, func);

       // private TResult NavigateToSettingItUp<TResult>(By childLocator, Func<ScenarioContext, TResult> func) => NavigateTo(SettingItUp, childLocator, func);

        public EmployerHubPage VerifyHireAnApprenticeCard1()
        {
            pageInteractionHelper.VerifyText(FiuHireAnApprenticeCard1, HireAnApprenticePageFiuCard1Heading);
            return new EmployerHubPage(_context);
        }

        public EmployerHubPage VerifyHireAnApprenticeCard2()
        {
            pageInteractionHelper.VerifyText(FiuHireAnApprenticeCard2, HireAnApprenticePageFiuCard2Heading);
            return new EmployerHubPage(_context);
        }

        public EmployerHubPage VerifyHireAnApprenticeCard3()
        {
            pageInteractionHelper.VerifyText(FiuHireAnApprenticeCard3, HireAnApprenticePageFiuCard3Heading);
            return new EmployerHubPage(_context);
        }

        public EmployerHubPage VerifyHireAnApprenticeCard4()
        {
            pageInteractionHelper.VerifyText(FiuHireAnApprenticeCard4, HireAnApprenticePageFiuCard4Heading);
            return new EmployerHubPage(_context);
        }

        public EmployerHubPage VerifyHireAnApprenticeCard5()
        {
            pageInteractionHelper.VerifyText(FiuHireAnApprenticeCard5, HireAnApprenticePageFiuCard5Heading);
            return new EmployerHubPage(_context);
        }
        public EmployerHubPage VerifyHireAnApprenticeCard6()
        {
            pageInteractionHelper.VerifyText(FiuHireAnApprenticeCard6, HireAnApprenticePageFiuCard6Heading);
            return new EmployerHubPage(_context);
        }
        public EmployerHubPage VerifyHireAnApprenticeCard7()
        {
            pageInteractionHelper.VerifyText(FiuHireAnApprenticeCard7, HireAnApprenticePageFiuCard7Heading);
            return new EmployerHubPage(_context);
        }
        public EmployerHubPage VerifyHireAnApprenticeCard8()
        {
            pageInteractionHelper.VerifyText(FiuHireAnApprenticeCard8, HireAnApprenticePageFiuCard8Heading);
            return new EmployerHubPage(_context);
        }
        public EmployerHubPage VerifyHireAnApprenticeCard9()
        {
            pageInteractionHelper.VerifyText(FiuHireAnApprenticeCard9, HireAnApprenticePageFiuCard9Heading);
            return new EmployerHubPage(_context);
        }
        public EmployerHubPage VerifyHireAnApprenticeCard10()
        {
            pageInteractionHelper.VerifyText(FiuHireAnApprenticeCard10, HireAnApprenticePageFiuCard10Heading);
            return new EmployerHubPage(_context);
        }


    }
}
