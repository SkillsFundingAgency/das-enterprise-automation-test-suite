using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderChooseAReservationPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Choose a Reservation";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderChooseAReservationPage(ScenarioContext context) : base(context) => _context = context;

        private By CreateANewReservationButton => By.CssSelector(".govuk-label--s");
        private By SaveAndContinueButton => By.CssSelector(".govuk-button");

        public ProviderApprenticeshipTrainingPage CreateANewReservation()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(CreateANewReservationButton, "CreateNew");
            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderApprenticeshipTrainingPage(_context);
        }
    }
}
