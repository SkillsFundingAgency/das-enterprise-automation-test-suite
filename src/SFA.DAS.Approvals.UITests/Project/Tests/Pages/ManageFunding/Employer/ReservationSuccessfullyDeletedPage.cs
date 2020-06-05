using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ReservationSuccessfullyDeletedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Reservation successfully deleted";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ReservationSuccessfullyDeletedPage(ScenarioContext context) : base(context) => _context = context;

        public ReservationSuccessfullyDeletedPage ChooseReturnToManageReservationRadioButton()
        {
            SelectRadioOptionByForAttribute("Manage");
            return new ReservationSuccessfullyDeletedPage(_context);
        }

        public ManageFundingHomePage ClickConfirmButton()
        {
            Continue();
            return new ManageFundingHomePage(_context);
        }
    }
}
