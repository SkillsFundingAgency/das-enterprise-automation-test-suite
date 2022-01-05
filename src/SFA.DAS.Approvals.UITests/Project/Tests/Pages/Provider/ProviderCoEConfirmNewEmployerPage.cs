using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoEConfirmNewEmployerPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm new employer";

        protected override bool TakeFullScreenShot => false;

        protected override By ContinueButton => By.Id("saveBtn");

        public ProviderCoEConfirmNewEmployerPage(ScenarioContext context) : base(context)  { }
        
        public ProviderCoEStartDatePage ConfirmNewEmployer()
        {
            SelectRadioOptionByForAttribute("confirm-true");
            Continue();
            return new ProviderCoEStartDatePage(context);
        }
    }
}
