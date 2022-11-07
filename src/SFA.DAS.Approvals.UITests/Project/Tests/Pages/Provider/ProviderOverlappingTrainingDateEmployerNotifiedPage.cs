using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderOverlappingTrainingDateEmployerNotifiedPage : ApprovalsBasePage
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        protected override string PageTitle => "Employer notified to confirm changes";

        protected override bool TakeFullScreenShot => false;

        public ProviderOverlappingTrainingDateEmployerNotifiedPage(ScenarioContext context) : base(context) { }
    }
}
