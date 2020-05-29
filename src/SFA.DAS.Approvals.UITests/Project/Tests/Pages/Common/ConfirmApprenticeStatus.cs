using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class ConfirmApprenticeStatus : ApprenticeDetailsPage
    {
        protected override By PageHeader => By.CssSelector(".heading-large");

        public ConfirmApprenticeStatus(ScenarioContext context) : base(context) { }
    }
}