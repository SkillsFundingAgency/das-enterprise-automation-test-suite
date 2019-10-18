using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class ReservationIdBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        #endregion

        public ReservationIdBasePage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }

        protected void SetCurrentReservationId()
        {
            var currentUrl = pageInteractionHelper.GetUrl();

            int subStringIndexFrom = currentUrl.IndexOf("/reservations/") + "/reservations/".Length;
            int subStringIndexTo = currentUrl.LastIndexOf("/completed");

            var reservationId = currentUrl.Substring(subStringIndexFrom, subStringIndexTo - subStringIndexFrom);

            objectContext.SetReservationId(reservationId);
        }
    }
}
