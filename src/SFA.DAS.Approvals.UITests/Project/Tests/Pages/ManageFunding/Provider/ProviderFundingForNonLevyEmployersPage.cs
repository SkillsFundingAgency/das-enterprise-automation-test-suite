using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderFundingForNonLevyEmployersPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Funding for non-levy employers";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly string _reservationId;
        #endregion

        protected By AddApprenticeLink => By.CssSelector($"table a[href*='?reservationId={_reservationId}']");

        protected By DeleteFundingLink => By.CssSelector($"table a[href*='{_reservationId}/delete']");

        public ProviderFundingForNonLevyEmployersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _reservationId = objectContext.GetReservationId();
        }

        internal ProviderAddApprenticeDetailsPage AddApprenticeWithReservedFunding()
        {
            formCompletionHelper.ClickElement(AddApprenticeLink);
            return new ProviderAddApprenticeDetailsPage(_context);
        }

        internal DeleteReservationPage DeleteTheReservedFunding()
        {
            formCompletionHelper.ClickElement(DeleteFundingLink);
            return new DeleteReservationPage(_context);
        }

        public AccessDeniedPage ClickToDeleteReservation()
        {
            formCompletionHelper.ClickElement(DeleteFundingLink);
            return new AccessDeniedPage(_context);
        }

        public AccessDeniedPage ClickToAddAnApprenticeForaReservation()
        {
            formCompletionHelper.ClickElement(AddApprenticeLink);
            return new AccessDeniedPage(_context);
        }
    }
}