using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderInformPage : ApprovalsBasePage
    {
        protected override string PageTitle => "What you'll need";

        protected override bool TakeFullScreenShot => false;

        private By ChangeTheEmployerButton => By.Id("change-the-employer-button");

        public ProviderInformPage(ScenarioContext context) : base(context)  { }

        public ProviderCoESelectEmployerPage SelectChangeTheEmployer()
        {
            formCompletionHelper.Click(ChangeTheEmployerButton);
            return new ProviderCoESelectEmployerPage(context);
        }
    }
}
