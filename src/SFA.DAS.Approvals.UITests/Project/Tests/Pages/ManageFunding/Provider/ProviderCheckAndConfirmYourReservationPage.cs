using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderCheckAndConfirmYourReservationPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Check and confirm your reservation";

        private static By ConfirmButton => By.XPath("//button[contains(text(),'Confirm')]");

        public YouHaveReservedFundingForTrainingPage ConfirmReserveFunding()
        {
            formCompletionHelper.ClickElement(ConfirmButton);
            return new YouHaveReservedFundingForTrainingPage(context);
        }

    }
}
