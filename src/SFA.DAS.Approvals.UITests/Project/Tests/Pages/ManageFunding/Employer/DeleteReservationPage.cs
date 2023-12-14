using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class DeleteReservationPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Delete Reservation";
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public DeleteReservationPage(ScenarioContext context) : base(context) { }

        public DeleteReservationPage ChooseDeleteReservationRadioButton()
        {
            SelectRadioOptionByForAttribute("Delete");
            return new DeleteReservationPage(context);
        }

        public ReservationSuccessfullyDeletedPage ClickConfirmButton()
        {
            Continue();
            return new ReservationSuccessfullyDeletedPage(context);
        }
    }
}
