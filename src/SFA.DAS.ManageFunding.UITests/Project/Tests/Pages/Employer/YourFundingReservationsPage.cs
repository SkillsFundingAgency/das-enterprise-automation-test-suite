using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ManageFunding.UITests.Project.Tests.Pages.Employer
{
    public class YourFundingReservationsPage : BasePage
    {
        protected override string PageTitle => "Your funding reservations";
        private By ReserveMoreFundingLink => By.LinkText("Reserve more funding");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public YourFundingReservationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ReserveFundingToTrainAndAssessAnApprenticePage ClickReserveMoreFundingLink()
        {
            _formCompletionHelper.ClickElement(ReserveMoreFundingLink);
            return new ReserveFundingToTrainAndAssessAnApprenticePage(_context);
        }
    }
}
