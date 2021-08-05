using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.RegisterInterest;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class EmployerHubPage : HubBasePage
    {
        protected override string PageTitle => "EMPLOYERS";

        protected By Basket => By.CssSelector("a[href='/Basket/View']");

        protected By FavCount => By.CssSelector(".fiu-navigation__favourites-link__count");
       
        protected By AreTheyRightForYou = By.CssSelector("a[href='/employers/are-they-right-for-you-employers']");
        
        protected By HowDoTheyWork => By.CssSelector("a[href= '/employers/how-do-they-work-for-employers']");

        protected By SettingItUp => By.CssSelector("a[href='/employers/setting-it-up']");
        
        protected By EnployerGuide => By.CssSelector("a[href='/employers/employer-guides']");

        protected By SearchForAnApprenticeship => By.CssSelector("#fiu-panel-link-fat");

        protected By RealStories => By.CssSelector("a[href='/employers/real-stories-employers']");

        protected By EmployerBenefits => By.CssSelector("a[href='/employers/benefits-of-hiring-apprentice']");

        protected By HiringAnApprentice => By.CssSelector("a[href='/employers/hiring-an-apprentice']");

        protected By UpskillingYourCurrentStaff => By.CssSelector("a[href='/employers/upskilling-your-workforce']");

        protected By FundingAnApprenticeship => By.CssSelector("a[href='/employers/funding-an-apprenticeship']");

        protected By TrainingYourApprenticeship => By.CssSelector("a[href='/employers/training-your-apprentice']");

        protected By EndPointAssessments => By.CssSelector("a[href='/employers/end-point-assessments']");

        protected By ChooseTheRightApprenticeship => By.CssSelector("a[href='/employers/choose-apprenticeship-training']");

        protected By ChooseATrainingProvider => By.CssSelector("a[href='/employers/choose-training-provider']");

        protected By SetUpServiceAccountr => By.CssSelector("a[href='/employers/real-stories']");

        protected By RegisterInterest => By.CssSelector("#fiu-panel-link-reg-int-emp");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EmployerHubPage(ScenarioContext context) : base(context) => _context = context;

        public void VerifySubHeadings() => VerifyFiuCards(() => NavigateToEmployerHubPage());

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
