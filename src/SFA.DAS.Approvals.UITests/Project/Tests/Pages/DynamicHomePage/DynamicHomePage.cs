using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class DynamicHomePage : BasePage
    {
        #region Helpers and Context
        protected readonly PageInteractionHelper _pageInteractionHelper;
        protected readonly FormCompletionHelper _formCompletionHelper;
        protected readonly ObjectContext objectContext;
        private readonly ScenarioContext _context;
        #endregion

        #region
        private const string ContinueSettingUpAnApprenticeshipPanelText = "Continue setting up an apprenticeship";
        private By ContinueSettingUpAnApprenticeship => By.Id("call-to-action-continue-setting-up-an-apprenticeship");
        private By CheckFundingAvailabilityAndMakeaReservation => By.LinkText("Check funding availability and make a reservation");
        protected override string PageTitle => "Home";
        protected override By PageHeader => By.LinkText("Home");
        protected override By ContinueButton => By.LinkText("Continue");
        #endregion

        public DynamicHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        
        public ReserveFundingToTrainAndAssessAnApprenticePage ClickToReserveFunding()
        {
            _formCompletionHelper.ClickElement(CheckFundingAvailabilityAndMakeaReservation);
            return new ReserveFundingToTrainAndAssessAnApprenticePage(_context);
        }

        public DoYouNeedToCreateAnAdverForThisApprenticeshipPage ClickContinueToCreateAdvertOrAddAnApprentices()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
            return new DoYouNeedToCreateAnAdverForThisApprenticeshipPage(_context);
        }
        public void VerifyReserveFundingPanel()
        {
            _pageInteractionHelper.VerifyText(ContinueSettingUpAnApprenticeship, ContinueSettingUpAnApprenticeshipPanelText);
        }

    }
}
