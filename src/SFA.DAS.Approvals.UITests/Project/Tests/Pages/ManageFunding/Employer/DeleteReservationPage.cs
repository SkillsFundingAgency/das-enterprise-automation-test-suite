using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class DeleteReservationPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Delete Reservation";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public DeleteReservationPage(ScenarioContext context) : base(context) => _context = context;

        public DeleteReservationPage ChooseDeleteReservationRadioButton()
        {
            SelectRadioOptionByForAttribute("Delete");
            return new DeleteReservationPage(_context);
        }

        public ReservationSuccessfullyDeletedPage ClickConfirmButton()
        {
            Continue();
            return new ReservationSuccessfullyDeletedPage(_context);
        }
    }
}
