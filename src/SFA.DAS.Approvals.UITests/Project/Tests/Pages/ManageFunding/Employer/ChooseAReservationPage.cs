using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ChooseAReservationPage : BasePage
    {
        protected override string PageTitle => "Choose a Reservation";
        private By CreateANewReservationRadioButton => By.CssSelector(".govuk-radios__label govuk-label--s");
        private By SaveAndContinueButton => By.CssSelector(".govuk-button");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ChooseAReservationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ChooseAReservationPage ChooseCreateANewReservationRadioButton()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(CreateANewReservationRadioButton, "CreateNew");
            return new ChooseAReservationPage(_context);
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickSaveAndContinueButton()
        {
            _formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }
    }
}
