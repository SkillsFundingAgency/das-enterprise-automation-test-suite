using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class HowDoTheyWorkPage : EmployerBasePage
    {
        protected override string PageTitle => "How do they work?";
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        #region Page Object Elements
        private By HiringAnApprenticeIconLink => By.Id("flow-link-1");
        private By UpskillingYourCurrentStaffIconLink => By.Id("flow-link-2");
        private By FundingAnApprenticeshipIconLink => By.Id("flow-link-3");
        private By TrainingYourApprenticeIconLink => By.Id("flow-link-4");
        private By EndPointAssessmentsIconLink => By.Id("flow-link-5");
        protected override By ContinueButton => By.XPath("//button[ contains(@class,  'button')  and contains(text(), 'Continue')]");
        #endregion

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public HowDoTheyWorkPage(ScenarioContext context) : base(context) => _context = context;

        public HireAnApprenticePage CheckHiringAnApprenticeIconPage()
        {
            formCompletionHelper.ClickElement(HiringAnApprenticeIconLink);
            return new HireAnApprenticePage(_context);
        }

        public UpSkillingYourCurrentStaffPage CheckUpSkillingYourCurrentStaffPage()
        {
            formCompletionHelper.ClickElement(UpskillingYourCurrentStaffIconLink);
            return new UpSkillingYourCurrentStaffPage(_context);
        }

        public FundingAnApprenticeshipPage CheckFundingAnApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(FundingAnApprenticeshipIconLink);
            return new FundingAnApprenticeshipPage(_context);
        }

        public TrainingYourApprenticePage CheckTrainYourApprenticePage()
        {
            formCompletionHelper.ClickElement(TrainingYourApprenticeIconLink);
            return new TrainingYourApprenticePage(_context);
        }

        public EndPointAssessmentPage CheckEndPointAssessmentPage()
        {
            formCompletionHelper.ClickElement(EndPointAssessmentsIconLink);
            return new EndPointAssessmentPage(_context);
        }

        public HireAnApprenticePage ClickContinueButton()
        {
            formCompletionHelper.ClickElement(ContinueButton);
            return new HireAnApprenticePage(_context);
        }
    }
}