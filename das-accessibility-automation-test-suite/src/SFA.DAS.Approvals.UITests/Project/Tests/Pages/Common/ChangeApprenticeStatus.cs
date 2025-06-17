using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class ChangeApprenticeStatus : ApprovalsBasePage
    {
        private static By ConfirmButton => By.Id("submit-status-change");

        protected ChangeApprenticeStatus(ScenarioContext context) : base(context) { }

        public void SelectYesAndConfirm()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            formCompletionHelper.ClickElement(ConfirmButton);
        }
    }
}