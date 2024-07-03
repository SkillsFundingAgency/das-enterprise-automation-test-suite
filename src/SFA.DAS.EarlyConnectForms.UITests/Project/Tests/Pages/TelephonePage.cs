using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class TelephonePage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "What's your telephone number? (optional)";
        private static By TelephoneField => By.CssSelector("#telephone");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public AreasOfWorkInterestPage EnterValidTelephoneNumber()
        {
            formCompletionHelper.SendKeys(TelephoneField, "01423554896");
            formCompletionHelper.ClickElement(ContinueButton);
            return new AreasOfWorkInterestPage(context);
        }
    }
}
