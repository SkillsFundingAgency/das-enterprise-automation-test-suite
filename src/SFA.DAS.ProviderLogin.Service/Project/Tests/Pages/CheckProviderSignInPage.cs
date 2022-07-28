using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class CheckProviderSignInPage : CheckPageUsingShorterTimeOut
    {
        protected override By Identifier => By.Id("sfaLogin");

        public CheckProviderSignInPage(ScenarioContext context) : base(context) { }
    }
}
