using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class AreaOfEnglandPage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "Would you move to another area of England for an apprenticeship?";
        private static By YesRadioButton => By.CssSelector("label[for='answer-9']");
        private static By NoRadioButton => By.CssSelector("label[for='answer-10']");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public SupportPage SelectYesForTheRightApprenticeship()
        {
            formCompletionHelper.SelectCheckbox(YesRadioButton);
            formCompletionHelper.ClickElement(ContinueButton);
            return new SupportPage(context);
        }

        public SupportPage SelectNo()
        {
            formCompletionHelper.SelectCheckbox(NoRadioButton);
            formCompletionHelper.ClickElement(ContinueButton);
            return new SupportPage(context);
        }
    }
}
