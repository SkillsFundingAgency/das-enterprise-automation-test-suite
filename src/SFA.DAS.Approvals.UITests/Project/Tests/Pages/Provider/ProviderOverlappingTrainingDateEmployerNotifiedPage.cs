using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderOverlappingTrainingDateEmployerNotifiedPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        protected override string PageTitle => "Employer notified to confirm changes";

        private static By IWillAddAnotherApprenticeRadionButton => By.CssSelector("#radio-add-another-apprentice");

        protected override bool TakeFullScreenShot => false;

        public ProviderApproveApprenticeDetailsPage IWillAddAnotherApprentice()
        {
            formCompletionHelper.SelectRadioOptionByLocator(IWillAddAnotherApprenticeRadionButton);
            Continue();

            return new ProviderApproveApprenticeDetailsPage(context);
        }
    }
}
