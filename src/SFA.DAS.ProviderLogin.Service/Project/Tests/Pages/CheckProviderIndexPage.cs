using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Pages
{
    public class CheckProviderIndexPage : CheckPage
    {
        protected override string PageTitle { get; }

        protected override By Identifier => By.CssSelector(".button-start");

        public CheckProviderIndexPage(ScenarioContext context) : base(context)
        {

        }
    }
}
