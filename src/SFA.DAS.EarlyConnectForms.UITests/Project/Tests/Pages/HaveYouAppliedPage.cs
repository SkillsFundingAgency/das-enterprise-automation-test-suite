using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class HaveYouAppliedPage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "Have you applied for any of the following?";
        private static By ApprenticeshipCheckBox => By.CssSelector("label[for='Question_Answers_0__IsSelected']");
        private static By UniversityCheckBox => By.CssSelector("label[for='Question_Answers_1__IsSelected']");
        private static By NoneAboveCheckBox => By.CssSelector("label[for='Question_Answers_2__IsSelected']");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public AreaOfEnglandPage SelectAnyPastApplications()
        {
            formCompletionHelper.SelectCheckbox(ApprenticeshipCheckBox);
            formCompletionHelper.SelectCheckbox(UniversityCheckBox);
            formCompletionHelper.ClickElement(ContinueButton);
            return new AreaOfEnglandPage(context);
        }

        public AreaOfEnglandPage SelectNoneAbove()
        {
            formCompletionHelper.SelectCheckbox(NoneAboveCheckBox);
            formCompletionHelper.ClickElement(ContinueButton);
            return new AreaOfEnglandPage(context);
        }
    }
}
