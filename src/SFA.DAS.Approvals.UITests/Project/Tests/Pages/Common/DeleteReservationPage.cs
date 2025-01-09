using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public class DeleteReservationPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Delete Reservation";

        protected override By ContinueButton => By.XPath("//button[contains(text(),'Confirm')]");

        internal ReservationSuccessfullyDeletedPage YesDeleteThisReservation()
        {
            SelectRadioOptionByForAttribute("Delete");
            Continue();
            return new ReservationSuccessfullyDeletedPage(context);
        }

        internal ProviderFundingForNonLevyEmployersPage NoGoBackToManageReservations()
        {
            SelectRadioOptionByForAttribute("Delete-no");
            Continue();
            return new ProviderFundingForNonLevyEmployersPage(context);
        }
    }
}
