using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class CheckYourAnswerPage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "Check your details before they’re sent to DfE";
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public CheckYourAnswerPage AcceptAndSubmitForm()
        {
            formCompletionHelper.ClickElement(ContinueButton);
            return new CheckYourAnswerPage(context);
        }

    }
}
