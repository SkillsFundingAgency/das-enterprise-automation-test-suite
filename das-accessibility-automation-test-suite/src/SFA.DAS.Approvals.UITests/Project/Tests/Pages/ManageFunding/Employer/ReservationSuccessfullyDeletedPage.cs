using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ReservationSuccessfullyDeletedPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Reservation successfully deleted";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public ReservationSuccessfullyDeletedPage ChooseReturnToManageReservationRadioButton()
        {
            SelectRadioOptionByForAttribute("Manage");
            return new ReservationSuccessfullyDeletedPage(context);
        }

        public ManageFundingHomePage ClickConfirmButton()
        {
            Continue();
            return new ManageFundingHomePage(context, false);
        }
    }
}
