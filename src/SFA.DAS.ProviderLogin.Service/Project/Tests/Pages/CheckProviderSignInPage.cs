using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class CheckProviderSignInPage : CheckProviderPage
    {
        protected override By Identifier => By.Id("sfaLogin");

        public CheckProviderSignInPage(ScenarioContext context) : base(context) { }
    }
}
