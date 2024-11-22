using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class PostcodePage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "What is your home postcode?";
        private static By PostcodeField => By.CssSelector("#postalCode");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public TelephonePage EnterValidPostcode()
        {
            formCompletionHelper.SendKeys(PostcodeField, earlyConnectDataHelper.PostCode);
            formCompletionHelper.ClickElement(ContinueButton);
            return new TelephonePage(context);
        }
    }
}
