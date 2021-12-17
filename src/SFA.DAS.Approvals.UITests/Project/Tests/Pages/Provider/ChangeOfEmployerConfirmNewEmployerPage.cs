using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerConfirmNewEmployerPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm new employer";
        protected override By ContinueButton => By.Id("saveBtn");

        public ChangeOfEmployerConfirmNewEmployerPage(ScenarioContext context) : base(context)  { }
        
        public ChangeOfEmployerStartDatePage ConfirmNewEmployer()
        {
            SelectRadioOptionByForAttribute("confirm-true");
            Continue();
            return new ChangeOfEmployerStartDatePage(context);
        }
    }
}
