using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class DeleteReservationPage : BasePage
    {
        protected override string PageTitle => "Delete Reservation";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

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
            SelectRadioOptionByForAttribute("Delete");
            return new DeleteReservationPage(_context);
        }

        public ReservationSuccessfullyDeletedPage ClickConfirmButton()
        {
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ReservationSuccessfullyDeletedPage(_context);
        }
    }
}
