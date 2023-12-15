using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class RemoveApprenticeshipCheckPage(ScenarioContext context) : CheckPage(context)
    {
        protected override string PageTitle { get; }

        protected override By Identifier => By.CssSelector("a[href*='ConfirmRemoval']");
    }
}
