using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class CheckProviderIndexPage : CheckProviderPage
    {
        protected override string PageTitle { get; }

        protected override By Identifier => By.CssSelector(".button-start");

        public CheckProviderIndexPage(ScenarioContext context) : base(context) { }
    }
}
