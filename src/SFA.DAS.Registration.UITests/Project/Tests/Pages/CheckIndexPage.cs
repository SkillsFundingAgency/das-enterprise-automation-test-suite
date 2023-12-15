using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CheckIndexPage(ScenarioContext context) : CheckPage(context)
    {
        protected override string PageTitle { get; }
        protected override By Identifier => By.Id("service-start");
    }
}
