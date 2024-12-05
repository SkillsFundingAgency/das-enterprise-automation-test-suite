using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class TelephonePage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "What's your telephone number? (optional)";
        private static By TelephoneField => By.CssSelector("#telephone");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        private static By BackButton => By.CssSelector(".govuk-back-link");
        public AreasOfWorkInterestPage EnterValidTelephoneNumber()
        {
            formCompletionHelper.SendKeys(TelephoneField, earlyConnectDataHelper.TelephoneNumber);
            formCompletionHelper.ClickElement(ContinueButton);
            return new AreasOfWorkInterestPage(context);
        }
        public PostcodePage SelectBackButton()
        {
            formCompletionHelper.ClickElement(BackButton);
            return new PostcodePage(context);
        }
        public CheckYourAnswerPage ChangeTel()
        {
            formCompletionHelper.SendKeys(TelephoneField, earlyConnectDataHelper.TelephoneNumber);
            formCompletionHelper.ClickElement(ContinueButton);
            return new CheckYourAnswerPage(context);
        }
    }
}
