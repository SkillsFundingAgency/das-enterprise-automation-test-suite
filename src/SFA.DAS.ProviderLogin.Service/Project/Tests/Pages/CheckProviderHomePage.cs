using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class CheckProviderPireanPreprodPage : CheckProviderPage
    {
        protected override string PageTitle { get; }

        protected override By Identifier => By.XPath("//span[contains(text(),'Pirean Preprod')]");

        public By PireanPreprod => Identifier;

        public CheckProviderPireanPreprodPage(ScenarioContext context) : base(context) { }
    }

    public class CheckProviderHomePage : CheckProviderPage
    {
        protected override string PageTitle { get; }

        protected override By Identifier => By.Id("account-home");

        public CheckProviderHomePage(ScenarioContext context) : base(context) { }
    }
}
