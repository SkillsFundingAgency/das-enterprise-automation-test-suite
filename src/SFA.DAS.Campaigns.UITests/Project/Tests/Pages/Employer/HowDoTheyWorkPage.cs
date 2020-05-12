using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class HowDoTheyWorkPage : EmployerBasePage
    {
        protected override string PageTitle => "HOW DO THEY WORK";

        #region Page Object Elements
        private readonly By _hiringAnApprenticeIconLink = By.Id("flow-link-1");
        private readonly By _upskillingYourCurrentStaffIconLink = By.Id("flow-link-2");
        private readonly By _fundingAnApprenticeshipIconLink = By.Id("flow-link-3");
        private readonly By _trainingYourApprenticeIconLink = By.Id("flow-link-4");
        private readonly By _endPointAssessmentsIconLink = By.Id("flow-link-5");
        #endregion


        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly HireAnApprenticePage _hireAnApprenticePage;
        #endregion

        public HowDoTheyWorkPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }


        public HireAnApprenticePage CheckHiringAnApprenticeIconPage()
        {
            formCompletionHelper.ClickElement(_hiringAnApprenticeIconLink);

            return new HireAnApprenticePage(_context);
        }

        public UpSkillingYourCurrentStaffPage CheckUpSkillingYourCurrentStaffPage()
        {
            formCompletionHelper.ClickElement(_upskillingYourCurrentStaffIconLink);
            return new UpSkillingYourCurrentStaffPage(_context);
        }

        public FundingAnApprenticeshipPage CheckFundingAnApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(_fundingAnApprenticeshipIconLink);
            return new FundingAnApprenticeshipPage(_context);
        }

        public TrainingYourApprenticePage CheckTrainYourApprenticePage()
        {
            formCompletionHelper.ClickElement(_trainingYourApprenticeIconLink);
            return new TrainingYourApprenticePage(_context);
        }

        public EndPointAssessmentPage CheckEndPointAssessmentPage()
        {
            formCompletionHelper.ClickElement(_endPointAssessmentsIconLink);
            return new EndPointAssessmentPage(_context);
        }


    }
}