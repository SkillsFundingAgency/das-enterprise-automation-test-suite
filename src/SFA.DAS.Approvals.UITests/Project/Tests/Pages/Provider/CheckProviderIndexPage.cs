using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
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
