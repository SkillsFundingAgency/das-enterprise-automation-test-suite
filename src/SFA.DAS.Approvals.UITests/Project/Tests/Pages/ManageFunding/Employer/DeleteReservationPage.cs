using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class DeleteReservationPage : BasePage
    {
        protected override string PageTitle => "Delete Reservation";
        private By DeleteReservationRadioButton => By.CssSelector(".govuk-radios__label");
        private By ConfirmButton => By.CssSelector(".govuk-button");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public DeleteReservationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public DeleteReservationPage ChooseDeleteReservationRadioButton()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(DeleteReservationRadioButton, "Delete");
            return new DeleteReservationPage(_context);
        }

        public ReservationSuccessfullyDeletedPage ClickConfirmButton()
        {
            _formCompletionHelper.ClickElement(ConfirmButton);
            return new ReservationSuccessfullyDeletedPage(_context);
        }
    }
}
