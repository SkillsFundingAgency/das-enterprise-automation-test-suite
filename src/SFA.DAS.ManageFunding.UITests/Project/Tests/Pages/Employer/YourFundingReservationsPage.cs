using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManageFunding.UITests.Project.Tests.Pages.Employer
{
    public class YourFundingReservationsPage : BasePage
    {
        protected override string PageTitle => "Your funding reservations";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ManageFundingConfig _config;
        #endregion

        public YourFundingReservationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetManageFundingConfig<ManageFundingConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        private By ReserveMoreFundingLink => By.LinkText("Reserve more funding");

        public ReserveFundingToTrainAndAssessAnApprenticePage ClickReserveMoreFundingLink()
        {
            _formCompletionHelper.ClickElement(ReserveMoreFundingLink);
            return new ReserveFundingToTrainAndAssessAnApprenticePage(_context);
        }
    }
}
