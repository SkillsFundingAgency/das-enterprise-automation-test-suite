using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderChooseAReservationPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Choose a Reservation";

        protected override bool TakeFullScreenShot => false;

        public ProviderChooseAReservationPage(ScenarioContext context) : base(context)  { }

        private By CreateANewReservationButton => By.CssSelector(".govuk-label--s");
        private By SaveAndContinueButton => By.XPath("//button[contains(text(),'Save and continue')]");

        public ProviderApprenticeshipTrainingPage CreateANewReservation()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(CreateANewReservationButton, "CreateNew");
            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderApprenticeshipTrainingPage(_context);
        }
    }
}
