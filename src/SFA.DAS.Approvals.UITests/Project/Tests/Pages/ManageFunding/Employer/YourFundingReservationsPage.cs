using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class YourFundingReservationsPage : FundingBasePage
    {
        protected override string PageTitle => "Your funding reservations";
        private By ReserveMoreFundingLink => By.LinkText("Reserve more funding");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public YourFundingReservationsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public ReserveFundingToTrainAndAssessAnApprenticePage ClickReserveMoreFundingLink()
        {
            formCompletionHelper.ClickElement(ReserveMoreFundingLink);
            return new ReserveFundingToTrainAndAssessAnApprenticePage(_context);
        }
    }
}
