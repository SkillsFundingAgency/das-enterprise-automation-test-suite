using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderConfirmYourReservationPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Confirm your reservation";

        private static By ConfirmButton => By.XPath("//button[contains(text(),'Confirm')]");

        public YouHaveReservedFundingforTrainingPage ConfirmReserveFunding()
        {
            formCompletionHelper.ClickElement(ConfirmButton);
            return new YouHaveReservedFundingforTrainingPage(context);
        }

    }
}
