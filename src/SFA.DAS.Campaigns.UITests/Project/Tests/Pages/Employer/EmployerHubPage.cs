using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerHubPage : CampaingnsPage
    {
        protected override string PageTitle => "HIRE AN APPRENTICE";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected By Basket => By.CssSelector("a[href='/Basket/View']");

        protected By FavCount => By.CssSelector(".fiu-navigation__favourites-link__count");
       
        protected By AreTheyRightForYou = By.CssSelector("a[href='/employers/are-they-right-for-you']");
        
        protected By HowDoTheyWork => By.CssSelector("a[href= '/employers/how-do-they-work']");

        protected By SettingItUp => By.CssSelector("a[href='/employers/setting-it-up']");
        
        protected By EnployerGuide => By.CssSelector("a[href='/employers/employer-guides']");

        protected By SearchForAnApprenticeship => By.CssSelector("a[href ='/employers/find-apprenticeship-training']");

        protected By RealStories => By.CssSelector("#fiu-emp-hub-card-1");

        protected By EmployerBenefits => By.CssSelector("#fiu-emp-hub-card-2");

        protected By HiringAnApprentice => By.CssSelector("#fiu-emp-hub-card-3");

        protected By UpskillingYourCurrentStaff => By.CssSelector("#fiu-emp-hub-card-4");

        protected By FundingAnApprenticeship => By.CssSelector("#fiu-emp-hub-card-5");

        protected By TrainingYourApprenticeship => By.CssSelector("#fiu-emp-hub-card-6");

        protected By EndPointAssessments => By.CssSelector("#fiu-emp-hub-card-7");

        protected By ChooseTheRightApprenticeship => By.CssSelector("#fiu-emp-hub-card-8");

        protected By ChooseATrainingProvider => By.CssSelector("#fiu-emp-hub-card-9");

        protected By SetUpServiceAccountr => By.CssSelector("#fiu-emp-hub-card-10");

        protected By RegisterInterest => By.CssSelector("#fiu-panel-link-reg-int-emp");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EmployerHubPage(ScenarioContext context) : base(context, true) => _context = context;

        public void VerifySubHeadings()
        {
            List<IWebElement> func() => pageInteractionHelper.FindElements(FiuCardHeading).ToList();

            VerifyPage(func, "Real stories");
            VerifyPage(func, "Benefits to your organisation");
            VerifyPage(func, "Hiring an apprentice");
            VerifyPage(func, "Upskilling your current staff");
            VerifyPage(func, "Funding an apprenticeship");
            VerifyPage(func, "Training your apprentice");
            VerifyPage(func, "End-point assessments");
            VerifyPage(func, "How to choose the right apprenticeship training");
            VerifyPage(func, "Choose a training provider");
            VerifyPage(func, "Set up a service account");
        }

        public EmployerRealStoriesPage NavigateToRealStoriesPage()
        {
            formCompletionHelper.ClickElement(RealStories);
            return new EmployerRealStoriesPage(_context);
        }
        public EmpBenefitsPage NavigateToEmpBenefitsPage()
        {
            formCompletionHelper.ClickElement(EmployerBenefits);
            return new EmpBenefitsPage(_context);
        }

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

        public EmployerGuidePage NavigateEmployerGuidePage()
        {
            formCompletionHelper.ClickElement(EnployerGuide);
            return new EmployerGuidePage(_context);
        }
        public RegisterInterestPage NavigateToRegisterInterestPage()
        {
            formCompletionHelper.ClickElement(RegisterInterest);
            return new RegisterInterestPage(_context);
        }
    }
}
