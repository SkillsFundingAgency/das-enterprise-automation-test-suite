using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class CheckProviderSignInPage : CheckPage
    {
        protected override By Identifier => By.Id("sfaLogin");

        public CheckProviderSignInPage(ScenarioContext context) : base(context)
        {
        }
    }
}
