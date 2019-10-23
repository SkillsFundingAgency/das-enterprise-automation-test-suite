using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderChooseAReservationPage : BasePage
    {
        protected override string PageTitle => "Choose a Reservation";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ProviderChooseAReservationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        private By CreateANewReservationButton => By.CssSelector(".govuk-label--s");
        private By SaveAndContinueButton => By.CssSelector(".govuk-button");

        public ProviderApprenticeshipTrainingPage CreateANewReservation()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(CreateANewReservationButton, "CreateNew");
            _formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new ProviderApprenticeshipTrainingPage(_context);
        }
    }
}
