using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderInformPage : ApprovalsBasePage
    {
        private By ChangeTheEmployerButton => By.Id("change-the-employer-button");

        public ProviderInformPage(ScenarioContext context) : base(context)  { }

        protected override string PageTitle => "What you'll need";

        public ChangeOfEmployerSelectEmployerPage SelectChangeTheEmployer()
        {
            formCompletionHelper.Click(ChangeTheEmployerButton);
            return new ChangeOfEmployerSelectEmployerPage(context);
        }
    }
}
