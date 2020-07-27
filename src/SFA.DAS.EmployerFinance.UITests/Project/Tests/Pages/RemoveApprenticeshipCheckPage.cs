using OpenQA.Selenium;
using SFA.DAS.Login.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class RemoveApprenticeshipCheckPage : CheckPage
    {
        protected override string PageTitle { get; }

        protected override By Identifier => By.CssSelector("a[href*='ConfirmRemoval']");

        public RemoveApprenticeshipCheckPage(ScenarioContext context) : base(context) { }
    }
}
