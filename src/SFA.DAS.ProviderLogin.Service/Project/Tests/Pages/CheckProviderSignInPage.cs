using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class CheckProviderSignInPage : CheckPage
    {
        protected override By Identifier => By.Id("sfaLogin");

        public CheckProviderSignInPage(ScenarioContext context) : base(context) { }
    }
}
