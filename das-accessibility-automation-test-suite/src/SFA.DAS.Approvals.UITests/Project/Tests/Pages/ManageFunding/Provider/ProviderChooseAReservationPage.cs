using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderChooseAReservationPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Select a Reservation";

        protected override bool TakeFullScreenShot => false;

        private static By CreateANewReservationButton => By.CssSelector(".govuk-label--s");
        private static By SaveAndContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        public ProviderApprenticeshipTrainingPage CreateANewReservation()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(CreateANewReservationButton, "CreateNew");
            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderApprenticeshipTrainingPage(context);
        }
    }
}
