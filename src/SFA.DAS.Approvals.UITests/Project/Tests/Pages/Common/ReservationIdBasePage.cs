using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
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

        private By MessageLocator => By.TagName("body");

        public ReservationIdBasePage(ScenarioContext context) : base(context)
        {
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }

        public void VerifySucessMessage()
        {
            var expected = "You have successfully reserved funding for apprenticeship training";

            var actual = pageInteractionHelper.GetText(MessageLocator);

            pageInteractionHelper.VerifyText(actual, expected);

            SetCurrentReservationId();
        }

        private void SetCurrentReservationId()
        {
            var currentUrl = pageInteractionHelper.GetUrl();

            int subStringIndexFrom = currentUrl.IndexOf("/reservations/") + "/reservations/".Length;
            int subStringIndexTo = currentUrl.LastIndexOf("/completed");

            var reservationId = currentUrl.Substring(subStringIndexFrom, subStringIndexTo - subStringIndexFrom);

            objectContext.SetReservationId(reservationId);
        }
    }
}
