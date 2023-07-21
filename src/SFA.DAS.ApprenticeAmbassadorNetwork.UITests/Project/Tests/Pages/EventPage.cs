using System.Collections.Generic;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class EventPage : SignInPage
    {
        protected override string PageTitle => "";

        private By CancelAttendanceLink = By.XPath("//button[text()='Cancel your attendance']");
        private By InPersonEventTag = By.XPath("//strong[contains(@class,'govuk-tag app-tag app-tag--InPerson')]");
        private By OnlineEventTag = By.XPath("//strong[contains(@class,'govuk-tag app-tag app-tag--Online')]");
        private By HybridEventTag = By.XPath("//strong[contains(@class,'govuk-tag app-tag app-tag--Hybrid')]");

        public EventPage(ScenarioContext context) : base(context) => VerifyPage();

        public SignUpConfirmationPage SignupForEvent()
        {
            Continue();
            return new SignUpConfirmationPage(context);
        }

        public SignUpCancelledPage CancelYourAttendance()
        {
            formCompletionHelper.ClickElement(CancelAttendanceLink);
            return new SignUpCancelledPage(context);
        }

        public EventPage VerifyInPersonEventTag()
        {
            pageInteractionHelper.IsElementDisplayed(InPersonEventTag);
            return new EventPage(context);
        }

        public EventPage VerifyOnlineEventTag()
        {
            pageInteractionHelper.IsElementDisplayed(OnlineEventTag);
            return new EventPage(context);
        }

        public EventPage VerifyHybridEventTag()
        {
            pageInteractionHelper.IsElementDisplayed(HybridEventTag);
            return new EventPage(context);
        }

    }
}