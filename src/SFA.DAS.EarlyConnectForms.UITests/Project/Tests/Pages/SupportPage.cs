using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class SupportPage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "What would you like support with?";
        private static By UnderstandingApprenticeshipCheckBox => By.CssSelector("label[for='Question_Answers_0__IsSelected']");
        private static By FindingApprenticeshipCheckBox => By.CssSelector("label[for='Question_Answers_1__IsSelected']");
        private static By ApplingApprenticeshipCheckBox => By.CssSelector("label[@for='Question_Answers_2__IsSelected']");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public SupportPage SelectAnySupportThatAppliesToYou()
        {
            formCompletionHelper.SelectCheckbox(UnderstandingApprenticeshipCheckBox);
            formCompletionHelper.SelectCheckbox(FindingApprenticeshipCheckBox);
            formCompletionHelper.SelectCheckbox(ApplingApprenticeshipCheckBox);
            formCompletionHelper.ClickElement(ContinueButton);
            return new SupportPage(context);
        } 
    }
}
