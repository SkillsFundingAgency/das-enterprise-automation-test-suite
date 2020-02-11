using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CheckIndexPage : CheckPage
    {
        protected override string PageTitle { get; }
        protected override By Identifier => By.Id("service-start");

        public CheckIndexPage(ScenarioContext context) : base(context) { }
    }
}
