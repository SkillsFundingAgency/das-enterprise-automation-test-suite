using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderFundingForNonLevyEmployersPage : BasePage
    {
        protected override string PageTitle => "Funding for non-levy employers";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected readonly FormCompletionHelper _formCompletionHelper;
        private readonly string _reservationId;
        #endregion

        protected By AddApprenticeLink => By.CssSelector($"table a[href*='?reservationId={_reservationId}']");

        protected By DeleteFundingLink => By.CssSelector($"table a[href*='{_reservationId}/delete']");

        public ProviderFundingForNonLevyEmployersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _reservationId = context.Get<ObjectContext>().GetReservationId();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ProviderAddApprenticeDetailsPage AddApprenticeWithReservedFunding()
        {
            _formCompletionHelper.ClickElement(AddApprenticeLink);
            return new ProviderAddApprenticeDetailsPage(_context);
        }

        internal DeleteReservationPage DeleteTheReservedFunding()
        {
            _formCompletionHelper.ClickElement(DeleteFundingLink);
            return new DeleteReservationPage(_context);
        }

    }
}
