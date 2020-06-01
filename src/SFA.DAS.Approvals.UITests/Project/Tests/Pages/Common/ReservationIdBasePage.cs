using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class ReservationIdBasePage : ApprovalsBasePage
    {
        private By MessageLocator => By.TagName("body");

        protected ReservationIdBasePage(ScenarioContext context) : base(context) { }

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
