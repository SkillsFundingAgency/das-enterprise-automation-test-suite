using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderInformPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "What you'll need";

        protected override bool TakeFullScreenShot => false;

        private static By ChangeTheEmployerButton => By.Id("change-the-employer-button");

        public ProviderCoESelectEmployerPage SelectChangeTheEmployer()
        {
            formCompletionHelper.Click(ChangeTheEmployerButton);
            return new ProviderCoESelectEmployerPage(context);
        }
    }
}
