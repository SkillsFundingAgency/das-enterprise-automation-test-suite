using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class ApprenticeshipsLevelPage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "What level of apprenticeship are you interested in?";
        private static By Level2Checbox => By.CssSelector("label[for='Question_Answers_0__IsSelected']");
        private static By Level3CheckBox => By.CssSelector("label[for='Question_Answers_1__IsSelected']");
        private static By NotSureCheckBox => By.CssSelector("label[for='Question_Answers_4__IsSelected']");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public ApprenticeshipsLevelPage SelectAnyApprenticeshipLevelInterestToYou()
        {
            formCompletionHelper.SelectCheckbox(Level2Checbox);
            formCompletionHelper.SelectCheckbox(Level3CheckBox);
            formCompletionHelper.ClickElement(ContinueButton);
            return new ApprenticeshipsLevelPage(context);
        }

        public ApprenticeshipsLevelPage SelectNotSure()
        {
            formCompletionHelper.SelectCheckbox(NotSureCheckBox);
            formCompletionHelper.ClickElement(ContinueButton);
            return new ApprenticeshipsLevelPage(context);
        }
    }
}
