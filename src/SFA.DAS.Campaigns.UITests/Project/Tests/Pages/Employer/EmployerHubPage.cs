using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerHubPage : CampaingnsPage
    {
        protected override string PageTitle => "HIRE AN APPRENTICE";
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected By Basket => By.CssSelector("a[href='/Basket/View']");

        protected By FavCount => By.CssSelector(".favourites-link__count");

        protected By AreApprenticeshipRightForMe => By.Id("fiu-emp-menu-link-1");

        protected By HowDoTheyWork => By.CssSelector("#link-nav-employer-2");

        protected By SettingItUp => By.CssSelector("#link-nav-employer-3");

        protected By SearchForAnApprenticeship => By.CssSelector("#link-nav-employer-4");


        protected By RealStories => By.CssSelector("#link-nav-app-real-stories");

        protected By EmployerBenefits => By.CssSelector("#link-nav-app-benefits");

        protected By HiringAnApprentice => By.CssSelector("#link-nav-emp-hdw-1");

        protected By UpskillingYourCurrentStaff => By.CssSelector("#link-nav-emp-hdw-2");

        protected By FundingAnApprenticeship => By.CssSelector("#link-nav-emp-hdw-3");

        protected By TrainingYourApprenticeship => By.CssSelector("#link-nav-emp-hdw-4");

        protected By EndPointAssessments => By.CssSelector("#link-nav-emp-hdw-6");

        protected By PreparingAndMonitoring => By.CssSelector("#link-nav-emp-step-5");

        protected By ChooseTheRightApprenticeship => By.CssSelector("#link-nav-emp-step-2");

        protected By ChooseATrainingProvider => By.CssSelector("#link-nav-emp-step-3");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EmployerHubPage(ScenarioContext context) : base(context, true) => _context = context;
    
        public EmployerRealStoriesPage NavigateToRealStoriesPage() => NavigateToAreApprenticeshipRightForYou(RealStories, (c) => new EmployerRealStoriesPage(c));

        public EmpBenefitsPage NavigateToEmpBenefitsPage() => NavigateToAreApprenticeshipRightForYou(EmployerBenefits, (c) => new EmpBenefitsPage(c));

        public FundingAnApprenticeshipPage NavigateToFundingAnApprenticeshipPage() => NavigateToHowDoTheyWork(FundingAnApprenticeship, (c) => new FundingAnApprenticeshipPage(c));

        public AreTheyRightFoeYouPage NavigateToAreTheyRightForYouPage()
        {
            formCompletionHelper.ClickElement(AreApprenticeshipRightForMe);
            return new AreTheyRightFoeYouPage(_context);
        }

        public TrainingYourApprenticePage NavigateToTrainingYourApprenticePage() => NavigateToHowDoTheyWork(TrainingYourApprenticeship, (c) => new TrainingYourApprenticePage(c));

        public UpSkillingYourCurrentStaffPage NavigateToUpSkillingYourCurrentStaffPage() => NavigateToHowDoTheyWork(UpskillingYourCurrentStaff, (c) => new UpSkillingYourCurrentStaffPage(c));

        public EndPointAssessmentPage NavigateToEndPointAssesmentPage() => NavigateToHowDoTheyWork(EndPointAssessments, (c) => new EndPointAssessmentPage(c));

        public PreparingAndMonitoringPage NavigateToPreparingAndMonitoringPage() => NavigateToHowDoTheyWork(PreparingAndMonitoring, (c) => new PreparingAndMonitoringPage(c));

        public ChooseTheRightApprenticeshipPage NavigateToChooseTheRightApprenticeshipPage() => NavigateToSettingItUp(ChooseTheRightApprenticeship, (c) => new ChooseTheRightApprenticeshipPage(c));

        public ChooseTheTrainingProviderPage NavigateToChooseTheTrainingProviderPage() => NavigateToSettingItUp(ChooseATrainingProvider, (c) => new ChooseTheTrainingProviderPage(c));

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
        private TResult NavigateToAreApprenticeshipRightForYou<TResult>(By childLocator, Func<ScenarioContext, TResult> func) => NavigateTo(AreApprenticeshipRightForYou, childLocator, func);

        private TResult NavigateToHowDoTheyWork<TResult>(By childLocator, Func<ScenarioContext, TResult> func) => NavigateTo(HowDoTheyWork, childLocator, func);

        private TResult NavigateToSettingItUp<TResult>(By childLocator, Func<ScenarioContext, TResult> func) => NavigateTo(SettingItUp, childLocator, func);
    }
}
