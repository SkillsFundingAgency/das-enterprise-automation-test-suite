using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderFundingForNonLevyEmployersPage : BasePage
    {
        protected override string PageTitle => "Funding for non-levy employers";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly string _reservationId;
        #endregion


        private By AddApprenticeLink => By.CssSelector($"td.govuk-table__cell.govuk-table__cell--numeric > a[href*='?reservationId={_reservationId}']");

        private By DeleteFundingLink => By.CssSelector($"td.govuk-table__cell.govuk-table__cell--numeric > a[href$='{_reservationId}/ delete']");

        public ProviderFundingForNonLevyEmployersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _reservationId = context.Get<ObjectContext>().GetReservationId();
            VerifyPage();
        }

        internal ProviderAddApprenticeDetailsPage AddApprenticeWithReservedFunding()
        {
            _formCompletionHelper.ClickElement(AddApprenticeLink);
            return new ProviderAddApprenticeDetailsPage(_context);
        }

        internal ProviderDeleteReservationPage DeleteTheReservedFunding()
        {
            _formCompletionHelper.ClickElement(DeleteFundingLink);
            return new ProviderDeleteReservationPage(_context);
        }
    }
}
