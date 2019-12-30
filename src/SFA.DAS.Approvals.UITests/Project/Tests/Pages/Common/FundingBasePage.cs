using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class FundingBasePage : BasePage
    {
        #region Helpers and Context
        private readonly string _reservationId;
        #endregion
 
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion
 
        protected By AddApprenticeLink => By.CssSelector($"table a[href*='?reservationId={_reservationId}']");

        protected By DeleteFundingLink => By.CssSelector($"table a[href*='{_reservationId}/delete']");

        public FundingBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            formCompletionHelper = context.Get<FormCompletionHelper>();
            _reservationId = context.Get<ObjectContext>().GetReservationId();
            VerifyPage();
        }

        internal DeleteReservationPage DeleteTheReservedFunding()
        {
            formCompletionHelper.ClickElement(DeleteFundingLink);
            return new DeleteReservationPage(_context);
        }
    }
}
