using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class DynamicHomePage : BasePage
    {
        #region Helpers and Context
        protected readonly PageInteractionHelper _pageInteractionHelper;
        protected readonly FormCompletionHelper _formCompletionHelper;
        protected readonly ObjectContext objectContext;
        private readonly ScenarioContext _context;
        #endregion

        private const string ContinueSettingUpAnApprenticeshipPanelText = "Continue setting up an apprenticeship";
        protected override string PageTitle => objectContext.GetOrganisationName();
        private By ContinueSettingUpAnApprenticeship => By.CssSelector(".heading-large");
        private By CheckFundingAvailabilityAndMakeaReservation => By.LinkText("Check funding availability and make a reservation");
        public DynamicHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }

        public DynamicHomePage DisplayReservationOnHomPage()
        {
            return this;
           // return DynamicHomePage
        }
        
        public ReserveFundingToTrainAndAssessAnApprenticePage ClickToReserveFunding()
        {
            _formCompletionHelper.ClickElement(CheckFundingAvailabilityAndMakeaReservation);
            return new ReserveFundingToTrainAndAssessAnApprenticePage(_context);
        }

        public void VerifyReserveFundingPanel()
        {
            _pageInteractionHelper.VerifyText(ContinueSettingUpAnApprenticeship, ContinueSettingUpAnApprenticeshipPanelText);
        }

    }
}
