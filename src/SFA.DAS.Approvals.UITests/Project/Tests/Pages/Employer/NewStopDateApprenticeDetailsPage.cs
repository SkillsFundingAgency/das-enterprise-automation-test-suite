using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class NewStopDateApprenticeDetailsPage : ApprenticeDetailsPage
    {
        protected override string PageTitle => "New stop date confirmed";        // "Apprenticeship stopped";
        protected override By PageHeader => By.CssSelector("h3.das-notification__heading");

        public NewStopDateApprenticeDetailsPage(ScenarioContext context) : base(context) { }
    }
}