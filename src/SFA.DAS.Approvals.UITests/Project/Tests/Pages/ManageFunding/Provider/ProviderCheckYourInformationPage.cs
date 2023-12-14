using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderCheckYourInformationPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Check your information";

        private static By ConfirmButton => By.XPath("//button[contains(text(),'Confirm')]");

        public ProviderCheckYourInformationPage(ScenarioContext context) : base(context) { }

        public ProviderMakingChangesPage ConfirmReserveFunding()
        {
            formCompletionHelper.ClickElement(ConfirmButton);
            return new ProviderMakingChangesPage(context);
        }

    }
}
