using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages
{
    public class EmailVerificationPage : AEDBasePage
    {
        protected override string PageTitle => "Click the link we've sent to";

        protected override By PageHeader => By.ClassName("govuk-heading-xl");
        
        public EmailVerificationPage(ScenarioContext context) : base(context) { }

    }
}
