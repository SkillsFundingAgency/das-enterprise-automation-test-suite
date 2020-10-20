using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class ChangeApprenticeStatus : ApprovalsBasePage
    {

        private By SelectPauseConfirmed => By.Id("PauseConfirmed");
        private By ConfirmButton => By.Id("submit-status-change");
        private By ConfirmResumeOptions => By.CssSelector(".selection-button-radio");


        protected ChangeApprenticeStatus(ScenarioContext context) : base(context) {}
        
        public void SelectYesAndConfirmPause()
        {
            javaScriptHelper.ClickElement(SelectPauseConfirmed);
            formCompletionHelper.ClickElement(ConfirmButton);
        }
        public void SelectYesAndConfirm()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmResumeOptions, "ChangeConfirmed-True");
            formCompletionHelper.ClickElement(ConfirmButton);
        }
    }
}